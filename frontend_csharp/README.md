# DormClimateGUI

DormClimateGUI is the WinForms dashboard frontend for the **DormClimate HVAC Simulation System**.  
It provides a graphical interface to visualize simulation state, interact with the backend, and manage Bluetooth (BLE) pairing with external devices.

---

## 📂 Project Structure

- **Backend (DormClimate Simulation)**  
  Implemented in C# with `SimulationController`, `SimulationService`, `ExternalTemperatureService`, `HvacController`, and `HvacActuator`.  
  Exposes state updates via `OnStateUpdated` event.

- **Frontend (DormClimateGUI)**  
  WinForms application written in C#.  
  Directly communicates with the backend (no web portal required).  
  Provides sections for HMI device pairing, sensor surrogate pairing, main unit status, external temperature override, and logging.

---

## 🖥️ GUI Layout

### 1. HMI Device Section

- Displays **paired HMI device ID**
- Shows **requested temperature** from HMI
- Button: **Pair HMI Device** → opens device selection dialog
- Connection status indicator

### 2. Sensor Surrogate Section

- Displays **paired sensor device ID**
- Shows **surrogate sensor temperature** (used to initiate simulation, not actual room temp)
- Button: **Pair Sensor Device** → opens device selection dialog
- Connection status indicator

### 3. Main Unit Section

- Displays simulation state:
  - Room Temperature
  - External Temperature
  - Desired Temperature
  - HVAC Mode (Heating / Cooling / Idle)
  - Heat % (progress bar)
  - AC % (progress bar)
  - Current Time (simulation clock)
- Manual desired temperature buttons: **-10, -5, +5, +10** (temporary until mobile HMI integration)

### 4. External Temperature Override

- Checkbox: **Enable Override**
- Numeric input: manual external temperature value
- Label: current external temperature (simulation vs override)

### 5. Logging Section

- Text log with timestamped entries
- Button: **Clear Log**
- Auto-scroll enabled for new entries

---

## ⚙️ Features

- Event-driven updates via backend `OnStateUpdated`
- BLE pairing controls for sensor and HMI devices
- Manual overrides for external and desired temperature
- Real-time visualization of HVAC system state
- Logging of connection and simulation events

---
