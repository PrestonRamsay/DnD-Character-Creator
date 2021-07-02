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
        public static string FindRace(string race)
        {
            string pickMsg = "Pick your subrace now.";
            var subraces = new List<string>();
            int index = -1;
            if (race == "Elf")
            {
                subraces.Add("Avariel");
                subraces.Add("Drow");
                subraces.Add("Eladrin");
                subraces.Add("Shadar-Kai");
            }
            foreach (var subrace in Options.SubRaces)
            {
                if (subrace.Contains(race))
                {
                    subraces.Add(subrace);
                }
            }
            switch (race)
            {
                case "Aasimar":
                    index = CLIHelper.PrintChoices(pickMsg, subraces);
                    race = subraces[index];
                    break;
                case "Dwarf":
                    index = CLIHelper.PrintChoices(pickMsg, subraces);
                    race = subraces[index];
                    break;
                case "Elf":
                    Elves.AddRange(subraces);
                    index = CLIHelper.PrintChoices(pickMsg, subraces);
                    race = subraces[index];
                    break;
                case "Gnome":
                    index = CLIHelper.PrintChoices(pickMsg, subraces);
                    race = subraces[index];
                    break;
                case "Halfling":
                    index = CLIHelper.PrintChoices(pickMsg, subraces);
                    race = subraces[index];
                    break;
                case "Human":
                    index = CLIHelper.PrintChoices(pickMsg, subraces);
                    race = subraces[index];
                    break;
                case "Tiefling":
                    index = CLIHelper.PrintChoices(pickMsg, subraces);
                    race = subraces[index];
                    break;
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
