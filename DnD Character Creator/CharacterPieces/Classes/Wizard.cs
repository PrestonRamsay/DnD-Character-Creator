using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Wizard
    {
        public static string ArcaneTradition { get; set; }
        public static void Base(Character character)
        {
            List<string> classSkills = new List<string> { "Arcana", "History", "Insight", "Investigation", "Medicine", "Religion" };

            character.GP += 100;
            character.HitDie = 6;
            character.Proficiencies.Add("Daggers");
            character.Proficiencies.Add("Darts");
            character.Proficiencies.Add("Slings");
            character.Proficiencies.Add("Quarterstaffs");
            character.Proficiencies.Add("Light crossbows");
            character.Saves.Add("Int");
            character.Saves.Add("Wis");

            BEHelper.GetSkills(character, classSkills, 2);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Quarterstaff", "Dagger");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Component pouch", "Arcane focus");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Scholar's Pack", "Explorer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                character.Equipment.Add(Options.SimpleMeleeWeapons[7]);
            }
            else
            {
                character.Equipment.Add(Options.SimpleMeleeWeapons[1]);
            }
            if (input2 == 1)
            {
                character.Equipment.Add("Component pouch");
            }
            else
            {
                var focuses = new List<string> { "Crystal", "Orb", "Rod", "Staff", "Wand" };
                int index = CLIHelper.PrintChoices("Pick an arcane focus.", focuses);
                character.Equipment.Add(Options.ArcaneFocuses[index]);
            }
            if (input3 == 1)
            {
                character.Equipment.Add(Options.Packs[6]);
            }
            else
            {
                character.Equipment.Add(Options.Packs[4]);
            }

            character.Equipment.Add("Spellbook");
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;
            try
            {
                character.ClassFeatures.Add("Spellcasting", "use Int for spell DCs, you use an Arcane Focus as a spell focus");
            }
            catch (Exception)
            {
                Console.WriteLine("*Note* You have 2 classes with spellcasting");
                throw;
            }
            character.ClassFeatures.Add("Arcane Recovery", "1/day after SR, gain spell slots <= 1/2 lvl, no lvl 6 slots or higher");

            if (lvl >= 2)
            {
                string msg = "Pick an Arcane Tradition that will give you features at levels 2, 6, 10, and 14.";
                var archetypes = new List<string> { "Abjuration", "Chronurgy Magic", "Conjuration", "Divination", "Enchantment",
                    "Evocation", "Graviturgy Magic", "Illusion", "Necromancy", "Order of Scribes", "Transmutation", "War Magic" };
                if (Prompts.Elves.Contains(character.ChosenRace))
                {
                    archetypes.Add("Bladesinging");
                }
                archetypes.Sort();
                int index = CLIHelper.PrintChoices(msg, archetypes);
                ArcaneTradition = archetypes[index];

                switch (ArcaneTradition)
                {
                    case "Abjuration":
                        Abjuration(character);
                        break;
                    case "Bladesinging":
                        Bladesinging(character);
                        break;
                    case "Chronurgy Magic":
                        ChronurgyMagic(character);
                        break;
                    case "Conjuration":
                        Conjuration(character);
                        break;
                    case "Divination":
                        Divination(character);
                        break;
                    case "Enchantment":
                        Enchantment(character);
                        break;
                    case "Evocation":
                        Evocation(character);
                        break;
                    case "Graviturgy Magic":
                        GraviturgyMagic(character);
                        break;
                    case "Illusion":
                        Illusion(character);
                        break;
                    case "Necromancy":
                        Necromancy(character);
                        break;
                    case "Order of Scribes":
                        OrderOfScribes(character);
                        break;
                    case "Transmutation":
                        Transmutation(character);
                        break;
                    case "War Magic":
                        WarMagic(character);
                        break;
                }
            }
            if (lvl >= 3)
            {
                character.ClassFeatures.Add("Cantrip Formulas", "on SR, replace a cantrip");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Spell Mastery", "pick a 1st and 2nd lvl spell to cast at-will without expending a spell slot");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Signature Spells", "pick two 3rd lvl spells to cast 1/SR without expending a spell slot");
            }
            Spells(character);
        }
        public static void Abjuration(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Abjuration Savant", "gold/time to copy an Abjuration spell into your spellbook is halved");
            character.ClassFeatures.Add("Arcane Ward", "when you cast an Abjuration spell, create ward with HP = lvl x 2 + Int");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Projected Ward", "reaction, ally you can see takes dmg, use Arcane Ward on ally instead of self");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Improved Abjuration", "add PB to Abjuartion spell checks");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Spell Resistance", "adv on saves vs spells, Resistance to spell dmg");
            }
        }
        public static void Bladesinging(Character character)
        {
            int lvl = character.Lvl;
            character.Proficiencies.Add("Light Armor");
            var allMelee = new List<string>();
            var oneHanded = new List<string>();
            allMelee.AddRange(Options.SimpleMeleeWeapons);
            allMelee.AddRange(Options.MartialMeleeWeapons);
            foreach (var item in allMelee)
            {
                if (!item.Contains("Two-Handed"))
                {
                    oneHanded.Add(item);
                }
            }
            Console.WriteLine("Pick a weapon type to gain proficiency in\n        ");
            string wep = CLIHelper.PrintChoices(oneHanded);
            int paranthesis = wep.IndexOf("(");
            wep = wep.Substring(0, paranthesis);
            character.Proficiencies.Add(wep);
            character.SkillProficiencies.Add("Performance");
            character.ClassFeatures.Add("Bladesong", "2/SR, bonus, 1 min, AC + Int, speed +10ft, adv on Acrobatics, Con saves + Int on conc spells");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Song of Defense", "reaction, when you take dmg, expend a spell slot to reduce dmg by slot lvl x 5");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Song of Victory", "While Bladesong is active, melee dmg + Int");
            }
        }
        public static void ChronurgyMagic(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Chronal Shift", "2/LR, reaction, force reroll on atk, save, or check - after success or fail");
            character.ClassFeatures.Add("Temporal Awareness", "Init + Int");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Momentary Stasis", "Int/LR, action, 1 turn, 60ft, Large or smaller creature, Con save, incap and speed = 0");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Arcane Abeyance", "SR, 1 hr, create Tiny gray bead (AC 15, 1 HP) that holds 4th lvl or lower spell, anyone can release the spell");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Convergent Future", "reaction, 60ft, 1 creature, decide whether atk, check, or save succeeds or fails / gain 1 lvl of exhuastion, only lost by LR");
            }
        }
        public static void Conjuration(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Conjuration Savant", "gold/time to copy a Conjuration spell into your spellbook is halved");
            character.ClassFeatures.Add("Minor Conjuration", "action, 10ft, creation for 1 hr, no larger than 3ft, no heavier than 10 lbs, visibily magical");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Benign Transposition", "1/LR (or until cast Conjuration spell), action, teleport 30ft or swap places with ally");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Focused Conjuration", "Conjuration concentration spells can't be broken due to taking dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Durable Summons", "creatures you create gain 30 temp HP");
            }
        }
        public static void Divination(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Divination Savant", "gold/time to copy a Divination spell into your spellbook is halved");
            character.ClassFeatures.Add("Portent", "LR, roll 2D20s - replace any atk, save, check");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Expert Divination", "when you cast a lvl 2 or higher Divination spell, regain a spell slot <= spell lvl(max 5)");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("The Third Eye", "1/SR - gain Darkvision, Ethereal Sight, Greater Comprehension, or See Invisibilty");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Remove("Portent");
                character.ClassFeatures.Add("Greater Portent", "LR, roll 3D20s - replace any atk, save, check");
            }
        }
        public static void Enchantment(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Enchantment Savant", "gold/time to copy an Enchantment spell into your spellbook is halved");
            character.ClassFeatures.Add("Hypnotic Gaze", "action, 5ft, Wis save, charm, incap, dazed - end if 5ft+ away, sustain each turn");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Instinctive Charm", "reaction, 30ft, Wis save, choose new target");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Split Enchantment", "non-cantrip Enchantment spells can effect 2 targets");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Alter Memories", "charmed creatures are unaware of being charmed" +
                    "\n        action, Int save, lose memories for 1 + Cha hr while charmed");
            }
        }
        public static void Evocation(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Evocation Savant", "gold/time to copy an Evocation spell into your spellbook is halved");
            character.ClassFeatures.Add("Sculpt Spells", "choose 1 + spell lvl to auto-succeed on saves against your spell and take no dmg");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Potent Cantrip", "success vs cantrip = 1/2 dmg");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Empowered Evocation", "+Int dmg to Evocation spells");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Overchannel", "max dmg for spells 1st-5th, if used before LR take 2D12/spell lvl + 1D12 per spell lvl for additional uses");
            }
        }
        public static void GraviturgyMagic(Character character)
        {
            int lvl = character.Lvl;
            string size = "Large";
            if (lvl >= 10)
            {
                size = "Huge";
            }
            character.ClassFeatures.Add("Adjust Density", $"action, 1 min conc, 30ft, {size} or smaller object or creature, half or double weight" +
                "\n        Halved(speed +10ft, jump distance x 2, disadv on Str saves/checks), Doubled(speed -10ft, adv on Str saves/checks)");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Gravity Well", "when you cast a spell on a creature - if you hit, the save is failed or the creature is willing - move creature 5ft to unoccupied sq");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Violent Attraction", "Int/LR, reaction, 60ft, when ally hits a wep atk, dmg + 1D10 / increase fall dmg by 2D10");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Event Horizon", "LR or 3rd lvl spell slot, action, 1 min conc, 30ft, Str save, hostiles take 2D10 Force and speed = 0 for 1 turn" +
                    "\n        on successful save - half dmg and 1ft of movement = 3ft of movement");
            }
        }
        public static void Illusion(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Illusion Savant", "gold/time to copy an Illusion spell into your spellbook is halved");
            character.ClassFeatures.Add("Improved Minor Illusion", "you can create sound and image simultaneously");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Malleable Illusions", "if Illusion has duration > 1 min, action to alter the Illusion");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Illusory Self", "reaction, SR, create double, atk misses, illusion dissipates");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Illusory Reality", "bonus, 1 min, choose 1 inanimate, nonmagical object in illusion - make it real");
            }
        }
        public static void Necromancy(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Necromancy Savant", "gold/time to copy a Necromancy spell into your spellbook is halved");
            character.ClassFeatures.Add("Grim Harvest", "1/turn, when kill, regain HP = spell lvl x 2 or x 3 if its Necromancy spell");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Undead Thralls", "when cast Animate Dead, undead get - HP + lvl, dmg + PB");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Inured to Undeath", "gain Resistance to Necrotic, max HP can't be reduced");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Command Undead", "action, Cha save, if Int 8+ adv, if Int 12+ it can save every hr");
            }
        }
        public static void OrderOfScribes(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Wizardly Quill", "bonus, create Tiny quill - doesn't require ink, copies spells in 2 min/lvl, can erase anything you write");
            character.ClassFeatures.Add("Awakened Spellbook", "when you cast a spell, dmg type = another spell you know the same lvl / LR, cast a ritual in 10 min");
            character.ClassFeatures["Spellcasting"] = "use Int for spell DCs, use Arcane Focus or Spellbook as a spell focus";
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Manifest Mind", "LR, bonus, 60ft, Awakened Spellbook = spectral Tiny object - Darkvision 60ft, telepathy / bonus, move 30ft - must stay within 300ft" +
                    "\n        PB/LR, cast a spell from object's location");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Master Scrivener", "on LR, create scroll of 1st or 2nd lvl (cast time 1 action), treat spell as 1 lvl higher" +
                    "\n        creating spell scroll magic items requires half time/gp costs");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("One with the Word", "gain adv on Arcana / LR, reaction, when you take dmg, dismiss Manifest Mind to negate all dmg" +
                    "\n        after reaction, temporarily lose 3D6 lvls of spells - regain them after 1D6 LR");
            }
        }
        public static void Transmutation(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Transmutation Savant", "gold/time to copy a Transmutation spell into your spellbook is halved");
            character.ClassFeatures.Add("Minor Alchemy", "10 min = 1ft, 1 hr, change one substance to another (wood, stone - not gems, iron, copper, or silver)");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Transmuter's Stone", "gain Darkvision, speed + 10ft, prof in Con saves, or Resistance to Cold, Fire, Lighting, or Thunder" +
                    "\n        when you cast a Transmutation spell, you can change the effect");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Shapechanger", "add Polymorph to spellbook, can cast it (SR) without expending a slot to change into a beast CR 1 or lower");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Master Transmuter", "action, destroy transmuter's stone to - transform 5ft object into another, remove all disease/curses/poisons/heal full HP," +
                    "\n        cast Raise Dead, or reduce creature's appearance by 3D10 yr (min 13 yr)");
            }
        }
        public static void WarMagic(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Arcane Deflection", "reaction, when hit or fail a save, +2 AC or save + 4 - can't cast non-Cantrips after using");
            character.ClassFeatures.Add("Tactical Wit", "Init + Int");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Power Surge", "gain pool of Power Surges(1/turn, dmg + 1/2 lvl), max Power Surges = Int, LR = 1" +
                    "\n        if SR with 0 - gain 1, gain 1 when you succesfully use Dispel Magic or Counterspell");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Durable Magic", "while using conc spell, AC and saves + 2");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Deflecting Shroud", "when you use Arcane Deflection, 60ft, 3 creatures, Force dmg = 1/2 lvl");
            }
        }
        public static void Spells(Character character)
        {
            int lvl = character.Lvl;
            AllSpells spells = new AllSpells(character);
            if (ArcaneTradition == "Chronurgy Magic" || ArcaneTradition == "Graviturgy Magic")
            {
                AddDunamancySpells(spells.Wizard, ArcaneTradition);
            }
            AllSpells.GetSpellDesc(spells.Wizard);
            string pickMsg = "Pick a cantrip.";
            for (int i = 0; i < character.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(spells.Wizard[0], character.Cantrips, pickMsg);
                character.Cantrips.Add(spell);
            }
            pickMsg = "Pick a 1st level spell.";
            for (int i = 0; i < 6; i++)
            {
                string spell = CLIHelper.GetNew(spells.Wizard[1], character.Spells[1], pickMsg);
                character.Spells[1].Add(spell);
                spells.Wizard[1].Remove(spell);
            }
            int spellLvl = 1;
            for (int i = 2; i <= lvl; i++)
            {
                if (3 <= i && i <= 17 && i % 2 != 0)
                {
                    spellLvl++;
                    pickMsg = CLIHelper.pickSpellLevel(i, 3, 5, 7, pickMsg, spellLvl);
                }
                string spell = CLIHelper.GetNew(spells.Wizard[spellLvl], character.Spells[spellLvl], pickMsg);
                character.Spells[spellLvl].Add(spell);
                spells.Wizard[spellLvl].Remove(spell);
                spell = CLIHelper.GetNew(spells.Wizard[spellLvl], character.Spells[spellLvl], pickMsg);
                character.Spells[spellLvl].Add(spell);
                spells.Wizard[spellLvl].Remove(spell);
            }
        }
        public static void AddDunamancySpells(Dictionary<int, List<string>> dict, string arcaneTrad)
        {
            if (arcaneTrad == "Chronurgy Magic")
            {
                dict[1].Add("Gift of Alacrity");
                dict[5].Add("Temporal Shunt");
                dict[8].Add("Reality Break");
                dict[9].Add("Time Ravage");
            }
            if (arcaneTrad == "Graviturgy Magic")
            {
                dict[1].Add("Magnify Gravity");
                dict[2].Add("Immovable Object");
                dict[4].Add("Gravity Sinkhole");
                dict[6].Add("Gravity Fissure");
                dict[8].Add("Dark Star");
                dict[9].Add("Ravenous Void");
            }
            dict[0].Add("Sapping Sting");
            dict[2].Add("Fortune's Favor");
            dict[2].Add("Wristpocket");
            dict[3].Add("Pulse Wave");
            dict[7].Add("Tether Essence");
            foreach (var item in dict.Keys)
            {
                dict[item].Sort();
            }
        }
    }
}
