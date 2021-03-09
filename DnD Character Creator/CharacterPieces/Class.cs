using DnD_Character_Creator.CharacterPieces.ClassSpecifics;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.Classes
{
    public class CharacterClass
    {
        public CharacterClass(int lvl)
        {
            ProfBonus = 2;
            Lvl = lvl;
            if (lvl > 4)
            {
                ProfBonus++;
            }
            if (lvl > 8)
            {
                ProfBonus++;
            }
            if (lvl > 12)
            {
                ProfBonus++;
            }
            if (lvl > 16)
            {
                ProfBonus++;
            }
        }
        public int Lvl { get; set; }
        public int GP { get; set; }
        public int HitDie { get; set; }
        public int ProfBonus { get; set; }
        public List<string> Proficiencies { get; protected set; } = new List<string>();
        public List<string> Saves { get; set; } = new List<string>();
        public List<string> SkillProficiencies { get; set; } = new List<string>();
        public List<string> ToolProficiencies { get; set; } = new List<string>();
        public List<string> Equipment { get; set; } = new List<string>();
        public Dictionary<string, string> ClassFeatures { get; set; } = new Dictionary<string, string>();
        public int CantripsKnown { get; set; }
        public int SpellsKnown { get; set; }
        public List<string> Cantrips { get; set; } = new List<string>();
        public Dictionary<int, List<string>> Spells { get; set; } = new Dictionary<int, List<string>>
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
            { 6, new List<string>() },
            { 7, new List<string>() },
            { 8, new List<string>() },
            { 9, new List<string>() }
        };
        public Dictionary<int, int> SpellSlots { get; set; } = new Dictionary<int, int>
        {
            { 1, 0 },
            { 2, 0 },
            { 3, 0 },
            { 4, 0 },
            { 5, 0 },
            { 6, 0 },
            { 7, 0 },
            { 8, 0 },
            { 9, 0 }
        };
        public static CharacterClass NewClass(Character character, CharacterClass result)
        {
            switch (character.ChosenClass)
            {
                case "Barbarian":
                    result = Barbarian(character, result);
                    break;
                case "Bard":
                    result = Bard(character, result);
                    break;
                case "Cleric":
                    result = Cleric(character, result);
                    break;
                case "Druid":
                    result = Druid(character, result);
                    break;
                case "Fighter":
                    result = Fighter(character, result);
                    break;
                case "Monk":
                    result = Monk(character, result);
                    break;
                case "Paladin":
                    result = Paladin(character, result);
                    break;
                case "Ranger":
                    result = Ranger(character, result);
                    break;
                case "Rogue":
                    result = Rogue(character, result);
                    break;
                case "Sorcerer":
                    result = Sorcerer(character, result);
                    break;
                case "Warlock":
                    result = Warlock(character, result);
                    break;
                case "Wizard":
                    result = Wizard(character, result);
                    break;
            }

            return result;
        }
        public static void GetSkills(Character character, string className, List<string> classSkills, int numOfSkills)
        {
            string pickMsg = $"Pick {numOfSkills} skills from the {className}'s class skill list (enter them one at a time):";
            string errorMsg = "You are already trained in that skill, pick a different skill.";
            for (int i = 0; i < numOfSkills; i++)
            {
                string skill = CLIHelper.GetNew(classSkills, character.SkillProficiencies, pickMsg, errorMsg);
                character.SkillProficiencies.Add(skill);
            }
        }
        public static CharacterClass Barbarian(Character character, CharacterClass result)
        {
            var classSkills = new List<string>() { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival" };

            result.GP = 50;
            result.HitDie = 12;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Medium armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Martial weapons");
            result.Saves.Add("Str");
            result.Saves.Add("Con");

            GetSkills(character, "Barbarian", classSkills, 2);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Greataxe", "Any martial melee weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Two handaxes", "Any simple weapon");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.MartialMeleeWeapons[3]);
            }
            else
            {
                result.Equipment.Add("Martial melee weapon");
            }
            if (input2 == 1)
            {
                result.Equipment.Add($"2 {Options.SimpleMeleeWeapons[3]}");
            }
            else
            {
                result.Equipment.Add("Simple weapon");
            }

            result.Equipment.Add(Options.Packs[5]);
            result.Equipment.Add($"4 {Options.SimpleMeleeWeapons[4]}");
            result = BarbarianSpecifics.Features(result);
            character.Archetype = BarbarianSpecifics.PathName;
            character.Speed += BarbarianSpecifics.FastMovement;

            return result;
        }
        public static CharacterClass Bard(Character character, CharacterClass result)
        {
            List<string> classSkills = Options.Skills;

            result.GP = 125;
            result.HitDie = 8;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Hand crossbows");
            result.Proficiencies.Add("Longswords");
            result.Proficiencies.Add("Rapiers");
            result.Proficiencies.Add("Shortswords");
            var instruments = new List<string>();
            instruments.AddRange(Options.MusicalInstruments);
            string msg = "You have proficiency with 3 musical instruments" +
                "\nPick your 1st instrument";
            int index = CLIHelper.PrintChoices(msg, instruments);
            string instrument1 = instruments[index];
            result.ToolProficiencies.Add(instrument1);
            instruments.Remove(instrument1);
            msg = "Pick your 2nd instrument";
            index = CLIHelper.PrintChoices(msg, instruments);
            string instrument2 = instruments[index];
            result.ToolProficiencies.Add(instrument2);
            instruments.Remove(instrument2);
            msg = "Pick your 3rd instrument";
            index = CLIHelper.PrintChoices(msg, instruments);
            string instrument3 = instruments[index];
            result.ToolProficiencies.Add(instrument3);
            instruments.Remove(instrument3);
            result.Saves.Add("Dex");
            result.Saves.Add("Cha");

            GetSkills(character, "Bard", classSkills, 3);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print3Choices("Rapier", "Longsword", "Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 3);
            CLIHelper.Print2Choices("Diplomat's Pack", "Entertainer's Pack");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Lute", "Musical Instrument");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.MartialMeleeWeapons[11]);
            }
            else if (input1 == 2)
            {
                result.Equipment.Add(Options.MartialMeleeWeapons[7]);
            }
            else
            {
                result.Equipment.Add("Simple weapon");
            }
            if (input2 == 1)
            {
                result.Equipment.Add(Options.Packs[1]);
            }
            else
            {
                result.Equipment.Add(Options.Packs[3]);
            }
            if (input3 == 1)
            {
                result.Equipment.Add("Lute");
            }
            else
            {
                result.Equipment.Add("Musical Instrument");
            }

            result.Equipment.Add(Options.LightArmor[1]);
            result.Equipment.Add(Options.SimpleMeleeWeapons[1]);
            result = BardSpecifics.Features(result, character);
            character.Archetype = BardSpecifics.BardicCollege;

            return result;
        }
        public static CharacterClass Cleric(Character character, CharacterClass result)
        {
            List<string> classSkills = new List<string>() { "History", "Insight", "Medicine", "Persuasion", "Religion" };

            result.GP = 125;
            result.HitDie = 8;
            result.Proficiencies.Add("Light Armor");
            result.Proficiencies.Add("Medium Armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple Weapons");
            result.Saves.Add("Wis");
            result.Saves.Add("Cha");

            GetSkills(character, "Cleric", classSkills, 2);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Mace", "Warhammer (if proficient)");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print3Choices("Scale mail", "Leather armor", "Chain mail (if proficient)");
            int input2 = CLIHelper.GetNumberInRange(1, 3);
            CLIHelper.Print2Choices("Light crossbow and 20 bolts", "Any simple weapon");
            int input3 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Priest's Pack", "Explorer's Pack");
            int input4 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.SimpleMeleeWeapons[6]);
            }
            else
            {
                result.Equipment.Add(Options.MartialMeleeWeapons[16]);
            }
            if (input2 == 1)
            {
                result.Equipment.Add(Options.MediumArmor[2]);
            }
            else if (input2 == 2)
            {
                result.Equipment.Add(Options.LightArmor[1]);
            }
            else
            {
                result.Equipment.Add(Options.HeavyArmor[1]);
            }
            if (input3 == 1)
            {
                result.Equipment.Add(Options.SimpleRangedWeapons[0]);
                result.Equipment.Add("20 bolts");
            }
            else
            {
                result.Equipment.Add("Simple weapon");
            }
            if (input4 == 1)
            {
                result.Equipment.Add(Options.Packs[5]);
            }
            else
            {
                result.Equipment.Add(Options.Packs[4]);
            }

            result.Equipment.Add("Shield(+2 AC)(10gp, 6lb.)");
            result.Equipment.Add("Holy symbol");
            result = ClericSpecifics.Features(result, character);
            character.Archetype = ClericSpecifics.DivineDomain;

            return result;
        }
        public static CharacterClass Druid(Character character, CharacterClass result)
        {
            List<string> classSkills = new List<string> { "Arcana", "Animal Handling", "Insight", "Medicine", "Nature", "Perception", "Religion", "Survival" };

            result.GP = 50;
            result.HitDie = 8;
            Console.WriteLine("Druids will not wear armor or use shields made of metal");
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Medium armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Clubs");
            result.Proficiencies.Add("Daggers");
            result.Proficiencies.Add("Darts");
            result.Proficiencies.Add("Javelins");
            result.Proficiencies.Add("Maces");
            result.Proficiencies.Add("Quarterstaffs");
            result.Proficiencies.Add("Scimitars");
            result.Proficiencies.Add("Sickles");
            result.Proficiencies.Add("Slings");
            result.Proficiencies.Add("Spears");
            result.ToolProficiencies.Add("Herbalism Kit");
            result.Saves.Add("Int");
            result.Saves.Add("Wis");

            GetSkills(character, "Druid", classSkills, 2);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Wooden shield", "Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Scimitar", "Any simple melee weapon");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("Wooden shield(+2 AC)(10gp, 6lb.)");
            }
            else
            {
                result.Equipment.Add("Simple weapon");
            }
            if (input2 == 1)
            {
                result.Equipment.Add(Options.MartialMeleeWeapons[12]);
            }
            else
            {
                result.Equipment.Add("Simple melee weapon");
            }

            result.Equipment.Add(Options.LightArmor[1]);
            result.Equipment.Add(Options.Packs[4]);
            Console.WriteLine("Pick a druidic focus. Enter a number.");
            Console.WriteLine("(1) Sprig of mistletoe");
            Console.WriteLine("(2) Totem");
            Console.WriteLine("(3) Wooden Staff");
            Console.WriteLine("(4) Yew wand");
            int focus = CLIHelper.GetNumberInRange(1, 4);

            if (focus == 1)
            {
                result.Equipment.Add(Options.DruidicFocuses[0]);
            }
            else if (focus == 2)
            {
                result.Equipment.Add(Options.DruidicFocuses[1]);
            }
            else if (focus == 2)
            {
                result.Equipment.Add(Options.DruidicFocuses[2]);
            }
            else
            {
                result.Equipment.Add(Options.DruidicFocuses[3]);
            }
            result = DruidSpecifics.Features(result, character);
            character.Archetype = DruidSpecifics.DruidCircle;

            return result;
        }
        public static CharacterClass Fighter(Character character, CharacterClass result)
        {
            List<string> classSkills = new List<string> { "Acrobatics", "Animal Handling", "Athletics", "History", "Insight", "Intimidation", "Perception", "Survival" };

            result.GP = 125;
            result.HitDie = 10;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Medium armor");
            result.Proficiencies.Add("Heavy armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Martial weapons");
            result.Saves.Add("Str");
            result.Saves.Add("Con");

            GetSkills(character, "Fighter", classSkills, 2);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Chain mail", "Leather, longbow, and 20 arrows");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Any martial weapon, and a shield", "Two martial weapons");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Light crossbow and 20 bolts", "Two handaxes");
            int input3 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Dungeoneer's Pack", "Explorer's Pack");
            int input4 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.HeavyArmor[1]);
            }
            else
            {
                result.Equipment.Add(Options.LightArmor[1]);
                result.Equipment.Add(Options.MartialRangedWeapons[3]);
                result.Equipment.Add("20 arrows");
            }
            if (input2 == 1)
            {
                result.Equipment.Add("Martial weapon");
                result.Equipment.Add("Shield(+2 AC)(10gp, 6lb.)");
            }
            else
            {
                result.Equipment.Add("Martial weapon");
                result.Equipment.Add("Martial weapon2");
            }
            if (input3 == 1)
            {
                result.Equipment.Add(Options.SimpleRangedWeapons[0]);
                result.Equipment.Add("20 bolts");
            }
            else
            {
                result.Equipment.Add($"2 {Options.SimpleMeleeWeapons[3]}");
            }
            if (input4 == 1)
            {
                result.Equipment.Add(Options.Packs[2]);
            }
            else
            {
                result.Equipment.Add(Options.Packs[4]);
            }
            result = FighterSpecifics.Features(result, character);
            character.Archetype = FighterSpecifics.MartialArchetype;

            return result;
        }
        public static CharacterClass Monk(Character character, CharacterClass result)
        {
            List<string> classSkills = new List<string> { "Acrobatics", "Athletics", "History", "Insight", "Religion", "Stealth" };

            result.GP = 13;
            result.HitDie = 8;
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Shortswords");
            Console.WriteLine("Which proficiency would you like?");
            CLIHelper.Print2Choices("One type of Artisan's Tools", "One musical instrument");
            int choice = CLIHelper.GetNumberInRange(1, 2);

            if (choice == 1)
            {
                int index = CLIHelper.PrintChoices("Pick a set of Artisan's Tools by entering a number.", Options.ArtisanTools);
                result.ToolProficiencies.Add(Options.ArtisanTools[index]);
            }
            else
            {
                int index = CLIHelper.PrintChoices("Pick a musical instrument you'd like to be proficient with.", Options.MusicalInstruments);
                result.Equipment.Add(Options.MusicalInstruments[index]);
            }

            result.Saves.Add("Str");
            result.Saves.Add("Dex");

            GetSkills(character, "Monk", classSkills, 2);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Shortsword", "Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Dungeoneer's Pack", "Explorer's Pack");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.MartialMeleeWeapons[13]);
            }
            else
            {
                result.Equipment.Add("Simple weapon");
            }
            if (input2 == 1)
            {
                result.Equipment.Add(Options.Packs[2]);
            }
            else
            {
                result.Equipment.Add(Options.Packs[4]);
            }

            result.Equipment.Add($"10 {Options.SimpleRangedWeapons[1]}");
            result = MonkSpecifics.Features(result);
            character.Archetype = MonkSpecifics.MonasticTradition;
            character.Speed += MonkSpecifics.FastMovement;

            return result;
        }
        public static CharacterClass Paladin(Character character, CharacterClass result)
        {
            List<string> classSkills = new List<string> { "Athletics", "Insight", "Intimidation", "Medicine", "Persuasion", "Religion" };

            result.GP = 125;
            result.HitDie = 10;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Medium armor");
            result.Proficiencies.Add("Heavy armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Martial weapons");
            result.Saves.Add("Wis");
            result.Saves.Add("Cha");

            GetSkills(character, "Paladin", classSkills, 2);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Any martial weapon and a shield", "Two martial weapons");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("5 Javelins", "Any simple weapon");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Priest's Pack", "Explorer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("Martial weapon");
                result.Equipment.Add("Shield(+2 AC)(10gp, 6lb.)");
            }
            else
            {
                result.Equipment.Add("Martial weapon");
                result.Equipment.Add("Martial weapon2");
            }
            if (input2 == 1)
            {
                result.Equipment.Add($"5 {Options.SimpleMeleeWeapons[4]}");
            }
            else
            {
                result.Equipment.Add("Simple weapon");
            }
            if (input3 == 1)
            {
                result.Equipment.Add(Options.Packs[5]);
            }
            else
            {
                result.Equipment.Add(Options.Packs[4]);
            }

            result.Equipment.Add(Options.HeavyArmor[1]);
            result.Equipment.Add("Holy symbol");
            result = PaladinSpecifics.Features(result);
            character.Archetype = PaladinSpecifics.SacredOath;

            return result;
        }
        public static CharacterClass Ranger(Character character, CharacterClass result)
        {
            List<string> classSkills = new List<string> { "Animal Handling", "Athletics", "Insight", "Investigation", "Nature", "Perception", "Stealth", "Survival" };

            result.GP = 125;
            result.HitDie = 10;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Medium armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Martial weapons");
            result.Saves.Add("Str");
            result.Saves.Add("Dex");

            GetSkills(character, "Ranger", classSkills, 3);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Scale mail", "Leather armor");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Two shortswords", "Two simple melee weapons");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Dungeoneer's Pack", "Explorer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.MediumArmor[2]);
            }
            else if (input2 == 2)
            {
                result.Equipment.Add(Options.LightArmor[1]);
            }
            if (input2 == 1)
            {
                result.Equipment.Add($"2 {Options.MartialMeleeWeapons[13]}");
            }
            else
            {
                result.Equipment.Add("Simple melee weapon");
                result.Equipment.Add("Simple melee weapon2");
            }
            if (input3 == 1)
            {
                result.Equipment.Add(Options.Packs[2]);
            }
            else
            {
                result.Equipment.Add(Options.Packs[4]);
            }

            result.Equipment.Add(Options.MartialRangedWeapons[3]);
            result.Equipment.Add("Quiver(20 arrows)");
            result = RangerSpecifics.Features(result);
            character.Archetype = RangerSpecifics.RangerArchetype;

            return result;
        }
        public static CharacterClass Rogue(Character character, CharacterClass result)
        {
            List<string> classSkills = new List<string> { "Acrobatics", "Animal Handling", "Athletics", "Deception", "Insight", "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth" };

            result.GP = 100;
            result.HitDie = 8;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Hand crossbows");
            result.Proficiencies.Add("Longswords");
            result.Proficiencies.Add("Rapiers");
            result.Proficiencies.Add("Shortswords");
            result.ToolProficiencies.Add("Thieves' Tools");
            result.Saves.Add("Dex");
            result.Saves.Add("Int");

            GetSkills(character, "Rogue", classSkills, 4);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Rapier", "Shortsword");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Shortbow and a quiver of 20 arrows", "Shortsword");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print3Choices("Burglar's Pack", "Dungeoneer's Pack", "Explorer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 3);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.MartialMeleeWeapons[11]);
            }
            else
            {
                result.Equipment.Add(Options.MartialMeleeWeapons[13]);
            }
            if (input2 == 1)
            {
                result.Equipment.Add(Options.SimpleRangedWeapons[2]);
                result.Equipment.Add("Quiver(20 arrows)");
            }
            else
            {
                result.Equipment.Add(Options.MartialMeleeWeapons[13]);
            }
            if (input3 == 1)
            {
                result.Equipment.Add(Options.Packs[0]);
            }
            else if (input3 == 2)
            {
                result.Equipment.Add(Options.Packs[2]);
            }
            else
            {
                result.Equipment.Add(Options.Packs[4]);
            }

            result.Equipment.Add(Options.LightArmor[1]);
            result.Equipment.Add($"2 {Options.SimpleMeleeWeapons[1]}");
            result.Equipment.Add("Thieves' Tools");
            result = RogueSpecifics.Features(result, character);
            character.Archetype = RogueSpecifics.RoguishArchetype;

            return result;
        }
        public static CharacterClass Sorcerer(Character character, CharacterClass result)
        {
            List<string> classSkills = new List<string> { "Arcana", "Deception", "Insight", "Intimidation", "Persuasion", "Religion" };

            result.GP = 75;
            result.HitDie = 6;
            result.Proficiencies.Add("Daggers");
            result.Proficiencies.Add("Darts");
            result.Proficiencies.Add("Slings");
            result.Proficiencies.Add("Quarterstaffs");
            result.Proficiencies.Add("Light crossbows");
            result.Saves.Add("Con");
            result.Saves.Add("Cha");

            GetSkills(character, "Sorcerer", classSkills, 2);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Light crossbow and 20 bolts", "Any simple weapon");            
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Component pouch", "Arcane focus");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Dungeoneer's Pack", "Explorer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.SimpleRangedWeapons[0]);
                result.Equipment.Add("20 bolts");
            }
            else
            {
                result.Equipment.Add("Simple weapon");
            }
            if (input2 == 1)
            {
                result.Equipment.Add("Component pouch");
            }
            else
            {
                int index = CLIHelper.PrintChoices("Pick an arcane focus.", Options.ArcaneFocuses);
                result.Equipment.Add(Options.ArcaneFocuses[index]);
            }
            if (input3 == 1)
            {
                result.Equipment.Add(Options.Packs[2]);
            }
            else
            {
                result.Equipment.Add(Options.Packs[4]);
            }

            result.Equipment.Add($"2 {Options.SimpleMeleeWeapons[1]}");
            result = SorcererSpecifics.Features(result, character);
            character.Archetype = SorcererSpecifics.SorcerousOrigin;

            return result;
        }
        public static CharacterClass Warlock(Character character, CharacterClass result)
        {
            List<string> classSkills = new List<string> { "Arcana", "Deception", "History", "Intimidation", "Investigation", "Nature", "Religion" };

            result.GP = 100;
            result.HitDie = 8;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Simple weapons");
            result.Saves.Add("Wis");
            result.Saves.Add("Cha");

            GetSkills(character, "Warlock", classSkills, 2);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Light crossbow and 20 bolts", "Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Component pouch", "Arcane focus");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Scholar's Pack", "Dungeoneer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.SimpleRangedWeapons[0]);
                result.Equipment.Add("20 bolts");
            }
            else
            {
                result.Equipment.Add("Simple weapon");
            }
            if (input2 == 1)
            {
                result.Equipment.Add("Component pouch");
            }
            else
            {
                int index = CLIHelper.PrintChoices("Pick an arcane focus.", Options.ArcaneFocuses); ;
                result.Equipment.Add(Options.ArcaneFocuses[index]);
            }
            if (input3 == 1)
            {
                result.Equipment.Add(Options.Packs[6]);
            }
            else
            {
                result.Equipment.Add(Options.Packs[2]);
            }

            result.Equipment.Add(Options.LightArmor[1]);
            result.Equipment.Add($"2 {Options.SimpleMeleeWeapons[1]}");

            if (result.Equipment.Contains("Simple weapon"))
            {
                result.Equipment.Add("Simple weapon2");
            }
            else
            {
                result.Equipment.Add("Simple weapon");
            }
            result = WarlockSpecifics.Features(result);
            character.Archetype = WarlockSpecifics.OtherworldlyPatron;

            return result;
        }
        public static CharacterClass Wizard(Character character, CharacterClass result)
        {
            List<string> classSkills = new List<string> { "Arcana", "History", "Insight", "Investigation", "Medicine", "Religion" };

            result.GP = 100;
            result.HitDie = 6;
            result.Proficiencies.Add("Daggers");
            result.Proficiencies.Add("Darts");
            result.Proficiencies.Add("Slings");
            result.Proficiencies.Add("Quarterstaffs");
            result.Proficiencies.Add("Light crossbows");
            result.Saves.Add("Int");
            result.Saves.Add("Wis");

            GetSkills(character, "Wizard", classSkills, 2);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Quarterstaff", "Dagger");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Component pouch", "Arcane focus");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Scholar's Pack", "Explorer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.SimpleMeleeWeapons[7]);
            }
            else
            {
                result.Equipment.Add(Options.SimpleMeleeWeapons[1]);
            }
            if (input2 == 1)
            {
                result.Equipment.Add("Component pouch");
            }
            else
            {
                int index = CLIHelper.PrintChoices("Pick an arcane focus.", Options.ArcaneFocuses); ;
                result.Equipment.Add(Options.ArcaneFocuses[index]);
            }
            if (input3 == 1)
            {
                result.Equipment.Add(Options.Packs[6]);
            }
            else
            {
                result.Equipment.Add(Options.Packs[4]);
            }

            result.Equipment.Add("Spellbook");
            result = WizardSpecifics.Features(result);
            character.Archetype = WizardSpecifics.ArcaneTradition;

            return result;
        }
    }
}
