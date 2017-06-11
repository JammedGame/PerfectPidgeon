using PerfectPidgeon.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Grouped : Enemy
    {
        private int _DependantInvincibility;
        private List<Vertex> _Offsets;
        private List<Enemy> _Auxes;
        private List<double> _Facings;
        public List<Vertex> Offsets
        { get => _Offsets; set => _Offsets = value; }
        public List<Enemy> Auxes
        {
            get
            {
                return _Auxes;
            }

            set
            {
                _Auxes = value;
            }
        }
        public List<double> Facings { get => _Facings; set => _Facings = value; }
        public int DependantInvincibility { get => _DependantInvincibility; set => _DependantInvincibility = value; }
        public Grouped() : base()
        {
            this.Type = EnemyType.Grouped;
            this._DependantInvincibility = -1;
            this._Facings = new List<double>();
            this._Auxes = new List<Enemy>();
            this._Offsets = new List<Vertex>();
        }
        public Grouped(Grouped Old)
        {
            this._DependantInvincibility = Old._DependantInvincibility;
            this._Facings = new List<double>();
            for (int i = 0; i < Old._Facings.Count; i++) this._Facings.Add(Old._Facings[i]);
            this._Auxes = new List<Enemy>();
            for (int i = 0; i < Old._Auxes.Count; i++) this._Auxes.Add(new Enemy(Old.Auxes[i]));
            this._Offsets = new List<Vertex>();
            for (int i = 0; i < Old._Offsets.Count; i++) this._Offsets.Add(new Vertex(Old._Offsets[i]));
        }
    }
}
