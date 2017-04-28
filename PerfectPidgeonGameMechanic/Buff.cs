using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public enum BuffType
    {
        SpeedEffect,
        WeaponMalfunction,
        DamageOverTime
    }
    public class Buff
    {
        private double _Amount;
        private long _Duration;
        private BuffType _Type;
        public double Amount { get => _Amount; set => _Amount = value; }
        public long Duration { get => _Duration; set => _Duration = value; }
        public BuffType Type { get => _Type; set => _Type = value; }
        public Buff()
        {
            this._Amount = 1;
            this._Duration = 10;
        }
        public Buff(BuffType Type, double Amount, long Duration)
        {
            this._Amount = Amount;
            this._Duration = Duration;
            this._Type = Type;
        }
        public Buff(Buff Old)
        {
            this._Amount = Old._Amount;
            this._Duration = Old._Duration;
            this._Type = Old._Type;
        }
    }
}
