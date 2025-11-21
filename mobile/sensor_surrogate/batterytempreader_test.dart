import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:battery_plus/battery_plus.dart';
import 'package:sensor_surrogate/battery_temp_reader.dart';

class MockBattery extends Mock implements Battery {}

void main() {
  group('BatteryTempReader', () {
    late MockBattery mockBattery;
    late BatteryTempReader batteryTempReader;

    setUp(() {
      mockBattery = MockBattery();
      batteryTempReader = BatteryTempReader(battery: mockBattery);
    });

    test('getBatteryLevel returns the mocked battery level', () async {
      const mockLevel = 42;
      when(mockBattery.batteryLevel).thenAnswer((_) => Future.value(mockLevel));

      final level = await batteryTempReader.getBatteryLevel();
      expect(level, mockLevel);
    });

    test('isBatteryOptimal returns true for level between 40 and 60', () async {
      const optimalLevel = 50;
      when(mockBattery.batteryLevel).thenAnswer((_) => Future.value(optimalLevel));

      final isOptimal = await batteryTempReader.isBatteryOptimal();
      expect(isOptimal, true);
    });

    test('isBatteryOptimal returns false for level below 40', () async {
      const lowLevel = 39;
      when(mockBattery.batteryLevel).thenAnswer((_) => Future.value(lowLevel));

      final isOptimal = await batteryTempReader.isBatteryOptimal();
      expect(isOptimal, false);
    });

    test('isBatteryOptimal returns false for level above 60', () async {
      const highLevel = 61;
      when(mockBattery.batteryLevel).thenAnswer((_) => Future.value(highLevel));

      final isOptimal = await batteryTempReader.isBatteryOptimal();
      expect(isOptimal, false);
    });
  });
}
