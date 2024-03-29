﻿using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Barbarian
    {
        public static string PathName { get; set; }
        public static void Base(Character character)
        {
            var classSkills = new List<string> { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival" };

            character.GP += 50;
            character.HitDie = 12;
            character.Proficiencies.Add("Light armor");
            character.Proficiencies.Add("Medium armor");
            character.Proficiencies.Add("Shields");
            character.Proficiencies.Add("Simple weapons");
            character.Proficiencies.Add("Martial weapons");

            character.Saves.Add("Str");
            character.Saves.Add("Con");
            BEHelper.GetSkills(character, classSkills, 2);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Greataxe", "Any martial melee weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Two handaxes", "Any simple weapon");
            int input2 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                character.Equipment.Add(Options.MartialMeleeWeapons[3]);
            }
            else
            {
                BEHelper.AddMartialMeleeWeapon(character);
            }
            if (input2 == 1)
            {
                character.Equipment.Add($"2 {Options.SimpleMeleeWeapons[3]}");
            }
            else
            {
                var simpleWeapons = new List<string>();
                string msg = "Pick a simple weapon";
                simpleWeapons.AddRange(Options.SimpleMeleeWeapons);
                simpleWeapons.AddRange(Options.SimpleRangedWeapons);
                int index = CLIHelper.PrintChoices(msg, simpleWeapons);
                character.Equipment.Add(simpleWeapons[index]);
            }

            character.Equipment.Add(Options.Packs[5]);
            character.Equipment.Add($"4 {Options.SimpleMeleeWeapons[4]}");
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;
            int numberOfRages = 2;
            int rageDamage = 2;
            int brutalCritDice = 1;

            for (int i = 1; i <= lvl; i++)
            {
                if (i == 3 || i == 6 || i == 12 || i == 17)
                {
                    numberOfRages++;
                }
                if (i == 9 || i == 16)
                {
                    rageDamage++;
                }
                if (i == 13 || i == 17)
                {
                    brutalCritDice++;
                }
            }
            if (lvl != 20)
            {
                character.ClassFeatures.Add($"Rage({numberOfRages}/day)", $"bonus, 1 min, adv on Str checks/saves, Str melee dmg+{rageDamage}," +
                $"\n        gain Resistance to B/P/S (end as bonus or if you don't atk or take dmg)");
            }
            else
            {
                character.ClassFeatures.Add($"Rage(Unlimited)", $"bonus, 1 min, adv on Str checks/saves, Str melee dmg+{rageDamage}," +
                $"\n        gain Resistance to B/P/S (end as bonus or if you don't atk or take dmg)");
            }
            character.ClassFeatures.Add("Unarmored Defense", "AC = 10 + Dex + Con, while wearing no armor");

            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Reckless Attack", "On your first atk, gain adv on atk rolls this turn, but atks against you" +
                    "\n         also have adv until your next turn");
                character.ClassFeatures.Add("Danger Sense", "Gain adv on Dex saves on effects you can see such as traps and spell" +
                    "\n         You can't be blinded, deafened, or incapacitated");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick a new skill from your skill list";
                var classSkills = new List<string>() { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival" };
                string newSkill = CLIHelper.GetNew(classSkills, character.SkillProficiencies, pickMsg);
                character.SkillProficiencies.Add(newSkill);
                string msg = "Pick a Primal Path that will give you features at levels 3, 6, 10, and 14.";
                var primalPaths = new List<string> { "Path of the Ancestral Guardian", "Path of the Battlerager", "Path of the Beast", 
                    "Path of the Berserker", "Path of the Storm Herald", "Path of the Totem Warrior", "Path of Wild Magic", "Path of the Zealot" };
                if (character.ChosenRace != "Hill Dwarf" || character.ChosenRace != "Mountain Dwarf")
                {
                    primalPaths.Remove("Path of the Battlerager");
                }
                int input = CLIHelper.PrintChoices(msg, primalPaths);

                if (input == 6)
                {
                    PathName = primalPaths[input].Substring(8);
                }
                else
                {
                    PathName = primalPaths[input].Substring(12);
                }

                switch (PathName)
                {
                    case "Ancestral Guardian":
                        AncestralGuardian(character);
                        break;
                    case "Battlerager":
                        Battlerager(character);
                        break;
                    case "Beast":
                        Beast(character);
                        break;
                    case "Berserker":
                        Berserker(character);
                        break;
                    case "Storm Herald":
                        StormHerald(character);
                        break;
                    case "Totem Warrior":
                        TotemWarrior(character);
                        break;
                    case "Wild Magic":
                        WildMagic(character);
                        break;
                    case "Zealot":
                        Zealot(character);
                        break;
                }
            }
            if (lvl >= 5)
            {
                character.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
                character.ClassFeatures.Add("Fast Movement", "While not wearing heavy armor, increase speed by 10ft");
                character.Speed += 10;
            }
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Feral Instinct", "can't be surprised, adv on Init");
                character.ClassFeatures.Add("Instinctive Pounce", "bonus, when you rage move 1/2 your speed");
            }
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Brutal Critical", $"When you crit, dmg + {brutalCritDice} weapon die");
            }
            if (lvl >= 10)
            {
                string pickMsg = "Pick a new skill from your skill list";
                var classSkills = new List<string>() { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival" };
                string skill = CLIHelper.GetNew(classSkills, character.SkillProficiencies, pickMsg);
                character.SkillProficiencies.Add(skill);
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Relentless Rage", "While raging, when you drop to 0HP, Con save, on success drop to 1HP." +
                    "\n        DC starts at 10, +5 every time feature is used. DC resets after a SR/LR");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Persistent Rage", "Rage only ends if you fall unconscious or you choose to end it");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Indomitable Might", "If total Str check < Str score, use Str score for check instead");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Primal Champion", "Increase Str and Con by 4, the max for Str and Con are now 24");
                character.StatMax += 4;
                character.Stats["Str"] += 4;
                character.Stats["Con"] += 4;
            }
        }
        public static void AncestralGuardian(Character character)
        {
            int lvl = character.Lvl;
            int spiritDice = 2;
            character.ClassFeatures.Add("Ancestral Protectors", "While raging, after hit, enemy has disadv on atk vs allies and" +
                "\n        they have Resistance to its dmg");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Spirit Shield", $"While raging, 30ft, if ally takes dmg, reduce dmg by {spiritDice}D6");
            }
            if (lvl >= 10)
            {
                spiritDice++;
                character.ClassFeatures.Add("Consult the Spirits", "SR, use Wis to cast Augury or Clairvoyance(a spectral ancestor instead of a sensor)");
                character.ClassFeatures["Spirit Shield"] = $"While raging, 30ft, if ally takes dmg, reduce dmg by {spiritDice}D6";
            }
            if (lvl >= 14)
            {
                spiritDice++;
                character.ClassFeatures.Add("Vengeful Ancestors", "When you use spirit shield, enemy takes force dmg = dmg reduced");
                character.ClassFeatures["Spirit Shield"] = $"While raging, 30ft, if ally takes dmg, reduce dmg by {spiritDice}D6";
            }
        }
        public static void Battlerager(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Battlerager Armor", "gain Spiked Armor(+4 AC, 1D4 Piercing) - bonus melee atk, grapple deals 3 dmg");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Reckless Abandon", "When you use Reckless Attack, gain Con temp HP, lose them when rage ends");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Battlerager Charge", "While raging, bonus, use Dash action");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Spiked Retribution", "When hit with melee, enemy takes 3 Piercing dmg");
            }
        }
        public static void Beast(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Form of the Beast", "When you rage, gain a Bite, Claw, or Tail atk with special effects" +
                            "\n        Bite(1D8, if bloodied - when you hit, heal HP = PB)" +
                            "\n        Claw(1D6, when you use an Attack action, gain an extra atk)" +
                            "\n        Tail(1D8, reach, when you're hit - reaction, 10ft, AC + 1D8)");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Bestial Soul", "your natural weapons are considered magical, on SR/LR gain Swim speed, Climb speed, or jump ft + Athletics check");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Infectious Fury", "PB/LR, on hit, Con-based Wis save, 2D12 Psychic dmg or must use reaction to melee atk target of your choice");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Call the Hunt", "PB/LR, when you rage, 30ft, Con allies, gain 5 temp HP/ally, allies dmg + 1D6");
            }
        }
        public static void Berserker(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Frenzy", "When you rage, you can frenzy, melee atk as bonus, when rage ends, suffer 1 lvl of exhaustion");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Mindless Rage", "No charm or fear while raging, if under an effect before raging they're suspended during the rage");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Intimidating Presence", "action, 30ft, one creature, Wis save, fear, action to sustain");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Retaliation", "When you take dmg from a creature within 5ft, reaction, make a melee atk");
            }
        }
        public static void StormHerald(Character character)
        {
            int lvl = character.Lvl;
            int fireAndIceDmg = 2;
            for (int i = 1; i <= lvl; i++)
            {
                if (i % 5 == 0)
                {
                    fireAndIceDmg++;
                }
            }
            int lightningDice = fireAndIceDmg - 1;
            character.ClassFeatures.Add("Storm Aura", "While raging, 1st turn no action, bonus, 10ft, negated by total cover, Con-based DCs" +
                "\n        you can change the environment of your aura after SR" +
                $"\n        Desert(all creatures take {fireAndIceDmg} fire dmg)" +
                $"\n        Sea(one creature, Dex save, {lightningDice}D6 lightning dmg)" +
                $"\n        Tundra(each ally gains {fireAndIceDmg} temp HP)");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Storm Soul", "you are granted a benefit based on your Storm Aura environment" +
                "\n        Desert(Resistance to Fire and extreme heat, action - ignite a flammable object not worn or carried)" +
                "\n        Sea(Resistance to Lightning dmg, Waterbreathing, and Swim speed 30ft)" +
                "\n        Tundra(Resistance to Cold and extreme cold, action - freeze 5ft of water for 1 min, fails if a creature is inside)");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Shielding Storm", "While in your Storm Aura, allies gain the Resistance you get from Storm Soul");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Raging Storm", "gain additional benefits based on your Storm Aura" +
                "\n        Desert(after being hit, reaction, Dex save, fire dmg = 1/2 lvl)" +
                "\n        Sea(1/turn, on a hit, Str save, knock prone)" +
                "\n        Tundra(when you activate your Storm Aura, Str save, reduce speed to 0)");
            }
        }
        public static void TotemWarrior(Character character)
        {
            int lvl = character.Lvl;
            string animalMsg = "Pick an animal to determine your feature.";
            var animals = new List<string> { "Bear", "Eagle", "Elk", "Tiger", "Wolf" };
            int index = CLIHelper.PrintChoices(animalMsg, animals);
            switch (index)
            {
                case 0:
                    character.ClassFeatures.Add("Totem Spirit(Bear)", "While raging, gain Resistance to all dmg except Psychic");
                    break;
                case 1:
                    character.ClassFeatures.Add("Totem Spirit(Eagle)", "While raging and not wearing heavy armor, op atk against you have disadv, and" +
                    "\n         you can Dash as a bonus");
                    break;
                case 2:
                    character.ClassFeatures.Add("Totem Spirit(Elk)", "While raging and not wearing heavy armor, increase speed by 15ft");
                    character.Speed += 15;
                    break;
                case 3:
                    character.ClassFeatures.Add("Totem Spirit(Tiger)", "While raging, long jump +10ft, high jump +3ft");
                    break;
                case 4:
                    character.ClassFeatures.Add("Totem Spirit(Wolf)", "While raging, your allies have adv on atks on hostile creatures within 5ft of you");
                    break;
            }

            if (lvl >= 6)
            {
                index = CLIHelper.PrintChoices(animalMsg, animals);

                switch (index)
                {
                    case 0:
                        character.ClassFeatures.Add("Aspect of the Beast(Bear)", "Double your carrying capacity, and gain adv on Str checks to" +
                        "\n         push, pull, lift or break objects");
                        break;
                    case 1:
                        character.ClassFeatures.Add("Aspect of the Beast(Eagle)", "You can see up to a mile away, discerning details as if they were 100ft away." +
                        "\n         Dim light does not impose disadv on Perception checks");
                        break;
                    case 2:
                        character.ClassFeatures.Add("Aspect of the Beast(Elk)", "Travel pace is doubled, up to 10 allies, 60ft");
                        break;
                    case 3:
                        Console.WriteLine("Pick 2 skills");
                        var skills = new List<string> { "Athletics", "Acrobatics", "Stealth", "Survival" };
                        string skill = CLIHelper.PrintChoices(skills);
                        character.SkillProficiencies.Add(skill);
                        skills.Remove(skill);
                        skill = CLIHelper.PrintChoices(skills);
                        character.SkillProficiencies.Add(skill);
                        character.ClassFeatures.Add("Aspect of the Beast(Tiger)", "gain prof in 2 skills");
                        break;
                    case 4:
                        character.ClassFeatures.Add("Aspect of the Beast(Wolf)", "You can track at a fast pace or move stealthily at a normal pace while tracking");
                        break;
                }
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Spirit Walker", "You can cast the 'commune with nature' spell as a ritual");
            }
            if (lvl >= 14)
            {
                index = CLIHelper.PrintChoices(animalMsg, animals);

                switch (index)
                {
                    case 0:
                        character.ClassFeatures.Add("Totemic Attunement(Bear)", "While raging, hostile creatures within 5ft have disadv on atks that aren't against you." +
                        "\n         Doesn't effect enemies who can't see or hear you or those that can't be frightened");
                        break;
                    case 1:
                        character.ClassFeatures.Add("Totemic Attunement(Eagle)", "While raging, gain a fly speed = walking speed. If middair at the end of" +
                        "\n         your turn, you fall to the ground");
                        break;
                    case 2:
                        character.ClassFeatures.Add("Totemic Attunement(Elk)", "While raging, bonus, Str save, 1D12 + Str Bludgeoning and knock prone");
                        break;
                    case 3:
                        character.ClassFeatures.Add("Totemic Attunement(Tiger)", "While raging, if you move 20ft, bonus melee atk");
                        break;
                    case 4:
                        character.ClassFeatures.Add("Totemic Attunement(Wolf)", "While raging, bonus, when you hit a melee atk, knock Large or smaller creatures prone");
                        break;
                }
            }
        }
        public static void WildMagic(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Magic Awareness", "PB/LR, action, 60ft, sense spells and magic items - when you sense a spell learn its school");
            character.ClassFeatures.Add("Wild Surge", "When you rage, roll 1D8 to determine an effect, Con-based DCs" +
                    "\n        1 - Shadowy tendrils(30ft, Con save, 1D12 Necrotic dmg, gain dmg as temp HP)" +
                    "\n        2 - Teleportation(30ft, repeat as bonus)" +
                    "\n        3 - Flumph or Pixie Spirit(30ft, appears adj, at end of turn it explodes - adj, Dex save, 1D6 Force dmg, repeat as bonus)" +
                    "\n        4 - Magic Weapon(becomes Force dmg, gain Light and Thrown 20/60 properties, if it leaves your hand - it returns next turn)" +
                    "\n        5 - Retribution(when you're hit, deal 1D6 Force dmg)" +
                    "\n        6 - Protective Lights(10ft, you and allies gain +1 AC)" +
                    "\n        7 - Flowers and Vines(ground 15ft around you is difficult terrain)" +
                    "\n        8 - Bolt of Light(30ft, Con save, 1D6 Radiant dmg, blind - repeat as bonus)");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Bosltering Magic", "PB/LR, action - 10 min, atks and checks + 1D3 or LR, ally regains spell slot lvl = 1D3");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Unstable Backlash", "reaction, while raging, if you take dmg or fail a save, gain a new Wild Surge effect");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Controlled Surge", "When deciding a Wild Surge effect roll twice, if same result pick your effect");
            }
        }
        public static void Zealot(Character character)
        {
            int lvl = character.Lvl;
            Console.WriteLine("Do you want to deal Radiant dmg or Necrotic dmg?");
            var list = new List<string> { "Radiant", "Necrotic" };
            string dmgType = CLIHelper.PrintChoices(list);
            character.ClassFeatures.Add("Divine Fury", $"1st hit/turn, 1D6 + 1/2 lvl {dmgType} dmg");
            character.ClassFeatures.Add("Warrior of the Gods", "when restored to life by a spell, you don't suffer any negative effects");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Fanatical Focus", "1/rage, while raging, if you fail a save, reroll it - use new roll");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Zealous Presence", "LR, bonus, 60ft, up to 10 allies, adv on atks");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Rage beyond Death", "While raging, dropping to 0 HP doesn't knock you unconscious, make death saves as normal" +
                    "\n        if you 'die', then you don't die until your rage ends");
            }
        }
    }
}
