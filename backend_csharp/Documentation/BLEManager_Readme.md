# BLEManager

## Overview
`BLEManager` is a C# class that provides Bluetooth Low Energy (BLE) functionality on Windows.  
It allows applications to **scan**, **connect**, and **interact** with BLE devices using the `Windows.Devices.Bluetooth` APIs.  
Designed for event-driven integration with WinForms, it uses a logger (`ILogger`) and exposes events for UI updates.

---

## Features
- Scan for nearby BLE devices.
- Connect to a device by its ID.
- Enumerate GATT services and characteristics.
- Enable notifications and handle incoming values.
- Read and write to specific characteristics.
- Provide event-driven updates for UI integration.

---

## Key Events
- **OnDeviceFound** → Raised when a new device is discovered (`DeviceEntry` payload).
- **OnLog** → Raised for log messages (`string` payload).
- **OnDeviceInfoReady** → Raised after connection with device ID and GATT summary.

---

## Common Methods
```csharp
_bleManager.StartScan();                     // Begin scanning for devices
_bleManager.StopScan();                      // Stop scanning
await _bleManager.ConnectAsync(deviceId);    // Connect to a device
await _bleManager.GetGattSummaryAsync();     // Enumerate services/characteristics
await _bleManager.EnableNotificationsAsync(characteristic); // Subscribe to notifications
await _bleManager.ReadCharacteristicAsync(serviceUuid, characteristicUuid); // Read
await _bleManager.WriteCharacteristicAsync(serviceUuid, characteristicUuid, "Hello"); // Write
await _bleManager.ReadNotifyCharacteristicAsync(); // Read predefined Notify characteristic

