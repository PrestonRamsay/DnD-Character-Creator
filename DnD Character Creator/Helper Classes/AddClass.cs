using DnD_Character_Creator.Races;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class AddClass
    {
        public static void ClassSpecifics(Character character, CharacterClass class1)
        {
            character.ProficiencyBonus = class1.ProfBonus;
            character.Saves.AddRange(class1.Saves);
            character.ClassFeatures = class1.ClassFeatures;
        }
        public static void AddEquipment(Character character, CharacterClass class1)
        {
            string str1 = "Pick a weapon to add to your inventory by entering the number next to it.";
            string str2 = "Pick two weapons to add to your inventory. Enter them one at a time.";
            
            if (class1.Equipment.Contains("Simple melee weapon2"))
            {
                class1.Equipment.Remove("Simple melee weapon");
                class1.Equipment.Remove("Simple melee weapon2");
                int index1 = Options.GetOptionIndex(Options.SimpleMeleeWeapons, str2);
                int index2 = CLIHelper.GetNumberInRange(1, Options.SimpleMeleeWeapons.Count);
                class1.Equipment.Add(Options.SimpleMeleeWeapons[index1]);
                class1.Equipment.Add(Options.SimpleMeleeWeapons[index2]);
            }
            else if (class1.Equipment.Contains("Simple melee weapon"))
            {
                class1.Equipment.Remove("Simple melee weapon");
                int index = Options.GetOptionIndex(Options.SimpleMeleeWeapons, str1);
                class1.Equipment.Add(Options.SimpleMeleeWeapons[index]);
            }
            if (class1.Equipment.Contains("Martial weapon2"))
            {
                class1.Equipment.Remove("Martial weapon2");
                class1.Equipment.Remove("Martial weapon");
                var martialWeapons = new List<string>();
                martialWeapons.AddRange(Options.MartialMeleeWeapons);
                martialWeapons.AddRange(Options.MartialRangedWeapons);
                int index1 = Options.GetOptionIndex(martialWeapons, str2);
                int index2 = CLIHelper.GetNumberInRange(1, martialWeapons.Count);
                class1.Equipment.Add(martialWeapons[index1]);
                class1.Equipment.Add(martialWeapons[index2]);
            }
            else if (class1.Equipment.Contains("Martial weapon"))
            {
                class1.Equipment.Remove("Martial weapon");
                var martialWeapons = new List<string>();
                martialWeapons.AddRange(Options.MartialMeleeWeapons);
                martialWeapons.AddRange(Options.MartialRangedWeapons);
                int index = Options.GetOptionIndex(martialWeapons, str1);
                class1.Equipment.Add(martialWeapons[index]);

            }
            if (class1.Equipment.Contains("Martial melee weapon"))
            {
                class1.Equipment.Remove("Martial melee weapon");
                int index = Options.GetOptionIndex(Options.MartialMeleeWeapons, str1);
                class1.Equipment.Add(Options.MartialMeleeWeapons[index]);
            }
            if (class1.Equipment.Contains("Simple weapon"))
            {
                class1.Equipment.Remove("Simple weapon");
                var simpleWeapons = new List<string>();
                simpleWeapons.AddRange(Options.SimpleMeleeWeapons);
                simpleWeapons.AddRange(Options.SimpleRangedWeapons);
                int index = Options.GetOptionIndex(simpleWeapons, str1);
                class1.Equipment.Add(simpleWeapons[index]);
            }

            character.Equipment.AddRange(class1.Equipment);
        }
        public static void AddProficiencies(Character character, CharacterClass class1)
        {
            foreach (var item in class1.Proficiencies)
            {
                if (!character.Proficiencies.Contains(item))
                {
                    character.Proficiencies.Add(item);
                }
            }
            foreach (var item in class1.ToolProficiencies)
            {
                if (!character.ToolProficiencies.Contains(item))
                {
                    character.ToolProficiencies.Add(item);
                }
            }
        }
        public static void DetermineHP(Character character, CharacterClass class1)
        {
            Console.WriteLine("Would you like to roll for your HP or take the average?");
            CLIHelper.Print2Choices("Take average", "Roll");
            int input = CLIHelper.GetNumberInRange(1, 2);
            int firstLvlHP = class1.HitDie + character.ConMod;
            int remainingLvls = class1.Lvl - 1;

            if (input == 1)
            {
                int hitDieAvg = (class1.HitDie / 2) + 1;
                character.HP = firstLvlHP + (remainingLvls * (hitDieAvg + character.ConMod));
            }
            else
            {
                DieRoll hitDie = new DieRoll(class1.HitDie);
                int HP = firstLvlHP;

                for (int i = 0; i < class1.Lvl - 1; i++)
                {
                    HP += (hitDie.RollDie() + character.ConMod);
                }

                character.HP = HP;
            }
        }
        public static void ModifySkills(Character character)
        {
            Dictionary<string, int> skills = new Dictionary<string, int>();

            foreach (var skill in character.Skills.Keys)
            {
                skills.Add(skill, 0);
            }

            foreach (string skill in skills.Keys)
            {
                if (skill.Contains("Str"))
                {
                    character.Skills[skill] += character.StrMod;
                }
                else if (skill.Contains("Dex"))
                {
                    character.Skills[skill] += character.DexMod;
                }
                else if (skill.Contains("Con"))
                {
                    character.Skills[skill] += character.ConMod;
                }
                else if (skill.Contains("Int"))
                {
                    character.Skills[skill] += character.IntMod;
                }
                else if (skill.Contains("Wis"))
                {
                    character.Skills[skill] += character.WisMod;
                }
                else if (skill.Contains("Cha"))
                {
                    character.Skills[skill] += character.ChaMod;
                }
                foreach (var trainedSkill in character.SkillProficiencies)
                {
                    if (skill.Contains(trainedSkill))
                    {
                        character.Skills[skill] += character.ProficiencyBonus;
                    }
                }
            }
        }
    }
}
