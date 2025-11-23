using backend_csharp.Utilities;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Storage.Streams;


[SupportedOSPlatform("windows10.0.26100.0")]
public class BLEManager
{

    private static readonly Guid TargetServiceUuid =
    Guid.Parse("12345678-1234-5678-1234-56789abcdef0");

    private static readonly Guid NotifyCharacteristicUuid =
        Guid.Parse("12345678-1234-5678-1234-56789abcdef1");

    private readonly ILogger _logger;
    private BluetoothLEAdvertisementWatcher _watcher;
    private Dictionary<string, ulong> _discoveredDevices = new();
    private BluetoothLEDevice? _connectedDevice;

    public event Action<DeviceEntry>? OnDeviceFound;
    public event Action<string>? OnLog;

    public event Action<string, string> OnDeviceInfoReady;
    // payload: (deviceIdHex, gattSummaryText)


    // Enumerate all services and characteristics; return a formatted string for display

    public BLEManager(ILogger logger)
    {
        _logger = logger;
        _watcher = new BluetoothLEAdvertisementWatcher
        {
            ScanningMode = BluetoothLEScanningMode.Active
        };
        _watcher.Received += Watcher_Received;
    }
    public async Task<string> GetGattSummaryAsync()
    {
        if (_connectedDevice == null)
            return "No device connected.";

        var sb = new System.Text.StringBuilder();

        var servicesResult = await _connectedDevice.GetGattServicesAsync();
        if (servicesResult.Status != GattCommunicationStatus.Success)
            return $"Failed to read GATT services: {servicesResult.Status}";

        foreach (var service in servicesResult.Services)
        {
            sb.AppendLine($"Service: {service.Uuid}");

            var characteristicsResult = await service.GetCharacteristicsAsync();
            if (characteristicsResult.Status != GattCommunicationStatus.Success)
            {
                sb.AppendLine($"  (Failed to read characteristics: {characteristicsResult.Status})");
                continue;
            }

            foreach (var characteristic in characteristicsResult.Characteristics)
            {
                sb.AppendLine($"  Char: {characteristic.Uuid} [{characteristic.CharacteristicProperties}]");
            }
        }

        return sb.ToString();
    }

    // Resolve first Notify/Read and first Write characteristic for later use
    public async Task<(GattCharacteristic notifyRead, GattCharacteristic write)> GetKeyCharacteristicsAsync()
    {
        GattCharacteristic notifyRead = null;
        GattCharacteristic write = null;

        if (_connectedDevice == null)
            return (null, null);

        var servicesResult = await _connectedDevice.GetGattServicesAsync();
        if (servicesResult.Status != GattCommunicationStatus.Success)
            return (null, null);

        foreach (var service in servicesResult.Services)
        {
            var charsResult = await service.GetCharacteristicsAsync();
            if (charsResult.Status != GattCommunicationStatus.Success)
                continue;

            foreach (var ch in charsResult.Characteristics)
            {
                var props = ch.CharacteristicProperties;

                if (notifyRead == null && (props.HasFlag(GattCharacteristicProperties.Notify) || props.HasFlag(GattCharacteristicProperties.Read)))
                    notifyRead = ch;

                if (write == null && props.HasFlag(GattCharacteristicProperties.Write))
                    write = ch;

                if (notifyRead != null && write != null)
                    return (notifyRead, write);
            }
        }

        return (notifyRead, write);
    }

    // Enable notifications on a characteristic and route values to OnLog
    public async Task<bool> EnableNotificationsAsync(GattCharacteristic characteristic)
    {
        if (characteristic == null)
            return false;

        characteristic.ValueChanged += (s, e) =>
        {
            var reader = Windows.Storage.Streams.DataReader.FromBuffer(e.CharacteristicValue);
            byte[] data = new byte[e.CharacteristicValue.Length];
            reader.ReadBytes(data);
            OnLog?.Invoke($"Notification from {characteristic.Uuid}: {BitConverter.ToString(data)}");
        };

        var status = await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
            GattClientCharacteristicConfigurationDescriptorValue.Notify);

