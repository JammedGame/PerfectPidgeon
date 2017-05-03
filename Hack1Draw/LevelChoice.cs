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
    public partial class LevelChoice : UserControl
    {
        public delegate void LevelChosen(string Name);
        public event LevelChosen Choice;
        public LevelChoice()
        {
            InitializeComponent();
            this.Choice = new LevelChosen(OnChoice);
        }
        private void OnChoice(string Choice)
        {

        }
        private void LV01_Click(object sender, EventArgs e)
        {
            Button B = sender as Button;
            Choice.Invoke(B.Tag.ToString());
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
