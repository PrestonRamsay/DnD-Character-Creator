using DnD_Character_Creator.Helper_Classes;
using System;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Tiefling
    {
        public static void Base(Character character)
        {
            int input = 0;
            Console.WriteLine("Would you like wings or magic? Pick a number.");
            CLIHelper.Print2Choices("Wings", "Magic");
            int answer = CLIHelper.GetNumberInRange(1, 2);
            if (answer == 2)
            {
                Console.WriteLine("Which kind of magic would you like? Pick a number.");
                CLIHelper.Print2Choices("Infernal Legacy", "Devil's Tongue");
                input = CLIHelper.GetNumberInRange(1, 2);
            }

            character.RacialTraits.Add("Hellish Resistance: gain Resistance to Fire");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 200;
            character.Speed += 30;
            if (answer == 1)
            {
                character.Speed += 30;
                character.Speedstring += ", Fly 30ft";
            }
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("C-N");
            character.AlignmentOptions.Add("C-E");
            character.AdultAge = 18;
            character.MaxAgeStart = 80;
            character.Languages.Add("Infernal");

            if (input == 1)
            {
                character.Cantrips.Add("Thaumaturgy(Cha to cast)");
                character.TieflingMagic = "Infernal Legacy";
            }
            else if (input == 2)
            {
                character.Cantrips.Add("Vicious Mockery(Cha to cast)");
                character.TieflingMagic = "Devil's Tongue";
            }
        }
        public static void Feral(Character character)
        {
            int input = 0;
            Console.WriteLine("Would you like wings or magic? Pick a number.");
            CLIHelper.Print2Choices("Wings", "Magic");
            int answer = CLIHelper.GetNumberInRange(1, 2);
            if (answer == 2)
            {
                Console.WriteLine("Which kind of magic would you like? Pick a number.");
                CLIHelper.Print2Choices("Infernal Legacy", "Devil's Tongue");
                input = CLIHelper.GetNumberInRange(1, 2);
            }

            character.RacialTraits.Add("Hellish Resistance: gain Resistance to Fire");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 200;
            character.Speed += 30;
            if (answer == 1)
            {
                character.Speed += 30;
                character.Speedstring += ", Fly 30ft";
            }
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("C-N");
            character.AlignmentOptions.Add("C-E");
            character.AdultAge = 18;
            character.MaxAgeStart = 80;
            character.Languages.Add("Infernal");

            if (input == 1)
            {
                character.Cantrips.Add("Thaumaturgy(Cha to cast)");
                character.TieflingMagic = "Infernal Legacy";
            }
            else if (input == 2)
            {
                character.Cantrips.Add("Vicious Mockery(Cha to cast)");
                character.TieflingMagic = "Devil's Tongue";
            }
        }
    }
}
