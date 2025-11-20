import 'package:flutter/material.dart';
import 'battery_temp_reader.dart';

void main() => runApp(const SensorSurrogateApp());

class SensorSurrogateApp extends StatelessWidget {
  const SensorSurrogateApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Sensor Surrogate',
      theme: ThemeData(primarySwatch: Colors.blue),
      home: const BatteryHomePage(),
    );
  }
}

class BatteryHomePage extends StatefulWidget {
  const BatteryHomePage({super.key});

  @override
  State<BatteryHomePage> createState() => _BatteryHomePageState();
}

class _BatteryHomePageState extends State<BatteryHomePage> {
  late BatteryTempReader _batteryTempReader;
  int? _batteryLevel;
  bool? _isOptimal;

  @override
  void initState() {
    super.initState();
    _batteryTempReader = BatteryTempReader();
    _loadBatteryInfo();
  }

  Future<void> _loadBatteryInfo() async {
    final level = await _batteryTempReader.getBatteryLevel();
    final optimal = await _batteryTempReader.isBatteryOptimal();
    setState(() {
      _batteryLevel = level;
      _isOptimal = optimal;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Sensor Surrogate')),
      body: Center(
        child: _batteryLevel == null
            ? const CircularProgressIndicator()
            : Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    'Battery level: $_batteryLevel%',
                    style: const TextStyle(fontSize: 24),
                  ),
                  const SizedBox(height: 12),
                  Text(
                    'Battery optimal? ${_isOptimal == true ? 'Yes' : 'No'}',
                    style: TextStyle(
                      fontSize: 20,
                      color: _isOptimal == true ? Colors.green : Colors.red,
                    ),
                  ),
                  const SizedBox(height: 28),
                  ElevatedButton(
                    onPressed: _loadBatteryInfo,
                    child: const Text('Refresh'),
                  ),
                ],
              ),
      ),
    );
  }

  
}
