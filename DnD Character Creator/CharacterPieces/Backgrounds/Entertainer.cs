using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Entertainer : Background
    {
        public static string[] PersonalityTrait { get; set; } =
        {
            "I know a story relevant to almost every situation.",
            "Whenever I come to a new place, I collect local rumors and spread gossip.",
            "I’m a hopeless romantic, always searching for that 'special someone.'",
            "Nobody stays angry at me or around me for long, since I can defuse any amount of tension.",
            "I love a good insult, even one directed at me.",
            "I get bitter if I’m not the center of attention.",
            "I’ll settle for nothing less than perfection.",
            "I change my mood or my mind as quickly as I change key in a song."
        };
        public static string[] Ideal { get; set; } =
        {
            "Beauty. When I perform, I make the world better than it was. (Good)",
            "Tradition. Stories/legends/songs of the past must never be forgotten, they teach us who we are. (Lawful)",
            "Creativity. The world is in need of new ideas and bold action. (Chaotic)",
            "Greed. I’m only in it for the money and fame. (Evil)",
            "People. I like seeing the smiles on people’s faces when I perform.That’s all that matters. (Neutral)",
            "Honesty. Art should reflect the soul, it should come from within and reveal who we really are. (Any)"
        };
        public static string[] Bond { get; set; } =
        {
            "My instrument is my most treasured possession, and it reminds me of someone I love.",
            "Someone stole my precious instrument, and someday I’ll get it back.",
            "I want to be famous, whatever it takes.",
            "I idolize a hero of the old tales and measure my deeds against that person’s.",
            "I will do anything to prove myself superior to my hated rival.",
            "I would do anything for the other members of my old troupe."
        };
        public static string[] Flaw { get; set; } =
        {
            "I’ll do anything to win fame and renown.",
            "I’m a sucker for a pretty face.",
            "A scandal prevents me from ever going home again. That kind of trouble seems to follow me around.",
            "I once satirized a noble who still wants my head. It was a mistake that I will likely repeat.",
            "I have trouble keeping my true feelings hidden. My sharp tongue lands me in trouble.",
            "Despite my best efforts, I am unreliable to my friends."
        };
        public static string[] Routine { get; set; } =
        {
            "Actor",
            "Dancer",
            "Fire-eater",
            "Jester",
            "Juggler",
            "Instrumentalist",
            "Poet",
            "Singer",
            "Storyteller",
            "Tumbler"
        };
        public static void AddStatics(Character character)
        {
            Console.WriteLine("You have the favor of an admirer. Pick an object to represent that by entering the number next to it.");
            CLIHelper.Print3Choices("Love letter from an admirer", "Lock of hair from an admirer", "Trinket from an admirer");
            int choice = CLIHelper.GetNumberInRange(1, 3);

            if (choice == 1)
            {
                character.Equipment.Add("Love letter from an admirer");
            }
            else if (choice == 2)
            {
                character.Equipment.Add("Lock of hair from an admirer");
            }
            else
            {
                character.Equipment.Add("Trinket from an admirer");
            }

            character.SkillProficiencies.Add("Acrobatics");
            character.SkillProficiencies.Add("Performance");
            character.ToolProficiencies.Add("Disguise Kit");

            Console.WriteLine("Would you like the Gladiator variant of the Entertainer background?");
            choice = CLIHelper.GetChoiceFromPair("Yes", "No");

            if (choice == 1)
            {
                character.ChosenBackground += "(Gladiator)";
                character.BackgroundFeature = "By Popular Demand: you can always find a place to perform that features combat for entertainment, such as an arena or fighting pit." +
                    "\n     The place you perform will provide you with free lodging and a modest/comfortable level of food (as long as you perform " +
                    "\n     each night). Your performances also make you a local figure - strangers recognize you and usually like you.";

                var weapons = new List<string> { "Dagger", "Net", "Pike", "Shortsword", "Sickle", "Spear", "Trident", "Whip" };
                string msg = "Pick a weapon to add to your inventory.";
                int index = CLIHelper.PrintChoices(msg, weapons);
                string weaponOfChoice = weapons[index];
                character.Proficiencies.Add(weaponOfChoice);
                weaponOfChoice = GetWeapon(weaponOfChoice);
                character.Equipment.Add(weaponOfChoice);

                Console.WriteLine("Suggest routines: Actor/Tumbler");
            }
            else
            {
                string pickMsg = "Pick a musical instrument you'd like to be proficient with";
                string instrument = CLIHelper.GetNew(Options.MusicalInstruments, character.ToolProficiencies, pickMsg);
                character.ToolProficiencies.Add(instrument);
                character.Equipment.Add(instrument);
                character.BackgroundFeature = "By Popular Demand: you can always find a place to perform, usually an inn or a tavern, but it could be a circus, theater or even a" +
                    "\n     noble's court. The place you perform will provide you with free lodging and a modest/comfortable level of food (as long as you perform " +
                    "\n     each night). Your performances also make you a local figure - strangers recognize you and usually like you.";
            }
            character.Equipment.Add("Costume");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 15;

            Console.WriteLine("A good entertainer is versatile, spicing things up every performance with a variety of different routines." +
                    "\n        You can have up to 3 routines that define your expertise. Enter a number(1-3) to decide how many routines you have.");
            int routines = CLIHelper.GetNumberInRange(1, 3);
            for (int i = 0; i < routines; i++)
            {
                int routineIndex = Prompts.BackgroundPrompts("routine", Routine);
                character.Routines.Add(Routine[routineIndex]);
            }
        }
        public static string GetWeapon(string weapon)
        {
            string returnWeapon = "";
            switch (weapon)
            {
                case "Dagger":
                    returnWeapon = Options.SimpleMeleeWeapons[1];
                    break;
                case "Net":
                    returnWeapon = Options.MartialRangedWeapons[5];
                    break;
                case "Pike":
                    returnWeapon = Options.MartialMeleeWeapons[10];
                    break;
                case "Shortsword":
                    returnWeapon = Options.MartialMeleeWeapons[13];
                    break;
                case "Sickle":
                    returnWeapon = Options.SimpleMeleeWeapons[8];
                    break;
                case "Spear":
                    returnWeapon = Options.SimpleMeleeWeapons[9];
                    break;
                case "Trident":
                    returnWeapon = Options.MartialMeleeWeapons[14];
                    break;
                case "Whip":
                    returnWeapon = Options.MartialMeleeWeapons[17];
                    break;
            }
            return returnWeapon;
        }
    }
}
