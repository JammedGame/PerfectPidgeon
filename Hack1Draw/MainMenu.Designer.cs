namespace PerfectPidgeon.Draw
{
    partial class MainMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainTitle = new System.Windows.Forms.Label();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.Options = new System.Windows.Forms.Panel();
            this.Continue = new System.Windows.Forms.Button();
            this.Bouncer1 = new System.Windows.Forms.Panel();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.News = new System.Windows.Forms.WebBrowser();
            this.Level = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.Bouncer2 = new System.Windows.Forms.Panel();
            this.Quit = new System.Windows.Forms.Button();
            this.LeftPanel.SuspendLayout();
            this.Options.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTitle
            // 
            this.MainTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTitle.Location = new System.Drawing.Point(0, 0);
            this.MainTitle.Name = "MainTitle";
            this.MainTitle.Size = new System.Drawing.Size(800, 149);
            this.MainTitle.TabIndex = 0;
            this.MainTitle.Text = "Perfect Pigeon";
            this.MainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.Options);
            this.LeftPanel.Controls.Add(this.Bouncer1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 149);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(397, 451);
            this.LeftPanel.TabIndex = 1;
            // 
            // Options
            // 
            this.Options.Controls.Add(this.Quit);
            this.Options.Controls.Add(this.Bouncer2);
            this.Options.Controls.Add(this.Settings);
            this.Options.Controls.Add(this.Level);
            this.Options.Controls.Add(this.Continue);
            this.Options.Dock = System.Windows.Forms.DockStyle.Right;
            this.Options.Location = new System.Drawing.Point(132, 0);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(190, 451);
            this.Options.TabIndex = 4;
            // 
            // Continue
            // 
            this.Continue.BackColor = System.Drawing.Color.Transparent;
            this.Continue.FlatAppearance.BorderSize = 2;
            this.Continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Continue.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue.Location = new System.Drawing.Point(3, 3);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(181, 75);
            this.Continue.TabIndex = 0;
            this.Continue.Text = "Continue";
            this.Continue.UseVisualStyleBackColor = false;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // Bouncer1
            // 
            this.Bouncer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Bouncer1.Location = new System.Drawing.Point(322, 0);
            this.Bouncer1.Name = "Bouncer1";
            this.Bouncer1.Size = new System.Drawing.Size(75, 451);
            this.Bouncer1.TabIndex = 3;
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.News);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(397, 149);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(403, 451);
            this.RightPanel.TabIndex = 2;
            // 
            // News
            // 
            this.News.Dock = System.Windows.Forms.DockStyle.Fill;
            this.News.Location = new System.Drawing.Point(0, 0);
            this.News.MinimumSize = new System.Drawing.Size(20, 20);
            this.News.Name = "News";
            this.News.Size = new System.Drawing.Size(403, 451);
            this.News.TabIndex = 0;
            this.News.Url = new System.Uri("http://www.deinvented.com/", System.UriKind.Absolute);
            // 
            // Level
            // 
            this.Level.BackColor = System.Drawing.Color.Transparent;
            this.Level.FlatAppearance.BorderSize = 2;
            this.Level.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Level.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.Location = new System.Drawing.Point(3, 94);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(181, 75);
            this.Level.TabIndex = 1;
            this.Level.Text = "Level";
            this.Level.UseVisualStyleBackColor = false;
            this.Level.Click += new System.EventHandler(this.Level_Click);
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.Transparent;
            this.Settings.FlatAppearance.BorderSize = 2;
            this.Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Settings.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings.Location = new System.Drawing.Point(3, 187);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(181, 75);
            this.Settings.TabIndex = 2;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Bouncer2
            // 
            this.Bouncer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bouncer2.Location = new System.Drawing.Point(0, 395);
            this.Bouncer2.Name = "Bouncer2";
            this.Bouncer2.Size = new System.Drawing.Size(190, 56);
            this.Bouncer2.TabIndex = 4;
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.Transparent;
            this.Quit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Quit.FlatAppearance.BorderSize = 2;
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quit.Location = new System.Drawing.Point(0, 320);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(190, 75);
            this.Quit.TabIndex = 5;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.MainTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(800, 600);
            this.Resize += new System.EventHandler(this.MainMenu_Resize);
            this.LeftPanel.ResumeLayout(false);
            this.Options.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MainTitle;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Panel Options;
        private System.Windows.Forms.Panel Bouncer1;
        private System.Windows.Forms.WebBrowser News;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Panel Bouncer2;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button Level;
    }
}
