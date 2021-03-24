﻿using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class MonkSpecifics
    {
        public static string MonasticTradition { get; set; }
        public static int FastMovement { get; set; } = 0;
        public static CharacterClass Features(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;
            int martialArtsDie = 4;
            int fastMovement = 10;
            for (int i = 5; i >= 18; i++)
            {
                if (i == 5 || i == 11 || i == 17)
                {
                    martialArtsDie += 2;
                }
                if (i == 6 || i == 10 || i == 14 || i == 18)
                {
                    fastMovement += 5;
                }
            }
            result.ClassFeatures.Add("Unarmored Defense", "AC + Dex or Wis, while wearing no armor");
            result.ClassFeatures.Add("Martial Arts", $"Dex for atk/dmg, dmg = 1D{martialArtsDie}, bonus - melee atk");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Ki", $"SR, meditate 30min, points = {lvl}");
                result.ClassFeatures.Add("Unarmored Movement", $"speed + {fastMovement}ft");
                FastMovement = fastMovement;
                result.ClassFeatures.Add("Dedicated Weapon", "on SR/LR, touch non-Heavy wep you have prof with, it becomes a monk weapon");
            }
            if (lvl >= 3)
            {
                result.ClassFeatures.Add("Deflect Missiles", $"reaction, reduce ranged dmg by 1D10 + Dex + lvl, if dmg = 0 - 1 ki pt to make atk range 20/60, dmg = 1D{martialArtsDie}(MA die)");
                result.ClassFeatures.Add("Ki-Fueled Attack", "bonus, when you take an action, spend 1 ki pt, make an mele atk");
                string msg = "Pick a Monastic Tradition that will give you features at levels 3, 6, 11, and 17.";
                var archetype = new List<string> { "Way of the Astral Self*", "Way of the Drunken Master", "Way of the Four Elements",
                    "Way of the Kensai", "Way of the Long Death", "Way of Mercy*", "Way of the Open Hand", "Way of Shadow", "Way of the Sun Soul" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                if (answer == 5 || answer == 7)
                {
                    MonasticTradition = archetype[answer].Substring(6);
                }
                else
                {
                    MonasticTradition = archetype[answer].Substring(10);
                }

                switch (MonasticTradition)
                {
                    case "Astral Self":
                        //result.ClassFeatures.Add("", "");
                        //if (lvl >= 6)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 11)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 17)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        break;
                    case "Drunken Master":
                        character.SkillProficiencies.Add("Performance");
                        result.ToolProficiencies.Add("Brewer's Supplies");
                        result.ClassFeatures.Add("Drunken Technique", "When you use Flurry of Blows, gain benefits of Disengage and speed +10ft");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Tipsy Sway", "Leap to Your Feet(while prone, stand up for 5ft of movement)" +
                                "\nRedirect Attack(when an atk vs you misses, 1 ki pt to cause the atk to hit an adj creature)");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Drunkard's Luck", "When you make an atk, save or check at disadv, 2 ki pt to cancel the disadv");
                        }
                        if (lvl >= 17)
                        {
                            result.ClassFeatures.Add("Intoxicated Frenzy", "When you use Flurry of Blows, atk up to 5 times if you atk different creatures");
                        }
                        break;
                    case "Four Elements":
                        int maxKi = 2;
                        result.ClassFeatures.Add("Disciple of the Elements", "use ki to cast spells");
                        result.ClassFeatures.Add("Elemental Attunement", "Prestidigation");
                        result.ClassFeatures.Add("Fangs of Fire Snake", "1 ki pt, reach 10ft, spend ki pt to add 1D10 Fire dmg");
                        result.ClassFeatures.Add("Fist of Four Thunders", "2 ki pt, cast Thunderwave");
                        result.ClassFeatures.Add("Fist of Unbroken Air", "2 ki pt, 30ft, Str save - 3D10 + 1D10 per ki pt, push 20ft, knock prone");
                        result.ClassFeatures.Add("Rush of Gale Spirits", "2 ki pt, cast Gust of Wind");
                        result.ClassFeatures.Add("Shape of Flowing Water", "1 ki pt, 120ft, transform or shape 30ft of water or ice");
                        result.ClassFeatures.Add("Sweeping Cinder Strike", "2 ki pt, cast Burning Hands");
                        result.ClassFeatures.Add("Water Whip", "bonus, 2 ki pt, 30ft, Dex save - knock prone or pull 25ft, 3D10, spend ki pt to add 1D10 dmg");
                        if (lvl >= 5)
                        {
                            for (int i = 5; i <= lvl; i += 4)
                            {
                                maxKi++;
                            }
                            result.ClassFeatures.Add("Casting Elemental Spells", $"you can spend additional ki pts to use a discipline at a" +
                                $"\nhigher lvl up to a max of {maxKi}");
                        }
                        if (lvl >= 6)
                        {
                            result.ClassFeatures["Fangs of Fire Snake"] = "1 ki pt, reach 10ft +1D10 Fire, spend ki pt to add 1D10 Fire dmg";
                            result.ClassFeatures["Fist of Four Thunders"] = "1 ki pt, cast Thunderwave";
                            result.ClassFeatures["Fist of Unbroken Air"] = "1 ki pt, 30ft, Str save - 3D10 + 1D10 per ki pt, push 20ft, knock prone";
                            result.ClassFeatures["Rush of Gale Spirits"] = "1 ki pt, cast Gust of Wind";
                            result.ClassFeatures["Sweeping Cinder Strike"] = "1 ki pt, cast Burning Hands";
                            result.ClassFeatures["Water Whip"] = "bonus, 1 ki pt, 30ft, Dex save - knock prone or pull 25ft, 3D10, spend ki pt to add 1D10 dmg";
                            result.ClassFeatures.Add("Clench of the North Wind", "2 ki pt, cast Hold Person");
                            result.ClassFeatures.Add("Gong of the Summit", "2 ki pt, cast Shatter");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures["Clench of the North Wind"] = "1 ki pt, cast Hold Person";
                            result.ClassFeatures["Gong of the Summit"] = "1 ki pt, cast Shatter";
                            result.ClassFeatures.Add("Eternal Mountain Defense", "3 ki pt, cast Stoneskin");
                            result.ClassFeatures.Add("Flames of the Phoenix", "2 ki pt, cast Fireball");
                            result.ClassFeatures.Add("Mist Stance", "2 ki pt, cast Gaseous Form");
                        }
                        if (lvl >= 17)
                        {
                            result.ClassFeatures["Eternal Mountain Defense"] = "2 ki pt, cast Stoneskin";
                            result.ClassFeatures.Add("Breath of Winter", "3 ki pt, cast Cone of Cold");
                            result.ClassFeatures.Add("River of Hungry Flame", "3 ki pt, cast Wall of Fire");
                            result.ClassFeatures.Add("Wave of Rolling Earth", "3 ki pt, cast Wall of Stone");
                        }
                        break;
                    case "Kensai":
                        string kensaiWep = GetKensaiWeapons(result, lvl);
                        result.ClassFeatures.Add("Path of the Kensai", $"Kensai Weapons(treat as monk wep: {kensaiWep})" +
                            $"\nAgile Parry(while holding Kensai wep, if you make unarmed atk, +2 AC), Kensai's Shot(bonus, ranged dmg + 1D4)");
                        var deftStrokes = new List<string> { "Calligrapher's Supplies", "Painter's Supplies" };
                        int index = CLIHelper.PrintChoices("Pick a tool", deftStrokes);
                        result.ToolProficiencies.Add(deftStrokes[index]);
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("One with the Blade", "Kensai Weapons are considered magical, Deft Strike(on hit with Kensai Weapon, 1/turn, 1 ki pt, dmg + Martial Arts Die)");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Sharpen the Blade", "bonus, 3 ki pt, 1 min, atk/dmg + 3");
                        }
                        if (lvl >= 17)
                        {
                            result.ClassFeatures.Add("Unerring Accuracy", "1/turn, if miss with monk weapon, reroll atk");
                        }
                        break;
                    case "Long Death":
                        result.ClassFeatures.Add("Touch of Death", "When you kill a creature, gain temp HP = Wis + lvl");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Hour of Reaping", "action, 30ft, Wis save, fear");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Mastery of Death", "When you drop to 0 HP - expend 1 ki pt, drop to 1 HP instead");
                        }
                        if (lvl >= 17)
                        {
                            result.ClassFeatures.Add("Touch of the Long Death", "action, Con save, expend 1-10 ki pt, 2D10 Necrotic dmg per ki pt");
                        }
                        break;
                    case "Mercy":
                        //result.ClassFeatures.Add("", "");
                        //if (lvl >= 6)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 11)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 17)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        break;
                    case "Open Hand":
                        result.ClassFeatures.Add("Open Hand Technique", "when use Flurry of Blows, gain one" +
                                "\nStr save - push 15ft" +
                                "\nDex save - knock prone" +
                                "\nenemy can't take reactions");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Wholeness of Body", "action, LR, heal HP = lvl x 3");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Tranquility", "after LR, gain Sanctuary spell effect, Wis-based DC");
                        }
                        if (lvl >= 17)
                        {
                            result.ClassFeatures.Add("Quivering Palm", "on hit, 3 ki pt, Con save - 0 HP or 10D10 Necrotic dmg");
                        }
                        break;
                    case "Shadow":
                        result.ClassFeatures.Add("Shadow Arts", "action, 2 ki pt, cast - Darkness, Darkvision, Pass Without a Trace, or Silence");
                        result.Cantrips.Add("Minor Illusion");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Shadow Step", "bonus, teleport 60ft, adv on next melee atk");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Cloak of Shadows", "action, in dim light or darkness become invisible");
                        }
                        if (lvl >= 17)
                        {
                            result.ClassFeatures.Add("Opportunist", "reaction, when creature is hit by someone else you can melee atk");
                        }
                        break;
                    case "Sun Soul":
                        result.ClassFeatures.Add("Radiant Sun Bolt", $"action, 30ft, 1D{martialArtsDie}(MA die) + Dex Radiant dmg, 1 ki pt to atk again with bonus");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Searing Arc Strike", "after Attack action, 2 ki pt, cast Burning Hands as bonus, spend ki pt to increase spell lvl (max 1/2 lvl - 2)");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Searing Sunburst", "action, 20ft within 150ft, Con save, 2D6 Radiant dmg, spend up to 3 ki pt to increase dmg by 2D6 per ki pt");
                        }
                        if (lvl >= 17)
                        {
                            result.ClassFeatures.Add("Sun Shield", "bonus, 30ft bright light, 30ft dim light, if hit - reaction, 5 + Wis Radiant dmg");
                        }
                        break;
                }
            }
            if (lvl >= 4)
            {
                result.ClassFeatures.Add("Slow Fall", "reaction, reduce fall dmg by lvl x 5");
                result.ClassFeatures.Add("Quickened Healing", $"action, spend 2 ki pt, heal HP = 1D{martialArtsDie}(MA die) + prof bonus");
            }
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
                result.ClassFeatures.Add("Stunning Strike", "on hit, 1 ki pt, Con save, stun 1 turn");
                result.ClassFeatures.Add("Focused Aim", "When you miss an atk, spend 1-3 ki pt, gain bonus to atk = ki spent");
            }
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Ki-Empowered Strikes", "unarmed atks count as magical");
            }
            if (lvl >= 7)
            {
                result.ClassFeatures.Add("Evasion", "Dex saves = 1/2 or no dmg");
                result.ClassFeatures.Add("Stillness of Mind", "action, end charm or fear effect");
            }
            if (lvl >= 9)
            {
                result.ClassFeatures["Unarmored Movement"] = $"speed + {fastMovement}ft, can move on vertical/liquid surfaces";
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Purity of Body", "gain Immnunity to disease and poison");
            }
            if (lvl >= 13)
            {
                result.ClassFeatures.Add("Tongue of the Sun and Moon", "understand/speak all spoken languages");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Diamond Soul", "gain prof in all saves, 1 ki pt to reroll a save");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures.Add("Timeless Body", "no age minuses, can't be aged magically, don't need food/water");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Empty Body", "action, 4 ki pt, 1 min, become invisible, gain Resistance to all dmg except Force," +
                    "\nor 8 ki pt to cast Astral Projection spell");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Perfect Self", "on nit, if no ki pt, regain 4 ki pt");
            }

            return result;
        }
        public static string GetKensaiWeapons(CharacterClass result, int lvl)
        {
            var allMelee = new List<string>();
            var kensaiMelee = new List<string>();
            allMelee.AddRange(Options.SimpleMeleeWeapons);
            allMelee.AddRange(Options.MartialMeleeWeapons);
            var allRanged = new List<string>();
            var kensaiRanged = new List<string>();
            allRanged.AddRange(Options.SimpleRangedWeapons);
            allRanged.AddRange(Options.MartialRangedWeapons);
            foreach (var item in allMelee)
            {
                if (!item.Contains("Heavy") && !item.Contains("Special"))
                {
                    kensaiMelee.Add(item);
                }
            }
            foreach (var item in allRanged)
            {
                if (!item.Contains("Heavy") && !item.Contains("Special"))
                {
                    kensaiRanged.Add(item);
                }
            }
            kensaiRanged.Add("Longbow");
            var kensaiWep = new List<string>();
            Console.WriteLine("Pick two Kensai weapons to gain proficiency with, they also count as monk weapons");
            string wep = CLIHelper.PrintChoices(kensaiMelee);
            kensaiMelee.Remove(wep);
            int paranthesis = wep.IndexOf("(");
            wep = wep.Substring(0, paranthesis);
            result.Proficiencies.Add(wep);
            kensaiWep.Add(wep);
            wep = CLIHelper.PrintChoices(kensaiRanged);
            kensaiRanged.Remove(wep);
            paranthesis = wep.IndexOf("(");
            wep = wep.Substring(0, paranthesis);
            result.Proficiencies.Add(wep);
            kensaiWep.Add(wep);
            kensaiMelee.AddRange(kensaiRanged);
            int kensaiProf = 0;
            for (int i = 6; i <= lvl; i += 5)
            {
                kensaiProf++;
                if (i == 11)
                {
                    i++;
                }
            }
            for (int i = 0; i < kensaiProf; i++)
            {
                Console.WriteLine("Pick a new Kensai weapon");
                wep = CLIHelper.PrintChoices(kensaiMelee);
                kensaiMelee.Remove(wep);
                paranthesis = wep.IndexOf("(");
                wep = wep.Substring(0, paranthesis);
                result.Proficiencies.Add(wep);
                kensaiWep.Add(wep);
            }
            return String.Join(", ", kensaiWep);
        }
    }
}
