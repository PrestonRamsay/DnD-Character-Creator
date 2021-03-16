using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
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
            int bardicInspiration = 6;
            int songOfRest = 6;

            for (int i = 0; i <= lvl; i++)
            {
                if (i == 5 || i == 10 || i == 15)
                {
                    bardicInspiration += 2;
                }
                if (i == 9 || i == 13 || i == 17)
                {
                    songOfRest += 2;
                }
            }

            result.ClassFeatures.Add($"Bardic Inspiration(D{bardicInspiration})","Cha/LR, bonus, 60ft, use on ally, add to atk, save, or ability check");
            result.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use a musical instrument as a spell focus");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Jack of All Trades", "add 1/2 prof bonus to untrained skills");
                result.ClassFeatures.Add($"Song of Rest(D{songOfRest})", "regain HP of yourself or allies during SR");
            }
            if (lvl >= 3)
            {
                string msg = "Pick a Bardic College that will give you features at levels 3, 6, and 14.";
                var archetype = new List<string> { "College of Lore", "College of Valor" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                result.ClassFeatures.Add("Expertise", "pick 2 skills, or 1 skill and 1 tool prof, double prof bonus");

                if (answer == 0)
                {
                    BardicCollege = "Lore";

                    msg = "Pick 3 skills to gain proficiency in";
                    string errorMsg = "You are already trained in that skill, pick a different skill.";
                    for (int i = 0; i < 3; i++)
                    {
                        string skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, msg, errorMsg);
                        character.SkillProficiencies.Add(skill);
                    }

                    result.ClassFeatures.Add("Cutting Words", "60ft, minus Bardic Inspiration from atk, dmg, ability check");

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Additional Magical Secrets", "gain 2 new spells from any class (pick them separately)");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Peerless Skill", "use Bardic Inspiration on self for an ability check");
                    }
                }
                else if (answer == 1)
                {
                    BardicCollege = "Valor";

                    character.Proficiencies.Add("Medium Armor");
                    character.Proficiencies.Add("Shields");
                    character.Proficiencies.Add("Martial Weapons");
                    result.ClassFeatures.Add("Combat Inspiration", "after Bardic Inspiration use - add to dmg or use reaction to add to AC");

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Battle Magic", "bonus, when you cast a spell, make wep atk");
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
                result.ClassFeatures.Add("Font of Inspiration", "regain Bardic Inspiration from SR");
            }
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Countercharm", "action, 30ft, you and allies, adv vs fear and charm effects");
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Magical Secrets", "gain 2 new spells from any class (pick them separately)");
                result.ClassFeatures.Add("Expertise II", "pick 2 skills, or 1 skill and 1 tool prof, double prof bonus");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Magical Secrets II", "gain 2 new spells from any class (pick them separately)");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Magical Secrets III", "gain 2 new spells from any class (pick them separately)");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Superior Inspiration", "on Init, if you have no Bardic Inspiration - regain 1 use");
            }
            //spells code
            string pickMsg = "Pick a cantrip.";
            string str2 = "You already have that cantrip.";
            int spellLvl = 1;
            AllSpells spells = new AllSpells(character.ChosenClass);

            for (int i = 0; i < result.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(spells.Bard[0], result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
                spells.Bard[0].Remove(spell);
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
                if (i != 13 || i != 14 || i != 17 || i != 18 || i != 21 || i != 22)
                {
                    string spell = CLIHelper.GetNew(spells.Bard[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                    result.Spells[spellLvl].Add(spell);
                    spells.Bard[spellLvl].Remove(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
