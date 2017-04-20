using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfectPidgeonGameMechanic.LevelData;

namespace PerfectPidgeonGameMechanic
{
    public class Level
    {
        private Background _Back;
        private List<Enemy> _Enemies;
        public Background Back
        {
            get
            {
                return _Back;
            }

            set
            {
                _Back = value;
            }
        }
        public List<Enemy> Enemies
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
        public Level()
        {
            this._Back = new Background("", BackgroundType.Static);
            this._Enemies = new List<Enemy>();
        }
    }
}
