
namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Aasimar
    {
        public static void Protector(Character character)
        {
            character.RacialTraits.Add("Celestial Radiance: Resistance to Necrotic & Radiant dmg");
            character.RacialTraits.Add("Healing Hands: LR, action, heal HP = lvl");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 300;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("N-G");
            character.MaxAgeStart = 160;
            character.Languages.Add("Celestial");
            character.Cantrips.Add("Light(Cha to cast)");
        }
        public static void Scourge(Character character)
        {
            character.RacialTraits.Add("Celestial Radiance: Resistance to Necrotic & Radiant dmg");
            character.RacialTraits.Add("Healing Hands: LR, action, heal HP = lvl");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 300;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("N-G");
            character.AdultAge = 18;
            character.MaxAgeStart = 160;
            character.Languages.Add("Celestial");
            character.Cantrips.Add("Light(Cha to cast)");
        }
        public static void Fallen(Character character)
        {
            character.RacialTraits.Add("Celestial Radiance: Resistance to Necrotic & Radiant dmg");
            character.RacialTraits.Add("Healing Hands: LR, action, heal HP = lvl");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 300;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("TN");
            character.AlignmentOptions.Add("N-E");
            character.AdultAge = 18;
            character.MaxAgeStart = 160;
            character.Languages.Add("Celestial");
            character.Cantrips.Add("Light(Cha to cast)");
        }
    }
}
