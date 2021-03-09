using DnD_Character_Creator.Backgrounds;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class AddBackground
    {
        public static void AddProficiencies(Character character, Background background)
        {
            if (background.ToolProficiencies.Contains("Musical instrument"))
            {
                background.ToolProficiencies.Remove("Musical instrument");
                string msg = "Pick a musical instrument you'd like to be proficient with.";
                int index = CLIHelper.PrintChoices(msg, Options.MusicalInstruments);
                string input = Options.MusicalInstruments[index];
                background.ToolProficiencies.Add(input);
            }
            if (background.ToolProficiencies.Contains("Artisan's Tools"))
            {
                background.ToolProficiencies.Remove("Artisan's Tools");
                string msg = "Pick a set of Artisan's Tools you'd like to be proficient with.";
                int index = CLIHelper.PrintChoices(msg, Options.ArtisanTools);
                string input = Options.ArtisanTools[index];
                background.ToolProficiencies.Add(input);
            }
            if (background.ToolProficiencies.Contains("Gaming set"))
            {
                background.ToolProficiencies.Remove("Gaming set");
                string msg = "Pick a gaming set you'd like to be proficient with.";
                int index = CLIHelper.PrintChoices(msg, Options.GamingSets);
                string input = Options.GamingSets[index];
                background.ToolProficiencies.Add(input);
            }

            character.SkillProficiencies.UnionWith(background.SkillProficiencies);
            character.Proficiencies.UnionWith(background.ToolProficiencies);
        }
        public static void AddLanguages(Character character, Background background)
        {
            if (background.Languages.Contains("Choice2"))
            {
                Console.WriteLine("This background gets to know 2 languages of your choice");
                background.Languages.Remove("Choice");
                background.Languages.Remove("Choice2");
                string msg = "Pick the 1st language now";
                string errorMsg = "You already have that language, try again.";
                string firstLanguage = CLIHelper.GetNew(Options.Languages, character.Languages, msg, errorMsg);
                character.Languages.Add(firstLanguage);
                msg = "Pick the 2nd language now";
                string secondLanguage = CLIHelper.GetNew(Options.Languages, character.Languages, msg, errorMsg);
                character.Languages.Add(secondLanguage);
            }
            else if (background.Languages.Contains("Choice"))
            {
                Console.WriteLine("This background gets to know one language of your choice");
                background.Languages.Remove("Choice");
                string msg = "Pick your language now";
                string errorMsg = "You already have that language, try again.";
                string input = CLIHelper.GetNew(Options.Languages, character.Languages, msg, errorMsg);
                character.Languages.Add(input);
            }

            character.Languages.UnionWith(background.Languages);
        }
        public static void AddEquipment(Character character, Background background)
        {
            if (background.Equipment.Contains("Musical instrument"))
            {
                background.Equipment.Remove("Musical instrument");
                string msg = "Pick a musical instrument you'd like to add to your inventory.";
                int index = CLIHelper.PrintChoices(msg, Options.MusicalInstruments);
                string input = Options.MusicalInstruments[index];
                background.Equipment.Add(input);
            }
            if (background.Equipment.Contains("Artisan's Tools"))
            {
                background.Equipment.Remove("Artisan's Tools");
                string msg = "Pick a set of Artisan's Tools you'd like to add to your inventory.";
                int index = CLIHelper.PrintChoices(msg, Options.ArtisanTools);
                string input = Options.ArtisanTools[index];
                background.Equipment.Add(input);
            }
            if (background.Equipment.Contains("Gaming set"))
            {
                background.Equipment.Remove("Gaming set");
                string msg = "Pick a gaming set you'd like to add to your inventory.";
                int index = CLIHelper.PrintChoices(msg, Options.GamingSets);
                string input = Options.GamingSets[index];
                background.Equipment.Add(input);
            }

            character.Equipment.AddRange(background.Equipment);
            character.GP += background.GP;
        }
        public static void PersonalCharacteristics(Character character, Background background)
        {
            int traitIndex = Prompts.BackgroundPrompts("personality trait", background.PersonalityTrait);
            character.PersonalityTrait = background.PersonalityTrait[traitIndex];

            int idealIndex = Prompts.BackgroundPrompts("ideal", background.Ideal);
            character.Ideal = background.Ideal[idealIndex];

            int bondIndex = Prompts.BackgroundPrompts("bond", background.Bond);
            character.Bond = background.Bond[bondIndex];

            int flawIndex = Prompts.BackgroundPrompts("flaw", background.Flaw);
            character.Flaw = background.Flaw[flawIndex];
        }
        public static void BackgroundSpecifics(Character character, Background background)
        {
            character.BackgroundFeature = background.Feature;
            string backgroundString = character.ChosenBackground;
            var backgroundObject = background;

            if (backgroundString == "Charltan")
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
            else if (backgroundString == "Entertainer")
            {
                Console.WriteLine("A good entertainer is versatile, spicing things up every performance with a variety of different routines." +
                    "\nYou can have up to 3 routines that define your expertise. Enter a number(1-3) to decide how many routines you have.");
                int routines = CLIHelper.GetNumberInRange(1, 3);
                for (int i = 0; i < routines; i++)
                {
                    int routineIndex = Prompts.BackgroundPrompts("routine", backgroundObject.Routine);
                    character.Routines.Add(backgroundObject.Routine[routineIndex]);
                }
            }
            else if (backgroundString == "Folk Hero")
            {
                Console.WriteLine("You previously lived a simple life, but something happened that set you on a different path and marked you for greatness.");
                int eventIndex = Prompts.BackgroundPrompts("defining event", backgroundObject.DefiningEvent);
                character.DefiningEvent = backgroundObject.DefiningEvent[eventIndex];
            }
            else if (backgroundString == "Guild Artisan")
            {
                Console.WriteLine("Guilds are groups of several artisans who practice the same trade. Pick one good to specialize in.");
                int businessIndex = Prompts.BackgroundPrompts("nature of your guild business", backgroundObject.GuildBusiness);
                character.GuildBusiness = backgroundObject.GuildBusiness[businessIndex];
            }
            else if (backgroundString == "Hermit")
            {
                Console.WriteLine("What was the reason for your isolation? What changed allowing you to end your solitude?");
                int seclusionIndex = Prompts.BackgroundPrompts("nature of your seclusion", backgroundObject.LifeOfSeclusion);
                character.LifeOfSeclusion = backgroundObject.LifeOfSeclusion[seclusionIndex];
            }
            else if (backgroundString == "Outlander")
            {
                backgroundObject = Background.Outlander();
                Console.WriteLine("What was your occupation during your time in the wild?");
                int originIndex = Prompts.BackgroundPrompts("origin", backgroundObject.Origin);
                character.Origin = backgroundObject.Origin[originIndex];
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
        }
        public static void BackgroundSpecifics(Character character, GHBackground background)
        {
            character.BackgroundFeature = background.Feature;
            string backgroundString = character.ChosenBackground;
            var backgroundObject = background;

            if (backgroundString.Contains("Charltan"))
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
            else if (backgroundString.Contains("Entertainer"))
            {
                Console.WriteLine("A good entertainer is versatile, spicing things up every performance with a variety of different routines." +
                    "\nYou can have up to 3 routines that define your expertise. Enter a number(1-3) to decide how many routines you have.");
                int routines = CLIHelper.GetNumberInRange(1, 3);
                for (int i = 0; i < routines; i++)
                {
                    int routineIndex = Prompts.BackgroundPrompts("routine", backgroundObject.Routine);
                    character.Routines.Add(backgroundObject.Routine[routineIndex]);
                }
            }
            else if (backgroundString.Contains("Merchant"))
            {
                Console.WriteLine("Guilds are groups of several merchants who practice the same trade. Pick one good to specialize in.");
                int businessIndex = Prompts.BackgroundPrompts("nature of your guild business", backgroundObject.GuildBusiness);
                character.GuildBusiness = backgroundObject.GuildBusiness[businessIndex];
            }
        }
        public static Background AddGHBackground(GHBackground background)
        {
            var result = new Background();

            result.SkillProficiencies.UnionWith(background.SkillProficiencies);
            result.ToolProficiencies.UnionWith(background.ToolProficiencies);
            result.Languages.UnionWith(background.Languages);
            result.Equipment.AddRange(background.Equipment);
            result.GP += background.GP;
            result.Feature = background.Feature;
            background.PersonalityTrait.CopyTo(result.PersonalityTrait, 0);
            background.Ideal.CopyTo(result.Ideal, 0);
            background.Bond.CopyTo(result.Bond, 0);
            background.Flaw.CopyTo(result.Flaw, 0);
            background.FavoriteScam.CopyTo(result.FavoriteScam, 0);
            background.Routine.CopyTo(result.Routine, 0);
            background.GuildBusiness.CopyTo(result.GuildBusiness, 0);

            return result;
        }
    }
}
