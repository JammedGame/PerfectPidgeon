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
    public partial class TestLevelPicker : UserControl
    {
        private MainForm _MForm;
        public TestLevelPicker()
        {
            InitializeComponent();
        }
        public void SetMainForm(MainForm MForm)
        {
            this._MForm = MForm;
        }
        private void Level_Click(object sender, EventArgs e)
        {
            PictureBox B = sender as PictureBox;
            this.Visible = false;
            this._MForm.LevelChosen(B.Tag.ToString());
        }
        private void LevelPicker_Resize(object sender, EventArgs e)
        {
            Container1.Size = new Size((this.Width - 100) / 5, Container1.Height);
            Container2.Size = new Size((this.Width - 100) / 5, Container2.Height);
            Container3.Size = new Size((this.Width - 100) / 5, Container3.Height);
        }
    }
}
