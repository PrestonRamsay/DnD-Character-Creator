﻿using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Races;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator
{
    public static class CLIHelper
    {      
        public static string GetString(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine().ToLower().Trim();

            return CapitalizeFirstLetter(userInput);
        }
        public static string GetStringInList(List<string> list)
        {
            string userInput = String.Empty;            
            bool gettingStringInList = true;
            var listForHelper = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                listForHelper.Add(list[i].ToLower());
            }
            while(gettingStringInList)
            {
                userInput = Console.ReadLine().ToLower();
                if (listForHelper.Contains(userInput))
                {
                    gettingStringInList = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid option. Please try again");
                }
            }

            return CapitalizeFirstLetter(userInput);
        }
        public static string GetNew(List<string> mainList, IEnumerable<string> knownList, string pickMsg, string alreadyHaveMsg)
        {
            int userInput = 0;
            string newItem = String.Empty;
            bool gettingStringInList = true;
            var list1 = new List<string>();
            var list2 = new List<string>();
            list1.AddRange(mainList);
            list2.AddRange(knownList);

            do
            {
                userInput = PrintChoices(pickMsg, list1);
                newItem = list1[userInput];
                if (list1.Contains(newItem))
                {
                    if (!list2.Contains(newItem))
                    {
                        gettingStringInList = false;
                    }
                    else
                    {
                        Console.WriteLine(alreadyHaveMsg);
                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid option");
                }
            }
            while (gettingStringInList);

            return CapitalizeFirstLetter(newItem);
        }
        public static List<string> GetDictionaryOptions(Dictionary<string, string> dict, int optionsNum, string msg)
        {
            var dictOptions = new Dictionary<string, string>();
            foreach (var item in dict.Keys)
            {
                dictOptions.Add(item, dict[item]);
            }
            var returnList = new List<string>();
            for (int i = 0; i < optionsNum; i++)
            {
                Console.Clear();
                Console.WriteLine(msg + "\n");
                string option = PrintChoices(dictOptions);
                returnList.Add(option);
                dictOptions.Remove(option);
            }

            return returnList;
        }
        public static List<string> GetDictionaryOptions(Dictionary<string, string> dict, List<string> list, int optionsNum, string msg)
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
        public static int GetNumberInRange(int min, int max)
        {
            string userInput = String.Empty;
            int intValue = 0;
            bool gettingNumberInRange = true;

            do
            {
                userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out intValue))
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }
                else
                {
                    if (min <= intValue && intValue <= max)
                    {
                        gettingNumberInRange = false;
                    }
                    else
                    {
                        Console.WriteLine($"Number you entered is not between {min} and {max}. Try again.");
                    }
                }
            }
            while (gettingNumberInRange);

            return intValue;
        }
        public static int GetIndex(List<string> list)
        {
            return GetNumberInRange(1, list.Count) - 1;
        }
        public static string ConvertHeight(int heightInInches)
        {
            int feetHeight = heightInInches / 12;
            int inchesHeight = heightInInches % 12;
            string height = $"{feetHeight}' {inchesHeight}\"";

            return height;
        }
        public static string CapitalizeFirstLetter(string word)
        {
            string returnString = "";

            if (word.Length > 1)
            {
                returnString = char.ToUpper(word[0]) + word.Substring(1);
            }
            else if (word.Length == 1)
            {
                returnString = word.ToUpper();
            }

            return returnString;
        }
        public static void Print2Choices(string str1, string str2)
        {
            var list = new List<string> { str1, str2 };
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {list[i]}");
            }
        }
        public static void Print3Choices(string str1, string str2, string str3)
        {
            var list = new List<string> { str1, str2, str3 };
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {list[i]}");
            }
        }
        public static int PrintChoices(string msg, List<string> list)
        {
            //Console.Clear();
            Console.WriteLine(msg);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {list[i]}");
            }

            return GetNumberInRange(1, list.Count) - 1;
        }
        public static string PrintChoices(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {list[i]}");
            }
            int index = GetNumberInRange(1, list.Count) - 1;

            return list[index];
        }
        public static string PrintChoices(Dictionary<string, string> dict)
        {
            var numDict = new Dictionary<int, string>();
            int num = 1;
            foreach (var item in dict.Keys)
            {
                Console.WriteLine($"({num}) {item}: {dict[item]}");
                numDict.Add(num, item);
                num++;
            }

            int index = GetNumberInRange(1, dict.Count);

            return numDict[index];
        }
        public static string PrintChoices(Dictionary<string, string> dict, List<string> list, string msg)
        {
            Console.WriteLine(msg);
            var numDict = new Dictionary<int, string>();
            int num = 1;
            foreach (var item in list)
            {
                Console.WriteLine($"({num}) {item}: {dict[item]}");
                numDict.Add(num, item);
                num++;
            }

            int index = GetNumberInRange(1, dict.Count);

            return numDict[index];
        }
        public static int PrintChoices(string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine($"({i + 1}) {list[i]}");
            }

            return GetNumberInRange(1, list.Length) - 1;
        }
        public static void GetSkills(Race race, List<string> classSkills, int numOfSkills)
        {
            string pickMsg = $"Pick {numOfSkills} skills from the list (enter them one at a time):";
            string errorMsg = "You are already trained in that skill, pick a different skill.";
            for (int i = 0; i < numOfSkills; i++)
            {
                string skill = GetNew(classSkills, race.SkillProficiencies, pickMsg, errorMsg);
                race.SkillProficiencies.Add(skill);
            }
        }
        public static void AddSpells(CharacterClass result, Dictionary<int, string> dict)
        {
            int spellLvl = 2;
            for (int i = 3; i <= result.Lvl; i += 2)
            {
                result.Spells[spellLvl].Add(dict[spellLvl]);
                spellLvl++;
                if (i == 5 || i == 9)
                {
                    i += 2;
                }
            }
        }
        public static void AddSpells(CharacterClass result, Dictionary<int, List<string>> dict)
        {
            int spellLvl = 2;
            for (int i = 3; i <= result.Lvl; i += 2)
            {
                result.Spells[spellLvl].AddRange(dict[spellLvl]);
                spellLvl++;
                if (i == 5 || i == 9)
                {
                    i += 2;
                }
            }
        }
    }
}
