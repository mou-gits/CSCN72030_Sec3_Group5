
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
            groupBoxHMI = new GroupBox();
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
            groupBoxSensor = new GroupBox();
            cmdConnectSensor = new Button();
            cmdSensorDevices = new ComboBox();
            cmbSearchSensor = new Button();
            txtSensorDeviceId = new TextBox();
            txtSensor = new TextBox();
            lblSensorDeviceId = new Label();
            lblSensor = new Label();
            groupBoxOverride = new GroupBox();
            lblExtTemp = new Label();
            txtExtTemp = new TextBox();
            cmdStop = new Button();
            cmdStart = new Button();
            cmdSetExtTemp = new Button();
            chkOverrideExternal = new CheckBox();
            chkRealtime = new CheckBox();
            groupBoxLog = new GroupBox();
            rtbLog = new RichTextBox();
            cmdClear = new Button();
            tabRoom1 = new TabControl();
            tabPage1 = new TabPage();
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
            groupBox1 = new GroupBox();
            lblDBExtTemp = new Label();
            label9 = new Label();
            lblTime = new Label();
            label8 = new Label();
            groupBoxHMI.SuspendLayout();
            groupBoxSensor.SuspendLayout();
            groupBoxOverride.SuspendLayout();
            groupBoxLog.SuspendLayout();
            tabRoom1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxHMI
            // 
            groupBoxHMI.Controls.Add(cmbHMIdevices);
            groupBoxHMI.Controls.Add(txtHMIExternalTemperature);
            groupBoxHMI.Controls.Add(txtHMIDesiredTemperature);
            groupBoxHMI.Controls.Add(txtHMIDeviceID);
            groupBoxHMI.Controls.Add(txtHMIRoomTemperature);
            groupBoxHMI.Controls.Add(cmdConnectHMI);
            groupBoxHMI.Controls.Add(cmdSearchHMI);
            groupBoxHMI.Controls.Add(lblHMIExternalTemperature);
            groupBoxHMI.Controls.Add(lblHMIDesiredTemperature);
            groupBoxHMI.Controls.Add(lblHMIRoomTemperature);
            groupBoxHMI.Controls.Add(lblHMIDeviceID);
            groupBoxHMI.Location = new Point(12, 12);
            groupBoxHMI.Name = "groupBoxHMI";
            groupBoxHMI.Size = new Size(317, 235);
            groupBoxHMI.TabIndex = 0;
            groupBoxHMI.TabStop = false;
            groupBoxHMI.Text = "HMI Device";
            groupBoxHMI.Enter += groupBoxHMI_Enter;
            // 
            // cmbHMIdevices
            // 
            cmbHMIdevices.FormattingEnabled = true;
            cmbHMIdevices.Location = new Point(6, 52);
            cmbHMIdevices.Name = "cmbHMIdevices";
            cmbHMIdevices.Size = new Size(135, 23);
            cmbHMIdevices.TabIndex = 6;
            // 
            // txtHMIExternalTemperature
            // 
            txtHMIExternalTemperature.Location = new Point(200, 195);
            txtHMIExternalTemperature.Name = "txtHMIExternalTemperature";
            txtHMIExternalTemperature.ReadOnly = true;
            txtHMIExternalTemperature.Size = new Size(100, 23);
            txtHMIExternalTemperature.TabIndex = 5;
            txtHMIExternalTemperature.TextChanged += textBox4_TextChanged;
            // 
            // txtHMIDesiredTemperature
            // 
            txtHMIDesiredTemperature.Location = new Point(200, 158);
            txtHMIDesiredTemperature.Name = "txtHMIDesiredTemperature";
            txtHMIDesiredTemperature.ReadOnly = true;
            txtHMIDesiredTemperature.Size = new Size(100, 23);
            txtHMIDesiredTemperature.TabIndex = 5;
            txtHMIDesiredTemperature.TextChanged += textBox3_TextChanged;
            // 
            // txtHMIDeviceID
            // 
            txtHMIDeviceID.Location = new Point(200, 84);
            txtHMIDeviceID.Name = "txtHMIDeviceID";
            txtHMIDeviceID.ReadOnly = true;
            txtHMIDeviceID.Size = new Size(100, 23);
            txtHMIDeviceID.TabIndex = 5;
            txtHMIDeviceID.TextChanged += txtHMIRoomTemperature_TextChanged;
            // 
            // txtHMIRoomTemperature
            // 
            txtHMIRoomTemperature.Location = new Point(200, 121);
            txtHMIRoomTemperature.Name = "txtHMIRoomTemperature";
            txtHMIRoomTemperature.ReadOnly = true;
            txtHMIRoomTemperature.Size = new Size(100, 23);
            txtHMIRoomTemperature.TabIndex = 5;
            txtHMIRoomTemperature.TextChanged += txtHMIRoomTemperature_TextChanged;
            // 
            // cmdConnectHMI
            // 
            cmdConnectHMI.Location = new Point(200, 51);
            cmdConnectHMI.Name = "cmdConnectHMI";
            cmdConnectHMI.Size = new Size(100, 23);
            cmdConnectHMI.TabIndex = 4;
            cmdConnectHMI.Text = "Connect Device";
            cmdConnectHMI.UseVisualStyleBackColor = true;
            // 
            // cmdSearchHMI
            // 
            cmdSearchHMI.Location = new Point(6, 22);
            cmdSearchHMI.Name = "cmdSearchHMI";
            cmdSearchHMI.Size = new Size(294, 23);
            cmdSearchHMI.TabIndex = 4;
            cmdSearchHMI.Text = "Search BlueTooth Devices";
            cmdSearchHMI.UseVisualStyleBackColor = true;
            // 
            // lblHMIExternalTemperature
            // 
            lblHMIExternalTemperature.AutoSize = true;
            lblHMIExternalTemperature.Location = new Point(6, 198);
            lblHMIExternalTemperature.Name = "lblHMIExternalTemperature";
            lblHMIExternalTemperature.Size = new Size(135, 15);
            lblHMIExternalTemperature.TabIndex = 3;
            lblHMIExternalTemperature.Text = "Displayed External Temp";
            lblHMIExternalTemperature.Click += label1_Click;
            // 
            // lblHMIDesiredTemperature
            // 
            lblHMIDesiredTemperature.AutoSize = true;
            lblHMIDesiredTemperature.Location = new Point(6, 161);
            lblHMIDesiredTemperature.Name = "lblHMIDesiredTemperature";
            lblHMIDesiredTemperature.Size = new Size(116, 15);
            lblHMIDesiredTemperature.TabIndex = 2;
            lblHMIDesiredTemperature.Text = "Desired Temperature";
            lblHMIDesiredTemperature.Click += lblHMIDesiredTemperature_Click;
            // 
            // lblHMIRoomTemperature
            // 
            lblHMIRoomTemperature.AutoSize = true;
            lblHMIRoomTemperature.Location = new Point(6, 124);
            lblHMIRoomTemperature.Name = "lblHMIRoomTemperature";
            lblHMIRoomTemperature.Size = new Size(126, 15);
            lblHMIRoomTemperature.TabIndex = 1;
            lblHMIRoomTemperature.Text = "Displayed Room Temp";
            lblHMIRoomTemperature.Click += label2_Click;
            // 
            // lblHMIDeviceID
            // 
            lblHMIDeviceID.AutoSize = true;
            lblHMIDeviceID.Location = new Point(6, 87);
            lblHMIDeviceID.Name = "lblHMIDeviceID";
            lblHMIDeviceID.Size = new Size(82, 15);
            lblHMIDeviceID.TabIndex = 0;
            lblHMIDeviceID.Text = "HMI Device ID";
            lblHMIDeviceID.Click += lblHMIDeviceID_Click;
            // 
            // groupBoxSensor
            // 
            groupBoxSensor.Controls.Add(cmdConnectSensor);
            groupBoxSensor.Controls.Add(cmdSensorDevices);
            groupBoxSensor.Controls.Add(cmbSearchSensor);
            groupBoxSensor.Controls.Add(txtSensorDeviceId);
            groupBoxSensor.Controls.Add(txtSensor);
            groupBoxSensor.Controls.Add(lblSensorDeviceId);
            groupBoxSensor.Controls.Add(lblSensor);
            groupBoxSensor.Location = new Point(335, 12);
            groupBoxSensor.Name = "groupBoxSensor";
            groupBoxSensor.Size = new Size(303, 166);
            groupBoxSensor.TabIndex = 1;
            groupBoxSensor.TabStop = false;
            groupBoxSensor.Text = "Sensor Surrogate";
            // 
            // cmdConnectSensor
            // 
            cmdConnectSensor.Location = new Point(171, 52);
            cmdConnectSensor.Name = "cmdConnectSensor";
            cmdConnectSensor.Size = new Size(121, 23);
            cmdConnectSensor.TabIndex = 7;
            cmdConnectSensor.Text = "Connect Device";
            cmdConnectSensor.UseVisualStyleBackColor = true;
            // 
            // cmdSensorDevices
            // 
            cmdSensorDevices.FormattingEnabled = true;
            cmdSensorDevices.Location = new Point(6, 52);
            cmdSensorDevices.Name = "cmdSensorDevices";
            cmdSensorDevices.Size = new Size(135, 23);
            cmdSensorDevices.TabIndex = 7;
            // 
            // cmbSearchSensor
            // 
            cmbSearchSensor.Location = new Point(6, 22);
            cmbSearchSensor.Name = "cmbSearchSensor";
            cmbSearchSensor.Size = new Size(286, 23);
            cmbSearchSensor.TabIndex = 4;
            cmbSearchSensor.Text = "Search BlueTooth Devices";
            cmbSearchSensor.UseVisualStyleBackColor = true;
            cmbSearchSensor.Click += button1_Click;
            // 
            // txtSensorDeviceId
            // 
            txtSensorDeviceId.Location = new Point(171, 87);
            txtSensorDeviceId.Name = "txtSensorDeviceId";
            txtSensorDeviceId.ReadOnly = true;
            txtSensorDeviceId.Size = new Size(121, 23);
            txtSensorDeviceId.TabIndex = 5;
            txtSensorDeviceId.TextChanged += txtHMIRoomTemperature_TextChanged;
            // 
            // txtSensor
            // 
            txtSensor.Location = new Point(171, 124);
            txtSensor.Name = "txtSensor";
            txtSensor.ReadOnly = true;
            txtSensor.Size = new Size(121, 23);
            txtSensor.TabIndex = 5;
            txtSensor.TextChanged += txtHMIRoomTemperature_TextChanged;
            // 
            // lblSensorDeviceId
            // 
            lblSensorDeviceId.AutoSize = true;
            lblSensorDeviceId.Location = new Point(6, 90);
            lblSensorDeviceId.Name = "lblSensorDeviceId";
            lblSensorDeviceId.Size = new Size(94, 15);
            lblSensorDeviceId.TabIndex = 0;
            lblSensorDeviceId.Text = "Sensor Device ID";
            lblSensorDeviceId.Click += lblHMIDeviceID_Click;
            // 
            // lblSensor
            // 
            lblSensor.AutoSize = true;
            lblSensor.Location = new Point(6, 127);
            lblSensor.Name = "lblSensor";
            lblSensor.Size = new Size(112, 15);
            lblSensor.TabIndex = 1;
            lblSensor.Text = "Sensor Temperature";
            lblSensor.Click += label2_Click;
            // 
            // groupBoxOverride
            // 
            groupBoxOverride.Controls.Add(lblExtTemp);
            groupBoxOverride.Controls.Add(txtExtTemp);
            groupBoxOverride.Controls.Add(cmdStop);
            groupBoxOverride.Controls.Add(cmdStart);
            groupBoxOverride.Controls.Add(cmdSetExtTemp);
            groupBoxOverride.Controls.Add(chkOverrideExternal);
            groupBoxOverride.Location = new Point(500, 253);
            groupBoxOverride.Name = "groupBoxOverride";
            groupBoxOverride.Size = new Size(138, 208);
            groupBoxOverride.TabIndex = 3;
            groupBoxOverride.TabStop = false;
            groupBoxOverride.Text = "Control";
            // 
            // lblExtTemp
            // 
            lblExtTemp.AutoSize = true;
            lblExtTemp.Location = new Point(6, 69);
            lblExtTemp.Name = "lblExtTemp";
            lblExtTemp.Size = new Size(55, 15);
            lblExtTemp.TabIndex = 3;
            lblExtTemp.Text = "Ext Temp";
            lblExtTemp.Click += lblExtTemp_Click;
            // 
            // txtExtTemp
            // 
            txtExtTemp.Location = new Point(76, 65);
            txtExtTemp.Name = "txtExtTemp";
            txtExtTemp.Size = new Size(49, 23);
            txtExtTemp.TabIndex = 2;
            txtExtTemp.TextChanged += textBox1_TextChanged;
            // 
            // cmdStop
            // 
            cmdStop.Location = new Point(6, 167);
            cmdStop.Name = "cmdStop";
            cmdStop.Size = new Size(121, 23);
            cmdStop.TabIndex = 1;
            cmdStop.Text = "Stop System";
            cmdStop.UseVisualStyleBackColor = true;
            cmdStop.Click += cmdSetExtTemp_Click;
            // 
            // cmdStart
            // 
            cmdStart.Location = new Point(6, 133);
            cmdStart.Name = "cmdStart";
            cmdStart.Size = new Size(121, 23);
            cmdStart.TabIndex = 1;
            cmdStart.Text = "Start System";
            cmdStart.UseVisualStyleBackColor = true;
            cmdStart.Click += cmdSetExtTemp_Click;
            // 
            // cmdSetExtTemp
            // 
            cmdSetExtTemp.Location = new Point(5, 99);
            cmdSetExtTemp.Name = "cmdSetExtTemp";
            cmdSetExtTemp.Size = new Size(122, 23);
            cmdSetExtTemp.TabIndex = 1;
            cmdSetExtTemp.Text = "Set";
            cmdSetExtTemp.UseVisualStyleBackColor = true;
            cmdSetExtTemp.Click += cmdSetExtTemp_Click;
            // 
            // chkOverrideExternal
            // 
            chkOverrideExternal.AutoSize = true;
            chkOverrideExternal.Location = new Point(6, 36);
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
            chkRealtime.Location = new Point(6, 27);
            chkRealtime.Name = "chkRealtime";
            chkRealtime.Size = new Size(112, 19);
            chkRealtime.TabIndex = 7;
            chkRealtime.Text = "Real Time Mode";
            chkRealtime.UseVisualStyleBackColor = true;
            chkRealtime.CheckedChanged += chkRealtime_CheckedChanged;
            // 
            // groupBoxLog
            // 
            groupBoxLog.Controls.Add(rtbLog);
            groupBoxLog.Controls.Add(cmdClear);
            groupBoxLog.Location = new Point(12, 467);
            groupBoxLog.Name = "groupBoxLog";
            groupBoxLog.Size = new Size(626, 126);
            groupBoxLog.TabIndex = 4;
            groupBoxLog.TabStop = false;
            groupBoxLog.Text = "Event Log";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(6, 22);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(609, 75);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "";
            // 
            // cmdClear
            // 
            cmdClear.Location = new Point(550, 97);
            cmdClear.Name = "cmdClear";
            cmdClear.Size = new Size(65, 23);
            cmdClear.TabIndex = 0;
            cmdClear.Text = "Clear Log";
            cmdClear.UseVisualStyleBackColor = true;
            cmdClear.Click += cmdClear_Click;
            // 
            // tabRoom1
            // 
            tabRoom1.Controls.Add(tabPage1);
            tabRoom1.Controls.Add(tabPage2);
            tabRoom1.Location = new Point(12, 253);
            tabRoom1.Name = "tabRoom1";
            tabRoom1.SelectedIndex = 0;
            tabRoom1.Size = new Size(482, 208);
            tabRoom1.TabIndex = 5;
            // 
            // tabPage1
            // 
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
            tabPage1.Size = new Size(474, 180);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Room 1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblRoom1AC
            // 
            lblRoom1AC.AutoSize = true;
            lblRoom1AC.Location = new Point(196, 153);
            lblRoom1AC.Name = "lblRoom1AC";
            lblRoom1AC.Size = new Size(30, 15);
            lblRoom1AC.TabIndex = 9;
            lblRoom1AC.Text = "-- %";
            // 
            // lblRoom1Heater
            // 
            lblRoom1Heater.AutoSize = true;
            lblRoom1Heater.Location = new Point(196, 128);
            lblRoom1Heater.Name = "lblRoom1Heater";
            lblRoom1Heater.Size = new Size(30, 15);
            lblRoom1Heater.TabIndex = 9;
            lblRoom1Heater.Text = "-- %";
            // 
            // lblRoom1HVACstatus
            // 
            lblRoom1HVACstatus.AutoSize = true;
            lblRoom1HVACstatus.Location = new Point(196, 99);
            lblRoom1HVACstatus.Name = "lblRoom1HVACstatus";
            lblRoom1HVACstatus.Size = new Size(17, 15);
            lblRoom1HVACstatus.TabIndex = 9;
            lblRoom1HVACstatus.Text = "--";
            // 
            // lblRoom1ExternalTemp
            // 
            lblRoom1ExternalTemp.AutoSize = true;
            lblRoom1ExternalTemp.Location = new Point(196, 70);
            lblRoom1ExternalTemp.Name = "lblRoom1ExternalTemp";
            lblRoom1ExternalTemp.Size = new Size(36, 15);
            lblRoom1ExternalTemp.TabIndex = 9;
            lblRoom1ExternalTemp.Text = "--  °C";
            // 
            // lblRoom1DesiredTemp
            // 
            lblRoom1DesiredTemp.AutoSize = true;
            lblRoom1DesiredTemp.Location = new Point(196, 41);
            lblRoom1DesiredTemp.Name = "lblRoom1DesiredTemp";
            lblRoom1DesiredTemp.Size = new Size(36, 15);
            lblRoom1DesiredTemp.TabIndex = 9;
            lblRoom1DesiredTemp.Text = "--  °C";
            // 
            // lblRoom1Temp
            // 
            lblRoom1Temp.AutoSize = true;
            lblRoom1Temp.Location = new Point(196, 13);
            lblRoom1Temp.Name = "lblRoom1Temp";
            lblRoom1Temp.Size = new Size(36, 15);
            lblRoom1Temp.TabIndex = 9;
            lblRoom1Temp.Text = "--  °C";
            // 
            // chkOverrideHMI
            // 
            chkOverrideHMI.AutoSize = true;
            chkOverrideHMI.Location = new Point(344, 12);
            chkOverrideHMI.Name = "chkOverrideHMI";
            chkOverrideHMI.Size = new Size(116, 19);
            chkOverrideHMI.TabIndex = 8;
            chkOverrideHMI.Text = "Override Request";
            chkOverrideHMI.UseVisualStyleBackColor = true;
            // 
            // btnRoomOneMinusTen
            // 
            btnRoomOneMinusTen.Location = new Point(344, 143);
            btnRoomOneMinusTen.Name = "btnRoomOneMinusTen";
            btnRoomOneMinusTen.Size = new Size(116, 23);
            btnRoomOneMinusTen.TabIndex = 7;
            btnRoomOneMinusTen.Text = "- 10";
            btnRoomOneMinusTen.UseVisualStyleBackColor = true;
            // 
            // btnRoomOneMinusFive
            // 
            btnRoomOneMinusFive.Location = new Point(344, 109);
            btnRoomOneMinusFive.Name = "btnRoomOneMinusFive";
            btnRoomOneMinusFive.Size = new Size(116, 23);
            btnRoomOneMinusFive.TabIndex = 7;
            btnRoomOneMinusFive.Text = "- 5";
            btnRoomOneMinusFive.UseVisualStyleBackColor = true;
            // 
            // btnRoomOnePlusFive
            // 
            btnRoomOnePlusFive.Location = new Point(344, 75);
            btnRoomOnePlusFive.Name = "btnRoomOnePlusFive";
            btnRoomOnePlusFive.Size = new Size(116, 23);
            btnRoomOnePlusFive.TabIndex = 7;
            btnRoomOnePlusFive.Text = "+ 5";
            btnRoomOnePlusFive.UseVisualStyleBackColor = true;
            // 
            // btnRoomOnePlusTen
            // 
            btnRoomOnePlusTen.Location = new Point(344, 41);
            btnRoomOnePlusTen.Name = "btnRoomOnePlusTen";
            btnRoomOnePlusTen.Size = new Size(116, 23);
            btnRoomOnePlusTen.TabIndex = 7;
            btnRoomOnePlusTen.Text = "+ 10";
            btnRoomOnePlusTen.UseVisualStyleBackColor = true;
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
            tabPage2.Size = new Size(474, 180);
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
            label7.Click += label7_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkRealtime);
            groupBox1.Controls.Add(lblDBExtTemp);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(lblTime);
            groupBox1.Controls.Add(label8);
            groupBox1.Location = new Point(335, 184);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(303, 63);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "System";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lblDBExtTemp
            // 
            lblDBExtTemp.AutoSize = true;
            lblDBExtTemp.Location = new Point(231, 39);
            lblDBExtTemp.Name = "lblDBExtTemp";
            lblDBExtTemp.Size = new Size(36, 15);
            lblDBExtTemp.TabIndex = 1;
            lblDBExtTemp.Text = "--  °C";
            lblDBExtTemp.Click += lblDBExtTemp_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(170, 39);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 0;
            label9.Text = "Ext Temp";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(232, 15);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(71, 15);
            lblTime.TabIndex = 1;
            lblTime.Text = "_ _ - _ _ - _ _ ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(191, 16);
            label8.Name = "label8";
            label8.Size = new Size(34, 15);
            label8.TabIndex = 0;
            label8.Text = "Time";
            // 
            // MainDashboardForm
            // 
            ClientSize = new Size(647, 605);
            Controls.Add(groupBox1);
            Controls.Add(tabRoom1);
            Controls.Add(groupBoxSensor);
            Controls.Add(groupBoxHMI);
            Controls.Add(groupBoxOverride);
            Controls.Add(groupBoxLog);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "MainDashboardForm";
            Text = "DormClimate Dashboard";
            Load += MainDashboardForm_Load;
            groupBoxHMI.ResumeLayout(false);
            groupBoxHMI.PerformLayout();
            groupBoxSensor.ResumeLayout(false);
            groupBoxSensor.PerformLayout();
            groupBoxOverride.ResumeLayout(false);
            groupBoxOverride.PerformLayout();
            groupBoxLog.ResumeLayout(false);
            tabRoom1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        private void lblDBExtTemp_Click(object sender, EventArgs e)
        {
       
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
   
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void chkOverrideExternal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmdSetExtTemp_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblExtTemp_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
 
        }

        private void lblHMIDeviceID_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        { 
        }

        private void label1_Click(object sender, EventArgs e)
        {
     
        }

        private void groupBoxHMI_Enter(object sender, EventArgs e)
        {
      
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void txtHMIRoomTemperature_TextChanged(object sender, EventArgs e)
        {
    
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
     
        }

        private void lblHMIDesiredTemperature_Click(object sender, EventArgs e)
        {
           
        }

        #endregion

        // --- Controls ---
        private System.Windows.Forms.GroupBox groupBoxHMI;
        private System.Windows.Forms.GroupBox groupBoxSensor;
        private System.Windows.Forms.GroupBox groupBoxOverride;
        private System.Windows.Forms.GroupBox groupBoxLog;
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
        private RichTextBox rtbLog;
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
    }
}
