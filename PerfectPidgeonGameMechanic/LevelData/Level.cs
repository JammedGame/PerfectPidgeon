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
    }
}
