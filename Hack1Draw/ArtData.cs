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
            InitializeTileSets()
        }
        public Color Environment = Color.White;
        public Bitmap Aim = global::PerfectPidgeon.Draw.Properties.Resources.aim;
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
            SpriteSetImages = new Bitmap[6];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.gohlub1;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.gohlub2;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.gohlub3;
            SpriteSetImages[3] = global::PerfectPidgeon.Draw.Properties.Resources.gohlub4;
            SpriteSetImages[4] = global::PerfectPidgeon.Draw.Properties.Resources.gohlub3;
            SpriteSetImages[5] = global::PerfectPidgeon.Draw.Properties.Resources.gohlub2;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 6));
            SpriteSetImages = new Bitmap[4];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.bad1;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.bad2;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.bad3;
            SpriteSetImages[3] = global::PerfectPidgeon.Draw.Properties.Resources.bad4;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 4));

            Bullets = new List<SpriteSet>();
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.met1;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.met1;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.lazer;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.pew1;
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
            EffectArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.boom);
            PowerUpArt = new List<Bitmap>();
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Health);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Speed);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Plasma);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Laser);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Heavy);
        }
    }
}
