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
        private Behaviour _AdditionalBehaviour;
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
        public Behaviour AdditionalBehaviour { get => _AdditionalBehaviour; set => _AdditionalBehaviour = value; }
        public Enemy() : base ()
        {
            this._Type = EnemyType.Basic;
            this._Guns = new List<Weapon>();
        }
        public Enemy(Enemy Old) : base(Old)
        {
            this._Type = Old._Type;
            this._Guns = new List<Weapon>();
            if (Old._AdditionalBehaviour != null)
            {
                if (Old.AdditionalBehaviour.Type == BehaviourType.Effective)
                {
                    this._AdditionalBehaviour = new EffectiveBehaviour((EffectiveBehaviour)Old._AdditionalBehaviour);
                }
                else if (Old.AdditionalBehaviour.Type == BehaviourType.Aux)
                {
                    this._AdditionalBehaviour = new AuxBehaviour((AuxBehaviour)Old._AdditionalBehaviour);
                }
                else if (Old.AdditionalBehaviour.Type == BehaviourType.Follower)
                {
                    this._AdditionalBehaviour = new FollowerBehaviour((FollowerBehaviour)Old._AdditionalBehaviour, this);
                }
                else
                {
                    this._AdditionalBehaviour = new Behaviour(Old._AdditionalBehaviour);
                }
            }
            for (int i = 0; i < Old._Guns.Count; i++) this._Guns.Add(new Weapon(Old._Guns[i]));
        }
    }
}
