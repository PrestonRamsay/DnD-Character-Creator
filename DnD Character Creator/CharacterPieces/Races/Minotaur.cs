using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Minotaur
    {
        public static void Base(Character character)
        {
            character.RacialTraits.Add("Horns - 1D6 Piercing");
            character.RacialTraits.Add("Goring Rush: after Dash that moves 20ft, melee bonus with Horns");
            character.RacialTraits.Add("Hammering Horns: on hit, bonus, Str DC - push 10ft");
            character.MinHeight = 72;
            character.MaxHeight = 84;
            character.MinWeight = 200;
            character.MaxWeight = 350;
            character.Speed += 30;
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("L-N");
            character.AlignmentOptions.Add("C-N");
            character.AdultAge = 18;
            character.MaxAgeStart = 80;
            character.SkillProficiencies.Add("Intimidation");
            character.SkillProficiencies.Add("Persuasion");
        }
    }
}
