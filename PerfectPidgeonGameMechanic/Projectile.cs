using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public enum ProjectileType
    {
        Ordinary,
        Angled,
        PidgeonGun,
        PidgeonHeavy,
        PidgeonLaser,
        PidgeonPlazma
    }
    public class Projectile : Object
    {
        private bool _Overdrawn;
        private int _Damage;
        private int _Spin;
        private int _SpinRate;
        private ProjectileType _Type;
        private List<Summon> _Summons;
        public int Damage
        {
            get { return _Damage; }
            set { _Damage = value; }
        }
        public int Spin
        {
            get
            {
                return _Spin;
            }

            set
            {
                _Spin = value;
            }
        }
        public ProjectileType Type
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
        public List<Summon> Summons { get => _Summons; set => _Summons = value; }
        public int SpinRate { get => _SpinRate; set => _SpinRate = value; }
        public bool Overdrawn { get => _Overdrawn; set => _Overdrawn = value; }

        public Projectile() : base()
        {
            this._Overdrawn = false;
            this._Damage = 0;
            this._Spin = 0;
            this._SpinRate = 0;
            this._Type = ProjectileType.Ordinary;
            this.HitRadius = 30;
            this._Summons = new List<Summon>();
        }
        public Projectile(Projectile Old) : base(Old)
        {
            this._Overdrawn = Old._Overdrawn;
            this._Damage = Old._Damage;
            this._Spin = Old._Spin;
            this._SpinRate = Old._SpinRate;
            this._Type = Old._Type;
            this._Summons = new List<Summon>();
            for (int i = 0; i < Old._Summons.Count; i++) this._Summons.Add(new Summon(Old._Summons[i]));
        }
    }
}
