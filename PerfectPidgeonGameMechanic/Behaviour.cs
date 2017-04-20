using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Behaviour
    {
        private int _Sight;
        private int _Radius;
        public int Sight
        {
            get
            {
                return _Sight;
            }

            set
            {
                _Sight = value;
            }
        }
        public int Radius
        {
            get
            {
                return _Radius;
            }

            set
            {
                _Radius = value;
            }
        }
        public Behaviour()
        {
            this._Sight = 1000;
            this._Radius = 500;
        }
        public Behaviour(Behaviour Old)
        {
            this._Sight = Old._Sight;
            this._Radius = Old._Radius;
        }
    }
}
