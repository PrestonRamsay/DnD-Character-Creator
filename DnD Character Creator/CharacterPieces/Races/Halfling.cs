using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Halfling
    {
        public static void Lightfoot(Character character)
        {
            character.RacialTraits.Add("Lucky: when you roll a 1 you can reroll it once");
            character.RacialTraits.Add("Brave: you have Advantage on saves vs fear effects");
            character.RacialTraits.Add("Halfling Nimbleness: you can move through squares occupied by creatures who are larger than you");
            character.RacialTraits.Add("Naturally Stealthy: you can attempt to hide when you are obscured by a creature larger than you");
            character.MinHeight = 34;
            character.MaxHeight = 38;
            character.Size = "Small";
            character.MinWeight = 35;
            character.MaxWeight = 45;
            character.Speed += 25;
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AdultAge = 20;
            character.MaxAgeStart = 200;
            character.Languages.Add("Halfling");
        }
        public static void Stout(Character character)
        {
            character.RacialTraits.Add("Lucky: when you roll a 1 you can reroll it once");
            character.RacialTraits.Add("Brave: you have Advantage on saves vs fear effects");
            character.RacialTraits.Add("Halfling Nimbleness: you can move through squares occupied by creatures who are larger than you");
            character.RacialTraits.Add("Stout Resilience: gain Resistance to Poison, and Advantage on saves vs Poison");
            character.MinHeight = 34;
            character.MaxHeight = 38;
            character.Size = "Small";
            character.MinWeight = 35;
            character.MaxWeight = 45;
            character.Speed += 25;
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AdultAge = 20;
            character.MaxAgeStart = 200;
            character.Languages.Add("Halfling");
        }
    }
}
