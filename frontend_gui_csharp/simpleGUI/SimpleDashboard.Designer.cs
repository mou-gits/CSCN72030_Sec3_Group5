using DormClimateBackend.Models;


namespace simpleGUI
{
    partial class SimpleDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void SimpleDashboard_Load(object sender, EventArgs e)
        {
            externalService = new ExternalTemperatureService("your_database_path.db");
            chkRealTime.Checked = true;
            textTimeGap.Text = "1"; // default 1 second
            textDuration.Text = "300"; // default 5 minutes
            textInitialTemperature.Text = "21.0"; // default room temp
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblACPercent = new Label();
            lblHeaterPercent = new Label();
            lblHVACMode = new Label();
            label7 = new Label();
            lblDesiredTemperature = new Label();
            label9 = new Label();
            groupBox2 = new GroupBox();
            lblRoomTemperature = new Label();
            lblExternalTime = new Label();
            lblTime = new Label();
            lblDate = new Label();
            label13 = new Label();
            label15 = new Label();
            label16 = new Label();
            groupBox3 = new GroupBox();
            textInitialTemperature = new TextBox();
            label17 = new Label();
            cmdStart = new Button();
            label18 = new Label();
            textTimeGap = new TextBox();
            chkRealTime = new CheckBox();
            lblDuration = new TextBox();
            label19 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblDesiredTemperature);
            groupBox1.Controls.Add(lblHVACMode);
            groupBox1.Controls.Add(lblHeaterPercent);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblACPercent);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(280, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(261, 153);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Controller Mode";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(21, 29);
            label1.Name = "label1";
            label1.Size = new Size(39, 17);
            label1.TabIndex = 0;
            label1.Text = "AC %";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(21, 60);
            label2.Name = "label2";
            label2.Size = new Size(62, 17);
            label2.TabIndex = 0;
            label2.Text = "Heater %";
            label2.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(21, 91);
            label3.Name = "label3";
            label3.Size = new Size(79, 17);
            label3.TabIndex = 0;
            label3.Text = "HVAC Mode";
            label3.Click += label1_Click;
            // 
            // lblACPercent
            // 
            lblACPercent.AutoSize = true;
            lblACPercent.Font = new Font("Segoe UI", 9.75F);
            lblACPercent.Location = new Point(196, 29);
            lblACPercent.Name = "lblACPercent";
            lblACPercent.Size = new Size(43, 17);
            lblACPercent.TabIndex = 1;
            lblACPercent.Text = "label4";
            // 
            // lblHeaterPercent
            // 
            lblHeaterPercent.AutoSize = true;
            lblHeaterPercent.Font = new Font("Segoe UI", 9.75F);
            lblHeaterPercent.Location = new Point(196, 60);
            lblHeaterPercent.Name = "lblHeaterPercent";
            lblHeaterPercent.Size = new Size(43, 17);
            lblHeaterPercent.TabIndex = 1;
            lblHeaterPercent.Text = "label4";
            // 
            // lblHVACMode
            // 
            lblHVACMode.AutoSize = true;
            lblHVACMode.Font = new Font("Segoe UI", 9.75F);
            lblHVACMode.Location = new Point(196, 91);
            lblHVACMode.Name = "lblHVACMode";
            lblHVACMode.Size = new Size(43, 17);
            lblHVACMode.TabIndex = 1;
            lblHVACMode.Text = "label4";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(21, 122);
            label7.Name = "label7";
            label7.Size = new Size(131, 17);
            label7.TabIndex = 0;
            label7.Text = "Desired Temperature";
            label7.Click += label1_Click;
            // 
            // lblDesiredTemperature
            // 
            lblDesiredTemperature.AutoSize = true;
            lblDesiredTemperature.Font = new Font("Segoe UI", 9.75F);
            lblDesiredTemperature.Location = new Point(196, 122);
            lblDesiredTemperature.Name = "lblDesiredTemperature";
            lblDesiredTemperature.Size = new Size(43, 17);
            lblDesiredTemperature.TabIndex = 1;
            lblDesiredTemperature.Text = "label4";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.Location = new Point(24, 29);
            label9.Name = "label9";
            label9.Size = new Size(35, 17);
            label9.TabIndex = 1;
            label9.Text = "Date";
            label9.Click += label9_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblRoomTemperature);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(lblExternalTime);
            groupBox2.Controls.Add(lblTime);
            groupBox2.Controls.Add(lblDate);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(262, 153);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Controller Mode";
            // 
            // lblRoomTemperature
            // 
            lblRoomTemperature.AutoSize = true;
            lblRoomTemperature.Font = new Font("Segoe UI", 9.75F);
            lblRoomTemperature.Location = new Point(180, 122);
            lblRoomTemperature.Name = "lblRoomTemperature";
            lblRoomTemperature.Size = new Size(43, 17);
            lblRoomTemperature.TabIndex = 1;
            lblRoomTemperature.Text = "label4";
            // 
            // lblExternalTime
            // 
            lblExternalTime.AutoSize = true;
            lblExternalTime.Font = new Font("Segoe UI", 9.75F);
            lblExternalTime.Location = new Point(180, 91);
            lblExternalTime.Name = "lblExternalTime";
            lblExternalTime.Size = new Size(43, 17);
            lblExternalTime.TabIndex = 1;
            lblExternalTime.Text = "label4";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 9.75F);
            lblTime.Location = new Point(180, 60);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(43, 17);
            lblTime.TabIndex = 1;
            lblTime.Text = "label4";
            lblTime.Click += label12_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9.75F);
            lblDate.Location = new Point(180, 29);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(50, 17);
            lblDate.TabIndex = 1;
            lblDate.Text = "label14";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F);
            label13.Location = new Point(24, 60);
            label13.Name = "label13";
            label13.Size = new Size(36, 17);
            label13.TabIndex = 1;
            label13.Text = "Time";
            label13.Click += label9_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9.75F);
            label15.Location = new Point(24, 91);
            label15.Name = "label15";
            label15.Size = new Size(131, 17);
            label15.TabIndex = 1;
            label15.Text = "Outside Temperature";
            label15.Click += label9_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9.75F);
            label16.Location = new Point(24, 122);
            label16.Name = "label16";
            label16.Size = new Size(121, 17);
            label16.TabIndex = 1;
            label16.Text = "Room Temperature";
            label16.Click += label9_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chkRealTime);
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(cmdStart);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(lblDuration);
            groupBox3.Controls.Add(textTimeGap);
            groupBox3.Controls.Add(textInitialTemperature);
            groupBox3.Location = new Point(12, 171);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(528, 114);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Demonstration Mode";
            // 
            // textInitialTemperature
            // 
            textInitialTemperature.Location = new Point(186, 28);
            textInitialTemperature.Name = "textInitialTemperature";
            textInitialTemperature.Size = new Size(76, 23);
            textInitialTemperature.TabIndex = 0;
            textInitialTemperature.TextChanged += textBox1_TextChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9.75F);
            label17.Location = new Point(24, 31);
            label17.Name = "label17";
            label17.Size = new Size(155, 17);
            label17.TabIndex = 1;
            label17.Text = "Initial Room Temperature";
            // 
            // cmdStart
            // 
            cmdStart.Location = new Point(427, 28);
            cmdStart.Name = "cmdStart";
            cmdStart.Size = new Size(75, 23);
            cmdStart.TabIndex = 2;
            cmdStart.Text = "Start";
            cmdStart.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9.75F);
            label18.Location = new Point(24, 76);
            label18.Name = "label18";
            label18.Size = new Size(98, 17);
            label18.TabIndex = 3;
            label18.Text = "Time resolution";
            // 
            // textTimeGap
            // 
            textTimeGap.Location = new Point(186, 73);
            textTimeGap.Name = "textTimeGap";
            textTimeGap.Size = new Size(76, 23);
            textTimeGap.TabIndex = 0;
            textTimeGap.TextChanged += textBox1_TextChanged;
            // 
            // chkRealTime
            // 
            chkRealTime.AutoSize = true;
            chkRealTime.Location = new Point(282, 30);
            chkRealTime.Name = "chkRealTime";
            chkRealTime.Size = new Size(139, 19);
            chkRealTime.TabIndex = 4;
            chkRealTime.Text = "Real time simulation?";
            chkRealTime.UseVisualStyleBackColor = true;
            chkRealTime.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // lblDuration
            // 
            lblDuration.Location = new Point(427, 73);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(75, 23);
            lblDuration.TabIndex = 0;
            lblDuration.TextChanged += textBox1_TextChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9.75F);
            label19.Location = new Point(282, 76);
            label19.Name = "label19";
            label19.Size = new Size(122, 17);
            label19.TabIndex = 3;
            label19.Text = "Simulation Duration";
            label19.Click += label19_Click;
            // 
            // SimpleDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 292);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "SimpleDashboard";
            Text = "SimpleDashboard";
            Load += SimpleDashboard_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label lblDesiredTemperature;
        private Label lblHVACMode;
        private Label lblHeaterPercent;
        private Label label7;
        private Label lblACPercent;
        private Label label3;
        private Label label2;
        private Label label9;
        private GroupBox groupBox2;
        private Label lblRoomTemperature;
        private Label lblExternalTime;
        private Label lblTime;
        private Label lblDate;
        private Label label13;
        private Label label16;
        private Label label15;
        private GroupBox groupBox3;
        private Label label17;
        private TextBox textInitialTemperature;
        private Label label18;
        private Button cmdStart;
        private TextBox textTimeGap;
        private CheckBox chkRealTime;
        private Label label19;
        private TextBox lblDuration;

    }
}