using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PerfectPidgeon.Draw
{
    public class ArtData
    {
        public ArtData()
        {
            InitializeSpriteSets();
            InitializeTileSets();
        }
        public int BackType = 0;
        public Color Environment = Color.White;
        public Bitmap Aim = global::PerfectPidgeon.Draw.Properties.Resources.aim;
        public Bitmap Back = global::PerfectPidgeon.Draw.Properties.Resources.earth;
        public List<SpriteSet> SpriteSets;
        public List<Bitmap> Tile1;
        public List<Bitmap> Tile2;
        public List<Bitmap> Tile3;
        public List<Bitmap> Tile4;
        public List<Bitmap> EffectArt;
        public List<Bitmap> PowerUpArt;
        public List<SpriteSet> Bullets;
        private void InitializeSpriteSets()
        {
            Bitmap[] SpriteSetImages;
            SpriteSets = new List<SpriteSet>();
            SpriteSetImages = new Bitmap[3];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.pig1;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.pig2;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.pig3;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));
            SpriteSetImages = new Bitmap[4];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.gun_def;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.gun_hev;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.gun_las;
            SpriteSetImages[3] = global::PerfectPidgeon.Draw.Properties.Resources.gun_pla;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 4));
            SpriteSetImages = new Bitmap[3];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm1_1;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.enm1_2;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.enm1_3;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));

            Bullets = new List<SpriteSet>();
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.met1;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.met1;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.bul_las;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.bul_pla;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.bul_pla;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
        }
        private void InitializeTileSets()
        {
            Tile1 = new List<Bitmap>();
            Tile1.Add(global::PerfectPidgeon.Draw.Properties.Resources.z0);
            Tile1.Add(global::PerfectPidgeon.Draw.Properties.Resources.z1);
            Tile1.Add(global::PerfectPidgeon.Draw.Properties.Resources.z2);
            Tile1.Add(global::PerfectPidgeon.Draw.Properties.Resources.z3);
            Tile2 = new List<Bitmap>();
            Tile2.Add(global::PerfectPidgeon.Draw.Properties.Resources.z_0);
            Tile2.Add(global::PerfectPidgeon.Draw.Properties.Resources.z_1);
            Tile2.Add(global::PerfectPidgeon.Draw.Properties.Resources.z_2);
            Tile3 = new List<Bitmap>();
            Tile3.Add(global::PerfectPidgeon.Draw.Properties.Resources.z__0);
            Tile4 = new List<Bitmap>();
            Tile4.Add(global::PerfectPidgeon.Draw.Properties.Resources.z___0);
            EffectArt = new List<Bitmap>();
            EffectArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.bum);
            EffectArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.boom1);
            PowerUpArt = new List<Bitmap>();
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Health);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Speed);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Plasma);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Laser);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Heavy);
        }
        public void GenerateTiles(int numTilesH, int numTilesV)
        {
            /*this.numTilesH = numTilesH;
            this.numTilesV = numTilesV;

            int numTiles = numTilesH * numTilesV;

            tiles = new List<Tile>();

            t = new int[numTiles];

            for (int i = 0; i < numTiles; ++i)
                t[i] = 0;

            int numQuadTiles = numTiles / 3 / 16;
            int numTriTiles = (numTiles - numQuadTiles * 16) / 2 / 9;
            int numDuoTiles = (numTiles - numQuadTiles * 16 - numTriTiles * 9) / 2 / 4;

            Random random = new Random();
            int numQuads = 0, numTris = 0, numDuos = 0;

            while (true)
            {
                int index;

                if (numQuads != -1)
                {
                    index = FindEmptyTile(4, numTiles);

                    if (index != -1)
                    {
                        Tile tajlo = new Tile();
                        tajlo.position = index;
                        tajlo.size = 4;
                        tajlo.ArtIndex = random.Next(0, Tile4.Count);
                        tiles.Add(tajlo);

                        for (int i = index; i < index + 4; ++i)
                            for (int j = 0; j < 4; ++j)
                                t[i + numTilesH * j] = 1;

                        numQuads++;

                        if (numQuads >= numQuadTiles)
                            numQuads = -1;
                    }
                    else
                        numQuads = -1;
                }

                if (numTris != -1)
                {
                    index = FindEmptyTile(3, numTiles);

                    if (index != -1)
                    {
                        Tile tajlo = new Tile();
                        tajlo.position = index;
                        tajlo.size = 3;
                        tajlo.ArtIndex = random.Next(0, Tile3.Count);
                        tiles.Add(tajlo);

                        for (int i = index; i < index + 3; ++i)
                            for (int j = 0; j < 3; ++j)
                                t[i + numTilesH * j] = 1;

                        numTris++;

                        if (numTris >= numTriTiles)
                            numTris = -1;
                    }
                    else
                        numTris = -1;
                }


                if (numDuos != -1)
                {
                    index = FindEmptyTile(2, numTiles);

                    if (index != -1)
                    {
                        Tile tajlo = new Tile();
                        tajlo.position = index;
                        tajlo.size = 2;
                        tajlo.ArtIndex = random.Next(0, Tile2.Count);
                        tiles.Add(tajlo);

                        for (int i = index; i < index + 2; ++i)
                            for (int j = 0; j < 2; ++j)
                                t[i + numTilesH * j] = 1;

                        numDuos++;

                        if (numDuos >= numDuoTiles)
                            numDuos = -1;
                    }
                    else
                        numDuos = -1;
                }

                if (numQuads == -1 && numTris == -1 && numDuos == -1)
                    break;
            }

            for (int i = 0; i < numTiles; ++i)
            {
                if (t[i] == 0)
                {
                    Tile tajlo = new Tile();
                    tajlo.position = i;
                    tajlo.size = 1;
                    tajlo.ArtIndex = random.Next(0, Tile1.Count);
                    tiles.Add(tajlo);
                    t[i] = 1;
                }
            }*/
        }
        public int FindEmptyTile(int size, int numTiles)
        {
            /* Random random = new Random();

             int index = random.Next(numTiles);
             int newIndex = index;

             bool occupied;

             while (true)
             {
                 occupied = false;

                 if (newIndex + size >= (newIndex / numTilesH) * numTilesH + numTilesH)
                     newIndex = (newIndex / numTilesH) * numTilesH + numTilesH;

                 for (int i = newIndex; i < newIndex + size; ++i)
                 {
                     bool impossibru = false;

                     for (int j = 0; j < size; ++j)
                     {
                         int ind = i + numTilesH * j;

                         if (ind >= numTiles)
                         {
                             occupied = true;
                             impossibru = true;
                             break;
                         }

                         if (t[ind] == 1)
                         {
                             occupied = true;
                             break;
                         }
                     }

                     if (impossibru)
                         break;
                 }

                 if (!occupied)
                     return newIndex;

                 newIndex++;

                 if (newIndex >= numTiles)
                     newIndex = 0;

                 if (newIndex == index)
                     break;
             }*/

            return -1;
        }
    }
}
