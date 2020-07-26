using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public static class WarlockSpells
    {
        public static List<string> Cantrips { get; set; } = new List<string>
        {
            "Blade Ward",
            "Chill Touch",
            "Eldritch Blast",
            "Friends",
            "Mage Hand",
            "Minor Illusion",
            "Poison Spray",
            "Prestidigitation",
            "True Strike"
        };
        public static List<string> FirstLvls { get; set; } = new List<string> {
            "Armor of Agathys",
            "Arms of Hadar",
            "Charm Person",
            "Comprehend Languages",
            "Expeditious Retreat",
            "Hellish Rebuke",
            "Hex",
            "Illusory Script",
            "Protection from Evil and Good",
            "Unseen Servant",
            "Witch Bolt"
        };
        public static List<string> SecondLvls { get; set; } = new List<string> {
            "Cloud of Daggers",
            "Crown of Madness",
            "Darkness",
            "Enthrall",
            "Hold Person",
            "Invisibility",
            "Mirror Image",
            "Misty Step",
            "Ray of Enfeeblement",
            "Shatter",
            "Spider Climb",
            "Suggestion"
        };
        public static List<string> ThirdLvls { get; set; } = new List<string> {
            "Counterspell",
            "Dispel Magic",
            "Fear",
            "Fly",
            "Gaseous Form",
            "Hunger of Hadar",
            "Hypnotic Pattern",
            "Magic Circle",
            "Major Image",
            "Remove Curse",
            "Tongues",
            "Vampiric Touch"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Banishment",
            "Blight",
            "Dimension Door",
            "Hallucinatory Terrain"
        };
        public static List<string> FifthLvls { get; set; } = new List<string> {
            "Contact Other Plane",
            "Dream",
            "Hold Monster",
            "Scrying",
        };
        public static List<string> SixthLvls { get; set; } = new List<string> {
            "Arcane Gate",
            "Circle of Death",
            "Conjure Fey",
            "Create Undead",
            "Eyebite",
            "Flesh to Stone",
            "Mass Suggestion",
            "True Seeing"
        };
        public static List<string> SeventhLvls { get; set; } = new List<string> {
            "Etherealness",
            "Finger of Death",
            "Forcecage",
            "Plane Shift",

        };
        public static List<string> EigthLvls { get; set; } = new List<string> {
            "Demiplane",
            "Dominate Monster",
            "Feeblemind",
            "Glibness",
            "Power Word Stun"
        };
        public static List<string> NinthLvls { get; set; } = new List<string> {
            "Astral Projection",
            "Foresight",
            "Imprisonment",
            "Power Word Kill",
            "True Polymorph"
        };
    }
}
