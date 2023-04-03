using DnD_Character_Creator.CharacterPieces.Spells;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class BEHelper
    {
        public static void AddLanguage(Character character, string piece)
        {
            string msg = $"This {piece} gets to know one language of your choice, pick it now.";
            string input = CLIHelper.GetNew(Options.Languages, character.Languages, msg);
            character.Languages.Add(input);
        }
        public static void GetTool(Character character)
        {
            var allTools = new List<string>();
            allTools.AddRange(Options.Tools);
            allTools.AddRange(Options.ArtisanTools);
            allTools.AddRange(Options.MusicalInstruments);
            allTools.Remove("Artisan's Tools");
            allTools.Remove("Musical Instrument");
            string tool = CLIHelper.GetNew(allTools, character.ToolProficiencies, "Pick a tool");
            character.ToolProficiencies.Add(tool);
        }
        public static void GetSkills(Character character, List<string> classSkills, int numOfSkills)
        {
            string className = character.ChosenClass;
            int skillsToPick = numOfSkills;
            for (int i = 0; i < numOfSkills; i++)
            {
                string pickMsg = $"Pick {skillsToPick} skills from the {className}'s class skill list (enter them one at a time):";
                string skill = CLIHelper.GetNew(classSkills, character.SkillProficiencies, pickMsg);
                character.SkillProficiencies.Add(skill);
                Console.WriteLine($"You've picked: {skill}");
                skillsToPick--;
            }
        }
        public static List<string> GetTalents(Dictionary<string, string> dict, List<string> list, int optionsNum, string msg)
        {
            string availableOptions = String.Join("", list);
            var dictOptions = new Dictionary<string, string>();
            foreach (var item in dict.Keys)
            {
                if (availableOptions.Contains(item))
                {
                    dictOptions.Add(item, dict[item]);
                }
            }
            var returnList = new List<string>();
            for (int i = 0; i < optionsNum; i++)
            {
                Console.Clear();
                Console.WriteLine(msg + "\n");
                string option = CLIHelper.PrintChoices(dictOptions);
                returnList.Add(option);
                dictOptions.Remove(option);
            }

            return returnList;
        }
        public static void AddSkillExpertise(string str, Character character)
        {
            var skills = new Dictionary<string, int>();
            foreach (var skill in character.Skills.Keys)
            {
                skills.Add(skill, character.Skills[skill]);
            }
            foreach (var skill in skills.Keys)
            {
                if (skill.Contains(str))
                {
                    character.Skills[skill] += character.ProficiencyBonus;
                }
            }
        }
        public static void AddSpellDesc(Character character)
        {
            for (int i = 1; i <= character.Spells.Count; i++)
            {
                for (int j = 0; j < character.Spells[i].Count; j++)
                {
                    var spells = character.Spells[i];
                    var spell = spells[j];
                    if (spell.Contains("("))
                    {
                        spell = spell.Substring(0, spell.IndexOf("("));
                    }
                    if (spell.Contains("*"))
                    {
                        spell = spell.Substring(0, spell.Length - 1);
                    }
                    if (AllSpells.Descriptions.ContainsKey(spell))
                    {
                        character.Spells[i][j] += $": {AllSpells.Descriptions[spell]}";
                    }
                }
            }
        }
        public static void AddPrimSpells(Character character, Dictionary<int, List<string>> expandedDict)
        {
            int spellLvl = 1;
            for (int i = 1; i <= character.Lvl; i += 2)
            {
                if (i > 9)
                {
                    continue;
                }
                character.Spells[spellLvl].AddRange(expandedDict[spellLvl]);
                spellLvl++;
            }
        }
        public static void AddSecSpells(Character character, Dictionary<int, List<string>> expandedDict)
        {
            int spellLvl = 1;
            for (int i = 3; i <= character.Lvl; i += 4)
            {
                character.Spells[spellLvl].AddRange(expandedDict[spellLvl]);
                spellLvl++;

                if (i == 3)
                {
                    i -= 2;
                }
            }
        }
        public static void AddSimpleMeleeWeapon(Character character)
        {
            string msg = "Pick a simple melee weapon";
            int index = CLIHelper.PrintChoices(msg, Options.SimpleMeleeWeapons);
            character.Equipment.Add(Options.SimpleMeleeWeapons[index]);
        }
        public static void AddMartialMeleeWeapon(Character character)
        {
            string msg = "Pick a martial melee weapon";
            int index = CLIHelper.PrintChoices(msg, Options.MartialMeleeWeapons);
            character.Equipment.Add(Options.MartialMeleeWeapons[index]);
        }
        public static void AddSimpleWeapon(Character character)
        {
            var simpleWeapons = new List<string>();
            string msg = "Pick a simple weapon";
            simpleWeapons.AddRange(Options.SimpleMeleeWeapons);
            simpleWeapons.AddRange(Options.SimpleRangedWeapons);
            int index = CLIHelper.PrintChoices(msg, simpleWeapons);
            character.Equipment.Add(simpleWeapons[index]);
        }
        public static void AddMartialWeapon(Character character)
        {
            var martialWeapons = new List<string>();
            martialWeapons.AddRange(Options.MartialMeleeWeapons);
            martialWeapons.AddRange(Options.MartialRangedWeapons);
            if (character.Lvl >= 3 && character.Proficiencies.Contains("Martial weapons"))
            {
                martialWeapons.AddRange(Options.AdvancedMeleeWeapons);
                martialWeapons.AddRange(Options.AdvancedRangedWeapons);
            }
            string msg = "Pick a martial weapon";
            int index = CLIHelper.PrintChoices(msg, martialWeapons);
            character.Equipment.Add(martialWeapons[index]);
        }
        public static void AddHolySymbol(Character character)
        {
            Console.WriteLine("Pick a holy symbol from:");
            CLIHelper.Print3Choices("Amulet", "Emblem", "Reliquary");
            int input = CLIHelper.GetNumberInRange(1, 3);
            if (input == 1)
            {
                character.Equipment.Add(Options.HolySymbols[0]);
            }
            else if (input == 2)
            {
                character.Equipment.Add(Options.HolySymbols[1]);
            }
            else
            {
                character.Equipment.Add(Options.HolySymbols[2]);
            }
        }
        public static void SetXP(Character character)
        {
            switch (character.Lvl)
            {
                case 1:
                    character.XP = 0;
                    break;
                case 2:
                    character.XP = 300;
                    break;
                case 3:
                    character.XP = 900;
                    break;
                case 4:
                    character.XP = 2700;
                    break;
                case 5:
                    character.XP = 6500;
                    break;
                case 6:
                    character.XP = 14000;
                    break;
                case 7:
                    character.XP = 23000;
                    break;
                case 8:
                    character.XP = 34000;
                    break;
                case 9:
                    character.XP = 48000;
                    break;
                case 10:
                    character.XP = 64000;
                    break;
                case 11:
                    character.XP = 85000;
                    break;
                case 12:
                    character.XP = 100000;
                    break;
                case 13:
                    character.XP = 120000;
                    break;
                case 14:
                    character.XP = 140000;
                    break;
                case 15:
                    character.XP = 165000;
                    break;
                case 16:
                    character.XP = 195000;
                    break;
                case 17:
                    character.XP = 225000;
                    break;
                case 18:
                    character.XP = 265000;
                    break;
                case 19:
                    character.XP = 305000;
                    break;
                case 20:
                    character.XP = 355000;
                    break;
            }
        }
    }
}
