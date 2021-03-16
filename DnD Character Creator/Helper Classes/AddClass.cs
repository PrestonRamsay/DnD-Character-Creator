using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class AddClass
    {
        public static void ClassSpecifics(Character character, CharacterClass class1)
        {
            character.Saves.AddRange(class1.Saves);
            foreach (var item in class1.ClassFeatures.Keys)
            {
                character.ClassFeatures.Add(item, class1.ClassFeatures[item]);
            }
            character.GP += class1.GP;
        }
        public static void AddEquipment(Character character, CharacterClass class1)
        {
            string str1 = "Pick a weapon to add to your inventory by entering the number next to it.";
            string str2 = "Pick two weapons to add to your inventory.";
            
            if (class1.Equipment.Contains("Simple melee weapon2"))
            {
                class1.Equipment.Remove("Simple melee weapon");
                class1.Equipment.Remove("Simple melee weapon2");
                Console.WriteLine(str2);
                int index1 = CLIHelper.PrintChoices(str1, Options.SimpleMeleeWeapons);
                int index2 = CLIHelper.PrintChoices(str1, Options.SimpleMeleeWeapons);
                class1.Equipment.Add(Options.SimpleMeleeWeapons[index1]);
                class1.Equipment.Add(Options.SimpleMeleeWeapons[index2]);
            }
            else if (class1.Equipment.Contains("Simple melee weapon"))
            {
                class1.Equipment.Remove("Simple melee weapon");
                int index = CLIHelper.PrintChoices(str1, Options.SimpleMeleeWeapons);
                class1.Equipment.Add(Options.SimpleMeleeWeapons[index]);
            }
            if (class1.Equipment.Contains("Martial weapon2"))
            {
                class1.Equipment.Remove("Martial weapon2");
                class1.Equipment.Remove("Martial weapon");
                var martialWeapons = new List<string>();
                martialWeapons.AddRange(Options.MartialMeleeWeapons);
                martialWeapons.AddRange(Options.MartialRangedWeapons);
                Console.WriteLine(str2);
                int index1 = CLIHelper.PrintChoices(str1, martialWeapons);
                int index2 = CLIHelper.PrintChoices(str1, martialWeapons);
                class1.Equipment.Add(martialWeapons[index1]);
                class1.Equipment.Add(martialWeapons[index2]);
            }
            else if (class1.Equipment.Contains("Martial weapon"))
            {
                class1.Equipment.Remove("Martial weapon");
                var martialWeapons = new List<string>();
                martialWeapons.AddRange(Options.MartialMeleeWeapons);
                martialWeapons.AddRange(Options.MartialRangedWeapons);
                int index = CLIHelper.PrintChoices(str1, martialWeapons);
                class1.Equipment.Add(martialWeapons[index]);

            }
            if (class1.Equipment.Contains("Martial melee weapon"))
            {
                class1.Equipment.Remove("Martial melee weapon");
                int index = CLIHelper.PrintChoices(str1, Options.MartialMeleeWeapons);
                class1.Equipment.Add(Options.MartialMeleeWeapons[index]);
            }
            if (class1.Equipment.Contains("Simple weapon"))
            {
                class1.Equipment.Remove("Simple weapon");
                var simpleWeapons = new List<string>();
                simpleWeapons.AddRange(Options.SimpleMeleeWeapons);
                simpleWeapons.AddRange(Options.SimpleRangedWeapons);
                int index = CLIHelper.PrintChoices(str1, simpleWeapons);
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
            string trainedSkills = string.Join(", ", character.SkillProficiencies);
            var skillList = new List<string>();
            var skills = new Dictionary<string, int>();

            foreach (string skill in character.Skills.Keys)
            {
                skills.Add(skill, character.Skills[skill]);

                if (skill.Contains("Str"))
                {
                    skills[skill] += character.StrMod;
                }
                else if (skill.Contains("Dex"))
                {
                    skills[skill] += character.DexMod;
                }
                else if (skill.Contains("Con"))
                {
                    skills[skill] += character.ConMod;
                }
                else if (skill.Contains("Int"))
                {
                    skills[skill] += character.IntMod;
                }
                else if (skill.Contains("Wis"))
                {
                    skills[skill] += character.WisMod;
                }
                else if (skill.Contains("Cha"))
                {
                    skills[skill] += character.ChaMod;
                }
                string withoutStat = skill.Substring(0, skill.Length - 5);
                if (trainedSkills.Contains(withoutStat))
                {
                    skills[skill] += character.ProficiencyBonus;
                    string fullSkill = $"(t) {skill}";
                    skillList.Add(fullSkill);
                    skills.Add(fullSkill, skills[skill]);
                    skills.Remove(skill);
                }
                else
                {
                    skillList.Add(skill);
                }
            }
            character.Skills.Clear();

            foreach (var skill in skillList)
            {
                character.Skills.Add(skill, skills[skill]);
            }
        }
        public static void AddSpellsKnown(Character character, CharacterClass class1)
        {
            string classString = character.ChosenClass;
            int lvl = character.Lvl;
            var cantrips = new List<string> { "Bard", "Cleric", "Druid", "Sorcerer", "Swordmage", "Warlock", "Wizard" };

            if (cantrips.Contains(classString))
            {
                class1.CantripsKnown = 2;

                if (lvl >= 4)
                {
                    class1.CantripsKnown++;
                }
                if (lvl >= 10)
                {
                    class1.CantripsKnown++;
                }
                if (classString == "Cleric" || classString == "Wizard")
                {
                    class1.CantripsKnown++;
                }
                if (classString == "Sorcerer")
                {
                    class1.CantripsKnown += 2;
                }
            }
            if (classString == "Bard")
            {
                class1.SpellsKnown = 4;
                for (int i = 2; i <= lvl; i++)
                {
                    if (i <= 9 || i == 11 || i == 15 || i == 17)
                    {
                        class1.SpellsKnown++;
                    }
                    if (i == 10 || i == 14 || i == 18)
                    {
                        class1.SpellsKnown += 2;
                    }
                }
            }
            if (classString == "Sorcerer" || classString == "Swordmage")
            {
                class1.SpellsKnown = 2;
                for (int i = 2; i <= lvl; i++)
                {
                    if (i <= 11 || i == 13 || i == 15 || i == 17)
                    {
                        class1.SpellsKnown++;
                    }
                }
            }
            if (classString == "Warlock")
            {
                class1.SpellsKnown = 2;
                for (int i = 2; i <= lvl; i++)
                {
                    if (i <= 9 || i == 11 || i == 13 || i == 15 || i == 17 || i == 19)
                    {
                        class1.SpellsKnown++;
                    }
                }
            }
        }
        public static void AddSpellSlots(Character character, CharacterClass class1)
        {
            string classString = character.ChosenClass;
            int lvl = character.Lvl;
            var classes = new List<string> { "Bard", "Cleric", "Druid", "Sorcerer", "Wizard" };

            if (classes.Contains(classString))
            {
                int spellSlotLvl = 0;
                int lvlToInc = 5;
                for (int i = 1; i <= lvl; i++)
                {
                    if (i % 2 != 0 && i <= 17)
                    {
                        spellSlotLvl++;
                        if (i <= 5)
                        {
                            class1.SpellSlots[spellSlotLvl] += 2;
                        }
                        else
                        {
                            class1.SpellSlots[spellSlotLvl] += 1;
                        }
                    }
                    if (i % 2 == 0 && i <= 10)
                    {
                        class1.SpellSlots[spellSlotLvl]++;
                    }
                    if (i >= 18)
                    {
                        class1.SpellSlots[lvlToInc]++;
                        lvlToInc++;
                    }
                }
            }
            if (classString == "Warlock")
            {
                int spellSlotLvl = 2;

                for (int i = 1; i <= lvl; i++)
                {
                    if (i <= 2)
                    {
                        class1.SpellSlots[1]++;
                    }
                    if (i % 2 != 0 && i <= 9)
                    {
                        class1.SpellSlots.Remove(spellSlotLvl - 1);
                        class1.SpellSlots[spellSlotLvl] += 2;
                        spellSlotLvl++;
                    }
                    if (i == 11 || i == 17)
                    {
                        class1.SpellSlots[5]++;
                    }
                }
            }
            if (classString == "Paladin" || classString == "Ranger" || classString == "Swordmage")
            {
                int spellSlotLvl = 1;
                if (classString != "Swordmage")
                {
                    if (lvl >= 2)
                    {
                        class1.SpellSlots[1] += 2;
                    }
                }
                else
                {
                    class1.SpellSlots[1] += 2;
                }
                for (int i = 3; i <= lvl; i++)
                {
                    if (i % 2 != 0)
                    {
                        if ((i != 9 || i != 13) && i <= 17)
                        {
                            class1.SpellSlots[spellSlotLvl]++;
                        }
                        if (i == 5 || i == 9)
                        {
                            spellSlotLvl++;
                            class1.SpellSlots[spellSlotLvl] += 2;
                        }
                        if (i == 13 || i == 17)
                        {
                            spellSlotLvl++;
                            class1.SpellSlots[spellSlotLvl]++;
                        }
                    }
                }
            }
        }
        public static void AddSpells(Character character, CharacterClass class1)
        {
            character.CantripsKnown = class1.CantripsKnown;
            character.Cantrips.AddRange(class1.Cantrips);
            character.SpellsKnown = class1.SpellsKnown;
            for (int i = 1; i < class1.SpellSlots.Count; i++)
            {
                character.SpellSlots[i] = class1.SpellSlots[i];
            }
            for (int i = 1; i < class1.Spells.Count; i++)
            {
                character.Spells[i].AddRange(class1.Spells[i]);
            }
        }
    }
}
