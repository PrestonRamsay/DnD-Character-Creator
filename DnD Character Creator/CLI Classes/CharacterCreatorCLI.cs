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
            var statsDisplay = new Stats();
            character = statsDisplay.AssignStats(character, stats);

            Console.WriteLine("You've finished your character's stats!");
        }
        public void RunAddRace(Character character)
        {
            string raceString = Prompts.PickOption("race", Options.Races);
            character.ChosenRace = raceString;
            var raceObject = new Race();

            if (raceString == "dragonborn")
            {
                raceObject = Race.Dragonborn();
            }
            else if (raceString == "hill dwarf")
            {
                raceObject = Race.HillDwarf();
            }
            else if (raceString == "mountain dwarf")
            {
                raceObject = Race.MountainDwarf();
            }
            else if (raceString == "drow")
            {
                raceObject = Race.Drow();
            }
            else if (raceString == "high elf")
            {
                raceObject = Race.HighElf();
            }
            else if (raceString == "wood elf")
            {
                raceObject = Race.WoodElf();
            }
            else if (raceString == "forest gnome")
            {
                raceObject = Race.ForestGnome();
            }
            else if (raceString == "rock gnome")
            {
                raceObject = Race.RockGnome();
            }
            else if (raceString == "half-elf")
            {
                raceObject = Race.HalfElf();
            }
            else if (raceString == "half-orc")
            {
                raceObject = Race.HalfOrc();
            }
            else if (raceString == "lightfoot halfling")
            {
                raceObject = Race.LightfootHalfling();
            }
            else if (raceString == "stout halfling")
            {
                raceObject = Race.StoutHalfling();
            }
            else if (raceString == "variant human")
            {
                raceObject = Race.VariantHuman();
            }
            else if (raceString == "human")
            {
                raceObject = Race.Human();
            }
            else if (raceString == "tiefling")
            {
                 raceObject = Race.Tiefling();
            }

            Console.Write("\nPick an alignment from: ");
            foreach (string alignment in raceObject.Alignment)
            {
                Console.Write(alignment + "  ");
            }
            character.Alignment = CLIHelper.GetStringInList(raceObject.Alignment);

            if (raceObject.MaxAgeEnd > 150)
            {
                Console.WriteLine($"Enter your age. This race usually lives for " +
                    $"{raceObject.MaxAgeStart}-{raceObject.MaxAgeEnd} years and is considered an adult at the age of " +
                    $"{raceObject.AdultAge}.");
            }
            else
            {
                Console.WriteLine($"Enter your age. This race usually lives for {raceObject.MaxAgeStart} years" +
                    $" and is considered an adult at the age of {raceObject.AdultAge}.");
            }
            AddRace.RacialSpecifics(character, raceObject);
            Console.WriteLine($"Pick a height between {CLIHelper.ConvertHeight(raceObject.MinHeight)} and " +
                $"{CLIHelper.ConvertHeight(raceObject.MaxHeight)}. Format should be: (Feet)'(Inches)\".");
            AddRace.AddHeight(character, raceObject);
            Console.WriteLine($"Pick a weight between {raceObject.MinWeight}lbs and {raceObject.MaxWeight}lbs.");
            AddRace.AddWeight(character, raceObject);
            AddRace.AddLanguages(character, raceObject);

            Console.WriteLine("You've finished adding your race!");
        }
        public void RunAddBackground(Character character)
        {            
            string backgroundString = Prompts.PickOption("background", Options.Backgrounds);
            character.ChosenBackground = backgroundString;
            var backgroundObject = new Background();

            if (backgroundString == "acolyte")
            {
                backgroundObject = Background.Acolyte();
            }
            else if (backgroundString == "charltan")
            {
                backgroundObject = Background.Charltan();
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
            else if (backgroundString == "criminal")
            {
                backgroundObject = Background.Criminal();
            }
            else if (backgroundString == "entertainer")
            {
                backgroundObject = Background.Entertainer();
                Console.WriteLine("A good entertainer is versatile, spicing things up every performance with a variety of different routines." +
                    "\nYou can have up to 3 routines that define your expertise. Enter a number(1-3) to decide how many routines you have.");
                int routines = CLIHelper.GetNumberInRange(1, 3);
                for (int i = 0; i < routines; i++)
                {
                    int routineIndex = Prompts.BackgroundPrompts("routine", backgroundObject.Routine);
                    character.Routine = backgroundObject.Routine[routineIndex];
                }
            }
            else if (backgroundString == "folk hero")
            {
                backgroundObject = Background.FolkHero();
                Console.WriteLine("You previously lived a simple life, but something happened that set you on a different path and marked you for greatness.");
                int eventIndex = Prompts.BackgroundPrompts("defining event", backgroundObject.DefiningEvent);
                character.DefiningEvent = backgroundObject.DefiningEvent[eventIndex];
            }
            else if (backgroundString == "guild artisan")
            {
                backgroundObject = Background.GuildArtisan();
                Console.WriteLine("Guilds are groups of several artisans who practice the same trade.");
                int businessIndex = Prompts.BackgroundPrompts("nature of your guild business", backgroundObject.GuildBusiness);
                character.GuildBusiness = backgroundObject.GuildBusiness[businessIndex];
            }
            else if (backgroundString == "hermit")
            {
                backgroundObject = Background.Hermit();
                Console.WriteLine("What was the reason for your isolation? What changed allowing you to end your solitude?");
                int seclusionIndex = Prompts.BackgroundPrompts("nature of your seclusion", backgroundObject.LifeOfSeclusion);
                character.LifeOfSeclusion = backgroundObject.LifeOfSeclusion[seclusionIndex];
            }
            else if (backgroundString == "noble")
            {
                backgroundObject = Background.Noble();
            }
            else if (backgroundString == "outlander")
            {
                backgroundObject = Background.Outlander();
                Console.WriteLine("What was your occupation during your wild in the wild?");
                int originIndex = Prompts.BackgroundPrompts("origin", backgroundObject.Origin);
                character.Origin = backgroundObject.Origin[originIndex];
            }
            else if (backgroundString == "sage")
            {
                backgroundObject = Background.Sage();
            }
            else if (backgroundString == "sailor")
            {
                backgroundObject = Background.Sailor();
            }
            else if (backgroundString == "soldier")
            {
                backgroundObject = Background.Soldier();
            }
            else if (backgroundString == "urchin")
            {
                backgroundObject = Background.Urchin();
            }

            if (backgroundString == "criminal" || backgroundString == "sage" || backgroundString == "soldier")
            {
                if (backgroundString == "criminal")
                {
                    Console.WriteLine("There are many kinds of criminals, but every criminal has a preference for certain kinds of crime.");
                }
                else if (backgroundString == "sage")
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

            AddBackground.AddProficiencies(character, backgroundObject);
            AddBackground.AddLanguages(character, backgroundObject);
            AddBackground.AddEquipment(character, backgroundObject);

            Console.WriteLine("Every background has a personality trait, an ideal, a bond and a flaw." +
                "\nFor each you can either pick one from a list or you can roll it randomly.");
            AddBackground.BackgroundSpecifics(character, backgroundObject);
        }
        public Character RunGetLvl(Character character)
        {
            Console.WriteLine("Pick the level your want your character to be. Must be between 1 and 20.");
            int level = CLIHelper.GetNumberInRange(1, 20);
            character.Lvl = level;

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
            string classString = Prompts.PickOption("class", Options.Classes);
            character.ChosenClass = classString;
            var classObject = new CharacterClass(character.Lvl);

            if (classString == "bard" || classString == "cleric" || classString == "druid" || classString == "sorcerer" || classString == "warlock" || classString == "wizard")
            {
                if (character.Lvl > 3)
                {
                    classObject.CantripsKnown++;
                }
                if (character.Lvl > 9)
                {
                    classObject.CantripsKnown++;
                }
            }
        }
    }
}
