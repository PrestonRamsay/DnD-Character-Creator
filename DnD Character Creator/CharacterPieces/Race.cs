using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Races
{
    public class Race
    {        
        public Race()
        {
            MaxAgeEnd = 100;
            Size = "Medium";
        }
        public Tuple<string, int> Stat1 { get; set; }
        public Tuple<string, int> Stat2 { get; set; }
        public Tuple<string, int> Stat3 { get; set; } = new Tuple<string, int>("Null", 0);
        public List<string> RacialTraits { get; set; } = new List<string>();
        public int MinHeight { get; protected set; }
        public int MaxHeight { get; protected set; }
        public string Size { get; set; }
        public int MinWeight { get; protected set; }
        public int MaxWeight { get; protected set; }
        public int Speed { get; set; }
        public string Speedstring { get; set; }
        public string Vision { get; set; }
        public List<string> Alignment { get; set; } = new List<string>();
        public int AdultAge { get; set; }
        public int FullyGrownAge { get; set; }
        public int MaxAgeStart { get; set; }
        public int MaxAgeEnd { get; set; }
        public List<string> Languages { get; set; } = new List<string>();
        public List<string> SkillProficiencies { get; set; } = new List<string>();
        public List<string> ToolProficiencies { get; set; } = new List<string>();
        public List<string> Proficiencies { get; set; } = new List<string>();
        public List<string> Cantrips { get; set; } = new List<string>();
        public string DragonColor { get; set; }
        public string TieflingMagic { get; set; }
        public string Name { get; set; }
        public static Race NewRace(string raceString)
        {
            var result = new Race();

            switch (raceString)
            {
                case "Aasimar(Protector)":
                    result = ProtectorAasimar();
                    break;
                case "Aasimar(Scourge)":
                    result = ScourgeAasimar();
                    break;
                case "Aasimar(Fallen)":
                    result = FallenAasimar();
                    break;
                case "Cambion":
                    result = Cambion();
                    break;
                case "Changeling":
                    result = Changeling();
                    break;
                case "Dhampir":
                    result = Dhampir();
                    break;
                case "Dragonborn":
                    result = Dragonborn();
                    break;
                case "Hill Dwarf":
                    result = HillDwarf();
                    break;
                case "Mountain Dwarf":
                    result = MountainDwarf();
                    break;
                case "Avariel":
                    result = Avariel();
                    break;
                case "Drow":
                    result = Drow();
                    break;
                case "Eladrin":
                    result = Eladrin();
                    break;
                case "Moon Elf":
                    result = MoonElf();
                    break;
                case "Sea Elf":
                    result = SeaElf();
                    break;
                case "Shadar-Kai":
                    result = ShadarKai();
                    break;
                case "High Elf":
                    result = HighElf();
                    break;
                case "Wild Elf":
                    result = WildElf();
                    break;
                case "Wood Elf":
                    result = WoodElf();
                    break;
                case "Forest Gnome":
                    result = ForestGnome();
                    break;
                case "Rock Gnome":
                    result = RockGnome();
                    break;
                case "Goliath":
                    result = Goliath();
                    break;
                case "Half-Elf":
                    result = HalfElf();
                    break;
                case "Half-Orc":
                    result = HalfOrc();
                    break;
                case "Lightfoot Halfling":
                    result = LightfootHalfling();
                    break;
                case "Stout Halfling":
                    result = StoutHalfling();
                    break;
                case "Human":
                    result = Human();
                    break;
                case "Variant Human":
                    result = VariantHuman();
                    break;
                case "Minotaur":
                    result = Minotaur();
                    break;
                case "Shade":
                    result = Shade();
                    break;
                case "Tiefling":
                    result = Tiefling();
                    break;
                case "Feral Tiefling":
                    result = FeralTiefling();
                    break;
            }

            return result;
        }
        public static Race NewRace(Character character)
        {
            return Demigod(character);
        }
        public static Race GetStats(string raceString)
        {
            var result = new Race();
            int choice = -1;

            switch (raceString)
            {
                case "Aasimar(Protector)":
                    result.Stat1 = new Tuple<string, int>("Cha", 2);
                    result.Stat2 = new Tuple<string, int>("Wis", 1);
                    break;
                case "Aasimar(Scourge)":
                    result.Stat1 = new Tuple<string, int>("Cha", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "Aasimar(Fallen)":
                    result.Stat1 = new Tuple<string, int>("Cha", 2);
                    result.Stat2 = new Tuple<string, int>("Str", 1);
                    break;
                case "Cambion":
                    result.Stat1 = new Tuple<string, int>("Str", 1);
                    result.Stat2 = new Tuple<string, int>("Dex", 1);
                    result.Stat3 = new Tuple<string, int>("Cha", 1);
                    break;
                case "Changeling":
                    result.Stat1 = new Tuple<string, int>("Cha", 2);
                    Console.WriteLine("Pick a stat to increase by 1");
                    CLIHelper.Print2Choices("Dex", "Int");
                    choice = CLIHelper.GetNumberInRange(1, 2);
                    if (choice == 1)
                    {
                        result.Stat2 = new Tuple<string, int>("Dex", 1);
                    }
                    else if (choice == 2)
                    {
                        result.Stat2 = new Tuple<string, int>("Int", 1);
                    }
                    break;
                case "Dhampir":
                    result.Stat1 = new Tuple<string, int>("Str", 2);
                    Console.WriteLine("Pick a stat to increase by 1");
                    CLIHelper.Print2Choices("Dex", "Cha");
                    choice = CLIHelper.GetNumberInRange(1, 2);
                    if (choice == 1)
                    {
                        result.Stat2 = new Tuple<string, int>("Dex", 1);
                    }
                    else if (choice == 2)
                    {
                        result.Stat2 = new Tuple<string, int>("Cha", 1);
                    }
                    break;
                case "Dragonborn":
                    result.Stat1 = new Tuple<string, int>("Str", 2);
                    result.Stat2 = new Tuple<string, int>("Cha", 1);
                    break;
                case "Hill Dwarf":
                    result.Stat1 = new Tuple<string, int>("Con", 2);
                    result.Stat2 = new Tuple<string, int>("Wis", 1);
                    break;
                case "Mountain Dwarf":
                    result.Stat1 = new Tuple<string, int>("Str", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "Avariel":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Int", 1);
                    break;
                case "Drow":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Cha", 1);
                    break;
                case "Eladrin":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Cha", 1);
                    break;
                case "Moon Elf":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Int", 1);
                    break;
                case "Sea Elf":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "Shadar-Kai":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "High Elf":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Int", 1);
                    break;
                case "Wild Elf":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Str", 1);
                    break;
                case "Wood Elf":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Wis", 1);
                    break;
                case "Forest Gnome":
                    result.Stat1 = new Tuple<string, int>("Int", 2);
                    result.Stat2 = new Tuple<string, int>("Dex", 1);
                    break;
                case "Rock Gnome":
                    result.Stat1 = new Tuple<string, int>("Int", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "Goliath":
                    result.Stat1 = new Tuple<string, int>("Str", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "Half-Elf":
                    var statOptions = new List<string>();
                    statOptions.AddRange(Options.Stats);
                    statOptions.Remove("Cha");
                    string pickMsg = "Pick a stat to increase by 1.";
                    int index = CLIHelper.PrintChoices(pickMsg, statOptions);
                    string stat = statOptions[index];
                    result.Stat1 = new Tuple<string, int>(stat, 1);
                    statOptions.Remove(stat);
                    pickMsg = "Pick another stat to increase by 1 (Note you can't pick the same stat that you picked last time.)";
                    index = CLIHelper.PrintChoices(pickMsg, statOptions);
                    stat = statOptions[index];
                    result.Stat2 = new Tuple<string, int>(stat, 1);
                    result.Stat3 = new Tuple<string, int>("Cha", 2);
                    break;
                case "Half-Orc":
                    result.Stat1 = new Tuple<string, int>("Str", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "Lightfoot Halfling":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Cha", 1);
                    break;
                case "Stout Halfling":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "Human":
                    result.Name = "Human";
                    break;
                case "Variant Human":
                    statOptions = new List<string>();
                    statOptions.AddRange(Options.Stats);
                    pickMsg = "Pick a stat to increase by 1.";
                    index = CLIHelper.PrintChoices(pickMsg, statOptions);
                    stat = statOptions[index];
                    result.Stat1 = new Tuple<string, int>(stat, 1);
                    statOptions.Remove(stat);
                    pickMsg = "Pick another stat to increase by 1 (Note you can't pick the same stat that you picked last time.)";
                    index = CLIHelper.PrintChoices(pickMsg, statOptions);
                    stat = statOptions[index];
                    result.Stat2 = new Tuple<string, int>(stat, 1);
                    break;
                case "Minotaur":
                    result.Stat1 = new Tuple<string, int>("Str", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "Shade":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    Console.WriteLine("Pick a stat to increase by 1");
                    CLIHelper.Print2Choices("Int", "Cha");
                    choice = CLIHelper.GetNumberInRange(1, 2);
                    if (choice == 1)
                    {
                        result.Stat2 = new Tuple<string, int>("Int", 1);
                    }
                    else if (choice == 2)
                    {
                        result.Stat2 = new Tuple<string, int>("Cha", 1);
                    }
                    break;
                case "Tiefling":
                    result.Stat1 = new Tuple<string, int>("Cha", 2);
                    result.Stat2 = new Tuple<string, int>("Int", 1);
                    break;
                case "Feral Tiefling":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Int", 1);
                    break;
            }

            return result;
        }
        public static Race DemigodStats(string demigodDomain)
        {
            var result = new Race();
            result.Stat2 = new Tuple<string, int>("Con", 1);

            switch (demigodDomain)
            {
                case "Beauty":
                    result.Stat1 = new Tuple<string, int>("Cha", 2);
                    break;
                case "Knowledge":
                    result.Stat1 = new Tuple<string, int>("Int", 2);
                    break;
                case "Life":
                    result.Stat1 = new Tuple<string, int>("Wis", 2);
                    break;
                case "Luck":
                    result.Stat1 = new Tuple<string, int>("Cha", 2);
                    break;
                case "Madness":
                    result.Stat1 = new Tuple<string, int>("Wis", 1);
                    result.Stat3 = new Tuple<string, int>("Cha", 1);
                    break;
                case "Music":
                    result.Stat1 = new Tuple<string, int>("Cha", 2);
                    break;
                case "Protection":
                    result.Stat1 = new Tuple<string, int>("Con", 2);
                    result.Stat2 = new Tuple<string, int>("Str", 1);
                    break;
                case "Smithing":
                    result.Stat1 = new Tuple<string, int>("Str", 1);
                    result.Stat3 = new Tuple<string, int>("Int", 1);
                    break;
                case "The Earth":
                    result.Stat1 = new Tuple<string, int>("Wis", 2);
                    break;
                case "The Hunt":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    break;
                case "The Sea":
                    result.Stat1 = new Tuple<string, int>("Dex", 1);
                    break;
                case "The Sky":
                    result.Stat1 = new Tuple<string, int>("Str", 1);
                    result.Stat3 = new Tuple<string, int>("Cha", 1);
                    break;
                case "The Sun":
                    result.Stat1 = new Tuple<string, int>("Dex", 1);
                    result.Stat3 = new Tuple<string, int>("Cha", 1);
                    break;
                case "Travel":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    break;
                case "Trickery":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    break;
                case "Undead":
                    result.Stat1 = new Tuple<string, int>("Con", 2);
                    result.Stat2 = new Tuple<string, int>("Wis", 1);
                    break;
                case "War":
                    result.Stat1 = new Tuple<string, int>("Str", 2);
                    break;
            }

            return result;
        }
        public static Race ProtectorAasimar()
        {
            Race result = new Race();

            result.RacialTraits.Add("Celestial Radiance: Resistance to Necrotic & Radiant dmg");
            result.RacialTraits.Add("Healing Hands: LR, action, heal HP = lvl");
            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 300;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("N-G");
            result.MaxAgeStart = 160;
            result.Languages.Add("Celestial");
            result.Cantrips.Add("Light - Cha to cast");

            return result;
        }
        public static Race ScourgeAasimar()
        {
            Race result = new Race();

            result.RacialTraits.Add("Celestial Radiance: Resistance to Necrotic & Radiant dmg");
            result.RacialTraits.Add("Healing Hands: LR, action, heal HP = lvl");
            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 300;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("N-G");
            result.AdultAge = 18;
            result.MaxAgeStart = 160;
            result.Languages.Add("Celestial");
            result.Cantrips.Add("Light - Cha to cast");

            return result;
        }
        public static Race FallenAasimar()
        {
            Race result = new Race();

            result.RacialTraits.Add("Celestial Radiance: Resistance to Necrotic & Radiant dmg");
            result.RacialTraits.Add("Healing Hands: LR, action, heal HP = lvl");
            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 300;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("TN");
            result.Alignment.Add("N-E");
            result.AdultAge = 18;
            result.MaxAgeStart = 160;
            result.Languages.Add("Celestial");
            result.Cantrips.Add("Light - Cha to cast");

            return result;
        }
        public static Race Cambion()
        {
            Race result = new Race();

            result.RacialTraits.Add("Fiendish Form: your type becomes Fiend");
            result.MinHeight = 65;
            result.MaxHeight = 77;
            result.MinWeight = 100;
            result.MaxWeight = 200;
            result.Speed = 30;
            result.Speedstring = ", Fly 30ft";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-E");
            result.Alignment.Add("C-E");
            result.AdultAge = 18;
            result.MaxAgeStart = 160;
            result.SkillProficiencies.Add("Deception");
            result.SkillProficiencies.Add("Persuasion");
            result.Cantrips.Add("Firebolt - Cha to cast");

            return result;
        }
        public static Race Changeling()
        {
            Race result = new Race();

            result.RacialTraits.Add("Change Appearance: action, doesn't change clothes - adv on Deception for disguise");
            result.RacialTraits.Add("Unsettling Visage: when attacked, SR, reaction, 30ft, impose disadv on atk");
            result.RacialTraits.Add("Divergent Persona: prof with 1 tool, while in your persona - PB x2 with that tool");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 100;
            result.MaxWeight = 160;
            result.Speed = 30;
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("N-G");
            result.Alignment.Add("TN");
            result.Alignment.Add("C-N");
            result.AdultAge = 15;
            result.MaxAgeStart = 100;
            result.Languages.Add("Choice");
            result.Languages.Add("Choice2");
            var skills = new List<string> { "Deception", "Insight", "Intimidation", "Persuasion" };
            Console.WriteLine("Changelings get 2 skill proficiencies of their choice, pick them now");
            string skill = CLIHelper.PrintChoices(skills);
            result.SkillProficiencies.Add(skill);
            skills.Remove(skill);
            skill = CLIHelper.PrintChoices(skills);
            result.SkillProficiencies.Add(skill);
            string pickMsg = "Pick a tool proficiency";
            int index = CLIHelper.PrintChoices(pickMsg, Options.Tools);
            result.ToolProficiencies.Add(Options.Tools[index]);

            return result;
        }
        public static Race Demigod(Character character)
        {
            Race result = new Race();

            result.RacialTraits.Add("Powerful Build: count as Large for carry capacity, etc");
            result.RacialTraits.Add("Godly Strength: adv on Str checks");
            result.RacialTraits.Add("Godly Protection: +2 AC");
            result.RacialTraits.Add("Divine Intervention: LR, gain adv on atk, save, or ability check");
            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 300;
            result.Speed = 40;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("N-G");
            result.Alignment.Add("C-G");
            result.Alignment.Add("C-N");
            result.AdultAge = 30;
            result.MaxAgeStart = 800;
            result.MaxAgeEnd = 1200;
            result.Languages.Add("Celestial");
            result.Languages.Add("Choice");

            int index = -1;
            switch (character.DemigodDomain)
            {
                case "Beauty":
                    result.RacialTraits.Add("Child of Love: impose disadv vs Enchantment spells");
                    result.RacialTraits.Add("Compelling Beauty: bonus, Cha save, disadv on atks, if attempt to move away from you Cha save");
                    result.Cantrips.Add("Friends - Cha to cast");
                    result.SkillProficiencies.Add("Deception");
                    result.SkillProficiencies.Add("Persuasion");
                    break;
                case "Knowledge":
                    result.RacialTraits.Add("Child of Wisdom: gain 1 skill, 1 tool, and Expertise in 1 skill");
                    result.RacialTraits.Add("Wit Without Measure: adv on all Int-based DCs");
                    result.Cantrips.Add("Guidance - Int to cast");
                    index = CLIHelper.PrintChoices("Pick a skill", Options.Skills);
                    result.SkillProficiencies.Add(Options.Skills[index]);
                    index = CLIHelper.PrintChoices("Pick a tool proficiency", Options.Tools);
                    result.ToolProficiencies.Add(Options.Tools[index]);
                    break;
                case "Life":
                    result.RacialTraits.Add("Child of Life: healing spells heal extra HP = Wis");
                    result.RacialTraits.Add("Refute Death: LR, 30ft, you or ally auto-succeeds on 1 death save");
                    result.Cantrips.Add("Spare the Dying - Wis to cast");
                    break;
                case "Luck":
                    result.RacialTraits.Add("Child of Luck: Cha/LR, add 1D6 to any atk, save, or ability check");
                    result.RacialTraits.Add("Auspicious Dodge: LR, reaction, when hit - cause atk to miss");
                    result.RacialTraits.Add("Favored Attack: LR, on hit, cause atk to crit");
                    result.RacialTraits.Add("Prosperous Life: whenever you find treasure or try to sell goods, increase its value by 30%");
                    break;
                case "Madness":
                    result.RacialTraits.Add("Child of Madness: auto-succeed on all Con checks for drinking, gain Immunity to charm, fear, and poison");
                    result.RacialTraits.Add("Party Starter: Cha check in social area, gain adv on all Cha-based DCs for 2hr");
                    result.SkillProficiencies.Add("Acrobatics");
                    result.SkillProficiencies.Add("Persuasion");
                    result.Cantrips.Add("Create Bonfire - Cha to cast");
                    result.Cantrips.Add("Dancing Lights - Cha to cast");
                    break;
                case "Music":
                    result.RacialTraits.Add("Child of Music: creatures with Int 8 or less are charmed by music");
                    result.RacialTraits.Add("Devastating Notes: SR, Cha save, 30ft, all hostiles, 1 min, disadv on atks and saves");
                    result.SkillProficiencies.Add("Performance");
                    result.ToolProficiencies.Add("All instruments");
                    result.Cantrips.Add("Vicious Mockery - Cha to cast");
                    break;
                case "Protection":
                    result.RacialTraits.Add("Child of Protection: Dodge as a bonus, +2 HP/lvl");
                    result.RacialTraits.Add("Experienced Knight: gain the Protection fighting style");
                    result.SkillProficiencies.Add("Athletics");
                    result.Proficiencies.Add("All armor and shields");
                    result.Cantrips.Add("Blade Ward - Cha to cast");
                    break;
                case "Smithing":
                    result.RacialTraits.Add("Child of Creation: LR, create an object of any combination of wood, stone, iron, crystal, rope, or cloth" +
                        "The object must smaller than a 5ft cube, and the object must be in a form that you have seen before");
                    result.RacialTraits.Add("Child of the Forge: gain Immunity to Fire, adv on all tool checks you're prof in");
                    result.ToolProficiencies.Add("Carpenter's Tools");
                    result.ToolProficiencies.Add("Cobbler's Tools");
                    result.ToolProficiencies.Add("Mason's Tools");
                    result.ToolProficiencies.Add("Smith's Tools");
                    result.ToolProficiencies.Add("Tinker's Tools");
                    result.Cantrips.Add("Sword Burst - Wis to cast");
                    break;
                case "The Earth":
                    result.RacialTraits.Add("Child of Nature: 30ft, create difficult terrain made of foliage, Str save or be restrained");
                    result.RacialTraits.Add("Earth Control: LR, cast Stoneshape or Wall of Stone");
                    result.SkillProficiencies.Add("Nature");
                    result.Cantrips.Add("Druidcraft - Wis to cast");
                    break;
                case "The Hunt":
                    result.RacialTraits.Add("Child of the Hunt: adv on Survival, identify creatures from tracks");
                    result.RacialTraits.Add("Hunter's Eyes: gain Superior Darkvision 120ft, 1/SR - cast Detect Poison and Disease");
                    character.Vision = "Superior Darkvision 120ft";
                    result.RacialTraits.Add("Godly Precision: +2 to atk/dmg with ranged wep");
                    result.SkillProficiencies.Add("Survival");
                    result.Proficiencies.Add("All ranged weapons");
                    result.Cantrips.Add("Thorn Whip - Wis to cast");
                    break;
                case "The Sea":
                    result.RacialTraits.Add("Child of the Sea: waterbreathing, swim 40ft");
                    result.RacialTraits.Add("Caress of the Ocean: gain regen = 1/4 lvl while in water");
                    result.Cantrips.Add("Shape Water - Int to cast");
                    break;
                case "The Sky":
                    result.RacialTraits.Add("Child of the Sky: gain Resistance Thunder and Lightning");
                    result.RacialTraits.Add("Lightning Wielder: +2 to atk/dmg while unarmed, 1/LR - Cha spell atk, range 30/120, 4D8 + Cha Lightning dmg");
                    result.Cantrips.Add("Gust - Cha to cast");
                    break;
                case "The Sun":
                    result.RacialTraits.Add("Child of the Sun: during the day, gain +2 Str, Dex, Con/at night, gain -2 Str, Dex, Con");
                    result.RacialTraits.Add("Solar Burst: LR, Con save - 30ft, 5D8 Radiant dmg, Con save - blindness");
                    result.Cantrips.Add("Light - Cha to cast");
                    break;
                case "Travel":
                    result.RacialTraits.Add("Child of Travel: move speed +10ft");
                    result.Speed = 50;
                    result.RacialTraits.Add("Fast Travel: LR, cast Teleport");
                    result.Cantrips.Add("Message - Wis to cast");
                    break;
                case "Trickery":
                    result.RacialTraits.Add("Child of Shadows: adv with Stealth and Thieves' Tools");
                    result.SkillProficiencies.Add("Deception");
                    result.SkillProficiencies.Add("Sleight of Hand");
                    result.SkillProficiencies.Add("Stealth");
                    result.ToolProficiencies.Add("Thieves' Tools");
                    result.Cantrips.Add("Minor Illusion - Int to cast");
                    break;
                case "Undead":
                    result.RacialTraits.Add("Child of Death: gain Resistance to Necrotic, Superior Darkvision 120ft");
                    result.Vision = "Superior Darkvision 120ft";
                    result.RacialTraits.Add("Undead Affinity: SR, action, conjure 3 skeletons or zombies");
                    result.Cantrips.Add("Toll the Dead - Int or Wis to cast");
                    break;
                case "War":
                    result.RacialTraits.Add("Child of War: can't be surprised, +5 on Init, use Str for Intimiation");
                    result.RacialTraits.Add("Aura of War: LR, 30ft, Con save, fear and prone, you and allies gain Str temp HP");
                    result.RacialTraits.Add("Godly Precision: +2 atk/dmg with melee");
                    result.Proficiencies.Add("All weapons and armor");
                    break;
            }

            return result;
        }
        public static Race Dhampir()
        {
            Race result = new Race();

            result.RacialTraits.Add("Bite - 1D6 Piercing");
            result.RacialTraits.Add("Blood Drain: after bite, bonus, grapple check - 1/D12 + Cha Necrotic dmg, heal HP = dmg");
            result.RacialTraits.Add("Regeneration: 1/turn, heal HP = 1/4 lvl, negated by sunlight, radiant or holy water dmg");
            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 250;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("N-E");
            result.Alignment.Add("C-G");
            result.AdultAge = 18;
            result.MaxAgeStart = 750;
            result.Languages.Add("Choice");

            return result;
        }
        public static Race Dragonborn()
        {           
            Race result = new Race();
            string msg = "Pick a dragon color for your ancestry";
            List<string> colorList = new List<string> { "Black", "Blue", "Brass", "Bronze", "Copper", "Gold", "Green",
                "Red", "Silver", "White" };
            int index = CLIHelper.PrintChoices(msg, colorList);
            string color = colorList[index];
            result.DragonColor = color;
            string dmgType = "";
            string shape = "";

            if (color == "Black" || color == "Copper")
            {
                dmgType = "Acid";
                shape = "5 by 30ft line";
            }
            else if (color == "Blue" || color == "Bronze")
            {
                dmgType = "Lightning";
                shape = "5 by 30ft line";
            }
            else if (color == "Brass")
            {
                dmgType = "Fire";
                shape = "5 by 30ft line";
            }
            else if (color == "Gold" || color == "Red")
            {
                dmgType = "Fire";
                shape = "15ft cone";
            }
            else if (color == "Green")
            {
                dmgType = "Poison";
                shape = "15ft cone";
            }
            else if (color == "Silver" || color == "White")
            {
                dmgType = "Cold";
                shape = "15ft cone";
            }

            result.RacialTraits.Add($"Damage Resistance: gain Resistance to {dmgType}");
            result.RacialTraits.Add($"Breath Weapon: 3D8 + (1D8 per 5 lvls above 1st) dmg, {shape} of {dmgType} - Dex save" +
                $"\n        recharge SR, Con-based DC");
            result.RacialTraits.Add("Bite - 1D6 Piercing");
            result.MinHeight = 75;
            result.MaxHeight = 81;
            result.MinWeight = 200;
            result.MaxWeight = 350;
            result.Speed = 30;
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("N-G");
            result.Alignment.Add("TN");
            result.Alignment.Add("N-E");
            result.FullyGrownAge = 3;
            result.AdultAge = 15;
            result.MaxAgeStart = 80;
            result.Languages.Add("Draconic");

            return result;
        }
        public static Race HillDwarf()
        {
            Race result = new Race();
            string msg = "Pick a Tool Proficiency from: Brewer's Supplies, Mason's Tools, or Smith's Tools";
            List<string> toolsList = new List<string> { "Brewer", "Mason", "Smith" };
            int index = CLIHelper.PrintChoices(msg, toolsList);
            string toolProficiency = toolsList[index];
            if (toolProficiency == "Brewer")
            {
                result.ToolProficiencies.Add("Brewer's Supplies");
            }
            else if (toolProficiency == "Mason")
            {
                result.ToolProficiencies.Add("Mason's Tools");
            }
            else
            {
                result.ToolProficiencies.Add("Smith's Tools");
            }

            result.RacialTraits.Add("Dwarven Resilience: gain Resistance to Poison, and advantage on saves vs Poison");
            result.RacialTraits.Add("Stonecunning: History checks on stonework are treated as if you are proficient and " +
                "\n        gain add your Proficiency bonus x2");
            result.RacialTraits.Add("Dwarven Toughness");
            result.MinHeight = 48;
            result.MaxHeight = 60;
            result.MinWeight = 100;
            result.MaxWeight = 200;
            result.Speed = 25;
            result.Speedstring = ", no speed penalty when wearing heavy armor";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("L-N");
            result.AdultAge = 50;
            result.MaxAgeStart = 350;
            result.Languages.Add("Dwarven");
            result.Proficiencies.Add("Battleaxes");
            result.Proficiencies.Add("Handaxes");
            result.Proficiencies.Add("Throwing Hammers");
            result.Proficiencies.Add("Warhammers");

            return result;
        }
        public static Race MountainDwarf()
        {
            Race result = new Race();
            string msg = "Pick a Tool Proficiency from: Brewer's Supplies, Mason's Tools, or Smith's Tools";
            List<string> toolsList = new List<string> { "Brewer", "Mason", "Smith" };
            int index = CLIHelper.PrintChoices(msg, toolsList);
            string toolProficiency = toolsList[index];
            if (toolProficiency == "Brewer")
            {
                result.ToolProficiencies.Add("Brewer's Supplies");
            }
            else if (toolProficiency == "Mason")
            {
                result.ToolProficiencies.Add("Mason's Tools");
            }
            else
            {
                result.ToolProficiencies.Add("Smith's Tools");
            }

            result.RacialTraits.Add("Dwarven Resilience: gain Resistance to Poison, and Advantage on saves vs Poison");
            result.RacialTraits.Add("Stonecunning: History checks on stonework are treated as if you are proficient and " +
                "\n        gain add your Proficiency bonus x2");
            result.MinHeight = 48;
            result.MaxHeight = 60;
            result.MinWeight = 100;
            result.MaxWeight = 200;
            result.Speed = 25;
            result.Speedstring = ", no speed penalty when wearing heavy armor";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("L-N");
            result.AdultAge = 50;
            result.MaxAgeStart = 350;
            result.Languages.Add("Dwarven");
            result.Proficiencies.Add("Light Armor");
            result.Proficiencies.Add("Medium Armor");
            result.Proficiencies.Add("Battleaxes");
            result.Proficiencies.Add("Handaxes");
            result.Proficiencies.Add("Throwing Hammers");
            result.Proficiencies.Add("Warhammers");

            return result;
        }
        public static Race Avariel()
        {
            Race result = new Race();

            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\n        After resting in such a way, you gain the benefits of a long rest");
            result.RacialTraits.Add("Aerial Reach: melee reach +5ft");
            result.MinHeight = 60;
            result.MaxHeight = 76;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = 30;
            result.Speedstring = ", Fly 40ft";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("N-G");
            result.Alignment.Add("C-G");
            result.Alignment.Add("C-N");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.Languages.Add("Auran");
            result.SkillProficiencies.Add("Perception");
            result.Proficiencies.Add("Spear");
            result.Proficiencies.Add("Shortbows");
            result.Proficiencies.Add("Net");
            result.Proficiencies.Add("Longbows");

            return result;
        }
        public static Race Drow()
        {
            Race result = new Race();

            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            result.RacialTraits.Add("Sunlight Sensitivity: suffer disadv on atks and sight Perception checks when you or target is in sunlight");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = 30;
            result.Vision = "Superior Darkvision 120ft";
            result.Alignment.Add("C-N");
            result.Alignment.Add("N-E");
            result.Alignment.Add("C-E");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.Languages.Add("Undercommon");
            result.SkillProficiencies.Add("Perception");
            result.Proficiencies.Add("Shortswords");
            result.Proficiencies.Add("Rapiers");
            result.Proficiencies.Add("Hand Crossbows");
            result.Cantrips.Add("Dancing Lights - Cha to cast");

            return result;
        }
        public static Race Eladrin()
        {
            Race result = new Race();

            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            result.RacialTraits.Add("Fey Step: SR, bonus, teleport 30ft & seasonal effect(Cha-based DC)" +
                "\n        Autumn - 2 creatures within 10ft, Wis save, charm 1 turn" +
                "\n        Spring - teleport adj creature within 30ft instead of yourself" +
                "\n        Summer - creatures you can see within 5ft take Cha Fire dmg" +
                "\n        Winter - 1 creature within 5ft, Wis save, fear 1 turn");
            result.MinHeight = 60;
            result.MaxHeight = 76;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-G");
            result.Alignment.Add("C-N");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.SkillProficiencies.Add("Perception");

            return result;
        }
        public static Race MoonElf()
        {
            Race result = new Race();

            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-G");
            result.Alignment.Add("C-N");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.Languages.Add("Choice");
            result.SkillProficiencies.Add("Perception");
            var skills = new List<string> { "Deception", "Investigation", "Persuasion", "Stealth" };
            CLIHelper.GetSkills(result, skills, 2);
            result.Proficiencies.Add("Shortswords");
            result.Proficiencies.Add("Shortbows");
            result.Proficiencies.Add("Longswords");
            result.Proficiencies.Add("Longbows");
            int index = CLIHelper.PrintChoices("Pick a cantrip from the Wizard's spell list.", WizardSpells.Cantrips);
            string cantrip = WizardSpells.Cantrips[index];
            result.Cantrips.Add($"{cantrip} - Int to cast");

            return result;
        }
        public static Race SeaElf()
        {
            Race result = new Race();

            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            result.RacialTraits.Add("Waterbreathing");
            result.RacialTraits.Add("Friend of the Sea: communicate basic ideas with water creatures");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = 30;
            result.Speedstring = ", Swim 30ft";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("N-G");
            result.Alignment.Add("C-G");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.Languages.Add("Aquan");
            result.SkillProficiencies.Add("Perception");
            result.Proficiencies.Add("Spear");
            result.Proficiencies.Add("Trident");
            result.Proficiencies.Add("Light Crossbow");
            result.Proficiencies.Add("Net");

            return result;
        }
        public static Race ShadarKai()
        {
            Race result = new Race();

            result.Stat1 = new Tuple<string, int>("Dex", 2);
            result.Stat2 = new Tuple<string, int>("Con", 1);
            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            result.RacialTraits.Add("Blessing of the Raven Queen: bonus, LR, teleport 30ft");
            result.RacialTraits.Add("Servant of Shadow: Resistance to Necrotic");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("N-G");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.SkillProficiencies.Add("Perception");

            return result;
        }
        public static Race HighElf()
        {
            Race result = new Race();

            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("N-G");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.Languages.Add("Choice");
            result.SkillProficiencies.Add("Perception");
            result.Proficiencies.Add("Shortswords");
            result.Proficiencies.Add("Shortbows");
            result.Proficiencies.Add("Longswords");
            result.Proficiencies.Add("Longbows");
            int index = CLIHelper.PrintChoices("Pick a cantrip from the Wizard's spell list.", WizardSpells.Cantrips);
            string cantrip = WizardSpells.Cantrips[index];
            result.Cantrips.Add($"{cantrip} - Int to cast");

            return result;
        }
        public static Race WildElf()
        {
            Race result = new Race();

            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("N-G");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.Languages.Add("Choice");
            result.SkillProficiencies.Add("Perception");
            result.Proficiencies.Add("Spear");
            result.Proficiencies.Add("Shortbows");
            result.Proficiencies.Add("Net");
            result.Proficiencies.Add("Longbows");
            int index = CLIHelper.PrintChoices("Pick a cantrip from the Druid's spell list.", DruidSpells.Cantrips);
            string cantrip = DruidSpells.Cantrips[index];
            result.Cantrips.Add($"{cantrip} - Wis to cast");

            return result;
        }
        public static Race WoodElf()
        {
            Race result = new Race();

            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            result.RacialTraits.Add("Mask of the Wild: you can attempt to hide even when you are only lightly obscured " +
                "\n        by foliage, heavy rain, falling snow, mist, and other natural phenomena.");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = 35;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-G");
            result.Alignment.Add("C-N");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.SkillProficiencies.Add("Perception");
            result.SkillProficiencies.Add("Stealth");
            result.Proficiencies.Add("Shortswords");
            result.Proficiencies.Add("Shortbows");
            result.Proficiencies.Add("Longswords");
            result.Proficiencies.Add("Longbows");

            return result;
        }
        public static Race ForestGnome()
        {
            Race result = new Race();

            result.RacialTraits.Add("Gnome Cunning: you gain Advantage on Int, Wis, and Cha saves vs magic");
            result.RacialTraits.Add("Speak with Small Beasts: Through sounds and gestures, you can communicate with " +
                "\n        simple ideas to small or smaller beasts");            
            result.MinHeight = 36;
            result.MaxHeight = 48;
            result.Size = "Small";
            result.MinWeight = 30;
            result.MaxWeight = 50;
            result.Speed = 25;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("N-G");
            result.Alignment.Add("C-G");
            result.AdultAge = 40;
            result.MaxAgeStart = 350;
            result.MaxAgeEnd = 500;
            result.Languages.Add("Gnomish");
            result.Cantrips.Add("Minor Illusion - Int to cast");

            return result;
        }
        public static Race RockGnome()
        {
            Race result = new Race();

            result.RacialTraits.Add("Gnome Cunning: you gain Advantage on Int, Wis, and Cha saves vs magic");
            result.RacialTraits.Add("Artificer's Lore: History checks on items or devices that are based on magic, " +
                "\n        technology, or alchemy are treated as if you are proficient and add your Proficiency bonus x2");
            result.RacialTraits.Add("Tinker: you can spend 1hr and 10gp to create a tiny clockwork device that has 1HP and " +
                "\n        an AC of 5. The device ceases to function after 24hr unless you spend 1hr to repair it. You can also use " +
                "\n        your action to dismantle the device and reclaim it's materials. You can make: a fire starter(creates " +
                "\n        miniature flame), a music box(single song at a moderate volume), or a clockwork toy(moves 5ft in a random " +
                "\n        direction and makes noise approriate to the creature it represents).");
            result.MinHeight = 36;
            result.MaxHeight = 48;
            result.Size = "Small";
            result.MinWeight = 30;
            result.MaxWeight = 50;
            result.Speed = 25;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("N-G");
            result.AdultAge = 40;
            result.MaxAgeStart = 350;
            result.MaxAgeEnd = 500;
            result.Languages.Add("Gnomish");

            return result;
        }
        public static Race Goliath()
        {
            Race result = new Race();

            result.RacialTraits.Add("Mountain Born: can endure cold climates above 20,000ft");
            result.RacialTraits.Add("Stone's Endurance: SR, reaction, reduce dmg by 1D12 + Con");
            result.RacialTraits.Add("Powerful Build: count as Large for carry capacity, etc");
            result.MinHeight = 84;
            result.MaxHeight = 96;
            result.MinWeight = 280;
            result.MaxWeight = 340;
            result.Speed = 30;
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("L-N");
            result.AdultAge = 18;
            result.MaxAgeStart = 80;
            result.Languages.Add("Giant");
            result.SkillProficiencies.Add("Athletics");

            return result;
        }
        public static Race HalfElf()
        {
            Race result = new Race();

            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Dilettante: pick a 1st lvl class feature from any class");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 100;
            result.MaxWeight = 250;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-N");
            result.AdultAge = 20;
            result.MaxAgeStart = 180;
            result.Languages.Add("Elven");
            result.Languages.Add("Choice");

            Console.WriteLine("Half-Elves are very versatile. You get you pick two extra skill proficiencies.");
            var skillList = new List<string>();
            skillList.AddRange(Options.Skills);
            string msg = "Pick your first skill here.";
            int index = CLIHelper.PrintChoices(msg, skillList);
            string skill = skillList[index];
            result.SkillProficiencies.Add(skill);
            skillList.Remove(skill);

            msg = "Enter your second skill here.";
            index = CLIHelper.PrintChoices(msg, skillList);
            skill = skillList[index];
            result.SkillProficiencies.Add(skill);

            return result;
        }
        public static Race HalfOrc()
        {
            Race result = new Race();

            result.RacialTraits.Add("Savage Attacks: when you crit on an attack roll, add 1 die to your damage roll");
            result.RacialTraits.Add("Relentless Endurance: 1/long rest, when you drop to 0HP, drop to 1HP instead");
            result.MinHeight = 72;
            result.MaxHeight = 84;
            result.MinWeight = 180;
            result.MaxWeight = 250;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-N");
            result.Alignment.Add("C-E");
            result.AdultAge = 14;
            result.MaxAgeStart = 75;
            result.Languages.Add("Orc");
            result.SkillProficiencies.Add("Intimidate");

            return result;
        }
        public static Race LightfootHalfling()
        {
            Race result = new Race();

            result.Stat1 = new Tuple<string, int>("Dex", 2);
            result.Stat2 = new Tuple<string, int>("Cha", 1);
            result.RacialTraits.Add("Lucky: when you roll a 1 you can reroll it once");
            result.RacialTraits.Add("Brave: you have Advantage on saves vs fear effects");
            result.RacialTraits.Add("Halfling Nimbleness: you can move through squares occupied by creatures who are larger than you");
            result.RacialTraits.Add("Naturally Stealthy: you can attempt to hide when you are obscured by a creature larger than you");
            result.MinHeight = 34;
            result.MaxHeight = 38;
            result.Size = "Small";
            result.MinWeight = 35;
            result.MaxWeight = 45;
            result.Speed = 25;
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("L-G");
            result.AdultAge = 20;
            result.MaxAgeStart = 200;
            result.Languages.Add("Halfling");

            return result;
        }
        public static Race StoutHalfling()
        {
            Race result = new Race();

            result.RacialTraits.Add("Lucky: when you roll a 1 you can reroll it once");
            result.RacialTraits.Add("Brave: you have Advantage on saves vs fear effects");
            result.RacialTraits.Add("Halfling Nimbleness: you can move through squares occupied by creatures who are larger than you");
            result.RacialTraits.Add("Stout Resilience: gain Resistance to Poison, and Advantage on saves vs Poison");
            result.MinHeight = 34;
            result.MaxHeight = 38;
            result.Size = "Small";
            result.MinWeight = 35;
            result.MaxWeight = 45;
            result.Speed = 25;
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("L-G");
            result.AdultAge = 20;
            result.MaxAgeStart = 200;
            result.Languages.Add("Halfling");

            return result;
        }
        public static Race VariantHuman()
        {
            Race result = new Race();

            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 300;
            result.Speed = 30;
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("L-N");
            result.Alignment.Add("L-E");
            result.Alignment.Add("C-G");
            result.Alignment.Add("C-N");
            result.Alignment.Add("C-E");
            result.Alignment.Add("N-G");
            result.Alignment.Add("TN");
            result.Alignment.Add("N-E");
            result.AdultAge = 18;
            result.MaxAgeStart = 80;
            result.Languages.Add("Choice");
            string msg = "You get to pick an extra skill proficiency. Enter the skill you'd like here.";
            int index = CLIHelper.PrintChoices(msg, Options.Skills);
            string pickedSkill = Options.Skills[index];
            result.SkillProficiencies.Add(pickedSkill);

            return result;
        }
        public static Race Human()
        {
            Race result = new Race();

            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 300;
            result.Speed = 30;
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("L-N");
            result.Alignment.Add("L-E");
            result.Alignment.Add("C-G");
            result.Alignment.Add("C-N");
            result.Alignment.Add("C-E");
            result.Alignment.Add("N-G");
            result.Alignment.Add("TN");
            result.Alignment.Add("N-E");
            result.AdultAge = 18;
            result.MaxAgeStart = 80;
            result.Languages.Add("Choice");

            return result;
        }
        public static Race Minotaur()
        {
            Race result = new Race();

            result.RacialTraits.Add("Horns - 1D6 Piercing");
            result.RacialTraits.Add("Goring Rush: after Dash that moves 20ft, melee bonus with Horns");
            result.RacialTraits.Add("Hammering Horns: on hit, bonus, Str DC - push 10ft");
            result.MinHeight = 72;
            result.MaxHeight = 84;
            result.MinWeight = 200;
            result.MaxWeight = 350;
            result.Speed = 30;
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("L-N");
            result.Alignment.Add("C-N");
            result.AdultAge = 18;
            result.MaxAgeStart = 80;
            result.SkillProficiencies.Add("Intimidation");
            result.SkillProficiencies.Add("Persuasion");

            return result;
        }
        public static Race Shade()
        {
            Race result = new Race();

            result.RacialTraits.Add("Shadow Step: bonus, SR, teleport 30ft");
            result.RacialTraits.Add("Child of Shadow: Resistance to Necrotic");
            result.RacialTraits.Add("Coalescing Darkness: adv on Stealth while in darkness");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 100;
            result.MaxWeight = 200;
            result.Speed = 30;
            result.Vision = "Superior Darkvision 120ft";
            result.Alignment.Add("N-E");
            result.AdultAge = 18;
            result.MaxAgeStart = 600;
            result.MaxAgeEnd = 1200;
            result.Languages.Add("Choice");
            result.SkillProficiencies.Add("Stealth");

            return result;
        }
        public static Race Tiefling()
        {
            Race result = new Race();
            int input = 0;
            Console.WriteLine("Would you like wings or magic? Pick a number.");
            CLIHelper.Print2Choices("Wings", "Magic");
            int answer = CLIHelper.GetNumberInRange(1, 2);
            if (answer == 2)
            {
                Console.WriteLine("Which kind of magic would you like? Pick a number.");
                CLIHelper.Print2Choices("Infernal Legacy", "Devil's Tongue");
                input = CLIHelper.GetNumberInRange(1, 2);
            }

            result.RacialTraits.Add("Hellish Resistance: gain Resistance to Fire");
            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 200;
            result.Speed = 30;
            if (answer == 1)
            {
                result.Speed = 30;
                result.Speedstring = ", Fly 30ft";
            }
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-N");
            result.Alignment.Add("C-E");
            result.AdultAge = 18;
            result.MaxAgeStart = 80;
            result.Languages.Add("Infernal");
            
            if (input == 1)
            {
                result.Cantrips.Add("Thaumaturgy - Cha to cast");
                result.TieflingMagic = "Infernal Legacy";
            }
            else if (input == 2)
            {
                result.Cantrips.Add("Vicious Mockery - Cha to cast");
                result.TieflingMagic = "Devil's Tongue";
            }

            return result;
        }
        public static Race FeralTiefling()
        {
            Race result = new Race();
            int input = 0;
            Console.WriteLine("Would you like wings or magic? Pick a number.");
            CLIHelper.Print2Choices("Wings", "Magic");
            int answer = CLIHelper.GetNumberInRange(1, 2);
            if (answer == 2)
            {
                Console.WriteLine("Which kind of magic would you like? Pick a number.");
                CLIHelper.Print2Choices("Infernal Legacy", "Devil's Tongue");
                input = CLIHelper.GetNumberInRange(1, 2);
            }

            result.RacialTraits.Add("Hellish Resistance: gain Resistance to Fire");
            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 200;
            result.Speed = 30;
            if (answer == 1)
            {
                result.Speed = 30;
                result.Speedstring = ", Fly 30ft";
            }
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-N");
            result.Alignment.Add("C-E");
            result.AdultAge = 18;
            result.MaxAgeStart = 80;
            result.Languages.Add("Infernal");

            if (input == 1)
            {
                result.Cantrips.Add("Thaumaturgy - Cha to cast");
                result.TieflingMagic = "Infernal Legacy";
            }
            else if (input == 2)
            {
                result.Cantrips.Add("Vicious Mockery - Cha to cast");
                result.TieflingMagic = "Devil's Tongue";
            }

            return result;
        }
    }
}
