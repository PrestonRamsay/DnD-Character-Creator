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
        public static CharacterClass Features(CharacterClass result, Character character)
        {
            int lvl = result.Lvl;
            result.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use an Arcane Focus as a spell focus");
            
            string msg = "Pick a Sorcerous Origin that will give you features at levels 1, 6, 14, and 18.";
            var archetype = new List<string> { "Draconic Bloodline", "Wild Magic" };
            int answer = CLIHelper.PrintChoices(msg, archetype);

            if (answer == 0)
            {
                SorcerousOrigin = "Draconic";
                character.Languages.Add("Draconic");

                msg = "Pick a color for your draconic ancestry";
                List<string> colorList = new List<string> { "Black", "Blue", "Brass", "Bronze", "Copper", "Gold", "Green",
                "Red", "Silver", "White" };
                int index = CLIHelper.PrintChoices(msg, colorList);
                string color = colorList[index];
                string dmgType = "";

                if (color == "Black" || color == "Copper")
                {
                    dmgType = "Acid";
                }
                else if (color == "Blue" || color == "Bronze")
                {
                    dmgType = "Lightning";
                }
                else if (color == "Brass")
                {
                    dmgType = "Fire";
                }
                else if (color == "Gold" || color == "Red")
                {
                    dmgType = "Fire";
                }
                else if (color == "Green")
                {
                    dmgType = "Poison";
                }
                else if (color == "Silver" || color == "White")
                {
                    dmgType = "Cold";
                }
                result.ClassFeatures.Add("Dragon Ancestor", $"double prof bonus on Cha checks when interacting with {color} Dragons");
                result.ClassFeatures.Add("Draconic Resilience", "increase HP by 1 per lvl, AC = 13 + Dex");
                character.HP += lvl;
                character.AC += 3;

                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Elemental Affinity", $"when you cast a spell that deals {dmgType} dmg, add Cha to dmg, spend 1 sorcery pt" +
                        $"\nto gain Resistance to {dmgType} for 1 hr");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures.Add("Dragon Wings", "bonus, sprout wings with fly speed = land speed");
                }
                if (lvl >= 18)
                {
                    result.ClassFeatures.Add("Draconic Presence", "action, 5 sorcery pts, 60ft, Wis save or fear");
                }
            }
            else if (answer == 1)
            {
                SorcerousOrigin = "Wild";
                result.ClassFeatures.Add("Wild Surge", "after casting a spell, roll D20 if its 1 - roll on Wild Magic table");
                result.ClassFeatures.Add("Tides of Chaos", "1/LR, gain adv on atk, save, check - before regaining use roll on Wild Magic table to regain use");

                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Bend Luck", "reaction, 2 sorcery pt, +/- 1D4 to atk, save, check of enemy or ally you can see");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures.Add("Controlled Chaos", "when you roll on Wild Magic table roll twice and use either result");
                }
                if (lvl >= 18)
                {
                    result.ClassFeatures.Add("Spell Bombardment", "1/turn when you roll max on a die, reroll it and add both results");
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
            int sorceryPts = lvl;
            var metamagic = new List<string> { "Careful Spell", "Distant Spell", "Empowered Spell", "Extended Spell", "Heightened Spell", "Quicken Spell", "Sudden Spell", "Twinned Spell" };

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Font of Magic", $"you have {sorceryPts} sorcery pts and Flexible Casting" +
                    "\n1st = 2pts" +
                    "\n2nd = 3pts" +
                    "\n3rd = 5pts" +
                    "\n4th = 6pts" +
                    "\n5th = 7pts");
            }
            if (lvl >= 3)
            {
                msg = "You get 2 metamagic options of your choice";
                int index = CLIHelper.PrintChoices(msg, metamagic);
                string choice1 = metamagic[index];
                metamagic.Remove(choice1);
                index = CLIHelper.PrintChoices(msg, metamagic);
                string choice2 = metamagic[index];
                metamagic.Remove(choice2);
                result.ClassFeatures.Add("Metamagic", $"{choice1}, {choice2}");
            }
            if (lvl >= 10)
            {
                msg = "Pick a new metamagic option";
                int index = CLIHelper.PrintChoices(msg, metamagic);
                string choice1 = metamagic[index];
                metamagic.Remove(choice1);
                result.ClassFeatures["Metamagic"] += $", {choice1}";
            }
            if (lvl >= 17)
            {
                msg = "Pick a new metamagic option";
                int index = CLIHelper.PrintChoices(msg, metamagic);
                string choice1 = metamagic[index];
                metamagic.Remove(choice1);
                result.ClassFeatures["Metamagic"] += $", {choice1}";
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Sorcerous Restoration", "gain 4 sorcery pt from SR");
            }
            //spells code
            string pickMsg = "Pick a cantrip.";
            string str2 = "You already have that cantrip.";
            for (int i = 0; i < result.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(SorcererSpells.Cantrips, result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            int spellLvl = 1;
            AllSpells spells = new AllSpells(character.ChosenClass);
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
                spells.Sorcerer[spellLvl].Remove(spell);
            }
            //end spells code

            return result;
        }
    }
}
