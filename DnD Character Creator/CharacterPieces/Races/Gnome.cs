using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Gnome
    {
        public static void Forest(Character character)
        {
            character.RacialTraits.Add("Gnome Cunning: you gain Advantage on Int, Wis, and Cha saves vs magic");
            character.RacialTraits.Add("Speak with Small Beasts: Through sounds and gestures, you can communicate with " +
                "\n        simple ideas to small or smaller beasts");
            character.MinHeight = 36;
            character.MaxHeight = 48;
            character.Size = "Small";
            character.MinWeight = 30;
            character.MaxWeight = 50;
            character.Speed += 25;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("C-G");
            character.AdultAge = 40;
            character.MaxAgeStart = 350;
            character.MaxAgeEnd = 500;
            character.Languages.Add("Gnomish");
            character.Cantrips.Add("Minor Illusion(Int to cast)");
        }
        public static void Rock(Character character)
        {
            character.RacialTraits.Add("Gnome Cunning: you gain Advantage on Int, Wis, and Cha saves vs magic");
            character.RacialTraits.Add("Artificer's Lore: History checks on items or devices that are based on magic, " +
                "\n        technology, or alchemy are treated as if you are proficient and add your Proficiency bonus x2");
            character.RacialTraits.Add("Tinker: you can spend 1hr and 10gp to create a tiny clockwork device that has 1HP and " +
                "\n        an AC of 5. The device ceases to function after 24hr unless you spend 1hr to repair it. You can also use " +
                "\n        your action to dismantle the device and reclaim it's materials. You can make: a fire starter(creates " +
                "\n        miniature flame), a music box(single song at a moderate volume), or a clockwork toy(moves 5ft in a random " +
                "\n        direction and makes noise approriate to the creature it represents).");
            character.MinHeight = 36;
            character.MaxHeight = 48;
            character.Size = "Small";
            character.MinWeight = 30;
            character.MaxWeight = 50;
            character.Speed += 25;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AlignmentOptions.Add("N-G");
            character.AdultAge = 40;
            character.MaxAgeStart = 350;
            character.MaxAgeEnd = 500;
            character.Languages.Add("Gnomish");
        }
    }
}
