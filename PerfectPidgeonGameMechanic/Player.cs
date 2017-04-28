using PerfectPidgeon.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Player : Object
    {
        private int _CurrentWeapons;
        private double _GunRotation;
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
        public double GunRotation
        {
            get
            {
                return _GunRotation;
            }

            set
            {
                _GunRotation = value;
            }
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
            this._NextLocation = null;
            this.Buffs = new List<Buff>();
            this._Guns = new List<Weapon>();
        }
        public Player(Player Old) : base(Old)
        {
            this._NextLocation = Old._NextLocation;
            this._Guns = new List<Weapon>();
            for (int i = 0; i < Old._Guns.Count; i++) this._Guns.Add(new Weapon(Old._Guns[i]));
        }
        public void SelectWeapon(int Index)
        {
            this._CurrentWeapons = Index;
            for (int i = 0; i < this._Guns.Count; i++) this._Guns[i].Active = false;
            this._Guns[Index*2].Active = true;
            this._Guns[Index*2 + 1].Active = true;
        }
        public void AddAmmo(int Ammount, ProjectileType Type)
        {
            for (int i = 0; i < this._Guns.Count; i++) if (this._Guns[i].Type.Type == Type) this._Guns[i].Ammo += Ammount;
        }
        public void IsActiveEmpty()
        {
            if (this._Guns[this._CurrentWeapons * 2].Ammo == 0 && this._Guns[this._CurrentWeapons * 2 + 1].Ammo == 0) SelectWeapon(0);
        }
        public int CurrentAmmo()
        {
            return this._Guns[this._CurrentWeapons * 2].Ammo + this._Guns[this._CurrentWeapons * 2 + 1].Ammo;
        }
        public override double ShootDirection()
        {
            return this.Facing + this._GunRotation;
        }
    }
}
