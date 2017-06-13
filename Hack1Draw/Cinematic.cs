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
            this._CinematicImages[0] = PerfectPidgeon.Draw.Properties.Resources._19104794_1398751953541584_660140607_o;
            this._CinematicImages[1] = PerfectPidgeon.Draw.Properties.Resources._19113314_1399676160115830_671902572_n;
            this._CinematicImages[2] = PerfectPidgeon.Draw.Properties.Resources._19113314_1399676160115830_671902572_n;
            this._CinematicImages[3] = PerfectPidgeon.Draw.Properties.Resources._19184004_1400613753355404_231690187_n;
            this._CinematicImages[4] = PerfectPidgeon.Draw.Properties.Resources._19184004_1400613753355404_231690187_n;
            this._CinematicImages[5] = PerfectPidgeon.Draw.Properties.Resources._19184004_1400613753355404_231690187_n;
            this._CinematicImages[6] = PerfectPidgeon.Draw.Properties.Resources._19184004_1400613753355404_231690187_n;
            this._CinematicImages[7] = PerfectPidgeon.Draw.Properties.Resources._19141513_1400613750022071_2009513361_n;
        }
        public void SetMainForm(MainForm Main)
        {
            this._Main = Main;
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            this._Index++;
            if (this._Index == 8)
            {
                _Main.Show();
                this.Hide();
            }
            else
            {
                TextLabel.Text = this._CinematicTexts[_Index];
                if (this._Index == 1 || this._Index == 3 || this._Index == 7) CinematicImage.BackgroundImage = this._CinematicImages[_Index];
            }
        }
    }
}
