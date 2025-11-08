# Integration Plan — Dorm Climate Control

This document outlines the integration strategy for Sprint 1, ensuring modular components are connected, tested, and demo-ready.

---

## Integration Goals

- Connect **SensorApp** and **HMIApp** to the **BackendControllerCS** via BLE
- Route BLE input to correct `Room` instances in backend
- Dispatch telemetry updates to **GUIApp** and **HMIApp**
- Validate end-to-end flow from mobile input to GUI display

---

## Integration Sequence

1. **BLE Pairing**
   - Backend scans and connects to SensorApp and HMIApp
   - MAC addresses are registered and mapped to rooms

2. **Data Flow**
   - SensorApp advertises battery temperature
   - HMIApp sends desired temperature
   - Backend parses and updates Room state

3. **Simulation Tick**
   - SimulationEngine evolves actual temperature
   - HVACController computes actuator output

4. **Telemetry Dispatch**
   - Updated room state sent to GUI and HMI
   - GUI reflects temperature, actuator, and MAC status

---

## Integration Tests

- Simulate BLE input and verify backend updates
- Validate GUI refresh and responsiveness
- Test BLE disconnection and reconnection logic
- Run long-duration simulations for stability

---

## Responsibilities

| Team Member | Integration Role |
|-------------|------------------|
| Moutushi    | Backend ↔ GUI, BLE pairing, simulation logic |
| [Others - Kenneth, Arman, Tanveer   | GUI testing, mobile UX validation, telemetry verification |

---
