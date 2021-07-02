using DnD_Character_Creator.Helper_Classes;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Changeling
    {
        public static void Base(Character character)
        {
            character.RacialTraits.Add("Change Appearance: action, doesn't change clothes - adv on Deception for disguise");
            character.RacialTraits.Add("Unsettling Visage: when attacked, SR, reaction, 30ft, impose disadv on atk");
            character.RacialTraits.Add("Divergent Persona: prof with 1 tool, while in your persona - PB x2 with that tool");
            character.MinHeight = 60;
            character.MaxHeight = 72;
            character.MinWeight = 100;
            character.MaxWeight = 160;
            character.Speed += 30;
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("TN");
            character.AlignmentOptions.Add("C-N");
            character.AdultAge = 15;
            character.MaxAgeStart = 100;

            string pickMsg = "This race gets to know two languages of your choice, pick them now.";
            for (int i = 0; i < 2; i++)
            {
                string input = CLIHelper.GetNew(Options.Languages, character.Languages, pickMsg);
                character.Languages.Add(input);
            }

            var skills = new List<string> { "Deception", "Insight", "Intimidation", "Persuasion" };
            pickMsg = "Changelings get 2 skill proficiencies of their choice, pick them now";
            for (int i = 0; i < 2; i++)
            {
                string input = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, pickMsg);
                character.SkillProficiencies.Add(input);
            }
            BEHelper.GetTool(character);
        }
    }
}
