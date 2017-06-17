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
        public static Cinematic Singleton;
        public static Dictionary<string, Video> BasePoolData;
        private int _Index;
        private Video _Video;
        private Form _ReturnForm;
        public Cinematic()
        {
            _Index = 0;
            VideoImageData.Init();
            InitializeComponent();
            Singleton = this;
        }
        public void SetReturnForm(Form ReturnForm)
        {
            this._ReturnForm = ReturnForm;
        }
        public void SetCinematic(Video NewVideo)
        {
            this._Index = -1;
            this._Video = NewVideo;
            this.ForwardFrame();
        }
        public void SetCinematic(string NewVideo)
        {
            this._Index = -1;
            this._Video = Cinematic.BasePoolData[NewVideo];
            this.ForwardFrame();
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            this.ForwardFrame();
        }
        private void ForwardFrame()
        {
            this._Index++;
            if (this._Index == this._Video.Entries.Count)
            {
                FinishCinematic();
            }
            else
            {
                TextLabel.Text = this._Video.Entries[_Index].Text;
                CinematicImage.BackgroundImage = VideoImageData._VideoImages[this._Video.Entries[_Index].Image];
            }
        }
        private void FinishCinematic()
        {
            _ReturnForm.Tag = _Video.ReturnArgument;
            this.Hide();
            _ReturnForm.Show();
            
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
        private string _ReturnArgument;
        private List<VideoEntry> _Entries;
        public string ReturnArgument { get => _ReturnArgument; set => _ReturnArgument = value; }
        public List<VideoEntry> Entries { get => _Entries; set => _Entries = value; }
        public Video()
        {
            this._Entries = new List<VideoEntry>();
        }
    }
    public class VideoEntry
    {
        private string _Text;
        private string _Image;
        public string Text { get => _Text; set => _Text = value; }
        public string Image { get => _Image; set => _Image = value; }
        public VideoEntry(string Text, string Image)
        {
            this._Text = Text;
            this._Image = Image;
        }
    }
    public class VideoImageData
    {
        public static Dictionary<string, Bitmap> _VideoImages;
        public static void Init()
        {
            _VideoImages = new Dictionary<string, Bitmap>();
            _VideoImages.Add("cin00_00", PerfectPidgeon.Draw.Properties.Resources.cin00_00);
            _VideoImages.Add("cin00_01", PerfectPidgeon.Draw.Properties.Resources.cin00_01);
            _VideoImages.Add("cin00_02", PerfectPidgeon.Draw.Properties.Resources.cin00_02);
            _VideoImages.Add("cin00_03", PerfectPidgeon.Draw.Properties.Resources.cin00_03);
            _VideoImages.Add("cin00_04", PerfectPidgeon.Draw.Properties.Resources.cin00_04);
            _VideoImages.Add("cin00_05", PerfectPidgeon.Draw.Properties.Resources.cin00_05);
            _VideoImages.Add("cin00_06", PerfectPidgeon.Draw.Properties.Resources.cin00_06);
            _VideoImages.Add("cin02_00", PerfectPidgeon.Draw.Properties.Resources.cin02_00);
            _VideoImages.Add("cin02_01", PerfectPidgeon.Draw.Properties.Resources.cin02_01);
            _VideoImages.Add("cin02_02", PerfectPidgeon.Draw.Properties.Resources.cin02_02);
            _VideoImages.Add("cin02_03", PerfectPidgeon.Draw.Properties.Resources.cin02_03);
            _VideoImages.Add("cin02_04", PerfectPidgeon.Draw.Properties.Resources.cin02_04);
            _VideoImages.Add("cin02_05", PerfectPidgeon.Draw.Properties.Resources.cin02_05);
        }
    }
}
