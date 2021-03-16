using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class RogueSpecifics
    {
        public static string RoguishArchetype { get; set; }
        public static CharacterClass Features(CharacterClass result, Character character)
        {
            int lvl = result.Lvl;
            int sneakAtkDice = 0;
            for (int i = 1; i <= lvl; i++)
            {
                if (i % 2 != 0)
                {
                    sneakAtkDice++;
                }
            }

            result.ClassFeatures.Add($"Sneak Attack({sneakAtkDice}D6)", "1/turn, if you have adv or tar is flanked, must use finesse or ranged wep");
            result.ClassFeatures.Add("Expertise","pick 2 skills, or 1 skill and 1 tool prof, double prof bonus");
            result.ClassFeatures.Add("Thieves' Cant", "secret thief language, speaking/writing takes 4x longer");
            character.Languages.Add("Thieves' Cant");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Cunning Action", "bonus, Dash, Disengage, or Hide");
            }
            if (lvl >= 3)
            {
                string msg = "Pick a Roguish Archetype that will give you features at levels 3, 9, 13, and 17.";
                var archetype = new List<string> { "Thief", "Assassin", "Arcane Trickster" };
                int input = CLIHelper.PrintChoices(msg, archetype);

                if (input == 0)
                {
                    RoguishArchetype = archetype[0];

                    if (lvl >= 3)
                    {
                        result.ClassFeatures.Add("Fast Hands", "bonus, Sleight of Hand check, use Thieves' Tools, or take the Use an Object action");
                        result.ClassFeatures.Add("Second-Story Work", "climbing doesn't cost extra movement, running jumps add Dex to distance");
                    }
                    if (lvl >= 9)
                    {
                        result.ClassFeatures.Add("Supreme Sneak", "adv on Stealth if you move no more than 1/2 speed");
                    }
                    if (lvl >= 13)
                    {
                        result.ClassFeatures.Add("Use Magic Device", "ignore all class, race, lvl requirements for magic items");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Theif's Reflexes", "during first round of combat take 2 turns - 2nd turn is at Init - 10");
                    }
                }
                else if (input == 1)
                {
                    RoguishArchetype = archetype[1];

                    if (lvl >= 3)
                    {
                        character.Proficiencies.Add("Disguise Kit");
                        character.Proficiencies.Add("Poisoner's Kit");
                        result.ClassFeatures.Add("Assassinate", "adv on atk vs creatures that haven't taken a turn yet, surprise = crit");
                    }
                    if (lvl >= 9)
                    {
                        result.ClassFeatures.Add("Infiltration Expertise", "spend 7 days & 25gp, establish alternate identity");
                    }
                    if (lvl >= 13)
                    {
                        result.ClassFeatures.Add("Impostor", "spend 3hr observing to mimic speech, writing, behavior of another, adv on Deception vs detection");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Death Strike", "when you hit a surprised creature, Dex-based DC Con save to double dmg");
                    }
                }
                else if (input == 2)
                {
                    RoguishArchetype = archetype[2];

                    if (lvl >= 3)
                    {
                        result.ClassFeatures.Add("Mage Hand Legerdemain", "bonus, when you cast Mage Hand, make hand invisible and - stow or retrieve an object carried or worn" +
                            "\nby another creature, use Thieves' Tools at a range - Sleight of Hand check vs creature to notice");
                    }
                    if (lvl >= 9)
                    {
                        result.ClassFeatures.Add("Magical Ambush", "if hidden when you cast a spell, enemy has disadv");
                    }
                    if (lvl >= 13)
                    {
                        result.ClassFeatures.Add("Versatile Trickster", "bonus, use Mage Hand to gain adv on atk");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Spell Thief", "LR, reaction, when enemy casts a spell, spell save - they lost the spell, you gain it");
                    }

                    //spells
                    AllSpells spells = new AllSpells(character.ChosenClass);
                    result.Cantrips.AddRange(character.Cantrips);
                    result.CantripsKnown = 2;
                    result.SpellsKnown = 3;
                    int slotLvl = 1;
                    result.SpellSlots[1] += 2;
                    string msg1 = "Pick a spell.";
                    string msg2 = "You already have that spell";

                    string cantrip = CLIHelper.GetNew(spells.Wizard[0], result.Cantrips, msg1, msg2);
                    result.Cantrips.Add(cantrip);
                    spells.Wizard[0].Remove(cantrip);
                    cantrip = CLIHelper.GetNew(spells.Wizard[0], result.Cantrips, msg1, msg2);
                    result.Cantrips.Add(cantrip);
                    spells.Wizard[0].Remove(cantrip);
                    string spell = CLIHelper.GetNew(spells.Rogue[1], result.Spells[1], msg1, msg2);
                    result.Spells[1].Add(spell);
                    spells.Rogue[1].Remove(spell);
                    spell = CLIHelper.GetNew(spells.Rogue[1], result.Spells[1], msg1, msg2);
                    result.Spells[1].Add(spell);
                    spells.Rogue[1].Remove(spell);
                    spell = CLIHelper.GetNew(spells.Wizard[1], result.Spells[1], msg1, msg2);
                    result.Spells[1].Add(spell);
                    spells.Rogue[1].Remove(spell);

                    for (int i = 3; i <= lvl; i++)
                    {
                        //slots
                        if (i == 7 || i == 13)
                        {
                            slotLvl++;
                            result.SpellSlots[slotLvl] += 2;
                        }
                        if (i == 4 || i == 10 || i == 16)
                        {
                            result.SpellSlots[slotLvl]++;
                        }
                        if (i == 19)
                        {
                            slotLvl++;
                            result.SpellSlots[4] += 1;
                        }
                        //known and add spells
                        if (i == 10)
                        {
                            character.CantripsKnown++;
                            cantrip = CLIHelper.GetNew(spells.Wizard[0], character.Cantrips, msg1, msg2);
                            result.Cantrips.Add(cantrip);
                            spells.Wizard[0].Remove(cantrip);
                            result.SpellsKnown++;
                            spell = CLIHelper.GetNew(spells.Rogue[slotLvl], result.Spells[slotLvl], msg1, msg2);
                            result.Spells[slotLvl].Add(spell);
                            spells.Rogue[slotLvl].Remove(spell);
                        }
                        if (i == 8 || i == 14 || i == 20)
                        {
                            result.SpellsKnown++;
                            spell = CLIHelper.GetNew(spells.Wizard[slotLvl], result.Spells[slotLvl], msg1, msg2);
                            result.Spells[slotLvl].Add(spell);
                            spells.Wizard[slotLvl].Remove(spell);
                        }
                        if (i == 4 || i == 7 || i == 11 || i == 13 || i == 16 || i == 19)
                        {
                            result.SpellsKnown++;
                            spell = CLIHelper.GetNew(spells.Rogue[slotLvl], result.Spells[slotLvl], msg1, msg2);
                            result.Spells[slotLvl].Add(spell);
                            spells.Rogue[slotLvl].Remove(spell);
                        }
                    }
                }
            }
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Uncanny Dodge", "reaction, 1/2 dmg");
            }
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Expertise II", "pick 2 skills, or 1 skill and 1 tool prof, double prof bonus");
            }
            if (lvl >= 7)
            {
                result.ClassFeatures.Add("Evasion", "Dex saves = 1/2 or no dmg");
            }
            if (lvl >= 11)
            {
                result.ClassFeatures.Add("Reliable Talent", "when you roll below 10 on a skill that you are prof in, you can treat that roll as a 10");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Blindsense", "if you can hear, you know the location of hidden or invisible creatures within 10ft");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures.Add("Slippery Mind", "gain prof in Wis saves");
                character.Saves.Add("Wis");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Elusive", "no atk has adv while you're not incap");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Stroke of Luck", "1/SR, make an atk hit or an ability check roll a 20");
            }

            return result;
        }
    }
}
