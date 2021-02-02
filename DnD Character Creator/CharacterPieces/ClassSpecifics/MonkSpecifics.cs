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
            result.ClassFeatures.Add("Unarmored Defense", "AC + Wis");
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
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 11)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                }
                else if (answer == 1)
                {
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 11)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                }
                else if (answer == 2)
                {
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 11)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("", "");
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
                result.ClassFeatures.Add("Stunning Strike", "when melee, 1 ki pt, Con save, stun 1 turn");
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
