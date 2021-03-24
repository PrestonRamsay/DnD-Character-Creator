using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public static class PaladinSpells
    {
        public static List<string> FirstLvls { get; set; } = new List<string> {
            "Bless",
            "Ceremony",
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
            "Gentle Repose",
            "Lesser Restoration",
            "Locate Object",
            "Magic Weapon",
            "Prayer of Healing",
            "Protection from Poison",
            "Warding Bond",
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
            "Revivify",
            "Spirit Shroud"
        };
        public static List<string> FourthLvls { get; set; } = new List<string> {
            "Aura of Life",
            "Aura of Purity",
            "Banishment",
            "Death Ward",
            "Find Greater Steed",
            "Locate Creature",
            "Staggering Smite"
        };
        public static List<string> FifthLvls { get; set; } = new List<string> {
            "Banishing Smite",
            "Circle of Power",
            "Destructive Wave",
            "Dispel Evil and Good",
            "Geas",
            "Holy Weapon",
            "Raise Dead",
            "Summon Celestial"
        };
    }
}
