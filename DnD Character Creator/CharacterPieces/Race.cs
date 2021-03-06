﻿using DnD_Character_Creator.CharacterPieces.Spells;
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
        public List<string> Feats { get; set; } = new List<string>();
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
        public static Race GetStats(string raceString)
        {
            var result = new Race();

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
                    int choice = CLIHelper.GetNumberInRange(1, 2);
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
        public static Race ProtectorAasimar()
        {
            Race result = new Race();

            result.RacialTraits.Add("Celestial Radiance: Resistance to Necrotic & Radiant dmg");
            result.RacialTraits.Add("Healing Hands: action, 1/LR, heal HP = lvl");
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
            result.RacialTraits.Add("Healing Hands: action, 1/LR, heal HP = lvl");
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
        public static Race FallenAasimar()
        {
            Race result = new Race();

            result.RacialTraits.Add("Celestial Radiance: Resistance to Necrotic & Radiant dmg");
            result.RacialTraits.Add("Healing Hands: action, 1/LR, heal HP = lvl");
            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 300;
            result.Speed = 30;
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("TN");
            result.Alignment.Add("N-E");
            result.MaxAgeStart = 160;
            result.Languages.Add("Celestial");
            result.Cantrips.Add("Light - Cha to cast");

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
                $"\nrecharge SR, Con-based DC");
            result.RacialTraits.Add("Bite - 1D6 piercing");
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
                "\ngain add your Proficiency bonus x2");
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
                "\ngain add your Proficiency bonus x2");
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
                "\nAfter resting in such a way, you gain the benefits of a long rest");
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
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
            result.RacialTraits.Add("Sunlight Sensitivity: take a Disadvantage on attacks and Perception checks that rely " +
                "\non sight while you or the target of your check/attack is in direct sunlight");
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
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
            result.RacialTraits.Add("Fey Step: bonus, SR, teleport 30ft & seasonal effect(Cha-based DC)" +
                "\nAutumn - 2 creatures within 10ft charm Wis save" +
                "\nSpring - teleport 1 willing creature within 30ft instead of yourself" +
                "\nSummer - creatures you can see within 5ft take Cha fire dmg" +
                "\nWinter - 1 creature within 5ft fear Wis save");
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
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
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
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
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
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
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
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
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
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
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
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
            result.RacialTraits.Add("Mask of the Wild: you can attempt to hide even when you are only lightly obscured " +
                "\nby foliage, heavy rain, falling snow, mist, and other natural phenomena.");
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
                "\nsimple ideas to small or smaller beasts");            
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
                "\ntechnology, or alchemy are treated as if you are proficient and add your Proficiency bonus x2");
            result.RacialTraits.Add("Tinker: you can spend 1hr and 10gp to create a tiny clockwork device that has 1HP and " +
                "\nan AC of 5. The device ceases to function after 24hr unless you spend 1hr to repair it. You can also use " +
                "\nyour action to dismantle the device and reclaim it's materials. You can make: a fire starter(creates " +
                "\nminiature flame), a music box(single song at a moderate volume), or a clockwork toy(moves 5ft in a random " +
                "\ndirection and makes noise approriate to the creature it represents).");
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
            result.RacialTraits.Add("Stone's Endurance: reaction, SR, reduce dmg by 1D12 + Con");
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
            msg = "You get to pick a feat. Enter the feat you'd like here.";
            index = CLIHelper.PrintChoices(msg, Options.Feats);
            string feat = Options.Feats[index];
            result.Feats.Add(feat);

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

            result.RacialTraits.Add("Horns - 1D6 piercing");
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
