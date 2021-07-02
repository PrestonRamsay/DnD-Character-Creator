using DnD_Character_Creator.Helper_Classes;
using System;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Human
    {
        public static void Base(Character character)
        {
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 300;
            character.Speed += 30;
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AlignmentOptions.Add("L-N");
            character.AlignmentOptions.Add("L-E");
            character.AlignmentOptions.Add("C-G");
            character.AlignmentOptions.Add("C-N");
            character.AlignmentOptions.Add("C-E");
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("TN");
            character.AlignmentOptions.Add("N-E");
            character.AdultAge = 18;
            character.MaxAgeStart = 80;
            BEHelper.AddLanguage(character, "race");
        }
        public static void Variant(Character character)
        {
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 300;
            character.Speed += 30;
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AlignmentOptions.Add("L-N");
            character.AlignmentOptions.Add("L-E");
            character.AlignmentOptions.Add("C-G");
            character.AlignmentOptions.Add("C-N");
            character.AlignmentOptions.Add("C-E");
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("TN");
            character.AlignmentOptions.Add("N-E");
            character.AdultAge = 18;
            character.MaxAgeStart = 80;
            BEHelper.AddLanguage(character, "race");
            string pickMsg = "You get to pick an extra skill proficiency. Enter the skill you'd like here.";
            string skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, pickMsg);
            character.SkillProficiencies.Add(skill);
            Console.WriteLine("You get to pick 2 Feats");
            Feats.AddFeat(character);
            Feats.AddFeat(character);
        }
    }
}
