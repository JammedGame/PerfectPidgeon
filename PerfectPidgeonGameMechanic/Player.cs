﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Player : Object
    {
        private int _CurrentWeapons;
        private int _SpeedBoostTimer;
        private double _SpeedBoost;
        private Vertex _NextLocation;
        private List<Weapon> _Guns;
        public int CurrentWeapons
        {
            get
            {
                return _CurrentWeapons;
            }

            set
            {
                _CurrentWeapons = value;
            }
        }
        public int SpeedBoostTimer
        {
            get { return _SpeedBoostTimer; }
            set { _SpeedBoostTimer = value; }
        }
        public double SpeedBoost
        {
            get { return _SpeedBoost; }
            set { _SpeedBoost = value; }
        }
        public Vertex NextLocation
        {
            get { return _NextLocation; }
            set { _NextLocation = value; }
        }
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
        public Player() : base()
        {
            this._SpeedBoostTimer = 0;
            this._SpeedBoost = 1;
            this._NextLocation = null;
            this._Guns = new List<Weapon>();
        }
        public Player(Player Old) : base(Old)
        {
            this._SpeedBoostTimer = Old._SpeedBoostTimer;
            this._SpeedBoost = Old._SpeedBoost;
            this._NextLocation = Old._NextLocation;
            this._Guns = new List<Weapon>();
            for (int i = 0; i < Old._Guns.Count; i++) this._Guns.Add(new Weapon(Old._Guns[i]));
        }
        public void SelectWeapon(int Index)
        {
            this._CurrentWeapons = Index;
            for (int i = 0; i < this._Guns.Count; i++) this._Guns[i].Active = false;
            this._Guns[Index].Active = true;
            this._Guns[Index + 1].Active = true;
        }
        public void AddAmmo(int Ammount, ProjectileType Type)
        {
            for (int i = 0; i < this._Guns.Count; i++) if (this._Guns[i].Type.Type == Type) this._Guns[i].Ammo += Ammount;
        }
    }
}
