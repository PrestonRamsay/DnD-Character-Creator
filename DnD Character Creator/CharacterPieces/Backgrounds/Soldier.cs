using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;
using System.Collections.Generic;
using System;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Soldier : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "I'm always polite and respectful.",
            "I’m haunted by memories of war.I can’t get the images of violence out of my mind.",
            "I’ve lost too many friends, and I’m slow to make new ones.",
            "I’m full of inspiring & cautionary tales from my military experience relevant to almost every combat situation.",
            "I can stare down a hell hound without flinching.",
            "I enjoy being strong and like breaking things.",
            "I have a crude sense of humor.",
            "I face problems head-on.A simple, direct solution is the best path to success."
        };
        public static string[] Ideal { get; set; } =
        {
            "Greater Good. Our lot is to lay down our lives in defense of others. (Good)",
            "Responsibility. I do what I must and obey just authority. (Lawful)",
            "Independence. When people follow orders blindly, they embrace a kind of tyranny. (Chaotic)",
            "Might. In life as in war, the stronger force wins. (Evil)",
            "Live and Let Live. Ideals aren’t worth killing over or going to war for. (Neutral)",
            "Nation. My city, nation, or people are all that matter. (Any)"
        };
        public static string[] Bond { get; set; } =
        {
            "I would still lay down my life for the people I served with.",
            "Someone saved my life on the battlefield.To this day, I will never leave a friend behind.",
            "My honor is my life.",
            "I’ll never forget the crushing defeat my company suffered or the enemies who dealt it.",
            "Those who fight beside me are those worth dying for.",
            "I fight for those who cannot fight for themselves."
        };
        public static string[] Flaw { get; set; } = 
        {
            "The monstrous enemy we faced in battle still leaves me quivering with fear.",
            "I have little respect for anyone who is not a proven warrior.",
            "I made a terrible mistake in battle cost many lives - and I would do anything to keep that mistake secret.",
            "My hatred of my enemies is blind and unreasoning.",
            "I obey the law, even if the law causes misery.",
            "I’d rather eat my armor than admit when I’m wrong."
        };
        public string[] Specialty { get; set; } =
        {
            "Officer",
            "Scout",
            "Infantry",
            "Cavalry",
            "Healer",
            "Quartermaster",
            "Standard bearer",
            "Support staff(cook, blacksmith, or the like)"
        };
        public static void AddStatics(Character character)
        {
            Console.WriteLine("During your time as a soldier you had a specific role to play in your unit or army.");
            Soldier soldier = new Soldier();
            int specialtyIndex = Prompts.BackgroundPrompts("specialty", soldier.Specialty);
            character.Specialty = soldier.Specialty[specialtyIndex];

            Console.WriteLine("Pick 1 or 2 to add to your equipment");
            //CLIHelper.Print2Choices("Bone dice", "Deck of cards");
            //int gamingchoice = CLIHelper.GetChoiceFromPair("", "");
            int gamingChoice = CLIHelper.GetChoiceFromPair("Bone dice", "Deck of cards");

            if (gamingChoice == 1)
            {
                character.Equipment.Add("Bone dice");
            }
            else
            {
                character.Equipment.Add("Deck of cards");
            }

            var trophyExamples = new List<string>() { "Dagger", "Broken blade", "Piece of a banner" };
            Console.WriteLine("Soldiers get a trophy taken from a fallen enemy as a part of their equipment. Pick an option to determine it.");
            CLIHelper.Print3Choices("See a list of examples to pick from", "Leave it as 'Trophy taken from a fallen enemy'.", "Write-in your own trophy.");
            int trophyChoice = CLIHelper.GetNumberInRange(1, 3);

            if (trophyChoice == 1)
            {
                string trophy = CLIHelper.PrintChoices(trophyExamples);
                character.Equipment.Add(trophy + " from a fallen enemy");
            }
            else if (trophyChoice == 2)
            {

                character.Equipment.Add("Trophy taken from a fallen enemy");
            }
            else
            {
                string trophy = Console.ReadLine().ToLower().Trim();
                trophy = CLIHelper.CapitalizeFirstLetter(trophy);
                character.Equipment.Add(trophy);
            }

            character.SkillProficiencies.Add("Athletics");
            character.SkillProficiencies.Add("Intimidation");
            string msg = "Pick a gaming set";
            string game = CLIHelper.GetNew(Options.GamingSets, character.ToolProficiencies, msg);
            character.ToolProficiencies.Add(game);
            character.ToolProficiencies.Add("Vehicles(land)");
            character.Equipment.Add("Common clothes");
            character.Equipment.Add("Insignia of rank");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 15;
            character.BackgroundFeature = "Military Rank: soldiers loyal to your former military organization still recognize your authority, deferring to you if they are a lower rank." +
                "\n     You can exert your influence over other soldiers and requisition simple equipment or horses for temporary use. You can usually gain access" +
                "\n     to friendly military encampments/fortresses.";
        }
    }
}
