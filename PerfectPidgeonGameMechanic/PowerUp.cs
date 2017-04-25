using PerfectPidgeon.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public enum PowerUpType
    {
        PidgeonHeavy = 2,
        PidgeonLaser = 3,
        PidgeonPlazma = 4,
        Health = 0,
        Speed = 1
    }
    public class PowerUp
    {
        private int _Duration_Ammo;
        private double _Boost;
        private PowerUpType _Type;
        private Vertex _Location;
        public PowerUpType Type
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
        public PowerUp(Vertex Location, PowerUpType Type, int duration, double boost)
        {
            _Type = Type;
            _Duration_Ammo = duration;
            _Boost = boost;
            _Location = Location;
        }
    }
}
