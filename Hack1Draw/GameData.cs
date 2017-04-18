using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeon.Draw
{
    public class GameData
    {
        public GameData()
        {
            this.Players = new List<Item>();
            this.NPCs = new List<Item>();
            this.Projectiles = new List<Item>(); ;
            this.Effects = new List<Item>();
            this.PowerUps = new List<Item>();
        }
        public int CurrentPlayer = 0;
        public List<Item> Players;
        public List<Item> NPCs;
        public List<Item> Projectiles;
        public List<Item> Effects;
        public List<Item> PowerUps;
        public List<Item> PlayersBuffer;
        public List<Item> NPCsBuffer;
        public List<Item> ProjectilesBuffer;
        public List<Item> EffectsBuffer;
        public List<Item> PowerUpsBuffer;
    }
}
