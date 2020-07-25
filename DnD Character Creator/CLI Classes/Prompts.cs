using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator
{
    public static class Prompts
    {
        public static string Prompt(string characterPiece)
        {
            return $"Type the name of the {characterPiece} you'd like your character to have. " +
                $"{Options.SeeOptions}";
        }
        public static string Prompt2(string characterPiece)
        {
            return $"Enter the {characterPiece} you'd like to choose.";
        }
        public static string PickOption(string characterPiece, List<string> pieceList)
        {
            Console.WriteLine(Prompt(characterPiece));
            string newPiece = CLIHelper.GetStringInList(pieceList);
            if (newPiece == "1")
            {
                Console.Clear();
                pieceList.Remove("1");
                for (int i = 0; i < pieceList.Count; i++)
                {
                    Console.WriteLine(pieceList[i]);
                }

                Console.WriteLine($"\n{Prompt2(characterPiece)}");
                newPiece = CLIHelper.GetStringInList(pieceList);
            }

            return newPiece;
        }
        public static int BackgroundPrompts(string backgroundPiece, string[] backgroundProperty)
        {
            Console.Clear();
            Console.WriteLine($"If you'd like to pick your {backgroundPiece} enter 'pick'." +
                $"\nIf you want to roll it randomly enter 'roll'.");
            var answerList = new List<string> { "pick", "roll" };
            string answer = CLIHelper.GetStringInList(answerList);            
            Console.WriteLine();
            int index = 0;
            
            if (answer == "pick")
            {
                Console.WriteLine($"Enter the number next to the {backgroundPiece} you want.");
                index = Options.GetOptionIndex(backgroundProperty);
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
                    Console.WriteLine($"If you'd like to keep that {backgroundPiece} enter 'keep', if not enter any key." +
                        $"\nIf you'd like to pick from the list instead, enter 'pick'.");
                    string input = CLIHelper.GetString();

                    if (input == "keep")
                    {
                        gettingPiece = false;
                    }
                    if (input == "pick")
                    {
                        Console.WriteLine($"Enter the number next to the {backgroundPiece} you want.");
                        index = Options.GetOptionIndex(backgroundProperty);
                        gettingPiece = false;
                    }
                }                
            }

            return index;
        }
    }
}
