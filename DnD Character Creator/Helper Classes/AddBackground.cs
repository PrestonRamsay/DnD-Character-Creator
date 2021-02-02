using DnD_Character_Creator.Backgrounds;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class AddBackground
    {
        public static void BackgroundSpecifics(Character character, Background background)
        {
            character.SkillProficiencies.AddRange(background.SkillProficiencies);
            character.GP += background.GP;
            character.BackgroundFeature = background.Feature;

            int traitIndex = Prompts.BackgroundPrompts("personality trait", background.PersonalityTrait);
            character.PersonalityTrait = background.PersonalityTrait[traitIndex];

            int idealIndex = Prompts.BackgroundPrompts("ideal", background.Ideal);
            character.Ideal = background.Ideal[idealIndex];

            int bondIndex = Prompts.BackgroundPrompts("bond", background.Bond);
            character.Bond = background.Bond[bondIndex];

            int flawIndex = Prompts.BackgroundPrompts("flaw", background.Flaw);
            character.Flaw = background.Flaw[flawIndex];
        }
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
            if (background.ToolProficiencies.Contains("Artisan's tools"))
            {
                background.ToolProficiencies.Remove("Artisan's tools");
                string msg = "Pick a set of artisan's tools you'd like to be proficient with.";
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

            character.Proficiencies.AddRange(background.ToolProficiencies);
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
            if (background.Equipment.Contains("Artisan's tools"))
            {
                background.Equipment.Remove("Artisan's tools");
                string msg = "Pick a set of artisan's tools you'd like to add to your inventory.";
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
        }        
    }
}
