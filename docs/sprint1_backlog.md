# Sprint Plan — Dorm Climate Control System

This document outlines the sprint schedule, feature assignments, and development goals for each phase of the project.

---

## Sprint 1: Core Backend Logic  
** Dates:** Nov 1 – Nov 10, 2025

| Feature ID | Feature Name              | Description |
|------------|---------------------------|-------------|
| F1.3       | Backend Controller (C#)   | BLE pairing, device registry, backend setup |
| F1.5       | Simulation Engine         | Time-marching model, external temperature integration |
| F1.4       | HVAC Controller Logic     | Actuator logic based on desired vs actual temperature |

---

## Sprint 2: Mobile Apps & GUI  
** Dates:** Nov 11 – Nov 20, 2025

| Feature ID | Feature Name              | Description |
|------------|---------------------------|-------------|
| F1.1       | BLE Sensor Surrogate (Flutter) | BLE advertising, battery temperature, MAC display |
| F1.2       | Mobile HMI (Flutter)      | Desired temperature input, BLE transmission, dynamic pairing |
| F1.6       | GUI Frontend (C#)         | Display MACs, temperatures, actuator states |

---

## Sprint 3: Integration & Stability  
** Dates:** Nov 21 – Nov 28, 2025

| Feature ID | Feature Name              | Description |
|------------|---------------------------|-------------|
| F2.1       | End-to-End BLE Flow       | Verify signal path: Sensor → Backend → HMI → GUI |
| F2.2       | Simulation Stability      | Validate thermal model over time |

---

## Sprint 4: UX & Resilience  
** Dates:** Nov 29 – Dec 5, 2025

| Feature ID | Feature Name              | Description |
|------------|---------------------------|-------------|
| F2.3       | GUI Usability             | Layout responsiveness, refresh accuracy |
| F2.4       | Mobile UX Validation      | BLE reliability, user feedback loop |
| F2.5       | Backend Resilience        | Reconnection handling, telemetry consistency |

---

## Final Week: Delivery & Demo  
** Dates:** Dec 8 – Dec 12, 2025

| Activity | Description |
|----------|-------------|
| Final Delivery & Demo | System walkthrough, presentation, and submission |


---

## Feature Set 1: Core Modules

| ID   | Feature Name           | User Story | Acceptance Criteria |
|------|------------------------|------------|---------------------|
| F1.1 | BLE Sensor Surrogate   | As a developer, I want SensorApp to advertise BLE with battery temp and show MAC | - BLE service is discoverable and includes correct characteristic<br>- Battery temperature updates periodically<br>- UI displays MAC and pairing status clearly<br>- Unit tests validate advertising payload and temperature range |
| F1.2 | Mobile HMI             | As a user, I want HMIApp to submit desired temperature via BLE | - Input field accepts valid numeric values<br>- BLEClient transmits reliably and confirms delivery<br>- Backend receives and acknowledges BLE packet<br>- UI shows confirmation after submission<br>- Unit tests validate packet structure and UI state changes |
| F1.3 | Backend Controller (C#)| As a developer, I want BackendControllerCS to pair devices and route BLE input | - BLEManagerCS discovers and connects to known MACs<br>- Input is mapped to correct Room instance<br>- Telemetry is parsed and routed correctly<br>- Unit tests validate pairing logic and room updates |
| F1.4 | HVAC Controller Logic  | As a developer, I want HVACController to compute actuator output | - Output reflects temperature delta and is bounded (0–100%)<br>- Output is 0% when desired equals actual<br>- Unit tests cover typical and edge cases |
| F1.5 | Simulation Engine      | As a developer, I want SimulationEngine to evolve room temperature | - Room.actualTemp changes based on HVAC and external temp<br>- ExternalTempSource returns consistent values<br>- tick() updates all rooms without duplication<br>- Unit tests validate evolution logic and tick behavior |
| F1.6 | GUI Frontend (C#)      | As a user, I want GUIApp to display room temp, HVAC state, and MAC status | - RoomDisplayPanel shows correct temperature and actuator values<br>- DeviceStatusPanel reflects pairing state accurately<br>- Telemetry is parsed and mapped to UI components<br>- Unit tests confirm rendering and error handling |

---

## Feature Set 2: Integration & Testing

| ID    | Feature Name            | User Story | Acceptance Criteria |
|-------|-------------------------|------------|---------------------|
| 2.1   | End-to-End BLE Flow     | As a tester, I want to simulate BLE input from the app and verify backend updates | - Room state updates correctly in response to BLE input from SensorApp and HMIApp |
|       |                         | As a tester, I want to validate TelemetryDispatcher sends updates to GUI and HMI | - GUIApp and HMIApp receive and display updated room state within expected latency |
| 2.2   | Simulation Stability     | As a tester, I want to run long-duration simulations to verify stability | - Room temperatures remain bounded and converge toward desired values over time |
|       |                         | As a tester, I want to validate consistent results across repeated runs | - Identical inputs produce consistent temperature evolution across multiple simulation runs |
| 2.3   | GUI Usability            | As a user, I want the GUI to refresh in real time | - RoomDisplayPanel updates within expected intervals |
|       |                         | As a tester, I want to test GUI under rapid updates | - GUIApp remains responsive during high-frequency refresh |
| 2.4   | Mobile UX Validation     | As a user, I want HMIApp to show confirmation after submitting temperature | - UI displays confirmation message or visual feedback after BLE transmission |
|       |                         | As a tester, I want to simulate BLE disconnection and verify graceful handling | - HMIApp detects disconnection and provides user feedback without crashing |
| 2.5   | Backend Resilience       | As a tester, I want to simulate BLE dropout and verify reconnection logic | - BLEManager attempts reconnection and resumes data flow without manual intervention |
|       |                         | As a tester, I want to test TelemetryDispatcher under partial failure | - GUI or HMI clients can fail independently without affecting telemetry delivery to others |
