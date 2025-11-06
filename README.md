# Dorm Climate Control System

A modular, SCADA-inspired system for simulating and controlling dorm room temperatures across multiple devices. Built as a Term 3 project for the **Software Development Life Cycle (SDLC)** course under **Professor Russell**.

---

## Project Overview

This system integrates:

- **Mobile Devices** as BLE-based HMIs and sensor surrogates  
- **Backend Controller** with simulation and HVAC logic (Python + FastAPI)  
- **GUI Frontend** for real-time monitoring (C# WinForms)

It demonstrates centralized control, real-time feedback, and modular design — aligning with SDLC principles of planning, implementation, and iterative refinement.

---

## System Components

| Module | Description |
|--------|-------------|
| `backend/` | Python FastAPI backend with BLE pairing, simulation engine, and HVAC controller |
| `mobile/hmi_app/` | Flutter app for user input (desired temperature) via BLE |
| `mobile/sensor_surrogate/` | Flutter app that advertises battery temperature as a BLE peripheral |
| `gui_frontend/` | C# WinForms GUI that displays telemetry from the backend |
| `docs/` | Architecture notes, sprint plans, and design documentation |
| `tests/` | Unit and integration tests for backend and mobile components |

---

## Getting Started

### Backend Setup

```bash
cd backend
python -m venv .venv
.venv\Scripts\activate     # On Windows
pip install -r requirements.txt
uvicorn main:app --reload
```

### Mobile Apps

Flutter-based apps for:
- BLE sensor surrogate
- BLE HMI for user input

Placeholder files are provided. Full implementation to follow in Sprint 2.

### GUI Frontend
C# WinForms app that:
- Displays room temperatures
- Shows heater/AC actuator states
- Reflects backend state in real time

Placeholder provided. Full implementation to follow in Sprint 2.

### Signal Flow Summary
- Sensor phones advertise battery temperature via BLE
- Backend pairs, reads temp, initializes simulation
- HMI phones send desired temp via BLE
- Backend updates HVAC settings and simulates room temp
- GUI and HMIs receive updated telemetry

### Contributors
- Tanveer Singh Jandu
- Armaan Singh Dhillon
- Kenneth Oluoch
- Moutushi Sarkar

### License
This project is for academic use under the SDLC course. Not licensed for commercial distribution.