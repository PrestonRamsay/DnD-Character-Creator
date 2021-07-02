using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Goliath
    {
        public static void Base(Character character)
        {
            character.RacialTraits.Add("Mountain Born: can endure cold climates above 20,000ft");
            character.RacialTraits.Add("Stone's Endurance: SR, reaction, reduce dmg by 1D12 + Con");
            character.RacialTraits.Add("Powerful Build: count as Large for carry capacity, etc");
            character.MinHeight = 84;
            character.MaxHeight = 96;
            character.MinWeight = 280;
            character.MaxWeight = 340;
            character.Speed += 30;
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("L-N");
            character.AdultAge = 18;
            character.MaxAgeStart = 80;
            character.Languages.Add("Giant");
            character.SkillProficiencies.Add("Athletics");
        }
    }
}
