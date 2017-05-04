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
    public partial class LevelPicker : UserControl
    {
        private MainForm _MForm;
        public LevelPicker()
        {
            InitializeComponent();
        }
        public void SetMainForm(MainForm MForm)
        {
            this._MForm = MForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void Level_Click(object sender, EventArgs e)
        {
            Button B = sender as Button;
            this.Visible = false;
            this._MForm.LevelChosen(B.Tag.ToString());
        }
    }
}
