using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Races;
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
        public int Lvl { get; set; }
        public double XP { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }
        public int Init { get; set; }
        public int ProficiencyBonus { get; set; }
        public int AC { get; set; }
        public int HP { get; set; }
        public List<string> Saves { get; set; } = new List<string>();
        public List<string> Languages { get; set; } = new List<string> { "Common" };
        public Dictionary<string, int> Skills { get; set; } = new Dictionary<string, int>
        {
            { "Acrobatics", 0 },
            { "Animal Handling", 0 },
            { "Arcana", 0 },
            { "Athletics", 0 },
            { "Deception", 0 },
            { "History", 0 },
            { "Insight", 0 },
            { "Intimidation", 0 },
            { "Investigation", 0 },
            { "Medicine", 0 },
            { "Nature", 0 },
            { "Perception", 0 },
            { "Performance", 0 },
            { "Persuasion", 0 },
            { "Religion", 0 },
            { "Sleight of Hand", 0 },
            { "Stealth", 0 },
            { "Survival", 0 }
        };
        public List<string> SkillProficiencies { get; set; } = new List<string>();
        public List<string> Proficiencies { get; set; } = new List<string>();
        public string BackgroundFeature { get; set; }
        public string PersonalityTrait { get; set; }
        public string Ideal { get; set; }
        public string Bond { get; set; }
        public string Flaw { get; set; }
        public string FavoriteScam { get; set; }
        public string Specialty { get; set; }
        public string Routine { get; set; }
        public string DefiningEvent { get; set; }
        public string GuildBusiness { get; set; }
        public string LifeOfSeclusion { get; set; }
        public string Origin { get; set; }
        public List<string> Equipment { get; set; } = new List<string>();
        public int GP { get; set; }
        public List<string> ClassFeatures { get; set; } = new List<string>();
        public List<string> Spells { get; set; } = new List<string>();
        public List<string> Feats { get; set; } = new List<string>();
    }
}
