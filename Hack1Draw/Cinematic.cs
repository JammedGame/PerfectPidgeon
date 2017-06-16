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
    public partial class Cinematic : Form
    {
        private int _Index;
        private MainForm _Main;
        private string[] _CinematicTexts;
        private Bitmap[] _CinematicImages;
        public Cinematic()
        {
            _Index = 0;
            InitializeComponent();
            this._CinematicTexts = new string[8];
            this._CinematicTexts[0] = "Aliens are attacking..";
            this._CinematicTexts[1] = "World leaders don't have a solution.";
            this._CinematicTexts[2] = "But someone sure does..";
            this._CinematicTexts[3] = "Gen. Hard: \"Dr. Insane, aliens are attacking.\"";
            this._CinematicTexts[4] = "Gen. Hard: \"We need a perfect widget!\"";
            this._CinematicTexts[5] = "Dr. Insane: \"You need WHAT?!\"";
            this._CinematicTexts[6] = "Gen. Hard: \"A PERFECT WIDGET!!\"";
            this._CinematicTexts[7] = "Dr. Insane: \"Perfect Pidgeon, I'm on it.\"";
            this._CinematicImages = new Bitmap[8];
            this._CinematicImages[0] = PerfectPidgeon.Draw.Properties.Resources.cin00_00;
            this._CinematicImages[1] = PerfectPidgeon.Draw.Properties.Resources.cin00_01;
            this._CinematicImages[2] = PerfectPidgeon.Draw.Properties.Resources.cin00_02;
            this._CinematicImages[3] = PerfectPidgeon.Draw.Properties.Resources.cin00_03;
            this._CinematicImages[4] = PerfectPidgeon.Draw.Properties.Resources.cin00_03;
            this._CinematicImages[5] = PerfectPidgeon.Draw.Properties.Resources.cin00_04;
            this._CinematicImages[6] = PerfectPidgeon.Draw.Properties.Resources.cin00_05;
            this._CinematicImages[7] = PerfectPidgeon.Draw.Properties.Resources.cin00_06;
        }
        public void SetMainForm(MainForm Main)
        {
            this._Main = Main;
        }
        public void Play(string CinematicID)
        {

        }
        private void Continue_Click(object sender, EventArgs e)
        {
            this._Index++;
            if (this._Index == 8)
            {
                FinishCinematic();
            }
            else
            {
                TextLabel.Text = this._CinematicTexts[_Index];
                CinematicImage.BackgroundImage = this._CinematicImages[_Index];
            }
        }
        private void FinishCinematic()
        {
            _Main.Show();
            this.Hide();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                FinishCinematic();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
    public class Video
    {
        private List<VideoEntry> _Entries;
        public List<VideoEntry> Entries { get => _Entries; set => _Entries = value; }
        public Video()
        {
            this._Entries = new List<VideoEntry>();
        }
    }
    public class VideoEntry
    {
        private string _Text;
        private Bitmap _Image;
        public string Text { get => _Text; set => _Text = value; }
        public Bitmap Image { get => _Image; set => _Image = value; }
        public VideoEntry(string Text, Bitmap Image)
        {
            this._Text = Text;
            this._Image = Image;
        }
    }
}
