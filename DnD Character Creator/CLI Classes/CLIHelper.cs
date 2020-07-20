using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator
{
    public static class CLIHelper
    {
        public static string GetString()
        {
            string input = Console.ReadLine().ToLower();
            return input;
        }        
        public static string GetString(string message)
        {
            string userInput = String.Empty;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine().ToLower();
                numberOfAttempts++;
            }
            while (String.IsNullOrEmpty(userInput));

            return userInput;
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
            do
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
            while (gettingStringInList);

            return userInput;
        }
        public static string GetSkill(List<string> list1, List<string> list2)
        {
            string userInput = String.Empty;
            bool gettingStringInList = true;
            var classSkills = new List<string>();
            var knownSkills = new List<string>();

            for (int i = 0; i < list1.Count; i++)
            {
                classSkills.Add(list1[i].ToLower());
            }
            for (int i = 0; i < list2.Count; i++)
            {
                knownSkills.Add(list2[i].ToLower());
            }
            do
            {
                userInput = Console.ReadLine().ToLower();
                if (classSkills.Contains(userInput))
                {
                    if (!knownSkills.Contains(userInput))
                    {
                        gettingStringInList = false;
                    }
                    else
                    {
                        Console.WriteLine("You are already trained in that skill, pick a different skill.");
                    }
                }
                else
                {
                    Console.WriteLine("That is not one of your class skills. Try again");
                }
            }
            while (gettingStringInList);

            return userInput;
        }
        public static int GetNumber()
        {
            string userInput = String.Empty;
            int intValue = 0;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }                
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!int.TryParse(userInput, out intValue));

            return intValue;
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
        public static string ConvertHeight(int heightInInches)
        {
            int feetHeight = heightInInches / 12;
            int inchesHeight = heightInInches % 12;
            string height = $"{feetHeight}' {inchesHeight}\"";

            return height;
        }
        public static int ConvertHeightToInches(string heightString)
        {
            string[] height = heightString.Split(new char[] { '\'' });
            string secondNumber = "";
            if (height[1].Length > 2)
            {
                secondNumber = height[1].Substring(0, 2);
            }
            else
            {
                secondNumber = height[1].Substring(0, 1);
            }

            int feet = int.Parse(height[0]) * 12;
            int inches = int.Parse(secondNumber);
            int heightInInches = feet + inches;

            return heightInInches;
        }
        public static List<string> CreateTossAwayList(List<string> list)
        {
            var tossAwayList = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                tossAwayList.Add(list[i].ToLower());
            }

            return tossAwayList;
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
    }
}
