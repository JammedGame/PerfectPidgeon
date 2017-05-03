using PerfectPidgeon.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public enum SummonType
    {
        Projectile,
        Enemy
    }
    public enum SummonActivationType
    {
        OnExpire,
        OnHit,
        OnBoth
    }
    public class Summon
    {
        private double _Facing;
        private SummonType _Type;
        private SummonActivationType _Event;
        private Vertex _Location;
        private string _Enemy;
        private Projectile _Projectile;
        public double Facing { get => _Facing; set => _Facing = value; }
        public SummonType Type { get => _Type; set => _Type = value; }
        public Vertex Location { get => _Location; set => _Location = value; }
        public string Enemy { get => _Enemy; set => _Enemy = value; }
        public Projectile Projectile { get => _Projectile; set => _Projectile = value; }
        public SummonActivationType Event { get => _Event; set => _Event = value; }
        public Summon()
        {
            this._Facing = 0;
            this._Type = SummonType.Enemy;
            this._Event = SummonActivationType.OnExpire;
            this._Location = new Vertex();
            this._Enemy = null;
            this._Projectile = null;
        }
        public Summon(Summon Old)
        {
            this._Facing = Old._Facing;
            this._Type = Old._Type;
            this._Event = Old._Event;
            this._Location = Old._Location;
            this._Enemy = Old._Enemy;
            if(Old._Projectile != null) this._Projectile = new Projectile(Old._Projectile);
        }
    }
}
