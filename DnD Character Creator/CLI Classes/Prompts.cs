using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator
{
    public static class Prompts
    {
        public static string PickOption(string characterPiece, List<string> pieceList)
        {
            string pickMsg = $"Pick a {characterPiece} you'd like your character to have.";
            int newPiece = CLIHelper.PrintChoices(pickMsg, pieceList);
            string choice = pieceList[newPiece];
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


                    Console.WriteLine($"Your {backgroundPiece} is:" +
                        $"\n{backgroundProperty[index]}");
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
    }
}
