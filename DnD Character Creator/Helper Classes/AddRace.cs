using DnD_Character_Creator.CharacterPieces.Races;
using DnD_Character_Creator.CharacterPieces.Spells;
using System.Collections.Generic;

namespace DnD_Character_Creator.CLI_Classes
{
    public static class AddRace
    {
        public static void NewRace(Character character)
        {
            switch (character.ChosenRace)
            {
                case "Aasimar(Protector)":
                    Aasimar.Protector(character);
                    break;
                case "Aasimar(Scourge)":
                    Aasimar.Scourge(character);
                    break;
                case "Aasimar(Fallen)":
                    Aasimar.Fallen(character);
                    break;
                case "Cambion":
                    Cambion.Base(character);
                    break;
                case "Changeling":
                    Changeling.Base(character);
                    break;
                case "Dhampir":
                    Dhampir.Base(character);
                    break;
                case "Dragonborn":
                    Dragonborn.Base(character);
                    break;
                case "Hill Dwarf":
                    Dwarf.Hill(character);
                    break;
                case "Mountain Dwarf":
                    Dwarf.Mountain(character);
                    break;
                case "Avariel":
                    Elf.Avariel(character);
                    break;
                case "Drow":
                    Elf.Drow(character);
                    break;
                case "Eladrin":
                    Elf.Eladrin(character);
                    break;
                case "Moon Elf":
                    Elf.Moon(character);
                    break;
                case "Sea Elf":
                    Elf.Sea(character);
                    break;
                case "Shadar-Kai":
                    Elf.ShadarKai(character);
                    break;
                case "High Elf":
                    Elf.High(character);
                    break;
                case "Wild Elf":
                    Elf.Wild(character);
                    break;
                case "Wood Elf":
                    Elf.Wood(character);
                    break;
                case "Air Genasi":
                    Genasi.Air(character);
                    break;
                case "Earth Genasi":
                    Genasi.Earth(character);
                    break;
                case "Fire Genasi":
                    Genasi.Fire(character);
                    break;
                case "Water Genasi":
                    Genasi.Water(character);
                    break;
                case "Forest Gnome":
                    Gnome.Forest(character);
                    break;
                case "Rock Gnome":
                    Gnome.Rock(character);
                    break;
                case "Deep Gnome":
                    Gnome.Deep(character);
                    break;
                case "Goliath":
                    Goliath.Base(character);
                    break;
                case "Half-Elf":
                    HalfElf.Base(character);
                    break;
                case "Half-Orc":
                    HalfOrc.Base(character);
                    break;
                case "Lightfoot Halfling":
                    Halfling.Lightfoot(character);
                    break;
                case "Stout Halfling":
                    Halfling.Stout(character);
                    break;
                case "Human":
                    Human.Base(character);
                    break;
                case "Variant Human":
                    Human.Variant(character);
                    break;
                case "Minotaur":
                    Minotaur.Base(character);
                    break;
                case "Shade":
                    Shade.Base(character);
                    break;
                case "Tiefling":
                    Tiefling.Base(character);
                    break;
                case "Feral Tiefling":
                    Tiefling.Feral(character);
                    break;
                case "Demigod":
                    Demigod.Base(character);
                    break;
            }
        }
        public static void Spells(Character character)
        {
            string burningHands = "";

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
                case "Air Genasi":
                    string gustOfWind = "Gust of Wind(1/LR, Con to cast)";
                    string fly = "Fly(1/LR, Con to cast)";
                    HelpAddSpells(character, gustOfWind, fly);
                    break;
                case "Earth Genasi":
                    string meldwithStone = "Meld With Stone(1/LR, Con to cast)";
                    HelpAddSpells(character, meldwithStone);
                    break;
                case "Fire Genasi":
                    burningHands = "Burning Hands(1/LR, Con to cast)";
                    HelpAddSpells(character, burningHands);
                    break;
                case "Water Genasi":
                    string createDestroyWater = "Create/Destroy Water(1/LR, Con to cast)";
                    string wallOfWater = "Wall of Water(1/LR, Con to cast)";
                    HelpAddSpells(character, createDestroyWater, wallOfWater);
                    break;
                case "Forest Gnome":
                    string silentImage = "Silent Image(1/LR, Int to cast)";
                    HelpAddSpells(character, silentImage);
                    break;
                case "Tiefling":
                    if (character.TieflingMagic == "Infernal Legacy")
                    {
                        string hellishRebuke = "Hellish Rebuke(1/LR, Cha to cast)";
                        burningHands = "Burning Hands(1/LR, Cha to cast)";
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
                character.Spells[4].Add(str3);
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
                    spellList = new List<string> { "Cure Wounds(1/LR, Wis to cast)", "Healing Word(1/LR, Wis to cast)" };
                    index = CLIHelper.PrintChoices("Pick a spell", spellList);
                    spell = $"{spellList[index]}(1/LR, Wis to cast)";
                    string prayerOfHealing = "Prayer of Healing(1/LR, Wis to cast)";
                    HelpAddSpells(character, spell, prayerOfHealing);
                    break;
                case "Madness":
                    string tashasHideousLaughter = "Tasha's Hideous Laughter(1/LR, Cha to cast)";
                    string crownOfMadness = "Crown of Madness(1/LR, Cha to cast)";
                    HelpAddSpells(character, tashasHideousLaughter, crownOfMadness);
                    break;
                case "Magic":
                    string chromaticOrb = $"Chromatic Orb(1/LR, {character.CastingStat} to cast)";
                    string enhanceAbility = $"Enhance Ability(1/LR, {character.CastingStat} to cast)";
                    string counterspell = $"Counterspell(1/LR, {character.CastingStat} to cast)";
                    string dispelMagic = $"Dispel Magic(1/LR, {character.CastingStat} to cast)";
                    spellList = new List<string> { counterspell, dispelMagic };
                    spell = CLIHelper.PrintChoices(spellList);
                    HelpAddSpells(character, chromaticOrb, enhanceAbility, spell);
                    break;
                case "Music":
                    index = CLIHelper.PrintChoices("Pick a first level spell", BardSpells.FirstLvls);
                    spell = $"{BardSpells.FirstLvls[index]}(1/LR, Cha to cast)";
                    index = CLIHelper.PrintChoices("Pick a second level spell", BardSpells.SecondLvls);
                    string spell2 = $"{BardSpells.SecondLvls[index]}(1/LR, Cha to cast)";
                    HelpAddSpells(character, spell, spell2);
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
        public static void HigherLvlFeatures(Character character)
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
                        "\n        10ft - Cha save, fear & 1/turn - extra Necrotic dmg = lvl");
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
                    case "Fire Genasi":
                        character.RacialTraits.Add("Embody Flame*: 1/LR, 1 min, 10ft, if creature starts turn 1/2 lvl fire dmg");
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
                    character.RacialTraits[index] += "\n        enemies that move in the area take Wis dmg per 5ft";
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
