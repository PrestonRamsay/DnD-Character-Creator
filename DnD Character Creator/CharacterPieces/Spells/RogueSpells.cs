
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public static class RogueSpells
    {
        public static List<string> Cantrips { get; set; } = new List<string>
        {
            
            "Encode Thoughts",
            "Friends",
            "Mind Sliver",
            "Minor Illusion"
        };
        public static List<string> FirstLvls { get; set; } = new List<string> {
            "Charm Person",
            "Color Spray",
            "Disguise Self",
            "Distort Value",
            "Illusory Script",
            "Silent Image",
            "Sleep",
            "Tasha’s Hideous Laughter"
        };
        public static List<string> SecondLvls { get; set; } = new List<string> {
            "Arcanist's Magic Aura",
            "Blur",
            "Crown of Madness",
            "Gift of Gab",
            "Hold Person",
            "Invisibility",
            "Jim's Glowing Coin",
            "Magic Mouth",
            "Mirror Image",
            "Nystul’s Magic Aura",
            "Phantasmal Force",
            "Shadow Blade",
            "Suggestion",
            "Tasha's Mind Whip"
        };
        public static List<string> ThirdLvls { get; set; } = new List<string> {
            "Fast Friends",
            "Fear",
            "Hypnotic Pattern",
            "Incite Greed",
            "Major Image",
            "Phantom Steed"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Charm Monster",
            "Confusion",
            "Greater Invisibility",
            "Hallucinatory Terrain",
            "Phantasmal Killer"
        };
    }
}
