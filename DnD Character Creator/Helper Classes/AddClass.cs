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
            character.HP += character.HitDie + character.ConMod;
            Console.WriteLine("Would you like to roll for your HP or take the average?");
            //CLIHelper.Print2Choices("Take average", "Roll");
            int input = CLIHelper.GetChoiceFromPair("Take average", "Roll");
            int con = character.ConMod;
            int hitDie = character.HitDie;

            if (character.CrossClass)
            {
                if (input == 1)
                {
                    character.HP += AverageHP(hitDie, character.BaseClassLvl, con);
                    character.HP += AverageHP(character.HitDieII, character.OffClassLvl, con);
                }
                else
                {
                    character.HP += RolledHP(hitDie, character.BaseClassLvl, con);
                    character.HP += RolledHP(character.HitDieII, character.OffClassLvl, con);
                }
            }
            else
            {
                if (input == 1)
                {
                    character.HP += AverageHP(hitDie, character.Lvl, con);
                }
                else
                {
                    character.HP += RolledHP(hitDie, character.Lvl, con);
                }
            }
        }
        public static int AverageHP(int hitDie, int lvl, int con)
        {
            int hitDieAvg = (hitDie / 2) + 1;

            return lvl * (hitDieAvg + con);
        }
        public static int RolledHP(int hitDie, int lvl, int con)
        {
            DieRoll rHitDie = new DieRoll(hitDie);
            int HP = 0;

            for (int i = 0; i < lvl; i++)
            {
                HP += (rHitDie.RollDie() + con);
            }

            return HP;
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
            string classStr = character.ChosenClass;
            int lvl = 0;
            if (character.CrossClass)
            {
                lvl = character.BaseClassLvl;
            }
            else
            {
                lvl = character.Lvl;
            }
            var cantrips = new List<string> { "Artificer", "Bard", "Cleric", "Druid", "Psion", "Sorcerer", "Swordmage", "Warlock", "Wizard" };

            if (cantrips.Contains(classStr))
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
                if (classStr == "Cleric" || classStr == "Wizard")
                {
                    character.CantripsKnown++;
                }
                if (classStr == "Sorcerer")
                {
                    character.CantripsKnown += 2;
                }
            }
            //end cantrips
            if (classStr == "Bard")
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
            if (classStr == "Ranger")
            {
                if (lvl >= 2)
                {
                    character.SpellsKnown = 2;
                }
                for (int i = 3; i < lvl; i += 2)
                {
                    character.SpellsKnown++;
                }
            }
            if (classStr == "Sorcerer" || classStr == "Swordmage")
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
            if (classStr == "Psion" || classStr == "Warlock")
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
            int lvl = 0;
            if (character.CrossClass)
            {
                CalculateCrossClassSlots(character);
                return;
            }
            else
            {
                lvl = character.Lvl;
            }
            var primaryCasters = new List<string> { "Bard", "Cleric", "Druid", "Sorcerer", "Wizard" };

            if (primaryCasters.Contains(classString))
            {
                CalculatePrimaryCasterSlots(character, lvl);
            }
            if (classString == "Warlock")
            {
                CalculateWarlockSlots(character, lvl);
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
        public static void CalculateCrossClassSlots(Character character)
        {
            string classString = character.ChosenClass;
            string offClassString = character.ChosenClassII;

            int lvl = 0;
            var primaryCasters = new List<string> { "Bard", "Cleric", "Druid", "Sorcerer", "Wizard" };
            var secondaryCasters = new List<string> { "Artificer", "Paladin", "Ranger", "Swordmage" };
            var dipCasters = new List<string> { "Fighter", "Rogue" };

            if (primaryCasters.Contains(classString))
            {
                lvl += character.BaseClassLvl;
            }
            if (primaryCasters.Contains(offClassString))
            {
                lvl += character.OffClassLvl;
            }
            if (secondaryCasters.Contains(classString))
            {
                lvl += (character.BaseClassLvl) / 2;
            }
            if (secondaryCasters.Contains(offClassString))
            {
                lvl += (character.OffClassLvl) / 2;
            }
            if (dipCasters.Contains(classString))
            {
                lvl += (character.BaseClassLvl) / 3;
            }
            if (dipCasters.Contains(offClassString))
            {
                lvl += (character.OffClassLvl) / 3;
            }
            CalculatePrimaryCasterSlots(character, lvl);
            if (classString == "Warlock")
            {
                CalculateWarlockSlots(character, character.BaseClassLvl);
            }
            if (offClassString == "Warlock")
            {
                CalculateWarlockSlots(character, character.OffClassLvl);
            }
        }
        public static void CalculateWarlockSlots(Character character, int lvl)
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
        public static void CalculatePrimaryCasterSlots(Character character, int lvl)
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
        public static void NewClass(Character character, int lvl)
        {
            int maintainLvl = character.Lvl;

            if (character.CrossClass)
            {
                character.Lvl = lvl;
            }
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
            if (character.CrossClass)
            {
                character.Lvl = maintainLvl;
            }
        }
        public static void OffClass(Character character, int lvl)
        {
            int maintainLvl = character.Lvl;
            string skill, msg, pickMsg = "";
            int index = -1;
            List<string> classSkills = new List<string>();

            if (character.CrossClass)
            {
                character.Lvl = lvl;
            }
            switch (character.ChosenClassII)
            {
                case "Artificer":
                    character.HitDieII = 6;
                    Artificer.Features(character);
                    character.Archetype = Artificer.ArtificerSpecialist;
                    break;
                case "Barbarian":
                    character.HitDieII = 12;
                    character.Proficiencies.Add("Shields");
                    character.Proficiencies.Add("Simple weapons");
                    character.Proficiencies.Add("Martial weapons");
                    Barbarian.Features(character);
                    character.Archetype = Barbarian.PathName;
                    break;
                case "Bard":
                    character.HitDieII = 8;
                    character.Proficiencies.Add("Light armor");
                    skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, "Pick a skill to gain proficiency with");
                    character.SkillProficiencies.Add(skill);

                    var instruments = new List<string>();
                    instruments.AddRange(Options.MusicalInstruments);
                    foreach(var item in character.ToolProficiencies)
                    {
                        if (instruments.Contains(item))
                        {
                            instruments.Remove(item);
                        }
                    }
                    msg = "Pick a musical instrument to gain proficiency with";
                    index = CLIHelper.PrintChoices(msg, instruments);
                    string instrument = instruments[index];
                    character.ToolProficiencies.Add(instrument);

                    Bard.Features(character);
                    character.Archetype = Bard.BardicCollege;
                    break;
                case "Bloodhunter":
                    character.HitDieII = 10;
                    Bloodhunter.Features(character);
                    character.Archetype = Bloodhunter.BloodhunterOrder;
                    break;
                case "Cleric":
                    character.HitDieII = 8;
                    character.Proficiencies.Add("Light armor");
                    character.Proficiencies.Add("Medium armor");
                    character.Proficiencies.Add("Shields");
                    Cleric.Features(character);
                    character.Archetype = Cleric.DivineDomain;
                    break;
                case "Druid":
                    character.HitDieII = 8;
                    character.Proficiencies.Add("Light armor");
                    character.Proficiencies.Add("Medium armor");
                    character.Proficiencies.Add("Shields");
                    Druid.Features(character);
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
                        msg = "Pick a star map to be your new spell focus";
                        var starMaps = new List<string>();
                        foreach (var item in Options.StarMaps)
                        {
                            starMaps.Add(item.Substring(8, item.Length - 1));
                        }
                        index = CLIHelper.PrintChoices(msg, starMaps);
                        character.Equipment.Add(Options.StarMaps[index]);
                    }
                    break;
                case "Fighter":
                    character.HitDieII = 10;
                    character.Proficiencies.Add("Light armor");
                    character.Proficiencies.Add("Medium armor");
                    character.Proficiencies.Add("Shields");
                    character.Proficiencies.Add("Simple weapons");
                    character.Proficiencies.Add("Martial weapons");
                    Fighter.Features(character);
                    character.Archetype = Fighter.MartialArchetype;
                    break;
                case "Monk":
                    character.HitDieII = 8;
                    character.Proficiencies.Add("Simple weapons");
                    character.Proficiencies.Add("Shortswords");
                    Monk.Features(character);
                    character.Archetype = Monk.MonasticTradition;
                    break;
                case "Paladin":
                    character.HitDieII = 10;
                    character.Proficiencies.Add("Light armor");
                    character.Proficiencies.Add("Medium armor");
                    character.Proficiencies.Add("Shields");
                    character.Proficiencies.Add("Simple weapons");
                    character.Proficiencies.Add("Martial weapons");
                    Paladin.Features(character);
                    character.Archetype = Paladin.SacredOath;
                    break;
                case "Psion":
                    character.HitDieII = 6;
                    Psion.Features(character);
                    break;
                case "Ranger":
                    character.HitDieII = 10;
                    character.Proficiencies.Add("Light armor");
                    character.Proficiencies.Add("Medium armor");
                    character.Proficiencies.Add("Shields");
                    character.Proficiencies.Add("Simple weapons");
                    character.Proficiencies.Add("Martial weapons");

                    classSkills = new List<string> { "Animal Handling", "Athletics", "Insight", "Investigation", "Nature",
                        "Perception", "Stealth", "Survival" };
                    pickMsg = $"Pick a skill from the Ranger's skill list";
                    skill = CLIHelper.GetNew(classSkills, character.SkillProficiencies, pickMsg);
                    character.SkillProficiencies.Add(skill);

                    Ranger.Features(character);
                    character.Archetype = Ranger.RangerArchetype;
                    break;
                case "Rogue":
                    character.HitDieII = 8;
                    character.Proficiencies.Add("Light armor");
                    character.ToolProficiencies.Add("Thieves' Tools");

                    classSkills = new List<string> { "Acrobatics", "Animal Handling", "Athletics", "Deception", "Insight",
                        "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth" };
                    pickMsg = $"Pick a skill from the Rogue's skill list";
                    skill = CLIHelper.GetNew(classSkills, character.SkillProficiencies, pickMsg);
                    character.SkillProficiencies.Add(skill);

                    Rogue.Features(character);
                    character.Archetype = Rogue.RoguishArchetype;
                    break;
                case "Sorcerer":
                    character.HitDieII = 6;
                    Sorcerer.Features(character);
                    character.Archetype = Sorcerer.SorcerousOrigin;
                    break;
                case "Swordmage":
                    character.HitDieII = 10;
                    Swordmage.Features(character); 
                    var swords = new List<string> { "Claymore", "Greatsword", "Longsword", "Rapier", "Sabre", "Scimitar", "Shortsword" };
                    character.Proficiencies.Add("Light armor");
                    character.Proficiencies.Add("Medium armor");
                    character.Proficiencies.Add("Simple weapons");
                    foreach (var item in swords)
                    {
                        character.Proficiencies.Add(item + "s");
                    }
                    character.Archetype = Swordmage.ArcaneSwordStyle;
                    break;
                case "Warlock":
                    character.HitDieII = 8;
                    character.Proficiencies.Add("Light armor");
                    character.Proficiencies.Add("Simple weapons");
                    Warlock.Features(character);
                    character.Archetype = Warlock.OtherworldlyPatron;
                    break;
                case "Wizard":
                    character.HitDieII = 6;
                    Wizard.Features(character);
                    character.Archetype = Wizard.ArcaneTradition;
                    break;
            }
            if (character.CrossClass)
            {
                character.Lvl = maintainLvl;
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
