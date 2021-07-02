using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Shade
    {
        public static void Base(Character character)
        {
            character.RacialTraits.Add("Shadow Step: bonus, SR, teleport 30ft");
            character.RacialTraits.Add("Child of Shadow: Resistance to Necrotic");
            character.RacialTraits.Add("Coalescing Darkness: adv on Stealth while in darkness");
            character.MinHeight = 60;
            character.MaxHeight = 72;
            character.MinWeight = 100;
            character.MaxWeight = 200;
            character.Speed += 30;
            character.Vision = "Superior Darkvision 120ft";
            character.AlignmentOptions.Add("N-E");
            character.AdultAge = 18;
            character.MaxAgeStart = 600;
            character.MaxAgeEnd = 1200;
            BEHelper.AddLanguage(character, "race");
            character.SkillProficiencies.Add("Stealth");
        }
    }
}
