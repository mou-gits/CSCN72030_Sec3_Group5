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
      // Arrange
      mockBattery = MockBattery();
      batteryTempReader = BatteryTempReader(battery: mockBattery);
    });

    test('getBatteryLevel returns the mocked battery level', () async {
      // Arrange
      const mockLevel = 42;
      when(mockBattery.batteryLevel).thenAnswer((_) async => mockLevel);

      // Act
      final level = await batteryTempReader.getBatteryLevel();

      // Assert
      expect(level, mockLevel);
    });

    test('isBatteryOptimal returns true for level between 40 and 60', () async {
      // Arrange
      const optimalLevel = 50;
      when(mockBattery.batteryLevel).thenAnswer((_) async => optimalLevel);

      // Act
      final isOptimal = await batteryTempReader.isBatteryOptimal();

      // Assert
      expect(isOptimal, true);
    });

    test('isBatteryOptimal returns false for level below 40', () async {
      // Arrange
      const lowLevel = 39;
      when(mockBattery.batteryLevel).thenAnswer((_) async => lowLevel);

      // Act
      final isOptimal = await batteryTempReader.isBatteryOptimal();

      // Assert
      expect(isOptimal, false);
    });

    test('isBatteryOptimal returns false for level above 60', () async {
      // Arrange
      const highLevel = 61;
      when(mockBattery.batteryLevel).thenAnswer((_) async => highLevel);

      // Act
      final isOptimal = await batteryTempReader.isBatteryOptimal();

      // Assert
      expect(isOptimal, false);
    });
  });
}
