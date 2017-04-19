using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Projectile : Object
    {
        private int _Damage;
        private int _Owner;
        private int _Spin;
        public int Damage
        {
            get { return _Damage; }
            set { _Damage = value; }
        }
        public int Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
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
    }
}
