using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic.LevelData
{
    public enum BackgroundType
    {
        Static = 0,
        Dynamic = 1
    }
    public class Background
    {
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
