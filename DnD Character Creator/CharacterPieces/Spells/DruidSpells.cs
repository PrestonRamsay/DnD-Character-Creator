using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public static class DruidSpells
    {
        public static List<string> Cantrips { get; set; } = new List<string> {
            "Druidcraft",
            "Guidance",
            "Mending",
            "Poison Spray",
            "Produce Flame",
            "Resistance",
            "Shillelagh",
            "Thorn Whip"
        };
        public static List<string> FirstLvls { get; set; } = new List<string> {
            "Animal Friendship",
            "Charm Person",
            "Create or Destroy Water",
            "Cure Wounds",
            "Detect Magic",
            "Detect Poison and Disease",
            "Entangle",
            "Faerie Fire",
            "Fog Cloud",
            "Goodberry",
            "Healing Word",
            "Jump",
            "Longstrider",
            "Purify Food and Drink",
            "Speak with Animals",
            "Thunderwave"
        };
        public static List<string> SecondLvls { get; set; } = new List<string> {
            "Animal Messenger",
            "Barkskin",
            "Beast Sense",
            "Darkvision",
            "Enhance Ability",
            "Find Traps",
            "Flame Blade",
            "Flaming Sphere",
            "Gust of Wind",
            "Heat Metal",
            "Hold Person",
            "Lesser Restoration",
            "Locate Animals or Plants",
            "Locate Object",
            "Moonbeam",
            "Pass without Trace",
            "Protection from Poison",
            "Spike Growth"
        };
        public static List<string> ThirdLvls { get; set; } = new List<string> {
            "Call Lightning",
            "Conjure Animals",
            "Daylight",
            "Dispel Magic",
            "Feign Death",
            "Meld into Stone",
            "Plant Growth",
            "Protection from Energy",
            "Sleet Storm",
            "Speak with Plants",
            "Water Breathing",
            "Water Walk",
            "Wind Wall"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Blight",
            "Confusion",
            "Conjure Minor Elementals",
            "Conjure Woodland Beings",
            "Control Water",
            "Dominate Beast",
            "Freedom of Movement",
            "Giant Insect",
            "Grasping Vine",
            "Hallucinatory Terrain",
            "Ice Storm",
            "Locate Creature",
            "Polymorph",
            "Stone Shape",
            "Stoneskin",
            "Wall of Fire"
        };
        public static List<string> FifthLvls { get; set; } = new List<string> {
            "Antilife Shell",
            "Awaken",
            "Commune with Nature",
            "Conjure Elemental",
            "Contagion",
            "Geas",
            "Greater Restoration",
            "Insect Plague",
            "Mass Cure Wounds",
            "Planar Binding",
            "Reincarnate",
            "Scrying",
            "Tree Stride",
            "Wall of Stone"
        };
        public static List<string> SixthLvls { get; set; } = new List<string> {
            "Conjure Fey",
            "Find the Path",
            "Heal",
            "Heroes’ Feast",
            "Move Earth",
            "Sunbeam",
            "Transport via Plants",
            "Wall of Thorns",
            "Wind Walk"
        };
        public static List<string> SeventhLvls { get; set; } = new List<string> {
            "Fire Storm",
            "Mirage Arcane",
            "Plane Shift",
            "Regenerate",
            "Reverse Gravity"
        };
        public static List<string> EigthLvls { get; set; } = new List<string> {
            "Animal Shapes",
            "Antipathy/Sympathy",
            "Control Weather",
            "Earthquake",
            "Feeblemind",
            "Sunburst",
            "Tsunami"
        };
        public static List<string> NinthLvls { get; set; } = new List<string> {
            "Foresight",
            "Shapechange",
            "Storm of Vengeance",
            "True Resurrection"
        };
    }
}
