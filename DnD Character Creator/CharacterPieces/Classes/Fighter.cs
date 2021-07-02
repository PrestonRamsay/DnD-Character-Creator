using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Fighter
    {
        public static string MartialArchetype { get; set; }
        public static void Base(Character character)
        {
            List<string> classSkills = new List<string> { "Acrobatics", "Animal Handling", "Athletics", "History", "Insight",
                "Intimidation", "Perception", "Survival" };

            character.GP += 125;
            character.HitDie = 10;
            character.Proficiencies.Add("Light armor");
            character.Proficiencies.Add("Medium armor");
            character.Proficiencies.Add("Heavy armor");
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
            CLIHelper.Print2Choices("Fullplate", "Leather, longbow, and 20 arrows");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Any martial weapon, and a shield", "Two martial weapons");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Light crossbow and 20 bolts", "Two handaxes");
            int input3 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Dungeoneer's Pack", "Explorer's Pack");
            int input4 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                character.Equipment.Add(Options.HeavyArmor[3]);
            }
            else
            {
                character.Equipment.Add(Options.LightArmor[1]);
                character.Equipment.Add(Options.MartialRangedWeapons[3]);
                character.Equipment.Add("20 arrows");
            }
            if (input2 == 1)
            {
                BEHelper.AddMartialWeapon(character);
                character.Equipment.Add("Shield(+2 AC)(10gp, 6lb.)");
            }
            else
            {
                BEHelper.AddMartialWeapon(character);
                BEHelper.AddMartialWeapon(character);
            }
            if (input3 == 1)
            {
                character.Equipment.Add(Options.SimpleRangedWeapons[0]);
                character.Equipment.Add("20 bolts");
            }
            else
            {
                character.Equipment.Add($"2 {Options.SimpleMeleeWeapons[3]}");
            }
            if (input4 == 1)
            {
                character.Equipment.Add(Options.Packs[2]);
            }
            else
            {
                character.Equipment.Add(Options.Packs[4]);
            }
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;
            string actionSurge = "SR, you can take an additional action ontop of your action and bonus action";
            string indomitable = "LR, reroll a failed saving throw";

            character.ClassFeatures.Add("Second Wind", "bonus, SR, heal 1D10+lvl HP");

            string fightStyleMsg = "Pick a fighting style.";
            List<string> styleList = new List<string>();
            foreach (var style in Options.FightingStyles.Keys)
            {
                if (style != "Blessed Warrior" || style != "Druidic Warrior")
                {
                    styleList.Add(style);
                }
            }
            string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
            string fightStyleKey = $"Fighting Style({fightStyle})";
            string fightStyleValue = Options.FightingStyles[fightStyle];
            if (fightStyle == "Superior Technique")
            {
                List<string> maneuvers = CLIHelper.GetDictionaryOptions(Options.Maneuvers, 1, "Pick a maneuver");
                string man = maneuvers[0];
                fightStyleValue += man;
            }
            character.ClassFeatures.Add(fightStyleKey, fightStyleValue);
            styleList.Remove(fightStyle);

            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Action Surge(1 use)", actionSurge);
            }
            if (lvl >= 3)
            {
                string msg = "Pick a Martial Archetype that will give you features at levels 3, 7, 10, 15, and 18.";
                var archetype = new List<string> { "Arcane Archer", "Battle Master", "Brawler", "Cavalier", "Champion", "Echo Knight",
                    "Eldritch Knight", "Gunslinger", "Psi Warrior", "Purple Dragon Knight", "Rune Knight", "Samurai" };
                int answer = CLIHelper.PrintChoices(msg, archetype);
                MartialArchetype = archetype[answer];

                switch (MartialArchetype)
                {
                    case "Arcane Archer":
                        ArcaneArcher(character);
                        break;
                    case "Battle Master":
                        BattleMaster(character);
                        break;
                    case "Brawler":
                        Brawler(character);
                        break;
                    case "Cavalier":
                        Cavalier(character);
                        break;
                    case "Champion":
                        Champion(character, styleList);
                        break;
                    case "Echo Knight":
                        EchoKnight(character);
                        break;
                    case "Eldritch Knight":
                        EldritchKnight(character);
                        break;
                    case "Gunslinger":
                        Gunslinger(character);
                        break;
                    case "Psi Warrior":
                        PsiWarrior(character);
                        break;
                    case "Purple Dragon Knight":
                        PurpleDragonKnight(character);
                        break;
                    case "Rune Knight":
                        RuneKnight(character);
                        break;
                    case "Samurai":
                        Samurai(character);
                        break;
                }
            }
            if (lvl >= 4)
            {
                character.ClassFeatures.Add("Martial Versatility", "When you gain an Ability Score Improvement, replace a Fighting Style or a Maneuver (if you know one)");
            }
            if (lvl >= 5)
            {
                character.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
            }
            if (lvl >= 9)
            {
                character.ClassFeatures.Add("Indomitable(1 use)", indomitable);
            }
            if (lvl >= 11)
            {
                character.ClassFeatures["Extra Attack"] = "When using an atk action, atk three times";
            }
            if (lvl >= 13)
            {
                character.ClassFeatures.Remove("Indomitable(1 use)");
                character.ClassFeatures.Add("Indomitable(2 uses)", indomitable);
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Remove("Action Surge(1 use)");
                character.ClassFeatures.Add("Action Surge(2 uses)", $"{actionSurge}(1/turn)");
                character.ClassFeatures.Remove("Indomitable(2 uses)");
                character.ClassFeatures.Add("Indomitable(3 uses)", indomitable);
            }
            if (lvl >= 20)
            {
                character.ClassFeatures["Extra Attack"] = "When using an atk action, atk four times";
            }
        }
        public static void ArcaneArcher(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Arcane Archer Lore", "gain prof in Arcana or Nature, gain Prestidigitation or Druidcraft");
            Console.WriteLine("Arcane Archer Lore: gain prof in Arcana or Nature, gain Prestidigitation or Druidcraft");
            var skills = new List<string> { "Arcana", "Nature" };
            var cantrips = new List<string> { "Prestidigitation", "Druidcraft" };
            string skill = CLIHelper.PrintChoices(skills);
            string cantrip = CLIHelper.PrintChoices(cantrips);
            character.SkillProficiencies.Add(skill);
            character.Cantrips.Add(cantrip);

            int options = 2;
            for (int i = 7; i <= lvl; i += 3)
            {
                options++;
                if (i == 10)
                {
                    i += 2;
                }
            }
            List<string> pickedOptions = CLIHelper.GetDictionaryOptions(Options.ArcaneShotOptions, options, "Pick an arcane shot option");
            character.ClassFeatures.Add("Arcane Shot", $"({options} options) 2/SR, 1/turn, part of Attack action, longbow/shortbow, Int-based DC");
            foreach (var item in pickedOptions)
            {
                character.ClassFeatures["Arcane Shot"] += $"\n        {item}({Options.ArcaneShotOptions[item]})";
            }
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Magic Arrow", "all ranged atks are considered magical");
                character.ClassFeatures.Add("Curving Shot", "bonus, 60ft, when you miss an atk, reroll atk vs new target");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Ever-Ready Shot", "on Init, if no Arcane Shot uses, regain 1 use");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Remove("Arcane Shot");
                character.ClassFeatures.Add("Arcane Shot", $"({options} options) 2/SR, 1/turn, part of Attack action, longbow/shortbow, Int-based DC");
                foreach (var item in pickedOptions)
                {
                    character.ClassFeatures["Arcane Shot"] += $"\n        {item}({Options.ArcaneShotOptionsImp[item]})";
                }
            }
        }
        public static void BattleMaster(Character character)
        {
            int lvl = character.Lvl;
            string pickMsg = "Pick a tool proficiency.";
            character.ClassFeatures.Add("Student of War", "gain prof in a tool set");
            string toolProf = CLIHelper.GetNew(Options.ArtisanTools, character.ToolProficiencies, pickMsg);
            character.ToolProficiencies.Add(toolProf);
            int supDice = 4;
            for (int i = 7; i <= lvl; i += 8)
            {
                supDice++;
            }
            int dieCat = 8;
            for (int i = 10; i <= lvl; i += 8)
            {
                dieCat += 2;
            }
            character.ClassFeatures.Add("Combat Superiority", $"Maneuvers - Str or Dex-based DC, Superiority Dice - {supDice}D{dieCat}/SR");
            Console.WriteLine("You get 3 maneuvers now and 2 more at levels 7, 10, and 15.");
            int man = 3;
            for (int i = 7; i <= lvl; i += 3)
            {
                if (lvl <= 15)
                {
                    man++;
                    if (i == 10)
                    {
                        i += 2;
                    }
                }
            }
            var manDict = new Dictionary<string, string>();
            var featMan = new List<string>();
            foreach (var item in Options.Maneuvers.Keys)
            {
                manDict.Add(item, Options.Maneuvers[item]);
            }
            if (character.Feats.ContainsKey("Martial Adept"))
            {
                character.ClassFeatures.Remove("Maneuvers(D6)");
                foreach (var item in Options.Maneuvers.Keys)
                {
                    if (character.ClassFeatures.ContainsKey(item))
                    {
                        character.ClassFeatures.Remove(item);
                        manDict.Remove(item);
                        featMan.Add(item);
                    }
                }
            }
            List<string> maneuvers = CLIHelper.GetDictionaryOptions(Options.Maneuvers, man, "Pick a new maneuver");
            maneuvers.AddRange(featMan);
            foreach (var item in maneuvers)
            {
                character.ClassFeatures["Combat Superiority"] += $"\n        {item}({Options.Maneuvers[item]})";
            }
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Know Your Enemy", "study 1min, DM tells you =/</> in 2 traits: Str, Dex, Con, AC," +
                    "\n        current HP, lvl, fighter lvl(if any)");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Relentless", "on Init, if no superiority dice - regain 1");
            }
        }
        public static void Brawler(Character character)
        {
            int lvl = character.Lvl;
            int dmg = 4;
            for (int i = 5; i <= lvl; i += 6)
            {
                dmg += 2;
            }
            character.ClassFeatures.Add("Pugilist", $"unarmed dmg = 1D{dmg}, melee atk as bonus, op atk dmg + 1D4");
            character.ClassFeatures.Add("Array of Strikes", "PB/LR, 1/turn, on hit, pick a type of attack to gain benefits, Str-based DCs" +
                "\n        Haymaker(Str save, push 15ft)" +
                "\n        Sucker Punch(gain adv on next unarmed atk)" +
                "\n        Thunderclap Strike(Con save, disadv on atk for 1 turn)" +
                "\n        Uppercut(Str save, knock prone)");
            character.ClassFeatures.Add("Fast Footwork", "bonus, take Dash, Disengage, or Dodge action");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Iron Fists", "unarmed atks count as magical / when you crit, dmg + Pugilist unarmed die");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Knockout Punch", "SR, action, creature Large or smaller, Str-based DC Con save, knock unconscious until successful save");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Hand to Hand Mastery", "unarmed dmg + 1/2 PB, unarmed atks crit on 19 and 20");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Stonejaw", "gain Resistance to Bludgeoning, reduce all dmg by 3");
            }
        }
        public static void Cavalier(Character character)
        {
            int lvl = character.Lvl;
            string pickLang = "Pick a language";
            CLIHelper.Print2Choices("Pick a skill", pickLang);
            int choice = CLIHelper.GetNumberInRange(1, 2);
            if (choice == 1)
            {
                var skills = new List<string> { "Animal Handling", "History", "Insight", "Performance", "Persuasion" };
                string skill = CLIHelper.GetNew(skills, character.SkillProficiencies, "Pick a skill");
                character.SkillProficiencies.Add(skill);
            }
            else if (choice == 2)
            {
                string lang = CLIHelper.GetNew(Options.Languages, character.Languages, pickLang);
                character.Languages.Add(lang);
            }

            character.ClassFeatures.Add("Born to the Saddle", "adv on saves to avoid falling off mount, if you fall less than 10ft - land on your feet, no incap" +
                "\n        mounting and dismounting only cost 5ft of movement instead of half your speed");
            character.ClassFeatures.Add("Unwavering Mark", "on hit, mark creature, disadv on atks vs allies, if atk ally - Str/LR, bonus melee atk, with adv, dmg + 1/2 lvl");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Warding Maneuver", "Con/LR, reaction, if you or adj ally are hit, AC + 1D8, if atk still hit - gain Resistance");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Hold the Line", "if enemy moves in reach, atk op, if hit - reduce speed to 0");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Ferocious Charger", "if move 10ft and hit, Str save, knock prone");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Vigilant Defender", "reaction, 1/turn (not your turn), make atk op within reach");
            }
        }
        public static void Champion(Character character, List<string> styleList)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Improved Critical", "crit on 19-20");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Remarkable Athlete", "add 1/2 PB to Str/Dex/Con checks that you don't have prof in." +
                    "\n        Increase your running long jump distance by Str mod ft");
            }
            if (lvl >= 10)
            {
                string fightStyleMsg = "Pick a fighting style.";
                string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                string fightStyleKey = $"Fighting Style({fightStyle})";
                string fightStyleValue = Options.FightingStyles[fightStyle];
                if (fightStyle == "Superior Technique")
                {
                    List<string> maneuvers = CLIHelper.GetDictionaryOptions(Options.Maneuvers, 1, "Pick a maneuver");
                    string newMan = maneuvers[0];
                    fightStyleValue += newMan;
                }
                character.ClassFeatures.Add(fightStyleKey, fightStyleValue);
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Remove("Improved Critical");
                character.ClassFeatures.Add("Superior Critical", "crit on 18-20");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Survivor", "when bloodied, gain regen = 5 + Con mod");
            }
        }
        public static void EchoKnight(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Manifest Echo", "bonus, echo stats(AC = 14 + PB, 1 HP, uses your saves, Immunity to all conditions), no action - move echo 30ft" +
                "\n        bonus, range = any, teleport/swap places with echo for 15ft movement / atks can originate from echo / reaction, make an atk op with echo");
            character.ClassFeatures.Add("Unleash Incarnation", "Con/LR, when you use Attack action, make an extra atk with echo");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Echo Avatar", "action, 10 min, see and hear through echo - causes blindness/deafness, echo can move up to 1000ft away from you");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Shadow Martyr", "SR, reaction, sight, atk is made, teleport echo adj to you or ally - atk is redirected to echo");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Reclaim Potential", "Con/LR, when echo is destroyed by taking dmg, gain temp HP = 2D6 + Con");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Legion of One", "bonus, create 2 echoes with Manifest Echo / on Init, if no uses of Unleash Incarnation - gain 1 use");
            }
        }
        public static void EldritchKnight(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Weapon Bond", "1hr ritual to bond, can't be disarmed, bonus to teleport to hand, " +
                "\n        can bond with 2 weapons(can only summon 1 at a time)");
            character.ClassFeatures.Add("Spellcasting", "use Int for spell DCs, you use a component pouch to cast spells");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("War Magic", "after casting cantrip, bonus, make wep atk");

            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Eldritch Strike", "on wep hit, impose disadv on next save vs spell");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Arcane Charge", "teleport 30ft before/after Action Surge");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Remove("War Magic");
                character.ClassFeatures.Add("Improved War Magic", "after casting spell, bonus, make wep atk");
            }
            Spells(character);
        }
        public static void Gunslinger(Character character)
        {
            int lvl = character.Lvl;
            int gun = CLIHelper.PrintChoices("Pick a firearm to add to your inventory", Options.Firearms);
            character.Equipment.Add(Options.Firearms[gun]);
            character.Proficiencies.Add("Firearms");
            character.ToolProficiencies.Add("Tinker's Tools");
            character.ClassFeatures.Add("Gunsmith", "use Tinker's Tools to craft ammo, repair firearms, or craft new ones(DM's discretion)");
            character.ClassFeatures.Add("Grit", "grit pts = Wis, regain pts by getting a crit or a kill with a firearm");
            character.ClassFeatures.Add("Deadeye Shot", "1 grit pt, gain adv on next atk");
            character.ClassFeatures.Add("Firearm properties", "Reload(requires action), Misfire(action to repair - DC 8 + misfire score)" +
                "\nScatter(range = 30ft cone, if adj - dmg x 2), Explosive(all adj, Dex save - 1/2 dmg)");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Quickdraw", "Init + 2, draw/stow firearms freely");
                character.ClassFeatures.Add("Violent Shot", "# grit pts, atk + (# x 2), dmg + # wep dice");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Trick Shot", "1 grit pt, pick a body part, Dex-based DC - Head(Con save, suffer disadv on atk for 1 turn), Arms(Str save, drops 1 held item)" +
                    "\nTorso(push 10ft), Legs(Str save, knock prone), Wings(Con save, plummet 20ft)");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Lightning Reload", "bonus, reload any firearm");
                character.ClassFeatures.Add("Piercing Shot", "1 grit pt, on hit, 1st range increment, all creatures directly behind target, make an atk with disadv");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Vicious Intent", "firearm atks crit on 19-20");
                character.ClassFeatures.Add("Hemoragging Critical", "when you crit, deal extra 1/2 dmg at start of enemy's turn");
            }
        }
        public static void PsiWarrior(Character character)
        {
            int lvl = character.Lvl;
            int energy = 6;
            for (int i = 5; i <= lvl; i += 6)
            {
                energy += 2;
            }
            character.ClassFeatures.Add("Psionic Power", $"PB x 2/LR, gain Psionic Energy dice(D{energy}) / SR, bonus, regain 1 Psionic Energy die" +
                $"\n        Protective Field(reaction, 30ft, when creature takes dmg, reduce dmg by Psionice Energy die + Int)" +
                $"\n        Psionic Strike(1/turn, on weapon hit, 30ft, Psionce Enerdy die + Int Force dmg)" +
                $"\n        Telekinetic Movement(LR or Psionice Energy die, action, 30ft, move Large or smaller object or ally 30ft, if Tiny move to/from hand)");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Telekinetic Adept", $"Psi-Powered Leap(SR, bonus, 1 turn, gain Fly {character.Speed * 2}ft)" +
                    $"\n        Telekinetic Thrust(when you deal dmg with Psionic Strike, Str save(Int-based DC), knock prone or slide 10ft)");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Guarded Mind", "gain Resistance to Psychic, expend Psionic Energy die to end charm/fear on self");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Bulwark of Force", "LR or Psionice Energy die, bonus, 1 min, 30ft, Int creatures, half cover(+2 AC, Dex saves)");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Telekinetic Master", "LR or Psionice Energy die, cast Telekinesis, while conc and turn cast - bonus, make wep atk");
            }
        }
        public static void PurpleDragonKnight(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Banneret", "Knighthood given on battle for courage, troop commander status");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Rallying Cry", "When you use Second Wind, 60ft, 3 allies, regain HP = lvl");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Royal Envoy", "gain a skill and double your PB for Persuasion");
                if (character.SkillProficiencies.Contains("Persuasion"))
                {
                    var skills = new List<string> { "Animal Handling", "Insight", "Intimidation", "Performance" };
                    Console.WriteLine("Pick a skill");
                    string skill = CLIHelper.PrintChoices(skills);
                    character.SkillProficiencies.Add(skill);
                }
                else
                {
                    character.SkillProficiencies.Add("Persuasion");
                }
                character.Skills["Persuasion"] += character.ProficiencyBonus;
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Inspiring Surge", "When you use Action Surge, 60ft, 1 ally, make a melee or ranged atk as a reaction");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures["Inspiring Surge"] = "When you use Action Surge, 60ft, 2 allies, make a melee or ranged atk as a reaction";
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Bulwark", "When you use Indomitable on Int, Wis, or Cha save - 60ft, if ally fails they can reroll");
            }
        }
        public static void RuneKnight(Character character)
        {
            int lvl = character.Lvl;
            character.Languages.Add("Giant");
            character.ToolProficiencies.Add("Smith's Tools");
            int runes = 2;
            for (int i = 7; i <= lvl; i += 3)
            {
                runes++;
                if (i == 10)
                {
                    i += 2;
                }
            }
            int giantDmg = 6;
            if (lvl >= 10)
            {
                giantDmg = 8;
            }
            if (lvl >= 18)
            {
                giantDmg = 10;
            }
            character.ClassFeatures.Add("Giant's Might", $"PB/LR, bonus, 1 min, become Large, gain adv on Str checks/saves, 1/turn dmg + 1D{giantDmg}");
            character.ClassFeatures.Add("Rune Carver", $"on LR, touch {runes} objects to imbue with a Rune, each object can only have 1 rune, Con-based DC" +
                "\n        Cloud Rune(gain adv on Deception and Sleight of Hand / SR, reaction, 30ft, creature is hit, transfer atk to new target)" +
                "\n        Fire Rune(PB for Tools x 2 / SR, on hit, dmg + 2D6 Fire, Str save, 1 min, restrain with shackles)" +
                "\n        Frost Rune(gain adv on Animal Handling and Intimidation / SR, bonus, 10 min, all Str and Con checks + 2)" +
                "\n        Stone Rune(gain adv on Insight and Darkvision 120ft / SR, reaction, 1 min, 30ft, Wis save, charm - incap and speed = 0)");
            if (lvl >= 7)
            {
                character.ClassFeatures["Rune Carver"] += "\n        Hill Rune(gain adv on saves vs poison(condition) and Resistance to Poison dmg / SR, bonus, 1 min, gain Resistance to B/P/S)" +
                "\n        Storm Rune(gain adv on Arcana, can't be surprised / SR, bonus, 1 min - reaction, 60ft, 1 creature, give atk, save, check adv or disadv)";
                character.ClassFeatures.Add("Runic Shield", "PB/LR, reaction, 60ft, when ally is hit, force atk reroll");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Great Stature", "height + 3D4 inches");

            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Master of Runes", "you can use each rune from your Rune Carver feature twice/SR");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Runic Juggernaut", "you can increase your size to Huge when you use Giant's Might, if you do - gain reach 5ft");
            }
        }
        public static void Samurai(Character character)
        {
            int lvl = character.Lvl;
            string pickLang = "Pick a language";
            CLIHelper.Print2Choices("Pick a skill", pickLang);
            int choice = CLIHelper.GetNumberInRange(1, 2);
            if (choice == 1)
            {
                var skills = new List<string> { "History", "Insight", "Performance", "Persuasion" };
                string skill = CLIHelper.GetNew(skills, character.SkillProficiencies, "Pick a skill");
                character.SkillProficiencies.Add(skill);
            }
            else if (choice == 2)
            {
                string lang = CLIHelper.GetNew(Options.Languages, character.Languages, pickLang);
                character.Languages.Add(lang);
            }
            int tempHP = 5;
            for (int i = 10; i < lvl; i += 5)
            {
                if (i != 20)
                {
                    tempHP += 5;
                }
            }
            character.ClassFeatures.Add("Fighting Spirit", $"3/LR, bonus, gain adv on atks and {tempHP} temp HP");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Elegant Courier", "Persuasion + Wis, gain prof in Wis saves (if already have gain Int or Cha instead)");
                character.Saves.Add("Wis");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Tireless Spirit", "on Init, if no uses of Fighting Spirit regain 1 use");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Rapid Strike", "1/turn, if an atk has adv, forgo the adv to gain an extra wep atk");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Strength before Death", "LR, if drop to 0 HP, don't fall unconscious for 1 turn, reaction - immediately take a turn");
            }
        }
        public static void Spells(Character character)
        {
            AllSpells spells = new AllSpells(character);
            character.Cantrips.AddRange(character.Cantrips);
            character.CantripsKnown = 2;
            character.SpellsKnown = 3;
            int slotLvl = 1;
            character.SpellSlots[1] += 2;
            string pickSpell = "Pick a spell.";
            string cantrip = "";
            string spell = "";

            for (int i = 0; i < 2; i++)
            {
                cantrip = CLIHelper.GetNew(spells.Wizard[0], character.Cantrips, pickSpell);
                character.Cantrips.Add(cantrip);
                spells.Wizard[0].Remove(cantrip);
            }
            for (int i = 0; i < 2; i++)
            {
                spell = CLIHelper.GetNew(spells.Fighter[1], character.Spells[1], pickSpell);
                character.Spells[1].Add(spell);
                spells.Fighter[1].Remove(spell);
            }
            spell = CLIHelper.GetNew(spells.Wizard[1], character.Spells[1], pickSpell);
            character.Spells[1].Add(spell);
            spells.Fighter[1].Remove(spell);

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
                    cantrip = CLIHelper.GetNew(spells.Wizard[0], character.Cantrips, pickSpell);
                    character.Cantrips.Add(cantrip);
                    spells.Wizard[0].Remove(cantrip);
                    character.SpellsKnown++;
                    spell = CLIHelper.GetNew(spells.Fighter[slotLvl], character.Spells[slotLvl], pickSpell);
                    character.Spells[slotLvl].Add(spell);
                    spells.Fighter[slotLvl].Remove(spell);
                }
                if (i == 8 || i == 14 || i == 20)
                {
                    character.SpellsKnown++;
                    spell = CLIHelper.GetNew(spells.Wizard[slotLvl], character.Spells[slotLvl], pickSpell);
                    character.Spells[slotLvl].Add(spell);
                    spells.Wizard[slotLvl].Remove(spell);
                }
                if (i == 4 || i == 7 || i == 11 || i == 13 || i == 16 || i == 19)
                {
                    character.SpellsKnown++;
                    spell = CLIHelper.GetNew(spells.Fighter[slotLvl], character.Spells[slotLvl], pickSpell);
                    character.Spells[slotLvl].Add(spell);
                    spells.Fighter[slotLvl].Remove(spell);
                }
            }
        }
    }
}
