import 'package:battery_plus/battery_plus.dart';

class BatteryTempReader {
  final Battery battery;

  BatteryTempReader({Battery? battery}) : battery = battery ?? Battery();

  Future<int> getBatteryLevel() async {
    return await battery.batteryLevel;
  }

  Future<bool> isBatteryOptimal() async {
    final level = await getBatteryLevel();
    return level >= 40 && level <= 60;
  }
}
