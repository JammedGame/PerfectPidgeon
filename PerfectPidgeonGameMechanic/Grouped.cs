using PerfectPidgeon.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectPidgeonGameMechanic
{
    public class Grouped : Enemy
    {
        private int _DependantInvincibility;
        private List<Vertex> _Offsets;
        private List<Enemy> _Auxes;
        private List<double> _Facings;
        private GroupVariant _Active;
        private List<GroupVariant> _Variants;
        public List<Vertex> Offsets
        { get => _Offsets; }
        public List<Enemy> Auxes
        {
            get
            {
                return _Auxes;
            }
        }
        public List<double> Facings { get => _Facings; set => _Facings = value; }
        public int DependantInvincibility { get => _DependantInvincibility; set => _DependantInvincibility = value; }
        public GroupVariant Active { get => _Active; set => _Active = value; }
        public List<GroupVariant> Variants { get => _Variants; set => _Variants = value; }
        public Grouped() : base()
        {
            this.Type = EnemyType.Grouped;
            this._DependantInvincibility = -1;
            this._Facings = new List<double>();
            this._Auxes = new List<Enemy>();
            this._Offsets = new List<Vertex>();
            this._Active = null;
            this._Variants = new List<GroupVariant>();
        }
        public Grouped(Grouped Old) : base(Old)
        {
            this._DependantInvincibility = Old._DependantInvincibility;
            this._Facings = new List<double>();
            for (int i = 0; i < Old._Facings.Count; i++) this._Facings.Add(Old._Facings[i]);
            this._Auxes = new List<Enemy>();
            for (int i = 0; i < Old._Auxes.Count; i++) this._Auxes.Add(new Enemy(Old.Auxes[i]));
            this._Offsets = new List<Vertex>();
            for (int i = 0; i < Old._Offsets.Count; i++) this._Offsets.Add(new Vertex(Old._Offsets[i]));
            if(Old._Active != null) this._Active = new GroupVariant(Old._Active);
            this._Variants = new List<GroupVariant>();
            for (int i = 0; i < Old._Variants.Count; i++) this._Variants.Add(new GroupVariant(Old._Variants[i]));
        }
        public void AddAux(Enemy Aux, Vertex Offset)
        {
            Aux.Type = EnemyType.Aux;
            Aux.Location = Offset;
            this.Offsets.Add(Offset);
            this.Auxes.Add(Aux);
        }
        public bool TryFindVariant(Enemy AuxCandidate)
        {
            if(Active != null)
            {
                for(int i = 0; i < this._Active.Entries.Count; i++)
                {
                    if(this._Active.Entries[i].DesiredID == AuxCandidate.ID)
                    {

                    }
                }
            }
            else
            {
                for (int i = 0; i < this._Variants.Count; i++)
                {

                }
            }
            return false;
        }
    }
    public class GroupVariant
    {
        private List<GroupVariantEntry> _Entries;
        public List<GroupVariantEntry> Entries { get => _Entries; set => _Entries = value; }
        public GroupVariant()
        {
            this._Entries = new List<GroupVariantEntry>();
        }
        public GroupVariant(GroupVariant Old)
        {
            this._Entries = new List<GroupVariantEntry>();
            for(int i = 0; i < Old._Entries.Count; i++)
            {
                this._Entries.Add(new GroupVariantEntry(Old._Entries[i]));
            }
        }
    }
    public class GroupVariantEntry
    {
        private bool _Filled;
        private string _DesiredID;
        private Vertex _Offset;
        public bool Filled { get => _Filled; set => _Filled = value; }
        public string DesiredID { get => _DesiredID; set => _DesiredID = value; }
        public Vertex Offset { get => _Offset; set => _Offset = value; }
        public GroupVariantEntry()
        {
            this._Filled = false;
            this._DesiredID = "";
            this._Offset = new Vertex();
        }
        public GroupVariantEntry(GroupVariantEntry Old)
        {
            this.Filled = Old._Filled;
            this._DesiredID = Old._DesiredID;
            this._Offset = Old._Offset;
        }
    }
}
