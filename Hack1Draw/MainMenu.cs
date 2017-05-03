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
    public partial class MainMenu : UserControl
    {
        public delegate void MenuItemChosen(MenuItem Item);
        public event MenuItemChosen Choice;
        public MainMenu()
        {
            InitializeComponent();
            Choice = new MenuItemChosen(OnChoice);
        }
        private void MainMenu_Resize(object sender, EventArgs e)
        {
            this.LeftPanel.Size = new Size(this.Width / 2, this.LeftPanel.Height);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void OnChoice(MenuItem Item)
        {
            
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            Choice.Invoke(MenuItem.Continue);
        }

        private void Level_Click(object sender, EventArgs e)
        {
            Choice.Invoke(MenuItem.Level);
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Choice.Invoke(MenuItem.Settings);
        }
    }
    public enum MenuItem
    {
        Continue,
        Level,
        Settings
    }
}
