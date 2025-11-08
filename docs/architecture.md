# System Architecture — Dorm Climate Control

This document outlines the modular architecture of the Dorm Climate Control System, designed for a SCADA-like simulation using BLE-connected mobile devices, a C# backend, and a WinForms GUI.

---

## Component Overview

| Module                  | Platform     | Language/Tech       | Description |
|-------------------------|--------------|----------------------|-------------|
| **Backend Controller**  | Windows      | C# (.NET)            | Core SCADA logic, BLE pairing, telemetry routing, DB access |
| **GUI Frontend**        | Windows      | C# WinForms          | Displays room temperature, HVAC state, and BLE status |
| **Sensor Surrogate App**| Android      | Flutter + BLE        | Simulates battery temperature via BLE advertisement |
| **Mobile HMI App**      | Android      | Flutter + BLE        | Sends desired temperature to backend via BLE |
| **Database**            | Local        | SQLite / SQL Server LocalDB | Stores telemetry, actuator logs, and external temperature |

---

## BLE Communication Flow

- **Backend** acts as BLE central using Windows BLE API
- **SensorApp** advertises battery temperature as BLE peripheral
- **HMIApp** connects to backend and sends desired temperature
- **BLEManagerCS** handles pairing, scanning, and GATT communication

---

## Core Backend Modules

- `BLEManagerCS`: Scans, connects, and manages BLE devices
- `Room`: Represents a dorm room with actual and desired temperature
- `HVACController`: Computes actuator output based on temperature delta
- `SimulationEngine`: Evolves room temperature over time
- `TelemetryDispatcher`: Sends updates to GUI and HMI

---

## GUI Panels

- `RoomDisplayPanel`: Shows temperature and actuator state
- `DeviceStatusPanel`: Shows MAC address and pairing status
- Updates triggered by backend telemetry events

---

## Database Schema (Simplified)

- `RoomState(roomId, actualTemp, desiredTemp, hvacOutput)`
- `TelemetryLog(timestamp, roomId, source, value)`
- `DeviceRegistry(macAddress, role, lastSeen)`

---

## Constraints

- Python is not allowed for backend or SCADA logic
- CSV files are deprecated — use a proper DBMS
- BLE must be implemented in C# on Windows
