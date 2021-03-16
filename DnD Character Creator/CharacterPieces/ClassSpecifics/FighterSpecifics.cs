using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class FighterSpecifics
    {
        public static string MartialArchetype { get; set; }
        public static CharacterClass Features(CharacterClass result, Character character)
        {
            int lvl = result.Lvl;
            string actionSurge = "SR, you can take an additional action ontop of your action and bonus action";
            string indomitable = "LR, reroll a failed saving throw";
            string msg1 = "Pick a tool proficiency.";
            string msg2 = "You already have that tool proficiency";

            result.ClassFeatures.Add("Second Wind", "bonus, SR, heal 1D10+lvl HP");

            List<string> styleList = new List<string>();
            foreach (var style in Options.FightingStyles.Keys)
            {
                styleList.Add(style);
            }
            string fightStyleMsg = "Pick a fighting style.";
            int index = CLIHelper.PrintChoices(fightStyleMsg, styleList);
            string fightStyleKey = "Fighting Style";
            fightStyleKey += $"({styleList[index]})";
            result.ClassFeatures.Add(fightStyleKey, Options.FightingStyles[styleList[index]]);
            styleList.Remove(styleList[index]);

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Action Surge(1 use)", actionSurge);
            }
            if (lvl >= 3)
            {
                string msg = "Pick a Martial Archetype that will give you features at levels 3, 7, 10, 15, and 18.";
                var archetype = new List<string> { "Champion", "Battle Master", "Eldritch Knight" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                if (answer == 0)
                {
                    MartialArchetype = archetype[0];
                    result.ClassFeatures.Add("Improved Critical", "crit on 19 and 20");

                    if (lvl >= 7)
                    {
                        result.ClassFeatures.Add("Remarkable Athlete", "add 1/2 prof bonus to Str/Dex/Con checks that you don't have prof in." +
                            "\nIncrease your running long jump distance by Str mod ft");
                    }
                    if (lvl >= 10)
                    {
                        index = CLIHelper.PrintChoices(fightStyleMsg, styleList);
                        fightStyleKey = "Fighting Style";
                        fightStyleKey += $"({styleList[index]})";
                        result.ClassFeatures.Add(fightStyleKey, Options.FightingStyles[styleList[index]]);
                        styleList.Remove(styleList[index]);
                    }
                    if (lvl >= 15)
                    {
                        result.ClassFeatures.Remove("Improved Critical");
                        result.ClassFeatures.Add("Superior Critical", "crit on 18-20");
                    }
                    if (lvl >= 18)
                    {
                        result.ClassFeatures.Add("Survivor", "when bloodied, gain regen = 5 + Con mod");
                    }
                }
                else if (answer == 1)
                {
                    MartialArchetype = archetype[1];
                    result.ClassFeatures.Add("Student of War", "gain prof in a tool set");
                    string toolProf = CLIHelper.GetNew(Options.ArtisanTools, character.ToolProficiencies, msg1, msg2);
                    result.ToolProficiencies.Add(toolProf);

                    result.ClassFeatures.Add("Superiority Dice", "SR, 4D8");

                    string CmbtSuperiorityMsg = "You get 3 maneuvers now and 2 more at levels 7, 10, and 15.";
                    var maneuvers = new List<string> { "", "", "" };
                    foreach (var man in Options.Maneuvers.Keys)
                    {
                        maneuvers.Add(man);
                    }
                    int maneuver1 = CLIHelper.PrintChoices(CmbtSuperiorityMsg, maneuvers);
                    string maneuver = maneuvers[maneuver1];
                    result.ClassFeatures.Add("Maneuvers", "DC - Str/Dex + 8 + Prof Bonus");
                    result.ClassFeatures.Add(maneuver, Options.Maneuvers[maneuver]);
                    maneuvers.Remove(maneuver);
                    int maneuver2 = CLIHelper.PrintChoices(CmbtSuperiorityMsg, maneuvers);
                    maneuver = maneuvers[maneuver2];
                    result.ClassFeatures.Add(maneuver, Options.Maneuvers[maneuver]);
                    maneuvers.Remove(maneuver);
                    int maneuver3 = CLIHelper.PrintChoices(CmbtSuperiorityMsg, maneuvers);
                    maneuver = maneuvers[maneuver3];
                    result.ClassFeatures.Add(maneuver, Options.Maneuvers[maneuver]);
                    maneuvers.Remove(maneuver);

                    if (lvl >= 7)
                    {
                        int maneuver4 = CLIHelper.PrintChoices(CmbtSuperiorityMsg, maneuvers);
                        maneuver = maneuvers[maneuver4];
                        result.ClassFeatures.Add(maneuver, Options.Maneuvers[maneuver]);
                        maneuvers.Remove(maneuver);
                        int maneuver5 = CLIHelper.PrintChoices(CmbtSuperiorityMsg, maneuvers);
                        maneuver = maneuvers[maneuver5];
                        result.ClassFeatures.Add(maneuver, Options.Maneuvers[maneuver]);
                        maneuvers.Remove(maneuver);
                    }
                    if (lvl >= 10)
                    {
                        int maneuver6 = CLIHelper.PrintChoices(CmbtSuperiorityMsg, maneuvers);
                        maneuver = maneuvers[maneuver6];
                        result.ClassFeatures.Add(maneuver, Options.Maneuvers[maneuver]);
                        maneuvers.Remove(maneuver);
                        int maneuver7 = CLIHelper.PrintChoices(CmbtSuperiorityMsg, maneuvers);
                        maneuver = maneuvers[maneuver7];
                        result.ClassFeatures.Add(maneuver, Options.Maneuvers[maneuver]);
                        maneuvers.Remove(maneuver);
                    }
                    if (lvl >= 15)
                    {
                        int maneuver8 = CLIHelper.PrintChoices(CmbtSuperiorityMsg, maneuvers);
                        maneuver = maneuvers[maneuver8];
                        result.ClassFeatures.Add(maneuver, Options.Maneuvers[maneuver]);
                        maneuvers.Remove(maneuver);
                        int maneuver9 = CLIHelper.PrintChoices(CmbtSuperiorityMsg, maneuvers);
                        maneuver = maneuvers[maneuver9];
                        result.ClassFeatures.Add(maneuver, Options.Maneuvers[maneuver]);
                        maneuvers.Remove(maneuver);
                    }
                    if (lvl >= 7)
                    {
                        result.ClassFeatures.Add("Know Your Enemy", "study 1min, DM tells you =/</> in 2 traits: Str, Dex, Con, AC," +
                            "\ncurrent HP, lvl, fighter lvl(if any)");
                        result.ClassFeatures["Superiority Dice"] = "SR, 5D8";
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Remove("Superiority Dice");
                        result.ClassFeatures.Add("Improved Combat Superiority", "SR, 5D10");
                    }
                    if (lvl >= 15)
                    {
                        result.ClassFeatures.Add("Relentless", "on Init, if no superiority dice - regain 1");
                        result.ClassFeatures["Improved Combat Superiority"] = "SR, 6D10";
                    }
                    if (lvl >= 18)
                    {
                        result.ClassFeatures["Improved Combat Superiority"] = "SR, 6D12";
                    }
                }
                else if (answer == 2)
                {
                    MartialArchetype = archetype[2];
                    
                    result.ClassFeatures.Add("Weapon Bond", "1hr ritual to bond, can't be disarmed, bonus to teleport to hand, " +
                        "\ncan bond with 2 weapons(can only summon 1 at a time)");
                    result.ClassFeatures.Add("Spellcasting", "use Int for spell DCs, you use a component pouch to cast spells");

                    if (lvl >= 7)
                    {
                        result.ClassFeatures.Add("War Magic", "after casting cantrip, bonus, make wep atk");
                        
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("Eldritch Strike", "on wep hit, impose disadv on next save vs spell");
                    }
                    if (lvl >= 15)
                    {
                        result.ClassFeatures.Add("Arcane Charge", "teleport 30ft before/after Action Surge");
                    }
                    if (lvl >= 18)
                    {
                        result.ClassFeatures.Remove("War Magic");
                        result.ClassFeatures.Add("Improved War Magic", "after casting spell, bonus, make wep atk");
                    }

                    //spells
                    AllSpells spells = new AllSpells(character.ChosenClass);
                    result.Cantrips.AddRange(character.Cantrips);
                    result.CantripsKnown = 2;
                    result.SpellsKnown = 3;
                    int slotLvl = 1;
                    result.SpellSlots[1] += 2;
                    msg1 = "Pick a spell.";
                    msg2 = "You already have that spell";

                    string cantrip = CLIHelper.GetNew(spells.Wizard[0], result.Cantrips, msg1, msg2);
                    result.Cantrips.Add(cantrip);
                    spells.Wizard[0].Remove(cantrip);
                    cantrip = CLIHelper.GetNew(spells.Wizard[0], result.Cantrips, msg1, msg2);
                    result.Cantrips.Add(cantrip);
                    spells.Wizard[0].Remove(cantrip);
                    string spell = CLIHelper.GetNew(spells.Fighter[1], result.Spells[1], msg1, msg2);
                    result.Spells[1].Add(spell);
                    spells.Fighter[1].Remove(spell);
                    spell = CLIHelper.GetNew(spells.Fighter[1], result.Spells[1], msg1, msg2);
                    result.Spells[1].Add(spell);
                    spells.Fighter[1].Remove(spell);
                    spell = CLIHelper.GetNew(spells.Wizard[1], result.Spells[1], msg1, msg2);
                    result.Spells[1].Add(spell);
                    spells.Fighter[1].Remove(spell);

                    for (int i = 3; i <= lvl; i++)
                    {
                        //slots
                        if (i == 7 || i == 13)
                        {
                            slotLvl++;
                            result.SpellSlots[slotLvl] += 2;
                        }
                        if (i == 4|| i == 10 || i == 16)
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
                            spell = CLIHelper.GetNew(spells.Fighter[slotLvl], result.Spells[slotLvl], msg1, msg2);
                            result.Spells[slotLvl].Add(spell);
                            spells.Fighter[slotLvl].Remove(spell);
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
                            spell = CLIHelper.GetNew(spells.Fighter[slotLvl], result.Spells[slotLvl], msg1, msg2);
                            result.Spells[slotLvl].Add(spell);
                            spells.Fighter[slotLvl].Remove(spell);
                        }
                    }
                }
            }
            
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
            }
            if (lvl >= 9)
            {
                result.ClassFeatures.Add("Indomitable(1 use)", indomitable);
            }
            if (lvl >= 11)
            {
                result.ClassFeatures["Extra Attack"] = "When using an atk action, atk three times";
            }
            if (lvl >= 13)
            {
                result.ClassFeatures.Remove("Indomitable(1 use)");
                result.ClassFeatures.Add("Indomitable(2 uses)", indomitable);
            }
            if (lvl >= 17)
            {
                result.ClassFeatures.Remove("Action Surge(1 use)");
                result.ClassFeatures.Add("Action Surge(2 uses)", $"{actionSurge}(1/turn)");
                result.ClassFeatures.Remove("Indomitable(2 uses)");
                result.ClassFeatures.Add("Indomitable(3 uses)", indomitable);
            }
            if (lvl >= 20)
            {
                result.ClassFeatures["Extra Attack"] = "When using an atk action, atk four times";
            }

            return result;
        }
    }
}
