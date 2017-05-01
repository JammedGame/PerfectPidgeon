using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Behaviour
    {
        private bool _Linear;
        private bool _Sustainable;
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
        public bool Linear { get => _Linear; set => _Linear = value; }
        public bool Sustainable { get => _Sustainable; set => _Sustainable = value; }
        public Behaviour()
        {
            this._Linear = false;
            this._Sustainable = false;
            this._Sight = 1000;
            this._Radius = 500;
        }
        public Behaviour(Behaviour Old)
        {
            this._Linear = Old._Linear;
            this._Sustainable = Old._Sustainable;
            this._Sight = Old._Sight;
            this._Radius = Old._Radius;
        }
    }
}
