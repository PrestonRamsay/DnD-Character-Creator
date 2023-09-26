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
            "Artificer",
            "Barbarian",
            "Bard",
            "Bloodhunter",
            "Cleric",
            "Druid",
            "Fighter",
            "Monk",
            "Paladin",
            "Psion",
            "Ranger",
            "Rogue",
            "Sorcerer",
            "Swordmage",
            "Warlock",
            "Wizard"
        };
        public static List<string> Races { get; set; } = new List<string>
        {
            "Aasimar",
            "Cambion",
            "Changeling",
            "Demigod",
            "Dhampir",
            "Dragonborn",
            "Dwarf",
            "Elf",
            "Genasi",
            "Gnome",
            "Goliath",
            "Half-Elf",
            "Half-Orc",
            "Halfling",
            "Human",
            "Minotaur",
            "Shade",
            "Tiefling"
        };
        public static List<string> OfficialRaces { get; set; } = new List<string>
        {
            "Aarakocra",
            "Bugbear",
            "Centaur",
            "Firbolg",
            "Genasi",
            "Gith",
            "Goblin",
            //"Grung",
            "Hobgoblin",
            //"Kalashtar",
            "Kenku",
            "Kobold",
            //"Leonin",
            "Lizardfolk",
            //"Locathah",
            "Loxodon",
            "Orc",
            //"Satyr",
            "Shifter",
            "Simic Hybird",
            "Tabaxi",
            "Tortle",
            "Triton",
            "Vedalken",
            "Verdan",
            "Warforged",
            "Yuan-ti Pureblood"
        };
        public static List<string> ExtendedRaces { get; set; } = new List<string>
        {
            "Deva",
            "Doppelganger",
            "Dryad",
            "Gargoyle",
            "Myconid",
            "Pixie",
            "Shardmind",
            "Skeleton",
            "Wilden",
            "Zombie"
        };
        public static List<string> UARaces { get; set; } = new List<string>
        {
            "Dhampir",
            "Fairy",
            "Hexblood",
            "Owlfolk",
            "Rabbitfolk",
            "Reborn"
        };
        public static List<string> SubRaces { get; set; } = new List<string>
        {
            "Aasimar(Protector)",
            "Aasimar(Scourge)",
            "Aasimar(Fallen)",
            "Dwarf(Hill)",
            "Dwarf(Mountain)",
            "Avariel",
            "Drow",
            "Eladrin",
            "Moon Elf",
            "Sea Elf",
            "Shadar-Kai",
            "High Elf",
            "Wild Elf",
            "Wood Elf",
            "Air Genasi",
            //"Cinder Genasi",
            "Earth Genasi",
            "Fire Genasi",
            //"Plague Genasi",
            //"Storm Genasi",
            //"Venom Genasi",
            //"Void Genasi",
            "Water Genasi",
            "Githyanki",
            "Githzerai",
            "Gnome(Deep)",
            "Gnome(Forest)",
            "Gnome(Rock)",
            "Halfling(Lightfoot)",
            "Halfling(Stout)",
            //"Hobgoblin of the Feywild",
            "Human",
            "Variant Human",
            "Myconid(Compost)",
            "Myconid(Growth)",
            "Myconid(Sporemaster)",
            //"Orc",
            //"Orc of Eberron",
            //"Orc of Exandria",
            "Shardmind(God Shard)",
            "Shardmind(Shard Slayer)",
            "Shardmind(Thought Builder)",
            "Beasthide Shifter",
            "Longtooth Shifter",
            "Swiftstride Shifter",
            "Wildhunt Shifter",
            "Tiefling",
            "Feral Tiefling",
            "Warforged(Envoy)",
            "Warforged(Juggernaut)",
            "Warforged(Skirmisher)",
            "Wilden(Ancients)",
            "Wilden(Destroyer)",
            "Wilden(Hunter)"
        };
        public static List<string> DemigodDomains { get; set; } = new List<string>
        {
            "Beauty",
            "Knowledge",
            "Life",
            "Luck",
            "Madness",
            "Magic",
            "Music",
            "Protection",
            "Smithing",
            "The Earth",
            "The Hunt",
            "The Sea",
            "The Sky",
            "The Sun",
            "Travel",
            "Trickery",
            "Undead",
            "War"
        };
        public static List<string> Templates { get; set; } = new List<string>
        {
            "Aberrant Horror",
            "Fiend",
            "Lich",
            "Lycanthrope",
            "Seraph",
            "Vampire"
        };
        public static List<string> UniversalMilestones { get; set; } = new List<string>
        {
            "Undertaking an exceptionally good or evil act.",
            "Completing an ancient ritual.",
            "Obtaining a powerful artifact.",
            "Being cursed by a dark agent.",
            "Being exalted by a patron or god."
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
        public static List<string> StandardLanguages { get; set; } = new List<string>
        {
            "Dwarven",
            "Elven",
            "Giant",
            "Gnomish",
            "Goblin",
            "Halfling",
            "Orc"
        };
        public static List<string> ExoticLanguages { get; set; } = new List<string>
        {
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
        public static List<string> GHBackgrounds { get; set; } = new List<string>
        {
            "Academic",
            "Aristocrat",
            "Clergy",
            "Common Folk",
            "Criminal",
            "Militarist",
            "Outlander",
            "Seafarer"
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
        public static Dictionary<string, string> FeatDefinitions { get; set; } = new Dictionary<string, string>
        {
            { "Acute Fighting", "wep dmg + 1D4" },
            { "Alert", "Init + 5, can't be surprsied, negate adv from hiding" },
            { "Arcane Initiate", "gain an Artificer cantrip and LR, 1st lvl Artificer spell, prof with 1 set of Artisan's Tools" },
            { "Athlete", "Increase Str or Dex by 1, when prone - stand up for 5ft of movement, gain Climb speed, standing jumps count as running jumps" },
            { "Actor", "Increase Int by 1, gain adv on Deception and Performance when impersonating, mimic speech if heard for 1 min(Decepetion vs Insight)" },
            { "Bountiful Luck", "reaction, 30ft, when ally rolls a 1 on atk, save, or check they can reroll" },
            { "Charger", "bonus, Dash make a melee atk - if you move 10ft, +5 dmg or push 10ft" },
            { "Chef", "Increase Con or Wis by 1, gain prof with Cook's Utensils / on SR, 4 + PB creatures, regain 1D8 HP" +
                "\n                 on LR, 8 hr, PB treats - bonus, gain PB temp HP" },
            { "Crossbow Expert", "ignore Loading, no disadv when threatened / bonus, when you use Attack action with One-Handed wep, make atk with Hand Crossbow" },
            { "Crusher", "Increase Str or Con by 1 / on hit, 1/turn, if Bludgeoning - push 5ft / on Bludgeoning crit - adv on atk next turn" },
            { "Defensive Duelist", "reaction, when you're hit with melee, AC + PB" },
            { "Dragon Fear", "Increase Str, Con, or Cha by 1 / expend Breath Weapon, 30ft, Cha-based Wis save, fear 1 min" },
            { "Dragon Hide", "Increase Str, Con, or Cha by 1 / AC = 13 + Dex while not wearing armor" },
            { "Drow High Magic", "cast Detect Magic at-will, gain Levitate and Dispel Magic spells" },
            { "Dual Wielder", "while wielding 2 weapons, +1 AC / use Two-Weapon Fighting with non-Light weapons / draw or stow 2 weapons" },
            { "Dungeon Delver", "gain adv on Perception or Investigation to detect secret doors, adv on saves to avoid traps" +
                "\n                 gain Resistance to trap dmg, search for traps at normal pace" },
            { "Durable", "Increase Con by 1 / on SR, when you roll HD to gain HP, regain HP = Con * 2" },
            { "Dwarven Fortitude", "Increase Con by 1 / when you take Dodge action, expend 1 Hit Die to heal Hit Die + Con HP" },
            { "Eldritch Adept", "gain a Warlock Invocation, you can replace it at lvl ups, must meet requirements" },
            { "Elemental Adept", "spells of dmg type (Cold, Fire, Lightning, Thunder) ignore Resistance and dmg rolls of 1 are considered 2s" },
            { "Elven Accuracy", "Increase Dex, Int, Wis, or Cha by 1 / when you have adv on an atk using Dex, Int, Wis, or Cha - reroll 1 die once" },
            { "Fade Away", "Increase Dex or Int by 1 / SR, reaction, when you take dmg, become invisible" },
            { "Fey Teleportation", "Increase Int or Cha by 1 / learn Sylvan / SR, cast Misty Step without using a spell slot" },
            { "Fey Touched", "Increase Int, Wis, or Cha by 1 / gain a 1st lvl divination or enchantment spell / LR, cast Misty Step or 1st lvl spell" },
            { "Fighting Initiate", "gain a Fighting Style, you can replace it when you gain an Ability Score Improvement" },
            { "Finesse Weapon Master", "-5 atk = +10 dmg, Acrobatics check to gain adv" },
            { "Flames of Phlegethos", "Increase Int or Cha by 1 / reroll 1s on Fire dmg spells then for 1 turn - bright light 30ft/dim light 30ft, adj 1D4 Fire dmg" },
            { "Grappler", "gain adv on atks vs creatures you are grappling, make another grapple check to restrain, grapple one size larger" },
            { "Great Weapon Master", "-5 atk = +10 dmg, if crit or kill - make melee atk as bonus" },
            { "Gunner", "Increase Dex by 1 / gain prof with Firearms, ignore Loading, no disadv when threatened" },
            { "Healer", "using Healer's Kit to stabilize also grants 1 HP / SR, action, use Healer's Kit to restore HP = 1D6 + 4 + creature's HD" },
            { "Heavily Armored", "Increase Str by 1 / gain prof with Heavy Armor" },
            { "Heavy Armor Master", "Increase Str by 1 / while wearing Heavy Armor, reduce nonmagical B/P/S by 3" },
            { "Improved Critical", "increase your crit range by 1 (ex. 20 = 19-20)" },
            { "Infernal Constitution", "Increase Con by 1 / gain Resistance to Cold and Poison, gain adv on saves vs poison(condition)" },
            { "Insightful Reflexes", "use Int for AC instead of Dex" },
            { "Inspiring Leader", "SR, spend 10 min, 30ft, 6 creatures, gain temp HP = lvl + Cha" },
            { "Jack of All Trades", "1/2 PB to all untrained skills" },
            { "Keen Mind", "Increase Int by 1 / always know true north, always know hr before sunrise/sunset, accurately recall anything seen/heard in past month" },
            { "Lightly Armored", "Increase Str or Dex by 1 / gain prof with Light Armor" },
            { "Linguist", "Increase Int by 1 / gain 3 languages, create written ciphers (Int DC = Int score + PB)" },
            { "Lucky", "LR, gain 3 luck pts - roll twice for atk, save, or check and use either roll / can also use on atk against you" },
            { "Mage Slayer", "reaction, if adj creature casts a spell, make a melee atk / impose disadv on Con checks for conc" +
                "\n                 adv on saves vs spells cast by adj creature" },
            { "Magic Initiate", "gain 2 (Bard, Cleric, Druid, Sorcerer, Warlock, or Wizard) cantrips and a 1st lvl spell (LR to cast)" },
            { "Martial Adept", "gain a Superior Die (if none = D6), gain 2 Maneuvers from Battle Master, Str or Dex-based DCs" },
            { "Medium Armor Master", "Medium Armor doesn't impose disadv on Stealth, +1 AC" },
            { "Metamagic Adept", "gain 2 Sorcery pts, learn 2 Metamagic options, you can replace a Metamagic option when you gain an Ability Score Improvement" },
            { "Mobile", "speed +10ft, ignore difficult terrain when you Dash, when you atk - no atk op from that creature this turn" },
            { "Moderately Armored", "Increase Str or Dex by 1 / gain prof with Medium Armor and Shields" },
            { "Mounted Combatant", "gain adv on melee atk vs unmounted(smaller than mount), force an atk against your mount to target you, mount gains Evasion" },
            { "Observant", "Increase Int or Wis by 1 / lip-reading if you share a language, +5 to Perception and Investigation" },
            { "Orcish Fury", "Increase Str or Con by 1 / SR, on hit, dmg + 1 weapon die / reaction, after using Relentless Endurance, make an atk" },
            { "Piercer", "Increase Str or Dex by 1 / 1/turn, reroll Piercing dmg / on Piercing crit, dmg + 1 weapon die" },
            { "Point Blank Shot", "no disadv when threatened / no action, 1 turn, 30ft, dmg + 4" },
            { "Poisoner", "ignore Poison Resistance, apply poison as a bonus, gain prof with Poisoner's Kit / 1 hr & 50gp, PB doses - 1 min, Con DC 14, 2D8 Poison dmg" },
            { "Polearm Master", "while wielding Glaive, Halberd, or Quarterstaff - make melee atk as a bonus(1D4 Bludgeoning), provoke atk op when creatures enter your reach" },
            { "Prodigy", "gain a skill, tool prof, and lang / gain Expertise in 1 skill" },
            { "Rapid Shot", "make a ranged atk as a bonus" },
            { "Regeneration", "1/turn, no action, heal 1 HP / action, heal 1D6 + Con / outside combat, heal 1D6 HP/hr" },
            { "Resilient", "Increase any Stat by 1 / gain prof in saves for chosen Stat" },
            { "Ritual Caster", "gain 2 (Bard, Cleric, Druid, Sorcerer, Warlock, or Wizard) 1st lvl ritual spells / (2 hr and 50gp)/spell lvl, copy a new ritual if its on spell list" },
            { "Savage Attacker", "1/turn, roll melee weapon dmg twice and use either roll" },
            { "Second Chance", "Increase Dex, Con, or Cha by 1 / SR or Init, reaction, when hit, reroll atk against you" },
            { "Sentinel", "on atk op hit, speed = 0 / negate Disengage benefits / reaction, adj creature atks ally, make a melee atk" },
            { "Shadow Touched", "Increase Int, Wis, or Cha by 1 / gain a 1st lvl illusion or necromancy spell / LR, cast Invisibility spell or 1st lvl spell" },
            { "Sharpshooter", "-5 atk = +10 dmg, long range doesn't impose disadv, ranged atks ignore half and 3/4 cover" },
            { "Shield Master", "bonus, when you make Attack action, shove adj creature / Dex saves + Shield AC bonus / reaction, on successful Dex save, no dmg instead of 1/2" },
            { "Skill Expert", "Increase any Stat by 1 / gain prof in 1 skill / gain Expertise in 1 skill" },
            { "Skilled", "gain prof in any combination of 3 skills/tools" },
            { "Skirmisher", "bonus, Disengage, gain +1 AC and dmg + 1D6 for 1 turn" },
            { "Skulker", "use Hide when only lightly obscured, while Hidden - missing a ranged atk doesn't reveal position, dim light doesn't impose disadv on Perception" },
            { "Slasher", "Increase Str or Dex by 1 / 1/turn, if Slashing - reduce speed by 10ft / on Slashing crit, target suffers disadv on atk next turn" },
            { "Spell Focus", "spell DCs + 2" },
            { "Spell Sniper", "double spells' range, spells ignore 1/2 and 3/4 cover, gain a (Bard, Cleric, Druid, Sorcerer, Warlock, or Wizard) cantrip" },
            { "Squat Nimbleness", "Increase Str or Dex by 1 / increase speed by 5ft, gain prof in Acrobatics or Athletics, gain adv on checks vs grapple" },
            { "Tavern Brawler", "Increase Str or Dex by 1 / gain prof with improvised and unarmed atks, unarmed dmg = 1D4 / bonus, hit with improvised for unarmed atk, grapple check" },
            { "Telekinetic", "Increase Int, Wis, or Cha by 1 / gain Mage Hand cantrip (if you already know range +30ft), its invisibile and doesn't require V or S components" +
                "\n                 bonus, 30ft, Str save, push 5ft" },
            { "Telepathic", "Increase Int, Wis, or Cha by 1 / gain Telepathy 60ft / LR or 2nd lvl spell slot, cast Detect Thoughts" },
            { "Tough", "gain max HP = lvl x 2, each lvl up gain 2 max HP" },
            { "Unarmored Defense", "while wearing no armor, AC = 10 + Dex + (Con or Wis)" },
            { "War Caster", "gain adv on Con saves for conc, perform somatic components while both hands are holding weapons/shields / reaction, atk op with spell" },
            { "Weapon Focus", "pick a specific weapon(ex. Longsword, Unarmed Strike, Club), +2 atk/dmg" },
            { "Weapon Master", "Increase Str or Dex by 1 / gain prof with 4 weapons of your choice" },
            { "Whirlwind Attack", "action, make an melee atk against each enemy within reach" },
            { "Wood Elf Magic", "gain a Druid cantrip, gain Longstrider and Pass without Trace spells" }
        };
        public static List<string> LightArmor { get; set; } = new List<string>
        {
            "Padded(+1 AC, Stealth disadv)(5gp, 8lb.)",
            "Leather(+1 AC)(10gp, 10lb.)",
            "Studded leather(+2 AC)(45gp, 13lb.)"
        };
        public static List<string> MediumArmor { get; set; } = new List<string>
        {
            "Hide(+2 AC)(10gp, 12lb.)",
            "Chain Shirt(+3 AC)(50gp, 20lb.)",
            "Scalemail(+4 AC, Stealth disadv)(50gp, 45lb.)",
            "Breastplate(+4 AC)(400gp, 20lb.)",
            "Half-plate(+5 AC, Stealth disadv)(750gp, 40lb.)"
        };
        public static List<string> HeavyArmor { get; set; } = new List<string>
        {
            "Ringmail(+4 AC, Stealth disadv)(30gp, 40lb.)",
            "Chainmail(+6 AC, Stealth disadv)(75gp, 55lb.)",
            "Splint(+7 AC, Stealth disadv)(200gp, 60lb.)",
            "Fullplate(+8 AC, Stealth disadv)(1,500gp, 65lb.)"
        };
        public static List<string> SimpleMeleeWeapons { get; set; } = new List<string>
        {
            "Club(1D4 Bludgeoning, Light)(1sp, 2lb.)",
            "Dagger(1D4 Piercing, Finesse, Light, Thrown 20/60)(2gp, 1lb.)",
            "Greatclub(1D8 Bludgeoning, Two-Handed)(2sp, 10lb.)",
            "Handaxe(1D6 Slashing, Light, Thrown 20/60)(5gp, 2lb.)",
            "Javelin(1D6 Piercing, Thrown 30/120)(5sp, 2lb.)",
            "Light Hammer(1D4 Bludgeoning, Light, Thrown 20/60)(2gp, 2lb.)",
            "Mace(1D6 Bludgeoning)(5gp, 4lb.)",
            "Quarterstaff(1D6 Bludgeoning, Versatile-D8)(2sp, 4lb.)",
            "Sickle(1D4 Slashing, Light)(1gp, 2lb.)",
            "Spear(1D6 Piercing, Thrown 20/60, Versatile-D8)(1gp, 3lb.)"
        };
        public static List<string> SimpleRangedWeapons { get; set; } = new List<string>
        {
            "Light Crossbow(1D8 Piercing, 80/320, Ammo, Loading, Two-Handed)(25gp, 5lb.)",
            "Dart(1D4 Piercing, Finesse, Thrown 20/60)(5cp, 1/4lb.)",
            "Shortbow(1D6 Piercing, 80/320, Ammo, Two-Handed)(25gp, 2lb.)",
            "Sling(1D4 Bludgeoning, 30/120, Ammo)(1sp, 0lb.)"
        };
        public static List<string> MartialMeleeWeapons { get; set; } = new List<string>
        {
            "Battleaxe(1D8 Slashing, Versatile-D10)(10gp, 4lb.)",
            "Flail(1D8 Bludgeoning)(10gp, 2lb.)",
            "Glaive(1D10 Slashing, Heavy, Reach, Two-Handed)(20gp, 6lb.)",
            "Greataxe(1D12 Slashing, Heavy, Two-Handed)(30gp, 7lb.)",
            "Greatsword(2D6 Slashing, Heavy, Two-Handed)(50gp, 6lb.)",
            "Halberd(1D10 Slashing, Heavy, Reach, Two-Handed)(20gp, 6lb.)",
            "Lance(1D12 Piercing, Reach, Special)(10gp, 6lb.)",
            "Longsword(1D8 Slashing, Versatile-D10)(15gp, 3lb.)",
            "Maul(2D6 Bludgeoning, Heavy, Two-Handed)(10gp, 10lb.)",
            "Morningstar(1D8 Piercing)(15gp, 4lb.)",
            "Pike(1D10 Piercing, Heavy, Reach, Two-Handed)(5gp, 18lb.)",
            "Rapier(1D8 Piercing, Finesse)(25gp, 2lb.)",
            "Scimitar(1D6 Slashing, Finesse, Light)(25gp, 3lb.)",
            "Shortsword(1D6 Piercing, Finesse, Light)(10gp, 2lb.)",
            "Trident(1D6 Piercing, Thrown 20/60, Versatile-D8)(5gp, 4lb.)",
            "Warpick(1D8 Piercing)(5gp, 2lb.)",
            "Warhammer(1D8 Bludgeoning, Versatile-D10)(15gp, 2lb.)",
            "Whip(1D4 Slashing, Finesse, Reach)(2gp, 3lb.)"
        };
        public static List<string> MartialRangedWeapons { get; set; } = new List<string>
        {
            "Blowgun(1 Piercing, 25/100, Ammo, Loading)(10gp, 1lb.)",
            "Hand Crossbow(1D6 Piercing, 30/120, Ammo, Light, Loading)(75gp, 3lb.)",
            "Heavy Crossbow(1D10 Piercing, 100/400, Ammo, Heavy, Loading, Two-Handed)(50gp, 18lb.)",
            "Longbow(1D8 Piercing, 150/600, Ammo, Heavy, Two-Handed)(50gp, 2lb.)",
            "Net(Thrown 5/15, Special)(1gp, 3lb.)"
        };
        public static List<string> AdvancedMeleeWeapons { get; set; } = new List<string>
        {
            "Cavalry Hammer(1D8 Bludgeoning, Versatile-D10, Momentum-D12, Armor Piercing)(500gp, 3lb.)",
            "Claymore(2D6 Slashing, 30/120, Brutal, Heavy, Two-Handed)(500gp, 7lb.)",
            "Polearm(1D12 Piercing, 150/600, Guard, Heavy, Reach, Two-Handed)(500gp, 12lb.)",
            "Sabre(1D8 Slashing, 100/400, Swift, Finesse)(500gp, 2lb.)"
        };
        public static List<string> AdvancedRangedWeapons { get; set; } = new List<string>
        {
            "Blackpowder Pistol(2D4 Piercing, 25/100, Ammo, Blackpowder, Light, Loading)(200gp, 4lb.)",
            "Blackpowder Rifle(2D6 Piercing, 80/300, Ammo, Blackpowder, Loading, Two-Handed)(500gp, 10lb.)",
            "Blunderbuss(2D6 Piercing, 20/30, Ammo, Blackpowder, Cumbersome, Loading, Scatter-line 10, Two-Handed)(750gp, 10lb.)",
            "Flame Bellows(2D6 Fire, 15/-, Ammo, Cumbersome, Loading, Scatter-cone 15, Two-Handed)(750gp, 11lb.)",
            "Repeater Crossbow(1D8 Piercing, 80/300, Ammo, Loading, Repeater, Two-Handed)(750gp, 7lb.)"
        };
        public static List<string> Firearms { get; set; } = new List<string>
        {
            "Pistol(1D10 Piercing, 100/400, Reload 4, Misfire 1)(250gp, 3lb.)",
            "Musket/Rifle(1D12 Piercing, 200/800, Two-Handed, Reload 1, Misfire 2)(500gp, 10lb.)",
            "Pepperbox(1D10 Piercing, 150/600, Reload 6, Misfire 2)(450gp, 5lb.)",
            "Scattergun(1D8 Piercing, 15/30, Scatter, Reload 2, Misfire 3)(500gp, 10lb.)",
            "Bad News(2D12 Piercing, 300/1200, Two-Handed, Reload 1, Misfire 3)(crafted, 25lb.)",
            "Hand Mortar(2D8 Fire, 30/60, Explosive, Reload 1, Misfire 3)(crafted, 10lb.)"
        };
        public static List<string> Packs { get; set; } = new List<string>
        {
            "Burglar's Pack(backpack, 1000 ball bearings, 10ft of string, bell, 5 candles, crowbar, hammer, 10 pitons, hooded lantern, 2 flasks of oil," +
            "\n     5 days of rations, tinderbox, waterskin, 50ft of rope)",
            "Diplomat's Pack(chest, 2 cases for maps/scrolls, fine clothes, bottle of ink, ink pen, lamp, 2 flasks of oil, 5 sheets of paper," +
            "\n     vial of perfume, sealing wax, soap)",
            "Dungeoneer's Pack(backpack, crowbar, hammer, 10 pitons, 10 torches, tinderbox, 10 days of rations, waterskin, 50ft of rope)",
            "Entertainer's Pack(backpack, bedroll, 2 costumes, 5 candles, 5 days of rations, waterskin, Disguise Kit",
            "Explorer's Pack(backpack, bedroll, mess kit, tinderbox, 10 torches, 10 days of rations, waterskin, 50ft of rope)",
            "Priest's Pack(backpack, blanket, 10 candles, tinderbox, alms box, 2 blocks of incense, censer, vestments, 2 days of rations, waterskin)",
            "Scholar's Pack(backpack, book of lore, bottle of ink, ink pen, 10 sheets of parchment, little bag of sand, small knife)"
        };
        public static List<string> HolySymbols { get; set; } = new List<string>
        {
            "Holy symbol(Amulet)",
            "Holy symbol(Emblem)",
            "Holy symbol(Reliquary)"
        };
        public static List<string> DruidicFocuses { get; set; } = new List<string>
        {
            "Druidic Focus(Sprig of mistletoe)",
            "Druidic Focus(Totem)",
            "Druidic Focus(Wooden staff)",
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
        public static List<string> PsiCrystals { get; set; } = new List<string>
        {
            "Psi Crystal(Bully)",
            "Psi Crystal(Calm)",
            "Psi Crystal(Creative)",
            "Psi Crystal(Cunning)",
            "Psi Crystal(Energetic)",
            "Psi Crystal(Friendly)",
            "Psi Crystal(Hero)",
            "Psi Crystal(Observant)",
            "Psi Crystal(Sympathetic)",
            "Psi Crystal(Wise)"
        };
        public static List<string> StarMaps { get; set; } = new List<string>
        {
            "Star Map(Scroll covered with constellation depictions)",
            "Star Map(Stone tablet with fine holes drilled in it)",
            "Star Map(Speckled owlbear hide with raised marks)",
            "Star Map(Collection of maps bound with ebony cover)",
            "Star Map(Crystal that projects starry patterns when in light)",
            "Star Map(Glass disks that depict constellations)"
        };
        public static List<string> MercifulMasks { get; set; } = new List<string>
        {
            "Merciful Mask(Raven)",
            "Merciful Mask(Blank white)",
            "Merciful Mask(Crying visage)",
            "Merciful Mask(Laughing visage)",
            "Merciful Mask(Skull)",
            "Merciful Mask(Butterfly)"
        };
        public static List<string> GenieVessels { get; set; } = new List<string>
        {
            "Genie Vessel(Oil lamp)",
            "Genie Vessel(Urn)",
            "Genie Vessel(Ring with a compartment)",
            "Genie Vessel(Stoppered bottle)",
            "Genie Vessel(Hollow statuette)",
            "Genie Vessel(Ornate lantern)"
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
            "Viol"
        };
        public static List<string> ArtisanTools { get; set; } = new List<string>
        {
            "Alchemist's Supplies",
            "Brewer's Supplies",
            "Calligrapher's Supplies",
            "Carpenter's Tools",
            "Cartographer's Tools ",
            "Cobbler's Tools",
            "Cook's Utensils",
            "Glassblower's Tools",
            "Jeweler's Tools",
            "Leatherworker's Tools",
            "Mason's Tools",
            "Painter's Supplies",
            "Potter's Tools",
            "Smith's Tools",
            "Tinker's Tools",
            "Weaver's Tools",
            "Woodcarver's Tools"
        };
        public static List<string> Tools { get; set; } = new List<string>
        {
            "Artisan's Tools",
            "Disguise Kit",
            "Forgery Kit",
            "Gaming Set",
            "Herbalism Kit",
            "Musical Instrument",
            "Navigator's Tools",
            "Poisoner's Kit",
            "Thieves' Tools",
            "Vechiles(land)",
            "Vechiles(water)"
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
            { "Blessed Warrior", "learn 2 cantrips from the Cleric list, when you gain a lvl - you can replace a cantrip" },
            { "Blind Fighting", "gain Blindsight 10ft - blindness, darkness, and invisibility" },
            { "Defense", "+1 AC in armor" },
            { "Druidic Warrior", "learn 2 cantrips from the Druid list, when you gain a lvl - you can replace a cantrip" },
            { "Dueling", "+2 dmg when only wielding one-handed wep" },
            { "Great Weapon Fighting", "reroll 1s and 2s on dmg with two-handed/versatile wep" },
            { "Interception", "reaction, when ally is hit, reduce dmg by 1D10 + prof bons, must wield shield" },
            { "Protection", "when adj ally is attacked, use reaction to impose disadv, must wield shield" },
            { "Superior Technique", "SR, D6, Str or Dex-based DC, " },
            { "Thrown Weapon Fighting", "when you use an Attack action to throw a weapon, dmg + 2, draw a weapon" },
            { "Two-Weapon Fighting", "off-hand dmg adds stat mod" },
            { "Unarmed Fighting", "dmg = 1D6 or 1D8 if wielding no weapons or shield, deal 1D4 to a grappled target" }
        };
        public static Dictionary<string, string> Maneuvers { get; set; } = new Dictionary<string, string>
        {
            { "Ambush", "on Init, Stealth + SD" },
            { "Bait and Switch", "switch places with adj ally, no atk op, you and ally gain AC + SD, 1 turn" },
            { "Brace", "reaction, when creature comes in reach, make atk, dmg + SD" },
            { "Commander's Strike", "bonus, forgo atk to have ally use reaction to atk + SD" },
            { "Commanding Presence", "Intimidation, Performance, or Persuasin check + SD" },
            { "Disarming Strike", "on hit, dmg + SD, Str save to disarm" },
            { "Distracting Strike", "on hit, dmg + SD, next atk gets adv" },
            { "Evasive Footwork", "on move, AC + SD until movement ends" },
            { "Feinting Attack", "bonus, adv on atk - on hit, dmg + SD" },
            { "Goading Attack", "on hit, dmg + SD, Wis save to impose disadv" },
            { "Grappling Strike", "bonus, on hit, grapple target, Athletics + SD" },
            { "Lunging Attack", "+5ft reach on atk, dmg + SD" },
            { "Manuevering Attack", "on hit, dmg + SD, ally use reaction to move 1/2 speed without atk op" },
            { "Menacing Attack", "on hit, dmg + SD, Wis save for fear 1 turn" },
            { "Parry", "reaction, reduce dmg by Dex + SD" },
            { "Precision Attack", "atk + SD, before or after roll" },
            { "Pushing Attack", "on hit, dmg + SD, Str save push 15ft" },
            { "Quick Toss", "bonus, make a ranged atk with thrown weapon and draw a weapon, dmg + SD" },
            { "Rally", "bonus, ally gains temp HP = Cha + SD" },
            { "Riposte", "on enemy miss, reaction - make melee atk, dmg + SD" },
            { "Sweeping Attack", "on hit, use atk roll against adj enemy - deal SD dmg" },
            { "Tactical Assessment", "History, Insight, or Investigation" },
            { "Trip Attack", "on hit, dmg + SD, Str save to knock prone" }
        };
        public static Dictionary<string, string> ArcaneShotOptions { get; set; } = new Dictionary<string, string>
        {
            { "Banishing Arrow", "Cha save, 1 turn, speed = 0, suffer incap" },
            { "Beguiling Arrow", "2D6 Psychic dmg, 30ft, choose ally, Wis save, charm 1 turn" },
            { "Bursting Arrow", "10ft, 2D6 Force dmg" },
            { "Enfeebling Arrow", "2D6 Necrotic dmg, Con save, dmg is halved for 1 turn" },
            { "Grasping Arrow", "2D6 Poison dmg, 1 min, speed -10ft, 1st move each turn - 2D6 Slashing, Athletics vs DC to free" },
            { "Piercing Arrow", "no atk roll, Dex save, 30ft line, ignores cover, +1D6 Piercing dmg" },
            { "Seeking Arrow", "no atk roll, Dex save, turns corners, ignores 3/4 cover, +1D6 Force dmg" },
            { "Shadow Arrow", "2D6 Psychic dmg, Wis save, can only see 5ft" }
        };
        public static Dictionary<string, string> ArcaneShotOptionsImp { get; set; } = new Dictionary<string, string>
        {
            { "Banishing Arrow", "Cha save, 2D6 force dmg, 1 turn, speed = 0, suffer incap" },
            { "Beguiling Arrow", "4D6 Psychic dmg, 30ft, choose ally, Wis save, charm 1 turn" },
            { "Bursting Arrow", "10ft, 4D6 Force dmg" },
            { "Enfeebling Arrow", "4D6 Necrotic dmg, Con save, dmg is halved for 1 turn" },
            { "Grasping Arrow", "4D6 Poison dmg, 1 min, speed -10ft, 1st move each turn - 2D6 Slashing, Athletics action vs DC to free" },
            { "Piercing Arrow", "no atk roll, Dex save, 30ft line, ignores cover, +2D6 Piercing dmg" },
            { "Seeking Arrow", "no atk roll, Dex save, turns corners, ignores 3/4 cover, +2D6 Force dmg" },
            { "Shadow Arrow", "4D6 Psychic dmg, Wis save, can only see 5ft" }
        };
        public static Dictionary<string, string> Metamagic { get; set; } = new Dictionary<string, string>
        {
            { "Careful Spell", "1 sorcery pt, choose Cha creatures to auto-succeed on spell save" },
            { "Distant Spell", "1 sorcery pt, double a spell's range or if its touch - range becomes 30ft" },
            { "Empowered Spell", "1 sorcery pt, reroll Cha dice on dmg, must use new rolls" },
            { "Extended Spell", "1 sorcery pt, for a spell 1 min or longer, double its' duration" },
            { "Heightened Spell", "3 sorcery pts, impose disadv on save vs your spell" },
            { "Quicken Spell", "2 sorcery pts, cast a spell that requires an action as a bonus" },
            { "Seeking Spell", "2 sorcery pt, when you miss an atk, reroll atk, must use new roll" },
            { "Subtle Spell", "1 sorcery pt, cast a spell without verbal or somatic components" },
            { "Transmuted Spell", "1 sorcery pt, change a spell's dmg type to Acid, Cold, Fire, Lightning, Poison, or Thunder" },
            { "Twinned Spell", "spell lvl(1 for cantrip) sorcery pt, make a spell that targets 1 creature target 2 instead" }
        };
        public static Dictionary<string, string> BloodCurses { get; set; } = new Dictionary<string, string>
        {
            { "Blood Curse of Binding", "bonus, 30ft, 1 Large or smaller creature, Wis-based Str save, speed = 0ft for 1 turn" +
                "\n        Amplified - 1 Hitdie, no size limit, duration = until successful save" },
            { "Blood Curse of the Eyeless", "bonus, 30ft, next atk - Wis" +
                "\n        Amplified - 1 Hitdie, atk - Wis for 1 turn" },
            { "Blood Curse of the Fallen Puppet", "reaction, 30ft, when creature dies/falls unconscious, creature makes an atk" +
                "\n        Amplified - 1 Hitdie, atk/dmg + Wis" },
            { "Blood Curse of the Fending Rite", "reaction, when enemy casts a spell, save + Wis" +
                "\n        Amplified - 1 Hitdie, allies within 10ft gain save + Wis" },
            { "Blood Curse of the Marked", "bonus, 1 turn, 30ft, Crimson Rite dmg x 2" +
                "\n        Amplified - 1 Hitdie, target loses Resistance to Crimson Rite dmg type" },
            { "Blood Curse of Mutual Suffering", "bonus, Wis rounds, 30ft, when target dmgs you, Necrotic dmg = 1/2 dmg taken" +
                "\n        Amplified - 1 Hitdie, duration = 1 min, this curse ignores Necrotic Resistance" },
            { "Blood Curse of Spell Sunder", "reaction, 30ft, when a spell atk targets you, impose disadv" +
                "\n        Amplified - 2 Hitdie, Wis check = 10 + lvl to dispel the atk, fail = impose disadv" }
        };
        public static Dictionary<string, string> Mutagens { get; set; } = new Dictionary<string, string>
        {
            { "Aether", "gain Fly 20ft, suffer disadv on Str and Dex checks" }, //lvl 10
            { "Celerity", "Dex + mutation score, Wis - mutation score" },
            { "Conversant", "gain adv on Int checks, suffer disadv on Cha checks" },
            { "Cruelty", "gain extra atk, suffer disadv on saves" },
            { "Impermeable", "gain Resistance to Piercing, suffer Vulnerability to Slashing" },
            { "Mobility", "Init - (mutation score x 2), gain Immunity to grapple, restrain" }, //if lvl 10 += , paralyze
            { "Nighteye", "gain or increase Darkvision 60ft, gain Sunlight Sensitivity(disadv on atks and Perception in sunlight)" },
            { "Potency", "Str + mutation score, Dex - mutation score" },
            { "Precision", "crit on 19-20, half all healing received" }, //lvl 7, if lvl 15 - crit 18-20
            { "Rapidity", "gain speed +10ft, enemies crit on 19-20" }, //if lvl 15 - speed +15ft
            { "Reconstruction", "speed -10ft, if above 0 HP - 1/turn, heal HP = mutation score x 2" },
            { "Sagacity", "Wis + mutation score, AC - mutation score" },
            { "Shielded", "gain Resistance to Slashing, suffer Vulnerability to Bludgeoning" },
            { "Unbreakable", "gain Resistance to Bludgeoning, suffer Vulnerability to Piercing" },
            { "Wariness", "Init + (mutation score x 2), suffer disadv on Perception" }
        };
        public static Dictionary<string, string> Infusions { get; set; } = new Dictionary<string, string>
        {
            { "Arcane Propulsion Armor", "increase speed by 5ft, gauntlet(1D8 Force, Thrown 20/60, Returning), can't be removed, replaces limbs" },
            { "Armor of Magical Strength", "6 charges(regain 1D6 at dawn), 1 charge - (Str check/save + Int) or (reaction, negate being knocked prone)" },
            { "Boots of the Winding Path", "bonus, teleport 15ft" },
            { "Enhanced Arcane Focus", "+1 (+2 if lvl 10) to spell atks and spells ignore half cover" },
            { "Enhanced Defense", "AC + 1 (+2 if lvl 10)" },
            { "Enhanced Weapon", "+1 to atk/dmg (+2 if lvl 10)" },
            { "Helm of Awareness", "gain adv on Init, can't be surprised" },
            { "Homunculus Servant", "uses your prof bonus, defaults to Dodge, bonus to command, Mending spell heals 2D6 HP" },
            { "Mind Sharpener", "4 charges(regain 1D4 at dawn), 1 charge - succeed a Con save for conc" },
            { "Radiant Weapon", "+1 to atk/dmg, bonus - bright light 30ft/dim light 30ft / 4 charges(regain 1D4 at dawn), 1 charge - reaction, blind 1 turn" },
            { "Repeating Shot", "+1 to ranged atk/dmg, ignore Loading property, creates ammo" },
            { "Replicate Magic Item", "see Tasha's Cauldron for options, DM's Guide for defintions" },
            { "Repulsion Shield", "AC + 1 / 4 charges(regain 1D4 at dawn), 1 charge - reaction, after being hit, push 15ft" },
            { "Resistant Armor", "gain Resistance to Acid, Cold, Fire, Force, Lightning, Necrotic, Poison, Psychic, Radiant, or Thunder" },
            { "Returning Weapon", "+1 to atk/dmg, returns back to your hand after a ranged atk" },
            { "Spell-Refueling Ring", "dawn, action, recover a 3rd lvl or lower spell slot" }
        };
        public static List<string> BaseInfusions { get; set; } = new List<string>
        {
            "Armor of Magical Strength",
            "Enhanced Arcane Focus",
            "Enhanced Defense",
            "Enhanced Weapon",
            "Homunculus Servant",
            "Mind Sharpener",
            "Repeating Shot",
            "Replicate Magic Item",
            "Returning Weapon"
        };
        public static List<string> Lvl6Infusions { get; set; } = new List<string>
        {
            "Boots of the Winding Path",
            "Radiant Weapon",
            "Repulsion Shield",
            "Resistant Armor",
            "Spell-Refueling Ring"
        };
        public static Dictionary<string, string> AllInvocations { get; set; } = new Dictionary<string, string>
        {
            { "Agonizing Blast", "when you cast Eldritch Blast, dmg + Cha" },
            { "Armor of Shadows", "cast Mage Armor at-will" },
            { "Ascendant Step", "cast Levitate at-will" },
            { "Aspect of the Moon", "don't need to sleep, can't be forced to sleep" },
            { "Beast Speech", "cast Speak with Animals at-will" },
            { "Beguiling Influence", "gain prof in Deception and Persuasion" },
            { "Bewitching Whispers", "LR, cast Compulsion using a spell slot" },
            { "Bond of the Talisman", "PB/LR, wearer of your talisman can teleport to each other" },
            { "Book of Ancient Secrets", "gain 2 ritual spells, can copy rituals into the spellbook for 50gp/2hr" },
            { "Chains of Carceri", "LR, cast Hold Monster on a celestial, fiend, or elemental" },
            { "Cloak of Flies", "SR, bonus, 5ft aura, Cha Poison dmg, grants adv on Intimidation but disadv on other Cha-based checks" },
            { "Devil's Sight", "gain Superior Darkvision 120ft" },
            { "Dreadful Word", "LR, cast Confusion using a spell slot" },
            { "Eldritch Mind", "adv on Con saves for conc on spells" },
            { "Eldritch Sight", "cast Detect Magic at-will" },
            { "Eldritch Smite", "1/turn, on hit, expend a spell slot, extra dmg = 1D8 Force dmg + 1D8/spell lvl, knock prone if Huge or smaller" },
            { "Eldritch Spear", "range on Eldritch Blast becomes 300ft" },
            { "Eyes of the Rune Keeper", "read all writing" },
            { "Far Scribe", "gain a page that can contain names = PB, cast Sending to any name without using spell slot" },
            { "Fiendish Vigor", "cast False Life at-will" },
            { "Gaze of Two Minds", "action, become blind/deaf to use the senses of another humanoid you touch" },
            { "Ghostly Gaze", "SR, action, 30ft, 1 min conc, see through objects, gain Darkvision" },
            { "Gift of the Depths", "gain waterbreathing, Swim speed / LR, cast Waterbreathing" },
            { "Gift of the Ever-Living Ones", "When you regain HP, familiar within 100ft, max the dice rolled for you" },
            { "Gift of the Protectors", "gain a page that can contain names = PB, LR, when a name drop to 0 HP, drop to 1 instead" },
            { "Grasp of Hadar", "1/turn, on hit with Eldritch Blast, pull 10ft" },
            { "Improved Pact Weapon", "your Pact Weapon can be a spell focus, atk/dmg + 1, you can summon any bow except hand crossbow" },
            { "Investment of the Chain Master", "cast Find Familiar to infuse with benefits" +
                "\n        (gain Fly or Swim 40ft, command as bonus, atks are magical, uses your spell DC, use reaciton to grant it Resistance)" },
            { "Lance of Lethargy", "1/turn, on hit with Eldritch Blast, reduce enemy's speed by 10ft" },
            { "Lifedrinker", "dmg + Cha Necrotic" },
            { "Maddening Hex", "bonus, 30ft, cursed target, deal Cha Psychic dmg to target and adj" },
            { "Mask of Many Faces", "cast Disguise Self at-will" },
            { "Master of Myriad Forms", "cast Alter Self at-will" },
            { "Minions of Chaos", "LR, cast Conjure Elemental using a spell slot" },
            { "Mire the Mind", "LR, cast Slow using a spell slot" },
            { "Misty Visions", "cast Silent Image at-will" },
            { "One with Shadows", "action, in dim light/darkness, become invisible" },
            { "Otherworldly Leap", "cast Jump at-will" },
            { "Protector of the Talisman", "PB/LR, wearer of your talisman fails a save, save + 1D4" },
            { "Rebuke of the Talisman", "reaction, 30ft, wearer of your talisman is hit, Psychic dmg = PB, push 10ft" },
            { "Relentless Hex", "bonus, 30ft, teleport adj to a cursed target" },
            { "Repelling Blast", "Eldritch Blast can push 10ft" },
            { "Sculptor of Flesh", "LR, cast Polymorph using a spell slot" },
            { "Shroud of Shadow", "cast Invisibility at-will" },
            { "Sign of Ill Omen", "LR, cast Bestow Curse using a spell slot" },
            { "Thief of Five Fates", "LR, cast Bane using a spell slot" },
            { "Thirsting Blade", "When using an Attack action, atk twice" },
            { "Tomb of Levistus", "SR, reaction, when you take dmg, gain 10 temp HP/lvl - ends next turn / after dmg resolution," +
                "\n        suffer Vulnerability to fire, speed = 0ft, gain incap" },
            { "Trickster's Escape", "LR, cast Freedom of Movement" },
            { "Undying Servitude", "LR, cast Animate Dead" },
            { "Visions of Distant Realms", "cast Arcane Eye at-will" },
            { "Voice of the Chain Master", "can communicate telepathically with familiar, perceive their senses, and speak through them" },
            { "Whispers of the Grave", "cast Speak with Dead at-will" },
            { "Witch Sight", "30ft, can see through shapechangers or creature using illusion/transmutation magic" }
        };
        public static List<string> BaseInvocations { get; set; } = new List<string>
        {
            "Agonizing Blast",
            "Armor of Shadows",
            "Beast Speech",
            "Beguiling Influence",
            "Devil's Sight",
            "Eldritch Mind",
            "Eldritch Sight",
            "Eldritch Spear",
            "Eyes of the Rune Keeper",
            "Fiendish Vigor",
            "Gaze of Two Minds",
            "Grasp of Hadar",
            "Lance of Lethargy",
            "Mask of Many Faces",
            "Misty Visions",
            "Repelling Blast",
            "Thief of Five Fates"
        };
        public static List<string> LvlFiveInvoc { get; set; } = new List<string>
        {
            "Cloak of Flies",
            "Gift of the Depths",
            "Maddening Hex",
            "Mire the Mind",
            "One with Shadows",
            "Sign of Ill Omen",
            "Tomb of Levistus",
            "Undying Servitude"
        };
        public static List<string> LvlSevenInvoc { get; set; } = new List<string>
        {
            "Bewitching Whispers",
            "Dreadful Word",
            "Ghostly Gaze",
            "Relentless Hex",
            "Sculptor of Flesh",
            "Trickster's Escape"
        };
        public static List<string> LvlNineInvoc { get; set; } = new List<string>
        {
            "Ascendant Step",
            "Minions of Chaos",
            "Otherworldly Leap",
            "Whispers of the Grave"
        };
        public static List<string> LvlFifteenInvoc { get; set; } = new List<string>
        {
            "Master of Myriad Forms",
            "Shroud of Shadow",
            "Visions of Distant Realms",
            "Witch Sight"
        };
        public static Dictionary<string, string> Talents { get; set; } = new Dictionary<string, string>
        {
            { "Astute Intuition", "Insight checks vs Aristocrats, Criminals, and Common Folk" },
            { "Beast Whisperer", "Animal Handling checks to train or direct a beast" },
            { "Biologist", "Nature checks to determine the properties of animals" },
            { "Born In the Saddle", "Animal Handling checks to ride an animal or interact with your mount" },
            { "Botanist", "Nature checks to determine the properties of plants" },
            { "Bounty Hunter", "Survival checks to track Criminals" },
            { "Cabal Lorekeeper", "Religion checks to recall information about Celestials, Fiends, Fey, or Undead" },
            { "Calloused Hands", "Athletics checks to lift, drag, or shove a heavy object" },
            { "Confessor", "Persuasion checks to reveal a secret or ask a favor of anyone who follows the same deity as you" },
            { "Contortionist", "Acrobatics checks to squeeze through a small space or escape bonds" },
            { "Copycat", "Forgery Kit checks to forge or create a document" },
            { "Court Schemer", "Deception checks when conversing with Aristocrats" },
            { "Diligent Researcher", "Int checks to research a subject" },
            { "Disciplinarian", "Intimidation checks to issue a command to someone of lower rank within your background" },
            { "Drunkard", "Con checks to determine if you will throw up, pass out, or how severe a hangover is" },
            { "Elusive", "Stealth checks to hide or blend into a crowd that shares your background" },
            { "Figure of Authority", "Persuasion checks while interacting with Common Folk" },
            { "Flamboyant Presentation", "Performance checks to entertain Aristocrats, Common Folk, or Seafarers" },
            { "Forecaster", "Survival checks to determine the weather for the next 48 hours" },
            { "Gambler", "Sleight of Hand or Perception checks to cheat at a game or catch someone else cheating" },
            { "Grifter", "Deception checks while attempting to pass off a fake object as authentic" },
            { "Gut Feeling", "Insight checks vs Aristocrats and Criminals" },
            { "Hard-Working", "Con checks for a repetitive task such as marching or labouring for hours without rest" },
            { "Heister", "Perception checks to spot traps, sentries, and other security measures" },
            { "Idolist", "Religion checks to recall information on religious or cult-related symbols" },
            { "Impressionist", "Deception or Performance checks to mimic the mannerisms, voice, or appearance of someone" },
            { "Interrogator", "Intimidation checks to extract information from an enemy who is restrained" },
            { "Local Historian", "History checks to determine the history/location of an item from your region" },
            { "Menacing Presence", "Intimidation checks vs Academics, Common Folk, or Seafarers" },
            { "Mystical Scholar", "Arcana checks to recall information on Aberrations, Constructs, or Elementals" },
            { "Navigator", "All vechile checks" },
            { "Nimble Fingers", "Thieves' Tools checks to pick locks" },
            { "Passionate Orator", "Performance checks to influence an Academic, Military, or Clergy member" },
            { "Pathologist", "Medicine checks to treat a disease" },
            { "Problem Solver", "Investigation checks to decipher a coded message or puzzle" },
            { "Quick Fingers", "Sleight of Hand checks to slip something small into someone's pocket, food or beverage" },
            { "Recruiter", "Persuasion checks to recruit people to a role" },
            { "Renowned", "Persuasion checks vs Militarists, Outlanders, and Criminals" },
            { "Ropesman", "Athletics or Acrobatics checks to climb, move along, or jump onto ropes" },
            { "Runekeeper", "Arcana checks to uncover the properties and uses of magical runes, glyphs, or other symbols" },
            { "Sawbones", "Medicine checks dealing with Grevious Wounds" },
            { "Sea Dog", "Athletics checks to swim in water" },
            { "Sentry", "Perception checks while on watch duty or defending a fortification" },
            { "Shrewd Deduction", "Investigation checks to investigate a crime scene" },
            { "Translator", "Int checks to communicate with a creature who doesn’t share a language with you" },
            { "Urban Sprinter", "Athletics or Acrobatics checks while fleeing from a pursuer, or pursuing someone else" },
            { "Wayfarer", "Survival checks to find a path or avoid getting lost" }
        };
        public static Dictionary<string, string> Lvl1Features { get; set; } = new Dictionary<string, string>
        {
            { "Acolyte of Nature", "learn a Druid cantrip and a skill from: Animal Handling, Nature, Survival" },
            { "Acolyte of Strength", "learn a Druid cantrip and a skill from: Animal Handling, Nature, Survival" },
            { "Among the Dead", "learn Spare the Dying cantrip, adv on saves vs disease, undead must make Wis save to atk, on fail must choose new target" },
            { "Arcane Initiate", "gain prof in Arcana and learn 2 Wizard cantrips" },
            { "Arcane Recovery", "1/day after SR, gain spell slots <= 1/2 lvl, no lvl 6 slots or higher" },
            { "Awakened Mind", "30ft, commmunicate telepathically without common language" },
            { "Bardic Inspiration(D6)", "Cha/LR, bonus, 60ft, use on ally, add to atk, save, or ability check" },
            { "Blessing of the Trickster", "action, give ally adv on Stealth for 1 hr" },
            { "Blessings of Knowledge", "gain 2 languages and 2 skills" },
            { "Canny", "gain Expertise in 1 skill, gain 2 languages" },
            { "Circle of Mortality", "when you use heal spell on ally with 0 HP, heal max on spell / gain Spare the Dying cantrip" },
            { "Clockwork Magic", "add Alarm and Protection from Evil and Good to your spell list(if you have one)" },
            { "Dark One's Blessing", "on kill, gain temp HP = Cha + lvl" },
            { "Disciple of Life", "healing spells heal extra 2 + spell lvl HP" },
            { "Divine Magic", "gain access to the Cleric spell list, learn Bane, Bless, Cure Wounds, Inflict Wounds, or Protection from Evil and Good" },
            { "Divine Sense","action, 60ft, 1 + Cha/LR, know location and type of celestials, fiend, undead" },
            { "Draconic Resilience", "increase HP by 1 per lvl, AC = 13 + Dex" },
            { "Dragon Ancestor", "double PB on Cha checks when interacting with 1 color Dragons, learn Draconic" },
            { "Druidic","DC 15 to spot a message" },
            { "Emboldening Bond", "PB/LR, action, 10 min, 30ft, PB creatures, 1/turn, when 30ft from ally - atk, check, save + 1D4" },
            { "Expertise","pick 2 skills, or 1 skill and 1 tool prof, double PB" },
            { "Eyes of the Dark", "gain Superior Darkvision 120ft" },
            { "Eyes of the Grave", "Wis/LR, action, 60ft, not behind total cover, detect the location of undead" },
            { "Eyes of Night", "LR or spell slot, action, 1 hr, 10ft, Wis creatures, share Darkvision" +
                        "\n        gain Darkvision 300ft, dim light = bright light, darkness = dim light," },
            { "Favored by the Gods", "SR, if you fail a save or miss an atk, +2D4 to the save or atk" },
            { "Favored Enemy(1 type)", "adv on Survival checks, gain 1 lang" },
            { "Favored Foe", "PB/LR, on hit, mark 1 min conc, dmg + 1D4" },
            { "Fey Presence", "1/SR, action, 10ft, Wis save, charm creatures" },
            { "Fighting Style", "pick from: Archery, Blind Fighting, Defense, Dueling, Great Weapon Fighting, Interception, Protection, " +
                "Superior Technique, Thrown Weapon Fighting, Two-Weapon Fighting, Unarmed Fighting" },
            { "Genie's Vessel", "AC = spell DC, HP = lvl + PB, Immunity to Poison and Psychic" +
                "\n        Bottled Respite(LR, action, PB x 2 hr, enter/exit extradimensional space inside the vessel)" +
                $"\n        Genie's Wrath(1/turn, on hit, dmg + PB Bludgeoning, Cold, Fire, or Thunder - pick when you gain feature)" },
            { "Gift of the Sea", "gain waterbreathing and Swim 40ft" },
            { "Healing Light", "LR, gain D6 pool = 1 + lvl, bonus, 60ft, 1 creature, heal D6s - max dice spent at once = Cha" },
            { "Heart of Fire", "when you cast a fire dmg spell, 10ft, creatures of your choice, fire dmg = 1/2 lvl" },
            { "Hexblade's Curse", "bonus, 30ft, 1 min, dmg + Prof, crit on 19, on death - regain HP = lvl + Cha" },
            { "Lay on Hands", "touch, heal 5 HP" },
            { "Martial Arts", "Dex for atk/dmg, unarmed dmg = 1D4, bonus - melee atk" },
            { "Natural Explorer(1 terrain)", "no difficult terrain, move stealthily at normal pace, forage x 2, learn exact number/size of creatures" },
            { "Priest of Zeal", "Wis/LR, atk as bonus" },
            { "Psionic Spells", "add Mind Sliver, Arms of Hadar, and Dissonant Whispers to your spell list(if you have one)" },
            { "Rage(2/day)", $"bonus, 1 min, adv on Str checks/saves, Str melee dmg + 2, gain Resistance to B/P/S (end as bonus or if you don't atk or take dmg)" },
            { "Reaper", "gain a Necromancy cantrip, Necromancy cantrips that target 1 creature can target 2 if adj" },
            { "Restore Balance", "PB/LR, reaction, 60ft, when a creature rolls with adv or disadv - negate the adv or disadv" },
            { "Second Wind", "bonus, SR, heal 1D10+lvl HP"},
            { "Sneak Attack(1D6)", "1/turn, if you have adv or tar is flanked, must use finesse or ranged wep" },
            { "Solidarity's Action", "Wis/LR, bonus, when you take Help action, make a weapon atk" },
            { "Spellcasting(Bard)", "1st lvl spells only, use Cha for spell DCs, you use a musical instrument as a spell focus" },
            { "Spellcasting(Cleric)", "1st lvl spells only, use Wis for spell DCs, you use a Holy Symbol as a spell focus" },
            { "Spellcasting(Druid)", "1st lvl spells only, use Wis for spell DCs, you use a Druidic Focus as a spell focus" },
            { "Spellcasting(Sorcerer)", "1st lvl spells only, use Cha for spell DCs, you use an Arcane Focus as a spell focus" },
            { "Spellcasting(Warlock)", "1st lvl spells only, use Cha for spell DCs, you use an Arcane Focus as a spell focus" },
            { "Spellcasting(Wizard)", "1st lvl spells only, use Int for spell DCs, you use an Arcane Focus as a spell focus" },
            { "Strength of the Grave", "LR, if you drop to 0 HP, Cha save(DC 5 + dmg), drop to 1 HP - can't be used if dmg is Radiant or a crit" },
            { "Telepathic Speech", "bonus, lvl min, 30ft, 1 creature, speak telepathically from Cha miles" },
            { "Tempestous Magic", "bonus, after you cast non-cantrip, fly 10ft no atk op" },
            { "Tentacle of the Deeps", $"PB/LR, bonus, 1 min, 60ft, create 10ft tentacle - make melee spell atk, 1D8 Cold, reduce speed by 10ft" +
                        "\n        bonus, move tentacle 30ft and atk again" },
            { "Thieves' Cant", "secret thief language, speaking/writing takes 4x longer" },
            { "Unarmored Defense(Con)", "while wearing no armor, AC = 10 + Dex + Con" },
            { "Unarmored Defense(Wis)", "while wearing no armor, AC = 10 + Dex + Wis" },
            { "Vigilant Blessing", "action, touch, 1 creature, give adv on Init" },
            { "Voice of Authority", "when you cast a non-cantrip spell on an ally, 1 ally can use reaction to make a weapon atk" },
            { "War Priest", "Wis/LR, atk as bonus" },
            { "Warding Flare", "Wis/LR, reaction, 30ft, impose disadv, attacker can't be immune to blinding" },
            { "Wild Surge", "after casting a spell, roll D20 if its 1 - roll on Wild Magic table" }
        };
    }
}
