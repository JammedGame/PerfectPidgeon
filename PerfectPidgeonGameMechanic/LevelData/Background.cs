using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic.LevelData
{
    public enum BackgroundType
    {
        Static = 0,
        Dynamic = 1,
        Tiled = 2
    }
    public class Background
    {
        public Background(string Path, BackgroundType Type)
        {
            this.Type = Type;
            this.Path = Path;
        }
        private string _Path;
        public string Path
        {
            get
            {
                return _Path;
            }

            set
            {
                _Path = value;
            }
        }
        private BackgroundType _Type;
        public BackgroundType Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }
    }
}
