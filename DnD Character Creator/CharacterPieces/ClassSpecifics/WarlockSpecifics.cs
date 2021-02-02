using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class WarlockSpecifics
    {
        public static string OtherworldlyPatron { get; set; }
        public static Dictionary<int, List<string>> ExpandedSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
        };
        public static CharacterClass Features(CharacterClass result)
        {
            int lvl = result.Lvl;
            int invocations = 2;
            string msg = "Pick an Otherworldly Patron that will give you features at levels 1, 6, 10, and 14.";
            var archetype = new List<string> { "Archfey", "Fiend", "The Great Old One" };
            int answer = CLIHelper.PrintChoices(msg, archetype);

            if (answer == 0)
            {
                OtherworldlyPatron = archetype[0];
                ExpandedSpells[1].Add("*");
                ExpandedSpells[1].Add("*");
                ExpandedSpells[2].Add("*");
                ExpandedSpells[2].Add("*");
                ExpandedSpells[3].Add("*");
                ExpandedSpells[3].Add("*");
                ExpandedSpells[4].Add("*");
                ExpandedSpells[4].Add("*");
                ExpandedSpells[5].Add("*");
                ExpandedSpells[5].Add("*");

                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 10)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            else if (answer == 1)
            {
                OtherworldlyPatron = archetype[0];
                ExpandedSpells[1].Add("*");
                ExpandedSpells[1].Add("*");
                ExpandedSpells[2].Add("*");
                ExpandedSpells[2].Add("*");
                ExpandedSpells[3].Add("*");
                ExpandedSpells[3].Add("*");
                ExpandedSpells[4].Add("*");
                ExpandedSpells[4].Add("*");
                ExpandedSpells[5].Add("*");
                ExpandedSpells[5].Add("*");

                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 10)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            else if (answer == 2)
            {
                OtherworldlyPatron = "Great Old One";
                ExpandedSpells[1].Add("*");
                ExpandedSpells[1].Add("*");
                ExpandedSpells[2].Add("*");
                ExpandedSpells[2].Add("*");
                ExpandedSpells[3].Add("*");
                ExpandedSpells[3].Add("*");
                ExpandedSpells[4].Add("*");
                ExpandedSpells[4].Add("*");
                ExpandedSpells[5].Add("*");
                ExpandedSpells[5].Add("*");

                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 10)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures.Add("", "");
                }
            }

            if (lvl >= 2)
            {

            }
            if (lvl >= 3)
            {

            }
            if (lvl >= 11)
            {

            }
            if (lvl >= 13)
            {

            }
            if (lvl >= 15)
            {

            }
            if (lvl >= 17)
            {

            }
            if (lvl >= 20)
            {

            }
            //spells code
            string pickMsg = "Pick a cantrip.";
            string str2 = "You already have that cantrip.";
            int spellLvl = 1;
            AllSpells spells = new AllSpells();
            for (int i = 0; i < result.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(WarlockSpells.Cantrips, result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            for (int i = 1; i <= result.SpellsKnown; i++)
            {
                if (4 >= i && i >= 10 && i % 2 == 0)
                {
                    spellLvl++;
                }
                if (i == 4)
                {
                    pickMsg = "Pick a 2nd level spell.";
                }
                if (i == 6)
                {
                    pickMsg = "Pick a 3rd level spell.";
                }
                if (i >= 8)
                {
                    pickMsg = $"Pick a {spellLvl}th level spell.";
                }
                string spell = CLIHelper.GetNew(spells.Warlock[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                result.Spells[spellLvl].Add(spell);
            }
            //end spells code

            return result;
        }
    }
}
