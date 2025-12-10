using backend_csharp.Utilities;
using DormClimateBackend.Controllers;
using DormClimateBackend.Services;
using DormClimateGUI.UI_utilities;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DormClimateGUI
{
    public partial class MainDashboardForm : Form
    {
        private SimulationController _simController;
        private ExternalTemperatureService _externalTempService;
        private DateTime _currentSimTime;
        private UiLogger _logger;
        private Double _timeScale = 60.0; // 1.0 = real-time, >1.0 = accelerated
        private BLEManager _bleManager;

        // Store DateTime x-values to render true timestamps
        private readonly List<DateTime> times = new();
        private readonly List<double> roomTemps = new();
        private readonly List<double> desiredTemps = new();
        private readonly List<double> externalTemps = new();

        // Window settings
        private const int WindowSeconds = 300; // rolling width of 300 seconds
        private const double YMin = 05;        // adjust to your expected range
        private const double YMax = 40;

        private void UpdatePlot(DateTime start, DateTime end)
        {
            formsPlot1.Plot.Clear();

            var xs = times.Select(t => t.ToOADate()).ToArray();

            var roomLine = formsPlot1.Plot.Add.Scatter(xs, roomTemps.ToArray(),
                color: new ScottPlot.Color(System.Drawing.Color.Red));
            roomLine.MarkerShape = MarkerShape.None;

            var desiredLine = formsPlot1.Plot.Add.Scatter(xs, desiredTemps.ToArray(),
                color: new ScottPlot.Color(System.Drawing.Color.Green));
            desiredLine.MarkerShape = MarkerShape.None;

            var externalLine = formsPlot1.Plot.Add.Scatter(xs, externalTemps.ToArray(),
                color: new ScottPlot.Color(System.Drawing.Color.Blue));
            externalLine.MarkerShape = MarkerShape.None;

            // X-axis: scrolling window
            // Always show the last WindowSeconds worth of data
            var latest = times[^1];
            var windowStart = latest.AddSeconds(-WindowSeconds);
            formsPlot1.Plot.Axes.SetLimitsX(windowStart.ToOADate(), latest.ToOADate());
            formsPlot1.Plot.Axes.DateTimeTicksBottom();

            // Y-axis: smart scaling
            double minY = new[] { roomTemps.Min(), desiredTemps.Min(), externalTemps.Min() }.Min();
            double maxY = new[] { roomTemps.Max(), desiredTemps.Max(), externalTemps.Max() }.Max();
            double padding = (maxY - minY) * 0.1;
            formsPlot1.Plot.Axes.SetLimitsY(minY - padding, maxY + padding);

            formsPlot1.Refresh();
        }

        // Event handler raised from a background thread → marshal to UI thread
        private void SimController_OnStateUpdated(SimulationState state)
        {
            // Append new data to buffers
            times.Add(state.SimTime);
            roomTemps.Add(state.RoomTemperature);
            desiredTemps.Add(_simController.GetDesiredTemperature());
            externalTemps.Add(state.ExternalTemperature);

            // Parity with real/accelerated time:
            // Refresh only once the latest time exceeds the current window end
            var latest = times[^1];
            var start = latest.AddSeconds(-WindowSeconds);

            // Marshal plotting to UI thread
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdatePlot(start, latest)));
            }
            else
            {
                UpdatePlot(start, latest);
            }
        }

        public MainDashboardForm(SimulationController simController, ExternalTemperatureService externalTempService)
        {
            InitializeComponent();

            _simController = simController ?? throw new ArgumentNullException(nameof(simController));
            _simController.OnStateUpdated += SimController_OnStateUpdated;

            formsPlot1.Enabled = false;

            // No title
            formsPlot1.Plot.Title(null);

            // Labels (optional)
            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel("Temperature (°C)");

            // DateTime ticks on bottom axis
            formsPlot1.Plot.Axes.DateTimeTicksBottom();

            // Fix Y axis to a stable range
            formsPlot1.Plot.Axes.SetLimitsY(YMin, YMax);

            _logger = new UiLogger(this, rtbLog);

            // Example usage
            _logger.Log("Dashboard initialized.");

            _simController = simController;
            _externalTempService = externalTempService;

            // Ensure Override External Temperature Checkbox starts unchecked
            chkOverrideExternal.Checked = false;

            // Apply initial enabling/disabling for the External Temp override controls
            ApplyOverrideState();

            // Initial UI state
            chkRealtime.Checked = true;
            _currentSimTime = DateTime.Now;

            lblTime.Text = _currentSimTime.ToString("HH:mm:ss");
            UpdateExternalTemp(_currentSimTime);

            cmdStart.Enabled = false;   // dimmed
            cmdStop.Enabled = true;     // available

            //Setting up the initial displays. 
            lblRoom1Temp.Text = "-- °C";
            lblRoom1DesiredTemp.Text = "-- °C";
            lblRoom1ExternalTemp.Text = "-- °C";
            lblRoom1HVACstatus.Text = "--";
            lblRoom1Heater.Text = "-- %";
            lblRoom1AC.Text = "-- %";

            //Set the chkOverrideHMI checkbox state and button states
            chkOverrideHMI.Checked = false;
            SetHMIButtons();

            // Pass logger into BLEManager
            _bleManager = new BLEManager(_logger);

            // Subscribe to backend events
            _bleManager.OnDeviceFound += BleManager_OnDeviceFound;
            _bleManager.OnLog += BleManager_OnLog;
            _bleManager.OnDeviceInfoReady += BleManager_OnDeviceInfoReady;

            //Start the HVAC Engine simulation
            StartSimulation();          // begin in realtime mode
        }

        // Called whenever a new BLE device is discovered
        private void BleManager_OnDeviceFound(DeviceEntry entry)
        {
            if (cmdSensorDevices.InvokeRequired)
            {
                cmdSensorDevices.Invoke(new Action(() =>
                {
                    cmdSensorDevices.Items.Add(entry);
                }));
            }
            else
            {
                cmdSensorDevices.Items.Add(entry);
            }
        }

        // Called whenever the BLEManager wants to log a message
        private void BleManager_OnLog(string message)
        {
            // Use your UiLogger to write into the RichTextBox
            _logger.Log(message);
        }

        // Called when BLEManager has finished gathering info about a connected device
        private void BleManager_OnDeviceInfoReady(string deviceId, string gattSummary)
        {
            if (txtSensorDeviceId.InvokeRequired || txtSensor.InvokeRequired)
            {
                txtSensorDeviceId.Invoke(new Action(() =>
                {
                    txtSensorDeviceId.Text = deviceId;
                    txtSensor.Text = gattSummary;
                }));
            }
            else
            {
                txtSensorDeviceId.Text = deviceId;
                txtSensor.Text = gattSummary;
            }
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
        // Start scanning when the "Search Sensor" button is clicked
        private void cmbSearchSensor_Click(object sender, EventArgs e)
        {
            // Clear previous results
            cmdSensorDevices.Items.Clear();
            txtSensorDeviceId.Clear();
            txtSensor.Clear();

            // Start BLE scan
            _bleManager.StartScan();
            _logger.Log("Started scanning for BLE devices...");
        }

        // Connect to the selected device when the "Connect Sensor" button is clicked
        private async void cmdConnectSensor_Click(object sender, EventArgs e)
        {
            _bleManager.StopScan();
            _logger.Log("Stopped scanning for BLE devices.");

            if (cmdSensorDevices.SelectedItem is DeviceEntry entry)
            {
                // Attempt connection
                string summary = await _bleManager.ConnectAsync(entry.Id);

                // Update UI
                txtSensorDeviceId.Text = entry.Id;
                txtSensor.Text = summary;

                _logger.Log($"Connected to {entry.Display}");
            }
            else
            {
                MessageBox.Show("Please select a device from the list before connecting.");
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
            // lblRoom1HVACstatus.Text = state.HvacMode.ToString();
            lblRoom1HVACstatus.Text = state.HvacMode.ToDisplayString();

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
            lblSimulationStatus.ForeColor = System.Drawing.Color.Red;
            lblSimulationStatus.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
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
            lblSimulationStatus.ForeColor = System.Drawing.Color.Blue;
            lblSimulationStatus.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            _logger.Log("Simulation Started - HVAC System Online.");
        }
        private void cmdSetExtTemp_Click(object sender, EventArgs e)
        {
            double value;

            if (!double.TryParse(txtExtTemp.Text, out value))
            {
                // Invalid input → default to 20
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
    }
}
