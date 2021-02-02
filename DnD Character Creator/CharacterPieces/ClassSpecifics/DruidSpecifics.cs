using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class DruidSpecifics
    {
        public static string DruidCircle { get; set; }
        public static CharacterClass Features(CharacterClass result)
        {
            int lvl = result.Lvl;

            result.ClassFeatures.Add("","");

            if (lvl >= 2)
            {
                string msg = "Pick a Druid Circle that will give you features at levels 2, 6, 10, and 14.";
                var archetype = new List<string> { "Circle of the Land", "Circle of the Moon" };
                int input = CLIHelper.PrintChoices(msg, archetype);

                if (input == 0)
                {
                    DruidCircle = "Land";

                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("", "");
                    }
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
                else if (input == 1)
                {
                    DruidCircle = "Moon";

                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("", "");
                    }
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
                //else if (input == 2)
                //{
                //    DruidCircle = "";

                //    if (lvl >= 2)
                //    {
                //        result.ClassFeatures.Add("", "");
                //    }
                //    if (lvl >= 6)
                //    {
                //        result.ClassFeatures.Add("", "");
                //    }
                //    if (lvl >= 10)
                //    {
                //        result.ClassFeatures.Add("", "");
                //    }
                //    if (lvl >= 14)
                //    {
                //        result.ClassFeatures.Add("", "");
                //    }
                //}
            }
            if (lvl >= 4)
            {

            }
            if (lvl >= 6)
            {

            }
            if (lvl >= 8)
            {

            }
            if (lvl >= 10)
            {

            }
            if (lvl >= 14)
            {

            }
            if (lvl >= 18)
            {

            }
            if (lvl >= 19)
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
                string spell = CLIHelper.GetNew(DruidSpells.Cantrips, result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            for (int i = 1; i <= lvl; i++)
            {
                if (i % 2 != 0)
                {
                    if (3 <= i && i <= 17)
                    {
                        spellLvl++;
                    }
                    if (i == 3)
                    {
                        pickMsg = "Pick a 2nd level spell.";
                    }
                    if (i == 5)
                    {
                        pickMsg = "Pick a 3rd level spell.";
                    }
                    if (i >= 7)
                    {
                        pickMsg = $"Pick a {spellLvl}th level spell.";
                    }
                    if (lvl <= 5)
                    {
                        string spell2 = CLIHelper.GetNew(spells.Druid[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                        result.Spells[spellLvl].Add(spell2);
                    }
                    if (lvl >= 13)
                    {
                        string spell2 = CLIHelper.GetNew(spells.Druid[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                        result.Spells[spellLvl].Add(spell2);
                    }
                }
                if (lvl <= 11)
                {
                    string spell = CLIHelper.GetNew(spells.Druid[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                    result.Spells[spellLvl].Add(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
