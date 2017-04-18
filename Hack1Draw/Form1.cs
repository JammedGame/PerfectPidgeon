using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Leap;

namespace Hackaton_Trening_1
{
    public partial class DrawForm : Form
    {
        private int HealthIndex = 200;
        private string WeaponText = "Basic";

        public bool Working = false;
        private Color Environment = Color.White;
        private int CurrentPlayer = 0;
        private double MouseAngle;
        private List<Item> Players;
        private List<Item> NPCs;
        private List<Item> Projectiles;
        private List<Item> Effects;
        private List<Item> PowerUps;
        private List<Item> PlayersBuffer;
        private List<Item> NPCsBuffer;
        private List<Item> ProjectilesBuffer;
        private List<Item> EffectsBuffer;
        private List<Item> PowerUpsBuffer;
        private Point MouseLoc;
        public event MouseEventHandler MouseMoved;
        public event MouseEventHandler MouseUpP;
        public event MouseEventHandler MouseDownP;
        public delegate void KeyPressedDelegate(ref Message msg, Keys keyData);
        public event KeyPressedDelegate KeyPressed;
        private List<SpriteSet> SpriteSets;
        private List<Bitmap> Tile1;
        private List<Bitmap> Tile2;
        private List<Bitmap> Tile3;
        private List<Bitmap> Tile4;
        private List<Bitmap> EffectArt;
        private List<Bitmap> PowerUpArt;
        private List<SpriteSet> Bullets;
        private Bitmap Aim = global::Hack1Draw.Properties.Resources.aim;
        private System.Timers.Timer UpdateFrame;
        private System.Timers.Timer UpdateLeap;
        private System.Timers.Timer Killemll;
        private Point BackGroundOffset = new Point(0, 0);
        private int EfectOffset = 0;
        private bool GLLoaded;
        private int Texture;

        private const int numTileTries = 60;
        private const int tileSize = 200;
        private int numTilesH;
        private int numTilesV;
        private List<Tile> tiles;
        private int tileList;
        private int[] t;

        private PidgeonLeapListener Listen;
        private Controller Control;
        private bool LeapCheck = false;
        private bool LeftDown = false;
        private bool RightDown = false;

