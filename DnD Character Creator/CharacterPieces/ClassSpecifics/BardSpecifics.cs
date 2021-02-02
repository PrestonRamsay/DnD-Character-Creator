using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class BardSpecifics
    {
        public static string BardicCollege { get; set; }
        public static CharacterClass Features(CharacterClass result, Character character)
        {
            int lvl = result.Lvl;

            result.ClassFeatures.Add("","");

            if (lvl >= 2)
            {

            }
            if (lvl >= 3)
            {
                string msg = "Pick a Bardic College that will give you features at levels 3, 6, and 14.";
                var archetype = new List<string> { "College of Lore", "College of Valor" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                if (answer == 0)
                {
                    BardicCollege = "Lore";

                    if (lvl >= 6)
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
                    BardicCollege = "Valor";

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                }
                //else if (answer == 2)
                //{
                //    if (lvl >= 6)
                //    {
                //        result.ClassFeatures.Add("", "");
                //    }
                //    if (lvl >= 14)
                //    {
                //        result.ClassFeatures.Add("", "");
                //    }
                //}
            }
            if (lvl >= 5)
            {

            }
            if (lvl >= 6)
            {

            }
            if (lvl >= 9)
            {

            }
            if (lvl >= 10)
            {

            }
            if (lvl >= 13)
            {

            }
            if (lvl >= 14)
            {

            }
            if (lvl >= 15)
            {

            }
            if (lvl >= 17)
            {

            }
            if (lvl >= 18)
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
                string spell = CLIHelper.GetNew(BardSpells.Cantrips, result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            for (int i = 1; i <= result.SpellsKnown; i++)
            {
                if (i > 5)
                {
                    if (i <= 13 && i % 2 == 0)
                    {
                        spellLvl++;
                    }
                    if (i == 15 || i == 16 || i == 19 || i == 20)
                    {
                        spellLvl++;
                    }
                }
                if (i == 6)
                {
                    pickMsg = "Pick a 2nd level spell.";
                }
                if (i == 8)
                {
                    pickMsg = "Pick a 3rd level spell.";
                }
                if (i >= 10)
                {
                    pickMsg = $"Pick a {spellLvl}th level spell.";
                }
                string spell = CLIHelper.GetNew(spells.Bard[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                result.Spells[spellLvl].Add(spell);
            }
            //end spells code

            return result;
        }
    }
}
