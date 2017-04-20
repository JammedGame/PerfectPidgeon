using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Object
    {
        private int _Health;
        private int _MaxHealth;
        private int _ArtIndex;
        private int _ImageIndex;
        private int _Owner;
        private double _Speed;
        private double _Facing;
        private Vertex _Location;
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
        public Object()
        {
            this._Health = 100;
            this._MaxHealth = 100;
            this._ArtIndex = 0;
            this._ImageIndex = 0;
            this._Owner = 0;
            this._Speed = 0;
            this._Facing = 0;
            this._Location = new Vertex();
        }
        public Object(Object Old)
        {
            this._Health = Old._Health;
            this._MaxHealth = Old._MaxHealth;
            this._ArtIndex = Old._ArtIndex;
            this._ImageIndex = Old._ImageIndex;
            this._Owner = Old._Owner;
            this._Speed = Old._Speed;
            this._Facing = Old._Facing;
            this._Location = new Vertex(Old._Location);
        }
    }
}
