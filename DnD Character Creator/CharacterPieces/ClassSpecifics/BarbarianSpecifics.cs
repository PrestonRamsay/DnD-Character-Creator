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
        public static CharacterClass Features(CharacterClass result)
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
                result.ClassFeatures.Add($"Rage({numberOfRages}/day)", $"bonus, 1min, adv on Str checks/saves, Str melee dmg+{rageDamage}," +
                $"\ngain Resistance to Bludgeoning, Piercing, Slashing (end as bonus or if you don't atk or take dmg)");
            }
            else
            {
                result.ClassFeatures.Add($"Rage(Unlimited)", $"bonus, 1min, adv on Str checks/saves, Str melee dmg+{rageDamage}," +
                $"\ngain Resistance to Bludgeoning, Piercing, Slashing (end as bonus or if you don't atk or take dmg)");
            }
            result.ClassFeatures.Add("Unarmored Defense", "AC + Dex or Con, while wearing no armor");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Reckless Attack", "On your first atk, gain adv on atk rolls this turn, but atks against you" +
                    "\n also have adv until your next turn");
                result.ClassFeatures.Add("Danger Sense", "Gain adv on Dex saves on effects you can see such as traps and spell" +
                    "\n You can't be blinded, deafened, or incapacitated");
            }
            if (lvl >= 3)
            {
                string msg = "Pick a Primal Path that will give you features at levels 3, 6, 10, and 14.";
                var primalPaths = new List<string> { "Path of the Berserker", "Path of the Totem Warrior" };
                int input = CLIHelper.PrintChoices(msg, primalPaths);

                if (input == 0)
                {
                    PathName = "Berserker";

                    result.ClassFeatures.Add("Frenzy", "When you rage, you can frenzy. While in a frenzy, you can melee atk as a bonus, but when your" +
                        "\n rage/frenzy ends you suffer one level of exhaustion");
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Mindless Rage", "You can't be charmed or frightened while raging.  If under one of those effects before" +
                        "\n raging they're suspended during the rage");
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("Intimidating Presence", "action, one creature within 30ft, Wis save or become frightened, action to sustain." +
                                "\n End if the creature is out of line of sight or 60ft+ away. Successful save means immune for 24hr");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Retaliation", "When you take dmg from a creature within 5ft, reaction, make a melee atk");
                    }
                }
                else if (input == 1)
                {
                    PathName = "Totem Warrior";

                    string animalMsg = "Pick an animal to determine your feature.";
                    var animals = new List<string> { "Bear", "Eagle", "Wolf" };
                    int animal = CLIHelper.PrintChoices(animalMsg, animals);

                    if (animal == 0)
                    {
                        result.ClassFeatures.Add("Totem Spirit(Bear)", "While raging, gain Resistance to all dmg except Psychic");
                    }
                    else if (animal == 1)
                    {
                        result.ClassFeatures.Add("Totem Spirit(Eagle)", "While raging and not wearing heavy armor, op atk against you have disadv, and" +
                            "\n you can Dash as a bonus");
                    }
                    else if (animal == 2)
                    {
                        result.ClassFeatures.Add("Totem Spirit(Wolf)", "While raging, your allies have adv on atks on hostile creatures within 5ft of you");
                    }

                    if (lvl >= 6)
                    {
                        int lvl6Animal = CLIHelper.PrintChoices(animalMsg, animals);

                        if (lvl6Animal == 0)
                        {
                            result.ClassFeatures.Add("Aspect of the Beast(Bear)", "Double your carrying capacity, and gain adv on Str checks to" +
                                "\n push, pull, lift or break objects");
                        }
                        else if (lvl6Animal == 1)
                        {
                            result.ClassFeatures.Add("Aspect of the Beast(Eagle)", "You can see up to a mile away, discerning details as if they were 100ft away." +
                                "\n Dim light does not impose disadv on Perception checks");
                        }
                        else if (lvl6Animal == 2)
                        {
                            result.ClassFeatures.Add("Aspect of the Beast(Wolf)", "You can track at a fast pace or move stealthily at a normal pace while tracking");
                        }
                    }
                    if (lvl >= 10)
                    {
                        result.ClassFeatures.Add("Spirit Walker", "You can cast the 'commune with nature' spell as a ritual");
                    }
                    if (lvl >= 14)
                    {
                        int lvl14Animal = CLIHelper.PrintChoices(animalMsg, animals);

                        if (lvl14Animal == 0)
                        {
                            result.ClassFeatures.Add("Totemic Attunement(Bear)", "While raging, hostile creatures within 5ft have disadv on atks that aren't against you." +
                                "\n Doesn't effect enemies who can't see or hear you or those that can't be frightened");
                        }
                        else if (lvl14Animal == 1)
                        {
                            result.ClassFeatures.Add("Totemic Attunement(Eagle)", "While raging, gain a fly speed = walking speed. If middair at the end of" +
                                "\n your turn, you fall to the ground");
                        }
                        else if (lvl14Animal == 2)
                        {
                            result.ClassFeatures.Add("Totemic Attunement(Wolf)", "While raging, bonus, when you hit a melee atk, knock Large or smaller creatures prone");
                        }
                    }
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
                result.ClassFeatures.Add("Feral Instinct", "Gain adv on init. You aren't incapacitated when surprised and can act normally," +
                    "\n but only if you rage at the start of your turn");
            }
            if (lvl >= 9)
            {
                result.ClassFeatures.Add("Brutal Critical", $"When you crit, roll {brutalCritDice} extra weapon dmg die");
            }
            if (lvl >= 11)
            {
                result.ClassFeatures.Add("Relentless Rage", "While raging, when you drop to 0HP make a Con save, on success drop to 1HP." +
                    "\n DC starts at 10 and increases by 5 every time the feature is used. DC resets after a SR/LR");
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
            }

            return result;
        }
    }
}
