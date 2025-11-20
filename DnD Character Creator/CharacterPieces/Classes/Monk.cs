using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Monk
    {
        public static string MonasticTradition { get; set; }
        public static int MartialArtsDie { get; set; }
        public static void Base(Character character)
        {
            List<string> classSkills = new List<string> { "Acrobatics", "Athletics", "History", "Insight", "Religion", "Stealth" };

            character.GP += 13;
            character.HitDie = 8;
            character.Proficiencies.Add("Simple weapons");
            character.Proficiencies.Add("Shortswords");
            Console.WriteLine("Which proficiency would you like?");
            //CLIHelper.Print2Choices("One type of Artisan's Tools", "One musical instrument");
            int choice = CLIHelper.GetChoiceFromPair("One type of Artisan's Tools", "One musical instrument");

            if (choice == 1)
            {
                int index = CLIHelper.PrintChoices("Pick a set of Artisan's Tools by entering a number.", Options.ArtisanTools);
                character.ToolProficiencies.Add(Options.ArtisanTools[index]);
            }
            else
            {
                int index = CLIHelper.PrintChoices("Pick a musical instrument you'd like to be proficient with.", Options.MusicalInstruments);
                character.Equipment.Add(Options.MusicalInstruments[index]);
            }

            character.Saves.Add("Str");
            character.Saves.Add("Dex");

            BEHelper.GetSkills(character, classSkills, 2);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            //CLIHelper.Print2Choices("Shortsword", "Any simple weapon");
            int input1 = CLIHelper.GetChoiceFromPair("Shortsword", "Any simple weapon");
            //CLIHelper.Print2Choices("Dungeoneer's Pack", "Explorer's Pack");
            int input2 = CLIHelper.GetChoiceFromPair("Dungeoneer's Pack", "Explorer's Pack");

            if (input1 == 1)
            {
                character.Equipment.Add(Options.MartialMeleeWeapons[13]);
            }
            else
            {
                BEHelper.AddSimpleWeapon(character);
            }
            if (input2 == 1)
            {
                character.Equipment.Add(Options.Packs[2]);
            }
            else
            {
                character.Equipment.Add(Options.Packs[4]);
            }

            character.Equipment.Add($"10 {Options.SimpleRangedWeapons[1]}");
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;
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
            character.ClassFeatures.Add("Unarmored Defense", "AC = 10 + Dex + Wis, while wearing no armor");
            character.ClassFeatures.Add("Martial Arts", $"Dex for unarmed atk/dmg, unarmed dmg = 1D{martialArtsDie}, melee atk as bonus");

            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Ki", $"SR, meditate 30min, ki pts = {lvl}, gain the following features" +
                    $"\n        Flurry of Blows(1 ki pt, make 2 unarmed atks as a bonus)" +
                    $"\n        Patient Defense(1 ki pt, Dodge as bonus)" +
                    $"\n        Step of the Wind(1 ki pt, Disengage or Dash as bonus, jump distance is doubled this turn)");
                character.ClassFeatures.Add("Unarmored Movement", $"speed + {fastMovement}ft");
                character.Speed += fastMovement;
                character.ClassFeatures.Add("Dedicated Weapon", "on SR/LR, touch non-Heavy wep you have prof with, it becomes a monk weapon");
            }
            if (lvl >= 3)
            {
                character.ClassFeatures.Add("Deflect Missiles", $"reaction, reduce ranged dmg by 1D10 + Dex + lvl, if dmg = 0 - 1 ki pt to make atk range 20/60, dmg = 1D{martialArtsDie}(MA die)");
                character.ClassFeatures.Add("Ki-Fueled Attack", "bonus, when you take an action, spend 1 ki pt, make an mele atk");
                string msg = "Pick a Monastic Tradition that will give you features at levels 3, 6, 11, and 17.";
                var archetype = new List<string> { "Way of the Astral Self", "Way of the Drunken Master", "Way of the Four Elements",
                    "Way of the Kensai", "Way of the Long Death", "Way of Mercy", "Way of the Open Hand", "Way of Shadow", "Way of the Sun Soul" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                if (answer == 5 || answer == 7)
                {
                    MonasticTradition = archetype[answer].Substring(7);
                }
                else
                {
                    MonasticTradition = archetype[answer].Substring(11);
                }

                switch (MonasticTradition)
                {
                    case "Astral Self":
                        AstralSelf(character);
                        break;
                    case "Drunken Master":
                        DrunkenMaster(character);
                        break;
                    case "Four Elements":
                        FourElements(character);
                        break;
                    case "Kensai":
                        Kensai(character);
                        break;
                    case "Long Death":
                        LongDeath(character);
                        break;
                    case "Mercy":
                        Mercy(character);
                        break;
                    case "Open Hand":
                        OpenHand(character);
                        break;
                    case "Shadow":
                        Shadow(character);
                        break;
                    case "Sun Soul":
                        SunSoul(character);
                        break;
                }
            }
            if (lvl >= 4)
            {
                character.ClassFeatures.Add("Slow Fall", "reaction, reduce fall dmg by lvl x 5");
                character.ClassFeatures.Add("Quickened Healing", $"action, spend 2 ki pt, heal HP = 1D{martialArtsDie}(MA die) + PB");
            }
            if (lvl >= 5)
            {
                character.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
                character.ClassFeatures.Add("Stunning Strike", "on hit, 1 ki pt, Con save, stun 1 turn");
                character.ClassFeatures.Add("Focused Aim", "When you miss an atk, spend 1-3 ki pt, gain bonus to atk = ki spent");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Ki-Empowered Strikes", "unarmed atks count as magical");
            }
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Evasion", "Dex saves = 1/2 or no dmg");
                character.ClassFeatures.Add("Stillness of Mind", "action, end charm or fear effect");
            }
            if (lvl >= 9)
            {
                character.ClassFeatures["Unarmored Movement"] = $"speed + {fastMovement}ft, can move on vertical/liquid surfaces";
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Purity of Body", "gain Immnunity to disease and poison");
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Add("Tongue of the Sun and Moon", "understand/speak all spoken languages");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Diamond Soul", "gain prof in all saves, 1 ki pt to reroll a save");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Timeless Body", "no age minuses, can't be aged magically, don't need food/water");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Empty Body", "action, 4 ki pt, 1 min, become invisible, gain Resistance to all dmg except Force," +
                    "\n        or 8 ki pt to cast Astral Projection spell");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Perfect Self", "on nit, if no ki pt, regain 4 ki pt");
            }

            
        }
        public static void AstralSelf(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Arms of the Astral Self", "bonus, 10min, 10ft, 1 ki pt, Dex save, 2 Martial Arts dice Force dmg" +
                "\n        use Wis for Str checks/saves, unarmed atks / gain reach 5ft, unarmed dmg type = Force");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Visage of the Astral Self", "bonus, 10min, 1 ki pt, gain a spectral mask/helmet - appearance of your choice and all benefits" +
                    "\n        Astral Sight(see through magical/nonmagical darkness 120ft)" +
                    "\n        Wisdom of the Spirit(gain adv on Insight and Intimidation)" +
                    "\n        Word of the Spirit(you can make only 1 creature hear your voice within 60ft, or amplify your voice up to 600ft)");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Body of the Astral Self", "when your Arms of the Astral Self and Visage of the Astral Self are both active gain all benefits" +
                    "\n        Deflect Energy(reaction, when you take Acid, Cold, Fire, Force, Lightning or Thunder dmg, reduce dmg by 1D10 + Wis)" +
                    "\n        Empowered Arms(1/turn, on hit, dmg + Martial Arts die)");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Awakened Astral Self", "bonus, 10min, 5 ki pts, summon Arms, Visage, and Body of the Astral Self and gain all benefits" +
                    "\n        Armor of the Spirit(+2 AC), Astral Barrage(when you use Attack action to make 2 atk with your astral arms, make 3 atk instead)");
            }
        }
        public static void DrunkenMaster(Character character)
        {
            int lvl = character.Lvl;
            character.SkillProficiencies.Add("Performance");
            character.ToolProficiencies.Add("Brewer's Supplies");
            character.ClassFeatures.Add("Drunken Technique", "When you use Flurry of Blows, gain benefits of Disengage and speed +10ft");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Tipsy Sway", "Leap to Your Feet(while prone, stand up for 5ft of movement)" +
                    "\n        Redirect Attack(when an atk vs you misses, 1 ki pt to cause the atk to hit an adj creature)");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Drunkard's Luck", "When you make an atk, save or check at disadv, 2 ki pt to cancel the disadv");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Intoxicated Frenzy", "When you use Flurry of Blows, atk up to 5 times if you atk different creatures");
            }
        }
        public static void FourElements(Character character)
        {
            int lvl = character.Lvl;
            int maxKi = 2;
            character.ClassFeatures.Add("Disciple of the Elements", "use ki to cast spells");
            character.ClassFeatures.Add("Elemental Attunement", "Prestidigation");
            character.ClassFeatures.Add("Fangs of Fire Snake", "1 ki pt, reach 10ft, spend ki pt to add 1D10 Fire dmg");
            character.ClassFeatures.Add("Fist of Four Thunders", "2 ki pt, cast Thunderwave");
            character.ClassFeatures.Add("Fist of Unbroken Air", "2 ki pt, 30ft, Str save - 3D10 + 1D10 per ki pt, push 20ft, knock prone");
            character.ClassFeatures.Add("Rush of Gale Spirits", "2 ki pt, cast Gust of Wind");
            character.ClassFeatures.Add("Shape of Flowing Water", "1 ki pt, 120ft, transform or shape 30ft of water or ice");
            character.ClassFeatures.Add("Sweeping Cinder Strike", "2 ki pt, cast Burning Hands");
            character.ClassFeatures.Add("Water Whip", "bonus, 2 ki pt, 30ft, Dex save - knock prone or pull 25ft, 3D10, spend ki pt to add 1D10 dmg");
            if (lvl >= 5)
            {
                for (int i = 5; i <= lvl; i += 4)
                {
                    maxKi++;
                }
                character.ClassFeatures.Add("Casting Elemental Spells", $"you can spend additional ki pts to use a discipline at a" +
                    $"\n        higher lvl up to a max of {maxKi}");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures["Fangs of Fire Snake"] = "1 ki pt, reach 10ft +1D10 Fire, spend ki pt to add 1D10 Fire dmg";
                character.ClassFeatures["Fist of Four Thunders"] = "1 ki pt, cast Thunderwave";
                character.ClassFeatures["Fist of Unbroken Air"] = "1 ki pt, 30ft, Str save - 3D10 + 1D10 per ki pt, push 20ft, knock prone";
                character.ClassFeatures["Rush of Gale Spirits"] = "1 ki pt, cast Gust of Wind";
                character.ClassFeatures["Sweeping Cinder Strike"] = "1 ki pt, cast Burning Hands";
                character.ClassFeatures["Water Whip"] = "bonus, 1 ki pt, 30ft, Dex save - knock prone or pull 25ft, 3D10, spend ki pt to add 1D10 dmg";
                character.ClassFeatures.Add("Clench of the North Wind", "2 ki pt, cast Hold Person");
                character.ClassFeatures.Add("Gong of the Summit", "2 ki pt, cast Shatter");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures["Clench of the North Wind"] = "1 ki pt, cast Hold Person";
                character.ClassFeatures["Gong of the Summit"] = "1 ki pt, cast Shatter";
                character.ClassFeatures.Add("Eternal Mountain Defense", "3 ki pt, cast Stoneskin");
                character.ClassFeatures.Add("Flames of the Phoenix", "2 ki pt, cast Fireball");
                character.ClassFeatures.Add("Mist Stance", "2 ki pt, cast Gaseous Form");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures["Eternal Mountain Defense"] = "2 ki pt, cast Stoneskin";
                character.ClassFeatures.Add("Breath of Winter", "3 ki pt, cast Cone of Cold");
                character.ClassFeatures.Add("River of Hungry Flame", "3 ki pt, cast Wall of Fire");
                character.ClassFeatures.Add("Wave of Rolling Earth", "3 ki pt, cast Wall of Stone");
            }
        }
        public static void Kensai(Character character)
        {
            int lvl = character.Lvl;
            string kensaiWep = GetKensaiWeapons(character, lvl);
            character.ClassFeatures.Add("Path of the Kensai", $"Kensai Weapons(treat as monk wep: {kensaiWep})" +
                $"\n        Agile Parry(while holding Kensai wep, if you make unarmed atk, +2 AC), Kensai's Shot(bonus, ranged dmg + 1D4)");
            var deftStrokes = new List<string> { "Calligrapher's Supplies", "Painter's Supplies" };
            int index = CLIHelper.PrintChoices("Pick a tool", deftStrokes);
            character.ToolProficiencies.Add(deftStrokes[index]);
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("One with the Blade", "Kensai Weapons are considered magical, Deft Strike(on hit with Kensai Weapon, 1/turn, 1 ki pt, dmg + Martial Arts Die)");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Sharpen the Blade", "bonus, 3 ki pt, 1 min, atk/dmg + 3");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Unerring Accuracy", "1/turn, if miss with monk weapon, reroll atk");
            }
        }
        public static void LongDeath(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Touch of Death", "When you kill a creature, gain temp HP = Wis + lvl");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Hour of Reaping", "action, 30ft, Wis save, fear");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Mastery of Death", "When you drop to 0 HP - expend 1 ki pt, drop to 1 HP instead");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Touch of the Long Death", "action, Con save, expend 1-10 ki pt, 2D10 Necrotic dmg per ki pt");
            }
        }
        public static void Mercy(Character character)
        {
            int lvl = character.Lvl;
            character.SkillProficiencies.Add("Insight");
            character.SkillProficiencies.Add("Medicine");
            character.ToolProficiencies.Add("Herbalism Kit");
            Console.WriteLine("Pick an appearance for your merciful mask");
            var masks = new List<string> { "Raven", "Blank white", "Crying visage", "Laughing visage", "Skull", "Butterfly" };
            character.Equipment.Add(CLIHelper.PrintChoices(masks));
            character.ClassFeatures.Add("Implements of Mercy", "gain prof in Insight, Medicine and Herbalism Kit");
            character.ClassFeatures.Add("Hand of Healing", "action, 1 ki pt, touch, restore HP = Martial Arts die + Wis / forgo an atk to use during Flurry of Blows for 0 ki pt");
            character.ClassFeatures.Add("Hand of Harm", "1/turn, on hit, 1 ki pt, Martial Arts die + Wis Necrotic dmg");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Physician's Touch", "Hand of Healing can also cure disease or remove blind, deaf, paralyze, posion, stun" +
                    "\n        Hand of Harm can inflict poison condition(disadv on atks/ability checks)");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Flurry of Healing and Harm", "replace any atk when using Flurry of Blows with a hand of healing for 0 ki pt, " +
                    "\n         when using Flurry of Blows - add hand of harm for 0 ki pt");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Hand of Ultimate Mercy", "LR, action, 5 ki pt, touch creature that died within 24hr, revives with 4D10 + Wis HP, removes blind, deaf, paralyze, posion, stun");
            }
        }
        public static void OpenHand(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Open Hand Technique", "when use Flurry of Blows, gain one" +
                    "\n        Str save - push 15ft" +
                    "\n        Dex save - knock prone" +
                    "\n        enemy can't take reactions");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Wholeness of Body", "LR, action, heal HP = lvl x 3");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Tranquility", "on LR, gain Sanctuary spell effect, Wis-based DC");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Quivering Palm", "on hit, 3 ki pt, Con save - 0 HP or 10D10 Necrotic dmg");
            }
        }
        public static void Shadow(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Shadow Arts", "action, 2 ki pt, cast - Darkness, Darkvision, Pass Without a Trace, or Silence");
            character.Cantrips.Add("Minor Illusion");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Shadow Step", "bonus, teleport 60ft, adv on next melee atk");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Cloak of Shadows", "action, in dim light or darkness become invisible");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Opportunist", "reaction, when creature is hit by someone else you can melee atk");
            }
        }
        public static void SunSoul(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Radiant Sun Bolt", $"action, 30ft, 1D{MartialArtsDie}(MA die) + Dex Radiant dmg, 1 ki pt to atk again with bonus");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Searing Arc Strike", "after Attack action, 2 ki pt, cast Burning Hands as bonus, spend ki pt to increase spell lvl (max 1/2 lvl - 2)");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Searing Sunburst", "action, 20ft within 150ft, Con save, 2D6 Radiant dmg, spend up to 3 ki pt to increase dmg by 2D6 per ki pt");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Sun Shield", "bonus, 30ft bright light, 30ft dim light, if hit - reaction, 5 + Wis Radiant dmg");
            }
        }
        public static string GetKensaiWeapons(Character character, int lvl)
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
            character.Proficiencies.Add(wep);
            kensaiWep.Add(wep);
            wep = CLIHelper.PrintChoices(kensaiRanged);
            kensaiRanged.Remove(wep);
            paranthesis = wep.IndexOf("(");
            wep = wep.Substring(0, paranthesis);
            character.Proficiencies.Add(wep);
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
                character.Proficiencies.Add(wep);
                kensaiWep.Add(wep);
            }
            return String.Join(", ", kensaiWep);
        }
    }
}
