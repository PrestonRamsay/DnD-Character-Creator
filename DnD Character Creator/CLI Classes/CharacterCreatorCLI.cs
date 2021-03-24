using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.CLI_Classes;
using DnD_Character_Creator.Helper_Classes;
using DnD_Character_Creator.Races;
using System;
using System.Collections.Generic;
using System.IO;

namespace DnD_Character_Creator
{
    public class CharacterCreatorCLI
    {
        public Race TempRace { get; set; } = new Race();
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
        public void RunGetLvl(Character character)
        {
            Console.WriteLine("Pick the level your want your character to be. Must be between 1 and 20.");
            int lvl = CLIHelper.GetNumberInRange(1, 20);
            character.Lvl = lvl;

            character.ProficiencyBonus = 2;
            if (lvl >= 5)
            {
                character.ProficiencyBonus++;
            }
            if (lvl >= 9)
            {
                character.ProficiencyBonus++;
            }
            if (lvl >= 13)
            {
                character.ProficiencyBonus++;
            }
            if (lvl >= 17)
            {
                character.ProficiencyBonus++;
            }

            var xp = new XPDecider(lvl);
            xp.SetXP(character);
            Console.Clear();
            character.ChosenRace = Prompts.PickOption("race", Options.Races);
            if (character.ChosenRace == "Demigod")
            {
                character.DemigodDomain = Prompts.GetDemigodDomain();
            }
            Console.Clear();
            Console.WriteLine($"You've picked {character.ChosenRace}.\n");
            character.ChosenClass = Prompts.PickOption("class", Options.Classes);
            Console.Clear();
            Console.WriteLine($"You've picked {character.ChosenClass}.\n");

            Console.WriteLine("Do you want to add a Template to your character? Y/N");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                character.Template = true;
                string pickMsg = "Pick from the list of templates.";
                int index = CLIHelper.PrintChoices(pickMsg, Options.Templates);
                character.ChosenTemplate = Options.Templates[index];
                Console.Clear();
                Console.WriteLine($"You've picked {character.ChosenTemplate}.");
            }
        }
        public void RunAddStats(Character character)
        {
            Console.WriteLine("\nSelect an option based on your DM's preferences:");
            CLIHelper.Print2Choices("Stats will max at 20", "Enter stat maximum");
            int input = CLIHelper.GetNumberInRange(1, 2);

            if (input == 2)
            {
                Console.WriteLine($"Enter the max for your character's stats now");
                character.StatMax = CLIHelper.GetNumberInRange(20, 99);
            }

            List<int> stats = Stats.FindStats(character);
            var statsDisplay = new Stats();
            statsDisplay.AssignStats(character, stats);
            Console.Clear();

            var race = new Race();
            if (character.ChosenRace == "Demigod")
            {
                race = Race.DemigodStats(character.DemigodDomain);

            }
            else
            {
                race = Race.GetStats(character.ChosenRace);
            }
            Stats.RacialStats(character, race);
            if (character.Template == true)
            {
                Template template = Template.GetStats(character.ChosenTemplate);
                Stats.TemplateStats(character, template);
                character.TemplateProgression.AddRange(Options.UniversalMilestones);
            }
            Console.Write($"\nAfter adding the rest of your stat boosts, your stats are now ");
            foreach (var stat in Options.Stats)
            {
                Console.Write($"{stat}: {character.Stats[stat]}  ");
            }
            Console.WriteLine("");

            Console.WriteLine("\nDo ability score improvements? Y/N");
            string answer = Console.ReadLine().ToLower();
            Console.Clear();

            if (answer != "n")
            {
                Stats.IncreaseStatByLvl(character);
                Console.Clear();
                Console.Write($"\nYour stats are now ");
                foreach (var stat in Options.Stats)
                {
                    Console.Write($"{stat}: {character.Stats[stat]}  ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\nYou've finished your character's stats!\n");
        }
        public void RunAddRace(Character character)
        {
            Console.WriteLine($"You will now add {character.ChosenRace} traits.\n");
            var raceObject = new Race();
            if (character.ChosenRace == "Demigod")
            {
                raceObject = Race.NewRace(character);

            }
            else
            {
                raceObject = Race.NewRace(character.ChosenRace);
            }
            TempRace = raceObject;

            AddRace.RacialSpecifics(character, raceObject);
            Console.WriteLine($"Pick a height between {CLIHelper.ConvertHeight(raceObject.MinHeight)} and " +
                $"{CLIHelper.ConvertHeight(raceObject.MaxHeight)}. Format should be: (Feet)'(Inches)\".");
            AddRace.AddHeight(character, raceObject);
            Console.WriteLine($"Pick a weight between {raceObject.MinWeight}lbs and {raceObject.MaxWeight}lbs.");
            character.Weight = CLIHelper.GetNumberInRange(raceObject.MinWeight, raceObject.MaxWeight);

            Console.Write("\nPick an alignment from: ");
            foreach (string alignment in raceObject.Alignment)
            {
                Console.Write(alignment + "  ");
            }
            character.Alignment = CLIHelper.GetStringInList(raceObject.Alignment).ToUpper();
            if (character.ChosenRace == "Cambion")
            {
                if (character.Alignment == "L-E")
                {
                    character.Languages.Add("Infernal");
                }
                else if (character.Alignment == "C-E")
                {
                    character.Languages.Add("Abyssal");
                }
            }
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
            character.Age = CLIHelper.GetNumberInRange(raceObject.AdultAge, raceObject.MaxAgeStart + 50);

            AddRace.AddLanguages(character, raceObject);
            AddRace.AddSpells(character);
            AddRace.AddHigherLvlFeature(character);
            if (character.ChosenRace == "Demigod")
            {
                character.ChosenRace += $"({character.DemigodDomain})";
            }

            Console.Clear();
            Console.WriteLine("\nYou've finished adding your race!\n");
        }
        public void RunAddTemplate(Character character)
        {
            if (character.Template == true)
            {
                string templateName = character.ChosenTemplate;
                Console.WriteLine($"Because you are a/an {templateName} you can pick a new age.");
                character.Age = CLIHelper.GetNumberInRange(TempRace.AdultAge, 15000);
                Template template = Template.NewTemplate(templateName, character);
                AddTemplate.TemplateBenefits(character, template);
            }
        }
        public void RunAddBackground(Character character)
        {
            var backgroundObject = new Background();
            var backgroundFiller = new GHBackground();

            Console.WriteLine("Do you want Grim Hollow Advanced Backgrounds? Y/N");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                character.ChosenBackground = Prompts.PickOption("background", Options.GHBackgrounds);
                Console.Clear();
                Console.WriteLine($"You've picked {character.ChosenBackground}.\n");
                backgroundFiller = GHBackground.NewBackground(character);
                backgroundObject = AddBackground.AddGHBackground(backgroundFiller);
            }
            else if (answer == "n")
            {
                character.ChosenBackground = Prompts.PickOption("background", Options.Backgrounds);
                backgroundObject = Background.NewBackground(character.ChosenBackground);
            }

            AddBackground.AddProficiencies(character, backgroundObject);
            AddBackground.AddLanguages(character, backgroundObject);
            AddBackground.AddEquipment(character, backgroundObject);
            AddBackground.PersonalCharacteristics(character, backgroundObject);
            if (answer == "y")
            {
                AddBackground.BackgroundSpecifics(character, backgroundFiller);
            }
            else if (answer == "n")
            {
                AddBackground.BackgroundSpecifics(character, backgroundObject);
            }

            Console.Clear();
            Console.WriteLine("\nYou've finished adding your background!\n");
        }
        public void RunAddClass(Character character)
        {
            var classObject = new CharacterClass(character.Lvl);

            AddClass.AddSpellsKnown(character, classObject);
            AddClass.AddSpellSlots(character, classObject);

            classObject = CharacterClass.NewClass(character, classObject);
            if (character.DemigodDomain == "Knowledge")
            {
                Console.WriteLine("Pick a skill to gain Expertise in");
                var prof = new List<string>();
                prof.AddRange(character.SkillProficiencies);
                string expertise = CLIHelper.PrintChoices(prof);
                character.Skills[expertise] += character.ProficiencyBonus;
            }

            AddClass.DetermineHP(character, classObject);
            AddClass.AddProficiencies(character, classObject);
            AddClass.ClassSpecifics(character, classObject);
            AddClass.AddEquipment(character, classObject);
            AddClass.ModifySkills(character);
            AddClass.AddSpells(character, classObject);

            Console.Clear();
            Console.WriteLine("\nYou've finished adding your character's class!\n");
        }
        public void PrintCharacter(Character character)
        {
            PickHolySymbol(character);
            character.Name = CLIHelper.GetString("Enter your character's name here:");
            character.Deity = CLIHelper.GetString("Enter the name of your deity here:");
            string height = CLIHelper.ConvertHeight(character.Height);
            string size = "";
            if (character.Size == "Small")
            {
                size = $" ({character.Size})";
            }
            if (character.Template == true)
            {
                character.ChosenTemplate = $"({character.ChosenTemplate})";
            }
            string saves = String.Join(", ", character.Saves);
            string lang = String.Join(", ", character.Languages);
            string profs = String.Join(", ", character.Proficiencies);
            string toolProfs = String.Join(", ", character.ToolProficiencies);
            string additionalBackgroundInfo = WriteAdditionalBackgroundProperty(character);
            int AC = character.AC + 10 + character.DexMod;

            Console.Clear();
            Console.WriteLine($"Name: {character.Name}           Height: {height}{size}                    Class: {character.ChosenClass}({character.Archetype})");
            Console.WriteLine($"Age: {character.Age}{character.ChosenTemplate}              Weight: {character.Weight} lbs.              Level: {character.Lvl}");
            Console.WriteLine($"Race: {character.ChosenRace}          Deity: {character.Deity}                GP: {character.GP}");
            Console.WriteLine($"Alignment: {character.Alignment}        Speed: {character.Speed}ft{character.Speedstring}               XP: {character.XP}");
            if (character.ChosenRace == "Dragonborn")
            {
                Console.Write($"Dragon color: {character.DragonColor}       ");
            }
            Console.WriteLine($"Background: {character.ChosenBackground}     Vision: {character.Vision}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Str: {character.Stats["Str"]} + {character.StrMod}| Init: {character.Init}");
            Console.WriteLine($"Dex: {character.Stats["Dex"]} + {character.DexMod}| Proficiency Bonus: +{character.ProficiencyBonus}");
            Console.WriteLine($"Con: {character.Stats["Con"]} + {character.ConMod}| AC: {AC}");
            Console.WriteLine($"Int: {character.Stats["Int"]} + {character.IntMod}| HP: {character.HP}");
            Console.WriteLine($"Wis: {character.Stats["Wis"]} + {character.WisMod}| Saves: {saves}");
            Console.WriteLine($"Cha: {character.Stats["Cha"]} + {character.ChaMod}");
            Console.WriteLine($"Languages: {lang}");
            Console.WriteLine("\nSkills:");
            Console.WriteLine("------------------------------------");
            foreach (string skill in character.Skills.Keys)
            {
                Console.WriteLine($"{skill} + {character.Skills[skill]}");
            }
            Console.WriteLine($"\nPersonality Trait: {character.PersonalityTrait}");
            Console.WriteLine($"Ideal: {character.Ideal}");
            Console.WriteLine($"Bond: {character.Bond}");
            Console.WriteLine($"Flaw: {character.Flaw}");
            Console.WriteLine($"Background Feature: {character.BackgroundFeature}");
            if (additionalBackgroundInfo != String.Empty)
            {
                Console.WriteLine($"{additionalBackgroundInfo}");
            }
            if (character.Talents.Count != 0)
            {
                Console.WriteLine($"Background Progression: {character.Progression}");
                Console.WriteLine($"\nTalents (+1D{character.ProfessionDie}):");
                Console.WriteLine("------------------------------------");
                foreach (string talent in character.Talents.Keys)
                {
                    Console.WriteLine($"{talent}: {character.Talents[talent]}");
                }
            }
            Console.WriteLine($"\nRacial Traits:");
            Console.WriteLine("------------------------------------");
            foreach (string trait in character.RacialTraits)
            {
                Console.WriteLine($"{trait}");
            }
            if (character.Feats.Count != 0)
            {
                Console.WriteLine($"\nFeats:");
                Console.WriteLine("------------------------------------");
                foreach (string feat in character.Feats)
                {
                    Console.WriteLine($"{feat}");
                }
            }
            Console.WriteLine("\nProficiencies:");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"{profs}");
            Console.WriteLine("\nTool Proficiencies:");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"{toolProfs}");
            Console.WriteLine("\nInventory:");
            Console.WriteLine("------------------------------------");
            foreach (string item in character.Equipment)
            {
                Console.WriteLine($"{item}");
            }
            if (character.Template == true)
            {
                Console.WriteLine($"\nTemplate Progression:");
                Console.WriteLine("------------------------------------");
                foreach (var item in character.TemplateProgression)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"\nTemplate Boons/Flaws:");
                Console.WriteLine("------------------------------------");
                foreach (var item in character.Boons.Keys)
                {
                    Console.WriteLine($"{item}: {character.Boons[item]}");
                }
                foreach (var item in character.Flaws.Keys)
                {
                    Console.WriteLine($"(Flaw){item}: {character.Flaws[item]}");
                }
            }
            Console.WriteLine("\nClass Features:");
            Console.WriteLine("------------------------------------");
            foreach (string feature in character.ClassFeatures.Keys)
            {
                if (!feature.StartsWith("-"))
                {
                    Console.WriteLine($"{feature}: {character.ClassFeatures[feature]}");
                }
                else
                {
                    Console.WriteLine(feature);
                }
            }
            if (character.Spells.Count > 0)
            {
                PrintSpellSlots(character);
                Console.Write("\n\nSpells:");
                if (character.CantripsKnown > 0)
                {
                    Console.Write($" Cantrips Known: {character.CantripsKnown} ");
                }
                if (character.SpellsKnown > 0)
                {
                    Console.Write($"| Spells Known: {character.SpellsKnown}");
                }
                Console.WriteLine("\n------------------------------------");
                PrintSpells(character.Cantrips, character.Spells);
            }
            Console.WriteLine("\nYou've finished creating your character! Scroll up to see the whole sheet");
        }
        public void WriteCharacterToDocument(Character character)
        {
            string directory = Directory.GetCurrentDirectory();
            directory += "..\\..\\..\\..\\..";
            string characterSheet = "YourCharacter.txt";
            string fullPath = Path.Combine(directory, characterSheet);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                //Console.SetOut(sw);
                //PrintCharacter(character);
                string height = CLIHelper.ConvertHeight(character.Height);
                string size = "";
                if (character.Size == "Small")
                {
                    size = $" ({character.Size})";
                }
                if (character.Template == true)
                {
                    character.ChosenTemplate = $"({character.ChosenTemplate})";
                }
                string saves = String.Join(", ", character.Saves);
                string lang = String.Join(", ", character.Languages);
                string profs = String.Join(", ", character.Proficiencies);
                string toolProfs = String.Join(", ", character.ToolProficiencies);
                string additionalBackgroundInfo = WriteAdditionalBackgroundProperty(character);
                int AC = character.AC + 10 + character.DexMod;

                sw.WriteLine($"Name: {character.Name}           Height: {height}{size}             Class: {character.ChosenClass}({character.Archetype})");
                sw.WriteLine($"Age: {character.Age}{character.ChosenTemplate}                Weight: {character.Weight} lbs.              Level: {character.Lvl}");
                sw.WriteLine($"Race: {character.ChosenRace}                Deity: {character.Deity}                GP: {character.GP}");
                sw.WriteLine($"Alignment: {character.Alignment}                Speed: {character.Speed}ft{character.Speedstring}                 XP: {character.XP}");
                if (character.ChosenRace == "Dragonborn")
                {
                    sw.Write($"Dragon color: {character.DragonColor}       ");
                }
                sw.WriteLine($"Background: {character.ChosenBackground}        Vision: {character.Vision}");
                sw.WriteLine("----------------------------------------------------------------------------------------------------------------");
                sw.WriteLine($"Str: {character.Stats["Str"]} + {character.StrMod}| Init: {character.Init}");
                sw.WriteLine($"Dex: {character.Stats["Dex"]} + {character.DexMod}| Proficiency Bonus: +{character.ProficiencyBonus}");
                sw.WriteLine($"Con: {character.Stats["Con"]} + {character.ConMod}| AC: {AC}");
                sw.WriteLine($"Int: {character.Stats["Int"]} + {character.IntMod}| HP: {character.HP}");
                sw.WriteLine($"Wis: {character.Stats["Wis"]} + {character.WisMod}| Saves: {saves}");
                sw.WriteLine($"Cha: {character.Stats["Cha"]} + {character.ChaMod}");
                sw.WriteLine($"Languages: {lang}");
                sw.WriteLine("\nSkills:");
                sw.WriteLine("------------------------------------");
                foreach (string skill in character.Skills.Keys)
                {
                    sw.WriteLine($"{skill} + {character.Skills[skill]}");
                }
                sw.WriteLine($"\nPersonality Trait: {character.PersonalityTrait}");
                sw.WriteLine($"Ideal: {character.Ideal}");
                sw.WriteLine($"Bond: {character.Bond}");
                sw.WriteLine($"Flaw: {character.Flaw}");
                sw.WriteLine($"Background Feature: {character.BackgroundFeature}");
                if (additionalBackgroundInfo != String.Empty)
                {
                    sw.WriteLine($"{additionalBackgroundInfo}");
                }
                if (character.Talents.Count != 0)
                {
                    sw.WriteLine($"Background Progression: {character.Progression}");
                    sw.WriteLine($"\nTalents:");
                    sw.WriteLine("------------------------------------");
                    foreach (string talent in character.Talents.Keys)
                    {
                        sw.WriteLine($"{talent}: {character.Talents[talent]}");
                    }
                }
                sw.WriteLine($"\nRacial Traits:");
                sw.WriteLine("------------------------------------");
                foreach (string trait in character.RacialTraits)
                {
                    sw.WriteLine($"{trait}");
                }
                if (character.Feats.Count != 0)
                {
                    sw.WriteLine($"\nFeats:");
                    sw.WriteLine("------------------------------------");
                    foreach (string feat in character.Feats)
                    {
                        sw.WriteLine($"{feat}");
                    }
                }
                sw.WriteLine("\nProficiencies:");
                sw.WriteLine("------------------------------------");
                sw.WriteLine($"{profs}");
                sw.WriteLine("\nTool Proficiencies:");
                sw.WriteLine("------------------------------------");
                sw.WriteLine($"{toolProfs}");
                sw.WriteLine("\nInventory:");
                sw.WriteLine("------------------------------------");
                foreach (string item in character.Equipment)
                {
                    sw.WriteLine($"{item}");
                }
                if (character.Template == true)
                {
                    sw.WriteLine($"\nTemplate Progression:");
                    sw.WriteLine("------------------------------------");
                    foreach (var item in character.TemplateProgression)
                    {
                        sw.WriteLine(item);
                    }
                    sw.WriteLine($"\nTemplate Boons/Flaws:");
                    sw.WriteLine("------------------------------------");
                    foreach (var item in character.Boons.Keys)
                    {
                        sw.WriteLine($"{item}: {character.Boons[item]}");
                    }
                    foreach (var item in character.Flaws.Keys)
                    {
                        sw.WriteLine($"(Flaw){item}: {character.Flaws[item]}");
                    }
                }
                sw.WriteLine("\nClass Features:");
                sw.WriteLine("------------------------------------");
                foreach (string feature in character.ClassFeatures.Keys)
                {
                    if (!feature.StartsWith("-"))
                    {
                        sw.WriteLine($"{feature}: {character.ClassFeatures[feature]}");
                    }
                    else
                    {
                        sw.WriteLine(feature);
                    }
                }
                if (character.Spells.Count > 0)
                {
                    int start = 2;
                    for (int i = 1; i <= character.SpellSlots.Count; i++)
                    {
                        if (character.SpellSlots[i] > 0)
                        {
                            if (i == 1)
                            {
                                sw.Write("\nSPD: 1");
                            }
                            sw.Write($" | {start}");
                            start++;
                        }
                    }
                    sw.WriteLine("\n------------------------------------");
                    for (int i = 1; i < character.SpellSlots.Count; i++)
                    {
                        if (character.SpellSlots[i] > 0)
                        {
                            if (i == 1)
                            {
                                sw.Write($"     {character.SpellSlots[1]}");
                            }

                            if (i != 1)
                            {
                                sw.Write($" | {character.SpellSlots[i]}");
                            }
                        }
                    }
                    sw.Write("\n\nSpells:");
                    if (character.CantripsKnown > 0)
                    {
                        sw.Write($" Cantrips Known: {character.CantripsKnown} ");
                    }
                    if (character.SpellsKnown > 0)
                    {
                        sw.Write($"| Spells Known: {character.SpellsKnown}");
                    }
                    sw.WriteLine("\n------------------------------------");
                    string cantrips = string.Join(", ", character.Cantrips);
                    sw.WriteLine($"0 - {cantrips}");
                    foreach (int spellLvl in character.Spells.Keys)
                    {
                        string currentSpells = string.Join(", ", character.Spells[spellLvl]);
                        sw.WriteLine($"{spellLvl} - {currentSpells}");
                    }
                    sw.WriteLine("\n\n\nEnd of character sheet\n\n");
                }
            }
        }
        public bool FinalPrompt()
        {
            bool returnBool = false;
            Console.WriteLine("\nDo you want to create another character? If yes enter '1' if not hit any key.");
            string input = Console.ReadLine();

            if (input == "1")
            {
                returnBool = true;
            }

            return returnBool;
        }
        public static void PrintSpellSlots(Character character)
        {
            int start = 2;
            for (int i = 1; i <= character.SpellSlots.Count; i++)
            {
                if (character.SpellSlots[i] > 0)
                {
                    if (i == 1)
                    {
                        Console.Write("\nSPD: 1");
                    }
                    Console.Write($" | {start}");
                    start++;
                }
            }
            Console.WriteLine("\n     -------------------------------");
            for (int i = 1; i < character.SpellSlots.Count; i++)
            {
                if (character.SpellSlots[i] > 0)
                {
                    if (i == 1)
                    {
                        Console.Write($"     {character.SpellSlots[1]}");
                    }
                    if (i != 1)
                    {
                        Console.Write($" | {character.SpellSlots[i]}");
                    }
                }
            }
        }
        public static void PrintSpells(List<string> cantripsList, Dictionary<int, List<string>> spells)
        {
            string cantrips = String.Join(", ", cantripsList);
            Console.WriteLine($"0 - {cantrips}");
            foreach (int spellLvl in spells.Keys)
            {
                string currentSpells = String.Join(", ", spells[spellLvl]);
                Console.WriteLine($"{spellLvl} - {currentSpells}");
            }
        }
        public static string WriteAdditionalBackgroundProperty(Character character)
        {
            string backgroundString = character.ChosenBackground;
            string returnString = String.Empty;
            
            if (backgroundString == "Charltan")
            {
                returnString = $"Favorite Scam: {character.FavoriteScam}";
            }
            else if (backgroundString == "Criminal")
            {
                returnString = $"Specialty: {character.Specialty}";
            }
            else if (backgroundString == "Entertainer")
            {
                string routines = String.Join(", ", character.Routines);
               returnString = $"Routines: {routines}";
            }
            else if (backgroundString == "Folk Hero")
            {
                returnString = $"Defining Event: {character.DefiningEvent}";
            }
            else if (backgroundString == "Guild Artisan")
            {
                returnString = $"Guild Business: {character.GuildBusiness}";
            }
            else if (backgroundString == "Hermit")
            {
                returnString = $"Life of Seclusion: {character.LifeOfSeclusion}";
            }
            else if (backgroundString == "Outlander")
            {
                returnString = $"Origin: {character.Origin}";
            }
            else if (backgroundString == "Sage")
            {
                returnString = $"Specialty: {character.Specialty}";
            }
            else if (backgroundString == "Soldier")
            {
                returnString = $"Specialty: {character.Specialty}";
            }
            if (character.ChosenClass == "Paladin")
            {
                string tenets = String.Join(", ", character.Tenets);
                returnString += $"\nPaladin Tenets: {tenets}\n";
                if (returnString.Length > 130)
                {
                    returnString = returnString.Substring(0, 130) + "\n" + returnString.Substring(130);
                }
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
        public static void DetermineAC(Character character)
        {
            if (character.ChosenClass == "Barbarian")
            {
                character.AC += character.Stats["Con"];
            }
            if (character.ChosenClass == "Monk")
            {
                character.AC += character.Stats["Wis"];
            }
            if (character.ChosenClass != "Barbarian" || character.ChosenClass != "Monk")
            {
                string armor = "";
                int armorAC = 0;
                int intValue = -1;
                foreach (var item in character.Equipment)
                {
                    if (item.Contains("AC"))
                    {
                        int index = item.IndexOf("AC");
                        armor = item.Substring(index - 2, 1);
                    }
                }
                if (int.TryParse(armor, out intValue))
                {
                    armorAC = intValue;
                }
                character.AC += armorAC;
            }
        }
    }
}
