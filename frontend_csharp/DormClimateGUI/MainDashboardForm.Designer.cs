
namespace DormClimateGUI
{
    partial class MainDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        // Dispose pattern
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboardForm));
            cmbHMIdevices = new ComboBox();
            txtHMIExternalTemperature = new TextBox();
            txtHMIDesiredTemperature = new TextBox();
            txtHMIDeviceID = new TextBox();
            txtHMIRoomTemperature = new TextBox();
            cmdConnectHMI = new Button();
            cmdSearchHMI = new Button();
            lblHMIExternalTemperature = new Label();
            lblHMIDesiredTemperature = new Label();
            lblHMIRoomTemperature = new Label();
            lblHMIDeviceID = new Label();
            cmdConnectSensor = new Button();
            cmdSensorDevices = new ComboBox();
            cmbSearchSensor = new Button();
            txtSensorDeviceId = new TextBox();
            txtSensor = new TextBox();
            lblSensorDeviceId = new Label();
            lblSensor = new Label();
            lblExtTemp = new Label();
            txtExtTemp = new TextBox();
            cmdStop = new Button();
            cmdStart = new Button();
            cmdSetExtTemp = new Button();
            chkOverrideExternal = new CheckBox();
            chkRealtime = new CheckBox();
            cmdClear = new Button();
            tabRoom1 = new TabControl();
            tabPage1 = new TabPage();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            textBox3 = new TextBox();
            lblRoom1AC = new Label();
            lblRoom1Heater = new Label();
            lblRoom1HVACstatus = new Label();
            lblRoom1ExternalTemp = new Label();
            lblRoom1DesiredTemp = new Label();
            lblRoom1Temp = new Label();
            chkOverrideHMI = new CheckBox();
            btnRoomOneMinusTen = new Button();
            btnRoomOneMinusFive = new Button();
            btnRoomOnePlusFive = new Button();
            btnRoomOnePlusTen = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            label11 = new Label();
            label10 = new Label();
            label7 = new Label();
            lblSimulationStatus = new Label();
            lblDBExtTemp = new Label();
            label9 = new Label();
            lblTime = new Label();
            label8 = new Label();
            Settings = new TabControl();
            loggerTab = new TabPage();
            rtbLog = new RichTextBox();
            sensorTab = new TabPage();
            richTextBox2 = new RichTextBox();
            hmiTab = new TabPage();
            textBox1 = new TextBox();
            btnClearHMIlog = new Button();
            richTextBox1 = new RichTextBox();
            label12 = new Label();
            textBox2 = new TextBox();
            ControlsTab = new TabControl();
            tabPage3 = new TabPage();
            textBox4 = new TextBox();
            tabPage4 = new TabPage();
            tabRoom1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            Settings.SuspendLayout();
            loggerTab.SuspendLayout();
            sensorTab.SuspendLayout();
            hmiTab.SuspendLayout();
            ControlsTab.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // cmbHMIdevices
            // 
            cmbHMIdevices.FormattingEnabled = true;
            cmbHMIdevices.Location = new Point(6, 47);
            cmbHMIdevices.Name = "cmbHMIdevices";
            cmbHMIdevices.Size = new Size(393, 23);
            cmbHMIdevices.TabIndex = 6;
            // 
            // txtHMIExternalTemperature
            // 
            txtHMIExternalTemperature.Location = new Point(96, 187);
            txtHMIExternalTemperature.Name = "txtHMIExternalTemperature";
            txtHMIExternalTemperature.ReadOnly = true;
            txtHMIExternalTemperature.Size = new Size(100, 23);
            txtHMIExternalTemperature.TabIndex = 5;
            // 
            // txtHMIDesiredTemperature
            // 
            txtHMIDesiredTemperature.Location = new Point(96, 218);
            txtHMIDesiredTemperature.Name = "txtHMIDesiredTemperature";
            txtHMIDesiredTemperature.ReadOnly = true;
            txtHMIDesiredTemperature.Size = new Size(100, 23);
            txtHMIDesiredTemperature.TabIndex = 5;
            // 
            // txtHMIDeviceID
            // 
            txtHMIDeviceID.Location = new Point(96, 125);
            txtHMIDeviceID.Name = "txtHMIDeviceID";
            txtHMIDeviceID.ReadOnly = true;
            txtHMIDeviceID.Size = new Size(303, 23);
            txtHMIDeviceID.TabIndex = 5;
            // 
            // txtHMIRoomTemperature
            // 
            txtHMIRoomTemperature.Location = new Point(96, 156);
            txtHMIRoomTemperature.Name = "txtHMIRoomTemperature";
            txtHMIRoomTemperature.ReadOnly = true;
            txtHMIRoomTemperature.Size = new Size(100, 23);
            txtHMIRoomTemperature.TabIndex = 5;
            // 
            // cmdConnectHMI
            // 
            cmdConnectHMI.Location = new Point(6, 81);
            cmdConnectHMI.Name = "cmdConnectHMI";
            cmdConnectHMI.Size = new Size(393, 33);
            cmdConnectHMI.TabIndex = 4;
            cmdConnectHMI.Text = "Connect Device";
            cmdConnectHMI.UseVisualStyleBackColor = true;
            // 
            // cmdSearchHMI
            // 
            cmdSearchHMI.Location = new Point(6, 15);
            cmdSearchHMI.Name = "cmdSearchHMI";
            cmdSearchHMI.Size = new Size(393, 23);
            cmdSearchHMI.TabIndex = 4;
            cmdSearchHMI.Text = "Search BlueTooth Devices";
            cmdSearchHMI.UseVisualStyleBackColor = true;
            // 
            // lblHMIExternalTemperature
            // 
            lblHMIExternalTemperature.AutoSize = true;
            lblHMIExternalTemperature.Location = new Point(8, 191);
            lblHMIExternalTemperature.Name = "lblHMIExternalTemperature";
            lblHMIExternalTemperature.Size = new Size(81, 15);
            lblHMIExternalTemperature.TabIndex = 3;
            lblHMIExternalTemperature.Text = "External Temp";
            // 
            // lblHMIDesiredTemperature
            // 
            lblHMIDesiredTemperature.AutoSize = true;
            lblHMIDesiredTemperature.Location = new Point(8, 222);
            lblHMIDesiredTemperature.Name = "lblHMIDesiredTemperature";
            lblHMIDesiredTemperature.Size = new Size(79, 15);
            lblHMIDesiredTemperature.TabIndex = 2;
            lblHMIDesiredTemperature.Text = "Desired Temp";
            // 
            // lblHMIRoomTemperature
            // 
            lblHMIRoomTemperature.AutoSize = true;
            lblHMIRoomTemperature.Location = new Point(8, 160);
            lblHMIRoomTemperature.Name = "lblHMIRoomTemperature";
            lblHMIRoomTemperature.Size = new Size(72, 15);
            lblHMIRoomTemperature.TabIndex = 1;
            lblHMIRoomTemperature.Text = "Room Temp";
            // 
            // lblHMIDeviceID
            // 
            lblHMIDeviceID.AutoSize = true;
            lblHMIDeviceID.Location = new Point(8, 129);
            lblHMIDeviceID.Name = "lblHMIDeviceID";
            lblHMIDeviceID.Size = new Size(82, 15);
            lblHMIDeviceID.TabIndex = 0;
            lblHMIDeviceID.Text = "HMI Device ID";
            // 
            // cmdConnectSensor
            // 
            cmdConnectSensor.Location = new Point(24, 83);
            cmdConnectSensor.Name = "cmdConnectSensor";
            cmdConnectSensor.Size = new Size(356, 46);
            cmdConnectSensor.TabIndex = 7;
            cmdConnectSensor.Text = "Connect Device";
            cmdConnectSensor.UseVisualStyleBackColor = true;
            cmdConnectSensor.Click += cmdConnectSensor_Click;
            // 
            // cmdSensorDevices
            // 
            cmdSensorDevices.FormattingEnabled = true;
            cmdSensorDevices.Location = new Point(24, 48);
            cmdSensorDevices.Name = "cmdSensorDevices";
            cmdSensorDevices.Size = new Size(356, 23);
            cmdSensorDevices.TabIndex = 7;
            // 
            // cmbSearchSensor
            // 
            cmbSearchSensor.Location = new Point(24, 12);
            cmbSearchSensor.Name = "cmbSearchSensor";
            cmbSearchSensor.Size = new Size(356, 23);
            cmbSearchSensor.TabIndex = 4;
            cmbSearchSensor.Text = "Search BlueTooth Devices";
            cmbSearchSensor.UseVisualStyleBackColor = true;
            cmbSearchSensor.Click += cmbSearchSensor_Click;
            // 
            // txtSensorDeviceId
            // 
            txtSensorDeviceId.Location = new Point(24, 159);
            txtSensorDeviceId.Name = "txtSensorDeviceId";
            txtSensorDeviceId.ReadOnly = true;
            txtSensorDeviceId.Size = new Size(238, 23);
            txtSensorDeviceId.TabIndex = 5;
            // 
            // txtSensor
            // 
            txtSensor.Location = new Point(268, 159);
            txtSensor.Name = "txtSensor";
            txtSensor.ReadOnly = true;
            txtSensor.Size = new Size(112, 23);
            txtSensor.TabIndex = 5;
            // 
            // lblSensorDeviceId
            // 
            lblSensorDeviceId.AutoSize = true;
            lblSensorDeviceId.Location = new Point(24, 140);
            lblSensorDeviceId.Name = "lblSensorDeviceId";
            lblSensorDeviceId.Size = new Size(94, 15);
            lblSensorDeviceId.TabIndex = 0;
            lblSensorDeviceId.Text = "Sensor Device ID";
            // 
            // lblSensor
            // 
            lblSensor.AutoSize = true;
            lblSensor.Location = new Point(268, 140);
            lblSensor.Name = "lblSensor";
            lblSensor.Size = new Size(112, 15);
            lblSensor.TabIndex = 1;
            lblSensor.Text = "Sensor Temperature";
            // 
            // lblExtTemp
            // 
            lblExtTemp.AutoSize = true;
            lblExtTemp.Location = new Point(9, 44);
            lblExtTemp.Name = "lblExtTemp";
            lblExtTemp.Size = new Size(55, 15);
            lblExtTemp.TabIndex = 3;
            lblExtTemp.Text = "Ext Temp";
            // 
            // txtExtTemp
            // 
            txtExtTemp.Location = new Point(78, 40);
            txtExtTemp.Name = "txtExtTemp";
            txtExtTemp.Size = new Size(49, 23);
            txtExtTemp.TabIndex = 2;
            // 
            // cmdStop
            // 
            cmdStop.Location = new Point(564, 12);
            cmdStop.Name = "cmdStop";
            cmdStop.Size = new Size(67, 51);
            cmdStop.TabIndex = 1;
            cmdStop.Text = "Stop System";
            cmdStop.UseVisualStyleBackColor = true;
            cmdStop.Click += btnStop_Click;
            // 
            // cmdStart
            // 
            cmdStart.Location = new Point(473, 12);
            cmdStart.Name = "cmdStart";
            cmdStart.Size = new Size(68, 51);
            cmdStart.TabIndex = 1;
            cmdStart.Text = "Start System";
            cmdStart.UseVisualStyleBackColor = true;
            cmdStart.Click += btnStart_Click;
            // 
            // cmdSetExtTemp
            // 
            cmdSetExtTemp.Location = new Point(137, 6);
            cmdSetExtTemp.Name = "cmdSetExtTemp";
            cmdSetExtTemp.Size = new Size(175, 64);
            cmdSetExtTemp.TabIndex = 1;
            cmdSetExtTemp.Text = "Set Temperature";
            cmdSetExtTemp.UseVisualStyleBackColor = true;
            cmdSetExtTemp.Click += cmdSetExtTemp_Click;
            // 
            // chkOverrideExternal
            // 
            chkOverrideExternal.AutoSize = true;
            chkOverrideExternal.Location = new Point(9, 11);
            chkOverrideExternal.Name = "chkOverrideExternal";
            chkOverrideExternal.Size = new Size(122, 19);
            chkOverrideExternal.TabIndex = 0;
            chkOverrideExternal.Text = "Override Ext Temp";
            chkOverrideExternal.UseVisualStyleBackColor = true;
            chkOverrideExternal.CheckedChanged += chkOverrideExternal_CheckedChanged;
            // 
            // chkRealtime
            // 
            chkRealtime.AutoSize = true;
            chkRealtime.Location = new Point(306, 41);
            chkRealtime.Name = "chkRealtime";
            chkRealtime.Size = new Size(112, 19);
            chkRealtime.TabIndex = 7;
            chkRealtime.Text = "Real Time Mode";
            chkRealtime.UseVisualStyleBackColor = true;
            chkRealtime.CheckedChanged += chkRealtime_CheckedChanged;
            // 
            // cmdClear
            // 
            cmdClear.Location = new Point(334, 338);
            cmdClear.Name = "cmdClear";
            cmdClear.Size = new Size(65, 25);
            cmdClear.TabIndex = 0;
            cmdClear.Text = "Clear Log";
            cmdClear.UseVisualStyleBackColor = true;
            cmdClear.Click += cmdClear_Click;
            // 
            // tabRoom1
            // 
            tabRoom1.Controls.Add(tabPage1);
            tabRoom1.Controls.Add(tabPage2);
            tabRoom1.Location = new Point(12, 119);
            tabRoom1.Name = "tabRoom1";
            tabRoom1.SelectedIndex = 0;
            tabRoom1.Size = new Size(649, 397);
            tabRoom1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.ButtonFace;
            tabPage1.Controls.Add(formsPlot1);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(lblRoom1AC);
            tabPage1.Controls.Add(lblRoom1Heater);
            tabPage1.Controls.Add(lblRoom1HVACstatus);
            tabPage1.Controls.Add(lblRoom1ExternalTemp);
            tabPage1.Controls.Add(lblRoom1DesiredTemp);
            tabPage1.Controls.Add(lblRoom1Temp);
            tabPage1.Controls.Add(chkOverrideHMI);
            tabPage1.Controls.Add(btnRoomOneMinusTen);
            tabPage1.Controls.Add(btnRoomOneMinusFive);
            tabPage1.Controls.Add(btnRoomOnePlusFive);
            tabPage1.Controls.Add(btnRoomOnePlusTen);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(641, 369);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Room 1";
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(9, 184);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(625, 176);
            formsPlot1.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ButtonFace;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Enabled = false;
            textBox3.Location = new Point(268, 12);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(260, 166);
            textBox3.TabIndex = 11;
            textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // lblRoom1AC
            // 
            lblRoom1AC.AutoSize = true;
            lblRoom1AC.Location = new Point(166, 153);
            lblRoom1AC.Name = "lblRoom1AC";
            lblRoom1AC.Size = new Size(30, 15);
            lblRoom1AC.TabIndex = 9;
            lblRoom1AC.Text = "-- %";
            // 
            // lblRoom1Heater
            // 
            lblRoom1Heater.AutoSize = true;
            lblRoom1Heater.Location = new Point(166, 128);
            lblRoom1Heater.Name = "lblRoom1Heater";
            lblRoom1Heater.Size = new Size(30, 15);
            lblRoom1Heater.TabIndex = 9;
            lblRoom1Heater.Text = "-- %";
            // 
            // lblRoom1HVACstatus
            // 
            lblRoom1HVACstatus.AutoSize = true;
            lblRoom1HVACstatus.Location = new Point(166, 99);
            lblRoom1HVACstatus.Name = "lblRoom1HVACstatus";
            lblRoom1HVACstatus.Size = new Size(17, 15);
            lblRoom1HVACstatus.TabIndex = 9;
            lblRoom1HVACstatus.Text = "--";
            // 
            // lblRoom1ExternalTemp
            // 
            lblRoom1ExternalTemp.AutoSize = true;
            lblRoom1ExternalTemp.Location = new Point(166, 70);
            lblRoom1ExternalTemp.Name = "lblRoom1ExternalTemp";
            lblRoom1ExternalTemp.Size = new Size(36, 15);
            lblRoom1ExternalTemp.TabIndex = 9;
            lblRoom1ExternalTemp.Text = "--  °C";
            // 
            // lblRoom1DesiredTemp
            // 
            lblRoom1DesiredTemp.AutoSize = true;
            lblRoom1DesiredTemp.Location = new Point(166, 41);
            lblRoom1DesiredTemp.Name = "lblRoom1DesiredTemp";
            lblRoom1DesiredTemp.Size = new Size(36, 15);
            lblRoom1DesiredTemp.TabIndex = 9;
            lblRoom1DesiredTemp.Text = "--  °C";
            // 
            // lblRoom1Temp
            // 
            lblRoom1Temp.AutoSize = true;
            lblRoom1Temp.Location = new Point(166, 13);
            lblRoom1Temp.Name = "lblRoom1Temp";
            lblRoom1Temp.Size = new Size(36, 15);
            lblRoom1Temp.TabIndex = 9;
            lblRoom1Temp.Text = "--  °C";
            // 
            // chkOverrideHMI
            // 
            chkOverrideHMI.AutoSize = true;
            chkOverrideHMI.Location = new Point(534, 11);
            chkOverrideHMI.Name = "chkOverrideHMI";
            chkOverrideHMI.Size = new Size(97, 19);
            chkOverrideHMI.TabIndex = 8;
            chkOverrideHMI.TabStop = false;
            chkOverrideHMI.Text = "Override HMI";
            chkOverrideHMI.UseVisualStyleBackColor = true;
            chkOverrideHMI.CheckedChanged += chkOverrideHMI_CheckedChanged;
            // 
            // btnRoomOneMinusTen
            // 
            btnRoomOneMinusTen.Location = new Point(534, 142);
            btnRoomOneMinusTen.Name = "btnRoomOneMinusTen";
            btnRoomOneMinusTen.Size = new Size(97, 23);
            btnRoomOneMinusTen.TabIndex = 7;
            btnRoomOneMinusTen.Text = "- 10";
            btnRoomOneMinusTen.UseVisualStyleBackColor = true;
            btnRoomOneMinusTen.Click += btnRoomOneMinusTen_Click;
            // 
            // btnRoomOneMinusFive
            // 
            btnRoomOneMinusFive.Location = new Point(534, 107);
            btnRoomOneMinusFive.Name = "btnRoomOneMinusFive";
            btnRoomOneMinusFive.Size = new Size(97, 23);
            btnRoomOneMinusFive.TabIndex = 7;
            btnRoomOneMinusFive.Text = "- 5";
            btnRoomOneMinusFive.UseVisualStyleBackColor = true;
            btnRoomOneMinusFive.Click += btnRoomOneMinusFive_Click;
            // 
            // btnRoomOnePlusFive
            // 
            btnRoomOnePlusFive.Location = new Point(534, 72);
            btnRoomOnePlusFive.Name = "btnRoomOnePlusFive";
            btnRoomOnePlusFive.Size = new Size(97, 23);
            btnRoomOnePlusFive.TabIndex = 7;
            btnRoomOnePlusFive.Text = "+ 5";
            btnRoomOnePlusFive.UseVisualStyleBackColor = true;
            btnRoomOnePlusFive.Click += btnRoomOnePlusFive_Click;
            // 
            // btnRoomOnePlusTen
            // 
            btnRoomOnePlusTen.Location = new Point(534, 37);
            btnRoomOnePlusTen.Name = "btnRoomOnePlusTen";
            btnRoomOnePlusTen.Size = new Size(97, 23);
            btnRoomOnePlusTen.TabIndex = 7;
            btnRoomOnePlusTen.Text = "+ 10";
            btnRoomOnePlusTen.UseVisualStyleBackColor = true;
            btnRoomOnePlusTen.Click += btnRoomOnePlusTen_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(115, 153);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 6;
            label6.Text = "AC %";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(96, 128);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 1;
            label5.Text = "Heater %";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 99);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 2;
            label4.Text = "HVAC Status";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 70);
            label3.Name = "label3";
            label3.Size = new Size(142, 15);
            label3.TabIndex = 3;
            label3.Text = "External Temperature (°C)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 41);
            label2.Name = "label2";
            label2.Size = new Size(140, 15);
            label2.TabIndex = 4;
            label2.Text = "Desired Temperature (°C)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 12);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 5;
            label1.Text = "Room Temperature (°C)";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label7);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(641, 383);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Room 2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(51, 119);
            label11.Name = "label11";
            label11.Size = new Size(372, 50);
            label11.TabIndex = 2;
            label11.Text = "Not Yet Implemented";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(51, 65);
            label10.Name = "label10";
            label10.Size = new Size(372, 50);
            label10.TabIndex = 1;
            label10.Text = "Not Yet Implemented";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(51, 12);
            label7.Name = "label7";
            label7.Size = new Size(372, 50);
            label7.TabIndex = 0;
            label7.Text = "Not Yet Implemented";
            // 
            // lblSimulationStatus
            // 
            lblSimulationStatus.AutoSize = true;
            lblSimulationStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSimulationStatus.ForeColor = Color.Blue;
            lblSimulationStatus.Location = new Point(143, 11);
            lblSimulationStatus.Name = "lblSimulationStatus";
            lblSimulationStatus.Size = new Size(86, 15);
            lblSimulationStatus.TabIndex = 8;
            lblSimulationStatus.Text = "--- ONLINE ---";
            // 
            // lblDBExtTemp
            // 
            lblDBExtTemp.AutoSize = true;
            lblDBExtTemp.Font = new Font("Segoe UI", 9F);
            lblDBExtTemp.Location = new Point(146, 43);
            lblDBExtTemp.Name = "lblDBExtTemp";
            lblDBExtTemp.Size = new Size(36, 15);
            lblDBExtTemp.TabIndex = 1;
            lblDBExtTemp.Text = "--  °C";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 43);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 0;
            label9.Text = "Ext Temp";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 9F);
            lblTime.Location = new Point(371, 11);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(71, 15);
            lblTime.TabIndex = 1;
            lblTime.Text = "_ _ - _ _ - _ _ ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(303, 11);
            label8.Name = "label8";
            label8.Size = new Size(34, 15);
            label8.TabIndex = 0;
            label8.Text = "Time";
            // 
            // Settings
            // 
            Settings.Controls.Add(loggerTab);
            Settings.Controls.Add(sensorTab);
            Settings.Controls.Add(hmiTab);
            Settings.Location = new Point(667, 119);
            Settings.Name = "Settings";
            Settings.SelectedIndex = 0;
            Settings.Size = new Size(413, 397);
            Settings.TabIndex = 7;
            // 
            // loggerTab
            // 
            loggerTab.BackColor = SystemColors.ButtonFace;
            loggerTab.Controls.Add(cmdClear);
            loggerTab.Controls.Add(rtbLog);
            loggerTab.Location = new Point(4, 24);
            loggerTab.Name = "loggerTab";
            loggerTab.Padding = new Padding(3);
            loggerTab.Size = new Size(405, 369);
            loggerTab.TabIndex = 0;
            loggerTab.Text = "Activity Log";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(6, 6);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(393, 326);
            rtbLog.TabIndex = 2;
            rtbLog.Text = "";
            // 
            // sensorTab
            // 
            sensorTab.BackColor = SystemColors.ButtonFace;
            sensorTab.Controls.Add(richTextBox2);
            sensorTab.Controls.Add(lblSensor);
            sensorTab.Controls.Add(txtSensor);
            sensorTab.Controls.Add(txtSensorDeviceId);
            sensorTab.Controls.Add(cmdConnectSensor);
            sensorTab.Controls.Add(cmbSearchSensor);
            sensorTab.Controls.Add(lblSensorDeviceId);
            sensorTab.Controls.Add(cmdSensorDevices);
            sensorTab.Location = new Point(4, 24);
            sensorTab.Name = "sensorTab";
            sensorTab.Padding = new Padding(3);
            sensorTab.Size = new Size(405, 383);
            sensorTab.TabIndex = 1;
            sensorTab.Text = "Sensor";
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = SystemColors.ButtonFace;
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.Location = new Point(24, 197);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(356, 176);
            richTextBox2.TabIndex = 8;
            richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // hmiTab
            // 
            hmiTab.BackColor = SystemColors.ButtonFace;
            hmiTab.Controls.Add(textBox1);
            hmiTab.Controls.Add(btnClearHMIlog);
            hmiTab.Controls.Add(richTextBox1);
            hmiTab.Controls.Add(txtHMIExternalTemperature);
            hmiTab.Controls.Add(cmbHMIdevices);
            hmiTab.Controls.Add(txtHMIDesiredTemperature);
            hmiTab.Controls.Add(cmdSearchHMI);
            hmiTab.Controls.Add(txtHMIRoomTemperature);
            hmiTab.Controls.Add(txtHMIDeviceID);
            hmiTab.Controls.Add(cmdConnectHMI);
            hmiTab.Controls.Add(lblHMIDeviceID);
            hmiTab.Controls.Add(lblHMIExternalTemperature);
            hmiTab.Controls.Add(lblHMIRoomTemperature);
            hmiTab.Controls.Add(lblHMIDesiredTemperature);
            hmiTab.Location = new Point(4, 24);
            hmiTab.Name = "hmiTab";
            hmiTab.Padding = new Padding(3);
            hmiTab.Size = new Size(405, 383);
            hmiTab.TabIndex = 2;
            hmiTab.Text = "HMI";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ButtonFace;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Location = new Point(202, 156);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(194, 54);
            textBox1.TabIndex = 9;
            textBox1.Text = "Connect your bluetooth mobile app with this controller using this section";
            // 
            // btnClearHMIlog
            // 
            btnClearHMIlog.Location = new Point(324, 354);
            btnClearHMIlog.Name = "btnClearHMIlog";
            btnClearHMIlog.Size = new Size(75, 23);
            btnClearHMIlog.TabIndex = 8;
            btnClearHMIlog.Text = "Clear Log";
            btnClearHMIlog.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(8, 247);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(391, 101);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(3, 11);
            label12.Name = "label12";
            label12.Size = new Size(122, 15);
            label12.TabIndex = 9;
            label12.Text = "HVAC Control System";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ButtonFace;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Enabled = false;
            textBox2.Location = new Point(318, 11);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(717, 55);
            textBox2.TabIndex = 10;
            textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // ControlsTab
            // 
            ControlsTab.Controls.Add(tabPage3);
            ControlsTab.Controls.Add(tabPage4);
            ControlsTab.Location = new Point(12, 12);
            ControlsTab.Name = "ControlsTab";
            ControlsTab.SelectedIndex = 0;
            ControlsTab.Size = new Size(1068, 101);
            ControlsTab.TabIndex = 8;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = SystemColors.ButtonFace;
            tabPage3.Controls.Add(textBox4);
            tabPage3.Controls.Add(cmdStop);
            tabPage3.Controls.Add(lblSimulationStatus);
            tabPage3.Controls.Add(cmdStart);
            tabPage3.Controls.Add(chkRealtime);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(lblTime);
            tabPage3.Controls.Add(lblDBExtTemp);
            tabPage3.Controls.Add(label8);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1060, 73);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "System Control";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.ButtonFace;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.Location = new Point(661, 6);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(393, 62);
            textBox4.TabIndex = 12;
            textBox4.Text = resources.GetString("textBox4.Text");
            // 
            // tabPage4
            // 
            tabPage4.BackColor = SystemColors.ButtonFace;
            tabPage4.Controls.Add(cmdSetExtTemp);
            tabPage4.Controls.Add(textBox2);
            tabPage4.Controls.Add(chkOverrideExternal);
            tabPage4.Controls.Add(lblExtTemp);
            tabPage4.Controls.Add(txtExtTemp);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1060, 73);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "Debug Mode";
            // 
            // MainDashboardForm
            // 
            ClientSize = new Size(1079, 520);
            Controls.Add(ControlsTab);
            Controls.Add(Settings);
            Controls.Add(tabRoom1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "MainDashboardForm";
            Text = "DormClimate Dashboard";
            FormClosing += MainDashboardForm_FormClosing;
            tabRoom1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            Settings.ResumeLayout(false);
            loggerTab.ResumeLayout(false);
            sensorTab.ResumeLayout(false);
            sensorTab.PerformLayout();
            hmiTab.ResumeLayout(false);
            hmiTab.PerformLayout();
            ControlsTab.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxOverride;
        private Label lblHMIDesiredTemperature;
        private Label lblHMIRoomTemperature;
        private Label lblHMIDeviceID;
        private Label lblHMIExternalTemperature;
        private Button cmdSearchHMI;
        private TextBox txtHMIExternalTemperature;
        private TextBox txtHMIDesiredTemperature;
        private TextBox txtHMIRoomTemperature;
        private Button cmdConnectHMI;
        private TextBox txtHMIDeviceID;
        private ComboBox cmbHMIdevices;
        private Button cmbSearchSensor;
        private ComboBox cmdSensorDevices;
        private Button cmdConnectSensor;
        private Label lblSensorDeviceId;
        private TextBox txtSensorDeviceId;
        private Label lblSensor;
        private TextBox txtSensor;
        private CheckBox chkOverrideExternal;
        private Button cmdSetExtTemp;
        private Label lblExtTemp;
        private TextBox txtExtTemp;
        private Button cmdClear;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        protected internal TabControl tabRoom1;
        private CheckBox chkOverrideHMI;
        private Button btnRoomOneMinusTen;
        private Button btnRoomOneMinusFive;
        private Button btnRoomOnePlusFive;
        private Button btnRoomOnePlusTen;
        private Label label7;
        private GroupBox groupBox1;
        private Button cmdStop;
        private Button cmdStart;
        private Label lblTime;
        private Label label8;
        private CheckBox chkRealtime;
        private Label lblRoom1AC;
        private Label lblRoom1Heater;
        private Label lblRoom1HVACstatus;
        private Label lblRoom1ExternalTemp;
        private Label lblRoom1DesiredTemp;
        private Label lblRoom1Temp;
        private Label lblDBExtTemp;
        private Label label9;
        private Label label11;
        private Label label10;
        private Label lblSimulationStatus;
        private TabControl Settings;
        private TabPage loggerTab;
        private RichTextBox rtbLog;
        private TabPage sensorTab;
        private TabPage hmiTab;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private Button button1;
        private Button btnClearHMIlog;
        private Label label12;
        private TextBox textBox2;
        private TextBox textBox3;
        private TabControl ControlsTab;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TextBox textBox4;
        private RichTextBox richTextBox2;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
    }
}
