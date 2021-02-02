using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class Options
    {
        public static string SeeOptions = "If you would like to see the options enter '1'.";
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
            "Wizard"
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
            "Tiefling"
        };
        public static List<string> Languages { get; set; } = new List<string>
        {
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
            "Undercommon"
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
            "Urchin"
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
            "Survival"
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
            "Acute Fighting",
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
            "Finesse Weapon Master",
            "Grappler",
            "Great Weapon Master",
            "Healer",
            "Heavily Armored",
            "Heavy Armor Master",
            "Improved Critical",
            "Insightful Reflexes",
            "Inspiring Leader",
            "Jack of All Trades",
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
            "Point Blank Shot",
            "Polearm Master",
            "Rapid Shot",
            "Regeneration",
            "Resilient",
            "Ritual Caster",
            "Savage Attacker",
            "Sentinel",
            "Sharpshooter",
            "Shield Master",
            "Skilled",
            "Skirmisher",
            "Skulker",
            "Spell Focus",
            "Spell Sniper",
            "Tavern Brawler",
            "Tough",
            "Unarmored Defense",
            "War Caster",
            "Weapon Focus",
            "Weapon Master",
            "Whirlwind Attack"        
        };
        public static List<string> LightArmor { get; set; } = new List<string>
        {
            "Padded(+1 AC, Stealth disadv)(5gp, 8lb.)",
            "Leather(+1 AC)(10gp, 10lb.)",
            "Studded Leather(+2 AC)(45gp, 13lb.)"
        };
        public static List<string> MediumArmor { get; set; } = new List<string>
        {
            "Hide(+2 AC)(10gp, 12lb.)",
            "Chain shirt(+3 AC)(50gp, 20lb.)",
            "Scale mail(+4 AC, Stealth disadv)(50gp, 45lb.)",
            "Breastplate(+4 AC)(400gp, 20lb.)",
            "Half plate(+5 AC, Stealth disadv)(750gp, 40lb.)"
        };
        public static List<string> HeavyArmor { get; set; } = new List<string>
        {
            "Ring mail(+4 AC, Stealth disadv)(30gp, 40lb.)",
            "Chain mail(+6 AC, Stealth disadv)(75gp, 55lb.)",
            "Splint(+7 AC, Stealth disadv)(200gp, 60lb.)",
            "Plate(+8 AC, Stealth disadv)(1,500gp, 65lb.)"
        };
        public static List<string> SimpleMeleeWeapons { get; set; } = new List<string>
        {
            "Club(1D4 bludgeoning, Light)(1sp, 2lb.)",
            "Dagger(1D4 piercing, Finesse, Light, Thrown 20/60)(2gp, 1lb.)",
            "Greatclub(1D8 bludgeoning, Two-Handed)(2sp, 10lb.)",
            "Handaxe(1D6 slashing, Light, Thrown 20/60)(5gp, 2lb.)",
            "Javelin(1D6 piercing, Thrown 30/120)(5sp, 2lb.)",
            "Light hammer(1D4 bludgeoning, Light, Thrown 20/60)(2gp, 2lb.)",
            "Mace(1D6 bludgeoning)(5gp, 4lb.)",
            "Quarterstaff(1D6 bludgeoning, Versatile-D8)(2sp, 4lb.)",
            "Sickle(1D4 slashing, Light)(1gp, 2lb.)",
            "Spear(1D piercing, Thrown 20/60, Versatile-D8)(1gp, 3lb.)"
        };
        public static List<string> SimpleRangedWeapons { get; set; } = new List<string>
        {
            "Light crossbow(1D8 piercing, Ammo 80/320, Loading, Two-Handed)(25gp, 5lb.)",
            "Dart(1D4 piercing, Finesse, Thrown 20/60)(5cp, 1/4lb.)",
            "Shortbow(1D6 piercing, Ammo 80/320, Two-Handed)(25gp, 2lb.)",
            "Sling(1D4 bludgeoning, Ammo 30/120)(1sp, 0lb.)"
        };
        public static List<string> MartialMeleeWeapons { get; set; } = new List<string>
        {
            "Battleaxe(1D8 slashing Versatile-D10)(10gp, 4lb.)",
            "Flail(1D8 bludgeoning)(10gp, 2lb.)",
            "Glaive(1D10 slashing, Heavy, Reach, Two-Handed)(20gp, 6lb.)",
            "Greataxe(1D12 slashing, Heavy, Two-Handed)(30gp, 7lb.)",
            "Greatsword(2D6 slashing, Heavy, Two-Handed)(50gp, 6lb.)",
            "Halberd(1D10 slashing, Heavy, Reach, Two-Handed)(20gp, 6lb.)",
            "Lance(1D12 piercing, Reach, Special)(10gp, 6lb.)",
            "Longsword(1D8 slashing, Versatile-D10)(15gp, 3lb.)",
            "Maul(2D6 bludgeoning, Heavy, Two-Handed)(10gp, 10lb.)",
            "Morningstar(1D8 piercing)(15gp, 4lb.)",
            "Pike(1D10 piercing, Heavy, Reach, Two-Handed)(5gp, 18lb.)",
            "Rapier(1D8 piercing, Finesse)(25gp, 2lb.)",
            "Scimitar(1D6 slashing, Finesse, Light)(25gp, 3lb.)",
            "Shortsword(1D6 piercing, Finesse, Light)(10gp, 2lb.)",
            "Trident(1D6 piercing, Thrown 20/60, Versatile-D8)(5gp, 4lb.)",
            "Warpick(1D8 piercing)(5gp, 2lb.)",
            "Warhammer(1D8 bludgeoning, Versatile-D10)(15gp, 2lb.)",
            "Whip(1D4 slashing, Finesse, Reach)(2gp, 3lb.)"
        };
        public static List<string> MartialRangedWeapons { get; set; } = new List<string>
        {
            "Blowgun(1 piercing, Ammo 25/100, Loading)(10gp, 1lb.)",
            "Hand crossbow(1D6 piercing, Ammo 30/120, Light, Loading)(75gp, 3lb.)",
            "Heavy crossbow(1D10 piercing, Ammo 100/400, Heavy, Loading, Two-Handed)(50gp, 18lb.)",
            "Longbow(1D8 piercing, Ammo 150/600, Heavy, Two-Handed)(50gp, 2lb.)",
            "Net(Thrown 5/15, Special)(1gp, 3lb.)"
        };
        public static List<string> Packs { get; set; } = new List<string>
        {
            "Burglar's Pack(backpack, 1000 ball bearings, 10ft of string, bell, 5 candles, crowbar, hammer, 10 pitons, hooded lantern," +
            "\n2 flasks of oil, 5 days of rations, tinderbox, waterskin, 50ft of rope)",
            "Diplomat's Pack(chest, 2 cases for maps/scrolls, fine clothes, bottle of ink, ink pen, lamp, 2 flasks of oil, 5 sheets of paper," +
            "\nvial of perfume, sealing wax, soap)",
            "Dungeoneer's Pack(backpack, crowbar, hammer, 10 pitons, 10 torches, tinderbox, 10 days of rations, waterskin, 50ft of rope)",
            "Entertainer's Pack(backpack, bedroll, 2 costumes, 5 candles, 5 days of rations, waterskin, disguise kit",
            "Explorer's Pack(backpack, bedroll, mess kit, tinderbox, 10 torches, 10 days of rations, waterskin, 50ft of rope)",
            "Priest's Pack(backpack, blanket, 10 candles, tinderbox, alms box, 2 blocks of incense, censer, vestments," +
            "\n2 days of rations, waterskin)",
            "Scholar's Pack(backpack, book of lore, bottle of ink, ink pen, 10 sheets of parchment, little bag of sand, small knife)"
        };
        public static List<string> HolySymbols { get; set; } = new List<string>
        {
            "Holy symbol(amulet)",
            "Holy symbol(emblem)",
            "Holy symbol(reliquary)"
        };
        public static List<string> DruidicFocuses { get; set; } = new List<string>
        {
            "Druidic Focus(Sprig of mistletoe)",
            "Druidic Focus(Totem)",
            "Druidic Focus(Wooden Staff)",
            "Druidic Focus(Yew wand)"
        };
        public static List<string> ArcaneFocuses { get; set; } = new List<string>
        {
            "Arcane Focus(Crystal)",
            "Arcane Focus(Orb)",
            "Arcane Focus(Rod)",
            "Arcane Focus(Staff)",
            "Arcane Focus(Wand)"
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
            "1"
        };
        public static List<string> ArtisanTools { get; set; } = new List<string>
        {
            "Alchemist's supplies",
            "Brewer's supplies",
            "Calligrapher's supplies",
            "Carpenter's tools",
            "Cartographer's tools ",
            "Cobbler's tools",
            "Cook's utensils",
            "Glassblower's tools",
            "Jeweler's tools",
            "Leatherworker's tools",
            "Mason's tools",
            "Painter's supplies",
            "Potter's tools",
            "Smith's tools",
            "Tinker's tools",
            "Weaver's tools",
            "Woodcarver's tools",
            "1"
        };
        public static List<string> GamingSets { get; set; } = new List<string>
        {
            "Dice set",
            "Dragonchess set",
            "Playing card set",
            "Three-Dragon Ante set"
        };
        public static Dictionary<string, string> FightingStyles { get; set; } = new Dictionary<string, string>
        {
            { "Archery", "+2 atk with ranged wep" },
            { "Defense", "+1 AC in armor" },
            { "Dueling", "+2 dmg when only wielding one-handed wep" },
            { "Great Weapon Fighting", "reroll 1s and 2s on dmg with two-handed/versatile wep" },
            { "Protection", "when adj ally is attacked, use reaction to impose disadv, must wield shield" },
            { "Two-Weapon Fighting", "off-hand dmg adds stat mod" }
        };
        public static Dictionary<string, string> Maneuvers { get; set; } = new Dictionary<string, string>
        {
            { "Commander's Strike", "bonus, forgo atk to have ally use reaction to atk + SD" },
            { "Disarming Strike", "on hit, dmg + SD, Str save to disarm" },
            { "Distracting Strike", "on hit, dmg + SD, next atk gets adv" },
            { "Evasive Footwork", "on move, AC + SD until movement ends" },
            { "Feinting Attack", "bonus, adv on atk - on hit, dmg + SD" },
            { "Goading Attack", "on hit, dmg + SD, Wis save to impose disadv" },
            { "Lunging Attack", "+5ft reach on atk, dmg + SD" },
            { "Manuevering Attack", "on hit, dmg + SD, ally use reaction to move 1/2 speed without atk op" },
            { "Menacing Attack", "on hit, dmg + SD, Wis save for fear 1 turn" },
            { "Parry", "reaction, reduce dmg by Dex + SD" },
            { "Precision Attack", "atk + SD, before or after roll" },
            { "Pushing Attack", "on hit, dmg + SD, Str save push 15ft" },
            { "Rally", "bonus, ally gains temp HP = Cha + SD" },
            { "Riposte", "on enemy miss, reaction - make melee atk, dmg + SD" },
            { "Sweeping Attack", "on hit, use atk roll against adj enemy - deal SD dmg" },
            { "Trip Attack", "on hit, dmg + SD, Str save to knock prone" }
        };
        public static Dictionary<string, string> Invocations { get; set; } = new Dictionary<string, string>
        {
            { "Agonizing Blast", "" },
            { "Armor of Shadows", "" },
            { "Ascendant Step", "" },
            { "Beast Speech", "" },
            { "Beguiling Influence", "" },
            { "Bewitching Whispers", "" },
            { "Book of Ancient Secrets", "" },
            { "Chains of Carceri", "" },
            { "Devil's Sight", "" },
            { "Dreadful Word", "" },
            { "Eldritch Sight", "" },
            { "Eldritch Spear", "" },
            { "Eyes of the Rune Keeper", "" },
            { "Fiendish Vigor", "" },
            { "Gaze of Two Minds", "" },
            { "Lifedrinker", "" },
            { "Mask of Many Faces", "" },
            { "Master of Myriad Forms", "" },
            { "Minions of Chaos", "" },
            { "Mire the Mind", "" },
            { "Misty Visions", "" },
            { "One with Shadows", "" },
            { "Otherworldly Leap", "" },
            { "Repelling Blast", "" },
            { "Sculptor of Flesh", "" },
            { "Sign of Ill Omen", "" },
            { "Thief of Five Fates", "" },
            { "Thirsting Blade", "" },
            { "Visions of Distant Realms", "" },
            { "Voice of the Chain Master", "" },
            { "Whispers of the Grave", "" },
            { "Witch Sight", "" }
        };
    }
}
