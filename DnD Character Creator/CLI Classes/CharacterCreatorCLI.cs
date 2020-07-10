using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.CLI_Classes;
using DnD_Character_Creator.Helper_Classes;
using DnD_Character_Creator.Races;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DnD_Character_Creator
{
    public class CharacterCreatorCLI
    {
        public void PrintHeader()
        {
            Console.WriteLine(@"                              ____    ___    ____  ");
            Console.WriteLine(@"                             |  _ \  ( _ )  |  _ \ ");
            Console.WriteLine(@"                             | | | | / _ \/\| | | |");
            Console.WriteLine(@"                             | |_| |( (_>  <| |_| |");
            Console.WriteLine(@"                             |____/  \___/\/|____/ ");
            Console.WriteLine(@"  ____ _                          _               ____                _             ");
            Console.WriteLine(@" / ___| |__   __ _ _ __ __ _  ___| |_ ___ _ __   / ___|_ __ ___  __ _| |_ ___  _ __ ");
            Console.WriteLine(@"| |   | '_ \ / _` | '__/ _` |/ __| __/ _ \ '__| | |   | '__/ _ \/ _` | __/ _ \| '__|");
            Console.WriteLine(@"| |___| | | | (_| | | | (_| | (__| ||  __/ |    | |___| | |  __/ (_| | || (_) | |   ");
            Console.WriteLine(@" \____|_| |_|\__,_|_|  \__,_|\___|\__\___|_|     \____|_|  \___|\__,_|\__\___/|_|   ");
            Console.WriteLine("\n Welcome, hit enter to continue");
            CLIHelper.GetString();
        }
        public void RunAddStats(Character character)
        {
            List<int> stats = Stats.FindStats();
            Stats statsDisplay = new Stats();
            character = statsDisplay.AssignStats(character, stats);
        }
        public void RunAddRace(Character character)
        {
            bool gettingRace = true;
            Race newRace = new Race();

            while (gettingRace)
            {
                string race = Prompts.PickOption("race", Options.Races);
                if (Race.IsValid(race))
                {
                    newRace = Race.AllRaces[race];
                    character.ChosenRace = race;
                    gettingRace = false;
                }
                else
                {
                    Console.WriteLine("Your entry does not appear to be among the racial options. Try again.");
                }
            }

            Console.Write("\nPick an alignment from: ");
            foreach (string alignment in newRace.Alignment)
            {
                Console.Write(alignment + "  ");
            }
            character.Alignment = CLIHelper.GetStringInList(newRace.Alignment);

            if (newRace.MaxAgeEnd > 150)
            {
                Console.WriteLine($"Enter your age. This race usually lives for " +
                    $"{newRace.MaxAgeStart}-{newRace.MaxAgeEnd} years and is considered an adult at the age of " +
                    $"{newRace.AdultAge}");
            }
            else
            {
                Console.WriteLine($"Enter your age. This race usually lives for {newRace.MaxAgeStart} years" +
                    $" and is considered an adult at the age of {newRace.AdultAge}");
            }
            AddRace.RacialSpecifics(character, newRace);
            Console.WriteLine($"Pick a height between {CLIHelper.ConvertHeight(newRace.MinHeight)} and " +
                $"{CLIHelper.ConvertHeight(newRace.MaxHeight)}. Format should be: (Feet)'(Inches)\".");
            AddRace.AddHeight(character, newRace);
            Console.WriteLine($"Pick a weight between {newRace.MinWeight}lbs and {newRace.MaxWeight}lbs.");
            AddRace.AddWeight(character, newRace);
            AddRace.AddLanguages(character, newRace);
        }
        public void RunAddBackground(Character character)
        {
            bool gettingBackground = true;
            Background backgroundObject = new Background();
            string backgroundAsString = "";

            while (gettingBackground)
            {
                backgroundAsString = Prompts.PickOption("background", Options.Backgrounds);
                if (Background.IsValid(backgroundAsString))
                {
                    backgroundObject = Background.AllBackgrounds[backgroundAsString];
                    character.ChosenBackground = backgroundAsString;
                    gettingBackground = false;
                }
                else
                {
                    Console.WriteLine("Your entry does not appear to be among the background options. Try again.");
                }
            }
            AddBackground.AddProficiencies(character, backgroundObject);
            AddBackground.AddLanguages(character, backgroundObject);
            AddBackground.AddEquipment(character, backgroundObject);

            if (backgroundAsString == "charltan")
            {
                Console.WriteLine("Every charltan has an angle he/she uses in preference to other schemes.");
                int scamIndex = Prompts.BackgroundPrompts("favorite scam", backgroundObject.FavoriteScam);
                character.FavoriteScam = backgroundObject.FavoriteScam[scamIndex];

                if (scamIndex == 0)
                {
                    character.Equipment.Add("Set of weighted dice");
                }
                else if (scamIndex == 2)
                {
                    character.Equipment.Add("Signet ring of imaginary duke");
                }
                else if (scamIndex == 4)
                {
                    character.Equipment.Add("Deck of marked cards");
                }
                else if (scamIndex == 5)
                {
                    character.Equipment.Add("10 stoppered bottles of colored liquid");
                }
            }
            if (backgroundAsString == "criminal" || backgroundAsString == "sage" || backgroundAsString == "soldier")
            {
                if (backgroundAsString == "criminal")
                {
                    Console.WriteLine("There are many kinds of criminals, but every criminal has a preference for certain kinds of crime.");
                }
                else if (backgroundAsString == "sage")
                {
                    Console.WriteLine("What was the nature of your scholarly training?");
                }
                else
                {
                    Console.WriteLine("During your time as a soldier you had a specific role to play in your unit or army.");
                }
                
                int specialtyIndex = Prompts.BackgroundPrompts("specialty", backgroundObject.Specialty);
                character.Specialty = backgroundObject.Specialty[specialtyIndex];
            }
            if (backgroundAsString == "entertainer")
            {
                Console.WriteLine("A good entertainer is versatile, spicing things up every performance with a variety of different routines." +
                    "\nYou can have up to 3 routines that define your expertise. Enter a number(1-3) to decide how many routines you have.");
                int routines = CLIHelper.GetNumberInRange(1, 3);
                for (int i = 0; i < routines; i++)
                {
                    int routineIndex = Prompts.BackgroundPrompts("routine", backgroundObject.Routine);
                    character.Routine = backgroundObject.Routine[routineIndex];
                }
            }
            if (backgroundAsString == "folk hero")
            {
                Console.WriteLine("You previously lived a simple life, but something happened that set you on a different path and marked you for greatness.");
                int eventIndex = Prompts.BackgroundPrompts("defining event", backgroundObject.DefiningEvent);
                character.DefiningEvent = backgroundObject.DefiningEvent[eventIndex];
            }
            if (backgroundAsString == "guild artisan")
            {
                Console.WriteLine("Guilds are groups of several artisans who practice the same trade.");
                int businessIndex = Prompts.BackgroundPrompts("nature of your guild business", backgroundObject.GuildBusiness);
                character.GuildBusiness = backgroundObject.GuildBusiness[businessIndex];
            }
            if (backgroundAsString == "hermit")
            {
                Console.WriteLine("What was the reason for your isolation? What changed allowing you to end your solitude?");
                int seclusionIndex = Prompts.BackgroundPrompts("nature of your seclusion", backgroundObject.LifeOfSeclusion);
                character.LifeOfSeclusion = backgroundObject.LifeOfSeclusion[seclusionIndex];
            }
            if (backgroundAsString == "outlander")
            {
                Console.WriteLine("What was your occupation during your wild in the wild?");
                int originIndex = Prompts.BackgroundPrompts("origin", backgroundObject.Origin);
                character.Origin = backgroundObject.Origin[originIndex];
            }

            Console.WriteLine("Every background has a personality trait, an ideal, a bond and a flaw." +
                "\nFor each you can either pick one from a list or you can roll it randomly.");
            AddBackground.BackgroundSpecifics(character, backgroundObject);
        }
        public Character RunGetLvl(Character character)
        {
            Console.WriteLine("Pick the level your want your character to be. Must be between 1 and 20.");
            int level = CLIHelper.GetNumberInRange(1, 20);

            if (character.ChosenRace == "drow")
            {
                if (level >= 3)
                {
                    character.Spells.Add("(1st)Faerie Fire - 1/day, use Cha to cast");
                }
                if (level >= 5)
                {
                    character.Spells.Add("(2nd)Darkness - 1/day, use Cha to cast");
                }
            }
            if (character.ChosenRace == "tiefling")
            {
                if (level >= 3)
                {
                    character.Spells.Add("(1st)Charm Person - 1/long rest, use Cha to cast");
                }
                if (level >= 5)
                {
                    character.Spells.Add("(2nd)Entrall - 1/long rest, use Cha to cast");
                }
            }

            return character;
        }
        public void RunAddClass(Character character)
        {
            List<string> classOptions = new List<string> { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk",
                "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };

            Console.WriteLine(Prompts.Prompt("class"));
            string characterClass = CLIHelper.GetString();
            if (characterClass == "see options")
            {
                Console.Clear();
                foreach (string option in classOptions)
                {
                    Console.WriteLine($"{option}");
                }
                Console.WriteLine($"\n{Prompts.Prompt2("class")}");
                characterClass = CLIHelper.GetString().ToLower();
            }
        }
    }
}