        return status == GattCommunicationStatus.Success;
    }
    public async Task<string> ConnectAsync(string deviceId)
    {
        if (!_discoveredDevices.TryGetValue(deviceId, out ulong address))
        {
            _logger.Log($"Device {deviceId} not found in discovered list.");
            return "Device not found.";
        }

        _connectedDevice = await BluetoothLEDevice.FromBluetoothAddressAsync(address);
        if (_connectedDevice == null)
        {
            _logger.Log($"Failed to connect to {deviceId}.");
            return "Connection failed.";
        }

        _logger.Log($"Connected to {_connectedDevice.Name ?? deviceId} ({deviceId})");

        // Build summary of ONLY the target characteristic
        return await GetTargetCharacteristicSummaryAsync();
    }

    private async Task<string> GetTargetCharacteristicSummaryAsync()
    {
        if (_connectedDevice == null) return "No device connected.";

        var servicesResult = await _connectedDevice.GetGattServicesAsync();
        if (servicesResult.Status != GattCommunicationStatus.Success)
            return $"Failed to read GATT services: {servicesResult.Status}";

        var targetService = servicesResult.Services
            .FirstOrDefault(s => s.Uuid == TargetServiceUuid);

        if (targetService == null)
            return $"Target service {TargetServiceUuid} not found.";

        var charsResult = await targetService.GetCharacteristicsAsync();
        if (charsResult.Status != GattCommunicationStatus.Success)
            return $"Failed to read characteristics: {charsResult.Status}";

        var notifyChar = charsResult.Characteristics
            .FirstOrDefault(c => c.Uuid == NotifyCharacteristicUuid);

        if (notifyChar == null)
            return $"Notify characteristic {NotifyCharacteristicUuid} not found.";

        return $"Characteristic: {notifyChar.Uuid} [{notifyChar.CharacteristicProperties}]";
    }
    private async void Watcher_Received(BluetoothLEAdvertisementWatcher sender,
                                    BluetoothLEAdvertisementReceivedEventArgs args)
    {
        string deviceId = args.BluetoothAddress.ToString("X");

        if (!_discoveredDevices.ContainsKey(deviceId))
        {
            _discoveredDevices[deviceId] = args.BluetoothAddress;

            // Try advertisement name first
            string name = args.Advertisement.LocalName;

            // If empty, resolve via BluetoothLEDevice
            if (string.IsNullOrEmpty(name))
            {
                try
                {
                    var device = await BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress);
                    name = device?.Name ?? "NoName";
                }
                catch
                {
                    name = "NoName";
                }
            }

            var entry = new DeviceEntry
            {
                Id = deviceId,
                Display = $"{name} ({deviceId})"
            };

            OnDeviceFound?.Invoke(entry);
            OnLog?.Invoke($"Discovered device: {entry.Display}");
        }
    }
    public void StartScan()
    {
        try
        {
            if (_watcher.Status != BluetoothLEAdvertisementWatcherStatus.Started)
            {
                _watcher.Start();
                OnLog?.Invoke("Started scanning for BLE devices...");
            }
        }
        catch (COMException ex)
        {
            OnLog?.Invoke("Failed to start BLE scan. Please ensure Bluetooth is turned on and your adapter is available.");
            OnLog?.Invoke($"Error details: {ex.Message}");
        }
        catch (Exception ex)
        {
            OnLog?.Invoke($"Unexpected error starting BLE scan: {ex.Message}");
        }
    }

    public void StopScan()
    {
        try
        {
            if (_watcher.Status == BluetoothLEAdvertisementWatcherStatus.Started)
            {
                _watcher.Stop();
                OnLog?.Invoke("Stopped scanning.");
            }
        }
        catch (Exception ex)
        {
            OnLog?.Invoke($"Error stopping scan: {ex.Message}");
        }
    }

    public async Task<string> ReadCharacteristicAsync(Guid serviceUuid, Guid characteristicUuid)
    {
        if (_connectedDevice is null)
        {
            OnLog?.Invoke("No device connected.");
            return "N/A";
        }

        var services = await _connectedDevice.GetGattServicesAsync();
        foreach (var service in services.Services)
        {
            if (service.Uuid == serviceUuid)
            {
                var chars = await service.GetCharacteristicsAsync();
                foreach (var ch in chars.Characteristics)
                {
                    if (ch.Uuid == characteristicUuid)
                    {
                        var result = await ch.ReadValueAsync();
                        var reader = DataReader.FromBuffer(result.Value);
                        return reader.ReadString(result.Value.Length);
                    }
                }
            }
        }
        return "N/A";
    }

    public async Task WriteCharacteristicAsync(Guid serviceUuid, Guid characteristicUuid, string value)
    {
        var services = await _connectedDevice.GetGattServicesAsync();
        foreach (var service in services.Services)
        {
            if (service.Uuid == serviceUuid)
            {
                var chars = await service.GetCharacteristicsAsync();
                foreach (var ch in chars.Characteristics)
                {
                    if (ch.Uuid == characteristicUuid)
                    {
                        var writer = new DataWriter();
                        writer.WriteString(value);
                        await ch.WriteValueAsync(writer.DetachBuffer());
                        OnLog?.Invoke($"Wrote {value} to {characteristicUuid}");
                    }
                }
            }
        }
    }

    public async Task<string> ReadNotifyCharacteristicAsync()
    {
        if (_connectedDevice == null) return "No device connected.";

        // Get the target service
        var servicesResult = await _connectedDevice.GetGattServicesAsync();
        if (servicesResult.Status != GattCommunicationStatus.Success)
            return $"Failed to read services: {servicesResult.Status}";

        var targetService = servicesResult.Services
            .FirstOrDefault(s => s.Uuid == TargetServiceUuid);
        if (targetService == null)
            return $"Service {TargetServiceUuid} not found.";

        // Get the target characteristic
        var charsResult = await targetService.GetCharacteristicsAsync();
        if (charsResult.Status != GattCommunicationStatus.Success)
            return $"Failed to read characteristics: {charsResult.Status}";

        var notifyChar = charsResult.Characteristics
            .FirstOrDefault(c => c.Uuid == NotifyCharacteristicUuid);
        if (notifyChar == null)
            return $"Characteristic {NotifyCharacteristicUuid} not found.";

        // Actually read the value
        var readResult = await notifyChar.ReadValueAsync();
        if (readResult.Status != GattCommunicationStatus.Success)
            return $"Read failed: {readResult.Status}";

        var reader = Windows.Storage.Streams.DataReader.FromBuffer(readResult.Value);
        byte[] data = new byte[readResult.Value.Length];
        reader.ReadBytes(data);

        // Interpret as UTF‑8 string (assuming your emulator writes text)
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
