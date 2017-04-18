using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic.LevelData
{
    public class StaticBackground : Background
    {
        public StaticBackground(string Path)
        {
            this.Type = BackgroundType.Static;
            this.Path = Path;
        }
    }
}
