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
            this.Other = 1;
        }
        public Background(string Path, BackgroundType Type, int Other)
        {
            this.Type = Type;
            this.Path = Path;
            this.Other = Other;
        }
        private int _Other;
        private string _Path;
        private BackgroundType _Type;
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
        public int Other
        {
            get
            {
                return _Other;
            }

            set
            {
                _Other = value;
            }
        }
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
