import 'package:flutter_blue_plus/flutter_blue_plus.dart';

/// Common BLE client interface
abstract class BleClient {
  Future<void> connect();
  Future<void> sendTemperature(int temperature);
}

/// Real BLE implementation using flutter_blue_plus (for Android / iOS).
class FlutterBleClient implements BleClient {
  final String deviceName; // e.g. "MyBleDevice"
  final Guid serviceUuid; // e.g. Guid("00001809-0000-1000-8000-00805f9b34fb");
  final Guid
  characteristicUuid; // e.g. Guid("00002a1c-0000-1000-8000-00805f9b34fb");

  BluetoothDevice? _device;
  BluetoothCharacteristic? _characteristic;
  bool _connecting = false;

  FlutterBleClient({
    required this.deviceName,
    required this.serviceUuid,
    required this.characteristicUuid,
  });

  @override
  Future<void> connect() async {
    if (_device != null && _characteristic != null) {
      return; // already connected
    }

    if (_connecting) return;
    _connecting = true;

    try {
      // 1. Start scan
      FlutterBluePlus.instance.startScan(timeout: const Duration(seconds: 5));

      // 2. Wait for a device with the given name
      final scanResult = await FlutterBluePlus.instance.scanResults.firstWhere(
        (results) => results.any((r) => r.device.name == deviceName),
      );

      final device = scanResult
          .firstWhere((r) => r.device.name == deviceName)
          .device;
      _device = device;

      // 3. Stop scan
      await FlutterBluePlus.instance.stopScan();

      // 4. Connect
      await device.connect(autoConnect: false);

      // 5. Discover services and characteristics
      final services = await device.discoverServices();
      for (final s in services) {
        if (s.uuid == serviceUuid) {
          for (final c in s.characteristics) {
            if (c.uuid == characteristicUuid) {
              _characteristic = c;
              break;
            }
          }
        }
      }

      if (_characteristic == null) {
        throw Exception('Characteristic not found on device');
      }

      print('FlutterBleClient: Connected to $deviceName');
    } finally {
      _connecting = false;
    }
  }

  @override
  Future<void> sendTemperature(int temperature) async {
    if (_characteristic == null) {
      await connect();
    }

    if (_characteristic == null) {
      throw Exception('Not connected to BLE characteristic');
    }

    // Encode temperature as a 2-byte signed integer (little endian)
    final bytes = <int>[temperature & 0xFF, (temperature >> 8) & 0xFF];

    await _characteristic!.write(bytes, withoutResponse: false);
    print('FlutterBleClient: Sent temperature $temperature °C');
  }
}

/// Mock implementation (for Windows / web / testing).
class MockBleClient implements BleClient {
  bool _connected = false;

  @override
  Future<void> connect() async {
    await Future.delayed(const Duration(milliseconds: 500));
    _connected = true;
    print('MockBleClient: Connected to BLE device');
  }

  @override
  Future<void> sendTemperature(int temperature) async {
    if (!_connected) {
      await connect();
    }
    await Future.delayed(const Duration(milliseconds: 300));
    print('MockBleClient: Sent temperature $temperature °C (MOCK)');
  }
}
