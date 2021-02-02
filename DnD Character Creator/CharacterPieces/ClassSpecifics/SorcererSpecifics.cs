using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class SorcererSpecifics
    {
        public static string SorcerousOrigin { get; set; }
        public static CharacterClass Features(CharacterClass result)
        {
            int lvl = result.Lvl;
            int sorceryPts = 2;

            string msg = "Pick a Sorcerous Origin that will give you features at levels 1, 6, 14, and 18.";
            var archetype = new List<string> { "Draconic Bloodline", "Wild Magic" };
            int answer = CLIHelper.PrintChoices(msg, archetype);

            if (answer == 0)
            {
                SorcerousOrigin = "Draconic";
                
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 18)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            else if (answer == 1)
            {
                SorcerousOrigin = "Wild";

                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 18)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            //else if (answer == 2)
            //{
            //    SorcerousOrigin = "";

            //    if (lvl >= 6)
            //    {
            //        result.ClassFeatures.Add("", "");
            //    }
            //    if (lvl >= 14)
            //    {
            //        result.ClassFeatures.Add("", "");
            //    }
            //    if (lvl >= 18)
            //    {
            //        result.ClassFeatures.Add("", "");
            //    }
            //}

            if (lvl >= 2)
            {

            }
            if (lvl >= 3)
            {

            }
            if (lvl >= 10)
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
                string spell = CLIHelper.GetNew(SorcererSpells.Cantrips, result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            for (int i = 1; i <= result.SpellsKnown; i++)
            {
                if (4 >= i && i >= 14 && i % 2 == 0)
                {
                    spellLvl++;
                }
                if (i == 13 || i == 15)
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
                string spell = CLIHelper.GetNew(spells.Sorcerer[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                result.Spells[spellLvl].Add(spell);
            }
            //end spells code

            return result;
        }
    }
}
