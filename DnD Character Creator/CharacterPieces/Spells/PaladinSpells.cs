using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public static class PaladinSpells
    {
        public static List<string> FirstLvls { get; set; } = new List<string> {
            "Bless",
            "Command",
            "Compelled Duel",
            "Cure Wounds",
            "Detect Evil and Good",
            "Detect Magic",
            "Detect Poison and Disease",
            "Divine Favor",
            "Heroism",
            "Protection from Evil and Good",
            "Purify Food and Drink",
            "Searing Smite",
            "Shield of Faith",
            "Thunderous Smite",
            "Wrathful Smite"
        };
        public static List<string> SecondLvls { get; set; } = new List<string> {
            "Aid",
            "Branding Smite",
            "Find Steed",
            "Lesser Restoration",
            "Locate Object",
            "Magic Weapon",
            "Protection from Poison",
            "Zone of Truth"
        };
        public static List<string> ThirdLvls { get; set; } = new List<string> {
            "Aura of Vitality",
            "Blinding Smite",
            "Create Food and Water",
            "Crusader's Mantle",
            "Daylight",
            "Dispel Magic",
            "Elemental Weapon",
            "Magic Circle",
            "Remove Curse",
            "Revivify"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Aura of Life",
            "Aura of Purity",
            "Banishment",
            "Death Ward",
            "Locate Creature",
            "Staggering Smite"
        };
        public static List<string> FifthLvls { get; set; } = new List<string> {
            "Banishing Smite",
            "Circle of Power",
            "Destructive Smite",
            "Dispel Evil and Good",
            "Geas",
            "Raise Dead"
        };
    }
}
