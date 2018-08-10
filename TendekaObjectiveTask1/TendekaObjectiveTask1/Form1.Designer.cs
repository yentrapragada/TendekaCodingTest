namespace TendekaObjectiveTask1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lstDepth = new System.Windows.Forms.ListBox();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.lblDepthDisplay = new System.Windows.Forms.Label();
            this.lblFiberName = new System.Windows.Forms.Label();
            this.lblSelectDepth = new System.Windows.Forms.Label();
            this.lblParseError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.button1.Location = new System.Drawing.Point(130, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(130, 185);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(200, 26);
            this.txtDisplayName.TabIndex = 1;
            this.txtDisplayName.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(130, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstDepth
            // 
            this.lstDepth.FormattingEnabled = true;
            this.lstDepth.ItemHeight = 20;
            this.lstDepth.Location = new System.Drawing.Point(650, 59);
            this.lstDepth.Name = "lstDepth";
            this.lstDepth.ScrollAlwaysVisible = true;
            this.lstDepth.Size = new System.Drawing.Size(319, 64);
            this.lstDepth.TabIndex = 3;
            this.lstDepth.Visible = false;
            this.lstDepth.SelectedValueChanged += new System.EventHandler(this.lstDepth_SelectedValueChanged);
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Location = new System.Drawing.Point(473, 204);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(0, 20);
            this.lblDisplay.TabIndex = 4;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(473, 167);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Maroon};
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Details";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(613, 300);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(1179, 233);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(0, 20);
            this.lblTemp.TabIndex = 6;
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepth.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblDepth.Location = new System.Drawing.Point(471, 133);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(94, 25);
            this.lblDepth.TabIndex = 7;
            this.lblDepth.Text = "Depth :  ";
            this.lblDepth.Visible = false;
            // 
            // lblDepthDisplay
            // 
            this.lblDepthDisplay.AutoSize = true;
            this.lblDepthDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepthDisplay.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblDepthDisplay.Location = new System.Drawing.Point(571, 133);
            this.lblDepthDisplay.Name = "lblDepthDisplay";
            this.lblDepthDisplay.Size = new System.Drawing.Size(0, 25);
            this.lblDepthDisplay.TabIndex = 8;
            // 
            // lblFiberName
            // 
            this.lblFiberName.AutoSize = true;
            this.lblFiberName.Location = new System.Drawing.Point(34, 188);
            this.lblFiberName.Name = "lblFiberName";
            this.lblFiberName.Size = new System.Drawing.Size(87, 20);
            this.lblFiberName.TabIndex = 9;
            this.lblFiberName.Text = "FiberName";
            this.lblFiberName.Visible = false;
            // 
            // lblSelectDepth
            // 
            this.lblSelectDepth.AutoSize = true;
            this.lblSelectDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDepth.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblSelectDepth.Location = new System.Drawing.Point(469, 59);
            this.lblSelectDepth.Name = "lblSelectDepth";
            this.lblSelectDepth.Size = new System.Drawing.Size(154, 25);
            this.lblSelectDepth.TabIndex = 10;
            this.lblSelectDepth.Text = "Select Depth   ";
            this.lblSelectDepth.Visible = false;
            // 
            // lblParseError
            // 
            this.lblParseError.AutoSize = true;
            this.lblParseError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParseError.Location = new System.Drawing.Point(401, 135);
            this.lblParseError.Name = "lblParseError";
            this.lblParseError.Size = new System.Drawing.Size(0, 25);
            this.lblParseError.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 558);
            this.Controls.Add(this.lblParseError);
            this.Controls.Add(this.lblSelectDepth);
            this.Controls.Add(this.lblFiberName);
            this.Controls.Add(this.lblDepthDisplay);
            this.Controls.Add(this.lblDepth);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.lstDepth);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Tendeka Windows Application";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lstDepth;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.Label lblDepthDisplay;
        private System.Windows.Forms.Label lblFiberName;
        private System.Windows.Forms.Label lblSelectDepth;
        private System.Windows.Forms.Label lblParseError;
    }
}

