using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic.LevelData
{
    public class StaticBackground : Background
    {
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
        public StaticBackground(string Path)
        {
            this.Type = BackgroundType.Static;
            this.Path = Path;
        }
    }
}
