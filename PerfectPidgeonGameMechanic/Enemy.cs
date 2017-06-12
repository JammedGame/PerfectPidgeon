using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public enum EnemyType
    {
        Basic = 0,
        Grouped = 1,
        Aux = 2
    }
    public class Enemy : Object
    {
        private EnemyType _Type;
        private List<Weapon> _Guns;
        public EnemyType Type
        { get => _Type; set => _Type = value; }
        public List<Weapon> Guns
        {
            get
            {
                return _Guns;
            }

            set
            {
                _Guns = value;
            }
        }
        public Enemy() : base ()
        {
            this._Type = EnemyType.Basic;
            this._Guns = new List<Weapon>();
        }
        public Enemy(Enemy Old) : base(Old)
        {
            this._Type = Old._Type;
            this._Guns = new List<Weapon>();
            for (int i = 0; i < Old._Guns.Count; i++) this._Guns.Add(new Weapon(Old._Guns[i]));
        }
    }
}
