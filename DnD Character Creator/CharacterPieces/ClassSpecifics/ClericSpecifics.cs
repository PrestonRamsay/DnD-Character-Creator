using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class ClericSpecifics
    {
        public static string DivineDomain { get; set; }
        public static Dictionary<int, List<string>> DomainSpells { get; set; } = new Dictionary<int, List<string>>()
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

            string msg = "Pick a Divine Domain that will give you features at levels 2, 6, 8, and 17.";
            var archetype = new List<string> { "Ice", "Knowledge", "Life", "Light", "Nature", "Tempest", "Trickery", "War" };
            int input = CLIHelper.PrintChoices(msg, archetype);

            if (input == 0)
            {
                DivineDomain = archetype[0];
                DomainSpells[1].Add("*");
                DomainSpells[1].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[5].Add("*");
                DomainSpells[5].Add("*");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            else if (input == 1)
            {
                DivineDomain = archetype[1];
                DomainSpells[1].Add("*");
                DomainSpells[1].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[5].Add("*");
                DomainSpells[5].Add("*");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            else if (input == 2)
            {
                DivineDomain = archetype[2];
                DomainSpells[1].Add("*");
                DomainSpells[1].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[5].Add("*");
                DomainSpells[5].Add("*");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            if (input == 3)
            {
                DivineDomain = archetype[3];
                DomainSpells[1].Add("*");
                DomainSpells[1].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[5].Add("*");
                DomainSpells[5].Add("*");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            else if (input == 4)
            {
                DivineDomain = archetype[4];
                DomainSpells[1].Add("*");
                DomainSpells[1].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[5].Add("*");
                DomainSpells[5].Add("*");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            else if (input == 5)
            {
                DivineDomain = archetype[5];
                DomainSpells[1].Add("*");
                DomainSpells[1].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[5].Add("*");
                DomainSpells[5].Add("*");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            if (input == 6)
            {
                DivineDomain = archetype[6];
                DomainSpells[1].Add("*");
                DomainSpells[1].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[5].Add("*");
                DomainSpells[5].Add("*");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            else if (input == 7)
            {
                DivineDomain = archetype[7];
                DomainSpells[1].Add("*");
                DomainSpells[1].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[2].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[3].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[4].Add("*");
                DomainSpells[5].Add("*");
                DomainSpells[5].Add("*");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("", "");
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("", "");
                }
            }
            result.Spells[1].AddRange(DomainSpells[1]);

            if (lvl >= 2)
            {
                
            }
            if (lvl >= 3)
            {
                result.Spells[1].AddRange(DomainSpells[2]);
            }
            if (lvl >= 5)
            {
                result.Spells[1].AddRange(DomainSpells[3]);
            }
            if (lvl >= 6)
            {

            }
            if (lvl >= 7)
            {
                result.Spells[1].AddRange(DomainSpells[4]);
            }
            if (lvl >= 8)
            {

            }
            if (lvl >= 9)
            {
                result.Spells[1].AddRange(DomainSpells[5]);
            }
            if (lvl >= 10)
            {

            }
            if (lvl >= 11)
            {

            }
            if (lvl >= 14)
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
                string spell = CLIHelper.GetNew(ClericSpells.Cantrips, result.Cantrips, pickMsg, str2);
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
                        string spell2 = CLIHelper.GetNew(spells.Cleric[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                        result.Spells[spellLvl].Add(spell2);
                    }
                    if (lvl >= 13)
                    {
                        string spell2 = CLIHelper.GetNew(spells.Cleric[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                        result.Spells[spellLvl].Add(spell2);
                    }
                }
                if (lvl <= 11)
                {
                    string spell = CLIHelper.GetNew(spells.Cleric[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                    result.Spells[spellLvl].Add(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
