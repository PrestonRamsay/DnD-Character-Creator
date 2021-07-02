using DnD_Character_Creator.Helper_Classes;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Dragonborn
    {
        public static void Base(Character character)
        {
            string msg = "Pick a dragon color for your ancestry";
            List<string> colorList = new List<string> { "Black", "Blue", "Brass", "Bronze", "Copper", "Gold", "Green",
                "Red", "Silver", "White" };
            int index = CLIHelper.PrintChoices(msg, colorList);
            string color = colorList[index];
            character.DragonColor = color;
            string dmgType = "";
            string shape = "";

            if (color == "Black" || color == "Copper")
            {
                dmgType = "Acid";
                shape = "5 by 30ft line";
            }
            else if (color == "Blue" || color == "Bronze")
            {
                dmgType = "Lightning";
                shape = "5 by 30ft line";
            }
            else if (color == "Brass")
            {
                dmgType = "Fire";
                shape = "5 by 30ft line";
            }
            else if (color == "Gold" || color == "Red")
            {
                dmgType = "Fire";
                shape = "15ft cone";
            }
            else if (color == "Green")
            {
                dmgType = "Poison";
                shape = "15ft cone";
            }
            else if (color == "Silver" || color == "White")
            {
                dmgType = "Cold";
                shape = "15ft cone";
            }

            character.RacialTraits.Add($"Damage Resistance: gain Resistance to {dmgType}");
            character.RacialTraits.Add($"Breath Weapon: 3D8 + (1D8 per 5 lvls above 1st) dmg, {shape} of {dmgType} - Dex save" +
                $"\n        recharge SR, Con-based DC");
            character.RacialTraits.Add("Bite - 1D6 Piercing");
            character.MinHeight = 75;
            character.MaxHeight = 81;
            character.MinWeight = 200;
            character.MaxWeight = 350;
            character.Speed += 30;
            character.Vision = "Lowlight 60ft";
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("TN");
            character.AlignmentOptions.Add("N-E");
            character.AdultAge = 15;
            character.MaxAgeStart = 80;
            character.Languages.Add("Draconic");
        }
    }
}
