using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeon.Draw
{
    public class SpriteSet
    {
        private Bitmap[] _Images;
        private int _AngleOffset;
        public Bitmap[] Images
        {
            get { return _Images; }
            set { _Images = value; }
        }
        public int AngleOffset
        {
            get { return _AngleOffset; }
            set { _AngleOffset = value; }
        }
        public SpriteSet(Bitmap[] Images, int AngleOffset)
        {
            this.Images = Images;
            this.AngleOffset = AngleOffset;
        }
    }
}
