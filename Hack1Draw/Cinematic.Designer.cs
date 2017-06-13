namespace PerfectPidgeon.Draw
{
    partial class Cinematic
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
            this.TextPanel = new System.Windows.Forms.Panel();
            this.TextLabel = new System.Windows.Forms.Label();
            this.Continue = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CinematicImage = new System.Windows.Forms.PictureBox();
            this.TextPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CinematicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // TextPanel
            // 
            this.TextPanel.BackColor = System.Drawing.Color.Black;
            this.TextPanel.Controls.Add(this.TextLabel);
            this.TextPanel.Controls.Add(this.Continue);
            this.TextPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextPanel.Location = new System.Drawing.Point(0, 325);
            this.TextPanel.Name = "TextPanel";
            this.TextPanel.Size = new System.Drawing.Size(564, 50);
            this.TextPanel.TabIndex = 0;
            // 
            // TextLabel
            // 
            this.TextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextLabel.ForeColor = System.Drawing.Color.White;
            this.TextLabel.Location = new System.Drawing.Point(0, 0);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(460, 50);
            this.TextLabel.TabIndex = 3;
            this.TextLabel.Text = "Aliens are attacking..";
            this.TextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Continue
            // 
            this.Continue.BackColor = System.Drawing.Color.Black;
            this.Continue.Dock = System.Windows.Forms.DockStyle.Right;
            this.Continue.FlatAppearance.BorderSize = 0;
            this.Continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Continue.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue.ForeColor = System.Drawing.Color.White;
            this.Continue.Location = new System.Drawing.Point(460, 0);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(104, 50);
            this.Continue.TabIndex = 2;
            this.Continue.Text = "Next >";
            this.Continue.UseVisualStyleBackColor = false;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 50);
            this.panel1.TabIndex = 4;
            // 
            // CinematicImage
            // 
            this.CinematicImage.BackgroundImage = global::PerfectPidgeon.Draw.Properties.Resources._19104794_1398751953541584_660140607_o;
            this.CinematicImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CinematicImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CinematicImage.Location = new System.Drawing.Point(0, 0);
            this.CinematicImage.Name = "CinematicImage";
            this.CinematicImage.Size = new System.Drawing.Size(564, 375);
            this.CinematicImage.TabIndex = 5;
            this.CinematicImage.TabStop = false;
            // 
            // Cinematic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(564, 375);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TextPanel);
            this.Controls.Add(this.CinematicImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Cinematic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cinematic";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TextPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CinematicImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TextPanel;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox CinematicImage;
    }
}