using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PerfectPidgeon.Draw.BackgroundGenerator
{
    public class TiledBackgroundGenerator
    {
        public static Bitmap Generate(List<TileGroup> Groups, int TileSize, Point TileRes, Point ImgRes)
        {
            Bitmap B = new Bitmap(ImgRes.X, ImgRes.Y);
            Groups.Sort(delegate (TileGroup X, TileGroup Y)
            {
                if (X.TileSize > Y.TileSize) return 1;
                else if (X.TileSize < Y.TileSize) return -1;
                else return 0;
            });
            int[,] Matrix = new int[TileRes.X, TileRes.Y]; 
            for(int i = 0; i < Groups.Count; i++)
            {
                TiledBackgroundGenerator.CompleteGroup(ref Matrix, TileSize, ref B, TileRes, Groups[i]);
            }
            return B;
        }
        private static void CompleteGroup(ref int[,] Matrix, int TileSize, ref Bitmap B, Point TileRes, TileGroup Group)
        {
            Random Rand = new Random();
            while (Group.Amount > 0)
            {
                List<Point> Available = new List<Point>();
                for (int i = 0; i < TileRes.X - Group.TileSize + 1; i++)
                {
                    for (int j = 0; j < TileRes.Y - Group.TileSize + 1; j++)
                    {
                        bool Free = true;
                        for (int k = i; k < i + Group.TileSize; k++)
                        {
                            for (int l = j; l < j + Group.TileSize; l++)
                            {
                                if (Matrix[k, l] == 1) Free = false;
                            }
                        }
                        if(Free) Available.Add(new Point(i, j));
                    }
                }
                if(Available.Count == 0)
                {
                    break;
                }
                int Chosen = Rand.Next(0, Available.Count - 1);
                for(int i = Available[Chosen].X; i < Available[Chosen].X + Group.TileSize; i++)
                {
                    for (int j = Available[Chosen].Y; j < Available[Chosen].Y + Group.TileSize; j++)
                    {
                        Matrix[i, j] = 1;
                    }
                }
                int ChosenImg = Rand.Next(0, Group.Images.Count - 1);
                TiledBackgroundGenerator.DrawImage(ref B, Group.Images[ChosenImg], new Point(Available[Chosen].X * TileSize, Available[Chosen].Y * TileSize), TileSize * Group.TileSize);
                Group.Amount--;
            }
        }
        private static void DrawImage(ref Bitmap B, Bitmap TileImage, Point DrawPoint, int Size)
        {
            Graphics G = Graphics.FromImage(B);
            G.DrawImage(TileImage, DrawPoint.X, DrawPoint.Y, Size, Size);
            G.Dispose();
        }
    }
}
