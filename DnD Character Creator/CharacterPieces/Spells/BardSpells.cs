using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public static class BardSpells
    {
        public static List<string> Cantrips { get; set; } = new List<string>
        {
            "Blade Ward",
            "Dancing Lights",
            "Friends",
            "Light",
            "Mage Hand",
            "Mending",
            "Message",
            "Minor Illusion",
            "Prestidigitation",
            "True Strike",
            "Vicious Mockery",
            "1"
        };
        public static List<string> FirstLvls { get; set; } = new List<string> {
            "Animal Friendship",
            "Bane",
            "Charm Person",
            "Comprehend Languages",
            "Cure Wounds",
            "Detect Magic",
            "Disguise Self",
            "Dissonant Whispers",
            "Faerie Fire",
            "Featherfall",
            "Healing Word",
            "Heroism",
            "Identify",
            "Illusory Script",
            "Longstrider",
            "Silent Image",
            "Sleep",
            "Speak with Animals",
            "Tasha's Hideous Laughter",
            "Thunderwave",
            "Unseen Servant",
            "1"
        };
        public static List<string> SecondLvls { get; set; } = new List<string> {
            "Animal Messenger",
            "Blindness/Deafness",
            "Calm Emotions",
            "Cloud of Daggers",
            "Crown of Madness",
            "Detect Thoughts",
            "Enhance Ability",
            "Enthrall",
            "Heat Metal",
            "Hold Person",
            "Invisibility",
            "Knock",
            "Lesser Restoration",
            "Locate Animals or Plants",
            "Locate Object",
            "Magic Mouth",
            "Phantasmal Force",
            "See Invisibility",
            "Shatter",
            "Silence",
            "Suggestion",
            "Zone of Truth",
            "1"
        };
        public static List<string> ThirdLvls { get; set; } = new List<string> {
            "Bestow Curse",
            "Clairvoyance",
            "Dispel Magic",
            "Fear",
            "Feign Death",
            "Glyph of Warding",
            "Hypnotic Pattern",
            "Leomund’s Tiny Hut",
            "Major Image",
            "Nondetection",
            "Plant Growth",
            "Sending",
            "Speak with Dead",
            "Speak with Plants",
            "Stinking Cloud",
            "Tongues",
            "1"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Compulsion",
            "Confusion",
            "Dimension Door",
            "Freedom of Movement",
            "Greater Invisibility",
            "Hallucinatory Terrain",
            "Locate Creature",
            "Polymorph",
            "1"
        };
        public static List<string> FifthLvls { get; set; } = new List<string> {
            "Animate Objects",
            "Awaken",
            "Dominate Person",
            "Dream",
            "Geas",
            "Greater Restoration",
            "Hold Monster",
            "Legend Lore",
            "Mass Cure Wounds",
            "Mislead",
            "Modify Memory",
            "Planar Binding",
            "Raise Dead",
            "Scrying",
            "Seeming",
            "Teleportation Circle",
            "1"
        };
        public static List<string> SixthLvls { get; set; } = new List<string> {
            "Eyebite",
            "Find the Path",
            "Guards and Wards",
            "Mass Suggestion",
            "Otto’s Irresistible Dance",
            "Programmed Illusion",
            "True Seeing",
            "1"
        };
        public static List<string> SeventhLvls { get; set; } = new List<string> {
            "Etherealness",
            "Forcecage",
            "Mirage Arcane",
            "Mordenkainen's Magnificent Mansion",
            "Mordenkainen’s Sword",
            "Project Image",
            "Regenerate",
            "Resurrection",
            "Symbol",
            "Teleport",
            "1"

        };
        public static List<string> EigthLvls { get; set; } = new List<string> {
            "Dominate Monster",
            "Feeblemind",
            "Glibness",
            "Mind Blank",
            "Power Word Stun",
            "1"
        };
        public static List<string> NinthLvls { get; set; } = new List<string> {
            "Foresight",
            "Power Word Heal",
            "Power Word Kill",
            "True Polymorph",
            "1"
        };
    }
}
