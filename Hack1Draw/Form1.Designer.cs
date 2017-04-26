namespace PerfectPidgeon.Draw
{
    partial class DrawForm
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
            this.components = new System.ComponentModel.Container();
            this.GLD = new OpenTK.GLControl();
            this.Time = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.HealthPanel = new System.Windows.Forms.Panel();
            this.WeaponLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LevelTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GLD
            // 
            this.GLD.BackColor = System.Drawing.Color.Black;
            this.GLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GLD.Location = new System.Drawing.Point(0, 0);
            this.GLD.Name = "GLD";
            this.GLD.Size = new System.Drawing.Size(1366, 768);
            this.GLD.TabIndex = 0;
            this.GLD.VSync = false;
            this.GLD.Load += new System.EventHandler(this.GLDLoad);
            this.GLD.Paint += new System.Windows.Forms.PaintEventHandler(this.GLDPaint);
            this.GLD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GLD_MouseDown);
            this.GLD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GLD_MouseMove);
            this.GLD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GLD_MouseUp);
            this.GLD.Resize += new System.EventHandler(this.GLD_Resize);
            // 
            // Time
            // 
            this.Time.Interval = 10;
            this.Time.Tick += new System.EventHandler(this.Time_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.HealthPanel);
            this.panel1.Location = new System.Drawing.Point(15, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 30);
            this.panel1.TabIndex = 1;
            // 
            // HealthPanel
            // 
            this.HealthPanel.BackColor = System.Drawing.Color.Silver;
            this.HealthPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.HealthPanel.Location = new System.Drawing.Point(0, 0);
            this.HealthPanel.Name = "HealthPanel";
            this.HealthPanel.Size = new System.Drawing.Size(120, 30);
            this.HealthPanel.TabIndex = 2;
            // 
            // WeaponLabel
            // 
            this.WeaponLabel.AutoSize = true;
            this.WeaponLabel.BackColor = System.Drawing.Color.Transparent;
            this.WeaponLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeaponLabel.ForeColor = System.Drawing.Color.Black;
            this.WeaponLabel.Location = new System.Drawing.Point(313, 20);
            this.WeaponLabel.Name = "WeaponLabel";
            this.WeaponLabel.Size = new System.Drawing.Size(90, 28);
            this.WeaponLabel.TabIndex = 2;
            this.WeaponLabel.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LevelTitle);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.WeaponLabel);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 66);
            this.panel2.TabIndex = 4;
            // 
            // LevelTitle
            // 
            this.LevelTitle.BackColor = System.Drawing.Color.Transparent;
            this.LevelTitle.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelTitle.ForeColor = System.Drawing.Color.Black;
            this.LevelTitle.Location = new System.Drawing.Point(233, 18);
            this.LevelTitle.Name = "LevelTitle";
            this.LevelTitle.Size = new System.Drawing.Size(74, 30);
            this.LevelTitle.TabIndex = 4;
            this.LevelTitle.Text = "TST";
            this.LevelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.GLD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DrawForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl GLD;
        private System.Windows.Forms.Timer Time;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel HealthPanel;
        private System.Windows.Forms.Label WeaponLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LevelTitle;
    }
}

