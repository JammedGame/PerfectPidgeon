using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfectPidgeonGameMechanic;
using PerfectPidgeonGameMechanic.LevelData;
using PerfectPidgeon.Draw;
using System.Drawing;

namespace PerfectPidgeonGameMechanic.Content
{
    public class BaseDataPool
    {
        private Player _Pidgeon;
        private Dictionary<string, Boss> _Bosses;
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
        public Dictionary<string, Boss> Bosses
        {
            get
            {
                return _Bosses;
            }

            set
            {
                _Bosses = value;
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
            P.Paint = Color.Black;
            P.Scale = 0.5;
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
            P.Paint = Color.FromArgb(100,100,100);
            this._Projectiles.Add("AlienSpeeder", P);
            P = new Projectile();
            P.Type = ProjectileType.AlienBeamer;
            P.ArtIndex = 12;
            P.Speed = 2;
            P.Damage = 100;
            P.Health = 5000;
            P.MaxHealth = 5000;
            this._Projectiles.Add("AlienBeamer", P);
            P = new Projectile();
            P.Type = ProjectileType.AlienMine;
            P.ArtIndex = 13;
            P.Speed = 10;
            P.Damage = 0;
            P.Health = 5000;
            P.MaxHealth = 5000;
            this._Projectiles.Add("AlienMine", P);
            P = new Projectile();
            P.Type = ProjectileType.AlienMineField;
            P.ArtIndex = 14;
            P.Speed = 0;
            P.Damage = 1;
            P.Health = 80;
            P.MaxHealth = 80;
            P.HitRadius = 100;
            this._Projectiles.Add("AlienMineField", P);
            P = new Projectile();
            P.Type = ProjectileType.ElvenArrow;
            P.ArtIndex = 16;
            P.Speed = 10;
            P.Damage = 1;
            P.Health = 1000;
            P.MaxHealth = 1000;
            this._Projectiles.Add("ElvenArrow", P);
            P = new Projectile();
            P.Type = ProjectileType.ElvenIcebolt;
            P.ArtIndex = 17;
            P.Speed = 5;
            P.Scale = 1.5;
            P.Damage = 10;
            P.Health = 3000;
            P.MaxHealth = 3000;
            this._Projectiles.Add("ElvenIcebolt", P);
            P = new Projectile();
            P.Type = ProjectileType.ElvenTendrils;
            P.ArtIndex = 18;
            P.Speed = 8;
            P.Scale = 3;
            P.Damage = 1;
            P.Health = 100;
            P.MaxHealth = 100;
            P.HitRadius = 200;
            P.Buffs.Add(new Buff(BuffType.WeaponMalfunction, 0, 200));
            this._Projectiles.Add("ElvenTendrils", P);
            P = new Projectile();
            P.Type = ProjectileType.ElvenFirebolt;
            P.ArtIndex = 19;
            P.Speed = 8;
            P.Scale = 1.5;
            P.Damage = 1;
            P.Health = 3000;
            P.MaxHealth = 3000;
            P.Buffs.Add(new Buff(BuffType.DamageOverTime, 3, 10));
            this._Projectiles.Add("ElvenFirebolt", P);
            P = new Projectile();
            P.Type = ProjectileType.ElvenSpear;
            P.ArtIndex = 20;
            P.Speed = 8;
            P.Damage = 30;
            P.Health = 8000;
            P.MaxHealth = 8000;
            this._Projectiles.Add("ElvenSpear", P);
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
            W.FireRate = 5;
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
            W = new Weapon();
            W.FireRate = 100;
            W.Type = this._Projectiles["AlienMine"];
            W.Location = new Vertex(0, 150, 0);
            W.Ammo = -1;
            this._Weapons.Add("AlienMine", W);
            W = new Weapon();
            W.FireRate = 10;
            W.Type = this._Projectiles["ElvenArrow"];
            W.Location = new Vertex(-10, 100, 0);
            W.Ammo = -1;
            this._Weapons.Add("ElvenBow", W);
            W = new Weapon();
            W.FireRate = 15;
            W.Type = this._Projectiles["ElvenIcebolt"];
            W.Location = new Vertex(-15, 180, 0);
            W.Ammo = -1;
            this._Weapons.Add("ElvenIceStaff", W);
            W = new Weapon();
            W.FireRate = 5;
            W.Type = this._Projectiles["ElvenTendrils"];
            W.Location = new Vertex(-15, 180, 0);
            W.Ammo = -1;
            this._Weapons.Add("ElvenStormStaff", W);
            W = new Weapon();
            W.Type = this._Projectiles["ElvenFirebolt"];
            W.Location = new Vertex(-15, 180, 0);
            W.Ammo = -1;
            this._Weapons.Add("ElvenFireStaff", W);
            W = new Weapon();
            W.FireRate = 20;
            W.Type = this._Projectiles["ElvenSpear"];
            W.Location = new Vertex(-45, 170, 0);
            W.Ammo = -1;
            this._Weapons.Add("ElvenSpearThrower", W);
        }
        private void InitEnemies()
        {
            //Aliens

            Enemy E;
            Behaviour B;
            Boss BO;
            Weapon W;

            this._Enemies = new Dictionary<string, Enemy>();
            this._Bosses = new Dictionary<string, Boss>();
            E = new Enemy();
            E.ArtIndex = 2;
            E.Facing = 0;
            E.Health = 100;
            E.MaxHealth = 100;
            E.Speed = 3;
            E.Owner = 1;
            B = new Behaviour();
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
            E.Health = 1000;
            E.MaxHealth = 1000;
            E.Speed = 2;
            E.Scale = 1.25;
            E.HitRadius = 100;
            E.Owner = 1;
            B = new Behaviour();
            B.Radius = 800;
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["AlienBeamer"]));
            this._Enemies.Add("AlienBeamer", E);
            E = new Enemy();
            E.ArtIndex = 6;
            E.Facing = 0;
            E.Health = 500;
            E.MaxHealth = 500;
            E.Speed = 2;
            E.Owner = 1;
            B = new Behaviour();
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["AlienMine"]));
            this._Enemies.Add("AlienMiner", E);
            //BOSS
            E = new Enemy();
            E.ArtIndex = 10;
            E.Facing = 0;
            E.Health = 3000;
            E.MaxHealth = 3000;
            E.Scale = 1.5;
            E.Speed = 5;
            E.Owner = 1;
            E.HitRadius = 140;
            B = new Behaviour();
            E.Behave = B;
            this._Enemies.Add("AlienMothershipLeftWing", E);
            E = new Enemy();
            E.ArtIndex = 12;
            E.Facing = 0;
            E.Health = 3000;
            E.MaxHealth = 3000;
            E.Scale = 1.5;
            E.Speed = 5;
            E.Owner = 1;
            E.HitRadius = 140;
            B = new Behaviour();
            E.Behave = B;
            this._Enemies.Add("AlienMothershipRightWing", E);
            BO = new Boss();
            BO.ArtIndex = 8;
            BO.Facing = 0;
            BO.Health = 5000;
            BO.MaxHealth = 5000;
            BO.Scale = 1.5;
            BO.Speed = 5;
            BO.Owner = 1;
            BO.HitRadius = 140;
            B = new Behaviour();
            BO.Behave = B;
            BO.Auxes.Add(this.Enemies["AlienMothershipLeftWing"]);
            BO.Auxes.Add(this.Enemies["AlienMothershipRightWing"]);
            BO.Offsets.Add(new Vertex(500, 0));
            BO.Offsets.Add(new Vertex(-500, 0));
            this._Bosses.Add("AlienMothership", BO);

            //Elves

            E = new Enemy();
            E.ArtIndex = 7;
            E.Facing = 0;
            E.Health = 100;
            E.MaxHealth = 100;
            E.Scale = 1.5;
            E.Speed = 3;
            E.Owner = 1;
            B = new Behaviour();
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["ElvenBow"]));
            this._Enemies.Add("ElvenArcher", E);
            E = new Enemy();
            E.ArtIndex = 14;
            E.Facing = 0;
            E.Health = 100;
            E.MaxHealth = 100;
            E.Scale = 1.5;
            E.Speed = 3;
            E.Owner = 1;
            B = new Behaviour();
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["ElvenIceStaff"]));
            this._Enemies.Add("ElvenMageIce", E);
            E = new Enemy();
            E.ArtIndex = 15;
            E.Facing = 0;
            E.Health = 100;
            E.MaxHealth = 100;
            E.Scale = 1.5;
            E.Speed = 3;
            E.Owner = 1;
            B = new Behaviour();
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["ElvenStormStaff"]));
            this._Enemies.Add("ElvenMageStorm", E);
            E = new Enemy();
            E.ArtIndex = 16;
            E.Facing = 0;
            E.Health = 100;
            E.MaxHealth = 100;
            E.Scale = 1.5;
            E.Speed = 3;
            E.Owner = 1;
            B = new Behaviour();
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["ElvenFireStaff"]));
            this._Enemies.Add("ElvenMageFire", E);
            E = new Enemy();
            E.ArtIndex = 17;
            E.Facing = 0;
            E.Health = 100;
            E.MaxHealth = 100;
            E.Scale = 1.2;
            E.Speed = 3;
            E.Owner = 1;
            B = new Behaviour();
            E.Behave = B;
            E.Guns.Add(new Weapon(this._Weapons["ElvenSpearThrower"]));
            this._Enemies.Add("ElvenManticore", E);
        }
        private void InitLevels()
        {
            this._Levels = new Dictionary<string, Level>();

            //Tests
            Level L = new Level();
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            this._Levels.Add("AlienBasic-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            this._Levels.Add("AlienCaptain-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            this._Levels.Add("AlienSpeeder-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town1", BackgroundType.Static);
            L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            this._Levels.Add("AlienBeamer-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            this._Levels.Add("AlienMiner-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town2", BackgroundType.Tiled, 1);
            L.Enemies.Add(new Enemy(this._Enemies["ElvenArcher"]));
            this._Levels.Add("ElvenArcher-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town2", BackgroundType.Tiled, 1);
            L.Enemies.Add(new Enemy(this._Enemies["ElvenMageIce"]));
            this._Levels.Add("ElvenMageIce-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town2", BackgroundType.Tiled, 1);
            L.Enemies.Add(new Enemy(this._Enemies["ElvenMageStorm"]));
            this._Levels.Add("ElvenMageStorm-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town2", BackgroundType.Tiled, 1);
            L.Enemies.Add(new Enemy(this._Enemies["ElvenMageFire"]));
            this._Levels.Add("ElvenMageFire-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town2", BackgroundType.Tiled, 1);
            L.Enemies.Add(new Enemy(this._Enemies["ElvenManticore"]));
            this._Levels.Add("ElvenManticore-Test", L);
            L = new Level();
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            this._Levels.Add("Alien-Test", L);
            
            //Alien Levels
            L = new Level();
            L.MaxSpawns = 10;
            L.FinishCondition = 5;
            L.Title = "1-1";
            L.Next = "LVL02";
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            for (int i = 0; i < 20; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            this._Levels.Add("LVL01", L);
            L = new Level();
            L.MaxSpawns = 12;
            L.FinishCondition = 6;
            L.Title = "1-2";
            L.Next = "LVL03";
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            this._Levels.Add("LVL02", L);
            L = new Level();
            L.MaxSpawns = 15;
            L.FinishCondition = 7;
            L.Title = "1-3";
            L.Next = "LVL04";
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            for (int i = 0; i < 6; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 6; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 6; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 6; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            this._Levels.Add("LVL03", L);
            L = new Level();
            L.MaxSpawns = 15;
            L.FinishCondition = 8;
            L.Title = "1-4";
            L.Next = "LVL05";
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            this._Levels.Add("LVL04", L);
            L = new Level();
            L.MaxSpawns = 18;
            L.FinishCondition = 9;
            L.Title = "1-5";
            L.Next = "LVL06";
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            this._Levels.Add("LVL05", L);
            L = new Level();
            L.MaxSpawns = 20;
            L.FinishCondition = 10;
            L.Title = "1-6";
            L.Next = "LVL07";
            L.Back = new Background("Data\\Town1", BackgroundType.Tiled, 2);
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBasic"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            this._Levels.Add("LVL06", L);
            L = new Level();
            L.MaxSpawns = 22;
            L.FinishCondition = 11;
            L.Title = "1-7";
            L.Next = "LVL08";
            L.Back = new Background("Earth", BackgroundType.Static);
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 1; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            this._Levels.Add("LVL07", L);
            L = new Level();
            L.MaxSpawns = 24;
            L.FinishCondition = 12;
            L.Title = "1-8";
            L.Next = "LVL09";
            L.Back = new Background("Earth", BackgroundType.Static);
            for (int i = 0; i < 7; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            for (int i = 0; i < 7; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            for (int i = 0; i < 7; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 4; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            this._Levels.Add("LVL08", L);
            L = new Level();
            L.MaxSpawns = 25;
            L.FinishCondition = 15;
            L.Title = "1-9";
            L.Next = "LVL11";
            L.Back = new Background("Earth", BackgroundType.Static);
            for (int i = 0; i < 8; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            for (int i = 0; i < 8; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            for (int i = 0; i < 8; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            for (int i = 0; i < 8; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            for (int i = 0; i < 5; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienSpeeder"]));
            for (int i = 0; i < 3; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienMiner"]));
            for (int i = 0; i < 2; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienBeamer"]));
            this._Levels.Add("LVL09", L);
            L = new Level();
            L.MaxSpawns = 4;
            L.FinishCondition = -1;
            L.Title = "1-X";
            L.Next = "LVL11";
            L.Back = new Background("Earth", BackgroundType.Static);
            L.LBoss = new Boss(this._Bosses["AlienMothership"]);
            //for (int i = 0; i < 20; i++) L.Enemies.Add(new Enemy(this._Enemies["AlienCaptain"]));
            this._Levels.Add("LVL10", L);
            L = new Level();
            L.MaxSpawns = 20;
            L.FinishCondition = 15;
            L.Title = "2-1";
            L.Next = "";
            L.Back = new Background("Data\\Town3", BackgroundType.Tiled);
            for (int i = 0; i < 40; i++) L.Enemies.Add(new Enemy(this._Enemies["ElvenArcher"]));
            this._Levels.Add("LVL11", L);
        }
    }
}
