using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using DnD_Character_Creator.Races;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CLI_Classes
{
    public static class AddRace
    {
        public static void RacialSpecifics(Character character, Race race)
        {
            character.RacialTraits.AddRange(race.RacialTraits);

            character.Str += race.RacialStr;
            character.Dex += race.RacialDex;
            character.Con += race.RacialCon;
            character.Int += race.RacialInt;
            character.Wis += race.RacialWis;
            character.Cha += race.RacialCha;
            
            character.Age = CLIHelper.GetNumberInRange(race.AdultAge, race.MaxAgeStart + 50);
            character.SkillProficiencies.AddRange(race.SkillProficiencies);
            character.ToolProficiencies.AddRange(race.ToolProficiencies);
            character.Proficiencies.AddRange(race.Proficiencies);
            character.Cantrips.AddRange(race.Cantrips);
            character.Feats.AddRange(race.Feats);
            character.DragonColor = race.DragonColor;
        }
        public static void AddHeight(Character character, Race race)
        {
            string height = Console.ReadLine().Trim();
            bool gettingheight = true;

            while (gettingheight)
            {
                if (!height.Contains("\""))
                {
                    Console.WriteLine("Format error, try again.");
                    height = Console.ReadLine().Trim();
                }
                else
                {
                    gettingheight = false;
                }
            }
            
            character.Height = ConvertHeightToInches(height);
        }
        public static int ConvertHeightToInches(string heightString)
        {
            string[] height = heightString.Split(new char[] { '\'' });
            string secondNumber = "";
            int quoteIndex = height[1].IndexOf("\"");
            secondNumber = height[1].Substring(0, quoteIndex);

            int feet = int.Parse(height[0]) * 12;
            int inches = int.Parse(secondNumber);
            int heightInInches = feet + inches;

            return heightInInches;
        }
        public static void AddWeight(Character character, Race race)
        {                        
            character.Weight = CLIHelper.GetNumberInRange(race.MinWeight, race.MaxWeight);
            character.Speed = race.Speed;
            character.Vision = race.Vision;
        }
        public static void AddLanguages(Character character, Race race)
        {
            if (race.Languages.Contains("Choice"))
            {
                race.Languages.Remove("Choice");
                string msg = "This race gets to know one language of your choice, pick it now.";
                string errorMsg = "You already know that language, try again.";
                string input = CLIHelper.GetNew(Options.Languages, race.Languages, msg, errorMsg);
                race.Languages.Add(input);
            }
            character.Languages.AddRange(race.Languages);
        }
        public static void AddSpells(Character character)
        {
            if (character.ChosenRace == "Drow")
            {
                if (character.Lvl >= 3)
                {
                    string faerieFire = "Faerie Fire(1/day, use Cha to cast)";
                    character.Cantrips.Add(faerieFire);
                }
                if (character.Lvl >= 5)
                {
                    string darkness = "Darkness(1/day, use Cha to cast)";
                    character.Spells[1].Add(darkness);
                }
            }
            else if (character.ChosenRace == "Tiefling")
            {
                if (character.Lvl >= 3)
                {
                    string charmPerson = "Charm Person(1/long rest, use Cha to cast)";
                    character.Cantrips.Add(charmPerson);
                }
                if (character.Lvl >= 5)
                {
                    string enthrall = "Entrall(1/long rest, use Cha to cast)";
                    character.Spells[1].Add(enthrall);
                }
            }
        }
    }
}
