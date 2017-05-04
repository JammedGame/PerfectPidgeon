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

namespace PerfectPidgeon.Draw
{
    public partial class DrawForm : Form
    {
        private SettingsData _SetData;

        private ArtData _ArtData;
        private GameData _Data;
        private Controls _Controls;
        private Renderer _Renderer;
        private GLControl GLD;

        private int HealthIndex = 200;
        private string WeaponText = "Basic";
        
        public event MouseEventHandler MouseMoved;
        public event MouseEventHandler MouseUpP;
        public event MouseEventHandler MouseDownP;
        public delegate void KeyPressedDelegate(Keys keyData);
        public event KeyPressedDelegate KeyPressed;
        public delegate void AxisRotate(double Angle);
        public event AxisRotate LeftRotate;
        public delegate void LevelChosen(string Choice);
        public event LevelChosen LevelStart;

        private System.Timers.Timer UpdateFrame;
        private System.Timers.Timer UpdateLeap;
        private System.Timers.Timer Killemll;

        private Joystick _Joystick;
        //private PidgeonLeapListener Listen;
        //private Controller Control;
        private bool LeapCheck = false;
        private bool LeftDown = false;
        private bool RightDown = false;
        public bool DrawDataReady = false;
        private string Title = "TST";
        public ArtData ArtData
        {
            get
            {
                return _ArtData;
            }

            set
            {
                _ArtData = value;
            }
        }
        public GameData Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
            }
        }

        private int counter = 0;
        public DrawForm()
        {
            //Cursor.Hide();
            InitializeComponent();

            _SetData = new SettingsData();
            this.Sets.Data = _SetData;
            this.Sets.Update += new Settings.SettingsUpdate(SetsUpdate);
            this.mainMenu1.Choice += new MainMenu.MenuItemChosen(MenuEvent);
            this.LevelStart += new LevelChosen(OnLevelStart);
            this.LevelChooser.Choice += new Draw.LevelChoice.LevelChosen(LevelChoice);

            this.GLD = new GLControl();
            this.GLD.BackColor = System.Drawing.Color.Black;
            this.GLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GLD.Location = new System.Drawing.Point(0, 0);
            this.GLD.Name = "GLD";
            this.GLD.Size = new System.Drawing.Size(800, 600);
            this.GLD.TabIndex = 0;
            this.GLD.VSync = false;
            this.GLD.Load += new System.EventHandler(this.GLDLoad);
            this.GLD.Paint += new System.Windows.Forms.PaintEventHandler(this.GLDPaint);
            this.GLD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GLD_MouseDown);
            this.GLD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GLD_MouseMove);
            this.GLD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GLD_MouseUp);
            this.GLD.Resize += new System.EventHandler(this.GLD_Resize);
            this.GLD.Visible = false;
            this.Controls.Add(GLD);

            this.Data = new GameData();
            this.ArtData = new ArtData();
            this._Controls = new PerfectPidgeon.Draw.Controls();
            this._Renderer = new Renderer(GLD, Data, ArtData, this._Controls, this._SetData);
            
            MouseMoved = new MouseEventHandler(OnMouseMoved);
            MouseUpP = new MouseEventHandler(OnMouseUp);
            MouseDownP = new MouseEventHandler(OnMouseDown);
            KeyPressed = new KeyPressedDelegate(OnKeyPress);
            LeftRotate = new AxisRotate(OnLeftRotate);

            this._Joystick = new Joystick(0);
            this._Joystick.LeftAxisChange += new AxisEvent(JoystickAxisLeft);
            this._Joystick.RightAxisChange += new AxisEvent(JoystickAxisRight);
            this._Joystick.JoystickButtonPress += new ButtonPress(JoystickButtonPressed);

            //Listen = new PidgeonLeapListener();
            //Control = new Controller();
            //Control.AddListener(Listen);

            UpdateLeap = new System.Timers.Timer();
            UpdateLeap.Enabled = true;
            UpdateLeap.Elapsed += new System.Timers.ElapsedEventHandler(Leap_Tick);
            UpdateLeap.Interval = 30;
            UpdateLeap.Start();
        }
        private void Leap_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            /*if (!Listen.Connected) return;
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
            }*/
        }     
        private void JoystickButtonPressed(JoystickButton Button, bool Pressed)
        {
            if(Button == JoystickButton.Move)
            {
                if(Pressed) MouseDownP.Invoke(null, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
                else MouseUpP.Invoke(null, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
            }
            if (Button == JoystickButton.Shoot)
            {
                if (Pressed) MouseDownP.Invoke(null, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
                else MouseUpP.Invoke(null, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            }
        }
        private void JoystickAxisLeft(double Angle)
        {
            
            Vertex V = new Vertex(0, 300);
            V = V.RotateZ(Angle);
            Point P = V.ToPoint();
            MouseMoved.Invoke(null, new MouseEventArgs(MouseButtons.None, 0, -P.X + GLD.Width / 2, -P.Y + GLD.Height / 2, 0));
        }
        private void JoystickAxisRight(double Angle)
        {
            LeftRotate.Invoke(Angle);
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
            this._Controls.MouseAngle = GetAngleDegree(p2, p1);
            this._Controls.MouseLoc = new Point(e.X, e.Y);
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
        }
        private void OnKeyPress(Keys keyData)
        {

        }
        private void OnLeftRotate(double Angle)
        {

        }
        private void OnLevelStart(string Choice) { }
        private void GLD_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpP.Invoke(sender, e);
        }
        private void GLDLoad(object sender, EventArgs e)
        {
            this._Renderer.Init();
        }
        private void GLDPaint(object sender, PaintEventArgs e)
        {
            if (!this._Renderer.GLLoaded) return;
            if (!DrawDataReady) return;
            if (this.WindowState == FormWindowState.Minimized || this.Height == 0 || this.Width == 0) return;
            HealthPanel.Size = new System.Drawing.Size(HealthIndex, HealthPanel.Height);
            WeaponLabel.Text = WeaponText;
            LevelTitle.Text = Title;
            if (this._Data.SwapingBuffers)
            {
                return;
            }
            this._Renderer.Draw();
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
        {
            if (keyData == Keys.A || keyData == Keys.D || keyData == Keys.W || keyData == Keys.Q || keyData == Keys.E || keyData == Keys.S || keyData == Keys.D1 || keyData == Keys.D2 || keyData == Keys.D3 || keyData == Keys.D4)
            {
                KeyPressed.Invoke(keyData);
                return true;
            }
            if (keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void ImgSwitch_Tick()
        {
            this.Data.ImageSwitch(this.ArtData.SpriteSets);
        }
        private void Killemll_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            Killemll.Interval = 10;
            if (this.ArtData.Environment.G > 0)
            {
                this.ArtData.Environment = Color.FromArgb(this.ArtData.Environment.R, this.ArtData.Environment.G - 1, this.ArtData.Environment.B - 1);
            }
        }
        public void DeathCall()
        {
            Killemll = new System.Timers.Timer();
            Killemll.Enabled = true;
            Killemll.Elapsed += new System.Timers.ElapsedEventHandler(Killemll_Tick);
            Killemll.Interval = 10;
            Killemll.Start();
        }
        public void SetTitle(string Title)
        {
            this.Title = Title;
        }
        public void MenuEvent(MenuItem Item)
        {
            if (Item == MenuItem.Settings)
            {
                this.Sets.Visible = true;
            }
            else if (Item == MenuItem.Level)
            {
                this.LevelChooser.Visible = true;
            }
            else if (Item == MenuItem.Continue)
            {
                LevelChoice("LVL01");
            }
        }
        public void SetsUpdate()
        {
            if(_SetData.Fullscreen)
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
            this.Size = new Size(_SetData.Resolution.X, _SetData.Resolution.Y);
        }
        public void LevelChoice(string Choice)
        {
            GLD.Visible = true;
            HealthPanel.Visible = true;
            LevelChooser.Visible = false;
            mainMenu1.Visible = false;
            GLD.BringToFront();
            HealthPanel.BringToFront();
            LevelStart.Invoke(Choice);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Time = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.HealthPanel = new System.Windows.Forms.Panel();
            this.WeaponLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LevelTitle = new System.Windows.Forms.Label();
            this.mainMenu1 = new PerfectPidgeon.Draw.MainMenu();
            this.Sets = new PerfectPidgeon.Draw.Settings();
            this.LevelChooser = new PerfectPidgeon.Draw.LevelChoice();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Time
            // 
            this.Time.Interval = 10;
            this.Time.Tick += new System.EventHandler(this.Time_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.HealthPanel);
            this.panel1.Location = new System.Drawing.Point(15, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 30);
            this.panel1.TabIndex = 1;
            // 
            // HealthPanel
            // 
            this.HealthPanel.BackColor = System.Drawing.Color.Silver;
            this.HealthPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.HealthPanel.Location = new System.Drawing.Point(0, 0);
            this.HealthPanel.Name = "HealthPanel";
            this.HealthPanel.Size = new System.Drawing.Size(120, 30);
            this.HealthPanel.TabIndex = 2;
            // 
            // WeaponLabel
            // 
            this.WeaponLabel.AutoSize = true;
            this.WeaponLabel.BackColor = System.Drawing.Color.Transparent;
            this.WeaponLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeaponLabel.ForeColor = System.Drawing.Color.Black;
            this.WeaponLabel.Location = new System.Drawing.Point(313, 20);
            this.WeaponLabel.Name = "WeaponLabel";
            this.WeaponLabel.Size = new System.Drawing.Size(90, 28);
            this.WeaponLabel.TabIndex = 2;
            this.WeaponLabel.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LevelTitle);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.WeaponLabel);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 66);
            this.panel2.TabIndex = 4;
            this.panel2.Visible = false;
            // 
            // LevelTitle
            // 
            this.LevelTitle.BackColor = System.Drawing.Color.Transparent;
            this.LevelTitle.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelTitle.ForeColor = System.Drawing.Color.Black;
            this.LevelTitle.Location = new System.Drawing.Point(233, 18);
            this.LevelTitle.Name = "LevelTitle";
            this.LevelTitle.Size = new System.Drawing.Size(74, 30);
            this.LevelTitle.TabIndex = 4;
            this.LevelTitle.Text = "TST";
            this.LevelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainMenu1
            // 
            this.mainMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenu1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu1.Location = new System.Drawing.Point(0, 0);
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size(800, 600);
            this.mainMenu1.TabIndex = 5;
            // 
            // Sets
            // 
            this.Sets.BackColor = System.Drawing.Color.White;
            this.Sets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sets.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sets.Location = new System.Drawing.Point(0, 0);
            this.Sets.Name = "Sets";
            this.Sets.Size = new System.Drawing.Size(800, 600);
            this.Sets.TabIndex = 6;
            this.Sets.Visible = false;
            // 
            // LevelChooser
            // 
            this.LevelChooser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LevelChooser.Location = new System.Drawing.Point(0, 0);
            this.LevelChooser.Name = "LevelChooser";
            this.LevelChooser.Size = new System.Drawing.Size(800, 600);
            this.LevelChooser.TabIndex = 7;
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.LevelChooser);
            this.Controls.Add(this.Sets);
            this.Controls.Add(this.mainMenu1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DrawForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
