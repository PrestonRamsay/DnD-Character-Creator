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
                Console.WriteLine($"Enter a musical instrument you'd like to be proficient with. {Options.SeeOptions}");
                string input = Options.GetOption(Options.MusicalInstruments);
                background.ToolProficiencies.Add(input);
            }
            if (background.ToolProficiencies.Contains("Artisan's tools"))
            {
                background.ToolProficiencies.Remove("Artisan's tools");
                Console.WriteLine($"Enter a set of artisan's tools you'd like to be proficient with. {Options.SeeOptions}");
                string input = Options.GetOption(Options.ArtisanTools);
                background.ToolProficiencies.Add(input);
            }
            if (background.ToolProficiencies.Contains("Gaming set"))
            {
                background.ToolProficiencies.Remove("Gaming set");
                Console.WriteLine($"Enter a gaming set you'd like to be proficient with. {Options.SeeOptions}");
                string input = Options.GetOption(Options.GamingSets);
                background.ToolProficiencies.Add(input);
            }

            character.Proficiencies.AddRange(background.ToolProficiencies);
        }
        public static void AddLanguages(Character character, Background background)
        {
            if (background.Languages.Contains("Choice2"))
            {
                Console.WriteLine("This background gets to know two languages of your choice, enter the first language now." +
                    $"\n{Options.SeeOptions}");
                background.Languages.Remove("Choice");
                background.Languages.Remove("Choice2");
                string firstLanguage = Options.GetOption(Options.Languages);
                character.Languages.Add(firstLanguage);

                Console.WriteLine($"Enter the second langauge now. {Options.SeeOptions}");
                string secondLanguage = Options.GetOption(Options.Languages);
                character.Languages.Add(secondLanguage);

            }
            else if (background.Languages.Contains("Choice"))
            {
                Console.WriteLine("This background gets to know one language of your choice, enter it now." +
                    $"\n{Options.SeeOptions}");
                background.Languages.Remove("Choice");
                string input = Options.GetOption(Options.Languages);
                character.Languages.Add(input);
            }
        }
        public static void AddEquipment(Character character, Background background)
        {
            if (background.Equipment.Contains("Musical instrument"))
            {
                background.Equipment.Remove("Musical instrument");
                Console.WriteLine($"Enter a musical instrument you'd like to add to your inventory. {Options.SeeOptions}");
                string input = Options.GetOption(Options.MusicalInstruments);
                background.Equipment.Add(input);
            }
            if (background.Equipment.Contains("Artisan's tools"))
            {
                background.Equipment.Remove("Artisan's tools");
                Console.WriteLine($"Enter a set of artisan's tools you'd like to add to your inventory. {Options.SeeOptions}");
                string input = Options.GetOption(Options.ArtisanTools);
                background.Equipment.Add(input);
            }
            if (background.Equipment.Contains("Gaming set"))
            {
                background.Equipment.Remove("Gaming set");
                Console.WriteLine($"Enter a gaming set you'd like to add to your inventory. {Options.SeeOptions}");
                string input = Options.GetOption(Options.GamingSets);
                background.Equipment.Add(input);
            }

            character.Equipment.AddRange(background.Equipment);
        }        
    }
}
