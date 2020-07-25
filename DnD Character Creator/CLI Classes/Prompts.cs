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
            if (newPiece == "see options")
            {
                Console.Clear();
                pieceList.Remove("see options");
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
                for (int i = 0; i < backgroundProperty.Length; i++)
                {
                    Console.WriteLine($"({i + 1}) {backgroundProperty[i]}");
                }
                index = CLIHelper.GetNumberInRange(1, backgroundProperty.Length) - 1;
            }
            else
            {
                bool gettingPiece = true;
                while (gettingPiece)
                {
                    DieRoll dx = new DieRoll(backgroundProperty.Length);
                    index = dx.RollDie() - 1;
                    Console.WriteLine($"Your {backgroundPiece} is:" +
                        $"\n{backgroundProperty[index]}");
                    Console.WriteLine($"If you'd like to keep that {backgroundPiece} enter 'keep', if not enter any key.");
                    string input = CLIHelper.GetString();

                    if (input == "keep")
                    {
                        gettingPiece = false;
                    }
                }                
            }

            return index;
        }
    }
}
