using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Drawing;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Sailor : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "My friends know they can rely on me, no matter what.",
            "I work hard so that I can play hard when the work is done.",
            "I enjoy sailing into new ports and making new friends over a flagon of ale.",
            "I stretch the truth for the sake of a good story.",
            "To me, a tavern brawl is a nice way to get to know a new city.",
            "I never pass up a friendly wager.",
            "My language is as foul as an otyugh nest.",
            "I like a job well done, especially if I can convince someone else to do it."
        };
        public static string[] Ideal { get; set; } =
        {
            "Respect. The thing that keeps a ship together is mutual respect between captain and crew. (Good)",
            "Fairness. We all do the work, so we all share in the rewards. (Lawful)",
            "Freedom. The sea is freedom—the freedom to go anywhere and do anything. (Chaotic)",
            "Mastery. I’m a predator, and the other ships on the sea are my prey. (Evil)",
            "People. I’m committed to my crewmates, not to ideals. (Neutral)",
            "Aspiration. Someday I’ll own my own ship and chart my own destiny. (Any)"
        };
        public static string[] Bond { get; set; } =
        {
            "I’m loyal to my captain first, everything else second.",
            "The ship is most important—crewmates and captains come and go.",
            "I’ll always remember my first ship.",
            "In a harbor town, I have a paramour whose eyes nearly stole me from the sea.",
            "I was cheated out of my fair share of the profits, and I want to get my due.",
            "Ruthless pirates murdered my crewmates, plundered our ship, and left me to die. Vengeance will be mine."
        };
        public static string[] Flaw { get; set; } = 
        {
            "I follow orders, even if I think they’re wrong.",
            "I’ll say anything to avoid having to do extra work.",
            "Once someone questions my courage, I never back down no matter how dangerous the situation.",
            "Once I start drinking, it’s hard for me to stop.",
            "I can’t help but pocket loose coins and other trinkets I come across.",
            "My pride will probably lead to my destruction."
        };
        public static void AddStatics(Character character)
        {
            Console.WriteLine("Would you like the Pirate variant of the Sailor background?");
            int choice = CLIHelper.GetChoiceFromPair("Yes", "No");

            if (choice == 1)
            {
                character.ChosenBackground += "(Pirate)";
                Console.WriteLine("Would you like the Bad Reputation feature or the Ship's Passage feature");
                choice = CLIHelper.GetChoiceFromPair("Bad Reputation", "Ship's Passage");

                if (choice == 1)
                {
                    character.BackgroundFeature = "Bad Reputation: when in a civilized settlement, people fear your reputation. You can get away with minor criminal offenses," +
                        "\n     since most people will not report your activity to the authorities.";
                }
                else
                {
                    character.BackgroundFeature = "Ship's Passage: you can secure free passage on a sailing ship for you and your party. You won't determine the route or what stops the" +
                        "\n     ship will make, and the crew expects the party to assist them along the way. The DM decides how long the journey takes.";
                }
            }
            else
            {
                character.BackgroundFeature = "Ship's Passage: you can secure free passage on a sailing ship for you and your party. You won't determine the route or what stops the" +
                    "\n     ship will make, and the crew expects the party to assist them along the way. The DM decides how long the journey takes.";
            }
            var luckyCharmExamples = new List<string>() { "rabbit foot", "small stone with a hole in the center", "random Trinket" };
            Console.WriteLine("Sailors get a lucky charm as a part of their equipment. Pick an option to determine it.");
            choice = CLIHelper.GetChoiceFromPair("Pick from a list of examples.", "Leave it as 'Lucky charm'.");

            if (choice == 1)
            {
                string luckyCharm = CLIHelper.PrintChoices(luckyCharmExamples);
                character.Equipment.Add(luckyCharm);
            }
            else
            {
                character.Equipment.Add("Lucky charm");
            }

            character.SkillProficiencies.Add("Athletics");
            character.SkillProficiencies.Add("Perception");
            character.ToolProficiencies.Add("Navigator's Tools");
            character.ToolProficiencies.Add("Vehicles(water)");
            character.Equipment.Add("Common clothes");
            character.Equipment.Add("Belaying Pin(can be used as a club)");
            character.Equipment.Add("50ft of silk rope");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 10;
            
        }

    }
}
