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
            if (background.Proficiencies.Contains("Musical instrument"))
            {
                background.Proficiencies.Remove("Musical instrument");
                Console.WriteLine("Enter a musical instrument you'd like to be proficient with. If you'd like to see the options enter 'see options'.");
                string input = Options.GetOption(Options.MusicalInstruments);
                background.Proficiencies.Add(input);
            }
            if (background.Proficiencies.Contains("Artisan's tools"))
            {
                background.Proficiencies.Remove("Artisan's tools");
                Console.WriteLine("Enter a set of artisan's tools you'd like to be proficient with. If you'd like to see the options enter 'see options'.");
                string input = Options.GetOption(Options.ArtisanTools);
                background.Proficiencies.Add(input);
            }
            if (background.Proficiencies.Contains("Gaming set"))
            {
                background.Proficiencies.Remove("Gaming set");
                Console.WriteLine("Enter a gaming set you'd like to be proficient with. If you'd like to see the options enter 'see options'.");
                string input = Options.GetOption(Options.GamingSets);
                background.Proficiencies.Add(input);
            }

            character.Proficiencies.AddRange(background.Proficiencies);
        }
        public static void AddLanguages(Character character, Background background)
        {
            if (background.Languages.Contains("Choice2"))
            {
                Console.WriteLine("This background gets to know two languages of your choice, enter the first language now." +
                    "\nIf you'd like to see the options enter 'see options'.");
                background.Languages.Remove("Choice");
                background.Languages.Remove("Choice2");
                string firstLanguage = Options.GetOption(Options.Languages);
                character.Languages.Add(firstLanguage);

                Console.WriteLine("Enter the second langauge now. If you'd like to see the options enter 'see options'.");
                string secondLanguage = Options.GetOption(Options.Languages);
                character.Languages.Add(secondLanguage);

            }
            else if (background.Languages.Contains("Choice"))
            {
                Console.WriteLine("This background gets to know one language of your choice, enter it now." +
                    "\nIf you'd like to see the options enter 'see options'.");
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
                Console.WriteLine("Enter a musical instrument you'd like to add to your inventory. If you'd like to see the options enter 'see options'.");
                string input = Options.GetOption(Options.MusicalInstruments);
                background.Equipment.Add(input);
            }
            if (background.Equipment.Contains("Artisan's tools"))
            {
                background.Equipment.Remove("Artisan's tools");
                Console.WriteLine("Enter a set of artisan's tools you'd like to add to your inventory. If you'd like to see the options enter 'see options'.");
                string input = Options.GetOption(Options.ArtisanTools);
                background.Equipment.Add(input);
            }
            if (background.Equipment.Contains("Gaming set"))
            {
                background.Equipment.Remove("Gaming set");
                Console.WriteLine("Enter a gaming set you'd like to add to your inventory. If you'd like to see the options enter 'see options'.");
                string input = Options.GetOption(Options.GamingSets);
                background.Equipment.Add(input);
            }

            character.Equipment.AddRange(background.Equipment);
        }        
    }
}
