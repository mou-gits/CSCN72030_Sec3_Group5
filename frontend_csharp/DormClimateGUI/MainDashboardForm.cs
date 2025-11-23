using DormClimateBackend.Controllers;
using DormClimateBackend.Services;
using DormClimateGUI.UI_utilities;

namespace DormClimateGUI
{
    public partial class MainDashboardForm : Form
    {
        private SimulationController _simController;
        private ExternalTemperatureService _externalTempService;
        private DateTime _currentSimTime;
        private UiLogger _logger;

        public MainDashboardForm(SimulationController simController, ExternalTemperatureService externalTempService)
        {
            InitializeComponent();
            _logger = new UiLogger(this, rtbLog);

            // Example usage
            _logger.Log("Dashboard initialized.");

            _simController = simController;
            _externalTempService = externalTempService;

            this.FormClosing += MainDashboardForm_FormClosing;

            // Initial UI state
            chkRealtime.Checked = true;
            _currentSimTime = DateTime.Now;

            lblTime.Text = _currentSimTime.ToString("HH:mm:ss");
            UpdateExternalTemp(_currentSimTime);

            cmdStart.Enabled = false;   // dimmed
            cmdStop.Enabled = true;     // available

            StartSimulation();          // begin in realtime mode
        }
        private void MainDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _simController.Stop();
        }
        private void StartSimulation()
        {
            if (chkRealtime.Checked)
                _simController.RunRealTime();
            else
                _simController.RunAccelerated();

            _simController.OnStateUpdated += SimulationController_OnStateUpdated;
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
            UpdateExternalTemp(_currentSimTime);
        }
        private void UpdateExternalTemp(DateTime simTime)
        {
            double? extTemp = _externalTempService.GetInterpolatedTemperature(simTime);
            lblDBExtTemp.Text = extTemp.HasValue ? $"{extTemp.Value:F1} °C" : "-- °C";
        }
        private void StopSimulation()
        {
            _simController.OnStateUpdated -= SimulationController_OnStateUpdated;
            // TODO: add a Stop() method in SimulationController to halt threads cleanly
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            _logger.Clear();
        }
        private void chkRealtime_CheckedChanged(object sender, EventArgs e)
        {
            // Restart sim at current displayed time, switch mode
            StopSimulation();
            StartSimulation();
        }
        private void cmdStop_Click(object sender, EventArgs e)
        {
            StopSimulation();
            cmdStart.Enabled = true;
            cmdStop.Enabled = false;
        }
        private void cmdStart_Click(object sender, EventArgs e)
        {
            _currentSimTime = DateTime.UtcNow;
            lblTime.Text = _currentSimTime.ToLocalTime().ToString("HH:mm:ss");
            UpdateExternalTemp(_currentSimTime);

            StartSimulation();
            cmdStart.Enabled = false;
            cmdStop.Enabled = true;
        }
        private void MainDashboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
