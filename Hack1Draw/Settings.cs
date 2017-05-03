using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PerfectPidgeon.Draw
{
    public partial class Settings : UserControl
    {
        public delegate void SettingsUpdate();
        public event SettingsUpdate Update;
        public SettingsData Data;
        public Settings()
        {
            InitializeComponent();
            this.Update = new SettingsUpdate(OnUpdate);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0) Data.Fullscreen = false;
            else Data.Fullscreen = true;
            this.Update.Invoke();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) Data.Resolution = new Point(1920, 1080);
            else if (comboBox1.SelectedIndex == 1) Data.Resolution = new Point(800, 600);
            else if (comboBox1.SelectedIndex == 2) Data.Resolution = new Point(1024, 768);
            else if (comboBox1.SelectedIndex == 3) Data.Resolution = new Point(1200, 600);
            else if (comboBox1.SelectedIndex == 4) Data.Resolution = new Point(1366, 768);
            else if (comboBox1.SelectedIndex == 5) Data.Resolution = new Point(1920, 1080);
            this.Update.Invoke();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void OnUpdate()
        {

        }
    }
}
