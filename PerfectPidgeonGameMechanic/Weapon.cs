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
            this._Location = new Vertex();
            this._Type = new Projectile();
        }
        public Weapon(Weapon Old)
        {
            this._Active = Old._Active;
            this._Ammo = Old.Ammo;
            this._Location = Old._Location;
            this._Type = Old._Type;
        }
        public List<Projectile> Shoot(Object Owner)
        {
            List<Projectile> Projectiles = new List<Projectile>();
            if (!this._Active) return Projectiles;
            if (this._Ammo == -1) return Projectiles;
            if (this._Type.Type != ProjectileType.PidgeonLaser)
            {
                Projectile P = new Projectile(this._Type);
                Vertex Offset = this._Location.RotateZ(Owner.Facing);
                P.Location = Owner.Location + Offset;
                P.Facing = Owner.Facing;
                Ammo--;
                Projectiles.Add(P);
            }
            else
            {
                for (int i = 0; i < 30; i++)
                {
                    Projectile P = new Projectile(this._Type);
                    Vertex Offset = new Vertex(this._Location.X, this._Location.Y + i * 50);
                    Offset = this._Location.RotateZ(Owner.Facing);
                    P.Location = Owner.Location + Offset;
                    P.Facing = Owner.Facing;
                    Ammo--;
                    Projectiles.Add(P);
                }
            }
            return Projectiles;
        }
    }
}
