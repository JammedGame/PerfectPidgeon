namespace PerfectPidgeon.Draw
{
    partial class MainForm
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
            this.Continue = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.Level = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.PigeonArt = new System.Windows.Forms.PictureBox();
            this.Picker = new PerfectPidgeon.Draw.LevelPicker();
            ((System.ComponentModel.ISupportInitialize)(this.PigeonArt)).BeginInit();
            this.SuspendLayout();
            // 
            // Continue
            // 
            this.Continue.BackColor = System.Drawing.Color.Gainsboro;
            this.Continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Continue.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue.Location = new System.Drawing.Point(548, 62);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(193, 52);
            this.Continue.TabIndex = 1;
            this.Continue.Text = "Continue";
            this.Continue.UseVisualStyleBackColor = false;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(485, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(315, 59);
            this.Title.TabIndex = 2;
            this.Title.Text = "Perfect Pigeon";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Level
            // 
            this.Level.BackColor = System.Drawing.Color.Gainsboro;
            this.Level.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Level.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.Location = new System.Drawing.Point(548, 120);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(193, 52);
            this.Level.TabIndex = 3;
            this.Level.Text = "Level";
            this.Level.UseVisualStyleBackColor = false;
            this.Level.Click += new System.EventHandler(this.Level_Click);
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.Gainsboro;
            this.Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Settings.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings.Location = new System.Drawing.Point(548, 178);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(193, 52);
            this.Settings.TabIndex = 4;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = false;
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.Gainsboro;
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quit.Location = new System.Drawing.Point(548, 258);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(193, 52);
            this.Quit.TabIndex = 5;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(523, 339);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(242, 240);
            this.webBrowser1.TabIndex = 6;
            this.webBrowser1.Url = new System.Uri("http://www.google.com", System.UriKind.Absolute);
            // 
            // PigeonArt
            // 
            this.PigeonArt.BackgroundImage = global::PerfectPidgeon.Draw.Properties.Resources.pidgeon;
            this.PigeonArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PigeonArt.Dock = System.Windows.Forms.DockStyle.Left;
            this.PigeonArt.Location = new System.Drawing.Point(0, 0);
            this.PigeonArt.Name = "PigeonArt";
            this.PigeonArt.Size = new System.Drawing.Size(485, 600);
            this.PigeonArt.TabIndex = 0;
            this.PigeonArt.TabStop = false;
            // 
            // Picker
            // 
            this.Picker.BackColor = System.Drawing.Color.White;
            this.Picker.Location = new System.Drawing.Point(0, 0);
            this.Picker.Name = "Picker";
            this.Picker.Size = new System.Drawing.Size(800, 600);
            this.Picker.TabIndex = 7;
            this.Picker.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Picker);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Level);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.PigeonArt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.PigeonArt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PigeonArt;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button Level;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private LevelPicker Picker;
    }
}