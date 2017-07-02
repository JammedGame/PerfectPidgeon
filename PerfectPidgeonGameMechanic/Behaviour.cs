using PerfectPidgeon.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public enum BehaviourType
    {
        Basic,
        Effective,
        Follower,
        Aux
    }
    public class Behaviour
    {
        private bool _Linear;
        private bool _Sustainable;
        private int _Sight;
        private int _Radius;
        private BehaviourType _Type;
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
        public BehaviourType Type { get => _Type; set => _Type = value; }
        public Behaviour()
        {
            this._Type = BehaviourType.Basic;
            this._Linear = false;
            this._Sustainable = false;
            this._Sight = 1000;
            this._Radius = 500;
        }
        public Behaviour(Behaviour Old)
        {
            this._Type = Old._Type;
            this._Linear = Old._Linear;
            this._Sustainable = Old._Sustainable;
            this._Sight = Old._Sight;
            this._Radius = Old._Radius;
        }
    }
    public class EffectiveBehaviour : Behaviour
    {
        private int _MagneticField;
        public int MagneticField { get => _MagneticField; set => _MagneticField = value; }
        public EffectiveBehaviour() : base()
        {
            this.Type = BehaviourType.Effective;
            this._MagneticField = 0;
        }
        public EffectiveBehaviour(EffectiveBehaviour Old) : base(Old)
        {
            this._MagneticField = Old._MagneticField;
        }
    }
    public class FollowerBehaviour : Behaviour
    {
        private bool _Rotate;
        private Vertex _Offset;
        private Object _Followed;
        public Object Followed { get => _Followed; set => _Followed = value; }
        public Vertex Offset { get => _Offset; set => _Offset = value; }
        public bool Rotate { get => _Rotate; set => _Rotate = value; }
        public FollowerBehaviour() : base()
        {
            this._Offset = new Vertex();
            this.Type = BehaviourType.Follower;
            this._Followed = null;
            this._Rotate = false;
        }
        public FollowerBehaviour(FollowerBehaviour Old, Object Followed) : base(Old)
        {
            this._Rotate = Old._Rotate;
            this._Offset = Old._Offset;
            this._Followed = Followed;
        }
    }
    public class AuxBehaviour : Behaviour
    {
        private bool _Merged;
        private int _MergeChance;
        private Vertex _Offset;
        private Grouped _MergeTarget;
        private List<Grouped> _Ignored;
        public bool Merged { get => _Merged; set => _Merged = value; }
        public int MergeChance { get => _MergeChance; set => _MergeChance = value; }
        public Grouped MergeTarget { get => _MergeTarget; set => _MergeTarget = value; }
        public List<Grouped> Ignored { get => _Ignored; set => _Ignored = value; }
        public Vertex Offset { get => _Offset; set => _Offset = value; }
        public AuxBehaviour() : base()
        {
            this.Type = BehaviourType.Aux;
            this._MergeChance = 40;
            this._Merged = false;
            this._MergeTarget = null;
            this._MergeChance = 60;
            this._Offset = new Vertex();
            this._Ignored = new List<Grouped>();
        }
        public AuxBehaviour(AuxBehaviour Old) : base(Old)
        {
            this.Type = BehaviourType.Aux;
            this._MergeChance = Old._MergeChance;
            this._Merged = false;
            this._MergeTarget = null;
            this._Offset = new Vertex();
            this._MergeChance = Old.MergeChance;
            this._Ignored = new List<Grouped>();
        }
        public Enemy Update(Enemy ThisEnemy, List<Enemy> Enemies)
        {
            if(ThisEnemy.Type == EnemyType.Grouped)
            {
                Grouped GE = (Grouped)ThisEnemy;
                if (GE.AuxCandidates.Count > 0) return ThisEnemy;
            }
            if(Merged)
            {
                if (_MergeTarget.Location == null && ThisEnemy.Location != null)
                {
                    _MergeTarget = null;
                    _Merged = false;
                    ThisEnemy.Type = EnemyType.Grouped;
                    return ThisEnemy;
                }
                else return null;
            }
            else
            {
                if (this._MergeTarget != null)
                {
                    if (_MergeTarget.Location == null && ThisEnemy.Location != null)
                    {
                        _MergeTarget = null;
                    }
                    this._Merged = this._MergeTarget.Attach(ThisEnemy, this._Offset);
                    if (this._Merged) return null;
                }
                else
                {
                    for (int i = 0; i < Enemies.Count; i++)
                    {
                        if (Enemies[i] == ThisEnemy) continue;
                        if (Enemies[i].Type == EnemyType.Grouped)
                        {
                            Grouped GE = (Grouped)Enemies[i];
                            if (GE == null) continue;
                            if (this._Ignored.Contains(GE)) continue;
                            Random R = new Random();
                            int Result = R.Next(0, 100);
                            if (Result < this._MergeChance)
                            {
                                bool Find = GE.TryFindVariant(ThisEnemy);
                                if (Find) ThisEnemy.Type = EnemyType.Aux;
                                break;
                            }
                            else this._Ignored.Add(GE);
                        }
                    }
                }
                return ThisEnemy;
            }
        }
    }
}
