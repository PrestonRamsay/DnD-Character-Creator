using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator
{
    public static class Prompts
    {
        public static List<string> Elves = new List<string> { "Half-Elf" };
        public static string PickOption(string characterPiece, List<string> pieceList)
        {
            Console.WriteLine($"Pick a {characterPiece} you'd like your character to have.");

            for (int i = 0; i < pieceList.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {pieceList[i]}");
            }

            int num = 1;
            string choice = "";

            if (characterPiece == "race")
            {
                //num = 0;
                //Console.WriteLine("\n        Enter 0 to pick from a list of racial categories\n        ");
            }
            int newPiece = CLIHelper.GetNumberInRange(num, pieceList.Count) - 1;
            //if (newPiece == 0)
            //{
            //    choice = ExtendedRaces();
            //}
            //else
            //{
            choice = pieceList[newPiece];
            //}
            if (characterPiece == "race")
            {
                choice = FindRace(choice);
            }

            return choice;
        }
        public static void PickOption(string characterPiece, List<string> pieceList, Character character)
        {
            Console.WriteLine($"Pick a {characterPiece} you'd like your character to have.");
            int lvl = character.Lvl;

            if (characterPiece == "class")
            {
                Console.WriteLine("Has your character cross-classed? Y/N");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    character.CrossClass = true;
                    Console.WriteLine("Pick your base class first");
                }
            }
            for (int i = 0; i < pieceList.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {pieceList[i]}");
            }
            int newPiece = CLIHelper.GetNumberInRange(1, pieceList.Count) - 1;
            string choice = pieceList[newPiece];
            character.ChosenClass = choice;

            if (character.CrossClass)
            {
                Console.WriteLine($"What level {choice} are you? Must be between 1 and {lvl}.");
                int baseLvl = CLIHelper.GetNumberInRange(1, lvl);
                character.BaseClassLvl = baseLvl;

                Console.WriteLine("What is your second class?");
                pieceList.Remove(choice);
                for (int i = 0; i < pieceList.Count; i++)
                {
                    Console.WriteLine($"({i + 1}) {pieceList[i]}");
                }
                newPiece = CLIHelper.GetNumberInRange(1, pieceList.Count) - 1;
                choice = pieceList[newPiece];
                character.ChosenClassII = choice;
            }
        }
        public static string FindRace(string race)
        {
            string pickMsg = "Pick your subrace now.";
            var races = new List<string> { "Aasimar", "Dwarf", "Gnome", "Genasi", "Halfling", "Human", "Tiefling" };
            var subraces = new List<string>();
            int index = -1;
            if (race == "Elf")
            {
                subraces.Add("Avariel");
                subraces.Add("Drow");
                subraces.Add("Eladrin");
                subraces.Add("Shadar-Kai");
                Elves.AddRange(subraces);
                index = CLIHelper.PrintChoices(pickMsg, subraces);
                race = subraces[index];
            }
            foreach (var subrace in Options.SubRaces)
            {
                if (subrace.Contains(race))
                {
                    subraces.Add(subrace);
                }
            }
            if (races.Contains(race))
            {
                index = CLIHelper.PrintChoices(pickMsg, subraces);
                race = subraces[index];
            }

            return race;
        }
        public static string GetDemigodDomain()
        {
            string pickMsg = "As a demigod, you get to pick a domain that grants you additional benefits";
            int index = CLIHelper.PrintChoices(pickMsg, Options.DemigodDomains);
            string demigodSubrace = Options.DemigodDomains[index];

            return demigodSubrace;
        }
        public static int BackgroundPrompts(string backgroundPiece, string[] backgroundProperty)
        {
            Console.Clear();
            Console.WriteLine($"If you'd like to pick your {backgroundPiece} enter '1'." +
                            $"\nIf you want to roll it randomly enter '2'.");
            int answer = CLIHelper.GetNumberInRange(1, 2);
            int index = 0;

            if (answer == 1)
            {
                Console.WriteLine($"Enter the number next to the {backgroundPiece} you want.");
                index = CLIHelper.PrintChoices(backgroundProperty);
            }
            else
            {
                bool gettingPiece = true;
                while (gettingPiece)
                {
                    DieRoll dx = new DieRoll(backgroundProperty.Length);
                    int dieRoll = dx.RollDie() - 1;
                    if (index == dieRoll)
                    {
                        dieRoll = dx.RollDie() - 1;
                    }
                    index = dieRoll;


                    Console.WriteLine($"Your {backgroundPiece} is: {backgroundProperty[index]}");
                    Console.WriteLine($"If you'd like to keep that {backgroundPiece} enter '1', if not hit enter." +
                        $"\nIf you'd like to pick from the list instead, enter '2'.");
                    int input = CLIHelper.GetNumberInRange(1, 2);

                    if (input == 1)
                    {
                        gettingPiece = false;
                    }
                    if (input == 2)
                    {
                        Console.WriteLine($"Enter the number next to the {backgroundPiece} you want.");
                        index = CLIHelper.PrintChoices(backgroundProperty);
                        gettingPiece = false;
                    }
                }
            }

            return index;
        }
        public static string ExtendedRaces()
        {
            string returnString = "";
            Console.WriteLine("Would you like a Official Race or an Extended Race?\n        ");
            CLIHelper.Print2Choices("Official Race(SRD)", "Extended Race(Homebrew)");
            int choice = CLIHelper.GetNumberInRange(1, 2);
            Console.Clear();
            if (choice == 1)
            {
                returnString = CLIHelper.PrintChoices(Options.OfficialRaces);
            }
            else if (choice == 2)
            {
                returnString = CLIHelper.PrintChoices(Options.ExtendedRaces);
            }

            return returnString;
        }
    }
}
