
namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Cambion
    {
        public static void Base(Character character)
        {
            character.RacialTraits.Add("Fiendish Form: your type becomes Fiend");
            character.MinHeight = 65;
            character.MaxHeight = 77;
            character.MinWeight = 100;
            character.MaxWeight = 200;
            character.Speed += 30;
            character.Speedstring += ", Fly 30ft";
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("L-E");
            character.AlignmentOptions.Add("C-E");
            character.AdultAge = 18;
            character.MaxAgeStart = 160;
            character.SkillProficiencies.Add("Deception");
            character.SkillProficiencies.Add("Persuasion");
            character.Cantrips.Add("Firebolt(Cha to cast)");
        }
    }
}
