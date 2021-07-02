using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class HalfOrc
    {
        public static void Base(Character character)
        {
            character.RacialTraits.Add("Savage Attacks: when you crit on an attack roll, add 1 die to your damage roll");
            character.RacialTraits.Add("Relentless Endurance: 1/long rest, when you drop to 0HP, drop to 1HP instead");
            character.MinHeight = 72;
            character.MaxHeight = 84;
            character.MinWeight = 180;
            character.MaxWeight = 250;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("C-N");
            character.AlignmentOptions.Add("C-E");
            character.AdultAge = 14;
            character.MaxAgeStart = 75;
            character.Languages.Add("Orc");
            character.SkillProficiencies.Add("Intimidate");
        }
    }
}
