using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Player : Object
    {
        private int _SpecialAmmo;
        private int _SpeedBoostTimer;
        private double _SpeedBoost;
        private Vertex _NextLocation;
        public int SpecialAmmo
        {
            get { return _SpecialAmmo; }
            set { _SpecialAmmo = value; }
        }
        public int SpeedBoostTimer
        {
            get { return _SpeedBoostTimer; }
            set { _SpeedBoostTimer = value; }
        }
        public double SpeedBoost
        {
            get { return _SpeedBoost; }
            set { _SpeedBoost = value; }
        }
        public Vertex NextLocation
        {
            get { return _NextLocation; }
            set { _NextLocation = value; }
        }
    }
}
