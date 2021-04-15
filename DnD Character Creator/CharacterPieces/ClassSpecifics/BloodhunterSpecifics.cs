﻿using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class BloodhunterSpecifics
    {
        public static string BloodhunterOrder { get; set; }
        public static CharacterClass Features(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;
            int index = -1;
            int dmg = 4;
            for (int i = 5; i <= lvl; i += 4)
            {
                dmg += 2;
            }
            int rites = 1;
            for (int i = 6; i <= lvl; i += 3)
            {
                rites++;
                if (i == 9)
                {
                    i++;
                }
            }
            var primalRites = new List<string> { "Rite of the Flame", "Rite of the Frozen", "Rite of the Ruined", "Rite of the Storm" };
            var esotericRites = new List<string> { "Rite of the Dead", "Rite of the Oracle", "Rite of the Roar" };
            string msg = "Pick a Primal Rite";
            var dmgTypes = new List<string>();
            for (int i = 0; i < rites; i++)
            {
                if (i != 3)
                {
                    index = CLIHelper.PrintChoices(msg, primalRites);
                    string newRite = primalRites[index];
                    string riteType = newRite.Substring(11);
                    switch (riteType)
                    {
                        case "Flame":
                            dmgTypes.Add("Fire");
                            break;
                        case "Frozen":
                            dmgTypes.Add("Cold");
                            break;
                        case "Ruined":
                            dmgTypes.Add("Acid");
                            break;
                        case "Storm":
                            dmgTypes.Add("Lightning");
                            break;
                    }
                    primalRites.Remove(newRite);
                }
                else
                {
                    index = CLIHelper.PrintChoices(msg, esotericRites);
                    string newRite = esotericRites[index].Substring(11);
                    switch (newRite)
                    {
                        case "Dead":
                            dmgTypes.Add("Necrotic");
                            break;
                        case "Oracle":
                            dmgTypes.Add("Psychic");
                            break;
                        case "Roar":
                            dmgTypes.Add("Thunder");
                            break;
                    }
                }
            }
            string riteDmg = String.Join(", ", dmgTypes);
            result.ClassFeatures.Add("Hunter's Bane", "adv on Survival to track and Int to recall info about Fey, Fiends, and Undead" +
                "\ncan't be surprised by creature type while tracking that type, can only track 1 type at a time");
            result.ClassFeatures.Add("Crimson Rite", $"bonus, reduce max HP by lvl, dmg + 1D{dmg} of 1 type, dmg type(s) = {riteDmg}");

            if (lvl >= 2)
            {
                string fightStyleMsg = "Pick a fighting style.";
                List<string> styleList = new List<string> { "Archery", "Blind Fighting", "Dueling", "Great Weapon Fighting", 
                    "Two-Weapon Fighting" };
                string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                string fightStyleKey = $"Fighting Style({fightStyle})";
                string fightStyleValue = Options.FightingStyles[fightStyle];
                result.ClassFeatures.Add(fightStyleKey, fightStyleValue);
            }
            if (lvl >= 3)
            {
                msg = "Pick a Bloodhunter Order that will give you features at levels 3, 7, 10, 15, and 18.";
                var archetypes = new List<string> { "Order of the Ghostslayer", "Order of the Mutant", "Order of the Profane Soul" };
                int answer = CLIHelper.PrintChoices(msg, archetypes);
                BloodhunterOrder = archetypes[answer].Substring(12);

                switch (BloodhunterOrder)
                {
                    case "Ghostslayer":
                        Ghostslayer(character, result);
                        break;
                    case "Mutant":
                        Mutant(character, result);
                        break;
                    case "Profane Soul":
                        ProfaneSoul(character, result);
                        break;
                }
            }
            if (lvl >= 4)
            {
                result.ClassFeatures.Add("Hunter's Versatility", "When you gain an Ability Score Improvement, replace a Fighting Style or a Crimson Rite option");
            }
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
            }
            if (lvl >= 6)
            {
                int cursesKnown = 2;
                int curseUses = 2;
                for (int i = 10; i <= lvl; i += 4)
                {
                    cursesKnown++;
                }
                for (int i = 11; i <= lvl; i += 6)
                {
                    curseUses++;
                }
                Options.BloodCurses.Add("Blood Curse of the Transfusion", $"bonus, 30ft, 1 ally, take {curseUses}D6 dmg to heal ally HP = dmg" +
                    $"\n        Amplified - 1 Hitdie, healing + (Wis x 2)");
                var bloodCurses = new List<string>();
                foreach (var item in Options.BloodCurses.Keys)
                {
                    bloodCurses.Add(item);
                }
                result.ClassFeatures.Add("Blood Maledict", $"{curseUses}/SR, target must have blood, creatures can only have 1 curse at a time, you know {cursesKnown} Blood Curse options");
                for (int i = 0; i < cursesKnown; i++)
                {
                    string newCurse = CLIHelper.PrintChoices(Options.BloodCurses, bloodCurses, "Pick a Blood Curse option");
                    result.ClassFeatures["Blood Maledict"] += $"\n{newCurse}({Options.BloodCurses[newCurse]})";
                    bloodCurses.Remove(newCurse);
                }
            }
            if (lvl >= 9)
            {
                result.ClassFeatures.Add("Grim Psychometry", "meditate for 10 min, Wis check, learn dark events/sinister purpose of an object touched by evil");
            }
            if (lvl >= 11)
            {
                result.ClassFeatures["Hunter's Bane"] = "gain adv on Insight and Intimidation";
                result.ClassFeatures.Add("Dark Velocity", "speed +10ft, op atks against you suffer disadv");
                character.Speed += 10;
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Hardened Soul", "gain Immunity to fear, gain adv vs charm");
            }
            if (lvl >= 17)
            {
                result.ClassFeatures.Add("Enduring Form", "1/turn, 2 Hitdie, reroll death save");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Sanguine Mastery", "Crimson Rite no longer reduces max HP, if HP < 1/4 max HP - all Crimson Rite dmg is maximized");
            }

            return result;
        }
        public static void Ghostslayer(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            result.ClassFeatures.Add("Cleansing Rite", "Crimson Rite dmg + Wis Radiant dmg");
            if (lvl >= 7)
            {
                result.ClassFeatures.Add("Hallowed Veins", "Blood Curses can be used on any creature");
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Supernal Flurry", "LR, bonus, Wis rounds, gain extra atk / on kill, regain HP = Crimson Rite die");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures["Supernal Flurry"] = "SR, bonus, Wis rounds, gain additional Attack action / on kill, regain HP = Crimson Rite die";
                result.ClassFeatures.Add("Gravesight", "gain Darkvision 60ft, see invisibility 60ft");
                if (character.Vision.Contains("Lowlight"))
                {
                    character.Vision = "Darkvision 60ft";
                }
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Vengeful Spirit", "when you drop to 0 HP, next turn manifest spirit form that picks up weapons, has Immunity to non-magical dmg" +
                    "\nhas no armor, can only take Move, Attack, and Bonus(offhand atk or Crimson Rite) actions");
            }
        }
        public static void Mutant(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            int formulas = 3;
            for (int i = 7; i < lvl; i += 3)
            {
                formulas++;
                if (i == 10)
                {
                    i += 2;
                }
            }
            var mutagens = new List<string>();
            var dict = new Dictionary<string, string>();
            foreach (var item in Options.Mutagens.Keys)
            {
                dict.Add(item, Options.Mutagens[item]);
            }
            if (lvl < 7)
            {
                dict.Remove("Precision");
            }
            if (lvl < 10)
            {
                dict.Remove("Aether");
            }
            else
            {
                dict["Mobility"] += ", paralyze";
            }
            if (lvl >= 15)
            {
                dict["Precision"] = "crit on 18-20, half all healing received";
                dict["Rapidity"] = "gain speed +15ft, enemies crit on 19-20";
            }
            foreach (var item in dict.Keys)
            {
                mutagens.Add(item);
            }
            result.ClassFeatures.Add("Mutagen Craft", "on SR, create a mutagen, consume as bonus, duration until SR, mutation score = lvl / 4, rounded up");
            for (int i = 0; i < formulas; i++)
            {
                string newMutagen = CLIHelper.PrintChoices(dict, mutagens, "Pick a new mutagen formula");
                mutagens.Remove(newMutagen);
                result.ClassFeatures["Mutagen Craft"] += $"\n{newMutagen}({dict[newMutagen]})";
            }
            if (result.ClassFeatures["Mutagen Craft"].Contains("Nighteye"))
            {
                if (character.Vision.Contains("Lowlight"))
                {
                    character.Vision = "Darkvision 60ft";
                }
                else
                {
                    string vision = character.Vision;
                    if (vision.Contains("Superior"))
                    {
                        character.Vision = "Superior Darkvision 180ft";
                    }
                    else
                    {
                        character.Vision = "Darkvision 120ft";
                    }
                }
            }
            if (lvl >= 7)
            {
                result.ClassFeatures.Add("Advanced Mutagen Craft", "on SR, create 2 mutagens, must be different formulas");
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Robust Physiology", "gain Immunity to Poison dmg and poison(condition)");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures["Advanced Mutagen Craft"] = "on SR, create 3 mutagens, must be different formulas";
                result.ClassFeatures.Add("Strange Metabolism", "SR, ignore the side effect from 1 mutagen after taking it");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Exalted Mutation", "choose 1 mutagen formula to gain permanently, can't be changed or effected by Strange Metabolism");
            }
        }
        public static void ProfaneSoul(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            result.ClassFeatures.Add("Pact Magic", "gain spells from the Warlock list, use Wis for spell DCs");
            result.ClassFeatures.Add("Lethal Focus", "you use a weapon as a spell focus");
            if (lvl >= 7)
            {
                result.ClassFeatures.Add("Mystic Frenzy", "bonus, when you cast a cantrip, make a wep atk");
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Diabolic Channel", "action, non-cantrip spell with cast time of 1 action, make an wep atk - if hit all spell atk hit, if adv then save has disadv");
                result.ClassFeatures.Add("Rite Bond", "gain Resistance to any Crimson Rite dmg types you are actively using");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures.Add("Arcane Impulse", "SR, reaction, when enemy atk misses, cast a spell with cast time of 1 action");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Soul Syphon", "regain a spell slot when you kill a CR 15+ creature");
            }
            Spells(character, result);
        }
        public static void Spells(Character character, CharacterClass result)
        {
            AllSpells spells = new AllSpells("Warlock");
            result.Cantrips.AddRange(character.Cantrips);
            result.CantripsKnown = 2;
            result.SpellsKnown = 2;
            string pickMsg = "Pick a spell.";
            string errorMsg = "You already have that spell";
            string spell = "";
            int slotLvl = 1;
            int slots = 1;
            for (int i = 3; i <= character.Lvl; i++)
            {
                //slots
                if (i == 5 || i == 15)
                {
                    slots++;
                }
                if (i == 7 || i == 11 || i == 18)
                {
                    result.SpellSlots[slotLvl] = 0;
                    slotLvl++;
                }
                result.SpellSlots[slotLvl] = slots;
                //spells known
                if (i == 10)
                {
                    result.CantripsKnown++;
                }
                if (i % 2 != 0 && i <= 17)
                {
                    result.SpellsKnown++;
                }
                if (i == 18 || i == 20)
                {
                    result.SpellsKnown++;
                }
            }
            //add spells
            for (int i = 0; i < result.CantripsKnown; i++)
            {
                spell = CLIHelper.GetNew(spells.Warlock[0], result.Cantrips, pickMsg, errorMsg);
                result.Cantrips.Add(spell);
                spells.Warlock[0].Remove(spell);
            }
            slotLvl = 1;
            for (int i = 0; i < result.SpellsKnown; i++)
            {
                if (i == 3 || i == 5 || i == 9)
                {
                    slotLvl++;
                }
                spell = CLIHelper.GetNew(spells.Warlock[slotLvl], result.Spells[slotLvl], pickMsg, errorMsg);
                result.Spells[slotLvl].Add(spell);
                spells.Warlock[slotLvl].Remove(spell);
            }
        }
    }
}
