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

        private void LevelPicker_Resize(object sender, EventArgs e)
        {
            Container1.Size = new Size((this.Width - 40) / 5, Container1.Height);
            Container2.Size = new Size((this.Width - 40) / 5, Container2.Height);
            Container3.Size = new Size((this.Width - 40) / 5, Container3.Height);
        }
    }
}
