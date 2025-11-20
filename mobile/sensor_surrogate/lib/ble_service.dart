import 'dart:typed_data';
import 'package:flutter_ble_peripheral/flutter_ble_peripheral.dart';
import 'package:permission_handler/permission_handler.dart';

/// Service class to handle BLE peripheral advertising
/// Broadcasts battery temperature data for SCADA backend to consume
class BleAdvertisingService {
  final FlutterBlePeripheral _blePeripheral = FlutterBlePeripheral();
  bool _isAdvertising = false;

  bool get isAdvertising => _isAdvertising;

  /// Request necessary BLE permissions for Android
  Future<bool> requestPermissions() async {
    Map<Permission, PermissionStatus> statuses = await [
      Permission.bluetooth,
      Permission.bluetoothAdvertise,
      Permission.bluetoothConnect,
      Permission.location,
    ].request();

    return statuses.values.every((status) => status.isGranted);
  }

  /// Start BLE advertising with battery temperature data
  ///
  /// [batteryLevel] - Current battery percentage (0-100)
  /// [deviceName] - Optional custom device name for identification
  Future<String> startAdvertising(int batteryLevel, {String? deviceName}) async {
    try {
      // Stop if already advertising
      if (_isAdvertising) {
        await stopAdvertising();
      }

      // Request permissions if not granted
      bool permissionsGranted = await requestPermissions();
      if (!permissionsGranted) {
        return 'Bluetooth permissions not granted';
      }

      // Start advertising with battery data
     await _blePeripheral.start(
  advertiseData: AdvertiseData(
    includeDeviceName: true,
    localName: deviceName ?? 'SensorSurrogate',
    manufacturerId: 1234,
    manufacturerData: Uint8List.fromList([batteryLevel]),
    serviceData: Uint8List.fromList(batteryLevel.toString().codeUnits), // FIXED
  ),
);


      _isAdvertising = true;
      return 'Broadcasting battery level: $batteryLevel%';
    } catch (e) {
      _isAdvertising = false;
      return 'Error starting BLE: $e';
    }
  }

  /// Stop BLE advertising
  Future<String> stopAdvertising() async {
    try {
      await _blePeripheral.stop();
      _isAdvertising = false;
      return 'Stopped advertising';
    } catch (e) {
      return 'Error stopping BLE: $e';
    }
  }

  /// Check if BLE is supported on this device
  Future<bool> isBluetoothSupported() async {
    try {
      // Try to check advertising support
      await _blePeripheral.isAdvertising;
      return true;
    } catch (e) {
      return false;
    }
  }

  /// Cleanup resources
  Future<void> dispose() async {
    if (_isAdvertising) {
      await stopAdvertising();
    }
  }
}
