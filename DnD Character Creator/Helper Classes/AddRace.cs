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
            if (race.Size == "Small")
            {
                character.Size = race.Size;
            }
            character.Speed = race.Speed;
            character.Speedstring = race.Speedstring;
            character.Vision = race.Vision;
            //in cli the other traits are assigned
            character.SkillProficiencies.UnionWith(race.SkillProficiencies);
            character.ToolProficiencies.UnionWith(race.ToolProficiencies);
            character.Proficiencies.UnionWith(race.Proficiencies);
            character.Cantrips.AddRange(race.Cantrips);
            character.Feats.AddRange(race.Feats);
            character.DragonColor = race.DragonColor;
            character.TieflingMagic = race.TieflingMagic;
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
            character.Languages.UnionWith(race.Languages);
        }
        public static void AddSpells(Character character)
        {
            int lvl = character.Lvl;
            
            if (character.ChosenRace == "Drow")
            {
                if (lvl >= 3)
                {
                    string faerieFire = "Faerie Fire(1/LR, Cha to cast)";
                    character.Spells[1].Add(faerieFire);
                }
                if (lvl >= 5)
                {
                    string darkness = "Darkness(1/LR, Cha to cast)";
                    character.Spells[2].Add(darkness);
                }
            }
            else if (character.ChosenRace == "High Elf")
            {
                if (lvl >= 3)
                {
                    string detectMagic = "Detect Magic(1/LR, Int to cast)";
                    character.Spells[1].Add(detectMagic);
                }
            }
            else if (character.ChosenRace == "Wild Elf")
            {
                if (lvl >= 3)
                {
                    string animalFriendship = "Animal Friendship(1/LR, Wis to cast)";
                    character.Spells[1].Add(animalFriendship);
                }
            }
            else if (character.ChosenRace == "Forest Gnome")
            {
                if (lvl >= 3)
                {
                    string silentImage = "Silent Image(1/LR, Int to cast)";
                    character.Spells[1].Add(silentImage);
                }
            }
            else if (character.ChosenRace == "Tiefling")
            {
                if (character.TieflingMagic == "Infernal Legacy")
                {
                    if (lvl >= 3)
                    {
                        string hellishRebuke = "Hellish Rebuke(1/LR, Cha to cast)";
                        character.Spells[1].Add(hellishRebuke);
                    }
                    if (lvl >= 5)
                    {
                        string burningHands = "Burning Hands(1/LR, Cha to cast)";
                        character.Spells[2].Add(burningHands);
                    }
                }
                else if (character.TieflingMagic == "Devil's Tongue")
                {
                    if (lvl >= 3)
                    {
                        string charmPerson = "Charm Person(1/LR, Cha to cast)";
                        character.Spells[1].Add(charmPerson);
                    }
                    if (lvl >= 5)
                    {
                        string enthrall = "Entrall(1/LR, Cha to cast)";
                        character.Spells[2].Add(enthrall);
                    }
                }
            }
        }
        public static void AddHigherLvlFeature(Character character)
        {
            int lvl = character.Lvl;
            string race = character.ChosenRace;

            if (lvl >= 3)
            {
                if (race == "Protector Aasimar")
                {
                    character.RacialTraits.Add("Radiant Soul: action, 1/LR, 1 min - fly 30ft, 1/turn gain" +
                        "\n extra Radiant dmg = lvl");
                }
                else if (race == "Scourge Aasimar")
                {
                    character.RacialTraits.Add("Radiant Consumption: action, 1/LR, 1 min - 10ft, 1/2 lvl radiant dmg" +
                        "\n& 1/turn - extra Radiant dmg = lvl");
                }
                else if (race == "Fallen Aasimar")
                {
                    character.RacialTraits.Add("Necrotic Shroud: 1/LR, 1 min - grow ghostly, skeletal (flightless) wings" +
                        "\n10ft - Cha save, fear & 1/turn - extra Necrotic dmg = lvl");
                }
                else if (race == "Shadar-Kai")
                {
                    character.RacialTraits.Remove("Blessing of the Raven Queen: bonus, LR, teleport 30ft");
                    character.RacialTraits.Add("Blessing of the Raven Queen: bonus, LR, teleport 30ft & 1 round - resist all dmg");
                }
            }
        }
    }
}
