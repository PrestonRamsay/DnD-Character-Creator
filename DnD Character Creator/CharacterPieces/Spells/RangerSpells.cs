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
            "Fog Cloud",
            "Goodberry",
            "Hail of Thorns",
            "Hunter's Mark",
            "Jump",
            "Longstrider",
            "Snare",
            "Speak with Animals",
            "Zephyr Strike"
        };
        public static List<string> SecondLvls { get; set; } = new List<string> {
            "Animal Messenger",
            "Barkskin",
            "Beast Sense",
            "Cordon of Arrows",
            "Darkvision",
            "Find Traps",
            "Healing Spirit",
            "Lesser Restoration",
            "Locate Animals or Plants",
            "Locate Object",
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
            "Flame Arrows",
            "Lightning Arrow",
            "Nondetection",
            "Plant Growth",
            "Protection from Energy",
            "Speak with Plants",
            "Summon Fey",
            "Water Breathing",
            "Water Walk",
            "Wind Wall"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Conjure Woodland Beings",
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
            "Steel Wind Strike",
            "Swift Quiver",
            "Tree Stride",
            "Wrath of Nature"
        };
    }
}
