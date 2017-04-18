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

namespace PerfectPidgeon.Draw
{
    public partial class DrawForm : Form
    {
        private ArtData _ArtData;
        private GameData _Data;
        private Controls _Controls;
        private Renderer _Renderer;

        private int HealthIndex = 200;
        private string WeaponText = "Basic";

        public bool Working = false;
        
        public event MouseEventHandler MouseMoved;
        public event MouseEventHandler MouseUpP;
        public event MouseEventHandler MouseDownP;
        public delegate void KeyPressedDelegate(ref Message msg, Keys keyData);
        public event KeyPressedDelegate KeyPressed;  
        
        private System.Timers.Timer UpdateFrame;
        private System.Timers.Timer UpdateLeap;
        private System.Timers.Timer Killemll;
        private Point BackGroundOffset = new Point(0, 0);
        private int EffectOffset = 0;
        private bool GLLoaded;  

        /*private const int numTileTries = 60;
        private const int tileSize = 200;
        private int numTilesH;
        private int numTilesV;
        private List<Tile> tiles;
        private int tileList;
        private int[] t;*/

        private PidgeonLeapListener Listen;
        private Controller Control;
        private bool LeapCheck = false;
        private bool LeftDown = false;
        private bool RightDown = false;

        public DrawForm()
        {
            Cursor.Hide();
            InitializeComponent();

            this._Data = new GameData();
            this._ArtData = new ArtData();
            this._Controls = new PerfectPidgeon.Draw.Controls();
            
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
        private bool IsInDraw = false;
        private void Draw()
        {
            HealthPanel.Size = new System.Drawing.Size(HealthIndex, HealthPanel.Height);
            WeaponLabel.Text = WeaponText;
            EnemyLabel.Text = "Enemies Remaining: " + NPCs.Count;

            _Renderer.Draw();
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
}
