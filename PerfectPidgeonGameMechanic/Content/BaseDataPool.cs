using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfectPidgeonGameMechanic;
using PerfectPidgeonGameMechanic.LevelData;

namespace PerfectPidgeonGameMechanic.Content
{
    public class BaseDataPool
    {
        private Player _Pidgeon;
        private Dictionary<string, Enemy> _Enemies;
        private Dictionary<string, PowerUp> _PowerUps;
        private Dictionary<string, Weapon> _Weapons;
        private Dictionary<string, Projectile> _Projectiles;
        private Dictionary<string, Level> _Levels;
        public Player Pidgeon
        {
            get
            {
                return _Pidgeon;
            }

            set
            {
                _Pidgeon = value;
            }
        }
        public Dictionary<string, Enemy> Enemies
        {
            get
            {
                return _Enemies;
            }

            set
            {
                _Enemies = value;
            }
        }
        public Dictionary<string, PowerUp> PowerUps
        {
            get
            {
                return _PowerUps;
            }

            set
            {
                _PowerUps = value;
            }
        }
        public Dictionary<string, Weapon> Weapons
        {
            get
            {
                return _Weapons;
            }

            set
            {
                _Weapons = value;
            }
        }
        public Dictionary<string, Projectile> Projectiles
        {
            get
            {
                return _Projectiles;
            }

            set
            {
                _Projectiles = value;
            }
        }
        public Dictionary<string, Level> Levels
        {
            get
            {
                return _Levels;
            }

            set
            {
                _Levels = value;
            }
        }
        public BaseDataPool()
        {
            Init();
        }
        private void Init()
        {
            InitProjectiles();
            InitWeapons();
            InitPlayer();
            InitEnemies();
            InitLevels();
        }
        private void InitPlayer()
        {
            this._Pidgeon = new Player();
            this._Pidgeon.Location = new Vertex(0, 0);
            this._Pidgeon.Health = 100;
            this._Pidgeon.MaxHealth = 100;
            this._Pidgeon.Facing = 0;
            this._Pidgeon.Speed = 6;
            this._Pidgeon.SpeedBoost = 1;
            this._Pidgeon.SpeedBoostTimer = 0;
            this._Pidgeon.Guns.Add(new Weapon(this._Weapons["Left-Basic"]));
            this._Pidgeon.Guns.Add(new Weapon(this._Weapons["Right-Basic"]));
            this._Pidgeon.Guns.Add(new Weapon(this._Weapons["Left-Heavy"]));
            this._Pidgeon.Guns.Add(new Weapon(this._Weapons["Right-Heavy"]));
            this._Pidgeon.Guns.Add(new Weapon(this._Weapons["Left-Laser"]));
            this._Pidgeon.Guns.Add(new Weapon(this._Weapons["Right-Laser"]));
            this._Pidgeon.Guns.Add(new Weapon(this._Weapons["Left-Plazma"]));
            this._Pidgeon.Guns.Add(new Weapon(this._Weapons["Right-Plazma"]));
        }
        private void InitProjectiles()
        {
            this._Projectiles = new Dictionary<string, Projectile>();
            Projectile P = new Projectile();
            P.Type = ProjectileType.PidgeonGun;
            P.ArtIndex = 0;
            P.Speed = 10;
            P.Damage = 10;
            P.Health = 5000;
            P.MaxHealth = 5000;
            this._Projectiles.Add("Basic", P);
            P = new Projectile();
            P.Type = ProjectileType.PidgeonHeavy;
            P.ArtIndex = 1;
            P.Speed = 15;
            P.Damage = 10;
            P.Health = 5000;
            P.MaxHealth = 5000;
            this._Projectiles.Add("Heavy", P);
            P = new Projectile();
            P.Type = ProjectileType.PidgeonLaser;
            P.ArtIndex = 2;
            P.Speed = 10;
            P.Damage = 5;
            P.Health = 50;
            P.MaxHealth = 50;
            this._Projectiles.Add("Laser", P);
            P = new Projectile();
            P.Type = ProjectileType.PidgeonPlazma;
            P.ArtIndex = 3;
            P.Speed = 6;
            P.Damage = 30;
            P.Health = 2000;
            P.MaxHealth = 2000;
            this._Projectiles.Add("Plazma", P);
            P = new Projectile();
            P.Type = ProjectileType.AlienBasic;
            P.ArtIndex = 10;
            P.Speed = 5;
            P.Damage = 10;
            P.Health = 2000;
            P.MaxHealth = 2000;
            this._Projectiles.Add("AlienBasic", P);
            P = new Projectile();
            P.Type = ProjectileType.AlienSpeeder;
            P.ArtIndex = 11;
            P.Speed = 8;
            P.Damage = 10;
            P.Health = 5000;
            P.MaxHealth = 5000;
            this._Projectiles.Add("AlienSpeeder", P);
            P = new Projectile();
            P.Type = ProjectileType.AlienBeamer;
            P.ArtIndex = 12;
            P.Speed = 2;
            P.Damage = 100;
            P.Health = 5000;
            P.MaxHealth = 5000;
            this._Projectiles.Add("AlienBeamer", P);
        }
        private void InitWeapons()
        {
            this._Weapons = new Dictionary<string, Weapon>();
            Weapon W = new Weapon();
            W.Type = this._Projectiles["Basic"];
            W.Location = new Vertex(38, 75, 0);
            W.Ammo = -1;
            this._Weapons.Add("Left-Basic", W);
            W = new Weapon();
            W.Type = this._Projectiles["Basic"];
            W.Location = new Vertex(-38, 75, 0);
            W.Ammo = -1;
            this._Weapons.Add("Right-Basic", W);
            W = new Weapon();
            W.Active = false;
            W.Type = this._Projectiles["Heavy"];
            W.Location = new Vertex(38, 75, 0);
            W.Ammo = 0;
            this._Weapons.Add("Left-Heavy", W);
            W = new Weapon();
            W.Active = false;
            W.FireRate = 5;
            W.Type = this._Projectiles["Heavy"];
            W.Location = new Vertex(-38, 75, 0);
            W.Ammo = 0;
            this._Weapons.Add("Right-Heavy", W);
            W = new Weapon();
            W.Active = false;
            W.FireRate = 5;
            W.Type = this._Projectiles["Laser"];
            W.Location = new Vertex(38, 75, 0);
            W.Ammo = 0;
            this._Weapons.Add("Left-Laser", W);
            W = new Weapon();
            W.Active = false;
            W.Type = this._Projectiles["Laser"];
            W.Location = new Vertex(-38, 75, 0);
            W.Ammo = 0;
            W.Active = false;
            this._Weapons.Add("Right-Laser", W);
            W = new Weapon();
            W.Active = false;
            W.Type = this._Projectiles["Plazma"];
            W.Location = new Vertex(38, 75, 0);
            W.Ammo = 0;
            W.FireRate = 20;
            W.Active = false;
            this._Weapons.Add("Left-Plazma", W);
            W = new Weapon();
            W.Type = this._Projectiles["Plazma"];
            W.Location = new Vertex(-38, 75, 0);
            W.Ammo = 0;
            W.FireRate = 20;
            W.Active = false;
            this._Weapons.Add("Right-Plazma", W);
            W = new Weapon();
            W.Type = this._Projectiles["AlienBasic"];
            W.Location = new Vertex(0, 100, 0);
            W.Ammo = -1;
            this._Weapons.Add("AlienBasic", W);
            W = new Weapon();
            W.Type = this._Projectiles["AlienSpeeder"];
            W.Location = new Vertex(0, 100, 0);
            W.Ammo = -1;
            W.FireRate = 5;
            this._Weapons.Add("AlienSpeeder", W);
            W = new Weapon();
            W.FireRate = 5;
            W.Type = this._Projectiles["AlienBeamer"];
            W.Location = new Vertex(0, 100, 0);
            W.Ammo = -1;
            this._Weapons.Add("AlienBeamer", W);
        }
        private void InitEnemies()
        {
            this._Enemies = new Dictionary<string, Enemy>();
            Enemy E = new Enemy();
            E.ArtIndex = 2;
            E.Facing = 0;
            E.Health = 100;
            E.MaxHealth = 100;
            E.Speed = 3;
            E.Owner = 1;
            Behaviour B = new Behaviour();
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["AlienBasic"]));
            this._Enemies.Add("AlienBasic", E);
            E = new Enemy();
            E.ArtIndex = 3;
            E.Facing = 0;
            E.Health = 200;
            E.MaxHealth = 200;
            E.Speed = 2;
            E.Owner = 1;
            B = new Behaviour();
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["AlienBasic"]));
            this._Enemies.Add("AlienCaptain", E);
            E = new Enemy();
            E.ArtIndex = 4;
            E.Facing = 0;
            E.Health = 100;
            E.MaxHealth = 100;
            E.Speed = 5;
            E.Owner = 1;
            B = new Behaviour();
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["AlienSpeeder"]));
            this._Enemies.Add("AlienSpeeder", E);
            E = new Enemy();
            E.ArtIndex = 5;
            E.Facing = 0;
            E.Health = 500;
            E.MaxHealth = 500;
            E.Speed = 2;
            E.Owner = 1;
            B = new Behaviour();
            B.Radius = 800;
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["AlienBeamer"]));
            this._Enemies.Add("AlienBeamer", E);
        }
        private void InitLevels()
        {
            this._Levels = new Dictionary<string, Level>();
            Level L = new Level();
            L.Back = new Background("Data\\Town", BackgroundType.Tiled);
            L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            this._Levels.Add("AlienBasic-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town", BackgroundType.Tiled);
            L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            this._Levels.Add("AlienCaptain-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town", BackgroundType.Tiled);
            L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            this._Levels.Add("AlienSpeeder-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town", BackgroundType.Tiled);
            L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            this._Levels.Add("AlienBeamer-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town", BackgroundType.Tiled);
            for(int i = 0; i < 10; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            this._Levels.Add("LVL01", L);
        }
    }
}
