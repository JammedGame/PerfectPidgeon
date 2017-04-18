using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic.LevelData
{
    public class DynamicBackground : Background
    {
        public DynamicBackground(string Path)
        {
            this.Type = BackgroundType.Dynamic;
            this.Path = Path;
        }
    }
}
