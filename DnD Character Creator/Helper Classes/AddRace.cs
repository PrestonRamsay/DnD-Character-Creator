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
        }
        public static void AddHeight(Character character, Race race)
        {            
            string height = CLIHelper.GetString();
            character.Height = CLIHelper.ConvertHeightToInches(height);
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
                race.Languages.AddRange(race.Languages);
                Console.WriteLine($"This race gets to know one language of your choice, enter it now. {Options.SeeOptions}");
                string input = Options.GetOption(Options.Languages);
                character.Languages.Add(input);
            }
            else
            {
                character.Languages.AddRange(race.Languages);
            }
        }
    }
}
