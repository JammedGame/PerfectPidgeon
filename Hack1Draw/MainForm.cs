using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PerfectPidgeon.Draw
{
    public partial class MainForm : Form
    {
        public delegate void LevelInit(string LevelID);
        public event LevelInit LevelStart;
        public event LevelInit LevelContinue;
        public MainForm()
        {
            InitializeComponent();
            this.Picker.SetMainForm(this);
            this.LevelStart = new LevelInit(OnLevelStart);
            this.LevelContinue = new LevelInit(OnLevelContinue);
        }
        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void LevelChosen(string LevelID)
        {
            this.LevelStart.Invoke(LevelID);
        }
        private void OnLevelStart(string LevelID)
        {

        }
        private void OnLevelContinue(string LevelID)
        {

        }
        private void Level_Click(object sender, EventArgs e)
        {
            this.Picker.Visible = true;
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            this.LevelContinue.Invoke("");
        }
    }
}
