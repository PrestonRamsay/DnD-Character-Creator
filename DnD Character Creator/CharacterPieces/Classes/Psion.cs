﻿using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Psion
    {
        public static Dictionary<int, List<string>> ExpandedSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 0, new List<string>() },
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() }
        };
        public static string CastingStat { get; set; }
        public static void Base(Character character)
        {
            string msg = "Pick a type of Discipline that will determine your skill list, saves and give you features at levels 1, 6, and 14.";
            var archetype = new List<string> { "Clairsentience(Seer)", "Metacreativity(Shaper)", "Psychokinesis(Savant)",
                "Psychometabolism(Egoist)", "Psychoportation(Nomad)", "Telepathy(Telepath)" };
            int input = CLIHelper.PrintChoices(msg, archetype);
            character.Archetype = archetype[input];
            var classSkills = new List<string>();

            switch (character.Archetype)
            {
                case "Clairsentience(Seer)":
                    classSkills = new List<string> { "Arcana", "History", "Insight", "Investigation", "Nature", "Perception", "Religion" };
                    character.Saves.Add("Int");
                    character.Saves.Add("Wis");
                    break;
                case "Metacreativity(Shaper)":
                    classSkills = new List<string> { "Animal Handling", "Arcana", "Insight", "Nature", "Persuasion", "Religion", "Stealth" };
                    character.Saves.Add("Wis");
                    character.Saves.Add("Cha");
                    break;
                case "Psychokinesis(Savant)":
                    classSkills = new List<string> { "Arcana", "Athletics", "Deception", "Intimidation", "Perception", "Survival" };
                    character.Saves.Add("Con");
                    character.Saves.Add("Cha");
                    break;
                case "Psychometabolism(Egoist)":
                    classSkills = new List<string> { "Acrobatics", "Athletics", "Intimidation", "Perception", "Performance", "Sleight of Hand", "Stealth" };
                    character.Saves.Add("Str");
                    character.Saves.Add("Con");
                    break;
                case "Psychoportation(Nomad)":
                    classSkills = new List<string> { "Acrobatics", "Athletics", "History", "Investigation", "Nature", "Perception", "Survival" };
                    character.Saves.Add("Dex");
                    character.Saves.Add("Int");
                    break;
                case "Telepathy(Telepath)":
                    classSkills = new List<string> { "Arcana", "Deception", "Insight", "Intimidation", "Investigation", "Persuasion", "Stealth" };
                    character.Saves.Add("Wis");
                    character.Saves.Add("Cha");
                    break;
            }
            character.GP += 75;
            character.HitDie = 6;
            character.Proficiencies.Add("Daggers");
            character.Proficiencies.Add("Darts");
            character.Proficiencies.Add("Slings");
            character.Proficiencies.Add("Quarterstaffs");
            character.Proficiencies.Add("Light crossbows");

            BEHelper.GetSkills(character, classSkills, 2);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Light crossbow and 20 bolts", "Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            int input2 = CLIHelper.PrintChoices("Pick a psi crystal personality for your spell focus", Options.PsiCrystals);
            character.Equipment.Add(Options.PsiCrystals[input2]);
            CLIHelper.Print2Choices("Scholar's Pack", "Explorer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                character.Equipment.Add(Options.SimpleRangedWeapons[0]);
                character.Equipment.Add("20 bolts");
            }
            else
            {
                BEHelper.AddSimpleWeapon(character);
            }
            if (input3 == 1)
            {
                character.Equipment.Add(Options.Packs[6]);
            }
            else
            {
                character.Equipment.Add(Options.Packs[4]);
            }
            character.Equipment.Add($"2 {Options.SimpleMeleeWeapons[1]}");
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;
            var tuple = DeterminePowerPts(lvl);
            int pts = tuple.Item1;
            int maxLvl = tuple.Item2;
            character.ClassFeatures.Add("Power Points", $"you have {pts} pts and you can cast up to {maxLvl} lvl spells(uses spell pts by lvl chart DMG pg 289)" +
                $"\n        there's a limit on how many times you can cast certain spell lvls, casting at higher lvls - pay pts = spell's new lvl, pt costs for spells below" +
                $"\n        1st = 2pts(9/LR)          4th = 6pts(6/LR)          7th = 10pts(3/LR)" +
                $"\n        2nd = 3pts(8/LR)          5th = 7pts(5/LR)          8th = 11pts(2/LR)" +
                $"\n        3rd = 5pts(7/LR)          6th = 9pts(4/LR)          9th = 13pts(1/LR)");
            character.ClassFeatures.Add("Spellcasting Description", "Instead of arcane magic, you channel psionic energy to 'cast' your powers/spells" +
                "\n        Some say psions are harnessing the energy of the Astral Plane, others think psions create psionic energy from their minds" +
                "\n        When you use a summoning spell, the creature has the appearance of a silver Astral Construct(solidified ectoplasm)" +
                "\n        Psychokinetic spells or atk spells are examples of you manipulating the form of your psionic energy to create various mental blasts" +
                "\n        Because the body is an extension of the mind, psychometabolism spells allow you to manipulate its form, abilites and heal" +
                "\n        Spells that involve 'your god' ignore that aspect of the spell, psions can be religious but it isn't necessary for their powers/spells");

            switch (character.Archetype)
            {
                case "Clairsentience(Seer)":
                    Clairsentience(character);
                    break;
                case "Metacreativity(Shaper)":
                    Metacreativity(character);
                    break;
                case "Psychokinesis(Savant)":
                    Psychokinesis(character);
                    break;
                case "Psychometabolism(Egoist)":
                    Psychometabolism(character);
                    break;
                case "Psychoportation(Nomad)":
                    Psychoportation(character);
                    break;
                case "Telepathy(Telepath)":
                    Telepathy(character);
                    break;
            }
            if (lvl >= 2)
            {
                int psionicDie = 6;
                for (int i = 0; i <= lvl; i++)
                {
                    if (i == 5 || i == 10 || i == 15)
                    {
                        psionicDie += 2;
                    }
                }
                string cmbMode = "";
                string msg = "";
                var psionicDict = GetPsionicModes(psionicDie, CastingStat);
                var modesList = new List<string>();
                foreach (var item in psionicDict.Keys)
                {
                    modesList.Add(item);
                }
                int options = 2;
                for (int i = 10; i <= lvl; i += 7)
                {
                    options++;
                }
                character.ClassFeatures.Add($"Psionic Combat Modes(D{psionicDie})", $"{CastingStat}/LR, reaction, 60ft, 1 creature, you have {options} modes");
                for (int i = 0; i < options; i++)
                {
                    if (i == 0)
                    {
                        msg = "You get 2 Psionic Combat Modes of your choice";
                    }
                    else
                    {
                        msg = "Pick a new Psionic Combat Mode option";
                    }
                    cmbMode = CLIHelper.PrintChoices(psionicDict, modesList, msg);
                    modesList.Remove(cmbMode);
                    character.ClassFeatures["Psionic Combat Modes(D{psionicDie})"] += $"\n        {cmbMode}({psionicDict[cmbMode]})";
                }
            }
            if (lvl >= 4)
            {
                character.ClassFeatures.Add("Psionic Versatility", "When you get an Ability Score Improvement, you can replace a Psionic Combat Mode option or Psion cantrip");
            }
            if (lvl >= 5)
            {
                character.ClassFeatures.Add("Astral Guidance", "expend 1 Psionic Combat Mode use, when you fail a check, reroll the check, must use new roll");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Superior Psionic Combat", "on Init, if you have no Psionic Combat Mode uses - regain 1 use");
            }
            Spells(character);

            
        }
        public static void Clairsentience(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[0].Add("Guidance");
            ExpandedSpells[1].Add("Detect Magic");
            ExpandedSpells[1].Add("Gift of Alacrity");
            ExpandedSpells[2].Add("Augury");
            ExpandedSpells[2].Add("Fortune's Favor");
            ExpandedSpells[3].Add("Clairvoyance");
            ExpandedSpells[3].Add("Tongues");
            ExpandedSpells[4].Add("Divination");
            ExpandedSpells[4].Add("Locate Creature");
            ExpandedSpells[5].Add("Legend Lore");
            ExpandedSpells[5].Add("Scrying");
            CastingStat = "Wis";
            character.ClassFeatures.Add("Spellcasting", $"use {CastingStat} for spell DCs, you use an Psi Crystal as a spell focus");
            character.ClassFeatures.Add("Extended Senses", "LR or 2 power pts, action, 1 hr, 10ft, Wis creatures, share senses" +
                "\n        gain Superior Darkvision, your senses have a radius of 180ft");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Expert Seer", "when you cast a lvl 2 or higher Divination spell, regain power pts = pt cost to cast");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Actionable Foreknowledge", "expend 1 Psionic Combat Mode use, add roll to an ability check you make");
            }
        }
        public static void Metacreativity(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[0].Add("Infestation");
            ExpandedSpells[1].Add("Create or Destroy Water");
            ExpandedSpells[1].Add("Find Familiar");
            ExpandedSpells[2].Add("Dust Devil");
            ExpandedSpells[2].Add("Summon Beast");
            string msg = "Pick a type of creature for your summoning";
            var summonList = new List<string> { "Fey", "Lesser Demon", "Shadowpawn", "Undead" };
            int index = CLIHelper.PrintChoices(msg, summonList);
            string creature = summonList[index];
            summonList.Remove(creature);
            ExpandedSpells[3].Add($"Summon {creature}");
            index = CLIHelper.PrintChoices(msg, summonList);
            creature = summonList[index];
            ExpandedSpells[3].Add($"Summon {creature}");
            summonList = new List<string> { "Aberration", "Construct", "Elemental", "Greater Demon" };
            index = CLIHelper.PrintChoices(msg, summonList);
            creature = summonList[index];
            summonList.Remove(creature);
            ExpandedSpells[4].Add($"Summon {creature}");
            index = CLIHelper.PrintChoices(msg, summonList);
            creature = summonList[index];
            ExpandedSpells[4].Add($"Summon {creature}");
            summonList = new List<string> { "Conjure Elemental", "Infernal Calling", "Summon Celestial" };
            index = CLIHelper.PrintChoices(msg, summonList);
            string summonSpell = summonList[index];
            summonList.Remove(summonSpell);
            ExpandedSpells[5].Add(summonSpell);
            index = CLIHelper.PrintChoices(msg, summonList);
            summonSpell = summonList[index];
            ExpandedSpells[5].Add(summonSpell);
            CastingStat = "Int";
            character.ClassFeatures.Add("Spellcasting", $"use {CastingStat} for spell DCs, you use an Psi Crystal as a spell focus");
            character.ClassFeatures.Add("Summon Astral Construct", "LR or 2 power pts, action, 1 hr, 30ft, uses your PB, defaults to Dodge, bonus to command, stat block separate");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Shaper Control", "astral construct actions +1D6(dmg or temp HP), spells with range not self can originate from your astral construct");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Improved Astral Construct", "astral construct AC + 2, gains (See Invisibility) or (Invisibility as an action)");
            }
        }
        public static void Psychokinesis(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[0].Add("Eldritch Blast");
            ExpandedSpells[1].Add("Chaos Bolt");
            ExpandedSpells[1].Add("Chromatic Orb");
            ExpandedSpells[2].Add("Mind Spike");
            ExpandedSpells[2].Add("Tasha's Mind Whip");
            ExpandedSpells[3].Add("Fireball");
            ExpandedSpells[3].Add("Lightning Bolt");
            ExpandedSpells[4].Add("Vitriolic Sphere");
            ExpandedSpells[4].Add("Watery Sphere");
            ExpandedSpells[5].Add("Cone of Cold");
            ExpandedSpells[5].Add("Destructive Wave");
            CastingStat = "Str";
            character.ClassFeatures.Add("Spellcasting", $"use {CastingStat} for spell DCs, you use an Psi Crystal as a spell focus");
            var savantCantrips = new List<string> { "Acid Spalsh", "Chill Touch", "Fire Bolt", "Frostbite", "Lightning Lure",
                        "Mind Sliver", "Poison Spray", "Ray of Frost", "Sacred Flame", "Shocking Grasp", "Thunderclap" };
            character.ClassFeatures.Add("Psionic Manipulation", "gain 2 cantrips from list");
            Console.WriteLine("Psionic Manipulation: gain 2 cantrips from list");
            string newCantrip = CLIHelper.PrintChoices(savantCantrips);
            character.Cantrips.Add(newCantrip);
            savantCantrips.Remove(newCantrip);
            newCantrip = CLIHelper.PrintChoices(savantCantrips);
            character.Cantrips.Add(newCantrip);
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Enhanced Psionic Powers", "when you cast a Force or Psychic dmg spell, dmg + Str");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Repelling Mind", "reaction, when hit by melee, Psychic dmg = lvl, Str save, push 20ft");
            }
        }
        public static void Psychometabolism(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[0].Add("Resistance");
            ExpandedSpells[1].Add("Disguise Self");
            ExpandedSpells[1].Add("Expeditious Retreat");
            ExpandedSpells[2].Add("Alter Self");
            ExpandedSpells[2].Add("Barkskin");
            ExpandedSpells[2].Add("Spiderclimb");
            ExpandedSpells[3].Add("Gaseous Form");
            ExpandedSpells[3].Add("Waterbreathing");
            ExpandedSpells[4].Add("Polymorph");
            ExpandedSpells[4].Add("Stoneskin");
            ExpandedSpells[5].Add("Hold Monster");
            ExpandedSpells[5].Add("Skill Empowerment");
            CastingStat = "Con";
            character.ClassFeatures.Add("Spellcasting", $"use {CastingStat} for spell DCs, you use an Psi Crystal as a spell focus");
            character.ClassFeatures.Add("Psionic Resilience", "increase HP by 1 per lvl, AC = 13 + Dex");
            character.HP += lvl;
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Reactive Evolution", "PB/LR, reaction, when you take dmg, gain Resistance to dmg");
                character.ClassFeatures.Add("Harden Body", $"SR, bonus, gain temp HP = 1D12 + Con");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Manipulate Biology", "bonus, 10 min, gain 1 option - (see invisible creatures 60ft), (gain Hover and Fly speed)" +
                    "\n        (gain Swim speed = speed x 2), or (become slime - move through 1 inch spaces, spend 5ft movement to escape nonmagical restraints/grapples)");
            }
        }
        public static void Psychoportation(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[0].Add("Light");
            ExpandedSpells[1].Add("Expeditious Retreat");
            ExpandedSpells[1].Add("Featherfall");
            ExpandedSpells[2].Add("Levitate");
            ExpandedSpells[2].Add("Misty Step");
            ExpandedSpells[3].Add("Fly");
            ExpandedSpells[3].Add("Thunder Step");
            ExpandedSpells[4].Add("Dimension Door");
            ExpandedSpells[4].Add("Freedom of Movement");
            ExpandedSpells[5].Add("Passwall");
            ExpandedSpells[5].Add("Teleportation Circle");
            CastingStat = "Dex";
            character.ClassFeatures.Add("Spellcasting", $"use {CastingStat} for spell DCs, you use an Psi Crystal as a spell focus");
            character.ClassFeatures.Add("Pyschic Blink", "SR, bonus, 5ft, 1 creature, teleport 30ft");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Nomad's Escape", "SR, reaction, when you take dmg - teleport 60ft and become invisible for 1 turn");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Psionic Steps", "when you cast a Psion spell, teleport 15ft / when you take Dash action, teleport dist = movement");
            }
        }
        public static void Telepathy(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[0].Add("Message");
            ExpandedSpells[1].Add("Beast Bond");
            ExpandedSpells[1].Add("Charm Person");
            ExpandedSpells[2].Add("Detect Thoughts");
            ExpandedSpells[2].Add("Suggestion");
            ExpandedSpells[3].Add("Sending");
            ExpandedSpells[3].Add("Fear");
            ExpandedSpells[4].Add("Compulsion");
            ExpandedSpells[4].Add("Confusion");
            ExpandedSpells[5].Add("Dominate Person");
            ExpandedSpells[5].Add("Rary's Telepathic Bond");
            CastingStat = "Cha";
            character.ClassFeatures.Add("Spellcasting", $"use {CastingStat} for spell DCs, you use an Psi Crystal as a spell focus");
            character.ClassFeatures.Add("Telepathic Speech", "bonus, lvl min, 30ft, 1 creature, speak telepathically from Cha miles");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Impenetrable Mind", "gain Immunity to charm and fear");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Psychic Thrall", "LR, action, 30ft, 1 creature, must share lang, Wis save, charm 8 hr, obeys commands, grants gifts/favors as if close friend");
            }
        }
        public static void Spells(Character character)
        {
            character.Cantrips.AddRange(ExpandedSpells[0]);
            BEHelper.AddPrimSpells(character, ExpandedSpells);
            string pickMsg = "Pick a cantrip.";
            int spellLvl = 1;
            AllSpells spells = new AllSpells(character);

            for (int i = 0; i < character.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(PsionSpells.Cantrips, character.Cantrips, pickMsg);
                character.Cantrips.Add(spell);
            }
            pickMsg = "Pick a 1st level spell.";
            for (int i = 1; i <= character.SpellsKnown; i++)
            {
                if (4 <= i && i <= 14 && i % 2 == 0)
                {
                    spellLvl++;
                }
                pickMsg = CLIHelper.pickSpellLevel(i, 4, 6, 8, pickMsg, spellLvl);
                string spell = CLIHelper.GetNew(spells.Psion[spellLvl], character.Spells[spellLvl], pickMsg);
                character.Spells[spellLvl].Add(spell);
                spells.Psion[spellLvl].Remove(spell);
            }
        }
        public static Dictionary<string, string> GetPsionicModes(int psionicDie, string castingStat)
        {
            var PsionicCombatModes = new Dictionary<string, string>
            {
                { "Ego Whip", $"when Dex atk/check is made, Dex atk/check +/- {psionicDie}, speed +/- 10ft for 1 min" },
                { "Empty Mind", $"when Detection spell is cast, 2 options - (Wis save) or (save +/- {psionicDie})" },
                { "Id Insinuation", $"when Str atk/check is made, Str atk/check +/- {psionicDie}, dmg +/- 1D4" },
                { "Mental Barrier", $"save vs blind or deafen +/- {psionicDie}" },
                { "Mind Blast", $"when Cha save is made, Cha save +/- {psionicDie}, range = 60ft cone, targets = all in cone" },
                { "Mind Thrust", $"when Int save is made, Int save +/- {psionicDie}, gain 1D4 temp HP or deal 1D4 Psychic dmg" },
                { "Psychic Crush", $"when Wis save is made, Wis save +/- {psionicDie}, speed = 0 for 1 turn" },
                { "Thought Shield", $"save vs charm or fear +/- {psionicDie}" },
                { "Tower of Iron Will", $"when Int, Wis, or Cha save is made, targets = {castingStat} allies, save + {psionicDie} / 2, min 1" }
            };

            return PsionicCombatModes;
        }
        public static Tuple<int, int> DeterminePowerPts(int lvl)
        {
            int pts = 4;
            int maxLvl = 1;
            for (int i = 3; i <= lvl; i += 2)
            {
                if (lvl <= 17)
                {
                    maxLvl++;
                }
            }
            switch (lvl)
            {
                case 2:
                    pts = 6;
                    break;
                case 3:
                    pts = 14;
                    break;
                case 4:
                    pts = 17;
                    break;
                case 5:
                    pts = 27;
                    break;
                case 6:
                    pts = 32;
                    break;
                case 7:
                    pts = 38;
                    break;
                case 8:
                    pts = 44;
                    break;
                case 9:
                    pts = 57;
                    break;
                case 10:
                    pts = 64;
                    break;
                case 11:
                    pts = 73;
                    break;
                case 12:
                    pts = 73;
                    break;
                case 13:
                    pts = 83;
                    break;
                case 14:
                    pts = 83;
                    break;
                case 15:
                    pts = 94;
                    break;
                case 16:
                    pts = 94;
                    break;
                case 17:
                    pts = 107;
                    break;
                case 18:
                    pts = 114;
                    break;
                case 19:
                    pts = 123;
                    break;
                case 20:
                    pts = 133;
                    break;
            }

            return new Tuple<int, int>(pts, maxLvl);
        }
    }
}
