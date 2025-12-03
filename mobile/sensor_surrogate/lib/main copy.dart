import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_blue_plus/flutter_blue_plus.dart';

import 'hmi/hmi_screen.dart';
import 'ble/ble_client.dart';

void main() {
  final BleClient bleClient = _createBleClient();
  runApp(HmiApp(bleClient: bleClient));
}

BleClient _createBleClient() {
  // On Android / iOS -> use real BLE
  if (defaultTargetPlatform == TargetPlatform.android ||
      defaultTargetPlatform == TargetPlatform.iOS) {
    return FlutterBleClient(
      deviceName: 'MyBleDevice', // TODO: replace with YOUR device name
      serviceUuid: Guid('00001809-0000-1000-8000-00805f9b34fb'), // TODO
      characteristicUuid: Guid('00002a1c-0000-1000-8000-00805f9b34fb'), // TODO
    );
  }

  // On Windows / web -> use mock BLE (still lets you test the UI)
  return MockBleClient();
}

class HmiApp extends StatelessWidget {
  final BleClient bleClient;

  const HmiApp({super.key, required this.bleClient});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'HMI Temperature Controller',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.blue),
        useMaterial3: true,
      ),
      home: HmiScreen(bleClient: bleClient),
    );
  }
}
