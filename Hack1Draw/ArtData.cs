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
        public Bitmap Back = global::PerfectPidgeon.Draw.Properties.Resources.earth1;
        public Bitmap Clouds = global::PerfectPidgeon.Draw.Properties.Resources.clouds3;
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
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.pig01;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.pig02;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.pig03;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));
            SpriteSetImages = new Bitmap[5];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.gun_def;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.gun_hev;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.gun_las;
            SpriteSetImages[3] = global::PerfectPidgeon.Draw.Properties.Resources.gun_pla;
            SpriteSetImages[4] = global::PerfectPidgeon.Draw.Properties.Resources.gun_stand;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 5));
            SpriteSetImages = new Bitmap[3];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm1_1;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.enm1_2;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.enm1_3;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));
            SpriteSetImages = new Bitmap[3];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm2_1;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.enm2_2;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.enm2_3;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));
            SpriteSetImages = new Bitmap[3];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm3_1;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.enm3_2;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.enm3_3;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));
            SpriteSetImages = new Bitmap[3];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm4_1;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.enm4_2;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.enm4_3;
            //SpriteSetImages[3] = global::PerfectPidgeon.Draw.Properties.Resources.enm4_4;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));
            SpriteSetImages = new Bitmap[3];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm5_1;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.enm5_2;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.enm5_3;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));
            SpriteSetImages = new Bitmap[3];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm6_1;
            SpriteSetImages[1] = global::PerfectPidgeon.Draw.Properties.Resources.enm6_2;
            SpriteSetImages[2] = global::PerfectPidgeon.Draw.Properties.Resources.enm6_3;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm7_1;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm8_1;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[3];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm9_1;
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm9_2;
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm9_3;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm10_1;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[3];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm11_1;
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm11_2;
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm11_3;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 3));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.enm12_1;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 1));

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
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.bul_pla;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.bul_pla;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.bul_pla;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.bul_pla;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.bul_pla;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));

            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.pewf;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.pewf;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.beam2;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.mine;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.minef1;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.pewf;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::PerfectPidgeon.Draw.Properties.Resources.arrow;
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
            EffectArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.boom4);
            PowerUpArt = new List<Bitmap>();
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Health);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Speed);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Heavy);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Laser);
            PowerUpArt.Add(global::PerfectPidgeon.Draw.Properties.Resources.Plasma);
        }
        public void SetBackground(string Path)
        {
            if(Path == "Earth") Back = global::PerfectPidgeon.Draw.Properties.Resources.earth1;
        }
    }
}
