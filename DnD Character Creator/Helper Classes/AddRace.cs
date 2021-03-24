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
            if (race.ToolProficiencies.Contains("Musical Instrument"))
            {
                race.ToolProficiencies.Remove("Musical Instrument");
                string msg = "Pick a musical instrument you'd like to be proficient with.";
                int index = CLIHelper.PrintChoices(msg, Options.MusicalInstruments);
                race.ToolProficiencies.Add(Options.MusicalInstruments[index]);
            }
            if (race.ToolProficiencies.Contains("Artisan's Tools"))
            {
                race.ToolProficiencies.Remove("Artisan's Tools");
                string msg = "Pick a set of Artisan's Tools you'd like to be proficient with.";
                int index = CLIHelper.PrintChoices(msg, Options.ArtisanTools);
                race.ToolProficiencies.Add(Options.ArtisanTools[index]);
            }
            if (race.ToolProficiencies.Contains("Gaming Set"))
            {
                race.ToolProficiencies.Remove("Gaming Set");
                string msg = "Pick a gaming set you'd like to be proficient with.";
                int index = CLIHelper.PrintChoices(msg, Options.GamingSets);
                race.ToolProficiencies.Add(Options.GamingSets[index]);
            }
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
            string msg = "";
            string errorMsg = "You already know that language, try again.";
            if (!race.Languages.Contains("Choice2"))
            {
                msg = "This race gets to know one language of your choice, pick it now.";
            }
            if (race.Languages.Contains("Choice2"))
            {
                race.Languages.Remove("Choice2");
                msg = "This race gets to know two languages of your choice, pick them now.";
                string input = CLIHelper.GetNew(Options.Languages, race.Languages, msg, errorMsg);
                race.Languages.Add(input);
            }
            if (race.Languages.Contains("Choice"))
            {
                race.Languages.Remove("Choice");
                string input = CLIHelper.GetNew(Options.Languages, race.Languages, msg, errorMsg);
                race.Languages.Add(input);
            }
            character.Languages.UnionWith(race.Languages);
        }
        public static void AddSpells(Character character)
        {
            switch (character.ChosenRace)
            {
                case "Cambion":
                    string command = "Command(1/LR, Cha to cast)";
                    string alterSelf = "Alter Self(1/LR, Cha to cast)";
                    HelpAddSpells(character, command, alterSelf);
                    break;
                case "Demigod":
                    DemigodSpells(character);
                    break;
                case "Drow":
                    string faerieFire = "Faerie Fire(1/LR, Cha to cast)";
                    string darkness = "Darkness(1/LR, Cha to cast)";
                    HelpAddSpells(character, faerieFire, darkness);
                    break;
                case "High Elf":
                    string detectMagic = "Detect Magic(1/LR, Int to cast)";
                    HelpAddSpells(character, detectMagic);
                    break;
                case "Wild Elf":
                    string animalFriendship = "Animal Friendship(1/LR, Wis to cast)";
                    HelpAddSpells(character, animalFriendship);
                    break;
                case "Forest Gnome":
                    string silentImage = "Silent Image(1/LR, Int to cast)";
                    HelpAddSpells(character, silentImage);
                    break;
                case "Tiefling":
                    if (character.TieflingMagic == "Infernal Legacy")
                    {
                        string hellishRebuke = "Hellish Rebuke(1/LR, Cha to cast)";
                        string burningHands = "Burning Hands(1/LR, Cha to cast)";
                        HelpAddSpells(character, hellishRebuke, burningHands);
                    }
                    else if (character.TieflingMagic == "Devil's Tongue")
                    {
                        string charmPerson = "Charm Person(1/LR, Cha to cast)";
                        string enthrall = "Entrall(1/LR, Cha to cast)";
                        HelpAddSpells(character, charmPerson, enthrall);
                    }
                    break;
            }
        }
        public static void HelpAddSpells(Character character, string str1)
        {
            int lvl = character.Lvl;
            if (lvl >= 3)
            {
                character.Spells[1].Add(str1);
            }
        }
        public static void HelpAddSpells(Character character, string str1, string str2)
        {
            int lvl = character.Lvl;
            if (lvl >= 3)
            {
                character.Spells[1].Add(str1);
            }
            if (lvl >= 5)
            {
                character.Spells[2].Add(str2);
            }
        }
        public static void HelpAddSpells(Character character, string str1, string str2, string str3)
        {
            int lvl = character.Lvl;
            if (lvl >= 3)
            {
                character.Spells[1].Add(str1);
            }
            if (lvl >= 5)
            {
                character.Spells[3].Add(str2);
            }
            if (lvl >= 7)
            {
                character.Spells[4].Add(str2);
            }
        }
        public static void DemigodSpells(Character character)
        {
            int index = -1;
            string spell = "";
            var spellList = new List<string>();
            switch (character.DemigodDomain)
            {
                case "Beauty":
                    string charmPerson = "Charm Person(1/LR, Cha to cast)";
                    string enthrall = "Entrall(1/LR, Cha to cast)";
                    HelpAddSpells(character, charmPerson, enthrall);
                    break;
                case "Knowledge":
                    string comprehendLang = "Comprehend Languages(1/LR, Int to cast)";
                    index = CLIHelper.PrintChoices("Pick a second level spell", WizardSpells.SecondLvls);
                    spell = WizardSpells.SecondLvls[index];
                    HelpAddSpells(character, comprehendLang, spell);
                    break;
                case "Life":
                    var list = new List<string> { "Cure Wounds(1/LR, Wis to cast)", "Healing Word(1/LR, Wis to cast)" };
                    index = CLIHelper.PrintChoices("Pick a spell", list);
                    spell = $"{list[index]}(1/LR, Wis to cast)";
                    string prayerOfHealing = "Prayer of Healing(1/LR, Wis to cast)";
                    HelpAddSpells(character, spell, prayerOfHealing);
                    break;
                case "Music":
                    index = CLIHelper.PrintChoices("Pick a first level spell", BardSpells.FirstLvls);
                    spell = $"{BardSpells.FirstLvls[index]}(1/LR, Cha to cast)";
                    index = CLIHelper.PrintChoices("Pick a second level spell", BardSpells.SecondLvls);
                    string spell2 = $"{BardSpells.SecondLvls[index]}(1/LR, Cha to cast)";
                    HelpAddSpells(character, spell, spell2);
                    break;
                case "Madness":
                    string tashasHideousLaughter = "Tasha's Hideous Laughter(1/LR, Cha to cast)";
                    string crownOfMadness = "Crown of Madness(1/LR, Cha to cast)";
                    HelpAddSpells(character, tashasHideousLaughter, crownOfMadness);
                    break;
                case "Protection":
                    string sanctuary = "Sanctuary(1/LR, Cha to cast)";
                    string wardingBond = "Warding Bond(1/LR, Cha to cast)";
                    HelpAddSpells(character, sanctuary, wardingBond);
                    break;
                case "The Earth":
                    string earthTremor = "Earth Tremor(1/LR, Wis to cast)";
                    string barkskin = "Barkskin(1/LR, Wis to cast)";
                    HelpAddSpells(character, earthTremor, barkskin);
                    break;
                case "The Hunt":
                    string huntersMark = "Hunter's Mark(1/LR, Wis to cast)";
                    string cordonOfArrows = "Cordon of Arrows(1/LR, Wis to cast)";
                    HelpAddSpells(character, huntersMark, cordonOfArrows);
                    break;
                case "The Sea":
                    string createDestroyWater = "Create or Destroy Water(1/LR, Int to cast)";
                    string tidalWave = "Tidal Wave(1/LR, Int to cast)";
                    string controlWater = "Control Water(1/LR, Int to cast)";
                    HelpAddSpells(character, createDestroyWater, tidalWave, controlWater);
                    break;
                case "The Sun":
                    string guidingBolt = "Guiding Bolt(1/LR, Cha to cast)";
                    string daylight = "Daylight(1/LR, Cha to cast)";
                    HelpAddSpells(character, guidingBolt, daylight);
                    break;
                case "Travel":
                    string expeditiousRetreat = "Expeditious Retreat(1/LR, Wis to cast)";
                    string mistyStep = "Misty Step(1/LR, Wis to cast)";
                    HelpAddSpells(character, expeditiousRetreat, mistyStep);
                    break;
                case "Trickery":
                    string disguiseSelf = "Disguise Self(1/LR, Int to cast)";
                    string invisibility = "Invisibility(1/LR, Int to cast)";
                    string silence = "Silence(1/LR, Int to cast)";
                    string darkness = "Darkness(1/LR, Int to cast)";
                    spellList = new List<string> { invisibility, silence, darkness };
                    spell = CLIHelper.PrintChoices(spellList);
                    HelpAddSpells(character, disguiseSelf, spell);
                    break;
                case "Undead":
                    string inflictWounds = "Inflict Wounds(1/LR, Int or Wis to cast)";
                    string rayOfEnfeeblement = "Ray of Enfeeblement(1/LR, Int or Wis to cast)";
                    string shadowBlade = "Shadowblade(1/LR, Int or Wis to cast)";
                    spellList = new List<string> { rayOfEnfeeblement, shadowBlade };
                    spell = CLIHelper.PrintChoices(spellList);
                    HelpAddSpells(character, inflictWounds, spell);
                    break;
            }
        }
        public static void AddHigherLvlFeature(Character character)
        {
            if (character.Lvl >= 3)
            {
                switch (character.ChosenRace)
                {
                    case "Aasimar(Protector)":
                        character.RacialTraits.Add("Radiant Soul: LR, action, 1 min - fly 30ft, 1/turn gain extra Radiant dmg = lvl");
                        break;
                    case "Aasimar(Scourge)":
                        character.RacialTraits.Add("Radiant Consumption: LR, action, 1 min - 10ft, 1/2 lvl Radiant dmg & 1/turn - extra Radiant dmg = lvl");
                        break;
                    case "Aasimar(Fallen)":
                        character.RacialTraits.Add("Necrotic Shroud: LR, 1 min - grow ghostly, skeletal (flightless) wings" +
                        "\n10ft - Cha save, fear & 1/turn - extra Necrotic dmg = lvl");
                        break;
                    case "Cambion":
                        if (character.Alignment == "L-E")
                        {
                            character.RacialTraits.Add("Fiendish Gaze: 1/SR, Charm Person, Cha to cast");
                        }
                        else if (character.Alignment == "C-E")
                        {
                            character.RacialTraits.Add("Fiendish Savagery: 1/SR, no action, gain adv on atks this turn");
                        }
                        break;
                    case "Demigod":
                        DemigodHigherLvls(character);
                        break;
                    case "Dhampir":
                        character.RacialTraits.Add("Vampiric Gaze: 1/SR, Charm Person, Cha to cast");
                        break;
                    case "Shadar-Kai":
                        character.RacialTraits.Remove("Blessing of the Raven Queen: bonus, LR, teleport 30ft");
                        character.RacialTraits.Add("Blessing of the Raven Queen: bonus, LR, teleport 30ft & 1 round - resist all dmg");
                        break;
                }
            }
            if (character.Lvl >= 5)
            {
                if (character.DemigodDomain == "Travel")
                {
                    int index = -1;
                    foreach (var item in character.RacialTraits)
                    {
                        if (item.Contains("Child of Travel"))
                        {
                            index = character.RacialTraits.IndexOf(item);
                        }
                    }
                    character.RacialTraits[index] += ", gain fly speed";
                    character.Speedstring = $", Fly {character.Speed}ft";
                }
            }
        }
        public static void DemigodHigherLvls(Character character)
        {
            int index = -1;
            switch (character.DemigodDomain)
            {
                case "The Earth":
                    foreach (var item in character.RacialTraits)
                    {
                        if (item.Contains("Child of Nature"))
                        {
                            index = character.RacialTraits.IndexOf(item);
                        }
                    }
                    character.RacialTraits[index] += "\nenemies that move in the area take Wis dmg per 5ft";
                    break;
                case "The Sky":
                    foreach (var item in character.RacialTraits)
                    {
                        if (item.Contains("Child of the Sky"))
                        {
                            index = character.RacialTraits.IndexOf(item);
                        }
                    }
                    character.RacialTraits[index] += ", gain fly speed";
                    character.Speedstring = $", Fly {character.Speed}ft";
                    break;
                case "Travel":
                    foreach (var item in character.RacialTraits)
                    {
                        if (item.Contains("Child of Travel"))
                        {
                            index = character.RacialTraits.IndexOf(item);
                        }
                    }
                    character.RacialTraits[index] += ", gain swim speed";
                    character.Speedstring = $", Swim {character.Speed}ft";
                    break;
            }
        }
    }
}
