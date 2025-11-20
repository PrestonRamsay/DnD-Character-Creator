using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Rogue
    {
        public static string RoguishArchetype { get; set; }
        public static void Base(Character character)
        {
            List<string> classSkills = new List<string> { "Acrobatics", "Animal Handling", "Athletics", "Deception", "Insight",
                "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth" };

            character.GP += 100;
            character.HitDie = 8;
            character.Proficiencies.Add("Light armor");
            character.Proficiencies.Add("Simple weapons");
            character.Proficiencies.Add("Hand crossbows");
            character.Proficiencies.Add("Longswords");
            character.Proficiencies.Add("Rapiers");
            character.Proficiencies.Add("Shortswords");
            character.ToolProficiencies.Add("Thieves' Tools");
            character.Saves.Add("Dex");
            character.Saves.Add("Int");

            BEHelper.GetSkills(character, classSkills, 4);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            //CLIHelper.Print2Choices("Rapier", "Shortsword");
            int input1 = CLIHelper.GetChoiceFromPair("Rapier", "Shortsword");
            //CLIHelper.Print2Choices("Shortbow and a quiver of 20 arrows", "Shortsword");
            int input2 = CLIHelper.GetChoiceFromPair("Shortbow and a quiver of 20 arrows", "Shortsword");
            CLIHelper.Print3Choices("Burglar's Pack", "Dungeoneer's Pack", "Explorer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 3);

            if (input1 == 1)
            {
                character.Equipment.Add(Options.MartialMeleeWeapons[11]);
            }
            else
            {
                character.Equipment.Add(Options.MartialMeleeWeapons[13]);
            }
            if (input2 == 1)
            {
                character.Equipment.Add(Options.SimpleRangedWeapons[2]);
                character.Equipment.Add("Quiver(20 arrows)");
            }
            else
            {
                character.Equipment.Add(Options.MartialMeleeWeapons[13]);
            }
            if (input3 == 1)
            {
                character.Equipment.Add(Options.Packs[0]);
            }
            else if (input3 == 2)
            {
                character.Equipment.Add(Options.Packs[2]);
            }
            else
            {
                character.Equipment.Add(Options.Packs[4]);
            }

            character.Equipment.Add(Options.LightArmor[1]);
            character.Equipment.Add($"2 {Options.SimpleMeleeWeapons[1]}");
            character.Equipment.Add("Thieves' Tools");
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;
            int sneakAtkDice = 0;
            for (int i = 1; i <= lvl; i++)
            {
                if (i % 2 != 0)
                {
                    sneakAtkDice++;
                }
            }
            string msg = "Pick a Roguish Archetype that will give you features at levels 3, 9, 13, and 17.";
            var archetype = new List<string> { "Arcane Trickster", "Assassin", "Inquisitive", "Mastermind", "Ninja", "Phantom", "Scout",
                    "Soulknife", "Swashbuckler", "Thief" };
            int input = CLIHelper.PrintChoices(msg, archetype);
            RoguishArchetype = archetype[input];

            character.ClassFeatures.Add($"Sneak Attack({sneakAtkDice}D6)", "1/turn, if you have adv or tar is flanked, must use finesse or ranged wep");
            character.ClassFeatures.Add("Expertise","pick 2 skills, or 1 skill and 1 tool prof, double PB");
            int num = -1;
            string expertise = "";
            var prof = new List<string>();
            if (RoguishArchetype != "Ninja")
            {
                Console.WriteLine("Would you like to gain Expertise in 2 skills or 1 skill and 1 tool prof?");
                //CLIHelper.Print2Choices("2 skills", "1 skill and 1 tool prof");
                num = CLIHelper.GetChoiceFromPair("2 skills", "1 skill and 1 tool prof");
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
            else
            {
                BEHelper.AddSkillExpertise("Acrobatics", character);
                Console.WriteLine("Would you like to gain Expertise in a skill or a tool proficiency?");
                //CLIHelper.Print2Choices("Skill", "Tool Proficiency");
                num = CLIHelper.GetChoiceFromPair("Skill", "Tool Proficiency");
                if (num == 1)
                {
                    prof.AddRange(character.SkillProficiencies);
                    if (prof.Contains("Acrobatics"))
                    {
                        prof.Remove("Acrobatics");
                    }
                    expertise = CLIHelper.PrintChoices(prof);
                    BEHelper.AddSkillExpertise(expertise, character);
                }
                else
                {
                    prof.AddRange(character.ToolProficiencies);
                    expertise = CLIHelper.PrintChoices(prof);
                    character.ToolProficiencies.Remove(expertise);
                    character.ToolProficiencies.Add(expertise + "(Expertise)");
                }
            }
            
            character.ClassFeatures.Add("Thieves' Cant", "secret thief language, speaking/writing takes 4x longer");
            character.Languages.Add("Thieves' Cant");

            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Cunning Action", "bonus, take Dash, Disengage, or Hide action");
            }
            if (lvl >= 3)
            {
                character.ClassFeatures.Add("Steady Aim", "bonus, gain adv on next atk - can't move before or after using");

                switch (RoguishArchetype)
                {
                    case "Arcane Trickster":
                        ArcaneTrickster(character);
                        break;
                    case "Assassin":
                        Assassin(character);
                        break;
                    case "Inquisitive":
                        Inquisitive(character);
                        break;
                    case "Mastermind":
                        Mastermind(character);
                        break;
                    case "Ninja":
                        Ninja(character);
                        break;
                    case "Phantom":
                        Phantom(character);
                        break;
                    case "Scout":
                        Scout(character);
                        break;
                    case "Soulknife":
                        Soulknife(character);
                        break;
                    case "Swashbuckler":
                        Swashbuckler(character);
                        break;
                    case "Thief":
                        Thief(character);
                        break;
                }
            }
            if (lvl >= 5)
            {
                character.ClassFeatures.Add("Uncanny Dodge", "reaction, 1/2 dmg");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Expertise II", "pick 2 skills, or 1 skill and 1 tool prof, double PB");
                Console.WriteLine("Would you like to gain Expertise in 2 skills or 1 skill and 1 tool prof?");
                //CLIHelper.Print2Choices("2 skills", "1 skill and 1 tool prof");
                num = CLIHelper.GetChoiceFromPair("2 skills", "1 skill and 1 tool prof");
                prof = new List<string>();
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
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Evasion", "Dex saves = 1/2 or no dmg");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Reliable Talent", "when you roll below 10 on a skill that you are prof in, you can treat that roll as a 10");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Blindsense", "if you can hear, you know the location of hidden or invisible creatures within 10ft");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Slippery Mind", "gain prof in Wis saves");
                character.Saves.Add("Wis");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Elusive", "no atk has adv while you're not incap");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Stroke of Luck", "1/SR, make an atk hit or an ability check roll a 20");
            }

            
        }
        public static void ArcaneTrickster(Character character)
        {
            int lvl = character.Lvl; 
            try
            {
                character.ClassFeatures.Add("Spellcasting", "use Int for spell DCs, you use a component pouch to cast spells");
            }
            catch (Exception)
            {
                Console.WriteLine("*Note* You have 2 classes with spellcasting");
                throw;
            }
            character.ClassFeatures.Add("Mage Hand Legerdemain", "bonus, when you cast Mage Hand, make hand invisible and - stow or retrieve an object carried or worn" +
                    "\n        by another creature, use Thieves' Tools at a range - Sleight of Hand check vs creature to notice");
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Magical Ambush", "if hidden when you cast a spell, enemy has disadv");
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Versatile Trickster", "bonus, use Mage Hand to gain adv on atk");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Spell Thief", "LR, reaction, when enemy casts a spell, spell save - they lost the spell, you gain it");
            }
            Spells(character);
        }
        public static void Assassin(Character character)
        {
            int lvl = character.Lvl;
            character.Proficiencies.Add("Disguise Kit");
            character.Proficiencies.Add("Poisoner's Kit");
            character.ClassFeatures.Add("Assassinate", "adv on atk vs creatures that haven't taken a turn yet, surprise = crit");
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Infiltration Expertise", "spend 7 days & 25gp, establish alternate identity");
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Impostor", "spend 3hr observing to mimic speech, writing, behavior of another, adv on Deception vs detection");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Death Strike", "when you hit a surprised creature, Dex-based DC Con save to double dmg");
            }
        }
        public static void Inquisitive(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Ear for Deceit", "When you roll Insight for lying, if roll is 7 or lower, treat the roll as an 8");
            character.ClassFeatures.Add("Eye for Detail", "bonus, Perception to spot hidden creature or object, Investigation to uncover/decipher clues");
            character.ClassFeatures.Add("Insightful Fighting", "bonus, 1 min, 1 creature, Insight vs Deception - you can use Sneak Attack without adv, but suffer disadv on the atk");
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Steady Eye", "adv on Perception or Investigation if you move half your speed or less");
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Unerring Eye", "Wis/LR, action, 30ft, not blind or deaf, sense the presence of illusions/shapechangers/magic designed to deceive");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Eye for Weakness", "When you use Insightful Fighting, dmg + 3D6");
            }
        }
        public static void Mastermind(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Master of Intrigue", "if you hear someone speak for 1 min, mimic speech patterns to pass off as a native/local");
            character.Proficiencies.Add("Disguise Kit");
            character.Proficiencies.Add("Forgery Kit");
            string msg = "Pick a gaming set you'd like to be proficient with.";
            int index = CLIHelper.PrintChoices(msg, Options.GamingSets);
            string game = Options.GamingSets[index];
            character.ToolProficiencies.Add(game);
            string pickMsg = "Pick 2 languages";
            string lang = CLIHelper.GetNew(Options.Languages, character.Languages, pickMsg);
            character.Languages.Add(lang);
            pickMsg = "Pick your second language now";
            lang = CLIHelper.GetNew(Options.Languages, character.Languages, pickMsg);
            character.Languages.Add(lang);
            character.ClassFeatures.Add("Master of Tactics", "bonus, 30ft use Help action to aid an ally in attacking");
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Insightful Manipulator", "observe a creature 1 min outside of combat, you know if you're superior, inferior, or equal in 2 stats from:" +
                    "\n        Int, Wis, Cha, lvl - at the DM's option, learn a piece of their history or one of their personality traits");
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Misdirection", "When you're attacked, if adj creature, reaction, creature takes atk instead");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Soul of Deceit", "Magic always identifies you as telling the truth and you can't be compelled to tell the truth" +
                    "\n        gain Immunity to mind-reading, if telepathy or mind-reading is used on you, Deception vs Insight to present false thoughts");
            }
        }
        public static void Ninja(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Ki", $"Ki pts = PB/LR, on SR gain 1 ki pt, Ghost Step(1 ki pt, become invisible for 1 turn)");
            character.ClassFeatures.Add("Remarkable Mobility", "gain Climb speed, jump dist + Dex, 1 use of Expertise must go to Acrobatics(gain prof if you don't have)");
            character.SkillProficiencies.Add("Acrobatics");
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Ghost Strike", "wep atks are considered magical, you can hit ethereal creatures");
                character.ClassFeatures["Ki"] += "\n        Ki Dodge(1 ki pt, as Blur spell)";
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Ghost Mind", "Detection spells must succeed on Wis-based Wis DC to detect you");
                character.ClassFeatures["Ki"] = $"Ki pts = PB/LR, on SR gain 1 ki pt, Ghost Step(1 ki pt, become invisible or etheral for 1 turn)" +
                    $"\n        Ki Dodge(1 ki pt, as Blur spell)";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Ghost Sight", "you can see invisible and etheral creatures normally");
                character.ClassFeatures["Ki"] += "\n        Ghost Walk(2 ki pt, as Etherealness spell)";
            }
        }
        public static void Phantom(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Whispers of the Dead", "on SR/LR, gain a skill or tool proficiency of your choice");
            character.ClassFeatures.Add("Wails from the Grave", "PB/LR, 30ft, when you hit Sneak Attack, target new creature, 1/2 Sneak Attack dice rounded up (Necrotic dmg)");
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Tokens of the Departed", "reaction, 30ft, when creature dies, create soul trinket, max trinkets = PB, gain adv on Con and death saves" +
                    "\n        destroy soul trinket - (use Wails from the Grave without expending a use) or (action, ask trinket spirit a question)");
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Ghost Walk", "bonus, 10 min, gain Hover and Fly 10ft");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Death's Friend", "Wails from the Grave also effect Sneak Attack target, on LR - gain a soul trinket");
            }
        }
        public static void Scout(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Skirmisher", "reaction, if enemy ends turn adj, move half your speed with no atk op");
            character.ClassFeatures.Add("Survivalist", "gain prof in Nature and Survival, double your PB for those skills");
            character.SkillProficiencies.Add("Nature");
            character.SkillProficiencies.Add("Survival");
            character.Skills["Nature"] += character.ProficiencyBonus;
            character.Skills["Survival"] += character.ProficiencyBonus;
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Superior Mobility", "speed +10ft, applies to Swim or Climb speeds");
                character.Speed += 10;
                if (character.Speedstring.Contains("Swim"))
                {
                    string tensFeet = character.Speedstring.Substring(character.Speedstring.Length - 4, 1);
                    int num = int.Parse(tensFeet);
                    num++;
                    string speed = character.Speedstring.Substring(0, character.Speedstring.Length - 4);
                    character.Speedstring = $"{speed}{num}0ft";
                }
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Ambush Master", "adv on Init, adv on 1st creature you atk that turn");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Sudden Strike", "bonus, if you use Attack action, make an atk - you can use Sneak Attack a 2nd time but not against the same creature");
            }
        }
        public static void Soulknife(Character character)
        {
            int lvl = character.Lvl;
            int dice = 6;
            for (int i = 5; i <= lvl; i += 6)
            {
                dice += 2;
            }
            character.ClassFeatures.Add("Psionic Power", $"PB x 2/LR, gain Psionic Energy dice(D{dice}) / SR, bonus, regain 1 Psionic Energy die" +
                $"\n        Psi-Bolstered Knack(when you fail a skill or tool check you are prof with, check + Psionic Energy die)" +
                $"\n        Psychic Whispers(LR, action, 1 mile, Psionic Energy die hr, PB creatures, gain telepathy - no action to use)");
            character.ClassFeatures.Add("Psychic Blades", "manifest psychic blade(1D6 Psychic, Finesse, Light, Thrown 60) / bonus, atk with psychic blade(1D4 Psychic)");
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Soul Blades", "Homing Strikes(when you miss atk with Psychic Blades, atk + Psionic Energy die)" +
                    "\n        Psychic Teleportation(bonus, teleport Psionic Energy die x 10ft)");
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Psychic Veil", "LR or Psionic Energy die, action, 1 hr, become invisible");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Rend Mind", "LR or 3 Psionic Energy dice, when you Sneak Attack with Psychic Blades, Dex-based Wis save, stun 1 min");
            }
        }
        public static void Swashbuckler(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Fancy Footwork", "if you make an atk, creature attacked can't take atk op");
            character.ClassFeatures.Add("Rakish Audacity", "Init + Cha, if no adj creature - you don't need adv to make Sneak Attacks");
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Panache", "action, 1 min, must share a lang, Persuasion vs Insight, charm(friend), disadv on atk vs allies, no atk op vs allies");
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Elegant Maneuver", "bonus, gain adv on Acrobatics or Athletics check");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Master Duelist", "SR, if you miss, reroll atk with adv");
            }
        }
        public static void Thief(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Fast Hands", "bonus, Sleight of Hand check, use Thieves' Tools, or take the Use an Object action");
            character.ClassFeatures.Add("Second-Story Work", "climbing doesn't cost extra movement, running jumps add Dex to distance");
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Supreme Sneak", "adv on Stealth if you move no more than 1/2 speed");
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Use Magic Device", "ignore all class, race, lvl requirements for magic items");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Theif's Reflexes", "during first round of combat take 2 turns - 2nd turn is at Init - 10");
            }
        }
        public static void Spells(Character character)
        {
            //spells
            AllSpells spells = new AllSpells(character);
            
            character.Cantrips.AddRange(character.Cantrips);
            character.CantripsKnown = 2;
            character.SpellsKnown = 3;
            int slotLvl = 1;
            character.SpellSlots[1] += 2;
            string pickMsg = "Pick a spell.";
            string cantrip = "";
            string spell = "";
            for (int i = 0; i < 2; i++)
            {
                cantrip = CLIHelper.GetNew(spells.Wizard[0], character.Cantrips, pickMsg);
                character.Cantrips.Add(cantrip);
                spells.Wizard[0].Remove(cantrip);
            }
            for (int i = 0; i < 2; i++)
            {
                spell = CLIHelper.GetNew(spells.Rogue[1], character.Spells[1], pickMsg);
                character.Spells[1].Add(spell);
                spells.Rogue[1].Remove(spell);
            }
            spell = CLIHelper.GetNew(spells.Wizard[1], character.Spells[1], pickMsg);
            character.Spells[1].Add(spell);
            spells.Rogue[1].Remove(spell);

            for (int i = 3; i <= character.Lvl; i++)
            {
                //slots
                if (i == 7 || i == 13)
                {
                    slotLvl++;
                    character.SpellSlots[slotLvl] += 2;
                }
                if (i == 4 || i == 10 || i == 16)
                {
                    character.SpellSlots[slotLvl]++;
                }
                if (i == 19)
                {
                    slotLvl++;
                    character.SpellSlots[4] += 1;
                }
                //known and add spells
                if (i == 10)
                {
                    character.CantripsKnown++;
                    cantrip = CLIHelper.GetNew(spells.Wizard[0], character.Cantrips, pickMsg);
                    character.Cantrips.Add(cantrip);
                    spells.Wizard[0].Remove(cantrip);
                    character.SpellsKnown++;
                    spell = CLIHelper.GetNew(spells.Rogue[slotLvl], character.Spells[slotLvl], pickMsg);
                    character.Spells[slotLvl].Add(spell);
                    spells.Rogue[slotLvl].Remove(spell);
                }
                if (i == 8 || i == 14 || i == 20)
                {
                    character.SpellsKnown++;
                    spell = CLIHelper.GetNew(spells.Wizard[slotLvl], character.Spells[slotLvl], pickMsg);
                    character.Spells[slotLvl].Add(spell);
                    spells.Wizard[slotLvl].Remove(spell);
                }
                if (i == 4 || i == 7 || i == 11 || i == 13 || i == 16 || i == 19)
                {
                    character.SpellsKnown++;
                    spell = CLIHelper.GetNew(spells.Rogue[slotLvl], character.Spells[slotLvl], pickMsg);
                    character.Spells[slotLvl].Add(spell);
                    spells.Rogue[slotLvl].Remove(spell);
                }
            }
        }
    }
}