        public DrawForm()
        {
            Cursor.Hide();
            InitializeComponent();
            InitializeSpriteSets();
            InitializeTileSets();
            Players = new List<Item>();
            NPCs = new List<Item>();
            Projectiles = new List<Item>();;
            Effects = new List<Item>();
            PowerUps = new List<Item>();
            UpdateFrame = new System.Timers.Timer();
            UpdateFrame.Enabled = true;
            UpdateFrame.Elapsed += new System.Timers.ElapsedEventHandler(ImgSwitch_Tick);
            UpdateFrame.Interval = 100;
            UpdateFrame.Start();
            MouseMoved = new MouseEventHandler(OnMouseMoved);
            MouseUpP = new MouseEventHandler(OnMouseUp);
            MouseDownP = new MouseEventHandler(OnMouseDown);

            Listen = new PidgeonLeapListener();
            Control = new Controller();
            Control.AddListener(Listen);

            UpdateLeap = new System.Timers.Timer();
            UpdateLeap.Enabled = true;
            UpdateLeap.Elapsed += new System.Timers.ElapsedEventHandler(Leap_Tick);
            UpdateLeap.Interval = 30;
            UpdateLeap.Start();
        }
        private void Leap_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!Listen.Connected) return;
            bool LeftPress = Listen.LeftCollected;
            bool RightPress = Listen.RightCollected;
            Point Loc = new Point((int)(Listen.LeftHandLocation.X * 16 + this.Width * 1.3), (int)(-Listen.LeftHandLocation.Y * 16 + this.Height * 3));
            Point LocRot = new Point((int)(Listen.RightHandLocation.X * 16 + this.Width * 1.3), (int)(-Listen.RightHandLocation.Y * 16 + this.Height * 4));
            if (!Listen.LeftHandLocation.Equals(new Point(0, 0)))
            {
                if (LeftPress)
                {
                    MouseDownP.Invoke(null, new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, Loc.X, Loc.Y, 0));
                    MouseUpP.Invoke(null, new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, Loc.X, Loc.Y, 0));
                    LeftDown = true;
                }
                else if (LeftDown)
                {
                    MouseDownP.Invoke(null, new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, Loc.X, Loc.Y, 0));
                    MouseUpP.Invoke(null, new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 0, Loc.X, Loc.Y, 0));
                }
                MouseMoved.Invoke(null, new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, Loc.X, Loc.Y, 0));
            }
            
        }
        private void InitializeSpriteSets()
        {
            Bitmap[] SpriteSetImages;
            SpriteSets = new List<SpriteSet>();
            SpriteSetImages = new Bitmap[6];
            SpriteSetImages[0] = global::Hack1Draw.Properties.Resources.gohlub1;
            SpriteSetImages[1] = global::Hack1Draw.Properties.Resources.gohlub2;
            SpriteSetImages[2] = global::Hack1Draw.Properties.Resources.gohlub3;
            SpriteSetImages[3] = global::Hack1Draw.Properties.Resources.gohlub4;
            SpriteSetImages[4] = global::Hack1Draw.Properties.Resources.gohlub3;
            SpriteSetImages[5] = global::Hack1Draw.Properties.Resources.gohlub2;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 6));
            SpriteSetImages = new Bitmap[4];
            SpriteSetImages[0] = global::Hack1Draw.Properties.Resources.bad1;
            SpriteSetImages[1] = global::Hack1Draw.Properties.Resources.bad2;
            SpriteSetImages[2] = global::Hack1Draw.Properties.Resources.bad3;
            SpriteSetImages[3] = global::Hack1Draw.Properties.Resources.bad4;
            SpriteSets.Add(new SpriteSet(SpriteSetImages, 4));

            Bullets = new List<SpriteSet>();
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::Hack1Draw.Properties.Resources.met1;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::Hack1Draw.Properties.Resources.met1;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::Hack1Draw.Properties.Resources.lazer;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
            SpriteSetImages = new Bitmap[1];
            SpriteSetImages[0] = global::Hack1Draw.Properties.Resources.pew1;
            Bullets.Add(new SpriteSet(SpriteSetImages, 1));
        }
        private void InitializeTileSets()
        {
            Tile1 = new List<Bitmap>();
            Tile1.Add(global::Hack1Draw.Properties.Resources.z0);
            Tile1.Add(global::Hack1Draw.Properties.Resources.z1);
            Tile1.Add(global::Hack1Draw.Properties.Resources.z2);
            Tile1.Add(global::Hack1Draw.Properties.Resources.z3);
            Tile2 = new List<Bitmap>();
            Tile2.Add(global::Hack1Draw.Properties.Resources.z_0);
            Tile2.Add(global::Hack1Draw.Properties.Resources.z_1);
            Tile2.Add(global::Hack1Draw.Properties.Resources.z_2);
            Tile3 = new List<Bitmap>();
            Tile3.Add(global::Hack1Draw.Properties.Resources.z__0);
            Tile4 = new List<Bitmap>();
            Tile4.Add(global::Hack1Draw.Properties.Resources.z___0);
            EffectArt = new List<Bitmap>();
            EffectArt.Add(global::Hack1Draw.Properties.Resources.bum);
            EffectArt.Add(global::Hack1Draw.Properties.Resources.boom);
            PowerUpArt = new List<Bitmap>();
            PowerUpArt.Add(global::Hack1Draw.Properties.Resources.Health);
            PowerUpArt.Add(global::Hack1Draw.Properties.Resources.Speed);
            PowerUpArt.Add(global::Hack1Draw.Properties.Resources.Plasma);
            PowerUpArt.Add(global::Hack1Draw.Properties.Resources.Laser);
            PowerUpArt.Add(global::Hack1Draw.Properties.Resources.Heavy);
        }
        private void GLD_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownP.Invoke(sender, e);
        }
        public static double GetAngleDegree(Point origin, Point target)
        {
            var n = 270 - (Math.Atan2(origin.Y - target.Y, origin.X - target.X)) * 180 / Math.PI;
            return n % 360;
        }
        private void GLD_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMoved.Invoke(sender, e);
        }
        private void OnMouseMoved(object sender, MouseEventArgs e)
        {
            Point p1 = new Point(GLD.Width / 2, GLD.Height / 2);
            Point p2 = new Point(e.X, e.Y);
            MouseAngle = GetAngleDegree(p2, p1);
            MouseLoc = new Point(e.X, e.Y);
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
        }
        private void GLD_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpP.Invoke(sender, e);
        }
        private void GLDLoad(object sender, EventArgs e)
        {
            GLD.MakeCurrent();
            GLLoaded = true;
            GL.ClearColor(Color.LightGray);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            tileList = GL.GenLists(4);
            GL.NewList(tileList, ListMode.Compile);

            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0f, 0f); GL.Vertex2(0, 0);
            GL.TexCoord2(0f, 1f); GL.Vertex2(0, tileSize);
            GL.TexCoord2(1f, 1f); GL.Vertex2(tileSize, tileSize);
            GL.TexCoord2(1f, 0f); GL.Vertex2(tileSize, 0);
            GL.End();

            GL.EndList();

            GL.NewList(tileList + 1, ListMode.Compile);

            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0f, 0f); GL.Vertex2(0, 0);
            GL.TexCoord2(0f, 1f); GL.Vertex2(0, tileSize * 2);
            GL.TexCoord2(1f, 1f); GL.Vertex2(tileSize * 2, tileSize * 2);
            GL.TexCoord2(1f, 0f); GL.Vertex2(tileSize * 2, 0);
            GL.End();

            GL.EndList();

            GL.NewList(tileList + 2, ListMode.Compile);

            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0f, 0f); GL.Vertex2(0, 0);
            GL.TexCoord2(0f, 1f); GL.Vertex2(0, tileSize * 3);
            GL.TexCoord2(1f, 1f); GL.Vertex2(tileSize * 3, tileSize * 3);
            GL.TexCoord2(1f, 0f); GL.Vertex2(tileSize * 3, 0);
            GL.End();

            GL.EndList();

            GL.NewList(tileList + 3, ListMode.Compile);

            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0f, 0f); GL.Vertex2(0, 0);
            GL.TexCoord2(0f, 1f); GL.Vertex2(0, tileSize * 4);
            GL.TexCoord2(1f, 1f); GL.Vertex2(tileSize * 4, tileSize * 4);
            GL.TexCoord2(1f, 0f); GL.Vertex2(tileSize * 4, 0);
            GL.End();

            GL.EndList();
        }
        private void GLDPaint(object sender, PaintEventArgs e)
        {
            if (!GLLoaded) return;
            if (this.WindowState == FormWindowState.Minimized || this.Height == 0 || this.Width == 0) return;
            Draw();
        }
        private void DrawImage(int X, int Y, int XSize, int YSize, Bitmap ToDraw)
        {
            if (ToDraw == null) return;
            SetTexture(ref ToDraw);
            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0f, 0f); GL.Vertex2(X, Y);
            GL.TexCoord2(0f, 1f); GL.Vertex2(X, Y + YSize);
            GL.TexCoord2(1f, 1f); GL.Vertex2(X + XSize, Y + YSize);
            GL.TexCoord2(1f, 0f); GL.Vertex2(X + XSize, Y);
            GL.End();
        }
        private void DrawShit(int X, int Y, float XSize, float YSize)
        {
            GL.Color3(Color.Red);
            GL.Begin(BeginMode.Polygon);
            GL.Vertex2(X, Y);
            GL.Vertex2(X, Y + YSize);
            GL.Vertex2(X + XSize, Y + YSize);
            GL.Vertex2(X + XSize, Y);
            GL.End();
            GL.Color3(Color.White);
        }
        private bool IsInDraw = false;
        private void Draw()
        {
            if (IsInDraw) return;
            IsInDraw = true;
            HealthPanel.Size = new System.Drawing.Size(HealthIndex, HealthPanel.Height);
            WeaponLabel.Text = WeaponText;
            EnemyLabel.Text = "Enemies Remaining: " + NPCs.Count;

            GLD_Resize(null, null);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //Drawing
            GL.Enable(EnableCap.Texture2D);
            
            #region tiles

            int left = Players[CurrentPlayer].Location.X - GLD.Width / 2;
            int right = Players[CurrentPlayer].Location.X + GLD.Width / 2;
            int top = Players[CurrentPlayer].Location.Y - GLD.Height / 2;
            int bottom = Players[CurrentPlayer].Location.Y + GLD.Height / 2;

            int xm = GLD.Width / 2 - Players[CurrentPlayer].Location.X;
            int ym = GLD.Height / 2 - Players[CurrentPlayer].Location.Y;
            Bitmap B = null;
            for (int i = 0; i < tiles.Count; ++i)
            {
                int xk = tiles[i].position % numTilesH;
                int yk = tiles[i].position / numTilesH;

                int x = xm - (xk - numTilesH / 2 + 1) * tileSize - tileSize * tiles[i].size - 1;
                int y = ym - (yk - numTilesV / 2 + 1) * tileSize - tileSize * tiles[i].size - 1;

                if (x + tiles[i].size * tileSize < 0 || x > GLD.Width || y + tiles[i].size * tileSize < 0 || y > GLD.Height)
                    continue;

                if (tiles[i].size == 1) B = Tile1[tiles[i].ArtIndex];
                if (tiles[i].size == 2) B = Tile2[tiles[i].ArtIndex];
                if (tiles[i].size == 3) B = Tile3[tiles[i].ArtIndex];
                if (tiles[i].size == 4) B = Tile4[tiles[i].ArtIndex];
                SetTexture(ref B);

                GL.PushMatrix();
                GL.Translate(x, y, 0);
                GL.CallList(tileList + tiles[i].size - 1);
                GL.PopMatrix();
            }
            #endregion
            GL.Color3(Color.Black);
            for (int i = 0; i < Projectiles.Count; i++)
            {
                if (Projectiles[i].Location.X - Players[CurrentPlayer].Location.X < GLD.Width * 1.5)
                {
                    if (Projectiles[i].Location.Y - Players[CurrentPlayer].Location.Y < GLD.Height * 1.5)
                    {
                        GL.Translate(Projectiles[i].Location.X - Players[CurrentPlayer].Location.X, Projectiles[i].Location.Y - Players[CurrentPlayer].Location.Y, 0);
                        GL.Translate(GLD.Width / 2, GLD.Height / 2, 0);
                        GL.Rotate(-Projectiles[i].Facing + 180, 0, 0, -1);
                        if (Projectiles[i].ArtIndex == 0)
                        {
                            GL.Color3(Color.Black);
                            DrawImage((int)(-Bullets[Projectiles[i].ArtIndex].Images[0].Width / 6), (int)(-Bullets[Projectiles[i].ArtIndex].Images[0].Height / 6), Bullets[Projectiles[i].ArtIndex].Images[0].Width /3, Bullets[Projectiles[i].ArtIndex].Images[0].Height / 3, Bullets[Projectiles[i].ArtIndex].Images[0]);
                        }
                        else if (Projectiles[i].ArtIndex == 1)
                        {
                            GL.Color3(Environment);
                            DrawImage((int)(-Bullets[Projectiles[i].ArtIndex].Images[0].Width / 4), (int)(-Bullets[Projectiles[i].ArtIndex].Images[0].Height / 4), Bullets[Projectiles[i].ArtIndex].Images[0].Width / 2, Bullets[Projectiles[i].ArtIndex].Images[0].Height / 2, Bullets[Projectiles[i].ArtIndex].Images[0]);
                        }
                        else if (Projectiles[i].ArtIndex == 2)
                        {
                            GL.Color3(Environment);
                            DrawImage((int)(-Bullets[Projectiles[i].ArtIndex].Images[0].Width / 2), (int)(-Bullets[Projectiles[i].ArtIndex].Images[0].Height / 2), Bullets[Projectiles[i].ArtIndex].Images[0].Width, Bullets[Projectiles[i].ArtIndex].Images[0].Height, Bullets[Projectiles[i].ArtIndex].Images[0]);
                        }
                        else if (Projectiles[i].ArtIndex == 3)
                        {
                            GL.Color3(Environment);
                            DrawImage((int)(-Bullets[Projectiles[i].ArtIndex].Images[0].Width / 2), (int)(-Bullets[Projectiles[i].ArtIndex].Images[0].Height / 2), Bullets[Projectiles[i].ArtIndex].Images[0].Width, Bullets[Projectiles[i].ArtIndex].Images[0].Height, Bullets[Projectiles[i].ArtIndex].Images[0]);
                        }
                        GL.LoadIdentity();
                    }
                }
            }

            GL.Color3(Environment);
            for (int i = 0; i < Effects.Count; i++)
            {
                if (Effects[i].Location.X - Players[CurrentPlayer].Location.X < GLD.Width * 1.5)
                {
                    if (Effects[i].Location.Y - Players[CurrentPlayer].Location.Y < GLD.Height * 1.5)
                    {
                        GL.Translate(Effects[i].Location.X - Players[CurrentPlayer].Location.X, Effects[i].Location.Y - Players[CurrentPlayer].Location.Y, 0);
                        GL.Translate(GLD.Width / 2, GLD.Height / 2, 0);
                        GL.Rotate(-Effects[i].Facing + 180, 0, 0, -1);

                        if (Effects[i].ArtIndex == 0)
                        {
                            DrawImage(-EffectArt[Effects[i].ArtIndex].Width / 8, -EffectArt[Effects[i].ArtIndex].Height / 8, EffectArt[Effects[i].ArtIndex].Width / 4, EffectArt[Effects[i].ArtIndex].Height / 4, EffectArt[Effects[i].ArtIndex]);
                        }
                        else if (Effects[i].ArtIndex == 1)
                        {
                            GL.Color3(Environment);
                            DrawImage(-EffectArt[Effects[i].ArtIndex].Width / 2, -EffectArt[Effects[i].ArtIndex].Height / 2, EffectArt[Effects[i].ArtIndex].Width, EffectArt[Effects[i].ArtIndex].Height, EffectArt[Effects[i].ArtIndex]);
                        }
                        
                        GL.LoadIdentity();
                    }
                }
            }

            GL.Color3(Environment);
            for (int i = 0; i < NPCs.Count; i++)
            {
                if (NPCs[i].Location.X - Players[CurrentPlayer].Location.X < GLD.Width * 1.5)
                {
                    if (NPCs[i].Location.Y - Players[CurrentPlayer].Location.Y < GLD.Height * 1.5)
                    {
                        GL.Translate(NPCs[i].Location.X - Players[CurrentPlayer].Location.X, NPCs[i].Location.Y - Players[CurrentPlayer].Location.Y, 0);
                        GL.Translate(GLD.Width / 2, GLD.Height / 2, 0);
                        GL.Rotate(NPCs[i].Facing, 0, 0, -1);
                        DrawImage((int)(-SpriteSets[NPCs[i].ArtIndex].Images[NPCs[i].ImageIndex].Width / 2), (int)(-SpriteSets[NPCs[i].ArtIndex].Images[NPCs[i].ImageIndex].Height / 2), SpriteSets[NPCs[i].ArtIndex].Images[NPCs[i].ImageIndex].Width, SpriteSets[NPCs[i].ArtIndex].Images[NPCs[i].ImageIndex].Height, SpriteSets[NPCs[i].ArtIndex].Images[NPCs[i].ImageIndex]);
                        GL.LoadIdentity();
                    }
                }
            }
            
            GL.Color3(Environment);
            if(PowerUps != null)
            for (int i = 0; i < PowerUps.Count; i++)
            {
                if (PowerUps[i].Location.X - Players[CurrentPlayer].Location.X < GLD.Width * 1.5)
                {
                    if (PowerUps[i].Location.Y - Players[CurrentPlayer].Location.Y < GLD.Height * 1.5)
                    {
                        GL.Translate(PowerUps[i].Location.X - Players[CurrentPlayer].Location.X, PowerUps[i].Location.Y - Players[CurrentPlayer].Location.Y, 0);
                        GL.Translate(GLD.Width / 2, GLD.Height / 2, 0);
                        GL.Rotate(PowerUps[i].Facing, 0, 0, -1);
                        DrawImage(-PowerUpArt[PowerUps[i].ArtIndex].Width / 2, -PowerUpArt[PowerUps[i].ArtIndex].Height / 2, PowerUpArt[PowerUps[i].ArtIndex].Width, PowerUpArt[PowerUps[i].ArtIndex].Height, PowerUpArt[PowerUps[i].ArtIndex]);
                        GL.LoadIdentity();
                    }
                }
            }

            DrawImage(MouseLoc.X - 50, MouseLoc.Y - 50, 100, 100, Aim);

            GL.LoadIdentity();

            GL.Color3(Environment);
            GL.Translate(GLD.Width / 2, GLD.Height / 2, 0);
            GL.Rotate(MouseAngle + Players[0].AngleOffsetIndex, 0, 0, -1);
            DrawImage(-SpriteSets[0].Images[Players[0].ImageIndex].Width / 2, -SpriteSets[0].Images[Players[0].ImageIndex].Height / 2, SpriteSets[0].Images[Players[0].ImageIndex].Width, SpriteSets[0].Images[Players[0].ImageIndex].Height, SpriteSets[0].Images[Players[0].ImageIndex]);
            GL.LoadIdentity();

            GL.Disable(EnableCap.Texture2D);
            GLD.SwapBuffers();
            GLD.Invalidate();
            IsInDraw = false;
        }
        private void SetTexture(ref Bitmap NewTexture)
        {
            GL.DeleteTextures(1, ref Texture);
            GL.GenTextures(1, out Texture);
            GL.BindTexture(TextureTarget.Texture2D, Texture);
            BitmapData data = NewTexture.LockBits(new System.Drawing.Rectangle(0, 0, NewTexture.Width, NewTexture.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            NewTexture.UnlockBits(data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.BindTexture(TextureTarget.Texture2D, Texture);
        }
        private void Time_Tick(object sender, EventArgs e)
        {
            GLDPaint(null, null);
        }
        private void GLD_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, GLD.Width, GLD.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, GLD.Width, GLD.Height, 0, -1, 1);
        }
        public void RefreshData(int Health, string Weapon)
        {
            HealthIndex = Health;
            WeaponText = Weapon;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {/*
            if (keyData == Keys.Left)
            {
                BackGroundOffset.X += 10;
                EfectOffset += 10;
                if (BackGroundOffset.X > 0) BackGroundOffset.X -= BackX;
                if (BackGroundOffset.Y > 0) BackGroundOffset.Y -= BackY;
                if (BackGroundOffset.X < -BackX) BackGroundOffset.X += BackX;
                if (BackGroundOffset.Y < -BackY) BackGroundOffset.Y += BackY;
                return true;
            }
            if (keyData == Keys.Right)
            {
                BackGroundOffset.X -= 10;
                EfectOffset -= 10;
                if (BackGroundOffset.X > 0) BackGroundOffset.X -= BackX;
                if (BackGroundOffset.Y > 0) BackGroundOffset.Y -= BackY;
                if (BackGroundOffset.X < -BackX) BackGroundOffset.X += BackX;
                if (BackGroundOffset.Y < -BackY) BackGroundOffset.Y += BackY;
                return true;
            }
            if (keyData == Keys.Up)
            {
                BackGroundOffset.Y += 10;
                if (BackGroundOffset.X > 0) BackGroundOffset.X -= BackX;
                if (BackGroundOffset.Y > 0) BackGroundOffset.Y -= BackY;
                if (BackGroundOffset.X < -BackX) BackGroundOffset.X += BackX;
                if (BackGroundOffset.Y < -BackY) BackGroundOffset.Y += BackY;
                return true;
            }
            if (keyData == Keys.Down)
            {
                BackGroundOffset.Y -= 10;
                if (BackGroundOffset.X > 0) BackGroundOffset.X -= BackX;
                if (BackGroundOffset.Y > 0) BackGroundOffset.Y -= BackY;
                if (BackGroundOffset.X < -BackX) BackGroundOffset.X += BackX;
                if (BackGroundOffset.Y < -BackY) BackGroundOffset.Y += BackY;
                return true;
            }*/

            if (KeyPressed != null)
                KeyPressed(ref msg, keyData);

            if (keyData == Keys.Tab)
            {
                //Score.Visible = !Score.Visible;
            }
            if (keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ImgSwitch_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (SpriteSets[0].Images.Length > 1)
                {
                    Players[i].ImageIndex += Players[i].ImageIndexIncrement;
                    if (Players[i].ImageIndex == SpriteSets[0].Images.Length - 1) Players[i].ImageIndexIncrement = -1;
                    if (Players[i].ImageIndex == 0) Players[i].ImageIndexIncrement = 1;
                }
                if (SpriteSets[0].AngleOffset != 0)
                {
                    Players[i].AngleOffsetIndex += Players[i].AngleOffsetIndexIncrement;
                    if (Players[i].AngleOffsetIndex == SpriteSets[0].AngleOffset - 1) Players[i].AngleOffsetIndexIncrement = -1;
                    if (Players[i].AngleOffsetIndex == 0) Players[i].AngleOffsetIndexIncrement = 1;
                }
            }
            for (int i = 0; i < NPCs.Count; i++)
            {
                if (SpriteSets[NPCs[i].ArtIndex].Images.Length > 1)
                {
                    NPCs[i].ImageIndex += NPCs[i].ImageIndexIncrement;
                    if (NPCs[i].ImageIndex == SpriteSets[NPCs[i].ArtIndex].Images.Length - 1) NPCs[i].ImageIndexIncrement = -1;
                    if (NPCs[i].ImageIndex == 0) NPCs[i].ImageIndexIncrement = 1;
                }
                if (SpriteSets[NPCs[i].ArtIndex].AngleOffset != 0)
                {
                    NPCs[i].AngleOffsetIndex += NPCs[i].AngleOffsetIndexIncrement;
                    if (NPCs[i].AngleOffsetIndex == SpriteSets[NPCs[i].ArtIndex].AngleOffset - 1) NPCs[i].AngleOffsetIndexIncrement = -1;
                    if (NPCs[i].AngleOffsetIndex == 0) NPCs[i].AngleOffsetIndexIncrement = 1;
                }
            }
        }
        private void Killemll_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            Killemll.Interval = 10;
            if (Environment.G > 0)
            {
                Environment = Color.FromArgb(Environment.R, Environment.G - 1, Environment.B - 1);
            }
        }
        public void ResetBuffers()
        {
            PlayersBuffer = new List<Item>();
            NPCsBuffer = new List<Item>();
            ProjectilesBuffer = new List<Item>();
            EffectsBuffer = new List<Item>();
            PowerUpsBuffer = new List<Item>();
        }
        public void UpdateItem(int Type, int Index, int ArtIndex, Point Location, double Facing, double Size)
        {
            if (Type == 0)
            {
                if (PlayersBuffer.Count > Index)
                {
                    if (Index == CurrentPlayer)
                    {
                    }
                    PlayersBuffer[Index].ArtIndex = ArtIndex;
                    PlayersBuffer[Index].Location = Location;
                    PlayersBuffer[Index].Size = Size;
                }
                else PlayersBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
            if (Type == 1)
            {
                if (NPCsBuffer.Count > Index)
                {
                    NPCsBuffer[Index].ArtIndex = ArtIndex;
                    NPCsBuffer[Index].Location = Location;
                    NPCsBuffer[Index].Facing = Facing;
                    NPCsBuffer[Index].Size = Size;
                }
                else NPCsBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
            if (Type == 2)
            {
                if (ProjectilesBuffer.Count > Index)
                {
                    ProjectilesBuffer[Index].ArtIndex = ArtIndex;
                    ProjectilesBuffer[Index].Location = Location;
                    ProjectilesBuffer[Index].Facing = Facing;
                    ProjectilesBuffer[Index].Size = Size;
                }
                else ProjectilesBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
            if (Type == 3)
            {
                if (EffectsBuffer.Count > Index)
                {
                    EffectsBuffer[Index].ArtIndex = ArtIndex;
                    EffectsBuffer[Index].Location = Location;
                    EffectsBuffer[Index].Facing = Facing;
                    EffectsBuffer[Index].Size = Size;
                }
                else EffectsBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
            if (Type == 4)
            {
                if (PowerUpsBuffer.Count > Index)
                {
                    PowerUpsBuffer[Index].ArtIndex = ArtIndex;
                    PowerUpsBuffer[Index].Location = Location;
                    PowerUpsBuffer[Index].Facing = Facing;
                    PowerUpsBuffer[Index].Size = Size;
                }
                else PowerUpsBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
        }
        public void UpdateItems(int Type, int[] Index, int[] ArtIndex, Point[] Location, double[] Facing, double[] Size)
        {
            if (Working) return;
                Working = true;
                for (int i = 0; i < Index.Length; i++)
                {
                    UpdateItem(Type, Index[i], ArtIndex[i], Location[i], Facing[i], Size[i]);
                }
                Working = false;
        }
        public void SwapBuffers()
        {
            Players = PlayersBuffer;
            NPCs = NPCsBuffer;
            Projectiles = ProjectilesBuffer;
            Effects = EffectsBuffer;
            PowerUps = PowerUpsBuffer;
        }
        struct Tile
        {
            public int position;
            public int size;
            public int ArtIndex;
        }
        public void GenerateTiles(int numTilesH, int numTilesV)
        {
            this.numTilesH = numTilesH;
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
            }
        }

        public int FindEmptyTile(int size, int numTiles)
        {
            Random random = new Random();

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
            }

            return -1;
        }
        public void DeathCall()
        {
            Killemll = new System.Timers.Timer();
            Killemll.Enabled = true;
            Killemll.Elapsed += new System.Timers.ElapsedEventHandler(Killemll_Tick);
            Killemll.Interval = 10;
            Killemll.Start();
        }
    }
    class Item
    {
        private int _ArtIndex;
        private int _ImageIndex;
        private int _ImageIndexIncrement;
        private int _AngleOffsetIndex;
        private int _AngleOffsetIndexIncrement;
        private double _Size;
        private double _Facing;
        private Point _Location;
        public int ArtIndex
        {
            get { return _ArtIndex; }
            set { _ArtIndex = value; }
        }
        public int ImageIndex
        {
            get { return _ImageIndex; }
            set { _ImageIndex = value; }
        }
        public int ImageIndexIncrement
        {
            get { return _ImageIndexIncrement; }
            set { _ImageIndexIncrement = value; }
        }
        public int AngleOffsetIndex
        {
            get { return _AngleOffsetIndex; }
            set { _AngleOffsetIndex = value; }
        }
        public int AngleOffsetIndexIncrement
        {
            get { return _AngleOffsetIndexIncrement; }
            set { _AngleOffsetIndexIncrement = value; }
        }
        public double Size
        {
            get { return _Size; }
            set { _Size = value; }
        }
        public double Facing
        {
            get { return _Facing; }
            set { _Facing = value; }
        }
        public Point Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
        public Item(int ArtIndex, Point Location, double Facing, double Size)
        {
            this._ArtIndex = ArtIndex;
            this._ImageIndex = 0;
            this._ImageIndexIncrement = 1;
            this._AngleOffsetIndex = 0;
            this._AngleOffsetIndexIncrement = 1;
            this._Size = Size;
            this._Location = Location;
            this._Facing = Facing;
        }
    }
    class SpriteSet
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
