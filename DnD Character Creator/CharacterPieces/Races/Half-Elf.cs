using DnD_Character_Creator.Helper_Classes;
using System;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class HalfElf
    {
        public static void Base(Character character)
        {
            character.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");

            character.MinHeight = 60;
            character.MaxHeight = 72;
            character.MinWeight = 100;
            character.MaxWeight = 250;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("C-N");
            character.AdultAge = 20;
            character.MaxAgeStart = 180;
            character.Languages.Add("Elven");
            BEHelper.AddLanguage(character, "race");

            Console.WriteLine("You have a choice between gaining 2 skill proficiencies or 1 skill proficiency and the Dilettante trait");
            string dilettante = "Dilettante: pick a 1st lvl class feature from any class";
            //CLIHelper.Print2Choices("2 extra skill proficiencies", dilettante);
            int input = CLIHelper.GetChoiceFromPair("2 extra skill proficiencies", dilettante);

            if (input == 1)
            {
                string pickMsg = "Pick a skill";
                for (int i = 0; i < 2; i++)
                {
                    string skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, pickMsg);
                    character.SkillProficiencies.Add(skill);
                }
            }
            else
            {
                string pickMsg = "Pick a skill";
                string skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, pickMsg);
                character.SkillProficiencies.Add(skill);
                character.RacialTraits.Add("Dilettante: pick a 1st lvl class feature from any class");
                Console.WriteLine("Pick a 1st lvl class feature for Dilettante, you will have to add this feature manually");
                string feature = CLIHelper.PrintChoices(Options.Lvl1Features);
                character.ClassFeatures.Add(feature, Options.Lvl1Features[feature]);
            }
        }
    }
}
