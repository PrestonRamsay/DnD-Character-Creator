﻿using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Races
{
    public class Template
    {
        public Tuple<string, int> Stat1 { get; set; }
        public Tuple<string, int> Stat2 { get; set; }
        public static Template NewTemplate(string template, Character character)
        {
            var result = new Template();

            switch (template)
            {
                case "Aberrant Horror":
                    AberrantHorror(character);
                    break;
                case "Fiend":
                    Fiend(character);
                    break;
                case "Lich":
                    Lich(character);
                    break;
                case "Lycanthrope":
                    Lycanthrope(character);
                    break;
                case "Seraph":
                    Seraph(character);
                    break;
                case "Vampire":
                    Vampire(character);
                    break;
            }

            return result;
        }
        public static Template GetStats(string template)
        {
            var result = new Template();

            switch (template)
            {
                case "Aberrant Horror":
                    result.Stat1 = new Tuple<string, int>("Con", 2);
                    result.Stat2 = new Tuple<string, int>("Str", 1);
                    break;
                case "Fiend":
                    result.Stat1 = new Tuple<string, int>("Cha", 2);
                    result.Stat2 = new Tuple<string, int>("Int", 1);
                    break;
                case "Lich":
                    result.Stat1 = new Tuple<string, int>("Int", 4);
                    result.Stat2 = new Tuple<string, int>("Wis", 2);
                    break;
                case "Lycanthrope":
                    result.Stat1 = new Tuple<string, int>("Str", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "Seraph":
                    result.Stat1 = new Tuple<string, int>("Wis", 2);
                    result.Stat2 = new Tuple<string, int>("Con", 1);
                    break;
                case "Vampire":
                    result.Stat1 = new Tuple<string, int>("Dex", 2);
                    result.Stat2 = new Tuple<string, int>("Cha", 1);
                    break;
            }

            return result;
        }
        public static void AberrantHorror(Character character)
        {
            character.TemplateProgression.Add("Defeating a powerful Aberration and absorbing its power.");
            character.TemplateProgression.Add("Undergoing a dangerous and costly experiment.");
            character.TemplateProgression.Add("Surviving a magical mishap.");
            character.TemplateProgression.Add("Acquiring the strength to give birth to a more powerful version of yourself, which then consumes your old self.");
            character.TemplateProgression.Add("Fulfilling an eldritch prophecy written in the stars.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                character.Boons.Add("Aberrant Adaptations", "\n        Chitinous Shell(bonus, 1 min, +2 AC, speed -10ft)" +
                    "\n        Eldritch Limbs(when atk, unarmed atks becomes 1D6 dmg of choice, can't hold anything in that hand)");
                character.Boons.Add("Aberrant Form", "your type becomes Aberration");
                character.Flaws.Add("Unstable Mutations", "after LR roll D% for Unstable Form, if same as previous reroll");
            }
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Efficient Killer", "Otherworldy Tendrils", "Situational Evolution" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "Bludgeoning(unarm dmg + 1D6, same atk roll vs adj to do 1D6 + Str dmg)" +
                            $"\n        Piercing(ranged atk, 30ft, 2D6 + Str dmg), Slashing(unarm dmg + 1D6, Con save - 1 min, bleeding: no healing)");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "bonus to grow, bonus to use, 10ft, unarm atk, 1D4 + Str" +
                            $"\n        Toxic Spray(Con save - poisoned, disadv on atks/ability checks), Constrict(no dmg, grapple check = atk roll)" +
                            $"\n        Hypnotic Trance(Wis save - adv on atks on vs target)");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "action to change Adaptation" +
                            $"\n        Scopulae(climb as move speed), Gills/Flippers(swim as move speed)" +
                            $"\n        Regenerative Tissues(regen Con HP, negate if take Fire/Acid dmg)");
                        break;
                }
                character.Flaws.Add("Hideous Appearance", "true form revealed if (use conc spell, unconscious, hallowed ground, or DM Con save)" +
                    "\n        Non-evil creatures who see your true form instantly become hostile unless GM decides overwise");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Wings", "Additional Tendrils", "Enhanced Hypertrophy" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "SR, bonus, 10 min, gain fly = move speed");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "bonus, atk per tendril (2 or 3 if lvl 4)");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "unarm dmg = D8, or +1 base die (D6 = D8, etc)");
                        break;
                }
                character.Flaws.Add("Unstable Existence", "reveal Hideous Appearance on rolls of 1, 2, or 3 on saves vs magic");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Savage Predator", "Master of the Deep", "Extremophilic Conditioning" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "on nat 20, dmg + 6D6 and 30ft, Wis save - 1 min, fear");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "SR, action, 15ft, Dex save - 1 min, Poison, disadv on atks/ability checks" +
                            $"\n        speed = 0, adv on atks vs target");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "Metamorphosis(action to switch benefits)" +
                            $"\n        -Resist B/P/S and fall dmg = 1 per 10ft, max 20" +
                            $"\n        -Resist Fire, Lightning, Acid and immune to hot climates" +
                            $"\n        -Resist Cold, Thunder, Poison and immune to cold climates");
                        break;
                }
                character.Flaws.Add("Entropic Abomination", "on failed save vs magic, roll Unstable Mutation - if lower than current replace it");
            }
        }
        public static void Fiend(Character character)
        {
            character.TemplateProgression.Add("Defeating a greater rival Fiend and taking their place in the hierarchy.");
            character.TemplateProgression.Add("Ensnaring a particularly powerful or influential soul with a contract.");
            character.TemplateProgression.Add("Establishing a cult of worshipers who offer their strength to you.");
            character.TemplateProgression.Add("Establishing a portal between the material plane and the Netherworld.");
            character.TemplateProgression.Add("Killing or corrupting a Seraph.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                int cost = 50 * lvl;
                character.Boons.Add($"Gifts of Damnation", "each contract requires magical ink and paper worth {cost}gp");
                character.Boons.Add("Fiendish Form", "your type becomes Fiend");
                character.Flaws.Add("Planar Binding", "disadv on death saves, on death GM takes control of the character");
            }
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Brand of the Chainer's Gaze", "Brand of the Tyrant's Hellfire", "Brand of the Deceiver's Guile" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "Cha/LR, bonus, 60ft, Int save, 1 min, target atks - 1D6");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "Cha/LR, bonus, 60ft, Cha save, 1 min, on hit +1D6 Fire dmg");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "Cha/LR, bonus, 60ft, Int save, 1 min, target atks - 1D6");
                        break;
                }
                character.Flaws.Add("Hideous Appearance", "true form revealed if (use conc spell, unconscious, hallowed ground, or DM Con save)" +
                    "\n        Non-evil creatures who see your true form instantly become hostile unless GM decides overwise");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Alluring Deceit", "Infernal Resistance", "Nether Blade" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "gain prof in Deception and Persuasion or double your PB if already prof" +
                            $"\n        Magic always identifies you as telling the truth and you can't be compelled to tell the truth");
                        if (character.SkillProficiencies.Contains("Deception"))
                        {
                            Console.WriteLine("You already have proficiency in Deception, so double your PB is added");
                            character.Skills["Deception"] += character.ProficiencyBonus;
                        }
                        else
                        {
                            character.SkillProficiencies.Add("Deception");
                        }
                        if (character.SkillProficiencies.Contains("Persuasion"))
                        {
                            Console.WriteLine("You already have proficiency in Persuasion, so double your PB is added");
                            character.Skills["Deception"] += character.ProficiencyBonus;
                        }
                        else
                        {
                            character.SkillProficiencies.Add("Persuasion");
                        }

                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "reaction, if you take magical dmg - half the dmg");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "bonus to summon, +2D6 Fire dmg, bright light 5ft/dim light 5ft, can't be disarmed");
                        break;
                }
                character.Flaws.Add("True Name", "you are reborn - choose new name, receive a brass/brimstone talisman with your name on it" +
                    "\n        A creature that knows your true name - action, 10ft, Wis save - charm 8hr, must obey commands");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Commanding Obedience", "Brimstone Pyrolysis", "Infernal Summoning" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "30ft, on a fail vs non-cantrip spell - must take turn to kneel (become prone)");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "kill with Fire, turn into statue - action, 10ft, Dex save, detonate statue 3D6 Fire");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "LR, action, summon 4 Imps, no action to issue commands");
                        break;
                }
                character.Flaws.Add("Pull of the Netherworld", "when roll 1 on save vs magic, take 1D6 per 2 lvls (lvl 8 = 4D6)");
            }
        }
        public static void Lich(Character character)
        {
            character.TemplateProgression.Add("Discover ancient and dark arcane knowledge.");
            character.TemplateProgression.Add("Consume the soul of an exceptionally powerful spellcaster.");
            character.TemplateProgression.Add("Build a monument to your power to serve as a giant arcane focus.");
            character.TemplateProgression.Add("Create an army of undead.");
            character.TemplateProgression.Add("Kill a god.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                character.Boons.Add("Harvester of Souls", "when kill, phylactery charge lvl = CR (max 27, below 1/4 is too low)" +
                    "\n        action, expend charge lvls to regain spell slot = 1/3 of charges consumed");
                character.Boons.Add("Undead Form", "your type becomes Undead, you don't require air, food, drink, or sleep" +
                    "\n        healing gives you temp HP instead of real HP, you no longer age/immune to aging effects");
                character.Flaws.Add("Phylactery", "AC 18, HP 90, immune to Poison, Psychic, and nonmagical B/P/S" +
                    "\n        Resistant to Necrotic, Cold, Thunder, Lightning, Force, Fire" +
                    "\n        If phylactery is destroyed you die instantly, if you die and it has charges - your body is reconstructed in 7 days");
            }
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Puppet Master", "Lichdom of the Arcane", "Rift of the dreadscapes" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "reanimated Undead CR 1- are permanently under your control, no one else can take control");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "when you kill with a spell, gain an additional effect" +
                            $"\n        Fire(create smoke that heavily obscures adj creatures)" +
                            $"\n        Necrotic(regain Int + lvl HP)" +
                            $"\n        Poison(10ft, Con save, 1 min, poisoned - disadv on atks/ability checks)");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "LR, action, 5ft, 20ft radius, 1 min, Con save, 10D10 Necrotic dmg, Undead are immune");
                        break;
                }
                character.Flaws.Add("Hideous Appearance", "true form revealed if (use conc spell, unconscious, hallowed ground, or DM Con save)" +
                    "\n        Non-evil creatures who see your true form instantly become hostile unless GM decides overwise");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Relentless Undead", "Arcane Supremacy", "Staff of Dreadscapes" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "when one of your undead would die, it can move its speed and makes an atk");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "LR, cast 2 conc spells for 1 lvl of exhaustion");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "ignore Necrotic Resistance, DCs + 2, food/non-creature plants wither on touch");
                        break;
                }
                character.Flaws.Add("Necromatic Dystrophy", "everyday must absorb 4 CR of charges or you can't" +
                    "\n        use Dash, Dodge, Disengage, or reactions / can't hide your Hideous Appearance");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Lord of Undeath", "Arcane Omniscience", "Deathly Being" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "whenever you kill a humanoid you can reanimate it as a zombie" +
                            $"\n        its permanently under your control and follows verbal commands");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "gain access to the Wizard's spell list, gain Int spells known");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "gain Immunity to Poison, nonmagical B/P/S, charm, fear, paralysis");
                        break;
                }
                character.Flaws.Add("Weight of Ages", "everyday must absorb 8 CR of charges or you can't use atk actions" +
                    "\n        if you move you can't use bonus actions or reactions / if you use bonus, speed = 0");
            }
        }
        public static void Lycanthrope(Character character)
        {
            character.TemplateProgression.Add("Establishing a pack of other Lycanthropes.");
            character.TemplateProgression.Add("Killing an Alpha Lycanthrope.");
            character.TemplateProgression.Add("Gaining control of your animalistic urges.");
            character.TemplateProgression.Add("Unleashing the beast within and losing your humanity.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                character.Boons.Add("Hybrid Transformation", "AC = 10 + Dex + Con, Claw(D6 slash), Bite(D8 pierc), bonus - claw or bite");
                character.Boons.Add("Shapechanger's Form", "your type becomes Shapechanger");
                character.Flaws.Add("Lust for the Hunt", "DC 10 Wis save every turn, full moon = auto-fail" +
                    "\n        if you lose control - must atk nearest non-player creature");
            }
            bool kindredForm = false;
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Iron Pelt", "Hunter's Howl", "Kindred Form" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "gain Resistance to nonsilvered, nonmagical B/P/S");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "Str/SR, bonus, 60ft, mark a creature - melee + 1D6 dmg, adv on Perception and Survival");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "gain an Animal form, can only use claw and bite, auto-succeed on Lust for the Hunt" +
                            $"\n        Wolf(speak with wolves, if adj ally gain adv on atks, speed + 20ft)" +
                            $"\n        Bear(speak with bears, saves + Con, +15 HP)");
                        kindredForm = true;
                        break;
                }
                character.Flaws.Add("Silver Sensitivity", "while in Hybird or Animal form, gain Vulnerability to silver, can't gain Resistance to it");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Titanic Vigor", "Predatory Leap", "Beastial Savagery" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "+2 HP/lvl (already calculated), gain 5 temp HP per turn while in Hybrid form");
                        character.HP += character.Lvl * 2;
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "double your jump distance, if in Hybrid form after a jump - atk then Str save to " +
                            $"\n        knock prone and then you can grapple check");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "claw and bite are magical and +1 base die, +1 AC, gain Immunity to charm and fear");
                        break;
                }
                character.Flaws.Add("Fraying Memories", "two personalities, disadv on skills and Int checks to recall info or knowledge");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Savage Instincts", "Unstoppable Rage" };
                if (kindredForm)
                {
                    boons.Add("Kindred Affinity");
                }
                int index = CLIHelper.PrintChoices(pickMsg, boons);
                string boon = boons[index];

                switch (boon)
                {
                    case "Savage Instincts":
                        character.Boons.Add($"{boon}", "if a creature isn't at max HP, claw and bite +1 base die");
                        break;
                    case "Kindred Affinity":
                        character.Boons.Add($"{boon}", "in Kindred form, you can speak, cast spells, and allies within 20ft gain adv on Wis saves");
                        break;
                    case "Unstoppable Rage":
                        character.Boons.Add($"{boon}", "you remain conscious when you're dropped to 0 HP, death saves occur normally");
                        break;
                }
                character.Flaws.Add("Predatory Nature", "if you can sense a helpless creature you gain disadv on Wis saves" +
                    "\n        if you sense a hostile/helpless nonplayer creature, DC 10 Wis save or turn into Hybrid form, success = immune until dawn" +
                    "\n        after a kill, you can't transform into human until dawn (you can transform into Kindred form)");
            }
        }
        public static void Seraph(Character character)
        {
            character.TemplateProgression.Add("Defeating a powerful force of darkness.");
            character.TemplateProgression.Add("Create a hallowed landmark for pilgrims.");
            character.TemplateProgression.Add("Establish a parish of worshipers who uphold your virtue.");
            character.TemplateProgression.Add("Establish a portal between the Material Plane and the Empyrium.");
            character.TemplateProgression.Add("Redeem a soul that was considered beyond redemption.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                character.Boons.Add("Celestial Form", "your type becomes Celestial");
                character.Boons.Add("Angelic Wings", "you have a fly speed = move speed");
                character.Flaws.Add("Planar Binding", "disadv on death saves, on death GM takes control of the character");
            }
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Divine Retribution", "Divine Clemency", "Divine Expedition" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "Wis/LR, reaction, 30ft, you or ally bonus, dmg + 1D8 Radiant");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "Wis/LR, reaction, 60ft, when dmg is taken, cast a non-cantrip healing spell");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "Wis/LR, reaction, 60ft, you or ally extra move action with no atk ops");
                        break;
                }
                character.Flaws.Add("Divine Appearance", "true form revealed if (use conc spell, unconscious, hallowed ground, or DM Con save)" +
                    "\n        Evil creatures who see your true form instantly become hostile unless GM decides overwise");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Radiant Strike", "Cleanse Affliction", "Bow of Celestial Judgment" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "melee dmg + 1D6 Radiant or 2D6 if Fiend, Fey, or Undead");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "when you cast a heal spell, also remove any condition caused by a spell or ability");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "bonus to summon longbow, doesn't require ammo, bright light 5ft/dim light 5ft" +
                            $"\n        dmg + 1D8 Radiant or 2D8 if Fiend, Fey, or Undead");
                        break;
                }
                character.Flaws.Add("Beacon to Darkness", "when an act of greater evil is committed within 30ft - gain 1 corruption pt" +
                    "\n        atks/saves vs evil take minus = corruption pts (SR/LR and 1hr prayer reduces pts by 1)");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Aura of Holy Purge", "Aura of Merciful Blessing", "Aura of Empyreal Valor" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "you or ally, 20ft, make hit a crit, LR to benefit from it again");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "you or ally, 20ft, 0HP = 1HP, LR to benefit from it again");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "20ft, +5 Init, adv on atks vs creatures who haven't gone, LR to benefit from it again");
                        break;
                }
                character.Flaws.Add("Pull of the Empyrean", "when roll 1 on save vs magic, take 1D6 per 2 lvls (lvl 8 = 4D6)");
            }
        }
        public static void Vampire(Character character)
        {
            character.TemplateProgression.Add("Establish a coven of vampire spawn.");
            character.TemplateProgression.Add("Drink the blood of a legendary monster.");
            character.TemplateProgression.Add("Learn the great secrets of vampirism from a Vampire Lord.");
            character.TemplateProgression.Add("Learn to embrace your Hideous Form and lose the ability to conceal it.");
            character.TemplateProgression.Add("Discover the lost crypts of an ancient vampire and consume its essence.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                character.Boons.Add("Blood Fury Abilities", "every atk gain 1 FP (max 4), after a SR/LR they reset to 0" +
                    "\n        (1 FP)Fanged Bite - unarmed Dex atk, bonus, 1D4 + Str or Dex, Con save - 2D6 Necrotic, on kill - gain 3 FP" +
                    "\n        (1 FP)Calculated Strike - dmg + 1D6, gain no FP from this atk" +
                    "\n        (2 FP)Vampiric Mist - bonus, teleport 30ft" +
                    "\n        (1 FP)Unearthly Reflexes - reaction, on Dex save, half or no dmg" +
                    "\n        (3 FP)Deathly Horror - bonus, 30ft, Wis save, fear 1 min");
                character.Boons.Add("Undead Form", "your type becomes Undead, you don't require air, food, drink, or sleep" +
                    "\n        healing gives you temp HP instead of real HP, you no longer age/immune to aging effects");
                character.Flaws.Add("The Curse Sanguine", "residence(1D10 Psychic), Darkvision 60ft," +
                    "\n        sunlight = disadv on atks/ability checks, must feed every week");
            }
            bool dreadKnightCmb = false;
            if (lvl >= 2)
            {
                Console.WriteLine("You must be able to cast spells you get the Sanguine Magic boon");
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Dread Knight Combat Training", "Sanguine Magic", "Shapechanger" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "bonus to enter or exit a stance, use Dex for atk/dmg with Slashing weapon" +
                            $"\n        Offensive(dmg + current FP), Defensive(AC + 1/2 current FP), Accuracy(atk + 1/2 current FP)");
                        dreadKnightCmb = true;
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "change dmg type of spells to Necrotic, spells grant FP");
                        character.Boons["Blood Fury Abilities"] += "\n        (1 FP)Cast in Blood - cantrip dmg + Cha" +
                            "\n        (3 FP)Sanguine Spellbinding - impose disadv on Int, Wis, Cha saves vs your spells";
                        break;
                    case 2:
                        character.Boons.Add($"{boons[2]}", "action, turn into bat(fly 30ft) or mist(fly 20ft, adv on physical saves, gain Immunity to nonmagical dmg)");
                        break;
                }
                character.Flaws.Add("Hideous Appearance", "true form revealed if (use conc spell, unconscious, hallowed ground, or DM Con save)" +
                    "\n        Non-evil creatures who see your true form instantly become hostile unless GM decides overwise");
            }
            bool captivatingGlance = false;
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Cruel Riposte", "Creatures of the Night", "Captivating Glance" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        character.Boons.Add($"{boons[0]}", "Dex/LR, reaction, when you are attacked make an atk");
                        break;
                    case 1:
                        character.Boons.Add($"{boons[1]}", "LR, 1 hr, call 2D4 swarms of bats/rats or wolves, arrive within 30ft end of next turn");
                        break;
                    case 2:
                        character.Boons.Add($"{boons[0]}", "gain prof in Deception and Persuasion or +2 if already prof, gain Immunity to mind-reading");
                        captivatingGlance = true;
                        if (character.SkillProficiencies.Contains("Deception"))
                        {
                            Console.WriteLine("You already have proficiency in Deception, so you get a +2");
                            character.Skills["Deception"] += 2;
                        }
                        else
                        {
                            character.SkillProficiencies.Add("Deception");
                        }
                        if (character.SkillProficiencies.Contains("Persuasion"))
                        {
                            Console.WriteLine("You already have proficiency in Persuasion, so you get a +2");
                            character.Skills["Deception"] += 2;
                        }
                        else
                        {
                            character.SkillProficiencies.Add("Persuasion");
                        }
                        break;
                }
                character.Flaws.Add("Greater Sanguine Curse", "1d10 Acid dmg in running water, gain Superior Darkvision 120ft," +
                    "\n        1d10 Radiant dmg in sunlight, must feed every 3 days");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Regenerate" };
                
                if (dreadKnightCmb)
                {
                    boons.Add("Grim Executioner");
                }
                if (captivatingGlance)
                {
                    boons.Add("Beguiler's Entrancement");
                }
                int index = CLIHelper.PrintChoices(pickMsg, boons);
                string boon = boons[index];

                switch (boon)
                {
                    case "Grim Executioner":
                        character.Boons.Add($"{boon}", "on a crit, if target HP <= 50 then kill, if HP = 51+ then deal 6D6 dmg");
                        break;
                    case "Beguiler's Entrancement":
                        character.Boons.Add($"{boon}", "LR, action, charm incap human for 24hrs, after a month become permanently charmed" +
                            "\n        max # of enthralled = Cha, perma-charm can be removed by Remove Curse, other spells, etc");
                        break;
                    case "Regenerate":
                        character.Boons.Add($"{boon}", "Gain regen 10 if HP >= 1, and not in sunlight orover running water" +
                            "\n        If you take Radiant dmg or dmg from holy water, no regen that turn");
                        break;
                }
                character.Flaws.Add("Stake to the Heart", "when enemy crits with a wooden or silver wep and HP <= 50, you are paralyzed for 1 hr");
            }
        }
    }
}
