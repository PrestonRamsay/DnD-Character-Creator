using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class WizardSpecifics
    {
        public static string ArcaneTradition { get; set; }
        public static CharacterClass Features(CharacterClass result)
        {
            int lvl = result.Lvl;

            result.ClassFeatures.Add("","");

            if (lvl >= 2)
            {
                string msg = "Pick an Arcane Tradition that will give you features at levels 2, 6, 10, and 14.";
                var archetype = new List<string> { "Abjuration", "Conjuration", "Divination", "Enchantment", "Evocation", "Illusion", "Necromancy", "Transmutation" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                if (answer == 0)
                {
                    ArcaneTradition = archetype[0];
                    
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
                    ArcaneTradition = archetype[1];

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
                    ArcaneTradition = archetype[2];

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

                if (answer == 3)
                {
                    ArcaneTradition = archetype[3];

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
                else if (answer == 4)
                {
                    ArcaneTradition = archetype[4];

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
                else if (answer == 5)
                {
                    ArcaneTradition = archetype[5];

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
                if (answer == 6)
                {
                    ArcaneTradition = archetype[6];

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
                else if (answer == 7)
                {
                    ArcaneTradition = archetype[7];

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
                string spell = CLIHelper.GetNew(WizardSpells.Cantrips, result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            for (int i = 1; i <= lvl; i++)
            {
                if (3 <= i && i <= 17 && i % 2 != 0)
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
                string spell = CLIHelper.GetNew(spells.Wizard[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                result.Spells[spellLvl].Add(spell);
                string spell2 = CLIHelper.GetNew(spells.Wizard[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                result.Spells[spellLvl].Add(spell2);
            }
            //end spells code

            return result;
        }
    }
}
