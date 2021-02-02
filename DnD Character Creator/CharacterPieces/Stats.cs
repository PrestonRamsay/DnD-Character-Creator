using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnD_Character_Creator
{
    public class Stats
    {
        public static List<int> FindStats(Character character)
        {
            List<int> stats = new List<int>();
            bool isValidEntry = false;
            int statMax = character.StatMax;

            while (!isValidEntry)
            {
                Console.WriteLine("Would you like to roll your stats, do the point buy system, or use another way? Enter 'roll' or 'buy' or 'custom'.");
                var answerList = new List<string> { "roll", "buy", "custom" };
                string answer = CLIHelper.GetStringInList(answerList);
                Console.Clear();

                if (answer == "Roll")
                {
                    Roll(stats);
                    Console.WriteLine();
                    Console.WriteLine(PrintStats(stats));
                    isValidEntry = true;
                }
                else if (answer == "Buy")
                {
                    Buy(stats);
                    IncreaseBy2D6(stats, statMax);
                    Console.WriteLine();
                    Console.WriteLine(PrintStats(stats));
                    isValidEntry = true;
                }
                else if (answer == "Custom")
                {
                    Custom(stats, statMax);
                    Console.WriteLine();
                    Console.WriteLine(PrintStats(stats));
                    isValidEntry = true;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Try again.");
                }
            }

            return stats;
        }
        public static string PrintStats(IList<int> stats)
        {
            return $"Your stats are {stats[0]}, {stats[1]}, {stats[2]}, {stats[3]}, {stats[4]}, {stats[5]}\n";
        }
        public static void Roll(List<int> allStats)
        {
            int[] rolls = new int[4];
            DieRoll d6 = new DieRoll(6);

            for (int i = 0; i < 6; i++)
            {
                int totalRoll = 0;
                for (int j = 0; j < rolls.Length; j++)
                {
                    rolls[j] = d6.RollDie();

                    //reroll ones and twos
                    while (rolls[j] < 3)
                    {
                        rolls[j] = d6.RollDie();
                    }

                    totalRoll += rolls[j];
                }
                totalRoll -= rolls.Min();
                allStats.Add(totalRoll);
            }
        }
        public static void Buy(List<int> allStats)
        {
            int points = 27;

            while (points != 0)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine($"\nEnter a value between 8 and 15. If you'd like to see cost for each value enter '1'." +
                        $"\nPoints remaining: {points}\n");
                    int input = CLIHelper.GetNumberInRange(1, 15);
                    Dictionary<int, int> costOf = SetCosts();

                    if (input == 1)
                    {
                        Console.WriteLine(DisplayStatPointCosts(costOf));
                        Console.WriteLine("Enter a value between 8 and 15.");
                        input = CLIHelper.GetNumberInRange(8, 15);
                    }

                    int pickedStat = GetValidStat(input);
                    bool successfulAdd = false;

                    while (!successfulAdd)
                    {
                        int cost = costOf[pickedStat];

                        if (cost <= points)
                        {
                            allStats.Add(pickedStat);
                            points -= cost;
                            successfulAdd = true;
                        }
                        else
                        {
                            Console.WriteLine("That stat costs too much, try again.");
                            pickedStat = CLIHelper.GetNumberInRange(8, 15);
                        }
                    }

                }
                if (allStats.Count == 6)
                {
                    Console.WriteLine(PrintStats(allStats));
                    Console.WriteLine("If you'd like to start over: enter '1'. If you'd like to keep your stats hit enter.");
                    string input2 = Console.ReadLine();
                    if (input2 == "1")
                    {
                        points = 27;
                        allStats.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        points = 0;
                    }
                }
            }
        }
        public static string DisplayStatPointCosts(Dictionary<int, int> costOf)
        {
            string returnString = "";

            foreach (int stat in costOf.Keys)
            {
                returnString += $"Score of {stat} costs {costOf[stat]} points\n";
            }
            return returnString;
        }
        public static Dictionary<int, int> SetCosts()
        {
            int[] costs = new int[8];
            Dictionary<int, int> costOf = new Dictionary<int, int>();

            for (int i = 0; i < costs.Length; i++)
            {
                if (i < 6)
                {
                    costs[i] = i;
                }
                else if (i == 6)
                {
                    costs[i] = i + 1;
                }
                else
                {
                    costs[i] = i + 2;
                }
                costOf.Add(8 + i, costs[i]);
            }
            return costOf;
        }
        public static int GetValidStat(int pickedStat)
        {
            bool gettingStat = true;

            while (gettingStat)
            {

                if (8 <= pickedStat && pickedStat <= 15)
                {
                    gettingStat = false;
                }
                else
                {
                    Console.WriteLine("The number you entered is not between 8 and 15. Try again.");
                    pickedStat = CLIHelper.GetNumberInRange(8, 15);
                }
            }

            return pickedStat;
        }
        private static void IncreaseBy2D6(List<int> stats, int statMax)
        {
            DieRoll d6 = new DieRoll(6);
            int totalRoll = d6.RollDie() + d6.RollDie();
            Console.WriteLine($"You rolled: {totalRoll} on your 2D6.\n");
            var statsDisplay = new Stats();

            while (totalRoll != 0)
            {
                statsDisplay.PrintStatsToAssign(stats);
                Console.WriteLine("Pick a stat to increase by entering the number next to it.");
                int pickedStat = CLIHelper.GetNumberInRange(1, stats.Count);
                Console.WriteLine($"Enter the amount of points you'd like to spend. You have {totalRoll} points remaining.");
                int pointsToSpend = CLIHelper.GetNumberInRange(0, totalRoll);
                int newTotal = stats[pickedStat - 1] + pointsToSpend;

                if (newTotal <= statMax)
                {
                    stats[pickedStat - 1] = newTotal;
                    totalRoll = totalRoll - pointsToSpend;
                }
                else
                {
                    Console.WriteLine($"Your stat cannot exceed the max of: {statMax}. Try spending less points.");
                }
                
            }
            Console.Clear();
        }
        public static void Custom(List<int> allStats, int statMax)
        {
            Console.WriteLine("This option is for if you want to roll your stats yourself or if your DM uses a custom method to decide stats. Enter the values one at a time.");

            for (int i = 0; i < 6; i++)
            {
                int stat = CLIHelper.GetNumberInRange(0, statMax);
                allStats.Add(stat);
            }
        }
        public void PrintStatsMenu(int highlight, List<string> stats)
        {
            for (int i = 0; i < stats.Count; i++)
            {
                if (i == highlight)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write($"({i + 1})  {stats[i]}    ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("\n");
        }
        public void PrintStatsToAssign(List<int> stats)
        {
            for (int i = 0; i < stats.Count; i++)
            {
                Console.Write($"({i + 1})  {stats[i]}    ");
            }
            Console.WriteLine("\n");
        }
        public void AssignStats(Character character, List<int> statNums)
        {
            List<string> statWords = new List<string> { "Str", "Dex", "Con", "Int", "Wis", "Cha" };

            while (statNums.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                PrintStatsMenu(-1, statWords);
                Console.WriteLine("Enter the number of the stat you'd like to select");
                int currentlySelected = CLIHelper.GetNumberInRange(1, statWords.Count) - 1;
                string statWord = statWords[currentlySelected];
                Console.Clear();
                PrintStatsMenu(currentlySelected, statWords);
                PrintStatsToAssign(statNums);
                Console.WriteLine($"Pick a stat to assign to {statWord} by entering the number next to it.");
                int statIndex = CLIHelper.GetNumberInRange(1, statNums.Count) - 1;

                if (statWord == "Str")
                {
                    character.Str = statNums[statIndex];
                }
                else if (statWord == "Dex")
                {
                    character.Dex = statNums[statIndex];
                }
                else if (statWord == "Con")
                {
                    character.Con = statNums[statIndex];
                }
                else if (statWord == "Int")
                {
                    character.Int = statNums[statIndex];
                }
                else if (statWord == "Wis")
                {
                    character.Wis = statNums[statIndex];
                }
                else if (statWord == "Cha")
                {
                    character.Cha = statNums[statIndex];
                }
                statNums.RemoveAt(statIndex);
                statWords.Remove(statWord);
                Console.WriteLine($"You assigned your stats as Str: {character.Str}, Dex: {character.Dex}, Con: {character.Con}, " +
                $"Int: {character.Int}, Wis: {character.Wis}, Cha: {character.Cha}\n");
            }
        }
        public static void IncreaseStatsByLvl(Character character)
        {
            int statMax = character.StatMax;
            Console.WriteLine("\nYou have an ability score increase, pick a number from the options.");
            CLIHelper.Print3Choices("Increase 1 stat by 2", "Increase 2 stats by 1", "Pick a feat");
            int input = CLIHelper.GetNumberInRange(1, 3);
            bool pickValidStat = true;

            if (input == 1)
            {
                Console.WriteLine($"\nYour stats are Str: {character.Str}, Dex: {character.Dex}, Con: {character.Con}, " +
                $"Int: {character.Int}, Wis: {character.Wis}, Cha: {character.Cha}");
                while (pickValidStat)
                {
                    Console.WriteLine("Type the stat you'd like to increase.");
                    string stat = CLIHelper.GetStringInList(Options.Stats);
                    pickValidStat = IncreaseStat(character, statMax, stat, 2);
                    Console.WriteLine($"\nYour stats are now Str: {character.Str}, Dex: {character.Dex}, Con: {character.Con}, " +
                $"Int: {character.Int}, Wis: {character.Wis}, Cha: {character.Cha}");
                }
            }
            else if (input == 2)
            {
                Console.WriteLine($"\nYour stats are Str: {character.Str}, Dex: {character.Dex}, Con: {character.Con}, " +
                $"Int: {character.Int}, Wis: {character.Wis}, Cha: {character.Cha}");
                while (pickValidStat)
                {
                    Console.WriteLine("Type the first stat you'd like to increase.");
                    string firstStat = CLIHelper.GetStringInList(Options.Stats);
                    bool first = IncreaseStat(character, statMax, firstStat, 1);
                    if (!first)
                    {
                        Console.WriteLine("Type the second stat you'd like to increase.");
                        string secondStat = CLIHelper.GetStringInList(Options.Stats);
                        pickValidStat = IncreaseStat(character, statMax, secondStat, 1);
                    }
                }
                Console.WriteLine($"\nYour stats are now Str: {character.Str}, Dex: {character.Dex}, Con: {character.Con}, " +
                $"Int: {character.Int}, Wis: {character.Wis}, Cha: {character.Cha}");
            }
            else
            {
                string pickMsg = "You get to pick a feat.";
                int index = CLIHelper.PrintChoices(pickMsg, Options.Feats);
                character.Feats.Add(Options.Feats[index]);
            }
        }
        private static bool IncreaseStat(Character character, int statMax, string stat, int incAmt)
        {
            if (stat == "Str")
            {
                if (character.Str + incAmt <= statMax)
                {
                    character.Str += incAmt;
                    return false;
                }
                else
                {
                    Console.WriteLine("You cannot exceed the max. Try again");
                }
            }
            else if (stat == "Dex")
            {
                if (character.Dex + incAmt <= statMax)
                {
                    character.Dex += incAmt;
                    return false;
                }
                else
                {
                    Console.WriteLine("You cannot exceed the max. Try again");
                }
            }
            else if (stat == "Con")
            {
                if (character.Con + incAmt <= statMax)
                {
                    character.Con += incAmt;
                    return false;
                }
                else
                {
                    Console.WriteLine("You cannot exceed the max. Try again");
                }
            }
            else if (stat == "Int")
            {
                if (character.Int + incAmt <= statMax)
                {
                    character.Int += incAmt;
                    return false;
                }
                else
                {
                    Console.WriteLine("You cannot exceed the max. Try again");
                }
            }
            else if (stat == "Wis")
            {
                if (character.Wis + incAmt <= statMax)
                {
                    character.Wis += incAmt;
                    return false;
                }
                else
                {
                    Console.WriteLine("You cannot exceed the max. Try again");
                }
            }
            else
            {
                if (character.Cha + incAmt <= statMax)
                {
                    character.Cha += incAmt;
                    return false;
                }
                else
                {
                    Console.WriteLine("You cannot exceed the max. Try again");
                }
            }

            return true;
        }
    }
}
