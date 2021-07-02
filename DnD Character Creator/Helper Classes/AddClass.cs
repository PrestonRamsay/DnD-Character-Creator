using System;
using System.Collections.Generic;
using DnD_Character_Creator.CharacterPieces.Classes;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class AddClass
    {
        public static void DetermineAC(Character character)
        {
            character.AC += 10 + character.DexMod;
            string arch = character.Archetype;
            var AC13 = new List<string> { "Draconic Bloodline", "Psychometabolism(Egoist)", "Stone Sorcery" };
            if (character.ChosenClass == "Barbarian" || character.Feats.ContainsKey("Unarmored Defense(Con)"))
            {
                character.AC += character.Stats["Con"];
            }
            else if (character.ChosenClass == "Monk" || character.Feats.ContainsKey("Unarmored Defense(Wis)"))
            {
                character.AC += character.Stats["Wis"];
            }
            else if (AC13.Contains(arch) || character.Feats.ContainsKey("Dragon Hide"))
            {
                character.AC += 3;
            }
            else
            {
                string armorAC = "";
                int intValue = 0;
                foreach (var item in character.Equipment)
                {
                    if (item.Contains("AC"))
                    {
                        int index = item.IndexOf("AC");
                        armorAC = item.Substring(index - 2, 1);

                        if (int.TryParse(armorAC, out intValue))
                        {
                            character.AC += intValue;
                        }
                    }
                }
            }
            if (character.Feats.ContainsKey("Insightful Reflexes"))
            {
                character.AC += character.IntMod;
                character.AC -= character.DexMod;
            }

        }
        public static void DetermineHP(Character character)
        {
            Console.WriteLine("Would you like to roll for your HP or take the average?");
            CLIHelper.Print2Choices("Take average", "Roll");
            int input = CLIHelper.GetNumberInRange(1, 2);
            int firstLvlHP = character.HitDie + character.ConMod;
            int remainingLvls = character.Lvl - 1;

            if (input == 1)
            {
                int hitDieAvg = (character.HitDie / 2) + 1;
                character.HP += firstLvlHP + (remainingLvls * (hitDieAvg + character.ConMod));
            }
            else
            {
                DieRoll hitDie = new DieRoll(character.HitDie);
                int HP = firstLvlHP;

                for (int i = 0; i < remainingLvls; i++)
                {
                    HP += (hitDie.RollDie() + character.ConMod);
                }

                character.HP += HP;
            }
        }
        public static void ModifySkills(Character character)
        {
            var skillList = new List<string>();
            var expList = new List<string>();
            var skills = new Dictionary<string, int>();

            foreach (string skill in character.Skills.Keys)
            {
                skills.Add(skill, character.Skills[skill]);
                if (skills[skill] != 0)
                {
                    expList.Add(skill);
                }
                if (skill.Contains("Str"))
                {
                    skills[skill] += character.StrMod;
                }
                else if (skill.Contains("Dex"))
                {
                    skills[skill] += character.DexMod;
                }
                else if (skill.Contains("Con"))
                {
                    skills[skill] += character.ConMod;
                }
                else if (skill.Contains("Int"))
                {
                    skills[skill] += character.IntMod;
                }
                else if (skill.Contains("Wis"))
                {
                    skills[skill] += character.WisMod;
                }
                else if (skill.Contains("Cha"))
                {
                    skills[skill] += character.ChaMod;
                }
                string withoutStat = skill.Substring(0, skill.Length - 5);
                if (character.SkillProficiencies.Contains(withoutStat))
                {
                    skills[skill] += character.ProficiencyBonus;
                    string fullSkill = $"(t) {skill}";
                    if (expList.Contains(skill))
                    {
                        fullSkill = $"(e)(t) {skill}";
                    }
                    skillList.Add(fullSkill);
                    skills.Add(fullSkill, skills[skill]);
                    skills.Remove(skill);
                }
                else
                {
                    skillList.Add(skill);
                    if (character.ClassFeatures.ContainsKey("Jack of All Trades") || character.Feats.ContainsKey("Jack of All Trades"))
                    {
                        skills[skill] += (character.ProficiencyBonus) / 2;
                    }
                }
            }
            character.Skills.Clear();

            foreach (var skill in skillList)
            {
                character.Skills.Add(skill, skills[skill]);
            }
        }
        public static void AddSpellsKnown(Character character)
        {
            string classString = character.ChosenClass;
            int lvl = character.Lvl;
            var cantrips = new List<string> { "Artificer", "Bard", "Cleric", "Druid", "Psion", "Sorcerer", "Swordmage", "Warlock", "Wizard" };

            if (cantrips.Contains(classString))
            {
                character.CantripsKnown = 2;
                if (lvl >= 4)
                {
                    character.CantripsKnown++;
                }
                if (lvl >= 10)
                {
                    character.CantripsKnown++;
                }
                if (classString == "Cleric" || classString == "Wizard")
                {
                    character.CantripsKnown++;
                }
                if (classString == "Sorcerer")
                {
                    character.CantripsKnown += 2;
                }
            }
            //end cantrips
            if (classString == "Bard")
            {
                character.SpellsKnown = 4;
                for (int i = 2; i <= lvl; i++)
                {
                    if (i <= 9 || i == 11 || i == 15 || i == 17)
                    {
                        character.SpellsKnown++;
                    }
                    if (i == 10 || i == 14 || i == 18)
                    {
                        character.SpellsKnown += 2;
                    }
                }
            }
            if (classString == "Sorcerer" || classString == "Swordmage")
            {
                character.SpellsKnown = 2;
                for (int i = 2; i <= lvl; i++)
                {
                    if (i <= 11 || i == 13 || i == 15 || i == 17)
                    {
                        character.SpellsKnown++;
                    }
                }
            }
            if (classString == "Psion" || classString == "Warlock")
            {
                character.SpellsKnown = 2;
                for (int i = 2; i <= lvl; i++)
                {
                    if (i <= 9 || i == 11 || i == 13 || i == 15 || i == 17 || i == 19)
                    {
                        character.SpellsKnown++;
                    }
                }
            }
        }
        public static void AddSpellSlots(Character character)
        {
            string classString = character.ChosenClass;
            int lvl = character.Lvl;
            var primaryCasters = new List<string> { "Bard", "Cleric", "Druid", "Sorcerer", "Wizard" };

            if (primaryCasters.Contains(classString))
            {
                int spellSlotLvl = 0;
                int lvlToInc = 5;
                for (int i = 1; i <= lvl; i++)
                {
                    if (i % 2 != 0 && i <= 17)
                    {
                        spellSlotLvl++;
                        if (i <= 5)
                        {
                            character.SpellSlots[spellSlotLvl] += 2;
                        }
                        else
                        {
                            character.SpellSlots[spellSlotLvl] += 1;
                        }
                    }
                    if (i % 2 == 0 && i <= 10)
                    {
                        character.SpellSlots[spellSlotLvl]++;
                    }
                    if (i >= 18)
                    {
                        character.SpellSlots[lvlToInc]++;
                        lvlToInc++;
                    }
                }
            }
            if (classString == "Warlock")
            {
                int spellSlotLvl = 2;

                for (int i = 1; i <= lvl; i++)
                {
                    if (i <= 2)
                    {
                        character.SpellSlots[1]++;
                    }
                    if (i % 2 != 0 && i <= 9)
                    {
                        character.SpellSlots.Remove(spellSlotLvl - 1);
                        character.SpellSlots[spellSlotLvl] += 2;
                        spellSlotLvl++;
                    }
                    if (i == 11 || i == 17)
                    {
                        character.SpellSlots[5]++;
                    }
                }
            }
            var secondaryCasters = new List<string> { "Artificer", "Paladin", "Ranger", "Swordmage" };
            if (secondaryCasters.Contains(classString))
            {
                int spellSlotLvl = 1;
                if (classString == "Paladin" || classString == "Ranger")
                {
                    if (lvl >= 2)
                    {
                        character.SpellSlots[1] += 2;
                    }
                }
                else
                {
                    character.SpellSlots[1] += 2;
                }
                for (int i = 3; i <= lvl; i += 2)
                {
                    if ((i != 9 || i != 13) && i <= 17)
                    {
                        character.SpellSlots[spellSlotLvl]++;
                    }
                    if (i == 5 || i == 9)
                    {
                        spellSlotLvl++;
                        character.SpellSlots[spellSlotLvl] += 2;
                    }
                    if (i == 13 || i == 17)
                    {
                        spellSlotLvl++;
                        character.SpellSlots[spellSlotLvl]++;
                    }
                }
            }
        }
        public static void NewClass(Character character)
        {
            switch (character.ChosenClass)
            {
                case "Artificer":
                    AddArtificer(character);
                    break;
                case "Barbarian":
                    AddBarbarian(character);
                    break;
                case "Bard":
                    AddBard(character);
                    break;
                case "Bloodhunter":
                    AddBloodhunter(character);
                    break;
                case "Cleric":
                    AddCleric(character);
                    break;
                case "Druid":
                    AddDruid(character);
                    break;
                case "Fighter":
                    AddFighter(character);
                    break;
                case "Monk":
                    AddMonk(character);
                    break;
                case "Paladin":
                    AddPaladin(character);
                    break;
                case "Psion":
                    AddPsion(character);
                    break;
                case "Ranger":
                    AddRanger(character);
                    break;
                case "Rogue":
                    AddRogue(character);
                    break;
                case "Sorcerer":
                    AddSorcerer(character);
                    break;
                case "Swordmage":
                    AddSwordmage(character);
                    break;
                case "Warlock":
                    AddWarlock(character);
                    break;
                case "Wizard":
                    AddWizard(character);
                    break;
            }
        }
        public static void AddArtificer(Character character)
        {
            Artificer.Base(character);
            Artificer.Features(character);
            Artificer.Equipment(character);
            character.Archetype = Artificer.ArtificerSpecialist;
        }
        public static void AddBarbarian(Character character)
        {
            Barbarian.Base(character);
            Barbarian.Features(character);
            Barbarian.Equipment(character);
            character.Archetype = Barbarian.PathName;
        }
        public static void AddBard(Character character)
        {
            Bard.Base(character);
            Bard.Features(character);
            Bard.Equipment(character);
            character.Archetype = Bard.BardicCollege;
        }
        public static void AddBloodhunter(Character character)
        {
            Bloodhunter.Base(character);
            Bloodhunter.Features(character);
            Bloodhunter.Equipment(character);
            character.Archetype = Bloodhunter.BloodhunterOrder;
        }
        public static void AddCleric(Character character)
        {
            Cleric.Base(character);
            Cleric.Features(character);
            Cleric.Equipment(character);
            character.Archetype = Cleric.DivineDomain;
        }
        public static void AddDruid(Character character)
        {
            Druid.Base(character);
            Druid.Features(character);
            Druid.Equipment(character);
            character.Archetype = Druid.DruidCircle;
            if (character.Archetype == "Stars")
            {
                string focus = "";
                foreach (var item in character.Equipment)
                {
                    if (character.Equipment.Contains("Druidic Focus"))
                    {
                        focus = item;
                    }
                }
                character.Equipment.Remove(focus);
                string msg = "Pick a star map to be your new spell focus";
                var starMaps = new List<string>();
                foreach (var item in Options.StarMaps)
                {
                    starMaps.Add(item.Substring(8, item.Length - 1));
                }
                int index = CLIHelper.PrintChoices(msg, starMaps);
                character.Equipment.Add(Options.StarMaps[index]);
            }
        }
        public static void AddFighter(Character character)
        {
            Fighter.Base(character);
            Fighter.Features(character);
            Fighter.Equipment(character);
            character.Archetype = Fighter.MartialArchetype;
        }
        public static void AddMonk(Character character)
        {
            Monk.Base(character);
            Monk.Features(character);
            Monk.Equipment(character);
            character.Archetype = Monk.MonasticTradition;
        }
        public static void AddPaladin(Character character)
        {
            Paladin.Base(character);
            Paladin.Features(character);
            Paladin.Equipment(character);
            character.Archetype = Paladin.SacredOath;
        }
        public static void AddPsion(Character character)
        {
            Psion.Base(character);
            Psion.Features(character);
            Psion.Equipment(character);
        }
        public static void AddRanger(Character character)
        {
            Ranger.Base(character);
            Ranger.Features(character);
            Ranger.Equipment(character);
            character.Archetype = Ranger.RangerArchetype;
        }
        public static void AddRogue(Character character)
        {
            Rogue.Base(character);
            Rogue.Features(character);
            Rogue.Equipment(character);
            character.Archetype = Rogue.RoguishArchetype;
        }
        public static void AddSorcerer(Character character)
        {
            Sorcerer.Base(character);
            Sorcerer.Features(character);
            Sorcerer.Equipment(character);
            character.Archetype = Sorcerer.SorcerousOrigin;
        }
        public static void AddSwordmage(Character character)
        {
            Swordmage.Base(character);
            Swordmage.Features(character);
            Swordmage.Equipment(character);
            character.Archetype = Swordmage.ArcaneSwordStyle;
        }
        public static void AddWarlock(Character character)
        {
            Warlock.Base(character);
            Warlock.Features(character);
            Warlock.Equipment(character);
            character.Archetype = Warlock.OtherworldlyPatron;
        }
        public static void AddWizard(Character character)
        {
            Wizard.Base(character);
            Wizard.Features(character);
            Wizard.Equipment(character);
            character.Archetype = Wizard.ArcaneTradition;
        }
    }
}
