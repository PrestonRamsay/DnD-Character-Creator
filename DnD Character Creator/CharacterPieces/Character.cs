using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator
{
    public class Character
    {     
        public Character()
        {
            GP = 0;
            StatMax = 20;
            SpellsKnown = 0;
            Archetype = "";
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string ChosenRace { get; set; }
        public List<string> RacialTraits { get; set; } = new List<string>();
        public string Alignment { get; set; }
        public string Deity { get; set; }
        public string ChosenBackground { get; set; }        
        public int Height { get; set; }
        public string Size { get; set; }
        public int Weight { get; set; }            
        public string EC { get; set; }
        public string HC { get; set; }
        public string SC { get; set; }
        public string Speed { get; set; }
        public string Vision { get; set; }
        public string ChosenClass { get; set; }
        public string Archetype { get; set; }
        public int Lvl { get; set; }
        public double XP { get; set; }
        public int StatMax { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }
        private int GetMod(int stat)
        {
            return (stat - 10) / 2;
        }
        public int StrMod
        {
            get
            {
                return GetMod(Str);
            }
        }
        public int DexMod
        {
            get
            {
                return GetMod(Dex);
            }
        }
        public int ConMod
        {
            get
            {
                return GetMod(Con);
            }
        }
        public int IntMod
        {
            get
            {
                return GetMod(Int);
            }
        }
        public int WisMod
        {
            get
            {
                return GetMod(Wis);
            }
        }
        public int ChaMod
        {
            get
            {
                return GetMod(Cha);
            }
        }
        public int Init
        {
            get
            {
                return DexMod;
            }
        }
        public int ProficiencyBonus { get; set; }
        public int AC
        {
            get
            {
                return 10 + DexMod;
            }
        }
        public int HP { get; set; }
        public List<string> Saves { get; set; } = new List<string>();
        public List<string> Languages { get; set; } = new List<string> { "Common" };
        public Dictionary<string, int> Skills { get; set; } = new Dictionary<string, int>
        {
            { "Acrobatics(Dex)", 0 },
            { "Animal Handling(Wis)", 0 },
            { "Arcana(Int)", 0 },
            { "Athletics(Str)", 0 },
            { "Deception(Cha)", 0 },
            { "History(Int)", 0 },
            { "Insight(Wis)", 0 },
            { "Intimidation(Cha)", 0 },
            { "Investigation(Int)", 0 },
            { "Medicine(Wis)", 0 },
            { "Nature(Int)", 0 },
            { "Perception(Wis)", 0 },
            { "Performance(Cha)", 0 },
            { "Persuasion(Cha)", 0 },
            { "Religion(Int)", 0 },
            { "Sleight of Hand(Dex)", 0 },
            { "Stealth(Dex)", 0 },
            { "Survival(Wis)", 0 }
        };
        public List<string> SkillProficiencies { get; set; } = new List<string>();
        public List<string> ToolProficiencies { get; set; } = new List<string>();
        public List<string> Proficiencies { get; set; } = new List<string>();
        public string BackgroundFeature { get; set; }
        public string PersonalityTrait { get; set; }
        public string Ideal { get; set; }
        public string Bond { get; set; }
        public string Flaw { get; set; }
        public string FavoriteScam { get; set; }
        public string Specialty { get; set; }
        public List<string> Routines { get; set; } = new List<string>();
        public string DefiningEvent { get; set; }
        public string GuildBusiness { get; set; }
        public string LifeOfSeclusion { get; set; }
        public string Origin { get; set; }
        public List<string> Equipment { get; set; } = new List<string>();
        public int GP { get; set; }
        public Dictionary<string, string> ClassFeatures { get; set; } = new Dictionary<string, string>();
        public int CantripsKnown { get; set; }
        public int SpellsKnown { get; set; }
        public List<string> Cantrips { get; set; } = new List<string>();
        public Dictionary<int, List<string>> Spells { get; set; } = new Dictionary<int, List<string>>
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
            { 6, new List<string>() },
            { 7, new List<string>() },
            { 8, new List<string>() },
            { 9, new List<string>() }
        };
        public Dictionary<int, int> SpellSlots { get; set; } = new Dictionary<int, int>
        {
            { 1, 0 },
            { 2, 0 },
            { 3, 0 },
            { 4, 0 },
            { 5, 0 },
            { 6, 0 },
            { 7, 0 },
            { 8, 0 },
            { 9, 0 }
        };
        public List<string> Feats { get; set; } = new List<string>();
        public string DragonColor { get; set; }
    }
}
