using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class BardSpecifics
    {
        public static string BardicCollege { get; set; }
        public static CharacterClass Features(CharacterClass result, Character character)
        {
            int lvl = result.Lvl;
            int bardicInspiration = 6;
            int songOfRest = 6;

            for (int i = 0; i <= lvl; i++)
            {
                if (i == 5 || i == 10 || i == 15)
                {
                    bardicInspiration += 2;
                }
                if (i == 9 || i == 13 || i == 17)
                {
                    songOfRest += 2;
                }
            }

            result.ClassFeatures.Add($"Bardic Inspiration(D{bardicInspiration})","Cha/LR, bonus, 60ft, use on ally, add to atk, save, or ability check");
            result.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use a musical instrument as a spell focus");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Jack of All Trades", "add 1/2 prof bonus to untrained skills");
                result.ClassFeatures.Add($"Song of Rest(D{songOfRest})", "regain HP of yourself or allies during SR");
                result.ClassFeatures.Add("Magical Inspiration", "use Bardic Inspiration to increase an ally's healing or dmg");
            }
            if (lvl >= 3)
            {
                result.ClassFeatures.Add("Expertise", "pick 2 skills, or 1 skill and 1 tool prof, double prof bonus");
                Console.WriteLine("Would you like to gain Expertise in 2 skills or 1 skill and 1 tool prof?");
                CLIHelper.Print2Choices("2 skills", "1 skill and 1 tool prof");
                int num = CLIHelper.GetNumberInRange(1, 2);
                string expertise = "";
                var prof = new List<string>();
                prof.AddRange(character.SkillProficiencies);
                if (num == 1)
                {
                    expertise = CLIHelper.PrintChoices(prof);
                    character.Skills[expertise] += character.ProficiencyBonus;
                    prof.Remove(expertise);
                    expertise = CLIHelper.PrintChoices(prof);
                    character.Skills[expertise] += character.ProficiencyBonus;
                }
                else
                {
                    expertise = CLIHelper.PrintChoices(prof);
                    character.Skills[expertise] += character.ProficiencyBonus;
                    prof.Clear();
                    prof.AddRange(character.ToolProficiencies);
                    expertise = CLIHelper.PrintChoices(prof);
                    character.ToolProficiencies.Remove(expertise);
                    character.ToolProficiencies.Add(expertise + "(Expertise)");
                }
                string msg = "Pick a Bardic College that will give you features at levels 3, 6, and 14.";
                var archetype = new List<string> { "College of Creation", "College of Eloquence", "College of Glamour", "College of Lore",
                    "College of Swords", "College of Valor", "College of Whispers"};
                int answer = CLIHelper.PrintChoices(msg, archetype);
                BardicCollege = archetype[answer].Substring(11);

                switch (BardicCollege)
                {
                    case "Creation":
                        string size = "Medium";
                        if (lvl >= 6)
                        {
                            size = "Large";
                        }
                        if (lvl >= 14)
                        {
                            size = "Huge";
                        }
                        result.ClassFeatures.Add("Mote of Potential", "additional benefits from Bardic Inspiration - check(roll twice), atk(Con save, adj, Thunder dmg), save(gain Temp HP = roll + Cha)");
                        result.ClassFeatures.Add("Performance of Creation", $"LR or 2nd lvl spell slot, action, hr/prof bonus, 10ft, create a {size} nonmagical item - value = lvl * 20gp, glimmers and soft music");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Animating Performance", "LR or 3rd lvl spell slot, action, 1 hr, 30ft, animate a nonmagical item, default to Dodge, shares Init" +
                                "\ncommand with bonus or when using Bardic Inspiration, if you're incap it can take any action");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Creative Crescendo", "When you use Performance of Creation, create Cha items - only one can be max Size, rest must be Small or Tiny, no gp limit");
                        }
                        break;
                    case "Eloquence":
                        result.ClassFeatures.Add("Silver Tongue", "treat a roll below 10 on Deception or Persuasion as a 10");
                        result.ClassFeatures.Add("Unsettling Words", "bonus, 60ft, expend Bardic Inspiration, next save - roll");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Unfailing Inspiration", "When an ally with Bardic Inspiration fails, they keep the Bardic Inspiration die");
                            result.ClassFeatures.Add("Universal Speech", "LR or spell slot, action, 60ft, 1 hr, Cha creatures, creatures understood you regardless of language");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Infectious Inspiration", "Cha/LR, reaction, 60ft, when ally uses Bardic Inspiration, give another ally Bardic Inspiration without expending a use");
                        }
                        break;
                    case "Glamour":
                        int tempHP = 5;
                        for (int i = 1; i <= lvl; i++)
                        {
                            if (i % 5 == 0 && i != 20)
                            {
                                tempHP += 3;
                            }
                        }
                        result.ClassFeatures.Add("Mantle of Inspiration", $"bonus, 60ft, Cha creatures, use Bardic Inspiration to give {tempHP} temp HP and" +
                            $"\nallies can move their speed, no atk op");
                        result.ClassFeatures.Add("Enthralling Performance", "after 1 min performance, SR, 1 hr, 60ft, Cha creatures, Wis save, charm and idolizing, if you fail" +
                            "\nthe target is unaware of charm attempt");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Mantle of Majesty", "LR, 1 min, gain unearthly beauty, bonus - cast Command, if charmed auto-fail Command's save");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Unbreakable Majesty", "SR, bonus, 1 min, when attacked, Cha save, must choose new target, if fail - disadv on saves vs your spells");
                        }
                        break;
                    case "Lore":
                        msg = "Pick 3 skills to gain proficiency in";
                        string errorMsg = "You are already trained in that skill, pick a different skill.";
                        for (int i = 0; i < 3; i++)
                        {
                            string skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, msg, errorMsg);
                            character.SkillProficiencies.Add(skill);
                        }

                        result.ClassFeatures.Add("Cutting Words", "60ft, minus Bardic Inspiration from atk, dmg, ability check");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Additional Magical Secrets", "gain 2 new spells from any class (pick them separately)");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Peerless Skill", "use Bardic Inspiration on self for an ability check");
                        }
                        break;
                    case "Swords":
                        result.Proficiencies.Add("Medium Armor");
                        result.Proficiencies.Add("Scimitar");
                        result.ClassFeatures["Spellcasting"] += ", proficient weapons can also be used as a spell focus";
                        string fightStyleMsg = "Pick a fighting style.";
                        List<string> styleList = new List<string> { "Dueling", "Two-Weapon Fighting" };
                        string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                        string fightStyleKey = $"Fighting Style({fightStyle})";
                        string fightStyleValue = Options.FightingStyles[fightStyle];
                        result.ClassFeatures.Add(fightStyleKey, fightStyleValue);
                        result.ClassFeatures.Add("Blade Flourish", "When atk, speed +10ft, use 1 of the 3 Flourishes" +
                            "\nDefensive Flourish(use Bardic Inspiration to gain AC and extra dmg)" +
                            "\nSlashing Flourish(use Bardic Inspiration to gain extra dmg and dmg adj creature)" +
                            "\nMobile Flourish(use Bardic Inspiration to gain extra dmg and push 5 + die roll ft, reaction - move your speed toward target)");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Master's Flourish", "When you use Blade Flourish, you can use 1D6 instead of expending Bardic Inspiration");
                        }
                        break;
                    case "Valor":
                        character.Proficiencies.Add("Medium Armor");
                        character.Proficiencies.Add("Shields");
                        character.Proficiencies.Add("Martial Weapons");
                        result.ClassFeatures.Add("Combat Inspiration", "after Bardic Inspiration use - add to dmg or use reaction to add to AC");

                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Battle Magic", "bonus, when you cast a spell, make wep atk");
                        }
                        break;
                    case "Whispers":
                        int psychicDice = 2;
                        if (lvl >= 5)
                        {
                            psychicDice++;
                        }
                        if (lvl >= 10)
                        {
                            psychicDice += 2;
                        }
                        if (lvl >= 5)
                        {
                            psychicDice += 3;
                        }
                        result.ClassFeatures.Add("Psychic Blades", $"1/turn, on hit, use Bardic Inspiration to deal {psychicDice}D6 Psychic dmg");
                        result.ClassFeatures.Add("Words of Terror", "SR, speak for 1 min, Wis save, choose creature for target to fear");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Mantle of Whispers", "SR, reaction, 30ft, when creature dies, gain shadow" +
                                "\naction, use shadow, 1 hr, becomes disguise of dead person, Deception + 5");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Shadow Lore", "LR, action, 30ft, 1 creature, must share lang, Wis save, charm 8 hr, obeys commands, grants gifts/favors as if close friend");
                        }
                        break;
                }
            }
            if (lvl >= 4)
            {
                result.ClassFeatures.Add("Bardic Versatility", "When you gain an Ability Score Improvement, change your Expertise or replace a cantrip");
            }
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Font of Inspiration", "regain Bardic Inspiration from SR");
            }
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Countercharm", "action, 30ft, you and allies, adv vs fear and charm effects");
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Magical Secrets", "gain 2 new spells from any class (pick them separately)");
                result.ClassFeatures.Add("Expertise II", "pick 2 skills, or 1 skill and 1 tool prof, double prof bonus");
                Console.WriteLine("Would you like to gain Expertise in 2 skills or 1 skill and 1 tool prof?");
                CLIHelper.Print2Choices("2 skills", "1 skill and 1 tool prof");
                int num = CLIHelper.GetNumberInRange(1, 2);
                string expertise = "";
                var prof = new List<string>();
                prof.AddRange(character.SkillProficiencies);
                if (num == 1)
                {
                    expertise = CLIHelper.PrintChoices(prof);
                    character.Skills[expertise] += character.ProficiencyBonus;
                    prof.Remove(expertise);
                    expertise = CLIHelper.PrintChoices(prof);
                    character.Skills[expertise] += character.ProficiencyBonus;
                }
                else
                {
                    expertise = CLIHelper.PrintChoices(prof);
                    character.Skills[expertise] += character.ProficiencyBonus;
                    prof.Clear();
                    prof.AddRange(character.ToolProficiencies);
                    expertise = CLIHelper.PrintChoices(prof);
                    character.ToolProficiencies.Remove(expertise);
                    character.ToolProficiencies.Add(expertise + "(Expertise)");
                }
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Magical Secrets II", "gain 2 new spells from any class (pick them separately)");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Magical Secrets III", "gain 2 new spells from any class (pick them separately)");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Superior Inspiration", "on Init, if you have no Bardic Inspiration - regain 1 use");
            }
            //spells code
            string pickMsg = "Pick a cantrip.";
            string str2 = "You already have that cantrip.";
            int spellLvl = 1;
            AllSpells spells = new AllSpells(character.ChosenClass);

            for (int i = 0; i < result.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(spells.Bard[0], result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
                spells.Bard[0].Remove(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";

            for (int i = 1; i <= result.SpellsKnown; i++)
            {
                if (i > 5)
                {
                    if (i <= 13 && i % 2 == 0)
                    {
                        spellLvl++;
                    }
                    if (i == 15 || i == 16 || i == 19 || i == 20)
                    {
                        spellLvl++;
                    }
                }
                if (i == 6)
                {
                    pickMsg = "Pick a 2nd level spell.";
                }
                if (i == 8)
                {
                    pickMsg = "Pick a 3rd level spell.";
                }
                if (i >= 10)
                {
                    pickMsg = $"Pick a {spellLvl}th level spell.";
                }
                if (i != 13 || i != 14 || i != 17 || i != 18 || i != 21 || i != 22)
                {
                    string spell = CLIHelper.GetNew(spells.Bard[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                    result.Spells[spellLvl].Add(spell);
                    spells.Bard[spellLvl].Remove(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
