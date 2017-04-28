using PerfectPidgeon.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Boss : Enemy
    {
        private List<Vertex> _Offsets;
        private List<Enemy> _Auxes;
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
        public Boss() : base()
        {
            this._Auxes = new List<Enemy>();
            this._Offsets = new List<Vertex>();
        }
        public Boss(Boss Old) : base(Old)
        {
            this._Auxes = new List<Enemy>();
            for (int i = 0; i < Old._Auxes.Count; i++) this._Auxes.Add(new Enemy(Old.Auxes[i]));
            this._Offsets = new List<Vertex>();
            for (int i = 0; i < Old._Offsets.Count; i++) this._Offsets.Add(new Vertex(Old._Offsets[i]));
        }
    }
}
