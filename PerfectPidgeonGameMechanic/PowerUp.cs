using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class PowerUp
    {
        private int _Type;
        private int _Duration_Ammo;
        private double _Boost;
        private Vertex _Location;
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public int Duration_Ammo
        {
            get { return _Duration_Ammo; }
            set { _Duration_Ammo = value; }
        }
        public double Boost
        {
            get { return _Boost; }
            set { _Boost = value; }
        }
        public Vertex Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
        public PowerUp(Vertex Location, int type, int duration, double boost)
        {
            _Type = type;
            _Duration_Ammo = duration;
            _Boost = boost;
            _Location = Location;
        }
    }
}
