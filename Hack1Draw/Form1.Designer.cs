﻿namespace PerfectPidgeon.Draw
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.HealthPanel);
            this.panel1.Location = new System.Drawing.Point(19, 71);
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
            this.WeaponLabel.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeaponLabel.ForeColor = System.Drawing.Color.Black;
            this.WeaponLabel.Location = new System.Drawing.Point(12, 11);
            this.WeaponLabel.Name = "WeaponLabel";
            this.WeaponLabel.Size = new System.Drawing.Size(125, 37);
            this.WeaponLabel.TabIndex = 2;
            this.WeaponLabel.Text = "label1";
            // 
            // EnemyLabel
            // 
            this.EnemyLabel.AutoSize = true;
            this.EnemyLabel.BackColor = System.Drawing.Color.Transparent;
            this.EnemyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyLabel.ForeColor = System.Drawing.Color.Black;
            this.EnemyLabel.Location = new System.Drawing.Point(15, 48);
            this.EnemyLabel.Name = "EnemyLabel";
            this.EnemyLabel.Size = new System.Drawing.Size(88, 20);
            this.EnemyLabel.TabIndex = 3;
            this.EnemyLabel.Text = "Enemies: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.EnemyLabel);
            this.panel2.Controls.Add(this.WeaponLabel);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(510, 116);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Consolas", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(243, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 114);
            this.label1.TabIndex = 4;
            this.label1.Text = "1-1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 347);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.GLD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DrawForm";
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
        private System.Windows.Forms.Label EnemyLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}

