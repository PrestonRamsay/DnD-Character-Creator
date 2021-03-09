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

            result.ClassFeatures.Add("Arcane Recovery", "1/day after SR, gain spell slots <= 1/2 lvl, no lvl 6 slots or higher");

            if (lvl >= 2)
            {
                string msg = "Pick an Arcane Tradition that will give you features at levels 2, 6, 10, and 14.";
                var archetype = new List<string> { "Abjuration", "Conjuration", "Divination", "Enchantment", "Evocation", "Illusion", "Necromancy", "Transmutation" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                if (answer == 0)
                {
                    ArcaneTradition = archetype[0];
                    result.ClassFeatures.Add("Abjuration Savant", "gold/time to copy an Abjuration spell into your spellbook is halved");
                    result.ClassFeatures.Add("Arcane Ward", "when you cast an Abjuration spell, create ward with HP = lvl x 2 + Int");

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Projected Ward", "reaction, ally you can see takes dmg, use Arcane Ward on ally instead of self");
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("Improved Abjuration", "add prof bonus to Abjuartion spell checks");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Spell Resistance", "adv on saves vs spells, Resistance to spell dmg");
                    }
                }
                else if (answer == 1)
                {
                    ArcaneTradition = archetype[1];
                    result.ClassFeatures.Add("Conjuration Savant", "gold/time to copy a Conjuration spell into your spellbook is halved");
                    result.ClassFeatures.Add("Minor Conjuration", "action, 10ft, creation for 1 hr, no larger than 3ft, no heavier than 10 lbs, visibily magical");

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Benign Transposition", "1/LR (or until cast Conjuration spell), action, teleport 30ft or swap places with ally");
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("Focused Conjuration", "Conjuration concentration spells can't be broken due to taking dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Durable Summons", "creatures you create gain 30 temp HP");
                    }
                }
                else if (answer == 2)
                {
                    ArcaneTradition = archetype[2];
                    result.ClassFeatures.Add("Divination Savant", "gold/time to copy a Divination spell into your spellbook is halved");
                    result.ClassFeatures.Add("Portent", "LR, roll 2D20s - replace any atk, save, check");

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Expert Divination", "when you cast a lvl 2 or higher Divination spell, regain a spell slot of 5th or lower");
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("The Third Eye", "1/SR - gain Darkvision, Ethereal Sight, Greater Comprehension, or See Invisibilty");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Remove("Portent");
                        result.ClassFeatures.Add("Greater Portent", "LR, roll 3D20s - replace any atk, save, check");
                    }
                }

                if (answer == 3)
                {
                    ArcaneTradition = archetype[3];
                    result.ClassFeatures.Add("Enchantment Savant", "gold/time to copy an Enchantment spell into your spellbook is halved");
                    result.ClassFeatures.Add("Hypnotic Gaze", "action, 5ft, Wis save, charm, incap, dazed - end if 5ft+ away, sustain each turn");

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Instinctive Charm", "reaction, 30ft, Wis save, choose new target");
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("Split Enchantment", "non-cantrip Enchantment spells can effect 2 targets");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Alter Memories", "charmed creatures are unaware of being charmed" +
                            "\naction, Int save, lose memories for 1 + Cha hr while charmed");
                    }
                }
                else if (answer == 4)
                {
                    ArcaneTradition = archetype[4];
                    result.ClassFeatures.Add("Evocation Savant", "gold/time to copy an Evocation spell into your spellbook is halved");
                    result.ClassFeatures.Add("Sculpt Spells", "choose 1 + spell lvl to auto-succeed on saves against your spell and take no dmg");

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Potent Cantrip", "success vs cantrip = 1/2 dmg");
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("Empowered Evocation", "+Int dmg to Evocation spells");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Overchannel", "max dmg for spells 1st-5th, if used before LR take 2D12/spell lvl + 1D12 per spell lvl for additional uses");
                    }
                }
                else if (answer == 5)
                {
                    ArcaneTradition = archetype[5];
                    result.ClassFeatures.Add("Illusion Savant", "gold/time to copy an Illusion spell into your spellbook is halved");
                    result.ClassFeatures.Add("Improved Minor Illusion", "you can create sound and image simultaneously");

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Malleable Illusions", "if Illusion has duration > 1 min, action to alter the Illusion");
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("Illusory Self", "reaction, SR, create double, atk misses, illusion dissipates");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Illusory Reality", "bonus, 1 min, choose 1 inanimate, nonmagical object in illusion - make it real");
                    }
                }
                if (answer == 6)
                {
                    ArcaneTradition = archetype[6];
                    result.ClassFeatures.Add("Necromancy Savant", "gold/time to copy a Necromancy spell into your spellbook is halved");
                    result.ClassFeatures.Add("Grim Harvest", "1/turn, when kill, regain HP = spell lvl x 2 or x 3 if its Necromancy spell");

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Undead Thralls", "when cast Animate Dead, undead get - HP + lvl, dmg + prof bonus");
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("Inured to Undeath", "gain Resistance to necrotic, max HP can't be reduced");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Command Undead", "action, Cha save, if Int 8+ adv, if Int 12+ it can save every hr");
                    }
                }
                else if (answer == 7)
                {
                    ArcaneTradition = archetype[7];
                    result.ClassFeatures.Add("Transmutation Savant", "gold/time to copy a Transmutation spell into your spellbook is halved");
                    result.ClassFeatures.Add("Minor Alchemy", "10 min = 1ft, 1 hr, change one substance to another (wood, stone - not gems, iron, copper, or silver)");

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Transmuter's Stone", "gain Darkvision, speed + 10ft, prof in Con saves, or Resistance to cold, fire, lightning, or thunder" +
                            "\nwhen you cast a Transmutation spell, you can change the effect");
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("Shapechanger", "add Polymorph to spellbook, can cast it (SR) without expending a slot to change into a beast CR 1 or lower");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Master Transmuter", "action, destroy transmuter's stone to - transform 5ft object into another, remove all disease/curses/poisons/heal full HP," +
                            "\ncast Raise Dead, or reduce creature's appearance by 3D10 yr (min 13 yr)");
                    }
                }
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Spell Mastery", "pick a 1st and 2nd lvl spell to cast at-will without expending a spell slot");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Signature Spells", "pick two 3rd lvl spells to cast 1/SR without expending a spell slot");
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
