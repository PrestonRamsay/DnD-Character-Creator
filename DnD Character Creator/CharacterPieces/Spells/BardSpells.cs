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
            "Thunderclap",
            "True Strike",
            "Vicious Mockery"
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
            "Distort Value",
            "Earth Tremor",
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
            "Unseen Servant"
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
            "Gift of Gab",
            "Heat Metal",
            "Hold Person",
            "Invisibility",
            "Knock",
            "Lesser Restoration",
            "Locate Animals or Plants",
            "Locate Object",
            "Magic Mouth",
            "Phantasmal Force",
            "Pyrotechnics",
            "See Invisibility",
            "Shatter",
            "Silence",
            "Skywrite",
            "Suggestion",
            "Warding Wind",
            "Zone of Truth"
        };
        public static List<string> ThirdLvls { get; set; } = new List<string> {
            "Bestow Curse",
            "Catnap",
            "Clairvoyance",
            "Dispel Magic",
            "Enemies Abound",
            "Fast Friends",
            "Fear",
            "Feign Death",
            "Glyph of Warding",
            "Hypnotic Pattern",
            "Intellect Fortress",
            "Leomund’s Tiny Hut",
            "Major Image",
            "Motivational Speech",
            "Nondetection",
            "Plant Growth",
            "Sending",
            "Speak with Dead",
            "Speak with Plants",
            "Stinking Cloud",
            "Tongues"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Charm Monster",
            "Compulsion",
            "Confusion",
            "Dimension Door",
            "Freedom of Movement",
            "Greater Invisibility",
            "Hallucinatory Terrain",
            "Locate Creature",
            "Polymorph"
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
            "Skill Empowerment",
            "Synaptic Static",
            "Teleportation Circle"
        };
        public static List<string> SixthLvls { get; set; } = new List<string> {
            "Eyebite",
            "Find the Path",
            "Guards and Wards",
            "Mass Suggestion",
            "Otto’s Irresistible Dance",
            "Programmed Illusion",
            "True Seeing"
        };
        public static List<string> SeventhLvls { get; set; } = new List<string> {
            "Dream of the Blue Veil",
            "Etherealness",
            "Forcecage",
            "Mirage Arcane",
            "Mordenkainen's Magnificent Mansion",
            "Mordenkainen’s Sword",
            "Project Image",
            "Regenerate",
            "Resurrection",
            "Symbol",
            "Teleport"

        };
        public static List<string> EigthLvls { get; set; } = new List<string> {
            "Dominate Monster",
            "Feeblemind",
            "Glibness",
            "Mind Blank",
            "Power Word Stun"
        };
        public static List<string> NinthLvls { get; set; } = new List<string> {
            "Foresight",
            "Power Word Heal",
            "Power Word Kill",
            "Psychic Scream",
            "True Polymorph"
        };
    }
}
