using DnD_Character_Creator.CharacterPieces;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DnD_Character_Creator.Races
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
        public Dictionary<int, int> SpellSlots { get; set; } = new Dictionary<int, int>();
        public static void Get2Skills(Character character, string className, List<string> classSkills)
        {
            Console.WriteLine($"Pick 2 skills from the {className}'s class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            character.SkillProficiencies.Add(secondSkill);
        }
        public static void Get3Skills(Character character, string className, List<string> classSkills)
        {
            Console.WriteLine($"Pick 3 skills from the {className}'s class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            character.SkillProficiencies.Add(thirdSkill);
        }
        public static void Get4Skills(Character character, string className, List<string> classSkills)
        {
            Console.WriteLine($"Pick 4 skills from the {className}'s class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            character.SkillProficiencies.Add(thirdSkill);
            string fourthSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            character.SkillProficiencies.Add(fourthSkill);
        }
        public static CharacterClass Barbarian(Character character)
        {
            var result = new CharacterClass(character.Lvl);
            result = BarbarianSpecifics.Features(result);

            var classSkills = new List<string>() { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival" };

            result.HitDie = 12;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Medium armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Martial weapons");
            result.Saves.Add("Str");
            result.Saves.Add("Con");

            Get2Skills(character, "Barbarian", classSkills);

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

            return result;
        }
        public static CharacterClass Bard(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = Options.Skills;

            result.HitDie = 8;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Hand crossbows");
            result.Proficiencies.Add("Longswords");
            result.Proficiencies.Add("Rapiers");
            result.Proficiencies.Add("Shortswords");
            result.ToolProficiencies.Add("Musical Instrument");
            result.ToolProficiencies.Add("Musical Instrument2");
            result.ToolProficiencies.Add("Musical Instrument3");
            result.Saves.Add("Dex");
            result.Saves.Add("Cha");

            Get3Skills(character, "Bard", classSkills);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print3Choices("Rapier", "Longsword", "Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 3);
            CLIHelper.Print2Choices("Diplomat's pack", "Entertainer's pack");
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
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Cleric(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = new List<string>() { "History", "Insight", "Medicine", "Persuasion", "Religion" };

            result.HitDie = 8;
            result.Proficiencies.Add("Light Armor");
            result.Proficiencies.Add("Medium Armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple Weapons");
            result.Saves.Add("Wis");
            result.Saves.Add("Cha");

            Get2Skills(character, "Cleric", classSkills);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Mace", "Warhammer (if proficient)");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print3Choices("Scale mail", "Leather armor", "Chain mail (if proficient)");
            int input2 = CLIHelper.GetNumberInRange(1, 3);
            CLIHelper.Print2Choices("Light crossbow and 20 bolts", "Any simple weapon");
            int input3 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Priest's pack", "Explorer's pack");
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
            result.CantripsKnown = 3;

            return result;
        }
        public static CharacterClass Druid(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = new List<string> { "Arcana", "Animal Handling", "Insight", "Medicine", "Nature", "Perception", "Religion", "Survival" };

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
            result.ToolProficiencies.Add("Herbalism kit");
            result.Saves.Add("Int");
            result.Saves.Add("Wis");

            Get2Skills(character, "Druid", classSkills);

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

            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Fighter(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = new List<string> { "Acrobatics", "Animal Handling", "Athletics", "History", "Insight", "Intimidation", "Perception", "Survival" };

            result.HitDie = 10;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Medium armor");
            result.Proficiencies.Add("Heavy armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Martial weapons");
            result.Saves.Add("Str");
            result.Saves.Add("Con");

            Get2Skills(character, "Fighter", classSkills);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Chain mail", "Leather, longbow, and 20 arrows");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Any martial weapon, and a shield", "Two martial weapons");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Light crossbow and 20 bolts", "Two handaxes");
            int input3 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Dungeoneer's pack", "Explorer's pack");
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

            return result;
        }
        public static CharacterClass Monk(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = new List<string> { "Acrobatics", "Athletics", "History", "Insight", "Religion", "Stealth" };

            result.HitDie = 8;
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Shortswords");
            Console.WriteLine("Which proficiency would you like?");
            CLIHelper.Print2Choices("One type of artisan's tools", "One musical instrument");
            int choice = CLIHelper.GetNumberInRange(1, 2);

            if (choice == 1)
            {
                result.ToolProficiencies.Add("Artisan's Tools");
            }
            else
            {
                result.ToolProficiencies.Add("Musical instrument");
            }

            result.Saves.Add("Str");
            result.Saves.Add("Dex");

            Get2Skills(character, "Monk", classSkills);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Shortsword", "Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Dungeoneer's pack", "Explorer's pack");
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

            return result;
        }
        public static CharacterClass Paladin(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = new List<string> { "Athletics", "Insight", "Intimidation", "Medicine", "Persuasion", "Religion" };

            result.HitDie = 10;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Medium armor");
            result.Proficiencies.Add("Heavy armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Martial weapons");
            result.Saves.Add("Wis");
            result.Saves.Add("Cha");

            Get2Skills(character, "Paladin", classSkills);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Any martial weapon and a shield", "Two martial weapons");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("5 Javelins", "Any simple weapon");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Priest's pack", "Explorer's pack");
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

            return result;
        }
        public static CharacterClass Ranger(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = new List<string> { "Animal Handling", "Athletics", "Insight", "Investigation", "Nature", "Perception", "Stealth", "Survival" };

            result.HitDie = 10;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Medium armor");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Martial weapons");
            result.Saves.Add("Str");
            result.Saves.Add("Dex");

            Get3Skills(character, "Ranger", classSkills);

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

            return result;
        }
        public static CharacterClass Rogue(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = new List<string> { "Acrobatics", "Animal Handling", "Athletics", "Deception", "Insight", "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth" };

            result.HitDie = 8;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Hand crossbows");
            result.Proficiencies.Add("Longswords");
            result.Proficiencies.Add("Rapiers");
            result.Proficiencies.Add("Shortswords");
            result.ToolProficiencies.Add("Thieves' tools");
            result.Saves.Add("Dex");
            result.Saves.Add("Int");

            Get4Skills(character, "Rogue", classSkills);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Rapier", "Shortsword");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Shortbow and a quiver of 20 arrows", "Shortsword");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print3Choices("Burglar's pack", "Dungeoneer's", "Explorer's pack");
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
            result.Equipment.Add("Thieves' tools");

            return result;
        }
        public static CharacterClass Sorcerer(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = new List<string> { "Arcana", "Deception", "Insight", "Intimidation", "Persuasion", "Religion" };

            result.HitDie = 6;
            result.Proficiencies.Add("Daggers");
            result.Proficiencies.Add("Darts");
            result.Proficiencies.Add("Slings");
            result.Proficiencies.Add("Quarterstaffs");
            result.Proficiencies.Add("Light crossbows");
            result.Saves.Add("Con");
            result.Saves.Add("Cha");

            Get2Skills(character, "Sorcerer", classSkills);

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
                Console.WriteLine($"Pick an arcane focus.");
                int index = Options.GetOptionIndex(Options.ArcaneFocuses);
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
            result.CantripsKnown = 4;

            return result;
        }
        public static CharacterClass Warlock(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = new List<string> { "Arcana", "Deception", "History", "Intimidation", "Investigation", "Nature", "Religion" };

            result.HitDie = 8;
            result.Proficiencies.Add("Light armor");
            result.Proficiencies.Add("Simple weapons");
            result.Saves.Add("Wis");
            result.Saves.Add("Cha");

            Get2Skills(character, "Warlock", classSkills);

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
                Console.WriteLine($"Pick an arcane focus.");
                int index = Options.GetOptionIndex(Options.ArcaneFocuses);
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
            
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Wizard(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = new List<string> { "Arcana", "History", "Insight", "Investigation", "Medicine", "Religion" };

            result.HitDie = 6;
            result.Proficiencies.Add("Daggers");
            result.Proficiencies.Add("Darts");
            result.Proficiencies.Add("Slings");
            result.Proficiencies.Add("Quarterstaffs");
            result.Proficiencies.Add("Light crossbows");
            result.Saves.Add("Int");
            result.Saves.Add("Wis");

            Get2Skills(character, "Wizard", classSkills);

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
                Console.WriteLine($"Pick an arcane focus.");
                int index = Options.GetOptionIndex(Options.ArcaneFocuses);
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
            result.CantripsKnown = 3;

            return result;
        }
    }
}
