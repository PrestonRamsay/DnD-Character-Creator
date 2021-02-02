using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public static class FighterSpells
    {
        public static List<string> Cantrips { get; set; } = new List<string>
        {
            "Booming Blade",
            "Blade Ward",
            "Dancing Lights",
            "Fire Bolt",
            "Frostbite",
            "Green-Flame blade",
            "Light",
            "Lightning Lure",
            "Ray of Frost",
            "Shocking Grasp",
            "Thunderclap",
            "1"
        };
        public static List<string> FirstLvls { get; set; } = new List<string> {
            "Absorb Elements",
            "Alarm",
            "Burning Hands",
            "Charm Person",
            "Chromatic Orb",
            "Earth tremor",
            "Frost fingers",
            "Jim's Magic Missile",
            "Mage Armor",
            "Magic Missile",
            "Protection from Evil and Good",
            "Shield",
            "Snare",
            "Tasha’s Caustic Brew",
            "Thunderwave",
            "Witch Bolt"
        };
        public static List<string> SecondLvls { get; set; } = new List<string> {
            "Acid Arrow",
            "Arcane Lock",
            "Aganazzar’s Scorcher",
            "Continual Flame",
            "Darkness",
            "Gust of Wind",
            "Melf’s Acid Arrow",
            "Scorching Ray",
            "Shatter",
            "Snilloc’s Snowball Swarm",
            "Warding Wind",
            "1"
        };
        public static List<string> ThirdLvls { get; set; } = new List<string> {
            "Counterspell",
            "Dispel Magic",
            "Fireball",
            "Glyph of Warding",
            "Intellect Fortress",
            "Leomund’s Tiny Hut",
            "Lightning Bolt",
            "Magic Circle",
            "Melf's Minute Meteors",
            "Nondetection",
            "Protection from Energy",
            "Remove Curse",
            "Sending",
            "Tiny Hut",
            "Wall of Sand",
            "Wall of Water",
            "1"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Banishment",
            "Fire Shield",
            "Ice Storm",
            "Mordenkainen’s Private Sanctum",
            "Otiluke’s Resilient Sphere",
            "Sickening Radiance",
            "Stoneskin",
            "Storm sphere",
            "Vitriolic Sphere",
            "Wall of Fire",
            "1"
        };
    }
}
