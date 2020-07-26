using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public static class ClericSpells
    {
        public static List<string> Cantrips { get; set; } = new List<string> {
            "Guidance",
            "Light",
            "Mending",
            "Resistance",
            "Sacred Flame",
            "Spare the Dying",
            "Thaumaturgy"
        };
        public static List<string> FirstLvls { get; set; } = new List<string> {
            "Bane",
            "Bless",
            "Command",
            "Create or Destroy Water",
            "Cure Wounds",
            "Detect Evil and Good",
            "Detect Magic",
            "Detect Poison and Disease",
            "Guiding Bolt",
            "Healing Word",
            "Inflict Wounds",
            "Protection from Evil and Good",
            "Purify Food and Drink",
            "Sanctuary",
            "Shield of Faith"
        };
        public static List<string> SecondLvls { get; set; } = new List<string> {
            "Aid",
            "Augury",
            "Blindness/Deafness",
            "Calm Emotions",
            "Continual Flame",
            "Enhance Ability",
            "Find Traps",
            "Gentle Repose",
            "Hold Person",
            "Lesser Restoration",
            "Locate Object",
            "Prayer of Healing",
            "Protection from Poison",
            "Silence",
            "Spiritual Weapon",
            "Warding Bond",
            "Zone of Truth"
        };
        public static List<string> ThirdLvls { get; set; } = new List<string> {
            "Animate Dead",
            "Beacon of Hope",
            "Bestow Curse",
            "Clairvoyance",
            "Create Food and Water",
            "Daylight",
            "Dispel Magic",
            "Feign Death",
            "Glyph of Warding",
            "Magic Circle",
            "Mass Healing Word",
            "Meld into Stone",
            "Protection from Energy",
            "Remove Curse",
            "Revivify",
            "Sending",
            "Speak with Dead",
            "Spirit Guardians",
            "Tongues",
            "Water Walk"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Banishment",
            "Control Water",
            "Death Ward",
            "Divination",
            "Freedom of Movement",
            "Guardian of Faith",
            "Locate Creature",
            "Stone Shape"
        };
        public static List<string> FifthLvls { get; set; } = new List<string> {
            "Commune",
            "Contagion",
            "Dispel Evil and Good",
            "Flame Strike",
            "Geas",
            "Greater Restoration",
            "Hallow",
            "Insect Plague",
            "Legend Lore",
            "Mass Cure Wounds",
            "Planar Binding",
            "Raise Dead",
            "Scrying"
        };
        public static List<string> SixthLvls { get; set; } = new List<string> {
            "Blade Barrier",
            "Create Undead",
            "Find the Path",
            "Forbiddance",
            "Harm",
            "Heal",
            "Heroes’ Feast",
            "Planar Ally",
            "True Seeing",
            "Word of Recall"
        };
        public static List<string> SeventhLvls { get; set; } = new List<string> {
            "Conjure Celestial",
            "Divine Word",
            "Etherealness",
            "Fire Storm",
            "Plane Shift",
            "Regenerate",
            "Resurrection",
            "Symbol"
        };
        public static List<string> EigthLvls { get; set; } = new List<string> {
            "Antimagic Field",
            "Control Weather",
            "Earthquake",
            "Holy Aura"
        };
        public static List<string> NinthLvls { get; set; } = new List<string> {
            "Astral Projection",
            "Gate",
            "Mass Heal",
            "True Resurrection"
        };
    }
}
