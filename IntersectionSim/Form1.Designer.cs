namespace IntersectionSim
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LaneGroup1 = new System.Windows.Forms.GroupBox();
            this.ToWestPerc1 = new System.Windows.Forms.NumericUpDown();
            this.ToSouthPerc1 = new System.Windows.Forms.NumericUpDown();
            this.ToEastPerc1 = new System.Windows.Forms.NumericUpDown();
            this.ToNorthPerc1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CarPerMin1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LaneParamEnabled1 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.SimulationDurationSelector = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.SpeedUpSelector = new System.Windows.Forms.NumericUpDown();
            this.CurrTimeLabel = new System.Windows.Forms.Label();
            this.PauseButton = new System.Windows.Forms.Button();
            this.ResumeButton = new System.Windows.Forms.Button();
            this.ManualIterButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.LaneGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToWestPerc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToSouthPerc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToEastPerc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToNorthPerc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarPerMin1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SimulationDurationSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedUpSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CurrTimeLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 500);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intersection Visualization";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.LaneGroup1);
            this.groupBox2.Location = new System.Drawing.Point(519, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 620);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Car Generation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Controls.Add(this.numericUpDown3);
            this.groupBox3.Controls.Add(this.numericUpDown4);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.numericUpDown5);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(6, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 120);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(109, 96);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(109, 76);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown2.TabIndex = 14;
            this.numericUpDown2.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(109, 56);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown3.TabIndex = 13;
            this.numericUpDown3.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(109, 36);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown4.TabIndex = 12;
            this.numericUpDown4.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "To West(%):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "To South(%):";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(109, 16);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown5.TabIndex = 2;
            this.numericUpDown5.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "To East(%):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "To North(%):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Cars/min";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "North Lane";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 44);
            this.label6.TabIndex = 8;
            this.label6.Text = "Specify which lanes should have non-random car generation";
            // 
            // LaneGroup1
            // 
            this.LaneGroup1.Controls.Add(this.ToWestPerc1);
            this.LaneGroup1.Controls.Add(this.ToSouthPerc1);
            this.LaneGroup1.Controls.Add(this.ToEastPerc1);
            this.LaneGroup1.Controls.Add(this.ToNorthPerc1);
            this.LaneGroup1.Controls.Add(this.label5);
            this.LaneGroup1.Controls.Add(this.label4);
            this.LaneGroup1.Controls.Add(this.CarPerMin1);
            this.LaneGroup1.Controls.Add(this.label3);
            this.LaneGroup1.Controls.Add(this.label2);
            this.LaneGroup1.Controls.Add(this.label1);
            this.LaneGroup1.Controls.Add(this.LaneParamEnabled1);
            this.LaneGroup1.Location = new System.Drawing.Point(6, 67);
            this.LaneGroup1.Name = "LaneGroup1";
            this.LaneGroup1.Size = new System.Drawing.Size(160, 120);
            this.LaneGroup1.TabIndex = 7;
            this.LaneGroup1.TabStop = false;
            this.LaneGroup1.Text = "groupBox3";
            // 
            // ToWestPerc1
            // 
            this.ToWestPerc1.Location = new System.Drawing.Point(109, 96);
            this.ToWestPerc1.Name = "ToWestPerc1";
            this.ToWestPerc1.Size = new System.Drawing.Size(43, 20);
            this.ToWestPerc1.TabIndex = 15;
            this.ToWestPerc1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // ToSouthPerc1
            // 
            this.ToSouthPerc1.Location = new System.Drawing.Point(109, 76);
            this.ToSouthPerc1.Name = "ToSouthPerc1";
            this.ToSouthPerc1.Size = new System.Drawing.Size(43, 20);
            this.ToSouthPerc1.TabIndex = 14;
            this.ToSouthPerc1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // ToEastPerc1
            // 
            this.ToEastPerc1.Location = new System.Drawing.Point(109, 56);
            this.ToEastPerc1.Name = "ToEastPerc1";
            this.ToEastPerc1.Size = new System.Drawing.Size(43, 20);
            this.ToEastPerc1.TabIndex = 13;
            this.ToEastPerc1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // ToNorthPerc1
            // 
            this.ToNorthPerc1.Location = new System.Drawing.Point(109, 36);
            this.ToNorthPerc1.Name = "ToNorthPerc1";
            this.ToNorthPerc1.Size = new System.Drawing.Size(43, 20);
            this.ToNorthPerc1.TabIndex = 12;
            this.ToNorthPerc1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "To West(%):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "To South(%):";
            // 
            // CarPerMin1
            // 
            this.CarPerMin1.Location = new System.Drawing.Point(109, 16);
            this.CarPerMin1.Name = "CarPerMin1";
            this.CarPerMin1.Size = new System.Drawing.Size(43, 20);
            this.CarPerMin1.TabIndex = 2;
            this.CarPerMin1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "To East(%):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "To North(%):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cars/min";
            // 
            // LaneParamEnabled1
            // 
            this.LaneParamEnabled1.AutoSize = true;
            this.LaneParamEnabled1.Location = new System.Drawing.Point(6, 0);
            this.LaneParamEnabled1.Name = "LaneParamEnabled1";
            this.LaneParamEnabled1.Size = new System.Drawing.Size(79, 17);
            this.LaneParamEnabled1.TabIndex = 6;
            this.LaneParamEnabled1.Text = "North Lane";
            this.LaneParamEnabled1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ManualIterButton);
            this.groupBox4.Controls.Add(this.ResumeButton);
            this.groupBox4.Controls.Add(this.PauseButton);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.SpeedUpSelector);
            this.groupBox4.Controls.Add(this.StartButton);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.SimulationDurationSelector);
            this.groupBox4.Location = new System.Drawing.Point(13, 520);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(500, 113);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Simulation Options";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(419, 11);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 20);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Simulation Duration (sec):";
            // 
            // SimulationDurationSelector
            // 
            this.SimulationDurationSelector.Location = new System.Drawing.Point(139, 14);
            this.SimulationDurationSelector.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.SimulationDurationSelector.Name = "SimulationDurationSelector";
            this.SimulationDurationSelector.Size = new System.Drawing.Size(45, 20);
            this.SimulationDurationSelector.TabIndex = 0;
            this.SimulationDurationSelector.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Time Speed Up Coeff:";
            // 
            // SpeedUpSelector
            // 
            this.SpeedUpSelector.Location = new System.Drawing.Point(139, 35);
            this.SpeedUpSelector.Name = "SpeedUpSelector";
            this.SpeedUpSelector.Size = new System.Drawing.Size(45, 20);
            this.SpeedUpSelector.TabIndex = 3;
            this.SpeedUpSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CurrTimeLabel
            // 
            this.CurrTimeLabel.AutoSize = true;
            this.CurrTimeLabel.Location = new System.Drawing.Point(7, 481);
            this.CurrTimeLabel.Name = "CurrTimeLabel";
            this.CurrTimeLabel.Size = new System.Drawing.Size(62, 13);
            this.CurrTimeLabel.TabIndex = 0;
            this.CurrTimeLabel.Text = "Time: 0 sec";
            // 
            // PauseButton
            // 
            this.PauseButton.Enabled = false;
            this.PauseButton.Location = new System.Drawing.Point(419, 63);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(75, 20);
            this.PauseButton.TabIndex = 5;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // ResumeButton
            // 
            this.ResumeButton.Enabled = false;
            this.ResumeButton.Location = new System.Drawing.Point(419, 37);
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.Size = new System.Drawing.Size(75, 20);
            this.ResumeButton.TabIndex = 6;
            this.ResumeButton.Text = "Animate";
            this.ResumeButton.UseVisualStyleBackColor = true;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // ManualIterButton
            // 
            this.ManualIterButton.Location = new System.Drawing.Point(419, 89);
            this.ManualIterButton.Name = "ManualIterButton";
            this.ManualIterButton.Size = new System.Drawing.Size(75, 20);
            this.ManualIterButton.TabIndex = 7;
            this.ManualIterButton.Text = "Iterate";
            this.ManualIterButton.UseVisualStyleBackColor = true;
            this.ManualIterButton.Click += new System.EventHandler(this.ManualIterButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 641);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "IntersectionSim";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.LaneGroup1.ResumeLayout(false);
            this.LaneGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToWestPerc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToSouthPerc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToEastPerc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToNorthPerc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarPerMin1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SimulationDurationSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedUpSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox LaneGroup1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown CarPerMin1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox LaneParamEnabled1;
        private System.Windows.Forms.NumericUpDown ToWestPerc1;
        private System.Windows.Forms.NumericUpDown ToSouthPerc1;
        private System.Windows.Forms.NumericUpDown ToEastPerc1;
        private System.Windows.Forms.NumericUpDown ToNorthPerc1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown SimulationDurationSelector;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown SpeedUpSelector;
        private System.Windows.Forms.Label CurrTimeLabel;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button ResumeButton;
        private System.Windows.Forms.Button ManualIterButton;
    }
}

