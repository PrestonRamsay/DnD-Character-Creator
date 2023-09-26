
namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Genasi
    {
        public static void Air(Character character)
        {
            character.RacialTraits.Add("Resist Cold*");
            character.RacialTraits.Add("Unending Breath: you can hold your breath indefinitely");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 250;
            character.Speed += 30;
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("TN");
            character.AdultAge = 18;
            character.MaxAgeStart = 120;
            character.Languages.Add("Primordial");
            character.Spells[2].Add("Levitate(1/LR, Con to cast)");
        }
        public static void Earth(Character character)
        {
            character.RacialTraits.Add("Resist Poison*");
            character.RacialTraits.Add("Earth Walk: ignore difficult terrain made of stone/earth");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 250;
            character.Speed += 30;
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("L-N");
            character.AlignmentOptions.Add("TN");
            character.AdultAge = 18;
            character.MaxAgeStart = 120;
            character.Languages.Add("Primordial");
            character.Spells[2].Add("Pass Without a Trace(1/LR, Con to cast)");
        }
        public static void Fire(Character character)
        {
            character.RacialTraits.Add("Resist Fire");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 250;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("TN");
            character.AdultAge = 18;
            character.MaxAgeStart = 120;
            character.Languages.Add("Primordial");
            character.Cantrips.Add("Produce Flame(Con to cast)");
        }
        public static void Water(Character character)
        {
            character.RacialTraits.Add("");
            character.RacialTraits.Add("");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 250;
            character.Speed += 30;
            character.Speedstring += ", Swim 30ft";
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("TN");
            character.AdultAge = 18;
            character.MaxAgeStart = 120;
            character.Languages.Add("Primordial");
            character.Cantrips.Add("Shape Water(Con to cast)");
        }
    }
}
