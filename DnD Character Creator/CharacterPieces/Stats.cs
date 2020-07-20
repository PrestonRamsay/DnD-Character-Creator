using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualBasic;

namespace DnD_Character_Creator
{
    public class Stats
    {
        public Stats()
        {
            CurrentlySelected = -1;
        }
        public static List<int> FindStats()
        {
            List<int> stats = new List<int>();
            bool isValidEntry = false;

            while (!isValidEntry)
            {
                Console.WriteLine("Would you like to roll your stats, do the point buy system, or use another way? Enter 'roll' or 'buy' or 'custom'.");
                var answerList = new List<string> { "roll", "buy", "custom" };
                string answer = CLIHelper.GetStringInList(answerList);

                if (answer == "roll")
                {
                    Roll(stats);
                    Console.WriteLine(PrintStats(stats));
                    isValidEntry = true;
                }
                else if (answer == "buy")
                {
                    Buy(stats);
                    Console.WriteLine(PrintStats(stats));
                    isValidEntry = true;
                }
                else if (answer == "custom")
                {
                    Custom(stats);
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
        public static List<int> Roll(List<int> allStats)
        {
            int[] rolls = new int[4];
            DieRoll d6 = new DieRoll(6);

            for (int i = 0; i < 6; i++)
            {
                int totalRoll = 0;
                for (int j = 0; j < rolls.Length; j++)
                {
                    rolls[j] = d6.RollDie();

                    while (rolls[j] < 2)
                    {
                        rolls[j] = d6.RollDie();
                    }

                    totalRoll += rolls[j];
                }
                totalRoll -= rolls.Min();
                allStats.Add(totalRoll);
            }
            return allStats;
        }
        public static List<int> Buy(List<int> allStats)
        {
            int points = 27;

            while (points != 0)
            {
                for (int j = 0; j < 6; j++)
                {
                    string input = CLIHelper.GetString($"\nEnter a value between 8 and 15. " +
                        $"If you'd like to see cost for each value enter 'see costs'." +
                        $"\nPoints remaining: {points}\n");
                    Dictionary<int, int> costOf = SetCosts();

                    if (input == "see costs")
                    {
                        Console.WriteLine(DisplayStatPointCosts(costOf));
                        Console.WriteLine("Enter a value between 8 and 15.");
                    }

                    int intValue = 0;
                    int pickedStat = 0;
                    if (!int.TryParse(input, out intValue))
                    {
                        Console.WriteLine("That entry was not valid. Try again.");
                        pickedStat = CLIHelper.GetNumberInRange(8, 15);
                    }
                    else
                    {
                        pickedStat = GetValidStat(intValue);
                    }

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
                    string input2 = CLIHelper.GetString("If you'd like to start over: enter 'yes'. If you'd like to keep your stats: enter any key");
                    if (input2 == "yes")
                    {
                        points = 27;
                        allStats.Clear();
                    }
                    else
                    {
                        points = 0;
                    }
                }
            }
            return allStats;
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
                    pickedStat = CLIHelper.GetNumber();
                }
            }

            return pickedStat;
        }
        public static List<int> Custom(List<int> allStats)
        {
            Console.WriteLine("This option is for if you want to roll your stats yourself or if your DM uses a custom method to decide stats. Enter the values one at a time.");

            for (int i = 0; i < 6; i++)
            {
                int stat = CLIHelper.GetNumber();
                allStats[i] = stat;
            }

            return allStats;
        }
        public int CurrentlySelected { get; set; }
        public Dictionary<int, string> StatWordPairs { get; set; } = new Dictionary<int, string>
        {
            { 1, "Str" },
            { 2, "Dex" },
            { 3, "Con" },
            { 4, "Int" },
            { 5, "Wis" },
            { 6, "Cha" }
        };

        public void PrintStatsMenu()
        {
            foreach (int key in StatWordPairs.Keys)
            {
                if (key == CurrentlySelected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write($"({key}) {StatWordPairs[key]}    ");
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
        public Character AssignStats(Character character, List<int> stats)
        {
            while (stats.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                PrintStatsMenu();
                Console.WriteLine("Enter the number of the stat you'd like to select");
                CurrentlySelected = CLIHelper.GetNumberInRange(1, 6);
                Console.Clear();
                PrintStatsMenu();
                PrintStatsToAssign(stats);
                Console.WriteLine($"Pick a stat to assign to {StatWordPairs[CurrentlySelected]} by entering the number next to it.");
                int pickedStat = CLIHelper.GetNumberInRange(1, stats.Count);
                if (CurrentlySelected == 1)
                {
                    character.Str = stats[pickedStat - 1];
                    stats.RemoveAt(pickedStat - 1);
                    StatWordPairs.Remove(1);
                }
                else if (CurrentlySelected == 2)
                {
                    character.Dex = stats[pickedStat - 1];
                    stats.RemoveAt(pickedStat - 1);
                    StatWordPairs.Remove(2);
                }
                else if (CurrentlySelected == 3)
                {
                    character.Con = stats[pickedStat - 1];
                    stats.RemoveAt(pickedStat - 1);
                    StatWordPairs.Remove(3);
                }
                else if (CurrentlySelected == 4)
                {
                    character.Int = stats[pickedStat - 1];
                    stats.RemoveAt(pickedStat - 1);
                    StatWordPairs.Remove(4);
                }
                else if (CurrentlySelected == 5)
                {
                    character.Wis = stats[pickedStat - 1];
                    stats.RemoveAt(pickedStat - 1);
                    StatWordPairs.Remove(5);
                }
                else
                {
                    character.Cha = stats[pickedStat - 1];
                    stats.RemoveAt(pickedStat - 1);
                    StatWordPairs.Remove(6);
                }
            }
            Console.WriteLine($"You assigned your stats as Str: {character.Str}, Dex: {character.Dex}, Con: {character.Con}, " +
                $"Int: {character.Int}, Wis: {character.Wis}, Cha: {character.Cha}");

            return character;
        }

    }
}
