using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class NPC
    {
        private int _Health;
        private int _MaxHealth;
        private int _ArtIndex;
        private double _Speed;
        private double _Facing;
        private double _Range;
        private double _Sight;
        private Vertex _Location;
        private int _ProjectileType;
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
        public int ProjectileType
        {
            get { return _ProjectileType; }
            set { _ProjectileType = value; }
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
        public double Range
        {
            get { return _Range; }
            set { _Range = value; }
        }
        public double Sight
        {
            get { return _Sight; }
            set { _Sight = value; }
        }
        public Vertex Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
    }
}
