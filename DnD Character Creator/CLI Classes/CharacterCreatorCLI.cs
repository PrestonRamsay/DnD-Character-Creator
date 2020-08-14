using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.CLI_Classes;
using DnD_Character_Creator.Helper_Classes;
using DnD_Character_Creator.Races;
using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("\nWelcome, hit enter to continue");
            Console.ReadLine();
        }
        public void RunAddStats(Character character)
        {
            List<int> stats = Stats.FindStats();
            var statsDisplay = new Stats();
            character = statsDisplay.AssignStats(character, stats);
            Console.WriteLine("Select an option based on your DM's preferences:");
            CLIHelper.Print2Choices("Stats will max at 20", "There will not be a max for stats");
            int input = CLIHelper.GetNumberInRange(1, 2);

            if (input == 2)
            {
                character.StatMax = false;
            }

            Console.WriteLine("\nYou've finished your character's stats!\n");
        }
        public void RunAddRace(Character character)
        {
            string raceString = Prompts.PickOption("race", Options.Races);
            character.ChosenRace = raceString;
            var raceObject = new Race();

            if (raceString == "Dragonborn")
            {
                raceObject = Race.Dragonborn();
            }
            else if (raceString == "Hill dwarf")
            {
                raceObject = Race.HillDwarf();
            }
            else if (raceString == "Mountain dwarf")
            {
                raceObject = Race.MountainDwarf();
            }
            else if (raceString == "Drow")
            {
                raceObject = Race.Drow();
            }
            else if (raceString == "High elf")
            {
                raceObject = Race.HighElf();
            }
            else if (raceString == "Wood elf")
            {
                raceObject = Race.WoodElf();
            }
            else if (raceString == "Forest gnome")
            {
                raceObject = Race.ForestGnome();
            }
            else if (raceString == "Rock gnome")
            {
                raceObject = Race.RockGnome();
            }
            else if (raceString == "Half-elf")
            {
                raceObject = Race.HalfElf();
            }
            else if (raceString == "Half-orc")
            {
                raceObject = Race.HalfOrc();
            }
            else if (raceString == "Lightfoot halfling")
            {
                raceObject = Race.LightfootHalfling();
            }
            else if (raceString == "Stout halfling")
            {
                raceObject = Race.StoutHalfling();
            }
            else if (raceString == "Variant human")
            {
                raceObject = Race.VariantHuman();
            }
            else if (raceString == "Human")
            {
                raceObject = Race.Human();
            }
            else if (raceString == "Tiefling")
            {
                 raceObject = Race.Tiefling();
            }

            Console.Write("\nPick an alignment from: ");
            foreach (string alignment in raceObject.Alignment)
            {
                Console.Write(alignment + "  ");
            }
            character.Alignment = CLIHelper.GetStringInList(raceObject.Alignment).ToUpper();
            Console.WriteLine();

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

            Console.Clear();
            Console.WriteLine("\nYou've finished adding your race!\n");
        }
        public void RunAddBackground(Character character)
        {            
            string backgroundString = Prompts.PickOption("background", Options.Backgrounds);
            character.ChosenBackground = backgroundString;
            var backgroundObject = new Background();

            if (backgroundString == "Acolyte")
            {
                backgroundObject = Background.Acolyte();
            }
            else if (backgroundString == "Charltan")
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
            else if (backgroundString == "Criminal")
            {
                backgroundObject = Background.Criminal();
            }
            else if (backgroundString == "Entertainer")
            {
                backgroundObject = Background.Entertainer();
                Console.WriteLine("A good entertainer is versatile, spicing things up every performance with a variety of different routines." +
                    "\nYou can have up to 3 routines that define your expertise. Enter a number(1-3) to decide how many routines you have.");
                int routines = CLIHelper.GetNumberInRange(1, 3);
                for (int i = 0; i < routines; i++)
                {
                    int routineIndex = Prompts.BackgroundPrompts("routine", backgroundObject.Routine);
                    character.Routines.Add(backgroundObject.Routine[routineIndex]);
                }
            }
            else if (backgroundString == "Folk hero")
            {
                backgroundObject = Background.FolkHero();
                Console.WriteLine("You previously lived a simple life, but something happened that set you on a different path and marked you for greatness.");
                int eventIndex = Prompts.BackgroundPrompts("defining event", backgroundObject.DefiningEvent);
                character.DefiningEvent = backgroundObject.DefiningEvent[eventIndex];
            }
            else if (backgroundString == "Guild artisan")
            {
                backgroundObject = Background.GuildArtisan();
                Console.WriteLine("Guilds are groups of several artisans who practice the same trade.");
                int businessIndex = Prompts.BackgroundPrompts("nature of your guild business", backgroundObject.GuildBusiness);
                character.GuildBusiness = backgroundObject.GuildBusiness[businessIndex];
            }
            else if (backgroundString == "Hermit")
            {
                backgroundObject = Background.Hermit();
                Console.WriteLine("What was the reason for your isolation? What changed allowing you to end your solitude?");
                int seclusionIndex = Prompts.BackgroundPrompts("nature of your seclusion", backgroundObject.LifeOfSeclusion);
                character.LifeOfSeclusion = backgroundObject.LifeOfSeclusion[seclusionIndex];
            }
            else if (backgroundString == "Noble")
            {
                backgroundObject = Background.Noble();
            }
            else if (backgroundString == "Outlander")
            {
                backgroundObject = Background.Outlander();
                Console.WriteLine("What was your occupation during your wild in the wild?");
                int originIndex = Prompts.BackgroundPrompts("origin", backgroundObject.Origin);
                character.Origin = backgroundObject.Origin[originIndex];
            }
            else if (backgroundString == "Sage")
            {
                backgroundObject = Background.Sage();
            }
            else if (backgroundString == "Sailor")
            {
                backgroundObject = Background.Sailor();
            }
            else if (backgroundString == "Soldier")
            {
                backgroundObject = Background.Soldier();
            }
            else if (backgroundString == "Urchin")
            {
                backgroundObject = Background.Urchin();
            }

            if (backgroundString == "Criminal" || backgroundString == "Sage" || backgroundString == "Soldier")
            {
                if (backgroundString == "Criminal")
                {
                    Console.WriteLine("There are many kinds of criminals, but every criminal has a preference for certain kinds of crime.");
                }
                else if (backgroundString == "Sage")
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

            Console.Clear();
            Console.WriteLine("\nYou've finished adding your background!\n");
        }
        public void RunGetLvl(Character character)
        {
            Console.WriteLine("Pick the level your want your character to be. Must be between 1 and 20.");
            int level = CLIHelper.GetNumberInRange(1, 20);
            character.Lvl = level;
            var xp = new XPDecider(level);
            xp.SetXP(character);

            //if (character.ChosenRace == "Drow")
            //{
            //    if (level >= 3)
            //    {
            //        character.Spells.Add(1, "Faerie Fire - 1/day, use Cha to cast");
            //    }
            //    if (level >= 5)
            //    {
            //        character.Spells.Add(2, "Darkness - 1/day, use Cha to cast");
            //    }
            //}
            //if (character.ChosenRace == "Tiefling")
            //{
            //    if (level >= 3)
            //    {
            //        character.Spells.Add(1, "Charm Person - 1/long rest, use Cha to cast");
            //    }
            //    if (level >= 5)
            //    {
            //        character.Spells.Add(2, "Entrall - 1/long rest, use Cha to cast");
            //    }
            //}
        }
        public void RunAddClass(Character character)
        {
            string classString = Prompts.PickOption("class", Options.Classes);
            character.ChosenClass = classString;
            var classObject = new CharacterClass(character.Lvl);

            if (classString == "Barbarian")
            {
                classObject = CharacterClass.Barbarian(character);
            }
            if (classString == "Bard" || classString == "Cleric" || classString == "Druid" || classString == "Sorcerer" || classString == "Warlock" || classString == "Wizard")
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

            AddClass.DetermineHP(character, classObject);
            AddClass.ModifySkills(character);
            AddClass.AddProficiencies(character, classObject);
            AddClass.ClassSpecifics(character, classObject);
            AddClass.AddEquipment(character, classObject);

            Console.Clear();
            Console.WriteLine("\nYou've finished adding your character's class!\n");
        }
        public void PrintCharacter(Character character)
        {
            PickHolySymbol(character);
            character.Name = CLIHelper.GetString("Enter your character's name here:");
            character.Deity = CLIHelper.GetString("Enter the name of your deity here:");
            string height = CLIHelper.ConvertHeight(character.Height);
            string saves = ListConcatenator(character.Saves);
            string lang = ListConcatenator(character.Languages);
            string profs = ListConcatenator(character.Proficiencies);
            string toolProfs = ListConcatenator(character.ToolProficiencies);
            string additionalBackgroundInfo = WriteAdditionalBackgroundProperty(character);

            Console.Clear();
            Console.WriteLine($"Name: {character.Name}           Height: {height}             Class: {character.ChosenClass}");
            Console.WriteLine($"Age: {character.Age}                Weight: {character.Weight} lbs.              Level: {character.Lvl}");
            Console.WriteLine($"Race: {character.ChosenRace}                Deity: {character.Deity}                GP: {character.GP}");
            Console.WriteLine($"Alignment: {character.Alignment}                Speed: {character.Speed}                XP: {character.XP}");
            if (character.ChosenRace == "Dragonborn")
            {
                Console.Write($"Dragon color: {character.DragonColor}       ");
            }
            Console.WriteLine($"Background: {character.ChosenBackground}        Vision: {character.Vision}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Str: {character.Str} + {character.StrMod}| Init: {character.Init}");
            Console.WriteLine($"Dex: {character.Dex} + {character.DexMod}| Proficiency Bonus + {character.ProficiencyBonus}");
            Console.WriteLine($"Con: {character.Con} + {character.ConMod}| AC: {character.AC} + Armor Bonuses");
            Console.WriteLine($"Int: {character.Int} + {character.IntMod}| HP: {character.HP}");
            Console.WriteLine($"Wis: {character.Wis} + {character.WisMod}| Saves: {saves}");
            Console.WriteLine($"Cha: {character.Cha} + {character.ChaMod}");
            Console.WriteLine($"Languages: {lang}");
            Console.WriteLine("\nSkills:");
            Console.WriteLine("---------------------");
            foreach (string skill in character.Skills.Keys)
            {
                Console.WriteLine($"{skill} + {character.Skills[skill]}");
            }
            Console.WriteLine($"\nPersonality Trait: {character.PersonalityTrait}");
            Console.WriteLine($"Ideal: {character.Ideal}");
            Console.WriteLine($"Bond: {character.Bond}");
            Console.WriteLine($"Flaw: {character.Flaw}");
            Console.WriteLine($"Background Feature: {character.BackgroundFeature}");
            Console.WriteLine($"{additionalBackgroundInfo}");
            Console.WriteLine($"\nRacial Traits:");
            Console.WriteLine("---------------------");
            foreach (string trait in character.RacialTraits)
            {
                Console.WriteLine($"{trait}");
            }
            Console.WriteLine($"\nFeats:");
            Console.WriteLine("---------------------");
            foreach (string feat in character.Feats)
            {
                Console.WriteLine($"{feat}");
            }
            Console.WriteLine("\nProficiencies:");
            Console.WriteLine("---------------------");
            Console.WriteLine($"{profs}");
            Console.WriteLine("\nTool Proficiencies:");
            Console.WriteLine("---------------------");
            Console.WriteLine($"{toolProfs}");
            Console.WriteLine("\nInventory:");
            Console.WriteLine("---------------------");
            foreach (string item in character.Equipment)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("\nClass Features:");
            Console.WriteLine("---------------------");
            foreach (string feature in character.ClassFeatures.Keys)
            {
                Console.WriteLine($"{feature}: {character.ClassFeatures[feature]}");
            }
            Console.WriteLine("\nSpells:");
            Console.WriteLine("---------------------");
            //foreach (int spellLvl in character.Spells.Keys)
            //{
            //    Console.WriteLine();
            //}
            Console.WriteLine("\nYou've finished creating your character! Scroll up to see all the data");
        }
        public void WriteCharacterToDocument(Character character)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string characterSheet = "Character.txt";
            string fullPath = Path.Combine(currentDirectory, characterSheet);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                string height = CLIHelper.ConvertHeight(character.Height);
                string saves = ListConcatenator(character.Saves);
                string lang = ListConcatenator(character.Languages);
                string profs = ListConcatenator(character.Proficiencies);
                string toolProfs = ListConcatenator(character.ToolProficiencies);
                string additionalBackgroundInfo = WriteAdditionalBackgroundProperty(character);

                sw.WriteLine($"Name: {character.Name}           Height: {height}             Class: {character.ChosenClass}");
                sw.WriteLine($"Age: {character.Age}                Weight: {character.Weight} lbs.              Level: {character.Lvl}");
                sw.WriteLine($"Race: {character.ChosenRace}                Deity: {character.Deity}                GP: {character.GP}");
                sw.WriteLine($"Alignment: {character.Alignment}                Speed: {character.Speed}                XP: {character.XP}");
                if (character.ChosenRace == "Dragonborn")
                {
                    sw.Write($"Dragon color: {character.DragonColor}       ");
                }
                sw.WriteLine($"Background: {character.ChosenBackground}        Vision: {character.Vision}");
                sw.WriteLine("----------------------------------------------------------------------------------------------------------------");
                sw.WriteLine($"Str: {character.Str} + {character.StrMod}| Init: {character.Init}");
                sw.WriteLine($"Dex: {character.Dex} + {character.DexMod}| Proficiency Bonus + {character.ProficiencyBonus}");
                sw.WriteLine($"Con: {character.Con} + {character.ConMod}| AC: {character.AC} + Armor Bonuses");
                sw.WriteLine($"Int: {character.Int} + {character.IntMod}| HP: {character.HP}");
                sw.WriteLine($"Wis: {character.Wis} + {character.WisMod}| Saves: {saves}");
                sw.WriteLine($"Cha: {character.Cha} + {character.ChaMod}");
                sw.WriteLine($"Languages: {lang}");
                sw.WriteLine("\nSkills:");
                sw.WriteLine("---------------------");
                foreach (string skill in character.Skills.Keys)
                {
                    sw.WriteLine($"{skill} + {character.Skills[skill]}");
                }
                sw.WriteLine($"\nPersonality Trait: {character.PersonalityTrait}");
                sw.WriteLine($"Ideal: {character.Ideal}");
                sw.WriteLine($"Bond: {character.Bond}");
                sw.WriteLine($"Flaw: {character.Flaw}");
                sw.WriteLine($"Background Feature: {character.BackgroundFeature}");
                sw.WriteLine($"{additionalBackgroundInfo}");
                sw.WriteLine($"\nRacial Traits:");
                sw.WriteLine("---------------------");
                foreach (string trait in character.RacialTraits)
                {
                    sw.WriteLine($"{trait}");
                }
                sw.WriteLine($"\nFeats:");
                sw.WriteLine("---------------------");
                foreach (string feat in character.Feats)
                {
                    sw.WriteLine($"{feat}");
                }
                sw.WriteLine("\nProficiencies:");
                sw.WriteLine("---------------------");
                sw.WriteLine($"{profs}");
                sw.WriteLine("\nTool Proficiencies:");
                sw.WriteLine("---------------------");
                sw.WriteLine($"{toolProfs}");
                sw.WriteLine("\nInventory:");
                sw.WriteLine("---------------------");
                foreach (string item in character.Equipment)
                {
                    sw.WriteLine($"{item}");
                }
                sw.WriteLine("\nClass Features:");
                sw.WriteLine("---------------------");
                foreach (string feature in character.ClassFeatures.Keys)
                {
                    sw.WriteLine($"{feature}: {character.ClassFeatures[feature]}");
                }
                sw.WriteLine("\nSpells:");
                sw.WriteLine("---------------------");
                //foreach (int spellLvl in character.Spells.Keys)
                //{
                //    sw.WriteLine();
                //}
            }
        }
        public bool FinalPrompt()
        {
            bool returnBool = true;
            string input = CLIHelper.GetString("\nDo you want to create another character? If yes enter 'yes' if not hit any key.");

            if (input == "Yes")
            {
                returnBool = false;
            }

            return returnBool;
        }
        public static string ListConcatenator(List<string> list)
        {
            string returnString = "";

            if (list.Count > 0)
            {
                returnString = list[0];

                for (int i = 1; i < list.Count; i++)
                {
                    returnString += $", {list[i]}";
                }
            }            
            
            return returnString;
        }
        public static string WriteAdditionalBackgroundProperty(Character character)
        {
            string backgroundString = character.ChosenBackground;
            string returnString = "";
            
            if (backgroundString == "charltan")
            {
                returnString = $"Favorite Scam: {character.FavoriteScam}";
            }
            else if (backgroundString == "criminal")
            {
                returnString = $"Specialty: {character.Specialty}";
            }
            else if (backgroundString == "entertainer")
            {
                string routines = ListConcatenator(character.Routines);
               returnString = $"Routines: {routines}";
            }
            else if (backgroundString == "folk hero")
            {
                returnString = $"Defining Event: {character.DefiningEvent}";
            }
            else if (backgroundString == "guild artisan")
            {
                returnString = $"Guild Business: {character.GuildBusiness}";
            }
            else if (backgroundString == "hermit")
            {
                returnString = $"Life of Seclusion: {character.LifeOfSeclusion}";
            }
            else if (backgroundString == "outlander")
            {
                returnString = $"Origin: {character.Origin}";
            }
            else if (backgroundString == "sage")
            {
                returnString = $"Specialty: {character.Specialty}";
            }
            else if (backgroundString == "soldier")
            {
                returnString = $"Specialty: {character.Specialty}";
            }

            return returnString;
        }
        public static void PickHolySymbol(Character character)
        {
            if (character.Equipment.Contains("Holy symbol"))
            {
                character.Equipment.Remove("Holy symbol");
                Console.WriteLine("Pick a holy symbol from:");
                CLIHelper.Print3Choices("Amulet", "Emblem", "Reliquary");
                int input = CLIHelper.GetNumberInRange(1, 3);

                if (input == 1)
                {
                    character.Equipment.Add(Options.HolySymbols[0]);
                }
                else if (input == 2)
                {
                    character.Equipment.Add(Options.HolySymbols[1]);
                }
                else
                {
                    character.Equipment.Add(Options.HolySymbols[2]);
                }
            }
        }
    }
}
