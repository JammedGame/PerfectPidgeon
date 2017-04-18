using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PerfectPidgeon.Draw.BackgroundGenerator
{
    public class TileGroup
    {
        public int TileSize;
        public int Amount;
        public List<Bitmap> Images;
        public TileGroup(int TileSize, int Amount, List<Bitmap> Images)
        {
            this.TileSize = TileSize;
            this.Amount = Amount;
            this.Images = Images;
        }
    }
}
