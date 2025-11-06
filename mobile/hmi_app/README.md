# HMI App (Flutter BLE Central)

This Flutter app acts as a Human-Machine Interface (HMI), allowing users to input desired room temperature. It connects to the backend via BLE and transmits the value.

---

## Getting Started

### 1. Clone the Repo

```bash
git clone https://github.com/<your-team>/dorm-climate-control.git
cd dorm-climate-control/mobile/hmi_app
```

### 2. Install Flutter

Follow the official guide: [Flutter Install](https://docs.flutter.dev/get-started/install)

- Ensure `flutter doctor` passes all checks
- Use **Flutter 3.10+** for compatibility

### 3. Set Up the Project

```bash
flutter pub get
```

---

## Development Notes

- This app will act as a **BLE central**, scanning and connecting to the backend
- After pairing, it will send desired temperature via BLE
- Use `flutter_blue_plus` or `reactive_ble_mobile` for BLE support

---

## Integration Expectations

- The backend will expose BLE characteristics for receiving temperature
- You’ll send a float value (e.g., `22.5`) when the user taps “Set Temperature”
- You do **not** need to simulate or control HVAC — just transmit input

---

## Dev Environment Tips

- Use Android Studio or VS Code with Flutter plugin
- Test on physical Android device (BLE support is limited in emulators)
- Enable location and Bluetooth permissions

---

## 📂 Folder Structure

```
hmi_app/
├── lib/
│   └── main.dart
├── pubspec.yaml
└── README.md
```