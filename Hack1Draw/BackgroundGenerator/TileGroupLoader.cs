using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace PerfectPidgeon.Draw.BackgroundGenerator
{
    public class TileGroupLoader
    {
        public static List<TileGroup> Load(string Path)
        {
            if (!Directory.Exists(Path)) return null;

            List<TileGroup> Groups = new List<TileGroup>();

            for (int i = 0; i < 10; i++)
            {
                List<Bitmap> Images = new List<Bitmap>();
                for(int j = 0; j < 10; j++)
                {
                    string FileName = Path + "\\" + (i+1) + "_" + (j+1) + ".png";
                    if (!File.Exists(FileName)) break;
                    Images.Add((Bitmap)Bitmap.FromFile(FileName));
                }
                if (Images.Count > 0) Groups.Add(new TileGroup(i+1, 0, Images));
            }

            return Groups;
        }
    }
}
