using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.CharacterPieces;
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

            BEHelper.SetXP(character);
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

            var racialStats = new List<Tuple<string, int>>();
            if (character.ChosenRace == "Demigod")
            {
                racialStats = Stats.DemigodStats(character.DemigodDomain);

            }
            else
            {
                racialStats = Stats.RacialStats(character.ChosenRace);
            }
            Stats.RacialStats(character, racialStats);

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

            Console.WriteLine("\nEnter anything to continue to ability score improvements");
            string answer = Console.ReadLine();
            Console.Clear();
            Stats.IncreaseStatByLvl(character);
            Console.Clear();
            Console.Write($"\nYour stats are now ");
            foreach (var stat in Options.Stats)
            {
                Console.Write($"{stat}: {character.Stats[stat]}  ");
            }
            Console.WriteLine("\nYou've finished your character's stats!\n");
        }
        public void RunAddTemplate(Character character)
        {
            if (character.Template == true)
            {
                string templateName = character.ChosenTemplate;
                Console.WriteLine($"Because you are a/an {templateName} you can pick a new age.");
                character.Age = CLIHelper.GetNumberInRange(character.AdultAge, 15000);
                Template.NewTemplate(templateName, character);
            }
        }
        public void RunAddRace(Character character)
        {
            Console.WriteLine($"You will now add {character.ChosenRace} traits.\n");
            AddRace.NewRace(character);

            Console.WriteLine($"Pick a height between {CLIHelper.ConvertHeight(character.MinHeight)} and " +
                $"{CLIHelper.ConvertHeight(character.MaxHeight)}. Format should be: (Feet)'(Inches)\".");
            CLIHelper.AddHeight(character);

            Console.WriteLine($"Pick a weight between {character.MinWeight}lbs and {character.MaxWeight}lbs.");
            character.Weight = CLIHelper.GetNumberInRange(character.MinWeight, character.MaxWeight);

            CLIHelper.Alignment(character);
            Console.WriteLine();
            CLIHelper.Age(character);
            AddRace.Spells(character);
            AddRace.HigherLvlFeatures(character);
            if (character.ChosenRace == "Demigod")
            {
                character.ChosenRace += $"({character.DemigodDomain})";
            }

            Console.Clear();
            Console.WriteLine("\nYou've finished adding your race!\n");
        }
        public void RunAddBackground(Character character)
        {
            var backgroundObject = new Background();

            Console.WriteLine("Do you want Grim Hollow Advanced Backgrounds? Y/N");
            var yesNo = new List<string> { "y", "n" };
            string answer = CLIHelper.GetStringInList(yesNo);

            if (answer == "y")
            {
                character.ChosenBackground = Prompts.PickOption("background", Options.GHBackgrounds);
                Console.Clear();
                Console.WriteLine($"You've picked {character.ChosenBackground}.\n");
                var GHFillerObject = GHBackground.NewBackground(character);
                backgroundObject = AddBackground.AddGHBackground(GHFillerObject);
            }
            else if (answer == "n")
            {
                character.ChosenBackground = Prompts.PickOption("background", Options.Backgrounds);
                backgroundObject = Background.NewBackground(character);
            }

            AddBackground.PersonalCharacteristics(character, backgroundObject);
            AddBackground.BackgroundSpecifics(character, backgroundObject);

            Console.Clear();
            Console.WriteLine("\nYou've finished adding your background!\n");
        }
        public void RunAddClass(Character character)
        {
            character.Init += character.DexMod;

            AddClass.AddSpellsKnown(character);
            AddClass.AddSpellSlots(character);
            AddClass.NewClass(character);

            if (character.DemigodDomain == "Knowledge")
            {
                Console.WriteLine("Pick a skill to gain Expertise in");
                var prof = new List<string>();
                prof.AddRange(character.SkillProficiencies);
                string expertise = CLIHelper.PrintChoices(prof);
                BEHelper.AddSkillExpertise(expertise, character);
            }
            if (character.Feats.ContainsKey("Weapon Master"))
            {
                Feats.WeaponMaster(character);
            }

            AddClass.ModifySkills(character);
            BEHelper.AddSpellDesc(character);
            AddClass.DetermineAC(character);
            AddClass.DetermineHP(character);

            Console.Clear();
            Console.WriteLine("\nYou've finished adding your character's class!\n");
        }
        public void WriteCharacterToDocument(Character character)
        {
            character.Name = CLIHelper.GetString("Enter your character's name here:");
            character.Deity = CLIHelper.GetString("Enter the name of your deity here:");
            string directory = Directory.GetCurrentDirectory();
            directory += "..\\..\\..\\..\\..";
            string characterSheet = $"{character.Name}.txt";
            string fullPath = Path.Combine(directory, characterSheet);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                if (character.Template == true)
                {
                    character.ChosenTemplate = $"({character.ChosenTemplate})";
                }
                string height = CLIHelper.ConvertHeight(character.Height);
                string size = "";
                if (character.Size == "Small")
                {
                    size = $" ({character.Size})";
                }
                string saves = String.Join(", ", character.Saves);
                string lang = String.Join(", ", character.Languages);
                string profs = String.Join(", ", character.Proficiencies);
                string toolProfs = String.Join(", ", character.ToolProficiencies);
                string additionalBackgroundInfo = CLIHelper.AddSpecialty(character);

                sw.WriteLine($"Name: {character.Name}           	Height: {height}{size}                  Speed: {character.Speed}ft{character.Speedstring}");
                sw.WriteLine($"Age: {character.Age}                 Weight: {character.Weight} lbs.           Level: {character.Lvl}");
                sw.WriteLine($"Race: {character.ChosenRace}{character.ChosenTemplate}");
                sw.WriteLine($"Alignment: {character.Alignment}                         Vision: {character.Vision}");
                sw.WriteLine($"Deity: {character.Deity}                     GP: {character.GP}              XP: {character.XP}");
                sw.WriteLine($"Background: {character.ChosenBackground}             Class: {character.ChosenClass}({character.Archetype})");
                if (character.ChosenRace == "Dragonborn")
                {
                    sw.Write($"Dragon color: {character.DragonColor}       ");
                }
                sw.WriteLine("-----------------------------------------------------------------");
                //stats
                sw.WriteLine($"Str: {character.Stats["Str"]} + {character.StrMod} | Init: {character.Init}");
                sw.WriteLine($"Dex: {character.Stats["Dex"]} + {character.DexMod} | Proficiency Bonus: +{character.ProficiencyBonus}");
                sw.WriteLine($"Con: {character.Stats["Con"]} + {character.ConMod} | AC: {character.AC}");
                sw.WriteLine($"Int: {character.Stats["Int"]} + {character.IntMod} | HP: {character.HP}");
                sw.WriteLine($"Wis: {character.Stats["Wis"]} + {character.WisMod} | Saves: {saves}");
                sw.WriteLine($"Cha: {character.Stats["Cha"]} + {character.ChaMod} |");
                sw.WriteLine($"Languages: {lang}");
                //skills
                sw.WriteLine("\nSkills:");
                foreach (string skill in character.Skills.Keys)
                {
                    sw.WriteLine($"{skill} + {character.Skills[skill]}");
                }
                //background
                sw.WriteLine($"\nPersonality Trait: {character.PersonalityTrait}");
                sw.WriteLine($"Ideal: {character.Ideal}");
                sw.WriteLine($"Bond: {character.Bond}");
                sw.WriteLine($"Flaw: {character.Flaw}");
                sw.WriteLine($"Background Feature: {character.BackgroundFeature}");
                if (additionalBackgroundInfo != String.Empty)
                {
                    sw.WriteLine($"{additionalBackgroundInfo}");
                }
                //racial
                sw.WriteLine($"\nRacial Traits:");
                foreach (string trait in character.RacialTraits)
                {
                    sw.WriteLine($"{trait}");
                }
                //feats
                if (character.Feats.Count != 0)
                {
                    sw.WriteLine($"\nFeats:");
                    foreach (string feat in character.Feats.Keys)
                    {
                        sw.WriteLine($"{feat}: {character.Feats[feat]}");
                    }
                }
                //inventory
                sw.WriteLine("\nInventory:");
                foreach (string item in character.Equipment)
                {
                    sw.WriteLine($"{item}");
                }
                //template
                if (character.Template == true)
                {
                    sw.WriteLine($"\nTemplate Boons/Flaws:");
                    foreach (var item in character.Boons.Keys)
                    {
                        sw.WriteLine($"{item}: {character.Boons[item]}");
                    }
                    foreach (var item in character.Flaws.Keys)
                    {
                        sw.WriteLine($"(Flaw){item}: {character.Flaws[item]}");
                    }
                }
                //class features
                sw.WriteLine("\nClass Features:");
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
                //spells
                if (character.Spells.Count > 0)
                {
                    PrintSpellSlots(character, sw);
                    sw.WriteLine("\nFormat: action or cast time, range, duration, targets, atk or save, conditions, dmg, effects and desc");
                    sw.Write("\nSpells:");
                    if (character.CantripsKnown > 0)
                    {
                        sw.Write($" Cantrips Known: {character.CantripsKnown} ");
                    }
                    if (character.SpellsKnown > 0)
                    {
                        sw.Write($"| Spells Known: {character.SpellsKnown}");
                    }
                    string cantrips = string.Join("\n", character.Cantrips);
                    sw.WriteLine($"0 - {cantrips}");
                    foreach (int spellLvl in character.Spells.Keys)
                    {
                        string currentSpells = string.Join("\n", character.Spells[spellLvl]);
                        sw.WriteLine($"{spellLvl} - {currentSpells}");
                    }
                }
                //profs
                sw.WriteLine($"\nProficiencies: {profs}");
                sw.WriteLine($"\nTool Proficiencies: {toolProfs}");
                //talents
                if (character.Talents.Count != 0)
                {
                    sw.WriteLine($"\nTalents(D{character.ProfessionDie}):");
                    foreach (string talent in character.Talents.Keys)
                    {
                        sw.WriteLine($"{talent}: {character.Talents[talent]}");
                    }
                    //progression
                    sw.WriteLine($"Background Progression: {character.Progression}");
                }
                if (character.Template == true)
                {
                    sw.WriteLine($"\nTemplate Progression:");
                    foreach (var item in character.TemplateProgression)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
        }
        public bool FinalPrompt()
        {
            Console.Clear();
            Console.WriteLine("\nYou've finished creating your character! It has been saved as \"Your Character's Name.txt\"");
            bool returnBool = false;
            Console.WriteLine("\n\nDo you want to create another character? If yes enter '1' if not hit any key.");
            string input = Console.ReadLine();

            if (input == "1")
            {
                returnBool = true;
            }

            return returnBool;
        }
        public static void PrintSpellSlots(Character character, StreamWriter sw)
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
            sw.WriteLine("\n     -------------------------------");
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
        }
    }
}
