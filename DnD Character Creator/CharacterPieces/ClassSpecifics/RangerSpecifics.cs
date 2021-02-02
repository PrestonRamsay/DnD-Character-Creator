using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class RangerSpecifics
    {
        public static string RangerArchetype { get; set; }
        public static CharacterClass Features(CharacterClass result)
        {
            int lvl = result.Lvl;

            result.ClassFeatures.Add("","");

            if (lvl >= 2)
            {
                string fightStyleMsg = "Pick a fighting style.";
                List<string> styleList = new List<string>();
                foreach (var style in Options.FightingStyles.Keys)
                {
                    if (style != "Great Weapon Fighting" && style != "Protection")
                    {
                        styleList.Add(style);
                    }
                }
                int input = CLIHelper.PrintChoices(fightStyleMsg, styleList);
                string fightStyleKey = "Fighting Style";
                fightStyleKey += $"({styleList[input]})";
                result.ClassFeatures.Add(fightStyleKey, Options.FightingStyles[styleList[input]]);
            }
            if (lvl >= 3)
            {
                string msg = "Pick a Ranger Archetype that will give you features at levels 3, 7, 11, and 15.";
                var archetype = new List<string> { "Hunter", "Beast Master" };
                int input = CLIHelper.PrintChoices(msg, archetype);

                if (input == 0)
                {
                    RangerArchetype = archetype[0];

                    if (lvl >= 3)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 7)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 11)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 15)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                }
                else if (input == 1)
                {
                    RangerArchetype = archetype[1];

                    if (lvl >= 3)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 7)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 11)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 15)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                }
                //else if (input == 2)
                //{
                //    RangerArchetype = archetype[2];

                //if (lvl >= 3)
                //{
                //    result.ClassFeatures.Add("", "");
                //}
                //if (lvl >= 7)
                //{
                //    result.ClassFeatures.Add("", "");
                //}
                //if (lvl >= 11)
                //{
                //    result.ClassFeatures.Add("", "");
                //}
                //if (lvl >= 15)
                //{
                //    result.ClassFeatures.Add("", "");
                //}
                //}
            }
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
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
            if (lvl >= 20)
            {

            }
            //spells code
            string str2 = "You already have that spell";
            string pickMsg = "Pick a 1st level spell.";
            AllSpells spells = new AllSpells();
            foreach (var slotLvl in result.SpellSlots.Keys)
            {
                if (slotLvl == 2)
                {
                    pickMsg = "Pick a 2nd level spell.";
                }
                if (slotLvl == 3)
                {
                    pickMsg = "Pick a 3rd level spell.";
                }
                if (slotLvl >= 4)
                {
                    pickMsg = $"Pick a {slotLvl}th level spell.";
                }
                int slots = result.SpellSlots[slotLvl];
                for (int i = 0; i < slots; i++)
                {
                    string spell = CLIHelper.GetNew(spells.Ranger[slotLvl], result.Spells[slotLvl], pickMsg, str2);
                    result.Spells[slotLvl].Add(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
