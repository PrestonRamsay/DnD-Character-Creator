using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class MonkSpecifics
    {
        public static string MonasticTradition { get; set; }
        public static int FastMovement { get; set; } = 0;
        public static CharacterClass Features(CharacterClass result)
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
            result.ClassFeatures.Add("Martial Arts", $"Dex for atk/dmg, dmg + 1D{martialArtsDie}, bonus - melee atk");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Ki", $"SR, meditate 30min, points = {lvl}");
                result.ClassFeatures.Add("Unarmored Movement", $"speed + {fastMovement}ft");
                FastMovement = fastMovement;
            }
            if (lvl >= 3)
            {
                result.ClassFeatures.Add("Deflect Missiles", "reaction, reduce ranged dmg by 1D10 + Dex + lvl, if dmg reduced to 0 - spend" +
                    $"\n1 ki pt to make atk range 20/60, dmg = 1D{martialArtsDie}");
                string msg = "Pick a Monastic Tradition that will give you features at levels 3, 6, 11, and 17.";
                var archetype = new List<string> { "Way of the Open Hand", "Way of Shadow", "Way of the Four Elements" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                if (answer == 0)
                {
                    MonasticTradition = "Open Hand";
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
                }
                else if (answer == 1)
                {
                    MonasticTradition = "Shadow";
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
                }
                else if (answer == 2)
                {
                    MonasticTradition = "Four Elements";
                    int maxKi = 2;
                    result.ClassFeatures.Add("Disciple of the Elements", "use ki to cast spells");
                    result.ClassFeatures.Add("Elemental Attunement", "Prestidigation");
                    result.ClassFeatures.Add("Fangs of Fire Snake", "1 ki pt, reach 10ft, spend ki pt to add 1D10 fire dmg");
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
                        result.ClassFeatures["Fangs of Fire Snake"] = "1 ki pt, reach 10ft +1D10 fire, spend ki pt to add 1D10 fire dmg";
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
                }
            }
            if (lvl >= 4)
            {
                result.ClassFeatures.Add("Slow Fall", "reaction, reduce fall dmg by lvl x 5");
            }
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
                result.ClassFeatures.Add("Stunning Strike", "on hit, 1 ki pt, Con save, stun 1 turn");
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
                result.ClassFeatures.Add("Purity of Body", "disease/poison immunity");
            }
            if (lvl >= 13)
            {
                result.ClassFeatures.Add("Tongue of the Sun and Moon", "understand/speak all spoken languages");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Diamond Soul", "gain prof in all saves, spend 1 ki pt to reroll a save");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures.Add("Timeless Body", "no age minuses, can't be aged magically, don't need food/water");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Empty Body", "action, 4 ki pt, 1min, become invisible, gain Resistance to all dmg except force," +
                    "\nor spend 8 ki pt to cast Astral Projection spell");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Perfect Self", "on init, if no ki pt, regain 4 ki pt");
            }

            return result;
        }
    }
}
