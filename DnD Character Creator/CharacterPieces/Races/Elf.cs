using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Elf
    {
        public static void Avariel(Character character)
        {
            character.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            character.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\n        After resting in such a way, you gain the benefits of a long rest");
            character.RacialTraits.Add("Aerial Reach: melee reach +5ft");
            character.MinHeight = 60;
            character.MaxHeight = 76;
            character.MinWeight = 120;
            character.MaxWeight = 180;
            character.Speed += 30;
            character.Speedstring += ", Fly 40ft";
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("C-G");
            character.AlignmentOptions.Add("C-N");
            character.AdultAge = 100;
            character.MaxAgeStart = 750;
            character.Languages.Add("Elven");
            character.Languages.Add("Auran");
            character.SkillProficiencies.Add("Perception");
            character.Proficiencies.Add("Spear");
            character.Proficiencies.Add("Shortbows");
            character.Proficiencies.Add("Net");
            character.Proficiencies.Add("Longbows");
        }
        public static void Drow(Character character)
        {
            character.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            character.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            character.RacialTraits.Add("Sunlight Sensitivity: suffer disadv on atks and sight Perception checks when you or target is in sunlight");
            character.MinHeight = 60;
            character.MaxHeight = 72;
            character.MinWeight = 120;
            character.MaxWeight = 180;
            character.Speed += 30;
            character.Vision = "Superior Darkvision 120ft";
            character.AlignmentOptions.Add("C-N");
            character.AlignmentOptions.Add("N-E");
            character.AlignmentOptions.Add("C-E");
            character.AdultAge = 100;
            character.MaxAgeStart = 750;
            character.Languages.Add("Elven");
            character.Languages.Add("Undercommon");
            character.SkillProficiencies.Add("Perception");
            character.Proficiencies.Add("Shortswords");
            character.Proficiencies.Add("Rapiers");
            character.Proficiencies.Add("Hand Crossbows");
            character.Cantrips.Add("Dancing Lights(Cha to cast)");
        }
        public static void Eladrin(Character character)
        {
            character.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            character.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            character.RacialTraits.Add("Fey Step: SR, bonus, teleport 30ft & seasonal effect(Cha-based DC)" +
                "\n        Autumn - 2 creatures within 10ft, Wis save, charm 1 turn" +
                "\n        Spring - teleport adj creature within 30ft instead of yourself" +
                "\n        Summer - creatures you can see within 5ft take Cha Fire dmg" +
                "\n        Winter - 1 creature within 5ft, Wis save, fear 1 turn");
            character.MinHeight = 60;
            character.MaxHeight = 76;
            character.MinWeight = 120;
            character.MaxWeight = 180;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("C-G");
            character.AlignmentOptions.Add("C-N");
            character.AdultAge = 100;
            character.MaxAgeStart = 750;
            character.Languages.Add("Elven");
            character.SkillProficiencies.Add("Perception");
        }
        public static void Moon(Character character)
        {
            character.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            character.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            character.MinHeight = 60;
            character.MaxHeight = 72;
            character.MinWeight = 120;
            character.MaxWeight = 180;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("C-G");
            character.AlignmentOptions.Add("C-N");
            character.AdultAge = 100;
            character.MaxAgeStart = 750;
            character.Languages.Add("Elven");
            BEHelper.AddLanguage(character, "race");
            character.SkillProficiencies.Add("Perception");
            var skills = new List<string> { "Deception", "Investigation", "Persuasion", "Stealth" };
            string pickMsg = "Pick 2 skills from the list";
            for (int i = 0; i < 2; i++)
            {
                string skill = CLIHelper.GetNew(skills, character.SkillProficiencies, pickMsg);
                Console.WriteLine($"You've picked: {skill}");
            }
            character.Proficiencies.Add("Shortswords");
            character.Proficiencies.Add("Shortbows");
            character.Proficiencies.Add("Longswords");
            character.Proficiencies.Add("Longbows");
            int index = CLIHelper.PrintChoices("Pick a cantrip from the Wizard's spell list.", WizardSpells.Cantrips);
            string cantrip = WizardSpells.Cantrips[index];
            character.Cantrips.Add($"{cantrip}(Int to cast)");
        }
        public static void Sea(Character character)
        {
            character.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            character.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            character.RacialTraits.Add("Waterbreathing");
            character.RacialTraits.Add("Friend of the Sea: communicate basic ideas with water creatures");
            character.MinHeight = 60;
            character.MaxHeight = 72;
            character.MinWeight = 120;
            character.MaxWeight = 180;
            character.Speed += 30;
            character.Speedstring += ", Swim 30ft";
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("C-G");
            character.AdultAge = 100;
            character.MaxAgeStart = 750;
            character.Languages.Add("Elven");
            character.Languages.Add("Aquan");
            character.SkillProficiencies.Add("Perception");
            character.Proficiencies.Add("Spear");
            character.Proficiencies.Add("Trident");
            character.Proficiencies.Add("Light Crossbow");
            character.Proficiencies.Add("Net");
        }
        public static void ShadarKai(Character character)
        {
            character.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            character.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            character.RacialTraits.Add("Blessing of the Raven Queen: bonus, LR, teleport 30ft");
            character.RacialTraits.Add("Servant of Shadow: Resistance to Necrotic");
            character.MinHeight = 60;
            character.MaxHeight = 72;
            character.MinWeight = 120;
            character.MaxWeight = 180;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AlignmentOptions.Add("N-G");
            character.AdultAge = 100;
            character.MaxAgeStart = 750;
            character.Languages.Add("Elven");
            character.SkillProficiencies.Add("Perception");
        }
        public static void High(Character character)
        {
            character.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            character.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            character.MinHeight = 60;
            character.MaxHeight = 72;
            character.MinWeight = 120;
            character.MaxWeight = 180;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AlignmentOptions.Add("N-G");
            character.AdultAge = 100;
            character.MaxAgeStart = 750;
            character.Languages.Add("Elven");
            BEHelper.AddLanguage(character, "race");
            character.SkillProficiencies.Add("Perception");
            character.Proficiencies.Add("Shortswords");
            character.Proficiencies.Add("Shortbows");
            character.Proficiencies.Add("Longswords");
            character.Proficiencies.Add("Longbows");
            int index = CLIHelper.PrintChoices("Pick a cantrip from the Wizard's spell list.", WizardSpells.Cantrips);
            string cantrip = WizardSpells.Cantrips[index];
            character.Cantrips.Add($"{cantrip}(Int to cast)");
        }
        public static void Wild(Character character)
        {
            character.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            character.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            character.MinHeight = 60;
            character.MaxHeight = 72;
            character.MinWeight = 120;
            character.MaxWeight = 180;
            character.Speed += 30;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AlignmentOptions.Add("N-G");
            character.AdultAge = 100;
            character.MaxAgeStart = 750;
            character.Languages.Add("Elven");
            BEHelper.AddLanguage(character, "race");
            character.SkillProficiencies.Add("Perception");
            character.Proficiencies.Add("Spear");
            character.Proficiencies.Add("Shortbows");
            character.Proficiencies.Add("Net");
            character.Proficiencies.Add("Longbows");
            int index = CLIHelper.PrintChoices("Pick a cantrip from the Druid's spell list.", DruidSpells.Cantrips);
            string cantrip = DruidSpells.Cantrips[index];
            character.Cantrips.Add($"{cantrip}(Wis to cast)");
        }
        public static void Wood(Character character)
        {
            character.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            character.RacialTraits.Add("Trance: you don't need sleep, meditate semiconscious for 4hr to gain benefits of LR");
            character.RacialTraits.Add("Mask of the Wild: you can attempt to hide even when you are only lightly obscured " +
                "\n        by foliage, heavy rain, falling snow, mist, and other natural phenomena.");
            character.MinHeight = 60;
            character.MaxHeight = 72;
            character.MinWeight = 120;
            character.MaxWeight = 180;
            character.Speed += 35;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("C-G");
            character.AlignmentOptions.Add("C-N");
            character.AdultAge = 100;
            character.MaxAgeStart = 750;
            character.Languages.Add("Elven");
            character.SkillProficiencies.Add("Perception");
            character.SkillProficiencies.Add("Stealth");
            character.Proficiencies.Add("Shortswords");
            character.Proficiencies.Add("Shortbows");
            character.Proficiencies.Add("Longswords");
            character.Proficiencies.Add("Longbows");
        }
    }
}
