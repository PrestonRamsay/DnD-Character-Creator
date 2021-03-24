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

            string fightStyleMsg = "Pick a fighting style.";
            List<string> styleList = new List<string>();
            foreach (var style in Options.FightingStyles.Keys)
            {
                if (style != "Blessed Warrior" || style != "Druidic Warrior")
                {
                    styleList.Add(style);
                }
            }
            string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
            string fightStyleKey = $"Fighting Style({fightStyle})";
            string fightStyleValue = Options.FightingStyles[fightStyle];
            if (fightStyle == "Superior Technique")
            {
                List<string> maneuvers = CLIHelper.GetDictionaryOptions(Options.Maneuvers, 1, "Pick a maneuver");
                string man = maneuvers[0];
                fightStyleValue += man;
            }
            result.ClassFeatures.Add(fightStyleKey, fightStyleValue);
            styleList.Remove(fightStyle);

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Action Surge(1 use)", actionSurge);
            }
            if (lvl >= 3)
            {
                string msg = "Pick a Martial Archetype that will give you features at levels 3, 7, 10, 15, and 18.";
                var archetype = new List<string> { "Arcane Archer", "Battle Master", "Cavalier", "Champion", "Echo Knight*", "Eldritch Knight",
                    "Psi Warrior*", "Purple Dragon Knight", "Rune Knight*", "Samurai" };
                int answer = CLIHelper.PrintChoices(msg, archetype);
                MartialArchetype = archetype[answer];

                switch (MartialArchetype)
                {
                    case "Arcane Archer":
                        result.ClassFeatures.Add("Arcane Archer Lore", "gain prof in Arcana or Nature, gain Prestidigitation or Druidcraft");
                        Console.WriteLine("Arcane Archer Lore: gain prof in Arcana or Nature, gain Prestidigitation or Druidcraft");
                        var skills = new List<string> { "Arcana", "Nature" };
                        var cantrips = new List<string> { "Prestidigitation", "Druidcraft" };
                        string skill = CLIHelper.PrintChoices(skills);
                        string cantrip = CLIHelper.PrintChoices(cantrips);
                        result.SkillProficiencies.Add(skill);
                        result.Cantrips.Add(cantrip);

                        int options = 2;
                        for (int i = 7; i <= lvl; i += 3)
                        {
                            options++;
                            if (i == 10)
                            {
                                i += 2;
                            }
                        }
                        List<string> pickedOptions = CLIHelper.GetDictionaryOptions(Options.ArcaneShotOptions, options, "Pick an arcane shot option");
                        result.ClassFeatures.Add("Arcane Shot", $"({options} options) 2/SR, 1/turn, part of Attack action, longbow/shortbow, Int-based DC");
                        foreach (var item in pickedOptions)
                        {
                            result.ClassFeatures["Arcane Shot"] += $"\n{item}({Options.ArcaneShotOptions[item]})";
                        }
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Magic Arrow", "all ranged atks are considered magical");
                            result.ClassFeatures.Add("Curving Shot", "bonus, 60ft, when you miss an atk, reroll atk vs new target");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Ever-Ready Shot", "on Init, if no Arcane Shot uses, regain 1 use");
                        }
                        if (lvl >= 18)
                        {
                            result.ClassFeatures.Remove("Arcane Shot");
                            result.ClassFeatures.Add("Arcane Shot", $"({options} options) 2/SR, 1/turn, part of Attack action, longbow/shortbow, Int-based DC");
                            foreach (var item in pickedOptions)
                            {
                                result.ClassFeatures["Arcane Shot"] += $"\n{item}({Options.ArcaneShotOptionsImp[item]})";
                            }
                        }
                        break;
                    case "Battle Master":
                        result.ClassFeatures.Add("Student of War", "gain prof in a tool set");
                        string toolProf = CLIHelper.GetNew(Options.ArtisanTools, character.ToolProficiencies, msg1, msg2);
                        result.ToolProficiencies.Add(toolProf);
                        int supDice = 4;
                        for (int i = 7; i <= lvl; i += 8)
                        {
                            supDice++;
                        }
                        int dieCat = 8;
                        for (int i = 10; i <= lvl; i += 8)
                        {
                            dieCat += 2;
                        }
                        result.ClassFeatures.Add("Combat Superiority", $"Maneuvers - Str or Dex-based DC, Superiority Dice - {supDice}D{dieCat}/SR");
                        Console.WriteLine("You get 3 maneuvers now and 2 more at levels 7, 10, and 15.");
                        int man = 3;
                        for (int i = 7; i <= lvl; i += 3)
                        {
                            if (lvl <= 15)
                            {
                                man++;
                                if (i == 10)
                                {
                                    i += 2;
                                }
                            }
                        }
                        List<string> maneuvers = CLIHelper.GetDictionaryOptions(Options.Maneuvers, man, "Pick a new maneuver");
                        foreach (var item in maneuvers)
                        {
                            result.ClassFeatures["Combat Superiority"] += $"\n{item}({Options.Maneuvers[item]})";
                        }
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Know Your Enemy", "study 1min, DM tells you =/</> in 2 traits: Str, Dex, Con, AC," +
                                "\ncurrent HP, lvl, fighter lvl(if any)");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Relentless", "on Init, if no superiority dice - regain 1");
                        }
                        break;
                    case "Cavalier":
                        string pickLang = "Pick a language";
                        CLIHelper.Print2Choices("Pick a skill", pickLang);
                        int choice = CLIHelper.GetNumberInRange(1, 2);
                        if (choice == 1)
                        {
                            skills = new List<string> { "Animal Handling", "History", "Insight", "Performance", "Persuasion" };
                            skill = CLIHelper.GetNew(skills, character.SkillProficiencies, "Pick a skill", "You already have that skill");
                            character.SkillProficiencies.Add(skill);
                        }
                        else if (choice == 2)
                        {
                            string lang = CLIHelper.GetNew(Options.Languages, character.Languages, pickLang, "You already have that language");
                            character.Languages.Add(lang);
                        }
                        
                        result.ClassFeatures.Add("Born to the Saddle", "adv on saves to avoid falling off mount, if you fall less than 10ft - land on your feet, no incap" +
                            "\nmounting and dismounting only cost 5ft of movement instead of half your speed");
                        result.ClassFeatures.Add("Unwavering Mark", "on hit, mark creature, disadv on atks vs allies, if atk ally - Str/LR, bonus melee atk, with adv, dmg + 1/2 lvl");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Warding Maneuver", "Con/LR, reaction, if you or adj ally are hit, AC + 1D8, if atk still hit - gain Resistance");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Hold the Line", "if enemy moves in reach, atk op, if hit - reduce speed to 0");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Ferocious Charger", "if move 10ft and hit, Str save, knock prone");
                        }
                        if (lvl >= 18)
                        {
                            result.ClassFeatures.Add("Vigilant Defender", "reaction, 1/turn (not your turn), make atk op within reach");
                        }
                        break;
                    case "Champion":
                        result.ClassFeatures.Add("Improved Critical", "crit on 19 and 20");

                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Remarkable Athlete", "add 1/2 prof bonus to Str/Dex/Con checks that you don't have prof in." +
                                "\nIncrease your running long jump distance by Str mod ft");
                        }
                        if (lvl >= 10)
                        {
                            fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                            fightStyleKey = $"Fighting Style({fightStyle})";
                            fightStyleValue = Options.FightingStyles[fightStyle];
                            if (fightStyle == "Superior Technique")
                            {
                                maneuvers = CLIHelper.GetDictionaryOptions(Options.Maneuvers, 1, "Pick a maneuver");
                                string newMan = maneuvers[0];
                                fightStyleValue += newMan;
                            }
                            result.ClassFeatures.Add(fightStyleKey, fightStyleValue);
                            styleList.Remove(fightStyle);
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
                        break;
                    case "Echo Knight":
                        //result.ClassFeatures.Add("", "");
                        //if (lvl >= 7)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 10)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 15)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 18)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        break;
                    case "Eldritch Knight":
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
                        string spell = "";

                        for (int i = 0; i < 2; i++)
                        {
                            cantrip = CLIHelper.GetNew(spells.Wizard[0], result.Cantrips, msg1, msg2);
                            result.Cantrips.Add(cantrip);
                            spells.Wizard[0].Remove(cantrip);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            spell = CLIHelper.GetNew(spells.Fighter[1], result.Spells[1], msg1, msg2);
                            result.Spells[1].Add(spell);
                            spells.Fighter[1].Remove(spell);
                        }
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
                        break;
                    case "Psi Warrior":
                        //result.ClassFeatures.Add("", "");
                        //if (lvl >= 7)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 10)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 15)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 18)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        break;
                    case "Purple Dragon Knight":
                        result.ClassFeatures.Add("Banneret", "Knighthood given on battle for courage, troop commander status");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Rallying Cry", "When you use Second Wind, 60ft, 3 allies, regain HP = lvl");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Royal Envoy", "gain a skill and double your prof bonus for Persuasion");
                            if (character.SkillProficiencies.Contains("Persuasion"))
                            {
                                skills = new List<string> { "Animal Handling", "Insight", "Intimidation", "Performance"};
                                Console.WriteLine("Pick a skill");
                                skill = CLIHelper.PrintChoices(skills);
                                character.SkillProficiencies.Add(skill);
                            }
                            else
                            {
                                character.SkillProficiencies.Add("Persuasion");
                            }
                            character.Skills["Persuasion"] += character.ProficiencyBonus;
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Inspiring Surge", "When you use Action Surge, 60ft, 1 ally, make a melee or ranged atk as a reaction");
                        }
                        if (lvl >= 17)
                        {
                            result.ClassFeatures["Inspiring Surge"] = "When you use Action Surge, 60ft, 2 allies, make a melee or ranged atk as a reaction";
                        }
                        if (lvl >= 18)
                        {
                            result.ClassFeatures.Add("Bulwark", "When you use Indomitable on Int, Wis, or Cha save - 60ft, if ally fails they can reroll");
                        }
                        break;
                    case "Rune Knight":
                        //result.ClassFeatures.Add("", "");
                        //if (lvl >= 7)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 10)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 15)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 18)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        break;
                    case "Samurai":
                        pickLang = "Pick a language";
                        CLIHelper.Print2Choices("Pick a skill", pickLang);
                        choice = CLIHelper.GetNumberInRange(1, 2);
                        if (choice == 1)
                        {
                            skills = new List<string> { "History", "Insight", "Performance", "Persuasion" };
                            skill = CLIHelper.GetNew(skills, character.SkillProficiencies, "Pick a skill", "You already have that skill");
                            character.SkillProficiencies.Add(skill);
                        }
                        else if (choice == 2)
                        {
                            string lang = CLIHelper.GetNew(Options.Languages, character.Languages, pickLang, "You already have that language");
                            character.Languages.Add(lang);
                        }
                        int tempHP = 5;
                        for (int i = 10; i < lvl; i += 5)
                        {
                            if (i != 20)
                            {
                                tempHP += 5;
                            }
                        }
                        result.ClassFeatures.Add("Fighting Spirit", $"3/LR, bonus, gain adv on atks and {tempHP} temp HP");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Elegant Courier", "Persuasion + Wis, gain prof in Wis saves (if already have gain Int or Cha instead)");
                            character.Saves.Add("Wis");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Tireless Spirit", "on Init, if no uses of Fighting Spirit regain 1 use");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Rapid Strike", "1/turn, if an atk has adv, forgo the adv to gain an extra wep atk");
                        }
                        if (lvl >= 18)
                        {
                            result.ClassFeatures.Add("Strength before Death", "LR, if drop to 0 HP, don't fall unconscious for 1 turn, reaction - immediately take a turn");
                        }
                        break;
                }
            }
            if (lvl >= 4)
            {
                result.ClassFeatures.Add("Martial Versatility", "When you gain an Ability Score Improvement, replace a Fighting Style or a Maneuver (if you know one)");
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
