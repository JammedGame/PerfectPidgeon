using PerfectPidgeon.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Weapon
    {
        private bool _Active;
        private int _Ammo;
        private int _FireRate;
        private int _RandomAngle;
        private Vertex _Location;
        private Projectile _Type;
        public bool Active
        {
            get
            {
                return _Active;
            }

            set
            {
                _Active = value;
            }
        }
        public int Ammo
        {
            get
            {
                return _Ammo;
            }

            set
            {
                _Ammo = value;
            }
        }
        public int FireRate
        {
            get
            {
                return _FireRate;
            }

            set
            {
                _FireRate = value;
            }
        }
        public Vertex Location
        {
            get
            {
                return _Location;
            }

            set
            {
                _Location = value;
            }
        }
        public Projectile Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }
        public int RandomAngle
        { get => _RandomAngle; set => _RandomAngle = value; }
        public Weapon()
        {
            this._Active = true;
            this._RandomAngle = 0;
            this._Ammo = -1;
            this._FireRate = 10;
            this._Location = new Vertex();
            this._Type = new Projectile();
        }
        public Weapon(Weapon Old)
        {
            this._Active = Old._Active;
            this._RandomAngle = Old._RandomAngle;
            this._Ammo = Old.Ammo;
            this._FireRate = Old._FireRate;
            this._Location = Old._Location;
            this._Type = Old._Type;
        }
        private List<Projectile> ShootProjectiles(Object Owner, long TimeStamp, Vertex Location)
        {
            List<Projectile> Projectiles = new List<Projectile>();
            if (!this._Active) return Projectiles;
            if (this._Ammo == 0) return Projectiles;
            if (TimeStamp % this._FireRate != 0) return Projectiles;
            if (this._Type.Type == ProjectileType.PidgeonLaser)
            {
                for (int i = 0; i < 50; i++)
                {
                    Projectile P = new Projectile(this._Type);
                    Vertex Offset = new Vertex(this._Location.X, this._Location.Y + i * 30);
                    Offset = Offset.RotateZ(Owner.ShootDirection());
                    P.Location = Location + Offset;
                    P.Owner = Owner.Owner;
                    P.Facing = Owner.ShootDirection();
                    Projectiles.Add(P);
                }
                if (this._Ammo != -1) Ammo--;
            }
            else if (this._Type.Type == ProjectileType.Angled)
            {
                Projectile P = new Projectile(this._Type);
                Vertex Offset = this._Location.RotateZ(Owner.ShootDirection());
                P.Location = Location + Offset;
                P.Owner = Owner.Owner;
                Random Rand = new Random();
                P.Facing = Owner.ShootDirection() + Rand.Next(-_RandomAngle, RandomAngle);
                if (this._Ammo != -1) Ammo--;
                Projectiles.Add(P);
            }
            else
            {
                Projectile P = new Projectile(this._Type);
                Vertex Offset = this._Location.RotateZ(Owner.ShootDirection());
                P.Location = Location + Offset;
                P.Owner = Owner.Owner;
                P.Facing = Owner.ShootDirection();
                if (this._Ammo != -1) Ammo--;
                Projectiles.Add(P);
                if(P.Behave.Type == BehaviourType.Follower)
                {
                    ((FollowerBehaviour)(P.Behave)).Followed = Owner;
                    Owner.Behave.Sight = 1000;
                    Owner.Behave.Radius = 0;
                }
            }
            return Projectiles;
        }
        public List<Projectile> Shoot(Object Owner, long TimeStamp)
        {
            return ShootProjectiles(Owner, TimeStamp, Owner.Location);
        }
        public List<Projectile> Shoot(Object Owner, long TimeStamp, Vertex Location)
        {
            return ShootProjectiles(Owner, TimeStamp, Location);
        }
    }
}
