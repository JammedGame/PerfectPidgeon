using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Boss : Enemy
    {
        private List<Enemy> _Auxes;
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
        }
        public Boss(Boss Old) : base(Old)
        {
            this._Auxes = new List<Enemy>();
            for (int i = 0; i < Old._Auxes.Count; i++) this._Auxes.Add(new Enemy(Old.Auxes[i]));
        }
    }
}
