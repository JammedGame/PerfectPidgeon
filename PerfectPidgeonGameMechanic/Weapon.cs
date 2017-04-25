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
        public Weapon()
        {
            this._Active = true;
            this._Ammo = -1;
            this._FireRate = 10;
            this._Location = new Vertex();
            this._Type = new Projectile();
        }
        public Weapon(Weapon Old)
        {
            this._Active = Old._Active;
            this._Ammo = Old.Ammo;
            this._FireRate = Old._FireRate;
            this._Location = Old._Location;
            this._Type = Old._Type;
        }
        public List<Projectile> Shoot(Object Owner, long TimeStamp)
        {
            if(Owner.Owner == 0 && this._Type.Type != ProjectileType.PidgeonGun)
            {
                int y = 4;
            }
            List<Projectile> Projectiles = new List<Projectile>();
            if (!this._Active) return Projectiles;
            if (this._Ammo == 0) return Projectiles;
            if (TimeStamp % this._FireRate != 0) return Projectiles;
            if (this._Type.Type != ProjectileType.PidgeonLaser)
            {
                Projectile P = new Projectile(this._Type);
                Vertex Offset = this._Location.RotateZ(Owner.ShootDirection());
                P.Location = Owner.Location + Offset;
                P.Owner = Owner.Owner;
                P.Facing = Owner.ShootDirection();
                if (this._Ammo != -1) Ammo--;
                Projectiles.Add(P);
            }
            else
            {
                for (int i = 0; i < 50; i++)
                {
                    Projectile P = new Projectile(this._Type);
                    Vertex Offset = new Vertex(this._Location.X, this._Location.Y + i * 50);
                    Offset = Offset.RotateZ(Owner.ShootDirection());
                    P.Location = Owner.Location + Offset;
                    P.Owner = Owner.Owner;
                    P.Facing = Owner.ShootDirection();
                    Projectiles.Add(P);
                }
                if (this._Ammo != -1) Ammo--;
            }
            return Projectiles;
        }
    }
}
