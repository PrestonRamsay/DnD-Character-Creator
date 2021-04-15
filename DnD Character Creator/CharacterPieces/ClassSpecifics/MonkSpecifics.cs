using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class MonkSpecifics
    {
        public static string MonasticTradition { get; set; }
        public static int MartialArtsDie { get; set; }
        public static CharacterClass Features(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;
            int martialArtsDie = 4;
            int fastMovement = 10;
            for (int i = 5; i <= lvl; i++)
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
            MartialArtsDie = martialArtsDie;
            result.ClassFeatures.Add("Unarmored Defense", "AC = 10 + Dex + Wis, while wearing no armor");
            result.ClassFeatures.Add("Martial Arts", $"Dex for unarmed atk/dmg, unarmed dmg = 1D{martialArtsDie}, melee atk as bonus");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Ki", $"SR, meditate 30min, ki pts = {lvl}, gain the following features" +
                    $"\n        Flurry of Blows(1 ki pt, make 2 unarmed atks as a bonus)" +
                    $"\n        Patient Defense(1 ki pt, Dodge as bonus)" +
                    $"\n        Step of the Wind(1 ki pt, Disengage or Dash as bonus, jump distance is doubled this turn)");
                result.ClassFeatures.Add("Unarmored Movement", $"speed + {fastMovement}ft");
                character.Speed += fastMovement;
                result.ClassFeatures.Add("Dedicated Weapon", "on SR/LR, touch non-Heavy wep you have prof with, it becomes a monk weapon");
            }
            if (lvl >= 3)
            {
                result.ClassFeatures.Add("Deflect Missiles", $"reaction, reduce ranged dmg by 1D10 + Dex + lvl, if dmg = 0 - 1 ki pt to make atk range 20/60, dmg = 1D{martialArtsDie}(MA die)");
                result.ClassFeatures.Add("Ki-Fueled Attack", "bonus, when you take an action, spend 1 ki pt, make an mele atk");
                string msg = "Pick a Monastic Tradition that will give you features at levels 3, 6, 11, and 17.";
                var archetype = new List<string> { "Way of the Astral Self", "Way of the Drunken Master", "Way of the Four Elements",
                    "Way of the Kensai", "Way of the Long Death", "Way of Mercy", "Way of the Open Hand", "Way of Shadow", "Way of the Sun Soul" };
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
                        AstralSelf(character, result);
                        break;
                    case "Drunken Master":
                        DrunkenMaster(character, result);
                        break;
                    case "Four Elements":
                        FourElements(character, result);
                        break;
                    case "Kensai":
                        Kensai(character, result);
                        break;
                    case "Long Death":
                        LongDeath(character, result);
                        break;
                    case "Mercy":
                        Mercy(character, result);
                        break;
                    case "Open Hand":
                        OpenHand(character, result);
                        break;
                    case "Shadow":
                        Shadow(character, result);
                        break;
                    case "Sun Soul":
                        SunSoul(character, result);
                        break;
                }
            }
            if (lvl >= 4)
            {
                result.ClassFeatures.Add("Slow Fall", "reaction, reduce fall dmg by lvl x 5");
                result.ClassFeatures.Add("Quickened Healing", $"action, spend 2 ki pt, heal HP = 1D{martialArtsDie}(MA die) + PB");
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
                    "\n        or 8 ki pt to cast Astral Projection spell");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Perfect Self", "on nit, if no ki pt, regain 4 ki pt");
            }

            return result;
        }
        public static void AstralSelf(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            result.ClassFeatures.Add("Arms of the Astral Self", "bonus, 10min, 10ft, 1 ki pt, Dex save, 2 Martial Arts dice Force dmg" +
                "\n        use Wis for Str checks/saves, unarmed atks / gain reach 5ft, unarmed dmg type = Force");
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Visage of the Astral Self", "bonus, 10min, 1 ki pt, gain a spectral mask/helmet - appearance of your choice and all benefits" +
                    "\n        Astral Sight(see through magical/nonmagical darkness 120ft)" +
                    "\n        Wisdom of the Spirit(gain adv on Insight and Intimidation)" +
                    "\n        Word of the Spirit(you can make only 1 creature hear your voice within 60ft, or amplify your voice up to 600ft)");
            }
            if (lvl >= 11)
            {
                result.ClassFeatures.Add("Body of the Astral Self", "when your Arms of the Astral Self and Visage of the Astral Self are both active gain all benefits" +
                    "\n        Deflect Energy(reaction, when you take Acid, Cold, Fire, Force, Lightning or Thunder dmg, reduce dmg by 1D10 + Wis)" +
                    "\n        Empowered Arms(1/turn, on hit, dmg + Martial Arts die)");
            }
            if (lvl >= 17)
            {
                result.ClassFeatures.Add("Awakened Astral Self", "bonus, 10min, 5 ki pts, summon Arms, Visage, and Body of the Astral Self and gain all benefits" +
                    "\n        Armor of the Spirit(+2 AC), Astral Barrage(when you use Attack action to make 2 atk with your astral arms, make 3 atk instead)");
            }
        }
        public static void DrunkenMaster(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            character.SkillProficiencies.Add("Performance");
            result.ToolProficiencies.Add("Brewer's Supplies");
            result.ClassFeatures.Add("Drunken Technique", "When you use Flurry of Blows, gain benefits of Disengage and speed +10ft");
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Tipsy Sway", "Leap to Your Feet(while prone, stand up for 5ft of movement)" +
                    "\n        Redirect Attack(when an atk vs you misses, 1 ki pt to cause the atk to hit an adj creature)");
            }
            if (lvl >= 11)
            {
                result.ClassFeatures.Add("Drunkard's Luck", "When you make an atk, save or check at disadv, 2 ki pt to cancel the disadv");
            }
            if (lvl >= 17)
            {
                result.ClassFeatures.Add("Intoxicated Frenzy", "When you use Flurry of Blows, atk up to 5 times if you atk different creatures");
            }
        }
        public static void FourElements(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
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
                    $"\n        higher lvl up to a max of {maxKi}");
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
        }
        public static void Kensai(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            string kensaiWep = GetKensaiWeapons(result, lvl);
            result.ClassFeatures.Add("Path of the Kensai", $"Kensai Weapons(treat as monk wep: {kensaiWep})" +
                $"\n        Agile Parry(while holding Kensai wep, if you make unarmed atk, +2 AC), Kensai's Shot(bonus, ranged dmg + 1D4)");
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
        }
        public static void LongDeath(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
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
        }
        public static void Mercy(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            character.SkillProficiencies.Add("Insight");
            character.SkillProficiencies.Add("Medicine");
            result.ToolProficiencies.Add("Herbalism Kit");
            Console.WriteLine("Pick an appearance for your merciful mask");
            var masks = new List<string> { "Raven", "Blank white", "Crying visage", "Laughing visage", "Skull", "Butterfly" };
            result.Equipment.Add(CLIHelper.PrintChoices(masks));
            result.ClassFeatures.Add("Implements of Mercy", "gain prof in Insight, Medicine and Herbalism Kit");
            result.ClassFeatures.Add("Hand of Healing", "action, 1 ki pt, touch, restore HP = Martial Arts die + Wis / forgo an atk to use during Flurry of Blows");
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Hand of Harm", "1/turn, on hit, 1 ki pt, Martial Arts die + Wis Necrotic dmg");
            }
            if (lvl >= 11)
            {
                result.ClassFeatures.Add("Physician's Touch", "Hand of Healing can also cure disease or remove blind, deaf, paralyze, posion, stun" +
                    "\n        Hand of Harm can influct poison condition(disadv on atks/ability checks)");
            }
            if (lvl >= 17)
            {
                result.ClassFeatures.Add("Hand of Ultimate Mercy", "LR, action, 5 ki pt, touch creature that died within 24hr, revives with 4D10 + Wis HP, removes blind, deaf, paralyze, posion, stun");
            }
        }
        public static void OpenHand(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            result.ClassFeatures.Add("Open Hand Technique", "when use Flurry of Blows, gain one" +
                    "\n        Str save - push 15ft" +
                    "\n        Dex save - knock prone" +
                    "\n        enemy can't take reactions");
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Wholeness of Body", "LR, action, heal HP = lvl x 3");
            }
            if (lvl >= 11)
            {
                result.ClassFeatures.Add("Tranquility", "on LR, gain Sanctuary spell effect, Wis-based DC");
            }
            if (lvl >= 17)
            {
                result.ClassFeatures.Add("Quivering Palm", "on hit, 3 ki pt, Con save - 0 HP or 10D10 Necrotic dmg");
            }
        }
        public static void Shadow(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
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
        public static void SunSoul(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            result.ClassFeatures.Add("Radiant Sun Bolt", $"action, 30ft, 1D{MartialArtsDie}(MA die) + Dex Radiant dmg, 1 ki pt to atk again with bonus");
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
