using System;
using System.Collections.Generic;

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
                userInput = Console.ReadLine().ToLower().Trim();
                if (listForHelper.Contains(userInput))
                {
                    gettingStringInList = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid option. Please try again");
                }
            }

            return userInput;
        }
        public static string GetNew(List<string> mainList, IEnumerable<string> knownList, string pickMsg)
        {
            var newMainList = new List<string>();
            var newKnownList = new List<string>();
            newMainList.AddRange(mainList);
            newKnownList.AddRange(knownList);

            foreach (var item in mainList)
            {
                if (newKnownList.Contains(item))
                {
                    newMainList.Remove(item);
                }
            }
            int index = PrintChoices(pickMsg, newMainList);
            string newItem = newMainList[index];

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
        public static void AddHeight(Character character)
        {
            string height = Console.ReadLine().Trim();
            bool gettingheight = true;

            while (gettingheight)
            {
                if (!height.Contains("\"") && !height.Contains("'"))
                {
                    Console.WriteLine("Format error, try again.");
                    height = Console.ReadLine().Trim();
                }
                else
                {
                    gettingheight = false;
                }
            }

            character.Height = ConvertHeightToInches(height);
        }
        public static int ConvertHeightToInches(string heightString)
        {
            string[] height = heightString.Split(new char[] { '\'' });
            string secondNumber = "";
            int quoteIndex = height[1].IndexOf("\"");
            secondNumber = height[1].Substring(0, quoteIndex);

            int feet = int.Parse(height[0]) * 12;
            int inches = int.Parse(secondNumber);
            int heightInInches = feet + inches;

            return heightInInches;
        }
        public static void Alignment(Character character)
        {
            Console.Write("\nPick an alignment from: ");
            foreach (string alignment in character.AlignmentOptions)
            {
                Console.Write(alignment + "  ");
            }
            Console.Write("\n");
            character.Alignment = GetStringInList(character.AlignmentOptions).ToUpper();
            if (character.ChosenRace == "Cambion")
            {
                if (character.Alignment == "L-E")
                {
                    character.Languages.Add("Infernal");
                }
                else if (character.Alignment == "C-E")
                {
                    character.Languages.Add("Abyssal");
                }
            }
        }
        public static void Age(Character character)
        {
            if (character.MaxAgeEnd > 100)
            {
                Console.WriteLine($"Enter your age. This race usually lives for " +
                    $"{character.MaxAgeStart}-{character.MaxAgeEnd} years and is considered an adult at the age of " +
                    $"{character.AdultAge}.");
            }
            else
            {
                Console.WriteLine($"Enter your age. This race usually lives for {character.MaxAgeStart} years" +
                    $" and is considered an adult at the age of {character.AdultAge}.");
            }
            character.Age = CLIHelper.GetNumberInRange(character.AdultAge, character.MaxAgeStart + 50);
        }
        public static string AddSpecialty(Character character)
        {
            string backgroundString = character.ChosenBackground;
            string returnString = String.Empty;

            if (backgroundString == "Charltan")
            {
                returnString = $"Favorite Scam: {character.FavoriteScam}";
            }
            else if (backgroundString == "Criminal")
            {
                returnString = $"Specialty: {character.Specialty}";
            }
            else if (backgroundString == "Entertainer")
            {
                string routines = String.Join(", ", character.Routines);
                returnString = $"Routines: {routines}";
            }
            else if (backgroundString == "Folk Hero")
            {
                returnString = $"Defining Event: {character.DefiningEvent}";
            }
            else if (backgroundString == "Guild Artisan")
            {
                returnString = $"Guild Business: {character.GuildBusiness}";
            }
            else if (backgroundString == "Hermit")
            {
                returnString = $"Life of Seclusion: {character.LifeOfSeclusion}";
            }
            else if (backgroundString == "Outlander")
            {
                returnString = $"Origin: {character.Origin}";
            }
            else if (backgroundString == "Sage")
            {
                returnString = $"Specialty: {character.Specialty}";
            }
            else if (backgroundString == "Soldier")
            {
                returnString = $"Specialty: {character.Specialty}";
            }
            if (character.ChosenClass == "Paladin")
            {
                string tenets = String.Join(", ", character.Tenets);
                returnString += $"\nPaladin Tenets: {tenets}\n";
                if (returnString.Length > 130)
                {
                    returnString = returnString.Substring(0, 130) + "\n" + returnString.Substring(130);
                }
            }

            return returnString;
        }
    }
}
