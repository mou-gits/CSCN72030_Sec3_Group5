import 'package:battery_plus/battery_plus.dart';

/// Reads battery level and determines if battery is optimal
/// Used as a surrogate for temperature sensor in the SCADA system
class BatteryTempReader {
  final Battery _battery;

  // Constructor with optional battery parameter for testing
  BatteryTempReader({Battery? battery}) : _battery = battery ?? Battery();

  /// Get the current battery level (0-100%)
  Future<int> getBatteryLevel() async {
    try {
      final level = await _battery.batteryLevel;
      return level;
    } catch (e) {
      // Return 0 if there's an error reading battery
      return 0;
    }
  }

  /// Check if battery is optimal (above 50%)
  /// Returns true if battery is above 50%, false otherwise
  Future<bool> isBatteryOptimal() async {
    final level = await getBatteryLevel();
    return level > 50;
  }

  /// Get battery state (charging, discharging, etc.)
  Future<BatteryState> getBatteryState() async {
    try {
      return await _battery.batteryState;
    } catch (e) {
      return BatteryState.unknown;
    }
  }
}