import 'package:flutter/material.dart';
import '../ble/ble_client.dart';

class HmiScreen extends StatefulWidget {
  final BleClient bleClient;

  const HmiScreen({super.key, required this.bleClient});

  @override
  State<HmiScreen> createState() => _HmiScreenState();
}

class _HmiScreenState extends State<HmiScreen> {
  final TextEditingController _tempController = TextEditingController();

  String _statusMessage = 'Not connected';
  bool _isSending = false;

  @override
  void dispose() {
    _tempController.dispose();
    super.dispose();
  }

  Future<void> _sendTemperature() async {
    final text = _tempController.text.trim();

    if (text.isEmpty) {
      _showSnackBar('Please enter a temperature value.');
      return;
    }

    final temp = int.tryParse(text);
    if (temp == null) {
      _showSnackBar('Invalid number. Please enter an integer.');
      return;
    }

    setState(() {
      _isSending = true;
      _statusMessage = 'Sending temperature...';
    });

    try {
      await widget.bleClient.sendTemperature(temp);
      setState(() {
        _statusMessage = 'Temperature $temp °C sent successfully.';
      });
    } catch (e) {
      setState(() {
        _statusMessage = 'Failed to send temperature: $e';
      });
      _showSnackBar('Error: $e');
    } finally {
      setState(() {
        _isSending = false;
      });
    }
  }

  void _showSnackBar(String message) {
    ScaffoldMessenger.of(
      context,
    ).showSnackBar(SnackBar(content: Text(message)));
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('HMI Temperature Controller')),
      body: Center(
        child: ConstrainedBox(
          constraints: const BoxConstraints(maxWidth: 400),
          child: Padding(
            padding: const EdgeInsets.all(16),
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                const Text(
                  'Enter desired temperature (°C):',
                  style: TextStyle(fontSize: 16),
                ),
                const SizedBox(height: 8),
                TextField(
                  controller: _tempController,
                  keyboardType: TextInputType.number,
                  decoration: const InputDecoration(
                    border: OutlineInputBorder(),
                    hintText: 'e.g. 22',
                  ),
                ),
                const SizedBox(height: 16),
                SizedBox(
                  width: double.infinity,
                  child: ElevatedButton(
                    onPressed: _isSending ? null : _sendTemperature,
                    child: _isSending
                        ? const SizedBox(
                            height: 18,
                            width: 18,
                            child: CircularProgressIndicator(strokeWidth: 2),
                          )
                        : const Text('Send to Device'),
                  ),
                ),
                const SizedBox(height: 16),
                Text(
                  _statusMessage,
                  textAlign: TextAlign.center,
                  style: const TextStyle(fontSize: 14),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
