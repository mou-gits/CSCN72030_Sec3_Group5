import 'package:battery_plus/battery_plus.dart';

//batteryreader to read battery temperature and ensure optimal level
class BatteryTempReader {
  final Battery _battery = Battery();

  Future<int> getBatteryLevel() async {
    return await _battery.batteryLevel;
  }

  Future<bool> isBatteryOptimal() async {
    int level = await getBatteryLevel();
    // Consider optimal if battery is around 50% (+/- 5%)
    return (level >= 45 && level <= 55);
  }
}