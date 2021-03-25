using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class BarbarianSpecifics
    {
        public static string PathName { get; set; }
        public static int FastMovement { get; set; } = 0;
        public static CharacterClass Features(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;
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
                result.ClassFeatures.Add($"Rage({numberOfRages}/day)", $"bonus, 1 min, adv on Str checks/saves, Str melee dmg+{rageDamage}," +
                $"\ngain Resistance to B/P/S (end as bonus or if you don't atk or take dmg)");
            }
            else
            {
                result.ClassFeatures.Add($"Rage(Unlimited)", $"bonus, 1 min, adv on Str checks/saves, Str melee dmg+{rageDamage}," +
                $"\ngain Resistance to B/P/S (end as bonus or if you don't atk or take dmg)");
            }
            result.ClassFeatures.Add("Unarmored Defense", "AC = 10 + Dex + Con, while wearing no armor");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Reckless Attack", "On your first atk, gain adv on atk rolls this turn, but atks against you" +
                    "\n also have adv until your next turn");
                result.ClassFeatures.Add("Danger Sense", "Gain adv on Dex saves on effects you can see such as traps and spell" +
                    "\n You can't be blinded, deafened, or incapacitated");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick a new skill from your skill list";
                string errorMsg = "You already have that skill";
                var classSkills = new List<string>() { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival" };
                string newSkill = CLIHelper.GetNew(classSkills, character.SkillProficiencies, pickMsg, errorMsg);
                character.SkillProficiencies.Add(newSkill);
                string msg = "Pick a Primal Path that will give you features at levels 3, 6, 10, and 14.";
                var primalPaths = new List<string> { "Path of the Ancestral Guardian", "Path of the Battlerager", "Path of the Beast", "Path of the Berserker",
                    "Path of the Storm Herald", "Path of the Totem Warrior", "Path of Wild Magic", "Path of the Zealot" };
                if (character.ChosenRace != "Hill Dwarf" || character.ChosenRace != "Mountain Dwarf")
                {
                    primalPaths.Remove("Path of the Battlerager");
                }
                int input = CLIHelper.PrintChoices(msg, primalPaths);

                if (input == 6)
                {
                    PathName = primalPaths[input].Substring(7);
                }
                else
                {
                    PathName = primalPaths[input].Substring(11);
                }

                switch (PathName)
                {
                    case "Ancestral Guardian":
                        int spiritDice = 2;
                        result.ClassFeatures.Add("Ancestral Protectors", "While raging, after hit, enemy has disadv on atk vs allies and" +
                            "\nthey have Resistance to its dmg");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Spirit Shield", $"While raging, 30ft, if ally takes dmg, reduce dmg by {spiritDice}D6");
                        }
                        if (lvl >= 10)
                        {
                            spiritDice++;
                            result.ClassFeatures.Add("Consult the Spirits", "SR, use Wis to cast Augury or Clairvoyance(a spectral ancestor instead of a sensor)");
                            result.ClassFeatures["Spirit Shield"] = $"While raging, 30ft, if ally takes dmg, reduce dmg by {spiritDice}D6";
                        }
                        if (lvl >= 14)
                        {
                            spiritDice++;
                            result.ClassFeatures.Add("Vengeful Ancestors", "When you use spirit shield, enemy takes force dmg = dmg reduced");
                            result.ClassFeatures["Spirit Shield"] = $"While raging, 30ft, if ally takes dmg, reduce dmg by {spiritDice}D6";
                        }
                        break;
                    case "Battlerager":
                        result.ClassFeatures.Add("Battlerager Armor", "gain Spiked Armor(+4 AC, 1D4 piercing) - bonus melee atk, grapple deals 3 dmg");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Reckless Abandon", "When you use Reckless Attack, gain Con temp HP, lose them when rage ends");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Battlerager Charge", "While raging, bonus, use Dash action");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Spiked Retribution", "When hit with melee, enemy takes 3 piercing dmg");
                        }
                        break;
                    case "Beast":
                        result.ClassFeatures.Add("Form of the Beast", "When you rage, gain a Bite, Claw, or Tail atk with special effects" +
                            "\nBite(1D8, if bloodied - when you hit, heal HP = PB)" +
                            "\nClaw(1D6, when you use an Attack action, gain an extra atk)" +
                            "\nTail(1D8, reach, when you're hit - reaction, 10ft, AC + 1D8)");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Bestial Soul", "your natural weapons are considered magical, on SR/LR gain Swim speed, Climb speed, or jump ft + Athletics check");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Infectious Fury", "PB/LR, on hit, Con-based Wis save, 2D12 Psychic dmg or must use reaction to melee atk target of your choice");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Call the Hunt", "PB/LR, when you rage, 30ft, Con allies, gain 5 temp HP/ally, allies dmg + 1D6");
                        }
                        break;
                    case "Berserker":
                        result.ClassFeatures.Add("Frenzy", "When you rage, you can frenzy, melee atk as bonus, when rage ends, suffer 1 lvl of exhaustion");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Mindless Rage", "No charm or fear while raging, if under an effect before raging they're suspended during the rage");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Intimidating Presence", "action, 30ft, one creature, Wis save, fear, action to sustain");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Retaliation", "When you take dmg from a creature within 5ft, reaction, make a melee atk");
                        }
                        break;
                    case "Storm Herald":
                        int fireAndIceDmg = 2;
                        for (int i = 1; i <= lvl; i++)
                        {
                            if (i % 5 == 0)
                            {
                                fireAndIceDmg++;
                            }
                        }
                        int lightningDice = fireAndIceDmg - 1;
                        result.ClassFeatures.Add("Storm Aura", "While raging, 1st turn no action, bonus, 10ft, negated by total cover, Con-based DCs" +
                            "\nyou can change the environment of your aura after SR" +
                            $"\nDesert(all creatures take {fireAndIceDmg} fire dmg)" +
                            $"\nSea(one creature, Dex save, {lightningDice}D6 lightning dmg)" +
                            $"\nTundra(each ally gains {fireAndIceDmg} temp HP)");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Storm Soul", "you are granted a benefit based on your Storm Aura environment" +
                            "\nDesert(Resistance to Fire and extreme heat, action - ignite a flammable object not worn or carried)" +
                            "\nSea(Resistance to Lightning dmg, Waterbreathing, and Swim speed 30ft)" +
                            "\nTundra(Resistance to Cold and extreme cold, action - freeze 5ft of water for 1 min, fails if a creature is inside)");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Shielding Storm", "While in your Storm Aura, allies gain the Resistance you get from Storm Soul");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Raging Storm", "gain additional benefits based on your Storm Aura" +
                            "\nDesert(after being hit, reaction, Dex save, fire dmg = 1/2 lvl)" +
                            "\nSea(1/turn, on a hit, Str save, knock prone)" +
                            "\nTundra(when you activate your Storm Aura, Str save, reduce speed to 0)");
                        }
                        break;
                    case "Totem Warrior":
                        string animalMsg = "Pick an animal to determine your feature.";
                        var animals = new List<string> { "Bear", "Eagle", "Elk", "Tiger", "Wolf" };
                        int index = CLIHelper.PrintChoices(animalMsg, animals);
                        switch (index)
                        {
                            case 0:
                                result.ClassFeatures.Add("Totem Spirit(Bear)", "While raging, gain Resistance to all dmg except Psychic");
                                break;
                            case 1:
                                result.ClassFeatures.Add("Totem Spirit(Eagle)", "While raging and not wearing heavy armor, op atk against you have disadv, and" +
                                "\n you can Dash as a bonus");
                                break;
                            case 2:
                                result.ClassFeatures.Add("Totem Spirit(Elk)", "While raging and not wearing heavy armor, increase speed by 15ft");
                                character.Speed += 15;
                                break;
                            case 3:
                                result.ClassFeatures.Add("Totem Spirit(Tiger)", "While raging, long jump +10ft, high jump +3ft");
                                break;
                            case 4:
                                result.ClassFeatures.Add("Totem Spirit(Wolf)", "While raging, your allies have adv on atks on hostile creatures within 5ft of you");
                                break;
                        }

                        if (lvl >= 6)
                        {
                            index = CLIHelper.PrintChoices(animalMsg, animals);

                            switch (index)
                            {
                                case 0:
                                    result.ClassFeatures.Add("Aspect of the Beast(Bear)", "Double your carrying capacity, and gain adv on Str checks to" +
                                    "\n push, pull, lift or break objects");
                                    break;
                                case 1:
                                    result.ClassFeatures.Add("Aspect of the Beast(Eagle)", "You can see up to a mile away, discerning details as if they were 100ft away." +
                                    "\n Dim light does not impose disadv on Perception checks");
                                    break;
                                case 2:
                                    result.ClassFeatures.Add("Aspect of the Beast(Elk)", "Travel pace is doubled, up to 10 allies, 60ft");
                                    break;
                                case 3:
                                    var skills = new List<string> { "Acrobatis", "Athletics", "Stealth", "Survival" };
                                    pickMsg = "Pick 2 skills.";
                                    int skill = CLIHelper.PrintChoices(pickMsg, skills);
                                    character.SkillProficiencies.Add(skills[skill]);
                                    skills.RemoveAt(skill);
                                    skill = CLIHelper.PrintChoices(pickMsg, skills);
                                    character.SkillProficiencies.Add(skills[skill]);
                                    result.ClassFeatures.Add("Aspect of the Beast(Tiger)", "gain prof in 2 skills");
                                    break;
                                case 4:
                                    result.ClassFeatures.Add("Aspect of the Beast(Wolf)", "You can track at a fast pace or move stealthily at a normal pace while tracking");
                                    break;
                            }
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Spirit Walker", "You can cast the 'commune with nature' spell as a ritual");
                        }
                        if (lvl >= 14)
                        {
                            index = CLIHelper.PrintChoices(animalMsg, animals);

                            switch (index)
                            {
                                case 0:
                                    result.ClassFeatures.Add("Totemic Attunement(Bear)", "While raging, hostile creatures within 5ft have disadv on atks that aren't against you." +
                                    "\n Doesn't effect enemies who can't see or hear you or those that can't be frightened");
                                    break;
                                case 1:
                                    result.ClassFeatures.Add("Totemic Attunement(Eagle)", "While raging, gain a fly speed = walking speed. If middair at the end of" +
                                    "\n your turn, you fall to the ground");
                                    break;
                                case 2:
                                    result.ClassFeatures.Add("Totemic Attunement(Elk)", "While raging, bonus, Str save, 1D12 + Str bludgeoning and knock prone");
                                    break;
                                case 3:
                                    result.ClassFeatures.Add("Totemic Attunement(Tiger)", "While raging, if you move 20ft, bonus melee atk");
                                    break;
                                case 4:
                                    result.ClassFeatures.Add("Totemic Attunement(Wolf)", "While raging, bonus, when you hit a melee atk, knock Large or smaller creatures prone");
                                    break;
                            }
                        }
                        break;
                    case "Wild Magic":
                        result.ClassFeatures.Add("Magic Awareness", "PB/LR, action, 60ft, sense spells and magic items - when you sense a spell learn its school");
                        result.ClassFeatures.Add("Wild Surge", "When you rage, roll 1D8 to determine an effect, Con-based DCs" +
                                "\n1 - Shadowy tendrils(30ft, Con save, 1D12 Necrotic dmg, gain dmg as temp HP)" +
                                "\n2 - Teleportation(30ft, repeat as bonus)" +
                                "\n3 - Flumph or Pixie Spirit(30ft, appears adj, at end of turn it explodes - adj, Dex save, 1D6 Force dmg, repeat as bonus)" +
                                "\n4 - Magic Weapon(becomes Force dmg, gain Light and Thrown 20/60 properties, if it leaves your hand - it returns next turn)" +
                                "\n5 - Retribution(when you're hit, deal 1D6 Force dmg)" +
                                "\n6 - Protective Lights(10ft, you and allies gain +1 AC)" +
                                "\n7 - Flowers and Vines(ground 15ft around you is difficult terrain)" +
                                "\n8 - Bolt of Light(30ft, Con save, 1D6 Radiant dmg, blind - repeat as bonus)");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Bosltering Magic", "PB/LR, action - 10 min, atks and checks + 1D3 or LR, ally regains spell slot lvl = 1D3");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Unstable Backlash", "reaction, while raging, if you take dmg or fail a save, gain a new Wild Surge effect");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Controlled Surge", "When deciding a Wild Surge effect roll twice, if same result pick your effect");
                        }
                        break;
                    case "Zealot":
                        Console.WriteLine("Do you want to deal Radiant dmg or Necrotic dmg?");
                        var list = new List<string> { "Radiant", "Necrotic" };
                        string dmgType = CLIHelper.PrintChoices(list);
                        result.ClassFeatures.Add("Divine Fury", $"1st hit/turn, 1D6 + 1/2 lvl {dmgType} dmg");
                        result.ClassFeatures.Add("Warrior of the Gods", "when restored to life by a spell, you don't suffer any negative effects");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Fanatical Focus", "1/rage, while raging, if you fail a save, reroll it - use new roll");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Zealous Presence", "LR, bonus, 60ft, up to 10 allies, adv on atks");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Rage beyond Death", "While raging, dropping to 0 HP doesn't knock you unconscious, make death saves as normal" +
                                "\nif you 'die', then you don't die until your rage ends");
                        }
                        break;
                }
            }
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
                result.ClassFeatures.Add("Fast Movement", "While not wearing heavy armor, increase speed by 10ft");
                FastMovement = 10;
            }
            if (lvl >= 7)
            {
                result.ClassFeatures.Add("Feral Instinct", "can't be surprised, adv on Init");
                result.ClassFeatures.Add("Instinctive Pounce", "bonus, when you rage move 1/2 your speed");
            }
            if (lvl >= 9)
            {
                result.ClassFeatures.Add("Brutal Critical", $"When you crit, roll {brutalCritDice} extra weapon dmg die");
            }
            if (lvl >= 10)
            {
                string pickMsg = "Pick a new skill from your skill list";
                string errorMsg = "You already have that skill";
                var classSkills = new List<string>() { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival" };
                string skill = CLIHelper.GetNew(classSkills, character.SkillProficiencies, pickMsg, errorMsg);
                character.SkillProficiencies.Add(skill);
            }
            if (lvl >= 11)
            {
                result.ClassFeatures.Add("Relentless Rage", "While raging, when you drop to 0HP, Con save, on success drop to 1HP." +
                    "\nDC starts at 10, +5 every time feature is used. DC resets after a SR/LR");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures.Add("Persistent Rage", "Rage only ends if you fall unconscious or you choose to end it");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Indomitable Might", "If your total Str check is less than your Str score, you can use your Str score instead");
            }
            
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Primal Champion", "Increase Str and Con by 4, the max for Str and Con are now 24");
                character.StatMax += 4;
                character.Stats["Str"] += 4;
                character.Stats["Con"] += 4;
            }

            return result;
        }
    }
}
