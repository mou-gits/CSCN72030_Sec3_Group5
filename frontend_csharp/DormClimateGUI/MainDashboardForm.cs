using backend_csharp.Utilities;
using DormClimateBackend.Controllers;
using DormClimateBackend.Services;
using DormClimateGUI.UI_utilities;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace DormClimateGUI
{
    public partial class MainDashboardForm : Form
    {
        private BLEManager _bleManager;
        private SimulationController _simController;
        private ExternalTemperatureService _externalTempService;
        private DateTime _currentSimTime;
        private UiLogger _logger;
        private Double _timeScale = 60.0; // 1.0 = real-time, >1.0 = accelerated

        public MainDashboardForm(SimulationController simController, ExternalTemperatureService externalTempService)
        {
            InitializeComponent();

            // Initialize logger
            _logger = new UiLogger(this, rtbLog);
            _logger.Log("Dashboard initialized.");

            // Assign services
            _simController = simController;
            _externalTempService = externalTempService;

            // Initial UI state
            chkOverrideExternal.Checked = false;
            ApplyOverrideState();

            chkRealtime.Checked = true;
            _currentSimTime = DateTime.Now;
            lblTime.Text = _currentSimTime.ToString("HH:mm:ss");
            UpdateExternalTemp(_currentSimTime);

            cmdStart.Enabled = false;   // dimmed
            cmdStop.Enabled = true;     // available

            // Room 1 initial displays
            lblRoom1Temp.Text = "-- °C";
            lblRoom1DesiredTemp.Text = "-- °C";
            lblRoom1ExternalTemp.Text = "-- °C";
            lblRoom1HVACstatus.Text = "--";
            lblRoom1Heater.Text = "-- %";
            lblRoom1AC.Text = "-- %";

            // HMI override initial state
            chkOverrideHMI.Checked = false;
            SetHMIButtons();

            // BLE communication manager initialization
            _bleManager = new BLEManager(_logger);
            cmdSensorDevices.DropDownStyle = ComboBoxStyle.DropDownList;

            // Hook events to update GUI
            _bleManager.OnDeviceFound += entry =>
            {
                bool exists = cmdSensorDevices.Items.Cast<DeviceEntry>()
                    .Any(x => x.Id == entry.Id);

                if (!exists)
                {
                    cmdSensorDevices.Items.Add(entry); // stores the whole object
                }
            };

            _bleManager.OnLog += msg => _logger.Log(msg);

            _bleManager.OnDeviceInfoReady += (deviceIdHex, summary) =>
            {
                txtSensorDeviceId.Text = deviceIdHex;   // keep showing device ID
                txtSensor.Text = summary;               // show only the Notify characteristic
            };

            _bleManager.OnDeviceInfoReady += (deviceIdHex, gattSummary) =>
            {
                // Ensure UI updates on the UI thread
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() =>
                    {
                        txtSensorDeviceId.Text = deviceIdHex;
                        txtSensor.Text = gattSummary;
                    }));
                }
                else
                {
                    txtSensorDeviceId.Text = deviceIdHex;
                    txtSensor.Text = gattSummary;
                }
            };

            // Start simulation in realtime mode
            StartSimulation();
        }

        private void chkOverrideExternal_CheckedChanged(object sender, EventArgs e)
        {
            ApplyOverrideState();
        }
        private void ApplyOverrideState()
        {
            if (chkOverrideExternal.Checked)
            {
                txtExtTemp.Enabled = true;
                cmdSetExtTemp.Enabled = true;
                txtExtTemp.Text = string.Empty; // clear content
            }
            else
            {
                txtExtTemp.Enabled = false;
                cmdSetExtTemp.Enabled = false;

                // Switch service back to database mode
                _externalTempService.UseDatabase();
            }
        }
        private void StartSimulation()
        {
            if (chkRealtime.Checked)
                _simController.RunRealTime();
            else
                _simController.RunAccelerated(_timeScale);

            _simController.OnStateUpdated += SimulationController_OnStateUpdated;
        }
        private void StopSimulation()
        {
            _simController.OnStateUpdated -= SimulationController_OnStateUpdated;
            _simController.Stop();
        }
        private void SimulationController_OnStateUpdated(SimulationState state)
        {
            if (InvokeRequired)
                BeginInvoke(new Action(() => UpdateSystemGroup(state)));
            else
                UpdateSystemGroup(state);
        }
        private void UpdateSystemGroup(SimulationState state)
        {
            _currentSimTime = state.SimTime;
            lblTime.Text = _currentSimTime.ToLocalTime().ToString("HH:mm:ss");

            //External Temperature
            UpdateExternalTemp(_currentSimTime);

            // Room temperature
            lblRoom1Temp.Text = $"{state.RoomTemperature:F1} °C";

            // Desired temperature
            lblRoom1DesiredTemp.Text = $"{_simController.GetDesiredTemperature():F1} °C";

            // External temperature (from state, not service)
            lblRoom1ExternalTemp.Text = $"{state.ExternalTemperature:F1} °C";

            // HVAC status (action description)
            lblRoom1HVACstatus.Text = state.HvacMode.ToString();

            // Heater and AC percentages
            lblRoom1Heater.Text = $"{state.ActuatorOutput.HeaterPercent * 100:F0} %";
            lblRoom1AC.Text = $"{state.ActuatorOutput.AcPercent * 100:F0} %";
        }
        private void UpdateExternalTemp(DateTime simTime)
        {
            double? extTemp = _externalTempService.GetInterpolatedTemperature(simTime);
            lblDBExtTemp.Text = extTemp.HasValue ? $"{extTemp.Value:F1} °C" : "-- °C";
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            _logger.Clear();
        }
        private void chkRealtime_CheckedChanged(object sender, EventArgs e)
        {
            // Always stop the current run before switching
            _simController.Stop();

            if (chkRealtime.Checked)
            {
                // Start realtime mode
                _simController.RunRealTime();
                _logger.Log("Switched to Real-Time Mode.");
            }
            else
            {
                // Start accelerated mode (example: 60× faster)
                _simController.RunAccelerated(_timeScale);
                _logger.Log($"Switched to Accelerated Mode (×{_timeScale}).");
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopSimulation();

            cmdStart.Enabled = true;
            cmdStop.Enabled = false;

            lblSimulationStatus.Text = "---- OFFLINE ----";
            lblSimulationStatus.ForeColor = Color.Red;
            lblSimulationStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            _logger.Log("Simulation Stopped - HVAC System Offline.");
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Ensure clean slate
            StopSimulation();

            StartSimulation();

            cmdStart.Enabled = false;
            cmdStop.Enabled = true;

            lblSimulationStatus.Text = "----- ONLINE -----";
            lblSimulationStatus.ForeColor = Color.Blue;
            lblSimulationStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            _logger.Log("Simulation Started - HVAC System Online.");
        }
        private void cmdSetExtTemp_Click(object sender, EventArgs e)
        {
            double value;

            if (!double.TryParse(txtExtTemp.Text, out value))
            {
                // Invalid input - default to a safe value
                value = 20;
                txtExtTemp.Text = "20";
            }

            // Apply override with the chosen value
            _externalTempService.OverrideWithConstant(value);
            //log message with value of external temp override
            _logger.Log($"Override applied: External Temperature = {value}.");
        }
        private void chkOverrideHMI_CheckedChanged(object sender, EventArgs e)
        {
            SetHMIButtons();
        }
        private void SetHMIButtons()
        {
            btnRoomOnePlusTen.Enabled = chkOverrideHMI.Checked;
            btnRoomOnePlusFive.Enabled = chkOverrideHMI.Checked;
            btnRoomOneMinusFive.Enabled = chkOverrideHMI.Checked;
            btnRoomOneMinusTen.Enabled = chkOverrideHMI.Checked;
        }
        private void btnRoomOnePlusTen_Click(object sender, EventArgs e)
        {
            double _RoomTemp = _simController.GetRoomTemperature();
            _simController.UpdateDesiredTemperature(_RoomTemp + 10.0);
        }
        private void btnRoomOnePlusFive_Click(object sender, EventArgs e)
        {
            double _RoomTemp = _simController.GetRoomTemperature();
            _simController.UpdateDesiredTemperature(_RoomTemp + 5.0);
        }
        private void btnRoomOneMinusFive_Click(object sender, EventArgs e)
        {
            double _RoomTemp = _simController.GetRoomTemperature();
            _simController.UpdateDesiredTemperature(_RoomTemp - 5.0);
        }
        private void btnRoomOneMinusTen_Click(object sender, EventArgs e)
        {
            double _RoomTemp = _simController.GetRoomTemperature();
            _simController.UpdateDesiredTemperature(_RoomTemp - 10.0);
        }
        private void MainDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _simController.Stop();
        }

        private void cmbSearchSensor_Click(object sender, EventArgs e)
        {
            cmdSensorDevices.Items.Clear();
            _bleManager.StartScan();
        }

        private async void cmdConnectSensor_Click(object sender, EventArgs e)
        {
            _bleManager.StopScan(); // optional safety

            var selected = cmdSensorDevices.SelectedItem as DeviceEntry;
            if (selected == null)
            {
                MessageBox.Show("Please select a device from the list.");
                return;
            }
            // Show device ID immediately
            txtSensorDeviceId.Text = selected.Id;
            _logger.Log($"Attempting connection to {selected.Display}");

            // Ask BLEManager to connect and return summary
            string summary = await _bleManager.ConnectAsync(selected.Id);

            // Then read the Notify characteristic value
            string sensorValue = await _bleManager.ReadNotifyCharacteristicAsync();
            txtSensor.Text = sensorValue;

        }



        private void txtSensorDeviceId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
