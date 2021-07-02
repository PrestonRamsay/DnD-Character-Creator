using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Dhampir
    {
        public static void Base(Character character)
        {
            character.RacialTraits.Add("Bite - 1D6 Piercing");
            character.RacialTraits.Add("Blood Drain: after bite, bonus, grapple check - 1/D12 + Cha Necrotic dmg, heal HP = dmg");
            character.RacialTraits.Add("Regeneration: 1/turn, heal HP = 1/4 lvl, negated by sunlight, radiant or holy water dmg");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 250;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("N-E");
            character.AlignmentOptions.Add("C-G");
            character.AdultAge = 18;
            character.MaxAgeStart = 750;
            BEHelper.AddLanguage(character, "race");
        }
    }
}
