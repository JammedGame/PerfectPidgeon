using PerfectPidgeon.Draw;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Object
    {
        private bool _Disabled;
        private int _Health;
        private int _MaxHealth;
        private int _ArtIndex;
        private int _ImageIndex;
        private int _Owner;
        private int _HitRadius;
        private int _ActiveHitRadius;
        private double _Scale;
        private double _Speed;
        private double _Facing;
        private double _ActiveScale;
        private double _ActiveSpeed;
        private Vertex _Location;
        private Color _Paint;
        private Behaviour _Behave;
        private List<Buff> _Buffs;
        public int Health
        {
            get { return _Health; }
            set { _Health = value; }
        }
        public int MaxHealth
        {
            get { return _MaxHealth; }
            set { _MaxHealth = value; }
        }
        public int ArtIndex
        {
            get { return _ArtIndex; }
            set { _ArtIndex = value; }
        }
        public int ImageIndex
        {
            get
            {
                return _ImageIndex;
            }

            set
            {
                _ImageIndex = value;
            }
        }
        public int Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }
        public int HitRadius
        {
            get
            {
                return _HitRadius;
            }

            set
            {
                _HitRadius = value;
            }
        }
        public double Scale
        {
            get
            {
                return _Scale;
            }

            set
            {
                _Scale = value;
            }
        }
        public double Speed
        {
            get { return _Speed; }
            set { _Speed = value; }
        }
        public double Facing
        {
            get { return _Facing; }
            set { _Facing = value; }
        }
        public Vertex Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
        public Color Paint
        {
            get
            {
                return _Paint;
            }

            set
            {
                _Paint = value;
            }
        }
        public Behaviour Behave
        {
            get
            {
                return _Behave;
            }

            set
            {
                _Behave = value;
            }
        }
        public List<Buff> Buffs
        { get => _Buffs; set => _Buffs = value; }
        public bool Disabled { get => _Disabled; set => _Disabled = value; }
        public int ActiveHitRadius { get => _ActiveHitRadius; set => _ActiveHitRadius = value; }
        public double ActiveScale { get => _ActiveScale; set => _ActiveScale = value; }
        public double ActiveSpeed { get => _ActiveSpeed; set => _ActiveSpeed = value; }
        public Object()
        {
            this._Health = 100;
            this._MaxHealth = 100;
            this._ArtIndex = 0;
            this._ImageIndex = 0;
            this._HitRadius = 50;
            this._Owner = 0;
            this._Scale = 1;
            this._Speed = 0;
            this._Facing = 0;
            this._Location = new Vertex();
            this._Paint = Color.White;
            this._Behave = new Behaviour();
            this._Buffs = new List<Buff>();
        }
        public Object(Object Old)
        {
            this._Health = Old._Health;
            this._MaxHealth = Old._MaxHealth;
            this._ArtIndex = Old._ArtIndex;
            this._ImageIndex = Old._ImageIndex;
            this._HitRadius = Old._HitRadius;
            this._Owner = Old._Owner;
            this._Scale = Old._Scale;
            this._Speed = Old._Speed;
            this._Facing = Old._Facing;
            this._Location = new Vertex(Old._Location);
            this._Paint = Old._Paint;
            this._Behave = new Behaviour(Old._Behave);
            this._Buffs = new List<Buff>();
            for (int i = 0; i < Old.Buffs.Count; i++) this._Buffs.Add(Old.Buffs[i]);
        }
        public virtual void ApplyBuffs(long TimeStamp)
        {
            this.Disabled = false;
            this.ActiveHitRadius = this._HitRadius;
            this.ActiveScale = this._Scale;
            this.ActiveSpeed = this._Speed;
            for(int i = this._Buffs.Count - 1; i >= 0; i--)
            {
                if (this._Buffs[i].Duration == 0)
                {
                    this._Buffs.RemoveAt(i);
                    continue;
                }
                
                if (this._Buffs[i].Type == BuffType.DamageOverTime)
                {
                    if (TimeStamp % 6 == 0)
                    {
                        this._Health -= (int)this._Buffs[i].Amount;
                        if (this._Health <= 0) this._Health = 1;
                        this._Buffs[i].Duration--;
                    }
                }
                else
                {
                    this._Buffs[i].Duration--;
                    if (this._Buffs[i].Type == BuffType.SpeedEffect)
                    {
                        this.ActiveSpeed = this._Buffs[i].Amount * this._Speed;
                    }
                    else if (this._Buffs[i].Type == BuffType.WeaponMalfunction)
                    {
                        this.Disabled = true;
                    }
                }
            }
        }
        public virtual double ShootDirection()
        {
            return this._Facing;
        }
    }
}
