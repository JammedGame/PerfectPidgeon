namespace PerfectPidgeon.Draw
{
    partial class Settings
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
            this.Options = new System.Windows.Forms.Panel();
            this.Back = new System.Windows.Forms.Button();
            this.Bouncer2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Level = new System.Windows.Forms.Button();
            this.Graphics = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Options.SuspendLayout();
            this.Graphics.SuspendLayout();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.Back);
            this.Options.Controls.Add(this.Bouncer2);
            this.Options.Controls.Add(this.button1);
            this.Options.Controls.Add(this.Level);
            this.Options.Dock = System.Windows.Forms.DockStyle.Left;
            this.Options.Location = new System.Drawing.Point(0, 0);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(190, 600);
            this.Options.TabIndex = 5;
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Back.FlatAppearance.BorderSize = 0;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.Location = new System.Drawing.Point(0, 469);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(190, 75);
            this.Back.TabIndex = 5;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Bouncer2
            // 
            this.Bouncer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bouncer2.Location = new System.Drawing.Point(0, 544);
            this.Bouncer2.Name = "Bouncer2";
            this.Bouncer2.Size = new System.Drawing.Size(190, 56);
            this.Bouncer2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 75);
            this.button1.TabIndex = 2;
            this.button1.Text = "Audio";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Level
            // 
            this.Level.BackColor = System.Drawing.Color.Transparent;
            this.Level.FlatAppearance.BorderSize = 0;
            this.Level.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Level.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.Location = new System.Drawing.Point(3, 3);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(181, 75);
            this.Level.TabIndex = 1;
            this.Level.Text = "Graphics";
            this.Level.UseVisualStyleBackColor = false;
            // 
            // Graphics
            // 
            this.Graphics.AutoSize = true;
            this.Graphics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Graphics.Controls.Add(this.comboBox2);
            this.Graphics.Controls.Add(this.label2);
            this.Graphics.Controls.Add(this.label1);
            this.Graphics.Controls.Add(this.comboBox1);
            this.Graphics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graphics.Location = new System.Drawing.Point(190, 0);
            this.Graphics.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.Graphics.Name = "Graphics";
            this.Graphics.Size = new System.Drawing.Size(610, 600);
            this.Graphics.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Auto",
            "800x600",
            "1024x768",
            "1200x600",
            "1366x768",
            "1920x1080"});
            this.comboBox1.Location = new System.Drawing.Point(303, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(254, 38);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Auto";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Resolution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Window";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Windowed",
            "Windowed Fullscreen"});
            this.comboBox2.Location = new System.Drawing.Point(303, 78);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(254, 38);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.Text = "Windowed Fullscreen";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Graphics);
            this.Controls.Add(this.Options);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(800, 600);
            this.Options.ResumeLayout(false);
            this.Graphics.ResumeLayout(false);
            this.Graphics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Options;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Panel Bouncer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Level;
        private System.Windows.Forms.Panel Graphics;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
