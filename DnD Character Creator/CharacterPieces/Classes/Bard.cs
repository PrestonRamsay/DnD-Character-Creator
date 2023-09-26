using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Bard
    {
        public static string BardicCollege { get; set; }
        public static void Base(Character character)
        {
            List<string> classSkills = Options.Skills;

            character.GP += 125;
            character.HitDie = 8;
            character.Proficiencies.Add("Light armor");
            character.Proficiencies.Add("Simple weapons");
            character.Proficiencies.Add("Hand crossbows");
            character.Proficiencies.Add("Longswords");
            character.Proficiencies.Add("Rapiers");
            character.Proficiencies.Add("Shortswords");

            var instruments = new List<string>();
            instruments.AddRange(Options.MusicalInstruments);
            string msg = "You have proficiency with 3 musical instruments" +
                "\nPick your 1st instrument";
            for (int i = 0; i < 3; i++)
            {
                int index = CLIHelper.PrintChoices(msg, instruments);
                string instrument = instruments[index];
                character.ToolProficiencies.Add(instrument);
                instruments.Remove(instrument);
                msg = "Pick your 2nd instrument";
                if (i == 1)
                {
                    msg = "Pick your 3rd instrument";
                }
            }
            character.Saves.Add("Dex");
            character.Saves.Add("Cha");
            BEHelper.GetSkills(character, classSkills, 3);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print3Choices("Rapier", "Longsword", "Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 3);
            CLIHelper.Print2Choices("Diplomat's Pack", "Entertainer's Pack");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Lute", "Musical Instrument");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                character.Equipment.Add(Options.MartialMeleeWeapons[11]);
            }
            else if (input1 == 2)
            {
                character.Equipment.Add(Options.MartialMeleeWeapons[7]);
            }
            else
            {
                BEHelper.AddSimpleWeapon(character);
            }
            if (input2 == 1)
            {
                character.Equipment.Add(Options.Packs[1]);
            }
            else
            {
                character.Equipment.Add(Options.Packs[3]);
            }
            if (input3 == 1)
            {
                character.Equipment.Add("Lute");
            }
            else
            {
                string pickMsg = "Pick an instrument to add to your inventory";
                int index = CLIHelper.PrintChoices(pickMsg, Options.MusicalInstruments);
                character.Equipment.Add(Options.MusicalInstruments[index]);
            }
            character.Equipment.Add(Options.LightArmor[1]);
            character.Equipment.Add(Options.SimpleMeleeWeapons[1]);
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;
            int bardicInspiration = 6;
            int songOfRest = 6;
            string magicalSecrets = "gain 2 new spells from any class";

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

            character.ClassFeatures.Add($"Bardic Inspiration(D{bardicInspiration})", "Cha/LR, bonus, 60ft, use on ally, add to atk, save, or ability check");
            try
            {
                character.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use a musical instrument as a spell focus");
            }
            catch (Exception)
            {
                Console.WriteLine("*Note* You have 2 classes with spellcasting");
                throw;
            }

            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Jack of All Trades", "add 1/2 PB to untrained skills");
                character.ClassFeatures.Add($"Song of Rest(D{songOfRest})", "regain HP of yourself or allies during SR");
                character.ClassFeatures.Add("Magical Inspiration", "use Bardic Inspiration to increase an ally's healing or dmg");
            }
            if (lvl >= 3)
            {
                character.ClassFeatures.Add("Expertise", "pick 2 skills, or 1 skill and 1 tool prof, double PB");
                Console.WriteLine("Would you like to gain Expertise in 2 skills or 1 skill and 1 tool prof?");
                CLIHelper.Print2Choices("2 skills", "1 skill and 1 tool prof");
                int num = CLIHelper.GetNumberInRange(1, 2);
                string expertise = "";
                var prof = new List<string>();
                prof.AddRange(character.SkillProficiencies);
                if (num == 1)
                {
                    expertise = CLIHelper.PrintChoices(prof);
                    BEHelper.AddSkillExpertise(expertise, character);
                    prof.Remove(expertise);
                    expertise = CLIHelper.PrintChoices(prof);
                    BEHelper.AddSkillExpertise(expertise, character);
                }
                else
                {
                    expertise = CLIHelper.PrintChoices(prof);
                    BEHelper.AddSkillExpertise(expertise, character);
                    prof.Clear();
                    prof.AddRange(character.ToolProficiencies);
                    expertise = CLIHelper.PrintChoices(prof);
                    character.ToolProficiencies.Remove(expertise);
                    character.ToolProficiencies.Add(expertise + "(Expertise)");
                }
                string msg = "Pick a Bardic College that will give you features at levels 3, 6, and 14.";
                var archetype = new List<string> { "College of Creation", "College of Eloquence", "College of Glamour", "College of Lore",
                    "College of Swords", "College of Valor", "College of Whispers" };
                int answer = CLIHelper.PrintChoices(msg, archetype);
                BardicCollege = archetype[answer].Substring(11);

                switch (BardicCollege)
                {
                    case "Creation":
                        Creation(character);
                        break;
                    case "Eloquence":
                        Eloquence(character);
                        break;
                    case "Glamour":
                        Glamour(character);
                        break;
                    case "Lore":
                        Lore(character);
                        break;
                    case "Swords":
                        Swords(character);
                        break;
                    case "Valor":
                        Valor(character);
                        break;
                    case "Whispers":
                        Whispers(character);
                        break;
                }
            }
            if (lvl >= 4)
            {
                character.ClassFeatures.Add("Bardic Versatility", "When you gain an Ability Score Improvement, change your Expertise or replace a cantrip");
            }
            if (lvl >= 5)
            {
                character.ClassFeatures.Add("Font of Inspiration", "regain Bardic Inspiration from SR");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Countercharm", "action, 30ft, you and allies, adv vs fear and charm effects");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Magical Secrets", magicalSecrets);
                character.ClassFeatures.Add("Expertise II", "pick 2 skills, or 1 skill and 1 tool prof, double PB");
                Console.WriteLine("Would you like to gain Expertise in 2 skills or 1 skill and 1 tool prof?");
                CLIHelper.Print2Choices("2 skills", "1 skill and 1 tool prof");
                int num = CLIHelper.GetNumberInRange(1, 2);
                string expertise = "";
                var prof = new List<string>();
                prof.AddRange(character.SkillProficiencies);
                if (num == 1)
                {
                    expertise = CLIHelper.PrintChoices(prof);
                    BEHelper.AddSkillExpertise(expertise, character);
                    prof.Remove(expertise);
                    expertise = CLIHelper.PrintChoices(prof);
                    BEHelper.AddSkillExpertise(expertise, character);
                }
                else
                {
                    expertise = CLIHelper.PrintChoices(prof);
                    BEHelper.AddSkillExpertise(expertise, character);
                    prof.Clear();
                    prof.AddRange(character.ToolProficiencies);
                    expertise = CLIHelper.PrintChoices(prof);
                    character.ToolProficiencies.Remove(expertise);
                    character.ToolProficiencies.Add(expertise + "(Expertise)");
                }
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Magical Secrets II", magicalSecrets);
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Magical Secrets III", magicalSecrets);
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Superior Inspiration", "on Init, if you have no Bardic Inspiration uses - regain 1 use");
            }
            Spells(character);
        }
        public static void Creation(Character character)
        {
            int lvl = character.Lvl;
            string size = "Medium";
            if (lvl >= 6)
            {
                size = "Large";
            }
            if (lvl >= 14)
            {
                size = "Huge";
            }
            character.ClassFeatures.Add("Mote of Potential", "additional benefits from Bardic Inspiration - check(roll twice), atk(Con save, adj, Thunder dmg), save(gain Temp HP = roll + Cha)");
            character.ClassFeatures.Add("Performance of Creation", $"LR or 2nd lvl spell slot, action, hr/PB, 10ft, create a {size} nonmagical item - value = lvl x 20gp, glimmers and soft music");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Animating Performance", "LR or 3rd lvl spell slot, action, 1 hr, 30ft, animate a nonmagical item, defaults to Dodge, shares Init" +
                    "\n        command with bonus or when using Bardic Inspiration, if you're incap it can take any action");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Creative Crescendo", "When you use Performance of Creation, create Cha items - only one can be max Size, rest must be Small or Tiny, no gp limit");
            }
        }
        public static void Eloquence(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Silver Tongue", "treat a roll below 10 on Deception or Persuasion as a 10");
            character.ClassFeatures.Add("Unsettling Words", "bonus, 60ft, expend Bardic Inspiration, next save - roll");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Unfailing Inspiration", "When an ally with Bardic Inspiration fails, they keep the Bardic Inspiration die");
                character.ClassFeatures.Add("Universal Speech", "LR or spell slot, action, 60ft, 1 hr, Cha creatures, creatures understood you regardless of language");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Infectious Inspiration", "Cha/LR, reaction, 60ft, when ally uses Bardic Inspiration, give another ally Bardic Inspiration without expending a use");
            }
        }
        public static void Glamour(Character character)
        {
            int lvl = character.Lvl;
            int tempHP = 5;
            for (int i = 1; i <= lvl; i++)
            {
                if (i % 5 == 0 && i != 20)
                {
                    tempHP += 3;
                }
            }
            character.ClassFeatures.Add("Mantle of Inspiration", $"bonus, 60ft, Cha creatures, use Bardic Inspiration to give {tempHP} temp HP and" +
                $"\n        allies can move their speed, no atk op");
            character.ClassFeatures.Add("Enthralling Performance", "after 1 min performance, SR, 1 hr, 60ft, Cha creatures, Wis save, charm and idolizing, if you fail" +
                "\n        the target is unaware of charm attempt");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Mantle of Majesty", "LR, 1 min, gain unearthly beauty, bonus - cast Command, if charmed auto-fail Command's save");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Unbreakable Majesty", "SR, bonus, 1 min, when attacked, Cha save, must choose new target, if fail - disadv on saves vs your spells");
            }
        }
        public static void Lore(Character character)
        {
            int lvl = character.Lvl;
            string msg = "Pick 3 skills to gain proficiency in";
            for (int i = 0; i < 3; i++)
            {
                string skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, msg);
                character.SkillProficiencies.Add(skill);
            }
            character.ClassFeatures.Add("Cutting Words", "60ft, minus Bardic Inspiration from atk, dmg, ability check");

            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Additional Magical Secrets", "gain 2 new spells from any class (pick them separately)");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Peerless Skill", "use Bardic Inspiration on self for an ability check");
            }
        }
        public static void Swords(Character character)
        {
            int lvl = character.Lvl;
            character.Proficiencies.Add("Medium Armor");
            character.Proficiencies.Add("Scimitar");
            character.ClassFeatures["Spellcasting"] += ", proficient weapons can also be used as a spell focus";
            string fightStyleMsg = "Pick a fighting style.";
            List<string> styleList = new List<string> { "Dueling", "Two-Weapon Fighting" };
            string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
            string fightStyleKey = $"Fighting Style({fightStyle})";
            string fightStyleValue = Options.FightingStyles[fightStyle];
            character.ClassFeatures.Add(fightStyleKey, fightStyleValue);
            character.ClassFeatures.Add("Blade Flourish", "When atk, speed +10ft, use 1 of the 3 Flourishes" +
                "\n        Defensive Flourish(use Bardic Inspiration to gain AC and extra dmg)" +
                "\n        Slashing Flourish(use Bardic Inspiration to gain extra dmg and dmg adj creature)" +
                "\n        Mobile Flourish(use Bardic Inspiration to gain extra dmg and push 5 + die roll ft, reaction - move your speed toward target)");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Master's Flourish", "When you use Blade Flourish, you can use 1D6 instead of expending Bardic Inspiration");
            }
        }
        public static void Valor(Character character)
        {
            int lvl = character.Lvl;
            character.Proficiencies.Add("Medium Armor");
            character.Proficiencies.Add("Shields");
            character.Proficiencies.Add("Martial Weapons");
            character.ClassFeatures.Add("Combat Inspiration", "after Bardic Inspiration use - add to dmg or use reaction to add to AC");

            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Battle Magic", "bonus, when you cast a spell, make wep atk");
            }
        }
        public static void Whispers(Character character)
        {
            int lvl = character.Lvl;
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
            character.ClassFeatures.Add("Psychic Blades", $"1/turn, on hit, use Bardic Inspiration to deal {psychicDice}D6 Psychic dmg");
            character.ClassFeatures.Add("Words of Terror", "SR, speak for 1 min, Wis save, choose creature for target to fear");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Mantle of Whispers", "SR, reaction, 30ft, when creature dies, gain shadow" +
                    "\n        action, use shadow, 1 hr, becomes disguise of dead person, Deception + 5");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Shadow Lore", "LR, action, 30ft, 1 creature, must share lang, Wis save, charm 8 hr, obeys commands, grants gifts/favors as if close friend");
            }
        }
        public static void Spells(Character character)
        {
            string pickMsg = "Pick a cantrip.";
            int spellLvl = 1;
            var charSpells = new List<string>();
            var spellNames = new List<string>();
            foreach (var spell in character.Spells[spellLvl])
            {
                if (spell.Contains(":"))
                {
                    int index = spell.IndexOf(":");
                    string spellName = spell.Substring(0, index);
                    charSpells.Add(spellName);
                }
            }
            foreach (var spell in AllSpells.Descriptions.Keys)
            {
                spellNames.Add(spell);
            }
            AllSpells spells = new AllSpells(character);
            List<int> magicalSecrets = new List<int> { 13, 14, 17, 18, 21, 22 };

            for (int i = 1; i <= character.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(spells.Bard[0], character.Cantrips, pickMsg);
                character.Cantrips.Add(spell);
                spells.Bard[0].Remove(spell);
            }
            pickMsg = "Pick a 1st level spell.";

            for (int i = 1; i <= character.SpellsKnown; i++)
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
                pickMsg = CLIHelper.pickSpellLevel(i, 6, 8, 10, pickMsg, spellLvl);
                if (magicalSecrets.Contains(i))
                {
                    string newSpell = CLIHelper.GetNew(spellNames, charSpells, pickMsg);
                    character.Spells[spellLvl].Add(newSpell);
                    spellNames.Remove(newSpell);
                }
                else
                {
                    string spell = CLIHelper.GetNew(spells.Bard[spellLvl], character.Spells[spellLvl], pickMsg);
                    character.Spells[spellLvl].Add(spell);
                    spells.Bard[spellLvl].Remove(spell);
                }
            }
        }
    }
}
