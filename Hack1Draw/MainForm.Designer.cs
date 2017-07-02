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
            this.Picker = new PerfectPidgeon.Draw.LevelPicker();
            this.TestPicker = new PerfectPidgeon.Draw.TestLevelPicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TestLevels = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.PictureBox();
            this.Continue = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.Level = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Picker
            // 
            this.Picker.BackColor = System.Drawing.Color.White;
            this.Picker.Location = new System.Drawing.Point(300, 58);
            this.Picker.Name = "Picker";
            this.Picker.Size = new System.Drawing.Size(482, 529);
            this.Picker.TabIndex = 12;
            this.Picker.Visible = false;
            // 
            // TestPicker
            // 
            this.TestPicker.Location = new System.Drawing.Point(300, 58);
            this.TestPicker.Name = "TestPicker";
            this.TestPicker.Size = new System.Drawing.Size(482, 530);
            this.TestPicker.TabIndex = 13;
            this.TestPicker.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 600);
            this.panel2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.TestLevels);
            this.panel1.Controls.Add(this.Quit);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.Continue);
            this.panel1.Controls.Add(this.Settings);
            this.panel1.Controls.Add(this.Level);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 600);
            this.panel1.TabIndex = 9;
            // 
            // TestLevels
            // 
            this.TestLevels.BackColor = System.Drawing.Color.Gainsboro;
            this.TestLevels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestLevels.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestLevels.Location = new System.Drawing.Point(0, 232);
            this.TestLevels.Name = "TestLevels";
            this.TestLevels.Size = new System.Drawing.Size(200, 52);
            this.TestLevels.TabIndex = 10;
            this.TestLevels.Text = "Test Levels";
            this.TestLevels.UseVisualStyleBackColor = false;
            this.TestLevels.Click += new System.EventHandler(this.TestLevels_Click);
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.Gainsboro;
            this.Quit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quit.Location = new System.Drawing.Point(0, 518);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(200, 52);
            this.Quit.TabIndex = 5;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 570);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 30);
            this.panel3.TabIndex = 9;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BackgroundImage = global::PerfectPidgeon.Draw.Properties.Resources.Perfectlogo;
            this.Title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(200, 52);
            this.Title.TabIndex = 8;
            this.Title.TabStop = false;
            // 
            // Continue
            // 
            this.Continue.BackColor = System.Drawing.Color.Gainsboro;
            this.Continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Continue.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue.Location = new System.Drawing.Point(0, 58);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(200, 52);
            this.Continue.TabIndex = 1;
            this.Continue.Text = "Continue";
            this.Continue.UseVisualStyleBackColor = false;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.Gainsboro;
            this.Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Settings.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings.Location = new System.Drawing.Point(0, 174);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(200, 52);
            this.Settings.TabIndex = 4;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = false;
            // 
            // Level
            // 
            this.Level.BackColor = System.Drawing.Color.Gainsboro;
            this.Level.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Level.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.Location = new System.Drawing.Point(0, 116);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(200, 52);
            this.Level.TabIndex = 3;
            this.Level.Text = "Level";
            this.Level.UseVisualStyleBackColor = false;
            this.Level.Click += new System.EventHandler(this.Level_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PerfectPidgeon.Draw.Properties.Resources.back;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.TestPicker);
            this.Controls.Add(this.Picker);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Button Level;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.PictureBox Title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LevelPicker Picker;
        private System.Windows.Forms.Button TestLevels;
        private TestLevelPicker TestPicker;
    }
}