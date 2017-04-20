using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Effect
    {
        private int _ArtIndex;
        private int _ImageIndex;
        private int _Lifetime;
        private Vertex _Location;
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
        public int Lifetime
        {
            get { return _Lifetime; }
            set { _Lifetime = value; }
        }
        public Vertex Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
    }
}
