namespace Hackaton_Trening_1
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
            this.EnemyLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GLD
            // 
            this.GLD.BackColor = System.Drawing.Color.Black;
            this.GLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GLD.Location = new System.Drawing.Point(0, 0);
            this.GLD.Name = "GLD";
            this.GLD.Size = new System.Drawing.Size(581, 347);
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.HealthPanel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
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
            this.WeaponLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.WeaponLabel.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeaponLabel.ForeColor = System.Drawing.Color.White;
            this.WeaponLabel.Location = new System.Drawing.Point(12, 45);
            this.WeaponLabel.Name = "WeaponLabel";
            this.WeaponLabel.Size = new System.Drawing.Size(125, 37);
            this.WeaponLabel.TabIndex = 2;
            this.WeaponLabel.Text = "label1";
            // 
            // EnemyLabel
            // 
            this.EnemyLabel.AutoSize = true;
            this.EnemyLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.EnemyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyLabel.ForeColor = System.Drawing.Color.White;
            this.EnemyLabel.Location = new System.Drawing.Point(12, 82);
            this.EnemyLabel.Name = "EnemyLabel";
            this.EnemyLabel.Size = new System.Drawing.Size(88, 20);
            this.EnemyLabel.TabIndex = 3;
            this.EnemyLabel.Text = "Enemies: ";
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 347);
            this.Controls.Add(this.EnemyLabel);
            this.Controls.Add(this.WeaponLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GLD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DrawForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl GLD;
        private System.Windows.Forms.Timer Time;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel HealthPanel;
        private System.Windows.Forms.Label WeaponLabel;
        private System.Windows.Forms.Label EnemyLabel;
    }
}

