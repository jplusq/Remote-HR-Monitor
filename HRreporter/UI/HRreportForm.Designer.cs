namespace Q.IoT.Exercises.HR.UI
{
    partial class HRreportForm
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
            this.lblRate = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.rdoMonitor = new System.Windows.Forms.RadioButton();
            this.rdoSimulator = new System.Windows.Forms.RadioButton();
            this.barRange = new System.Windows.Forms.TrackBar();
            this.lblReport = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barRange)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRate
            // 
            this.lblRate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate.Location = new System.Drawing.Point(0, 0);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(200, 55);
            this.lblRate.TabIndex = 0;
            this.lblRate.Text = "---";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtData
            // 
            this.txtData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtData.Location = new System.Drawing.Point(0, 152);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(200, 159);
            this.txtData.TabIndex = 4;
            // 
            // rdoMonitor
            // 
            this.rdoMonitor.AutoSize = true;
            this.rdoMonitor.Location = new System.Drawing.Point(10, 79);
            this.rdoMonitor.Name = "rdoMonitor";
            this.rdoMonitor.Size = new System.Drawing.Size(74, 17);
            this.rdoMonitor.TabIndex = 5;
            this.rdoMonitor.Text = "Monitoring";
            this.rdoMonitor.UseVisualStyleBackColor = true;
            this.rdoMonitor.CheckedChanged += new System.EventHandler(this.rdoMonitor_CheckedChanged);
            // 
            // rdoSimulator
            // 
            this.rdoSimulator.AutoSize = true;
            this.rdoSimulator.Location = new System.Drawing.Point(108, 79);
            this.rdoSimulator.Name = "rdoSimulator";
            this.rdoSimulator.Size = new System.Drawing.Size(73, 17);
            this.rdoSimulator.TabIndex = 6;
            this.rdoSimulator.Text = "Simulation";
            this.rdoSimulator.UseVisualStyleBackColor = true;
            this.rdoSimulator.CheckedChanged += new System.EventHandler(this.rdoSimulator_CheckedChanged);
            // 
            // barRange
            // 
            this.barRange.Location = new System.Drawing.Point(1, 101);
            this.barRange.Maximum = 200;
            this.barRange.Minimum = 30;
            this.barRange.Name = "barRange";
            this.barRange.Size = new System.Drawing.Size(198, 45);
            this.barRange.TabIndex = 7;
            this.barRange.Value = 30;
            this.barRange.Scroll += new System.EventHandler(this.barRange_Scroll);
            // 
            // lblReport
            // 
            this.lblReport.Location = new System.Drawing.Point(1, 53);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(199, 23);
            this.lblReport.TabIndex = 8;
            this.lblReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HRreportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 311);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.barRange);
            this.Controls.Add(this.rdoSimulator);
            this.Controls.Add(this.rdoMonitor);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.lblRate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HRreportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HR Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.barRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.RadioButton rdoMonitor;
        private System.Windows.Forms.RadioButton rdoSimulator;
        private System.Windows.Forms.TrackBar barRange;
        private System.Windows.Forms.Label lblReport;
    }
}

