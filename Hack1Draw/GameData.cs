using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PerfectPidgeon.Draw
{
    public enum GameDataType
    {
        Player,
        Enemy,
        Projectile,
        Effect,
        PowerUp
    }
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
        public void UpdateItem(GameDataType Type, int Index, int ArtIndex, int ImageIndex, int Other, double Facing, double Size, Point Location, Color Paint)
        {
            if (Type == GameDataType.Player)
            {
                if (PlayersBuffer.Count > Index)
                {
                    PlayersBuffer[Index].ArtIndex = ArtIndex;
                    //PlayersBuffer[Index].ImageIndex = ImageIndex;
                    PlayersBuffer[Index].Location = Location;
                    PlayersBuffer[Index].Size = Size;
                    PlayersBuffer[Index].Other = Other;
                    PlayersBuffer[Index].Paint = Paint;
                }
                else PlayersBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
            if (Type == GameDataType.Enemy)
            {
                if (NPCsBuffer.Count > Index)
                {
                    NPCsBuffer[Index].ArtIndex = ArtIndex;
                    NPCsBuffer[Index].ImageIndex = ImageIndex;
                    NPCsBuffer[Index].Location = Location;
                    NPCsBuffer[Index].Facing = Facing;
                    NPCsBuffer[Index].Size = Size;
                    NPCsBuffer[Index].Paint = Paint;
                }
                else
                {
                    if (NPCs.Count > Index && NPCs[Index] != null) NPCsBuffer.Add(new Item(ArtIndex, Location, Facing, Size, NPCs[Index].ImageIndex));
                    else NPCsBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
                }
            }
            if (Type == GameDataType.Projectile)
            {
                if (ProjectilesBuffer.Count > Index)
                {
                    ProjectilesBuffer[Index].ArtIndex = ArtIndex;
                    ProjectilesBuffer[Index].ImageIndex = ImageIndex;
                    ProjectilesBuffer[Index].Location = Location;
                    ProjectilesBuffer[Index].Facing = Facing;
                    ProjectilesBuffer[Index].Size = Size;
                    ProjectilesBuffer[Index].Other = Other;
                    ProjectilesBuffer[Index].Paint = Paint;
                }
                else
                {
                    Item NewItem = new Item(ArtIndex, Location, Facing, Size);
                    NewItem.ImageIndex = Other;
                    NewItem.Paint = Paint;
                    ProjectilesBuffer.Add(NewItem);
                }
            }
            if (Type == GameDataType.Effect)
            {
                if (EffectsBuffer.Count > Index)
                {
                    EffectsBuffer[Index].ArtIndex = ArtIndex;
                    EffectsBuffer[Index].ImageIndex = ImageIndex;
                    EffectsBuffer[Index].Location = Location;
                    EffectsBuffer[Index].Facing = Facing;
                    EffectsBuffer[Index].Size = Size;
                    EffectsBuffer[Index].Paint = Paint;
                }
                else EffectsBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
            if (Type == GameDataType.PowerUp)
            {
                if (PowerUpsBuffer.Count > Index)
                {
                    PowerUpsBuffer[Index].ArtIndex = ArtIndex;
                    PowerUpsBuffer[Index].ImageIndex = ImageIndex;
                    PowerUpsBuffer[Index].Location = Location;
                    PowerUpsBuffer[Index].Facing = Facing;
                    PowerUpsBuffer[Index].Size = Size;
                    PowerUpsBuffer[Index].Paint = Paint;
                }
                else PowerUpsBuffer.Add(new Item(ArtIndex, Location, Facing, Size));
            }
        }
        public void UpdateItems(GameDataType Type, int[] Index, int[] ArtIndex, int[] ImageIndex, int[] Other, double[] Facing, double[] Size, Point[] Location, Color[] Paints)
        {
            if (this.Working) return;
            this.Working = true;
            for (int i = 0; i < Index.Length; i++)
            {
                this.UpdateItem(Type, Index[i], ArtIndex[i], ImageIndex[i], Other[i], Facing[i], Size[i], Location[i], Paints[i]);
            }
            this.Working = false;
        }
    }
}
