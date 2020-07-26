using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public static class RangerSpells
    {
        public static List<string> FirstLvls { get; set; } = new List<string> {
            "Alarm",
            "Animal Friendship",
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
            "Speak with Animals"
        };
        public static List<string> SecondLvls { get; set; } = new List<string> {
            "Animal Messenger",
            "Barkskin",
            "Beast Sense",
            "Cordon of Arrows",
            "Darkvision",
            "Find Traps",
            "Lesser Restoration",
            "Locate Animals or Plants",
            "Locate Object",
            "Pass without Trace",
            "Protection from Poison",
            "Silence",
            "Spike Growth"
        };
        public static List<string> ThirdLvls { get; set; } = new List<string> {
            "Conjure Animals",
            "Conjure Barrage",
            "Daylight",
            "Lightning Arrow",
            "Nondetection",
            "Plant Growth",
            "Protection from Energy",
            "Speak with Plants",
            "Speak with Plants",
            "Water Breathing",
            "Water Walk",
            "Wind Wall"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Conjure Woodland Beings",
            "Freedom of Movement",
            "Grasping Vine",
            "Locate Creature",
            "Stoneskin"
        };
        public static List<string> FifthLvls { get; set; } = new List<string> {
            "Commune with Nature",
            "Conjure Volley",
            "Swift Quiver",
            "Tree Stride"
        };
    }
}
