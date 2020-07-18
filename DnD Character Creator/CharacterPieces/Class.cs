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
            Console.WriteLine("Pick 2 skills from(one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            result.SkillProficiencies.Add(firstSkill);
            result.SkillProficiencies.Add(secondSkill);
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            Console.WriteLine("(1) Greataxe");
            Console.WriteLine("(2) Any martial melee weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            Console.WriteLine("(1) Two handaxes");
            Console.WriteLine("(2) Any simple weapon");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                result.Equipment.Add(Options.Weapons[19]);
            }
            else
            {
                result.Equipment.Add("Martial melee weapon");
            }
            if (input1 == 1)
            {
                result.Equipment.Add($"2 {Options.Weapons[3]}");
            }
            else
            {
                result.Equipment.Add("Simple weapon");
            }

            result.Equipment.Add(Options.Packs[5]);
            result.Equipment.Add($"4 {Options.Weapons[4]}");

            return result;
        }
        public static CharacterClass Bard(Character character)
        {
            var result = new CharacterClass(character.Lvl);

            var classSkills = new List<string>() { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival" };

            result.HitDie = 12;
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Proficiencies.Add("");
            result.Saves.Add("");
            result.Saves.Add("");
            Console.WriteLine("Pick 2 skills from(one at a time):");
            for (int i = 0; i < classSkills.Count; i++)
            {
                Console.WriteLine(classSkills[i]);
            }
            string firstSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            string secondSkill = CLIHelper.GetSkill(classSkills, character.SkillProficiencies);
            result.SkillProficiencies.Add(firstSkill);
            result.SkillProficiencies.Add(secondSkill);
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
