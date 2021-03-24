using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public static class RangerSpells
    {
        public static List<string> FirstLvls { get; set; } = new List<string> {
            "Absorb Elements",
            "Alarm",
            "Animal Friendship",
            "Beast Bond",
            "Cure Wounds",
            "Detect Magic",
            "Detect Poison and Disease",
            "Ensnaring Strike",
            "Entangle",
            "Fog Cloud",
            "Goodberry",
            "Hail of Thorns",
            "Hunter's Mark",
            "Jump",
            "Longstrider",
            "Searing Smite",
            "Snare",
            "Speak with Animals",
            "Zephyr Strike"
        };
        public static List<string> SecondLvls { get; set; } = new List<string> {
            "Aid",
            "Animal Messenger",
            "Barkskin",
            "Beast Sense",
            "Cordon of Arrows",
            "Darkvision",
            "Enhance Ability",
            "Find Traps",
            "Gust of Wind",
            "Healing Spirit",
            "Lesser Restoration",
            "Locate Animals or Plants",
            "Locate Object",
            "Magic Weapon",
            "Pass without Trace",
            "Protection from Poison",
            "Silence",
            "Spike Growth",
            "Summon Beast"
        };
        public static List<string> ThirdLvls { get; set; } = new List<string> {
            "Conjure Animals",
            "Conjure Barrage",
            "Daylight",
            "Elemental Weapon",
            "Flame Arrows",
            "Lightning Arrow",
            "Meld Into Stone",
            "Nondetection",
            "Plant Growth",
            "Protection from Energy",
            "Revivify",
            "Speak with Plants",
            "Summon Fey",
            "Waterbreathing",
            "Water Walk",
            "Wind Wall"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Conjure Woodland Beings",
            "Dominate Beast",
            "Freedom of Movement",
            "Grasping Vine",
            "Guardian of Nature",
            "Locate Creature",
            "Stoneskin",
            "Summon Elemental"
        };
        public static List<string> FifthLvls { get; set; } = new List<string> {
            "Commune with Nature",
            "Conjure Volley",
            "Greater Restoration",
            "Steel Wind Strike",
            "Swift Quiver",
            "Tree Stride",
            "Wrath of Nature"
        };
    }
}
