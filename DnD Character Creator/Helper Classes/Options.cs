using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class Options
    {
        public static List<string> Classes { get; set; } = new List<string>
        {
            "Barbarian",
            "Bard",
            "Cleric",
            "Druid",
            "Fighter",
            "Monk",
            "Paladin",
            "Ranger",
            "Rogue",
            "Sorcerer",
            "Warlock",
            "Wizard",
            "see options"
        };
        public static List<string> Races { get; set; } = new List<string>
        {
            "Dragonborn",
            "Hill Dwarf",
            "Mountain Dwarf",
            "Drow",
            "High Elf",
            "Wood Elf",
            "Forest Gnome",
            "Rock Gnome",
            "Half-Elf",
            "Half-Orc",
            "Lightfoot Halfling",
            "Stout Halfling",
            "Human",
            "Variant Human",
            "Tiefling",
            "see options"
        };
        public static List<string> Languages { get; set; } = new List<string>
        {
            "Common",
            "Dwarven",
            "Elven",
            "Giant",
            "Gnomish",
            "Goblin",
            "Halfling",
            "Orc",
            "Abyssal",
            "Celestial",
            "Draconic",
            "Deep Speech",
            "Infernal",
            "Primordial",
            "Sylvan",
            "Undercommon",
            "see options"
        };
        public static List<string> Backgrounds { get; set; } = new List<string>
        {
            "Acolyte",
            "Charltan",
            "Criminal",
            "Entertainer",
            "Folk Hero",
            "Guild Artisan",
            "Hermit",
            "Noble",
            "Outlander",
            "Sage",
            "Sailor",
            "Soldier",
            "Urchin",
            "see options"
        };
        public static List<string> Skills { get; set; } = new List<string>
        {
            "Acrobatics",
            "Animal Handling",
            "Arcana",
            "Athletics",
            "Deception",
            "History",
            "Insight",
            "Intimidation",
            "Investigation",
            "Medicine",
            "Nature",
            "Perception",
            "Performance",
            "Persuasion",
            "Religion",
            "Sleight of Hand",
            "Stealth",
            "Survival",
            "see options"
        };
        public static List<string> Stats { get; set; } = new List<string>
        {
            "Str",
            "Dex",
            "Con",
            "Int",
            "Wis",
            "Cha"
        };
        public static List<string> Feats { get; set; } = new List<string>
        {
            "Alert",
            "Athlete",
            "Actor",
            "Charger",
            "Crossbow Expert",
            "Defensive Duelist",
            "Dual Wielder",
            "Dungeon Delver",
            "Durable",
            "Elemental Adept",
            "Grappler",
            "Great Weapon Master",
            "Healer",
            "Heavily Armored",
            "Heavy Armor Master",
            "Inspiring Leader",
            "Keen Mind",
            "Lightly Armored",
            "Linguist",
            "Lucky",
            "Mage Slayer",
            "Magic Initiate",
            "Martial Adept",
            "Medium Armor Master",
            "Mobile",
            "Moderately Armored",
            "Mounted Combatant",
            "Observant",
            "Polearm Master",
            "Resilient",
            "Ritual Caster",
            "Savage Attacker",
            "Sentinel",
            "Sharpshooter",
            "Shield Master",
            "Skilled",
            "Skulker",
            "Spell Sniper",
            "Tavern Brawler",
            "Tough",
            "War Caster",
            "Weapon Master",
            "see options"            
        };
        public static List<string> Weapons { get; set; } = new List<string>
        {
            "",
            "",
            "",
            "Handaxe(1D slashing, Light, Thrown 20/60)(5gp, 2lb.)",
            "Javelin(1D6 piercing, Thrown 30/120)(5sp, 2lb.)",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "Greataxe(2D6 slashing, Heavy, Two-Handed)(30gp, 7lb.)",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
        };
        public static List<string> Packs { get; set; } = new List<string>
        {
            "Burglar's Pack()",
            "Diplomat's Pack()",
            "Dungeoneer's Pack()",
            "Entertainer's Pack()",
            "Explorer's Pack(backpack, bedroll, mess kit, tinderbox, 10 torches, 10 days of rations, waterskin, 50ft of rope)",
            "Priest's Pack()",
            "Scholar's Pack()"
        };
        public static List<string> MusicalInstruments { get; set; } = new List<string>
        {
            "Bagpipes",
            "Drum",
            "Dulcimer",
            "Flute",
            "Lute",
            "Lyre",
            "Horn",
            "Pan flute",
            "Shawm",
            "Viol",
            "see options"
        };
        public static List<string> ArtisanTools { get; set; } = new List<string>
        {
            "Alchemist’s supplies",
            "Brewer’s supplies",
            "Calligrapher's supplies",
            "Carpenter’s tools",
            "Cartographer’s tools ",
            "Cobbler’s tools",
            "Cook’s utensils",
            "Glassblower’s tools",
            "Jeweler’s tools",
            "Leatherworker’s tools",
            "Mason’s tools",
            "Painter’s supplies",
            "Potter’s tools",
            "Smith’s tools",
            "Tinker’s tools",
            "Weaver’s tools",
            "Woodcarver's tools",
            "see options"
        };
        public static List<string> GamingSets { get; set; } = new List<string>
        {
            "Dice set",
            "Dragonchess set",
            "Playing card set",
            "Three-Dragon Ante set",
            "see options"
        };
        public static string GetOption(List<string> list)
        {
            string entry = CLIHelper.GetStringInList(list);
            if (entry == "see options")
            {
                Console.Clear();
                list.Remove("see options");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i]);
                }
                entry = CLIHelper.GetStringInList(list);
            }

            return entry;
        }
    }
}
