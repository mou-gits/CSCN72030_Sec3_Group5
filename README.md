# Dorm Climate Control System - Group 3

A SCADA-inspired climate control simulation for dorm rooms, integrating mobile BLE devices, a C# backend, and a WinForms GUI. Built collaboratively using GitHub workflows, this project demonstrates modular development, BLE communication, and database-backed telemetry.

---

## Repository Overview

This repo contains all components of the system:

- `backend_csharp/` — C# backend logic (SCADA controller, BLE, DB access)
- `gui_frontend/` — C# WinForms GUI for monitoring and control
- `mobile/hmi_app/` — Flutter Android app for user input via BLE
- `mobile/sensor_surrogate/` — Flutter Android app simulating battery temperature via BLE
- `database/` — DB schema and seed data (SQLite or SQL Server LocalDB)
- `docs/` — Architecture, sprint plans, integration notes
- `tests/` — Unit and integration tests

---

## Architecture Summary

| Component              | Platform     | Tech Stack         | Role |
|------------------------|--------------|---------------------|------|
| Backend Controller     | Windows      | C# (.NET)           | SCADA logic, BLE pairing, DB access |
| GUI Frontend           | Windows      | C# WinForms         | Visual display of telemetry and actuator states |
| Mobile HMI App         | Android      | Flutter + BLE       | Sends desired temperature to backend |
| Sensor Surrogate       | Android      | Flutter + BLE       | Advertises battery temperature |
| Database               | Local (Windows) | SQLite or SQL Server LocalDB | Stores telemetry, actuator logs, outside temperature |

---

## BLE Communication

- **Backend (Windows)** acts as BLE central using Windows BLE API or Bluetooth Framework
- **Mobile apps (Android)** use Flutter BLE plugins (`flutter_blue_plus`)
- BLE is used to exchange temperature data and control signals between backend and mobile devices

---

## Sprint 1 Demo Requirements

- Each team member must show **running code** for their assigned user stories
- Any **integration** between modules (e.g., backend ↔ mobile) must be live and working
- Moutushi and Arman must complete and integrate their modules for full marks

---

## GitHub Collaboration Checklist

✅ Repository name: `CSCN72020-SecX-GroupY`  
✅ All team members invited as collaborators  
✅ Professor added to repo access  
✅ Branches created per module or developer  
✅ Pull requests used for integration  
✅ Issues tracked with reproduction steps, root cause, fix details, and version tags  
✅ Only source code files committed — no solution/project files  
✅ Initial Hello World app committed and synced  
✅ Weekly updates and peer reviews documented in Issues

---

## Setup Instructions

Each module has its own `README.md` with setup instructions:
- `backend_csharp/README.md`
- `gui_frontend/README.md`
- `mobile/hmi_app/README.md`
- `mobile/sensor_surrogate/README.md`
- `database/README.md`

---

## Team Members

- Moutushi – Backend logic, BLE integration, GUI coordination
- Arman – Mobile BLE surrogate and HMI integration
- [Add others as needed]

---

## Resources

- [Windows BLE API](https://learn.microsoft.com/en-us/uwp/api/windows.devices.bluetooth)
- [Flutter BLE Plugin](https://pub.dev/packages/flutter_blue_plus)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [SQLite for .NET](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/)
- [GitHub Collaboration Guide](https://docs.github.com/en)

---

## Notes

- All commits, issues, and pull requests are traceable and reviewed 
