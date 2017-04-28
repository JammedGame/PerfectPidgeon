using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public enum ProjectileType
    {
        PidgeonGun,
        PidgeonHeavy,
        PidgeonLaser,
        PidgeonPlazma,
        AlienBasic,
        AlienSpeeder,
        AlienMine,
        AlienMineField,
        AlienField,
        AlienBeamer,
        AlienMothershipLaser,
        ElvenArrow,
        ElvenIcebolt,
        ElvenTendrils,
        ElvenFirebolt,
        ElvenSpear,
        ElvenBlast
    }
    public class Projectile : Object
    {
        private int _Damage;
        private int _Spin;
        private ProjectileType _Type;
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
        public Projectile() : base()
        {
            this._Damage = 0;
            this._Spin = 0;
            this._Type = ProjectileType.PidgeonGun;
            this.HitRadius = 30;
        }
        public Projectile(Projectile Old) : base(Old)
        {
            this._Damage = Old._Damage;
            this._Spin = Old._Spin;
            this._Type = Old._Type;
        }
    }
}
