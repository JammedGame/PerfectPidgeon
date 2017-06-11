using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using PerfectPidgeon.Draw;
using PerfectPidgeon.Draw.BackgroundGenerator;
using PerfectPidgeonGameMechanic.Content;

namespace PerfectPidgeonGameMechanic
{
    public class Game
    {
        private long TimeStamp = 0;
        private long Sanctuary = 1000;
        private bool Paused = false;
        private bool Started = false;
        private bool PlayerOnMove = false;
        private bool PlayerOnFire = false;
        private DrawForm DForm;
        private MainForm MForm;
        private System.Timers.Timer _Time;
        private Player _CurrentPlayer;
        private Boss _CurrentBoss;
        private Level _CurrentLevel;
        private BaseDataPool _DataPool;
        private List<Enemy> _EnemyPool;
        private List<Enemy> _Enemies;
        private List<Projectile> _Projectiles;
        private List<Effect> _Effects;
        private List<PowerUp> _PowerUps;
        public System.Timers.Timer Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        public Player CurrentPlayer
        {
            get { return _CurrentPlayer; }
            set { _CurrentPlayer = value; }
        }
        public List<Enemy> Enemies
        {
            get { return _Enemies; }
            set { _Enemies = value; }
        }
        public List<Projectile> Projectiles
        {
            get { return _Projectiles; }
            set { _Projectiles = value; }
        }
        public List<Effect> Effects
        {
            get { return _Effects; }
            set { _Effects = value; }
        }
        public List<PowerUp> PowerUps
        {
            get { return _PowerUps; }
            set { _PowerUps = value; }
        }
        public Game(DrawForm DForm, MainForm MForm)
        {
            this.DForm = DForm;
            this.MForm = MForm;
            MForm.LevelStart += new MainForm.LevelInit(this.Start);
            MForm.LevelContinue += new MainForm.LevelInit(this.Continue);
        }
        public void Start(string LevelName)
        {
            if(!this.Started)
            {
                DForm.MouseMoved += new MouseEventHandler(this.MouseEvent_Move);
                DForm.MouseUpP += new MouseEventHandler(this.MouseEvent_Up);
                DForm.MouseDownP += new MouseEventHandler(this.MouseEvent_Down);
                DForm.KeyPressed += new DrawForm.KeyPressedDelegate(this.KeyPressed);
                DForm.LeftRotate += new DrawForm.AxisRotate(this.LeftRotate);
                this._DataPool = new BaseDataPool();
                StartLevel(this._DataPool.Levels[LevelName]);
                Time = new System.Timers.Timer(10);
                Time.Elapsed += new System.Timers.ElapsedEventHandler(TimerEvent_Tick);
                Time.Start();
                DForm.Show();
            }
            else
            {
                Restart(this._DataPool.Levels[LevelName]);
                Time.Start();
                DForm.Show();
            }
        }
        public void Continue(string LevelName)
        {
            DForm.Show();
            Time.Start();
        }
        public void Stop()
        {
            DForm.Hide();
            Time.Stop();
        }
        public void StartLevel(Level CLevel)
        {
            this.Sanctuary = 100;
            this._CurrentLevel = CLevel;
            if (CLevel.Back.Type == LevelData.BackgroundType.Static)
            {
                DForm.ArtData.SetBackground(CLevel.Back.Path);
            }
            else if (CLevel.Back.Type == LevelData.BackgroundType.Dynamic)
            {

            }
            else if (CLevel.Back.Type == LevelData.BackgroundType.Tiled)
            {
                DForm.ArtData.BackType = 2;
                DForm.ArtData.Back = TiledBackgroundGenerator.Create(CLevel.Back.Path, CLevel.Back.Other * 20, 2, CLevel.Back.Other);
            }

            DForm.SetTitle(CLevel.Title);

            if (CurrentPlayer == null)
            {
                CurrentPlayer = this._DataPool.Pidgeon;
            }

            Random Rand = new Random();
            this.Enemies = new List<Enemy>();
            this._EnemyPool = new List<Enemy>();
            for (int i = 0; i < CLevel.Enemies.Count; i++)
            {
                Enemy E = new Enemy(CLevel.Enemies[i]);
                this._EnemyPool.Add(E);
            }
            if (CLevel.LBoss != null)
            {
                this._CurrentBoss = new Boss(CLevel.LBoss);
                
                for (int i = 0; i < this._CurrentBoss.Auxes.Count; i++)
                {
                    this._EnemyPool.Add(this._CurrentBoss.Auxes[i]);
                }
                this._EnemyPool.Add(this._CurrentBoss);
            }
            Spawn();

            this.Projectiles = new List<Projectile>();
            this.Effects = new List<Effect>();
            this.PowerUps = new List<PowerUp>();
        }
        private bool CurrentTick = false;
        public void TimerEvent_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimeStamp++;
            if (Sanctuary != 0) Sanctuary--;
            if (CurrentTick) return;
            CurrentTick = true;
            RefreshGame();
            CurrentTick = false;
        }
        public void RefreshGame()
        {
            if (TimeStamp % 3 == 0) DForm.ImgSwitch_Tick();
            if (TimeStamp % 100 == 0) Spawn();
            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Spin += 5;
            }
            CurrentPlayer.ApplyBuffs(TimeStamp);
            if (PlayerOnMove)
            {
                //Vertex UnitVector = Vertex.Norm(DrawForm.GetAngleDegree(CurrentPlayer.Location.ToPoint(), CurrentPlayer.NextLocation.ToPoint())) * CurrentPlayer.Speed;
                Vertex UnitVectorBase = new Vertex(1, 0);
                double Angle = CurrentPlayer.Facing + 90;
                Vertex UnitVector = UnitVectorBase.RotateZ(Angle);
                CurrentPlayer.Location += UnitVector * CurrentPlayer.ActiveSpeed;
            }
            for (int i = 0; i < Projectiles.Count; i++)
            {
                double Angle = 0;
                if (Projectiles[i].Behave.Linear) Angle = Projectiles[i].Facing + 90;
                else Angle = -DrawForm.GetAngleDegree(Projectiles[i].Location.ToPoint(), CurrentPlayer.Location.ToPoint()) + 90;
                Vertex UnitVectorBase = new Vertex(1, 0);
                Vertex UnitVector = UnitVectorBase.RotateZ(Angle);
                Projectiles[i].Location += UnitVector * Projectiles[i].Speed;
                if(!Projectiles[i].Behave.Sustainable) Projectiles[i].Health -= 10;
                if (Projectiles[i].Health == 0)
                {
                    for (int j = 0; j < Projectiles[i].Summons.Count; j++)
                    {
                        if (Projectiles[i].Summons[j].Event == SummonActivationType.OnExpire || Projectiles[i].Summons[j].Event == SummonActivationType.OnBoth)
                        {
                            if (Projectiles[i].Summons[j].Type == SummonType.Projectile)
                            {
                                Projectile P = new Projectile(Projectiles[i].Summons[j].Projectile);
                                P.Owner = Projectiles[i].Owner;
                                P.Location += Projectiles[i].Location;
                                P.Facing += Projectiles[i].Facing + Projectiles[i].Summons[j].Facing;
                                Projectiles.Add(P);
                            }
                            else if (Projectiles[i].Summons[j].Type == SummonType.Enemy)
                            {
                                Enemy E = new Enemy(_DataPool.Enemies[Projectiles[i].Summons[j].Enemy]);
                                E.Location += Projectiles[i].Location;
                                E.Facing = Projectiles[i].Facing;
                                this._Enemies.Add(E);
                            }
                        }
                    }
                    Projectiles[i].Location = null;
                }
            }
            if (PlayerOnFire && TimeStamp % 5 == 0)
            {
                if (!CurrentPlayer.Disabled)
                {
                    for (int i = 0; i < CurrentPlayer.Guns.Count; i++)
                    {
                        if (!CurrentPlayer.Guns[i].Active) continue;
                        this._Projectiles.AddRange(CurrentPlayer.Guns[i].Shoot(CurrentPlayer, TimeStamp));
                    }
                    CurrentPlayer.IsActiveEmpty();
                }
            }
            for (int i = 0; i < Effects.Count; i++)
            {
                Effects[i].Lifetime--;
                if (Effects[i].Lifetime == 0) Effects[i].Location = null;
            }
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Sanctuary > 0) break;
                if (Enemies[i].Location == null) continue;
                Enemies[i].ApplyBuffs(TimeStamp);
                if (Vertex.Distance(Enemies[i].Location, CurrentPlayer.Location) < Enemies[i].Behave.Sight)
                {
                    if (Vertex.Distance(Enemies[i].Location, CurrentPlayer.Location) > Enemies[i].Behave.Radius)
                    {
                        Vertex UnitVectorBase = new Vertex(1, 0);
                        double Angle = DrawForm.GetAngleDegree(Enemies[i].Location.ToPoint(), CurrentPlayer.Location.ToPoint());
                        Vertex UnitVector = UnitVectorBase.RotateZ(Angle + 90);
                        UnitVector.Y *= -1;
                        Enemies[i].Location -= UnitVector * Enemies[i].ActiveSpeed;
                    }
                    else if (TimeStamp % 5 == 0)
                    {
                        Enemies[i].Facing = -DrawForm.GetAngleDegree(Enemies[i].Location.ToPoint(), CurrentPlayer.Location.ToPoint());

                        for (int j = 0; j < Enemies[i].Guns.Count; j++)
                        {
                            if (!Enemies[i].Guns[j].Active) continue;
                            this._Projectiles.AddRange(Enemies[i].Guns[j].Shoot(Enemies[i], TimeStamp));
                        }
                    }
                }
            }
            if(this._CurrentBoss != null)
            {
                for(int i = 0; i < this._CurrentBoss.Auxes.Count; i++)
                {
                    this._CurrentBoss.Auxes[i].Location = this._CurrentBoss.Location + this._CurrentBoss.Offsets[i].RotateZ(this._CurrentBoss.Facing);
                    this._CurrentBoss.Auxes[i].Facing = this._CurrentBoss.Facing;
                }
            }
            isHit();
            isPlayerHit();
            if (PowerUps.Count > 0) tookPowerUp();
            if (CurrentPlayer.CurrentWeapons == 0) DForm.RefreshData((int)(200 * CurrentPlayer.Health * 1.0 / CurrentPlayer.MaxHealth), "Basic");
            else if (CurrentPlayer.CurrentWeapons == 1) DForm.RefreshData((int)(200 * CurrentPlayer.Health * 1.0 / CurrentPlayer.MaxHealth), "Heavy - " + CurrentPlayer.CurrentAmmo());
            else if (CurrentPlayer.CurrentWeapons == 2) DForm.RefreshData((int)(200 * CurrentPlayer.Health * 1.0 / CurrentPlayer.MaxHealth), "Laser - " + CurrentPlayer.CurrentAmmo());
            else if (CurrentPlayer.CurrentWeapons == 3) DForm.RefreshData((int)(200 * CurrentPlayer.Health * 1.0 / CurrentPlayer.MaxHealth), "Plasma - " + CurrentPlayer.CurrentAmmo());
            RefreshDrawing();
        }
        public void RefreshDrawing()
        {
            DForm.Data.ResetBuffers();
            DForm.Data.UpdateItem(GameDataType.Player, 0, CurrentPlayer.CurrentWeapons, CurrentPlayer.ImageIndex, (int)CurrentPlayer.GunRotation, CurrentPlayer.Facing, 3, CurrentPlayer.Location.ToPoint(), CurrentPlayer.Paint);
            List<int> Indices = new List<int>();
            List<int> ArtIndices = new List<int>();
            List<int> ImageIndices = new List<int>();
            List<int> Other = new List<int>();
            List<double> Angles = new List<double>();
            List<double> Sizes = new List<double>();
            List<Color> Colors = new List<Color>();
            List<Point> Locations = new List<Point>();
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].Location != null)
                {
                    Indices.Add(i);
                    ArtIndices.Add(Enemies[i].ArtIndex);
                    ImageIndices.Add(Enemies[i].ImageIndex);
                    Other.Add(0);
                    Colors.Add(Enemies[i].Paint);
                    Sizes.Add(Enemies[i].Scale);
                    Locations.Add(Enemies[i].Location.ToPoint());
                    if(this._CurrentBoss != null && this._CurrentBoss.Auxes.Contains(Enemies[i]))
                    {
                        Angles.Add(DrawForm.GetAngleDegree((CurrentPlayer.Location).ToPoint(), this._CurrentBoss.Location.ToPoint()));
                    }
                    else Angles.Add(DrawForm.GetAngleDegree((CurrentPlayer.Location).ToPoint(), Enemies[i].Location.ToPoint()));
                }
            }
            for (int i = Enemies.Count - 1; i >= 0; i--) if (!(Enemies[i].Location != null)) Enemies.RemoveAt(i);
            while (DForm.Data.Working) ;
            DForm.Data.UpdateItems(GameDataType.Enemy, Indices.ToArray(), ArtIndices.ToArray(), ImageIndices.ToArray(), Other.ToArray(), Angles.ToArray(), Sizes.ToArray(), Locations.ToArray(), Colors.ToArray());
            Indices = new List<int>();
            ArtIndices = new List<int>();
            ImageIndices = new List<int>();
            Angles = new List<double>();
            Sizes = new List<double>();
            Locations = new List<Point>();
            Colors = new List<Color>();
            Other = new List<int>();
            for (int i = 0; i < Projectiles.Count; i++)
            {
                if (Projectiles[i].Location != null)
                {
                    Indices.Add(i);
                    ArtIndices.Add(Projectiles[i].ArtIndex);
                    ImageIndices.Add(Projectiles[i].ImageIndex);
                    Angles.Add(Projectiles[i].Facing);
                    Sizes.Add(Projectiles[i].Scale);
                    Other.Add(Projectiles[i].Spin);
                    Colors.Add(Projectiles[i].Paint);
                    Locations.Add(Projectiles[i].Location.ToPoint());
                }
            }
            for (int i = Projectiles.Count - 1; i >= 0; i--) if (!(Projectiles[i].Location != null)) Projectiles.RemoveAt(i);
            while (DForm.Data.Working) ;
            DForm.Data.UpdateItems(GameDataType.Projectile, Indices.ToArray(), ArtIndices.ToArray(), ImageIndices.ToArray(), Other.ToArray(), Angles.ToArray(), Sizes.ToArray(), Locations.ToArray(), Colors.ToArray());
            Indices = new List<int>();
            ArtIndices = new List<int>();
            ImageIndices = new List<int>();
            Angles = new List<double>();
            Sizes = new List<double>();
            Locations = new List<Point>();
            Colors = new List<Color>();
            Other = new List<int>();
            for (int i = 0; i < Effects.Count; i++)
            {
                if (Effects[i].Location != null)
                {
                    Indices.Add(i);
                    ArtIndices.Add(Effects[i].ArtIndex);
                    ImageIndices.Add(Effects[i].ImageIndex);
                    Angles.Add(0);
                    Sizes.Add(1);
                    Other.Add(0);
                    Colors.Add(Color.White);
                    Locations.Add(Effects[i].Location.ToPoint());
                }
            }
            for (int i = Effects.Count - 1; i >= 0; i--) if (!(Effects[i].Location != null)) Effects.RemoveAt(i);
            while (DForm.Data.Working) ;
            DForm.Data.UpdateItems(GameDataType.Effect, Indices.ToArray(), ArtIndices.ToArray(), ImageIndices.ToArray(), Other.ToArray(), Angles.ToArray(), Sizes.ToArray(), Locations.ToArray(), Colors.ToArray());
            Indices = new List<int>();
            ArtIndices = new List<int>();
            ImageIndices = new List<int>();
            Angles = new List<double>();
            Sizes = new List<double>();
            Locations = new List<Point>();
            Colors = new List<Color>();
            Other = new List<int>();
            for (int i = 0; i < PowerUps.Count; i++)
            {
                if (PowerUps[i].Location != null)
                {
                    Indices.Add(i);
                    ArtIndices.Add((int)(PowerUps[i].Type));
                    ImageIndices.Add(0);
                    Angles.Add(0);
                    Sizes.Add(1);
                    Other.Add(0);
                    Colors.Add(Color.White);
                    Locations.Add(PowerUps[i].Location.ToPoint());
                }
            }
            for (int i = PowerUps.Count - 1; i >= 0; i--) if (!(PowerUps[i].Location != null)) PowerUps.RemoveAt(i);
            while (DForm.Data.Working) ;
            DForm.Data.UpdateItems(GameDataType.PowerUp, Indices.ToArray(), ArtIndices.ToArray(), ImageIndices.ToArray(), Other.ToArray(), Angles.ToArray(), Sizes.ToArray(), Locations.ToArray(), Colors.ToArray());
            DForm.Data.SwapBuffers();
        }
        public void MouseEvent_Move(object sender, MouseEventArgs e)
        {
            if (_CurrentPlayer != null)
            {
                Point p1 = new Point(DForm.Width / 2, DForm.Height / 2);
                Point p2 = new Point(e.X, e.Y);
                CurrentPlayer.Facing = -DrawForm.GetAngleDegree(p2, p1) + 180;
            }
        }
        public void MouseEvent_Down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PlayerOnMove = true;
                CurrentPlayer.NextLocation = new Vertex(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Left)
            {
                PlayerOnFire = true;
            }
        }
        public void MouseEvent_Up(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PlayerOnMove = false;
            }
            else if (e.Button == MouseButtons.Left)
            {
                PlayerOnFire = false;
            }
        }
        public void isPlayerHit()
        {
            double distance;
            for (int j = Projectiles.Count - 1; j >= 0; j--)
            {
                if (!(CurrentPlayer.Location != null)) continue;
                if (!(Projectiles[j].Location != null)) continue;
                if (Projectiles[j].Owner == 0) continue;
                distance = Math.Sqrt((CurrentPlayer.Location.X - Projectiles[j].Location.X) * (CurrentPlayer.Location.X - Projectiles[j].Location.X) +
                    (CurrentPlayer.Location.Y - Projectiles[j].Location.Y) * (CurrentPlayer.Location.Y - Projectiles[j].Location.Y));
                if (distance < CurrentPlayer.HitRadius + Projectiles[j].HitRadius)
                {
                    CurrentPlayer.Health -= Projectiles[j].Damage;
                    for(int i = 0; i < Projectiles[j].Buffs.Count; i++)
                    {
                        CurrentPlayer.Buffs.Add(new Buff(Projectiles[j].Buffs[i]));
                    }
                    if (!(CurrentPlayer.Health > 0))
                    {
                        Time.Stop();
                        DForm.DeathCall();
                    }
                    if (CurrentPlayer.Location != null)
                    {
                        Effect NewEffect = new Effect();
                        NewEffect.ArtIndex = 0;
                        NewEffect.Lifetime = 25;
                        NewEffect.Location = Projectiles[j].Location;
                        Effects.Add(NewEffect);
                    }
                    for (int k = 0; k < Projectiles[j].Summons.Count; k++)
                    {
                        if (Projectiles[j].Summons[k].Event == SummonActivationType.OnHit || Projectiles[j].Summons[k].Event == SummonActivationType.OnBoth)
                        {
                            if (Projectiles[j].Summons[k].Type == SummonType.Projectile)
                            {
                                Projectile P = new Projectile(Projectiles[j].Summons[k].Projectile);
                                P.Location += Projectiles[j].Location;
                                P.Facing += Projectiles[j].Facing + Projectiles[j].Summons[k].Facing;
                                P.Owner = Projectiles[j].Owner;
                                Projectiles.Add(P);
                            }
                            else if (Projectiles[j].Summons[k].Type == SummonType.Enemy)
                            {
                                Enemy E = new Enemy(_DataPool.Enemies[Projectiles[j].Summons[k].Enemy]);
                                E.Location += Projectiles[j].Location;
                                E.Facing = Projectiles[j].Facing;
                                this._Enemies.Add(E);
                            }
                        }
                    }
                    if (Projectiles[j].Behave.Sustainable)
                    {
                        Projectiles[j].Health -= Projectiles[j].Damage;
                        if(Projectiles[j].Health <= 0) Projectiles[j].Location = null;
                    }
                    else
                    {
                        Projectiles[j].Location = null;
                    }
                }

            }
        }
        public void isHit()
        {
            double distance;
            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                for (int j = Projectiles.Count - 1; j >= 0; j--)
                {
                    if (!(Projectiles[j].Location != null)) continue;
                    if (!(Enemies[i].Location != null)) continue;
                    if (Projectiles[j].Owner > 0) continue;
                    distance = Math.Sqrt((Enemies[i].Location.X - Projectiles[j].Location.X) * (Enemies[i].Location.X - Projectiles[j].Location.X) +
                        (Enemies[i].Location.Y - Projectiles[j].Location.Y) * (Enemies[i].Location.Y - Projectiles[j].Location.Y));
                    if (distance < Enemies[i].HitRadius + Projectiles[j].HitRadius)
                    {
                        Enemies[i].Health -= Projectiles[j].Damage;
                        if (!(Enemies[i].Health > 0))
                        {
                            Effect NewEffect = new Effect();
                            NewEffect.ArtIndex = 1;
                            NewEffect.Lifetime = 100;
                            NewEffect.Location = Enemies[i].Location;
                            Effects.Add(NewEffect);
                            dropPowerUp(Enemies[i].Location);
                            Enemies[i].Location = null;
                        }
                        if (Enemies[i].Location != null)
                        {
                            Effect NewEffect = new Effect();
                            NewEffect.ArtIndex = 0;
                            NewEffect.Lifetime = 25;
                            NewEffect.Location = Projectiles[j].Location;
                            Effects.Add(NewEffect);
                        }
                        Projectiles[j].Location = null;
                    }
                }
                if (Enemies[i].Type == EnemyType.Grouped)
                {
                    Grouped G = Enemies[i] as Grouped;
                    for (int k = 0; k < G.Auxes.Count; i++)
                    {
                        for (int j = Projectiles.Count - 1; j >= 0; j--)
                        {
                            if (!(Projectiles[j].Location != null)) continue;
                            if (!(G.Auxes[k].Location != null)) continue;
                            if (Projectiles[j].Owner > 0) continue;
                            distance = Math.Sqrt((G.Auxes[k].Location.X - Projectiles[j].Location.X) * (G.Auxes[k].Location.X - Projectiles[j].Location.X) +
                                (G.Auxes[k].Location.Y - Projectiles[j].Location.Y) * (G.Auxes[k].Location.Y - Projectiles[j].Location.Y));
                            if (distance < G.Auxes[k].HitRadius + Projectiles[j].HitRadius)
                            {
                                G.Auxes[k].Health -= Projectiles[j].Damage;
                                if (!(G.Auxes[k].Health > 0))
                                {
                                    Effect NewEffect = new Effect();
                                    NewEffect.ArtIndex = 1;
                                    NewEffect.Lifetime = 100;
                                    NewEffect.Location = G.Auxes[k].Location;
                                    Effects.Add(NewEffect);
                                    dropPowerUp(G.Auxes[k].Location);
                                    G.Auxes[k].Location = null;
                                }
                                if (G.Auxes[k].Location != null)
                                {
                                    Effect NewEffect = new Effect();
                                    NewEffect.ArtIndex = 0;
                                    NewEffect.Lifetime = 25;
                                    NewEffect.Location = Projectiles[j].Location;
                                    Effects.Add(NewEffect);
                                }
                                Projectiles[j].Location = null;
                            }
                        }
                    }
                }
                
            }
            if ((Enemies.Count + _EnemyPool.Count <= this._CurrentLevel.FinishCondition) || (this._CurrentLevel.FinishCondition == -1 && false))
            {
                if (this._CurrentLevel.Next != "") Restart(this._DataPool.Levels[this._CurrentLevel.Next]);
                else Restart(this._CurrentLevel);
            }
        }
        public void Restart(Level New)
        {
            CurrentTick = true;
            CurrentPlayer.Health = CurrentPlayer.MaxHealth;
            CurrentPlayer.Location = new Vertex();
            StartLevel(New);
            CurrentTick = false;
        }
        public void tookPowerUp()
        {
            for (int i = PowerUps.Count - 1; i >= 0; i--)
            {
                double distance;
                distance = Math.Sqrt((PowerUps[i].Location.X - CurrentPlayer.Location.X) * (PowerUps[i].Location.X - CurrentPlayer.Location.X) +
                        (PowerUps[i].Location.Y - CurrentPlayer.Location.Y) * (PowerUps[i].Location.Y - CurrentPlayer.Location.Y));
                if (distance < 100)
                {
                    if (PowerUps[i].Type == PowerUpType.Health)
                    {
                        if (CurrentPlayer.Health + PowerUps[i].Boost > CurrentPlayer.MaxHealth)
                            CurrentPlayer.Health = CurrentPlayer.MaxHealth;
                        else
                            CurrentPlayer.Health += (int)PowerUps[i].Boost;
                    }
                    if (PowerUps[i].Type == PowerUpType.Speed)
                    {
                        CurrentPlayer.Buffs.Add(new Buff(BuffType.SpeedEffect, PowerUps[i].Boost, PowerUps[i].Duration_Ammo));
                    }
                    if (PowerUps[i].Type == PowerUpType.PidgeonHeavy)
                    {
                        CurrentPlayer.AddAmmo(PowerUps[i].Duration_Ammo, ProjectileType.PidgeonHeavy);
                        CurrentPlayer.SelectWeapon(1);
                    }
                    if (PowerUps[i].Type == PowerUpType.PidgeonLaser)
                    {
                        CurrentPlayer.AddAmmo(PowerUps[i].Duration_Ammo, ProjectileType.PidgeonLaser);
                        CurrentPlayer.SelectWeapon(2);
                    }
                    if (PowerUps[i].Type == PowerUpType.PidgeonPlazma)
                    {
                        CurrentPlayer.AddAmmo(PowerUps[i].Duration_Ammo, ProjectileType.PidgeonPlazma);
                        CurrentPlayer.SelectWeapon(3);
                    }
                    PowerUps.RemoveAt(i);
                }
            }
        }
        public void dropPowerUp(Vertex DropLocation)
        {
            Random rnd = new Random();
            int chance = rnd.Next(1, 1);
            if (chance == 1)
            {
                int type = rnd.Next(1, 6);
                if (type == 1)
                    PowerUps.Add(new PowerUp(DropLocation, PowerUpType.Health, 0, 50));//HP
                if (type == 2)
                    PowerUps.Add(new PowerUp(DropLocation, PowerUpType.Speed, 600, 2)); //Speed
                if (type == 3)
                    PowerUps.Add(new PowerUp(DropLocation, PowerUpType.PidgeonHeavy, 100, 50)); // Heavy ammo
                if (type == 4)
                    PowerUps.Add(new PowerUp(DropLocation, PowerUpType.PidgeonLaser, 50, 10)); // Laser gun
                if (type == 5)
                    PowerUps.Add(new PowerUp(DropLocation, PowerUpType.PidgeonPlazma, 30, 70)); // Plasma gun
            }
        }
        public void Spawn()
        {
            if (this._CurrentLevel.SpawnStrategy < 4)
            {
                int OuterRadius = 3000;
                int InnerRadius = 600;
                if(this._CurrentLevel.SpawnStrategy == 1)
                {
                    OuterRadius = 1200;
                    InnerRadius = 600;
                }
                else if (this._CurrentLevel.SpawnStrategy == 2)
                {
                    OuterRadius = 1500;
                    InnerRadius = 800;
                }
                Random Rand = new Random();
                for (int i = 0; i < this._Enemies.Count; i++)
                {
                    if (Vertex.Distance(this._CurrentPlayer.Location, this._Enemies[i].Location) > OuterRadius)
                    {
                        this._EnemyPool.Insert(0, this._Enemies[i]);
                        this._Enemies.Remove(this._Enemies[i]);
                    }
                }
                while (this._Enemies.Count < this._CurrentLevel.MaxSpawns && this._EnemyPool.Count > 0)
                {
                    long X = Rand.Next(-OuterRadius/2, +OuterRadius/2);
                    if (X != 0) X += (X / Math.Abs(X)) * InnerRadius;
                    else X = InnerRadius;
                    long Y = Rand.Next(-OuterRadius / 2, +OuterRadius / 2);
                    if (Y != 0) Y += (Y / Math.Abs(X)) * InnerRadius;
                    else Y = InnerRadius;
                    this._EnemyPool[0].Location = this._CurrentPlayer.Location + new Vertex(X, Y);
                    this._Enemies.Add(this._EnemyPool[0]);
                    this._EnemyPool.RemoveAt(0);
                }
            }
        }
        public void KeyPressed(Keys Key)
        {
            if (Key == Keys.Escape) this.Stop();
            else if (Key == Keys.Space)
            {
                this.Paused = !this.Paused;
                if (Paused) this.Time.Stop();
                else this.Time.Start();
            }
            else if (Key == Keys.Q) this._CurrentPlayer.GunRotation -= 10;
            else if (Key == Keys.W) this._CurrentPlayer.GunRotation = 0;
            else if (Key == Keys.E) this._CurrentPlayer.GunRotation += 10;
            else if (Key == Keys.S) this._CurrentPlayer.GunRotation = 180;
            else if (Key == Keys.D) this._CurrentPlayer.GunRotation = 90;
            else if (Key == Keys.A) this._CurrentPlayer.GunRotation = 270;
            else if (Key == Keys.D1) this._CurrentPlayer.SelectWeapon(0);
            else if (Key == Keys.D2) this._CurrentPlayer.SelectWeapon(1);
            else if (Key == Keys.D3) this._CurrentPlayer.SelectWeapon(2);
            else if (Key == Keys.D4) this._CurrentPlayer.SelectWeapon(3);
        }
        private void LeftRotate(double Angle)
        {
            if (this._CurrentPlayer != null)
            {
                //this._CurrentPlayer.GunRotation += (Angle + 180) - this._CurrentPlayer.Facing;
            }
        }
    }
}
