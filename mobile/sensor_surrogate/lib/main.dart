import 'package:flutter/material.dart';
import 'battery_temp_reader.dart';

void main() => runApp(const DormClimateApp());

class DormClimateApp extends StatelessWidget {
  const DormClimateApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Dorm Climate Control',
      theme: ThemeData.dark(),
      debugShowCheckedModeBanner: false,
      home: const HMIScreen(),
    );
  }
}

class HMIScreen extends StatefulWidget {
  const HMIScreen({super.key});

  @override
  State<HMIScreen> createState() => _HMIScreenState();
}

class _HMIScreenState extends State<HMIScreen> {
  late BatteryTempReader _batteryTempReader;
  
  // Temperature control
  double currentTemp = 22.5;
  double targetTemp = 22.0;
  bool heaterOn = false;
  bool coolerOn = false;
  
  // Battery sensor data
  int? batteryLevel;
  bool? isOptimal;

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
      batteryLevel = level;
      isOptimal = optimal;
    });
  }

  void increaseTarget() {
    setState(() {
      if (targetTemp < 28) targetTemp += 0.5;
    });
  }

  void decreaseTarget() {
    setState(() {
      if (targetTemp > 18) targetTemp -= 0.5;
    });
  }

  void toggleHeater() {
    setState(() {
      heaterOn = !heaterOn;
      if (heaterOn) coolerOn = false;
    });
  }

  void toggleCooler() {
    setState(() {
      coolerOn = !coolerOn;
      if (coolerOn) heaterOn = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Dorm Climate Control HMI'),
        backgroundColor: Colors.blue.shade900,
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            // Battery Sensor Info
            Card(
              color: Colors.grey.shade900,
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        const Text(
                          'Battery Sensor',
                          style: TextStyle(
                            fontSize: 18,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        IconButton(
                          onPressed: _loadBatteryInfo,
                          icon: const Icon(Icons.refresh),
                          tooltip: 'Refresh Battery',
                        ),
                      ],
                    ),
                    const SizedBox(height: 10),
                    if (batteryLevel == null)
                      const CircularProgressIndicator()
                    else
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceAround,
                        children: [
                          Column(
                            children: [
                              Icon(
                                Icons.battery_charging_full,
                                size: 40,
                                color: isOptimal == true ? Colors.green : Colors.red,
                              ),
                              const SizedBox(height: 5),
                              Text(
                                '$batteryLevel%',
                                style: TextStyle(
                                  fontSize: 24,
                                  fontWeight: FontWeight.bold,
                                  color: isOptimal == true ? Colors.green : Colors.red,
                                ),
                              ),
                            ],
                          ),
                          Column(
                            children: [
                              Text(
                                isOptimal == true ? 'Optimal' : 'Not Optimal',
                                style: TextStyle(
                                  fontSize: 16,
                                  color: isOptimal == true ? Colors.green : Colors.red,
                                  fontWeight: FontWeight.bold,
                                ),
                              ),
                            ],
                          ),
                        ],
                      ),
                  ],
                ),
              ),
            ),

            const SizedBox(height: 20),

            // Current Temperature Display
            Card(
              child: Padding(
                padding: const EdgeInsets.all(20.0),
                child: Column(
                  children: [
                    const Text(
                      'Current Temperature',
                      style: TextStyle(fontSize: 18),
                    ),
                    const SizedBox(height: 10),
                    Text(
                      '${currentTemp.toStringAsFixed(1)}°C',
                      style: const TextStyle(
                        fontSize: 48,
                        fontWeight: FontWeight.bold,
                        color: Colors.orange,
                      ),
                    ),
                  ],
                ),
              ),
            ),

            const SizedBox(height: 20),

            // Target Temperature Control
            Card(
              child: Padding(
                padding: const EdgeInsets.all(20.0),
                child: Column(
                  children: [
                    const Text(
                      'Target Temperature',
                      style: TextStyle(fontSize: 18),
                    ),
                    const SizedBox(height: 10),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        IconButton(
                          onPressed: decreaseTarget,
                          icon: const Icon(Icons.remove_circle),
                          iconSize: 40,
                          color: Colors.blue,
                        ),
                        const SizedBox(width: 20),
                        Text(
                          '${targetTemp.toStringAsFixed(1)}°C',
                          style: const TextStyle(
                            fontSize: 40,
                            fontWeight: FontWeight.bold,
                            color: Colors.cyan,
                          ),
                        ),
                        const SizedBox(width: 20),
                        IconButton(
                          onPressed: increaseTarget,
                          icon: const Icon(Icons.add_circle),
                          iconSize: 40,
                          color: Colors.blue,
                        ),
                      ],
                    ),
                    const SizedBox(height: 10),
                    const Text(
                      'Range: 18°C - 28°C',
                      style: TextStyle(color: Colors.grey),
                    ),
                  ],
                ),
              ),
            ),

            const SizedBox(height: 20),

            // Actuator Controls
            const Text(
              'Actuator Controls',
              style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
              textAlign: TextAlign.center,
            ),
            
            const SizedBox(height: 10),

            Row(
              children: [
                // Heater Button
                Expanded(
                  child: Card(
                    color: heaterOn ? Colors.orange.shade700 : null,
                    child: InkWell(
                      onTap: toggleHeater,
                      child: Padding(
                        padding: const EdgeInsets.all(20.0),
                        child: Column(
                          children: [
                            Icon(
                              Icons.local_fire_department,
                              size: 50,
                              color: heaterOn ? Colors.white : Colors.orange,
                            ),
                            const SizedBox(height: 10),
                            Text(
                              'HEATER',
                              style: TextStyle(
                                fontSize: 16,
                                fontWeight: FontWeight.bold,
                                color: heaterOn ? Colors.white : null,
                              ),
                            ),
                            const SizedBox(height: 5),
                            Text(
                              heaterOn ? 'ON' : 'OFF',
                              style: TextStyle(
                                fontSize: 14,
                                color: heaterOn ? Colors.white : Colors.grey,
                              ),
                            ),
                          ],
                        ),
                      ),
                    ),
                  ),
                ),

                const SizedBox(width: 10),

                // Cooler Button
                Expanded(
                  child: Card(
                    color: coolerOn ? Colors.blue.shade700 : null,
                    child: InkWell(
                      onTap: toggleCooler,
                      child: Padding(
                        padding: const EdgeInsets.all(20.0),
                        child: Column(
                          children: [
                            Icon(
                              Icons.ac_unit,
                              size: 50,
                              color: coolerOn ? Colors.white : Colors.blue,
                            ),
                            const SizedBox(height: 10),
                            Text(
                              'COOLER',
                              style: TextStyle(
                                fontSize: 16,
                                fontWeight: FontWeight.bold,
                                color: coolerOn ? Colors.white : null,
                              ),
                            ),
                            const SizedBox(height: 5),
                            Text(
                              coolerOn ? 'ON' : 'OFF',
                              style: TextStyle(
                                fontSize: 14,
                                color: coolerOn ? Colors.white : Colors.grey,
                              ),
                            ),
                          ],
                        ),
                      ),
                    ),
                  ),
                ),
              ],
            ),

            const SizedBox(height: 20),

            // Status
            Card(
              color: Colors.grey.shade900,
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    const Icon(Icons.info_outline, color: Colors.cyan),
                    const SizedBox(width: 10),
                    Text(
                      'Status: ${heaterOn ? 'Heating' : coolerOn ? 'Cooling' : 'Idle'}',
                      style: const TextStyle(fontSize: 16),
                    ),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
