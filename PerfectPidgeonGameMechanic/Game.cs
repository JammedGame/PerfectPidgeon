using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using PerfectPidgeon.Draw;
using PerfectPidgeon.Draw.BackgroundGenerator;

namespace PerfectPidgeonGameMechanic
{
    public class Game
    {
        private long TimeStamp = 0;
        private const int FieldSize = 200;
        private bool PlayerOnMove = false;
        private bool PlayerOnFire = false;
        private DrawForm DForm;
        private Point _Size;
        private System.Timers.Timer _Time;
        private Player _CurrentPlayer;
        private List<Object> _Enemies;
        private List<Projectile> _Projectiles;
        private List<Effect> _Effects;
        private List<PowerUp> _PowerUps;
        public Point Size
        {
            get { return _Size; }
            set { _Size = value; }
        }
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
        public List<Object> Enemies
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
        public Game(DrawForm DForm)
        {
            this.DForm = DForm;
            DForm.MouseMoved += new MouseEventHandler(this.MouseEvent_Move);
            DForm.MouseUpP += new MouseEventHandler(this.MouseEvent_Up);
            DForm.MouseDownP += new MouseEventHandler(this.MouseEvent_Down);
            StartLevel(new Point(10,10), 1);
            Time = new System.Timers.Timer(10);
            Time.Elapsed += new System.Timers.ElapsedEventHandler(TimerEvent_Tick);
            Time.Start();
        }
        public void GeneratePreset()
        {

        }
        public void StartLevel(Point Size, int Difficulty)
        {
            DForm.ArtData.BackType = 2;
            DForm.ArtData.Back = TiledBackgroundGenerator.Create("Data\\Town", 100, 40, 2);

            DForm.ArtData.GenerateTiles(Size.X, Size.Y);
            //Defining Player
            CurrentPlayer = new Player();
            CurrentPlayer.Location = new Vertex(0,0);
            CurrentPlayer.Health = 100;
            CurrentPlayer.MaxHealth = 100;
            CurrentPlayer.ProjectileType = 0;
            CurrentPlayer.NextLocation = null;
            CurrentPlayer.Facing = 0;
            CurrentPlayer.Speed = 4;
            CurrentPlayer.SpecialAmmo = 0;
            CurrentPlayer.SpeedBoost = 1;
            CurrentPlayer.SpeedBoostTimer = 0;

            //Defining NPCs
            int NumberOfNPC = (int)(Math.Sqrt(Size.X * Size.Y) * 2);
            Random Rand = new Random();
            Enemies = new List<Object>();
            for (int i = 0; i < NumberOfNPC; i++)
            {
                Object NewNPC = new Object();
                NewNPC.Location = new Vertex(Rand.NextDouble() * Size.X * FieldSize, Rand.NextDouble() * Size.Y * FieldSize);
                NewNPC.Facing = 0;
                NewNPC.ProjectileType = 0;
                NewNPC.Health = Rand.Next(100, 200);
                NewNPC.Speed = 2;
                NewNPC.ArtIndex = 2;
                NewNPC.Sight = 1000;
                NewNPC.Range = 500;
                Enemies.Add(NewNPC);
            }

            Projectiles = new List<Projectile>();
            Effects = new List<Effect>();
            PowerUps = new List<PowerUp>();
        }
        public void RefreshDrawing()
        {
            DForm.Data.ResetBuffers();
            DForm.Data.UpdateItem(0, 0, CurrentPlayer.ProjectileType, CurrentPlayer.Location.ToPoint(), CurrentPlayer.Facing, 3, 0);
            List<int> Indices = new List<int>();
            List<int> ArtIndices = new List<int>();
            List<double> Angles = new List<double>();
            List<double> Sizes = new List<double>();
            List<Point> Locations = new List<Point>();
            List<int> Other = new List<int>();
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].Location != null)
                {
                    Indices.Add(i);
                    ArtIndices.Add(Enemies[i].ArtIndex);
                    Angles.Add(DrawForm.GetAngleDegree((CurrentPlayer.Location).ToPoint(), Enemies[i].Location.ToPoint()));
                    Sizes.Add(1);
                    Other.Add(0);
                    Locations.Add(Enemies[i].Location.ToPoint());
                }
            }
            for (int i = Enemies.Count - 1; i >= 0; i--) if (!(Enemies[i].Location != null)) Enemies.RemoveAt(i);
            while (DForm.Data.Working) ;
            DForm.Data.UpdateItems(1, Indices.ToArray(), ArtIndices.ToArray(), Locations.ToArray(), Angles.ToArray(), Sizes.ToArray(), Other.ToArray());
            Indices = new List<int>();
            ArtIndices = new List<int>();
            Angles = new List<double>();
            Sizes = new List<double>();
            Locations = new List<Point>();
            Other = new List<int>();
            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Health -= 10;
                if (Projectiles[i].Health == 0)
                {
                    Projectiles[i].Location = null;
                }
                if (Projectiles[i].Location != null)
                {
                    Indices.Add(i);
                    ArtIndices.Add(Projectiles[i].ProjectileType);
                    Angles.Add(Projectiles[i].Facing);
                    Sizes.Add(1);
                    if(Projectiles[i].Spin > 0)
                    {
                        int r = 3;
                    }
                    Other.Add(Projectiles[i].Spin);
                    Locations.Add(Projectiles[i].Location.ToPoint());
                }
            }
            for (int i = Projectiles.Count - 1; i >= 0; i--) if (!(Projectiles[i].Location != null)) Projectiles.RemoveAt(i);
            while (DForm.Data.Working) ;
            DForm.Data.UpdateItems(2, Indices.ToArray(), ArtIndices.ToArray(), Locations.ToArray(), Angles.ToArray(), Sizes.ToArray(), Other.ToArray());
            Indices = new List<int>();
            ArtIndices = new List<int>();
            Angles = new List<double>();
            Sizes = new List<double>();
            Locations = new List<Point>();
            Other = new List<int>();
            for (int i = 0; i < Effects.Count; i++)
            {
                if (Effects[i].Location != null)
                {
                    Indices.Add(i);
                    ArtIndices.Add(Effects[i].ArtIndex);
                    Angles.Add(0);
                    Sizes.Add(1);
                    Other.Add(0);
                    Locations.Add(Effects[i].Location.ToPoint());
                }
            }
            for (int i = Effects.Count - 1; i >= 0; i--) if (!(Effects[i].Location != null)) Effects.RemoveAt(i);
            while (DForm.Data.Working) ;
            DForm.Data.UpdateItems(3, Indices.ToArray(), ArtIndices.ToArray(), Locations.ToArray(), Angles.ToArray(), Sizes.ToArray(), Other.ToArray());
            Indices = new List<int>();
            ArtIndices = new List<int>();
            Angles = new List<double>();
            Sizes = new List<double>();
            Locations = new List<Point>();
            Other = new List<int>();
            for (int i = 0; i < PowerUps.Count; i++)
            {
                if (PowerUps[i].Location != null)
                {
                    Indices.Add(i);
                    ArtIndices.Add(PowerUps[i].Type - 1);
                    Angles.Add(0);
                    Sizes.Add(1);
                    Other.Add(0);
                    Locations.Add(PowerUps[i].Location.ToPoint());
                }
            }
            for (int i = PowerUps.Count - 1; i >= 0; i--) if (!(PowerUps[i].Location != null)) PowerUps.RemoveAt(i);
            while (DForm.Data.Working) ;
            DForm.Data.UpdateItems(4, Indices.ToArray(), ArtIndices.ToArray(), Locations.ToArray(), Angles.ToArray(), Sizes.ToArray(), Other.ToArray());
            DForm.Data.SwapBuffers();
        }
        private bool CurrentTick = false;
        public void TimerEvent_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimeStamp++;
            if (CurrentTick) return;
            CurrentTick = true;
            if(TimeStamp%3 == 0) DForm.ImgSwitch_Tick();
            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Spin += 5;
            }
            if (PlayerOnMove)
            {
                //Vertex UnitVector = Vertex.Norm(DrawForm.GetAngleDegree(CurrentPlayer.Location.ToPoint(), CurrentPlayer.NextLocation.ToPoint())) * CurrentPlayer.Speed;
                Vertex UnitVectorBase = new Vertex(1, 0);
                double Angle = CurrentPlayer.Facing + 90;
                Vertex UnitVector = UnitVectorBase.RotateZ(Angle);
                CurrentPlayer.Location += UnitVector * CurrentPlayer.Speed * CurrentPlayer.SpeedBoost;
            }
            for (int i = 0; i < Projectiles.Count; i++)
            {
                Vertex UnitVectorBase = new Vertex(1, 0);
                double Angle = Projectiles[i].Facing + 90;
                Vertex UnitVector = UnitVectorBase.RotateZ(Angle);
                Projectiles[i].Location += UnitVector * Projectiles[i].Speed;
                /*Projectiles[i].Health -= 5;
                if (Projectiles[i].Health <= 0) Projectiles[i].Location = null;*/
            }
            if (PlayerOnFire && CurrentPlayer.ProjectileType == 0 && TimeStamp%10 == 0)
            {
                Vertex Offset1 = new Vertex(38, 75, 0);
                Vertex Offset2 = new Vertex(-38, 75, 0);
                Offset1 = Offset1.RotateZ(CurrentPlayer.Facing);
                Offset2 = Offset2.RotateZ(CurrentPlayer.Facing);

                Projectile Proj1 = new Projectile();
                Proj1.Location = CurrentPlayer.Location + Offset1;
                Proj1.Facing = CurrentPlayer.Facing;
                Proj1.ProjectileType = 0;
                Proj1.Speed = 10;
                Proj1.Damage = 10;
                Proj1.Health = 5000;
                Proj1.MaxHealth = 5000;
                Proj1.Owner = 0;

                Projectile Proj2 = new Projectile();
                Proj2.Location = CurrentPlayer.Location + Offset2;
                Proj2.Facing = CurrentPlayer.Facing;
                Proj2.ProjectileType = 0;
                Proj2.Speed = 10;
                Proj2.Damage = 10;
                Proj2.Health = 5000;
                Proj2.MaxHealth = 5000;
                Proj2.Owner = 0;

                Projectiles.Add(Proj1);
                Projectiles.Add(Proj2);
            }
            if (PlayerOnFire && CurrentPlayer.ProjectileType == 1 && TimeStamp % 5 == 0)
            {
                Vertex Offset1 = new Vertex(38, 75, 0);
                Vertex Offset2 = new Vertex(-38, 75, 0);
                Offset1 = Offset1.RotateZ(CurrentPlayer.Facing);
                Offset2 = Offset2.RotateZ(CurrentPlayer.Facing);

                Projectile Proj1 = new Projectile();
                Proj1.Location = CurrentPlayer.Location + Offset1;
                Proj1.Facing = CurrentPlayer.Facing;
                Proj1.ProjectileType = 1;
                Proj1.Speed = 15;
                Proj1.Damage = 10;
                Proj1.Health = 5000;
                Proj1.MaxHealth = 5000;
                Proj1.Owner = 0;

                Projectile Proj2 = new Projectile();
                Proj2.Location = CurrentPlayer.Location + Offset2;
                Proj2.Facing = CurrentPlayer.Facing;
                Proj2.ProjectileType = 1;
                Proj2.Speed = 15;
                Proj2.Damage = 10;
                Proj2.Health = 5000;
                Proj2.MaxHealth = 5000;
                Proj2.Owner = 0;

                Projectiles.Add(Proj1);
                Projectiles.Add(Proj2);

                if (CurrentPlayer.SpecialAmmo == 0)
                    CurrentPlayer.ProjectileType = 0;
                else
                    CurrentPlayer.SpecialAmmo -= 5;
            }
            if (PlayerOnFire && CurrentPlayer.ProjectileType == 2 && TimeStamp % 10 == 0)
            {
                Vertex Offset1 = new Vertex(38, 75, 0);
                Vertex Offset2 = new Vertex(-38, 75, 0);
                Vertex Offset1R = Offset1.RotateZ(CurrentPlayer.Facing);
                Vertex Offset2R = Offset2.RotateZ(CurrentPlayer.Facing);
                Projectile Proj1;
                Projectile Proj2;
                for (int i = 0; i < 30; i++)
                {
                    Offset1 = new Vertex(35, 75 + i * 50, 0);
                    Offset2 = new Vertex(-35, 75 + i * 50, 0);
                    Offset1R = Offset1.RotateZ(CurrentPlayer.Facing);
                    Offset2R = Offset2.RotateZ(CurrentPlayer.Facing);
                    Proj1 = new Projectile();
                    Proj2 = new Projectile();
                    Proj1.Location = CurrentPlayer.Location + Offset1R;
                    Proj1.Facing = CurrentPlayer.Facing;
                    Proj1.ProjectileType = 2;
                    Proj1.Speed = 10;
                    Proj1.Damage = 5;
                    Proj1.Health = 50;
                    Proj1.MaxHealth = 50;
                    Proj1.Owner = 0;
                    Proj2.Location = CurrentPlayer.Location + Offset2R;
                    Proj2.Facing = CurrentPlayer.Facing;
                    Proj2.ProjectileType = 2;
                    Proj2.Speed = 10;
                    Proj2.Damage = 5;
                    Proj2.Health = 50;
                    Proj2.MaxHealth = 50;
                    Proj2.Owner = 0;
                    Projectiles.Add(Proj1);
                    Projectiles.Add(Proj2);
                }

                if (CurrentPlayer.SpecialAmmo == 0)
                {
                    CurrentPlayer.ProjectileType = 0;
                }
                else
                    CurrentPlayer.SpecialAmmo -= 10;
            }
            if (PlayerOnFire && CurrentPlayer.ProjectileType == 3 && TimeStamp % 20 == 0)
            {
                Vertex Offset1 = new Vertex(38, 75, 0);
                Vertex Offset2 = new Vertex(-38, 75, 0);
                Offset1 = Offset1.RotateZ(CurrentPlayer.Facing);
                Offset2 = Offset2.RotateZ(CurrentPlayer.Facing);

                Projectile Proj1 = new Projectile();
                Proj1.Location = CurrentPlayer.Location + Offset1;
                Proj1.Facing = CurrentPlayer.Facing;
                Proj1.ProjectileType = 3;
                Proj1.Speed = 6;
                Proj1.Damage = 30;
                Proj1.Health = 2000;
                Proj1.MaxHealth = 2000;
                Proj1.Owner = 0;

                Projectile Proj2 = new Projectile();
                Proj2.Location = CurrentPlayer.Location + Offset2;
                Proj2.Facing = CurrentPlayer.Facing;
                Proj2.ProjectileType = 3;
                Proj2.Speed = 6;
                Proj2.Damage = 30;
                Proj2.Health = 2000;
                Proj2.MaxHealth = 2000;
                Proj2.Owner = 0;

                Projectiles.Add(Proj1);
                Projectiles.Add(Proj2);

                if (CurrentPlayer.SpecialAmmo == 0)
                {
                    CurrentPlayer.ProjectileType = 0;
                }
                else
                    CurrentPlayer.SpecialAmmo -= 2;
            }
            for (int i = 0; i < Effects.Count; i++)
            {
                Effects[i].Lifetime --;
                if (Effects[i].Lifetime == 0) Effects[i].Location = null;
            }
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].Location == null) continue;
                if (Vertex.Distance(Enemies[i].Location, CurrentPlayer.Location) < Enemies[i].Sight)
                {
                    if (Vertex.Distance(Enemies[i].Location, CurrentPlayer.Location) > Enemies[i].Range)
                    {
                        Vertex UnitVectorBase = new Vertex(1, 0);
                        double Angle = DrawForm.GetAngleDegree(Enemies[i].Location.ToPoint(), CurrentPlayer.Location.ToPoint());
                        Vertex UnitVector = UnitVectorBase.RotateZ(Angle + 90);
                        UnitVector.Y *= -1;
                        Enemies[i].Location -= UnitVector * Enemies[i].Speed;
                    }
                    else if (TimeStamp%10 == 0)
                    {
                        Vertex UnitVectorBase = new Vertex(1, 0);
                        double Angle = DrawForm.GetAngleDegree(Enemies[i].Location.ToPoint(), CurrentPlayer.Location.ToPoint());
                        Vertex UnitVector = UnitVectorBase.RotateZ(Angle);
                        UnitVector.Y *= -1;
                        Enemies[i].Location -= UnitVector * Enemies[i].Speed;

                        Vertex Offset = new Vertex(0, -100, 0);
                        Offset = Offset.RotateZ(-Angle + 180);

                        Projectile Proj = new Projectile();
                        Proj.Location = Enemies[i].Location + Offset;
                        Proj.Facing = -Angle;
                        Proj.ProjectileType = 4;
                        Proj.Speed = 5;
                        Proj.Damage = 10;
                        Proj.Health = 2000;
                        Proj.MaxHealth = 2000;
                        Proj.Owner = 1;
                        Projectiles.Add(Proj);
                    }
                }
            }
            isHit();
            isPlayerHit();
            if (PowerUps.Count > 0) tookPowerUp();
            if (CurrentPlayer.SpeedBoostTimer > 0)
                CurrentPlayer.SpeedBoostTimer -= 40;
            else
                CurrentPlayer.SpeedBoost = 1;
            if (CurrentPlayer.ProjectileType == 0) DForm.RefreshData((int)(200 * CurrentPlayer.Health * 1.0 / CurrentPlayer.MaxHealth), "Basic");
            else if (CurrentPlayer.ProjectileType == 1) DForm.RefreshData((int)(200 * CurrentPlayer.Health * 1.0 / CurrentPlayer.MaxHealth), "Heavy - " + CurrentPlayer.SpecialAmmo);
            else if (CurrentPlayer.ProjectileType == 2) DForm.RefreshData((int)(200 * CurrentPlayer.Health * 1.0 / CurrentPlayer.MaxHealth), "Laser - " + CurrentPlayer.SpecialAmmo);
            else if (CurrentPlayer.ProjectileType == 3) DForm.RefreshData((int)(200 * CurrentPlayer.Health * 1.0 / CurrentPlayer.MaxHealth), "Plasma - " + CurrentPlayer.SpecialAmmo);
            RefreshDrawing();
            CurrentTick = false;
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
                    if (distance < 80)
                    {
                        CurrentPlayer.Health -= Projectiles[j].Damage;
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
                        Projectiles[j].Location = null;
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
                    if (distance < 80)
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
            }
            if (Enemies.Count == 0)
            {
                CurrentTick = true;
                StartLevel(new Point(10, 10), 1);
                CurrentTick = false;
            }
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
                    if (PowerUps[i].Type == 1)
                    {
                        if (CurrentPlayer.Health + PowerUps[i].Boost > CurrentPlayer.MaxHealth)
                            CurrentPlayer.Health = CurrentPlayer.MaxHealth;
                        else
                            CurrentPlayer.Health += (int)PowerUps[i].Boost;
                    }
                    if (PowerUps[i].Type == 2)
                    {
                        CurrentPlayer.SpeedBoostTimer = PowerUps[i].Duration_Ammo;
                        CurrentPlayer.SpeedBoost = PowerUps[i].Boost;
                    }
                    if (PowerUps[i].Type == 3)
                    {
                        CurrentPlayer.ProjectileType = 3;
                        CurrentPlayer.SpecialAmmo = PowerUps[i].Duration_Ammo;
                    }
                    if (PowerUps[i].Type == 4)
                    {
                        CurrentPlayer.ProjectileType = 2;
                        CurrentPlayer.SpecialAmmo = PowerUps[i].Duration_Ammo;
                    }
                    if (PowerUps[i].Type == 5)
                    {
                        CurrentPlayer.ProjectileType = 1;
                        CurrentPlayer.SpecialAmmo = PowerUps[i].Duration_Ammo;
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
                    PowerUps.Add(new PowerUp(DropLocation, type, 0, 50));//HP
                if (type == 2)
                    PowerUps.Add(new PowerUp(DropLocation, type, 30000, 2)); //Speed
                if (type == 3)
                    PowerUps.Add(new PowerUp(DropLocation, type, 100, 70)); // Plasma gun
                if (type == 4)
                    PowerUps.Add(new PowerUp(DropLocation, type, 1000, 10)); // Laser gun
                if (type == 5)
                    PowerUps.Add(new PowerUp(DropLocation, type, 300, 50)); // Heavy ammo
            }
        }
    }
}
