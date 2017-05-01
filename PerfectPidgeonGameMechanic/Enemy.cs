using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Enemy : Object
    {
        private List<Weapon> _Guns;  
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
            this._Guns = new List<Weapon>();
        }
        public Enemy(Enemy Old) : base(Old)
        {
            this._Guns = new List<Weapon>();
            for (int i = 0; i < Old._Guns.Count; i++) this._Guns.Add(new Weapon(Old._Guns[i]));
        }
    }
}
