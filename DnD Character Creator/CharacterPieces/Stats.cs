using DnD_Character_Creator.CharacterPieces;
using DnD_Character_Creator.Helper_Classes;
using DnD_Character_Creator.Races;
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
            int statMax = character.StatMax;
            string pickMsg = "Would you like to roll your stats, do the point buy system, or use another way?";
            var answerList = new List<string> { "Roll", "Buy", "Custom" };
            int index = CLIHelper.PrintChoices(pickMsg, answerList);
            string answer = answerList[index];
            Console.Clear();

            switch (answer)
            {
                case "Roll":
                    Roll(stats);
                    break;
                case "Buy":
                    Buy(stats);
                    IncreaseBy2D6(stats, statMax);
                    break;
                case "Custom":
                    Custom(stats, statMax);
                    break;
            }
                
            Console.WriteLine();
            Console.WriteLine(PrintStats(stats));
            
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
            bool successfulAdd = false;

            while (points != 0)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine($"\nEnter a value between 8 and 15. If you'd like to see cost for each value enter '1'." +
                        $"\nPoints remaining: {points}\n");
                    int stat = CLIHelper.GetNumberInRange(1, 15);
                    Dictionary<int, int> costOf = SetCosts();
                    if (stat == 1)
                    {
                        stat = DisplayStatPointCosts(costOf);
                    }
                    while (!successfulAdd)
                    {
                        int cost = costOf[stat];
                        if (cost <= points)
                        {
                            allStats.Add(stat);
                            points -= cost;
                            successfulAdd = true;
                        }
                        else
                        {
                            Console.WriteLine("That stat costs too much, try again.");
                            stat = CLIHelper.GetNumberInRange(8, 15);
                        }
                    }

                }
                if (allStats.Count == 6)
                {
                    Console.WriteLine(PrintStats(allStats));
                    Console.WriteLine("If you'd like to start over: enter '1'. If you'd like to keep your stats hit enter.");
                    string input = Console.ReadLine();
                    if (input == "1")
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
        public static int DisplayStatPointCosts(Dictionary<int, int> costOf)
        {
            Console.Clear();
            string str = "";

            foreach (int stat in costOf.Keys)
            {
                str += $"Score of {stat} costs {costOf[stat]} points\n";
            }

            Console.WriteLine(str);
            Console.WriteLine("Enter a value between 8 and 15.");

            return CLIHelper.GetNumberInRange(8, 15);
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
        public static void PrintStatsMenu(int highlight, List<string> stats)
        {
            for (int i = 0; i < stats.Count; i++)
            {
                if (i == highlight)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write($"({i + 1})  {stats[i]}   ");
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
            List<string> statWords = new List<string>();
            statWords.AddRange(Options.Stats);

            while (statNums.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                PrintStatsMenu(-1, statWords);
                Console.WriteLine("Enter the number of the stat you'd like to select");
                int currentlySelected = CLIHelper.GetNumberInRange(1, statWords.Count) - 1;
                string statWord = statWords[currentlySelected];
                Console.Clear();

                Console.WriteLine("You've selected:");
                PrintStatsMenu(currentlySelected, statWords);
                Console.WriteLine("Your stats are:");
                PrintStatsToAssign(statNums);
                Console.WriteLine($"Pick a stat to assign to {statWord} by entering the number next to it.");
                int statIndex = CLIHelper.GetNumberInRange(1, statNums.Count) - 1;
                Console.Clear();

                character.Stats[statWord] = statNums[statIndex];
                statNums.RemoveAt(statIndex);
                statWords.Remove(statWord);
            }
        }
        public static void RacialStats(Character character, Race race)
        {
            if (race.Name == "Human")
            {
                foreach (var stat in character.Stats.Keys)
                {
                    character.Stats[stat] += 1;
                }
            }
            else
            {
                string stat1 = race.Stat1.Item1;
                int incAmt = race.Stat1.Item2;
                IncreaseStat(character, stat1, incAmt);

                string stat2 = race.Stat2.Item1;
                incAmt = race.Stat2.Item2;
                IncreaseStat(character, stat2, incAmt);

                if (race.Stat3.Item1 != "Null")
                {
                    string stat3 = race.Stat3.Item1;
                    incAmt = race.Stat3.Item2;
                    IncreaseStat(character, stat3, incAmt);
                }
            }
        }
        public static void TemplateStats(Character character, Template template)
        {
            string stat1 = template.Stat1.Item1;
            int incAmt = template.Stat1.Item2;
            IncreaseStat(character, stat1, incAmt);

            string stat2 = template.Stat2.Item1;
            incAmt = template.Stat2.Item2;
            IncreaseStat(character, stat2, incAmt);
        }
        public static void IncreaseStatByLvl(Character character)
        {
            for (int i = 1; i <= character.Lvl; i++)
            {
                if (i != 20)
                {
                    if (i % 4 == 0 || i == 19)
                    {
                        AbilityScoreInc(character);
                    }
                }
                if (character.ChosenClass == "Fighter")
                {
                    if (i == 6 || i == 14)
                    {
                        AbilityScoreInc(character);
                    }
                }
                if (character.ChosenClass == "Rogue")
                {
                    if (i == 10)
                    {
                        AbilityScoreInc(character);
                    }
                }
            }
        }
        public static void AbilityScoreInc(Character character)
        {
            Console.WriteLine("\nYou have an ability score increase, pick from the options.");
            CLIHelper.Print3Choices("Increase 1 stat by 2", "Increase 2 stats by 1", "Pick a feat");
            int input = CLIHelper.GetNumberInRange(1, 3);

            if (input == 1)
            {
                Console.Write($"\nYour stats are ");
                foreach (var stat in Options.Stats)
                {
                    Console.Write($"{stat}: {character.Stats[stat]}  ");
                }
                Console.WriteLine("\n\nPick the stat you'd like to increase.");
                IncreaseStat(character, 2);
                Console.Clear();
                Console.Write($"\nYour stats are now ");
                foreach (var stat in Options.Stats)
                {
                    Console.Write($"{stat}: {character.Stats[stat]}  ");
                }
                Console.WriteLine("");
            }
            else if (input == 2)
            {
                Console.Write($"\nYour stats are ");
                foreach (var stat in Options.Stats)
                {
                    Console.Write($"{stat}: {character.Stats[stat]}  ");
                }
                Console.WriteLine("\n\nPick the first stat you'd like to increase.");
                IncreaseStat(character, 1);
                Console.WriteLine("Pick the second stat you'd like to increase.");
                IncreaseStat(character, 1);
                Console.Clear();
                Console.Write($"\nYour stats are now ");
                foreach (var stat in Options.Stats)
                {
                    Console.Write($"{stat}: {character.Stats[stat]}  ");
                }
                Console.WriteLine("");
            }
            else
            {
                Feats.AddFeat(character);
            }
        }
        public static void IncreaseStat(Character character, int incAmt)
        {
            bool gettingStat = true;
            int statMax = character.StatMax;

            while (gettingStat)
            {
                PrintStatsMenu(-1, Options.Stats);
                int index = CLIHelper.GetIndex(Options.Stats);
                string stat = Options.Stats[index];

                if (character.Stats[stat] + incAmt <= statMax)
                {
                    character.Stats[stat] += incAmt;
                    gettingStat = false;
                }
                else
                {
                    Console.WriteLine("You cannot exceed the max. Try again");
                }
            }
        }
        public static void IncreaseStat(Character character, string stat, int incAmt)
        {
            int statMax = character.StatMax;

            if (character.Stats[stat] + incAmt <= statMax)
            {
                character.Stats[stat] += incAmt;
            }
            else
            {
                character.Stats[stat] = statMax;
            }
        }
        public static string IncreaseStat(Character character, int incAmt, bool retrn)
        {
            bool gettingStat = true;
            int statMax = character.StatMax;
            string returnValue = "";

            while (gettingStat)
            {
                PrintStatsMenu(-1, Options.Stats);
                int index = CLIHelper.GetIndex(Options.Stats);
                string stat = Options.Stats[index];

                if (character.Stats[stat] + incAmt <= statMax)
                {
                    character.Stats[stat] += incAmt;
                    returnValue = stat;
                    gettingStat = false;
                }
                else
                {
                    Console.WriteLine("You cannot exceed the max. Try again");
                }
            }

            return returnValue;
        }
    }
}
