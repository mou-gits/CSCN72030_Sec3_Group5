Project overview and setup instructions go here. 
# 🏫 Dorm Climate Control System

This project simulates a SCADA-like system for monitoring and controlling dorm room climate. It includes a C# backend, a WinForms GUI, and two Flutter Android apps for mobile interaction via BLE. The system supports real-time telemetry, actuator control, and BLE-based communication between mobile and backend components.

---

## 🧱 Architecture Overview

| Component              | Platform     | Tech Stack         | Role |
|------------------------|--------------|---------------------|------|
| **Backend Controller** | Windows      | C# (.NET)           | SCADA logic, BLE pairing, DB access |
| **GUI Frontend**       | Windows      | C# WinForms         | Visual display of telemetry and actuator states |
| **Mobile HMI App**     | Android      | Flutter + BLE       | Sends desired temperature to backend |
| **Sensor Surrogate**   | Android      | Flutter + BLE       | Advertises battery temperature |
| **Database**           | Local (Windows) | SQLite or SQL Server LocalDB | Stores telemetry, actuator logs, outside temperature |

---

## 🔄 BLE Communication

- **Backend (Windows)** acts as BLE central using Windows BLE API or Bluetooth Framework
- **Mobile apps (Android)** use Flutter BLE plugins (`flutter_blue_plus`)
- BLE is used to exchange temperature data and control signals between backend and mobile devices

---

## 📁 Folder Structure

```
dorm-climate-control/
├── backend_csharp/          # C# backend logic
├── gui_frontend/            # C# WinForms GUI
├── mobile/
│   ├── hmi_app/             # Flutter Android app for HMI
│   └── sensor_surrogate/    # Flutter Android app for sensor simulation
├── database/                # DB schema and seed scripts
├── docs/                    # Architecture, sprint plans, integration notes
├── tests/                   # Unit and integration tests
└── README.md                # This file
```

---

## 🚀 Sprint 1 Demo Requirements

- Each team member must show **running code** for their assigned user stories
- Any **integration** between modules (e.g., backend ↔ mobile) must be live and working
- Moutushi and Arman must complete and integrate their modules for full marks

---

## 🧠 Development Notes

- Backend logic must follow **SOLID principles** in C#
- CSV files are deprecated — use a proper **DBMS** (e.g., SQLite)
- Python is allowed **only for GUI**, not for backend or SCADA logic
- BLE must be implemented in **C# on Windows**, not Python

---

## 🛠️ Setup Instructions

Each module has its own `README.md` with setup instructions:
- `backend_csharp/README.md`
- `gui_frontend/README.md`
- `mobile/hmi_app/README.md`
- `mobile/sensor_surrogate/README.md`
- `database/README.md`

---

## 👥 Team Members

- Moutushi – Backend logic, BLE integration, GUI coordination
- Arman – Mobile BLE surrogate and HMI integration
- [Add others as needed]

---

## 📚 Resources

- [Windows BLE API](https://learn.microsoft.com/en-us/uwp/api/windows.devices.bluetooth)
- [Flutter BLE Plugin](https://pub.dev/packages/flutter_blue_plus)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [SQLite for .NET](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/)

