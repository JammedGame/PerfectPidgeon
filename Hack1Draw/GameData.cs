using System;
using System.Collections.Generic;
using System.Drawing;
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
        private bool _Working = false;
        private bool _ImageSwitchWorking = false;       
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
        public bool Working
        {
            get
            {
                return _Working;
            }

            set
            {
                _Working = value;
            }
        }
        public bool ImageSwitchWorking
        {
            get
            {
                return _ImageSwitchWorking;
            }

            set
            {
                _ImageSwitchWorking = value;
            }
        }
        public void ImageSwitch(List<SpriteSet> SpriteSets)
        {
            if (this._ImageSwitchWorking) return;
            this._ImageSwitchWorking = true;
            for (int i = 0; i < Players.Count; i++)
            {
                if (SpriteSets[0].Images.Length > 1)
                {
                    Players[i].ImageIndex += Players[i].ImageIndexIncrement;
                    if (Players[i].ImageIndex == SpriteSets[0].Images.Length)
                    {
                        Players[i].ImageIndex = 0;
                    }
                }
            }
            for (int i = 0; i < NPCs.Count; i++)
            {
                if (SpriteSets[NPCs[i].ArtIndex].Images.Length > 1)
                {
                    NPCs[i].ImageIndex += NPCs[i].ImageIndexIncrement;
                    if (NPCs[i].ImageIndex == SpriteSets[NPCs[i].ArtIndex].Images.Length) NPCs[i].ImageIndex = 0;
                }
            }
            this._ImageSwitchWorking = false;
        }
        public void ResetBuffers()
        {
            PlayersBuffer = Players;
            NPCsBuffer = new List<Item>();
            ProjectilesBuffer = new List<Item>();
            EffectsBuffer = new List<Item>();
            PowerUpsBuffer = new List<Item>();
        }
        public void SwapBuffers()
        {
            Players = PlayersBuffer;
            NPCs = NPCsBuffer;
            Projectiles = ProjectilesBuffer;
            Effects = EffectsBuffer;
            PowerUps = PowerUpsBuffer;
        }
        public void UpdateItem(int Type, int Index, int ArtIndex, Point Location, double Facing, double Size)
        {
            if (Type == 0)
            {
                if (PlayersBuffer.Count > Index)
                {
                    if (Index == CurrentPlayer)
                    {
                    }
                    PlayersBuffer[Index].ArtIndex = ArtIndex;
                    PlayersBuffer[Index].Location = Location;
                    PlayersBuffer[Index].Size = Size;
                }
                else PlayersBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
            if (Type == 1)
            {
                if (NPCsBuffer.Count > Index)
                {
                    NPCsBuffer[Index].ArtIndex = ArtIndex;
                    NPCsBuffer[Index].ImageIndex = NPCs[Index].ImageIndex;
                    NPCsBuffer[Index].Location = Location;
                    NPCsBuffer[Index].Facing = Facing;
                    NPCsBuffer[Index].Size = Size;
                }
                else
                {
                    if (NPCs.Count > Index && NPCs[Index] != null) NPCsBuffer.Add(new Item(ArtIndex, Location, Facing, Size, NPCs[Index].ImageIndex));
                    else NPCsBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
                }
            }
            if (Type == 2)
            {
                if (ProjectilesBuffer.Count > Index)
                {
                    ProjectilesBuffer[Index].ArtIndex = ArtIndex;
                    ProjectilesBuffer[Index].Location = Location;
                    ProjectilesBuffer[Index].Facing = Facing;
                    ProjectilesBuffer[Index].Size = Size;
                }
                else ProjectilesBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
            if (Type == 3)
            {
                if (EffectsBuffer.Count > Index)
                {
                    EffectsBuffer[Index].ArtIndex = ArtIndex;
                    EffectsBuffer[Index].Location = Location;
                    EffectsBuffer[Index].Facing = Facing;
                    EffectsBuffer[Index].Size = Size;
                }
                else EffectsBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
            if (Type == 4)
            {
                if (PowerUpsBuffer.Count > Index)
                {
                    PowerUpsBuffer[Index].ArtIndex = ArtIndex;
                    PowerUpsBuffer[Index].Location = Location;
                    PowerUpsBuffer[Index].Facing = Facing;
                    PowerUpsBuffer[Index].Size = Size;
                }
                else PowerUpsBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
        }
        public void UpdateItems(int Type, int[] Index, int[] ArtIndex, Point[] Location, double[] Facing, double[] Size)
        {
            if (this.Working) return;
            this.Working = true;
            for (int i = 0; i < Index.Length; i++)
            {
                UpdateItem(Type, Index[i], ArtIndex[i], Location[i], Facing[i], Size[i]);
            }
            this.Working = false;
        }
    }
}
