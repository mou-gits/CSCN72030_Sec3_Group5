# Sensor Surrogate App (Flutter BLE Peripheral)

This Flutter app simulates a BLE-based temperature sensor by advertising the phone’s battery temperature as a BLE peripheral. It will be paired by the backend controller to initialize room simulation.

---

## Getting Started

### 1. Clone the Repo

```bash
git clone https://github.com/<your-team>/dorm-climate-control.git
cd dorm-climate-control/mobile/sensor_surrogate
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

- This app will act as a **BLE peripheral**, advertising battery temperature
- Use `flutter_blue_plus` or `reactive_ble_mobile` for BLE support
- Battery temperature can be accessed via platform channels or simulated

---

## 🧠 Integration Expectations

- The backend will scan and pair with this app via BLE
- Once paired, it will read advertised temperature and begin simulation
- You do **not** need to handle backend logic — just advertise correctly

---

## Dev Environment Tips

- Use Android Studio or VS Code with Flutter plugin
- Test on physical Android device (BLE support is limited in emulators)
- Enable location and Bluetooth permissions

---

## Folder Structure

```
sensor_surrogate/
├── lib/
│   └── main.dart
├── pubspec.yaml
└── README.md
```

---

## Assigned To

- [Your Name Here]
