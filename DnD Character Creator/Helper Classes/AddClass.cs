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
        }
        public static void DetermineHP(Character character, CharacterClass class1)
        {
            Console.WriteLine("Would you like to roll for your HP or take the average?");
            Console.WriteLine("(1) Take average");
            Console.WriteLine("(2) Roll");
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
