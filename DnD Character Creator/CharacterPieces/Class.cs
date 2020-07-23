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
            if(lvl > 4)
            {
                ProfBonus++;
            }
            if(lvl > 8)
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
        public List<string> Equipment { get; set; } = new List<string>();
        public Dictionary<string, string> ClassFeatures { get; set; } = new Dictionary<string, string>();
        public int CantripsKnown { get; set; }
        public int SpellsKnown { get; set; }
        public Dictionary<int, int> SpellSlots { get; set; } = new Dictionary<int, int>();
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
            Console.WriteLine("Pick 2 skills from the Barbarian's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) Greataxe");
            Console.WriteLine("(2) Any martial melee weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) Two handaxes");
            Console.WriteLine("(2) Any simple weapon");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.MartialMeleeWeapons[3]);
            }
            else
            {
                result.Equipment.Add("Martial melee weapon");
            }
            if (input1 == 1)
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
            result.Proficiencies.Add("3 Musical Instruments");
            result.Saves.Add("Dex");
            result.Saves.Add("Cha");
            Console.WriteLine("Pick 3 skills from the Bard's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            thirdSkill = CLIHelper.CapitalizeFirstLetter(thirdSkill);
            character.SkillProficiencies.Add(thirdSkill);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) Rapier");
            Console.WriteLine("(2) Longsword");
            Console.WriteLine("(3) Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 3);
            Console.WriteLine("(1) Diplomat's pack");
            Console.WriteLine("(2) Entertainer's pack");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) Lute");
            Console.WriteLine("(2) Musical Instrument");
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
            Console.WriteLine("Pick 2 skills from the Cleric's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);            

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }
            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }

            result.Equipment.Add("");
            result.Equipment.Add("");
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Druid(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = Options.Skills;

            result.HitDie = 8;
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Saves.Add("");
            result.Saves.Add("");
            Console.WriteLine("Pick 3 skills from the Bard's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            thirdSkill = CLIHelper.CapitalizeFirstLetter(thirdSkill);
            character.SkillProficiencies.Add(thirdSkill);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }
            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }

            result.Equipment.Add("");
            result.Equipment.Add("");
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Fighter(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = Options.Skills;

            result.HitDie = 10;
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Saves.Add("");
            result.Saves.Add("");
            Console.WriteLine("Pick 3 skills from the Bard's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            thirdSkill = CLIHelper.CapitalizeFirstLetter(thirdSkill);
            character.SkillProficiencies.Add(thirdSkill);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            result.Equipment.Add("Shield(+2 AC)(10gp, 6lb.)");
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }
            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }

            result.Equipment.Add("");
            result.Equipment.Add("");
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Monk(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = Options.Skills;

            result.HitDie = 8;
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Saves.Add("");
            result.Saves.Add("");
            Console.WriteLine("Pick 3 skills from the Bard's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            thirdSkill = CLIHelper.CapitalizeFirstLetter(thirdSkill);
            character.SkillProficiencies.Add(thirdSkill);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }
            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }

            result.Equipment.Add("");
            result.Equipment.Add("");
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Paladin(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = Options.Skills;

            result.HitDie = 10;
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Saves.Add("");
            result.Saves.Add("");
            Console.WriteLine("Pick 3 skills from the Bard's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            thirdSkill = CLIHelper.CapitalizeFirstLetter(thirdSkill);
            character.SkillProficiencies.Add(thirdSkill);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }
            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }

            result.Equipment.Add("");
            result.Equipment.Add("");
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Ranger(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = Options.Skills;

            result.HitDie = 10;
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Saves.Add("");
            result.Saves.Add("");
            Console.WriteLine("Pick 3 skills from the Bard's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            thirdSkill = CLIHelper.CapitalizeFirstLetter(thirdSkill);
            character.SkillProficiencies.Add(thirdSkill);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }
            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }

            result.Equipment.Add("");
            result.Equipment.Add("");
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Rogue(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = Options.Skills;

            result.HitDie = 8;
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Saves.Add("");
            result.Saves.Add("");
            Console.WriteLine("Pick 3 skills from the Bard's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            thirdSkill = CLIHelper.CapitalizeFirstLetter(thirdSkill);
            character.SkillProficiencies.Add(thirdSkill);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }
            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }

            result.Equipment.Add("");
            result.Equipment.Add("");
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Sorcerer(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = Options.Skills;

            result.HitDie = 6;
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Saves.Add("");
            result.Saves.Add("");
            Console.WriteLine("Pick 3 skills from the Bard's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            thirdSkill = CLIHelper.CapitalizeFirstLetter(thirdSkill);
            character.SkillProficiencies.Add(thirdSkill);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }
            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }

            result.Equipment.Add("");
            result.Equipment.Add("");
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Warlock(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = Options.Skills;

            result.HitDie = 8;
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Saves.Add("");
            result.Saves.Add("");
            Console.WriteLine("Pick 3 skills from the Bard's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            thirdSkill = CLIHelper.CapitalizeFirstLetter(thirdSkill);
            character.SkillProficiencies.Add(thirdSkill);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }
            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }

            result.Equipment.Add("");
            result.Equipment.Add("");
            result.CantripsKnown = 2;

            return result;
        }
        public static CharacterClass Wizard(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            List<string> classSkills = Options.Skills;

            result.HitDie = 6;
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Saves.Add("");
            result.Saves.Add("");
            Console.WriteLine("Pick 3 skills from the Bard's class skill list (enter them one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            firstSkill = CLIHelper.CapitalizeFirstLetter(firstSkill);
            character.SkillProficiencies.Add(firstSkill);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            secondSkill = CLIHelper.CapitalizeFirstLetter(secondSkill);
            character.SkillProficiencies.Add(secondSkill);
            string thirdSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            thirdSkill = CLIHelper.CapitalizeFirstLetter(thirdSkill);
            character.SkillProficiencies.Add(thirdSkill);

            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) ");
            Console.WriteLine("(2) ");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }
            if (input1 == 1)
            {
                result.Equipment.Add("");
            }
            else
            {
                result.Equipment.Add("");
            }

            result.Equipment.Add("");
            result.Equipment.Add("");
            result.CantripsKnown = 2;

            return result;
        }
    }
}
