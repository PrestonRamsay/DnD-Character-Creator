using DnD_Character_Creator.CharacterPieces.Spells;
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
        public List<string> Milestones { get; set; } = new List<string>();
        public List<string> Boons { get; set; } = new List<string>();
        public List<string> Flaws { get; set; } = new List<string>();
        public static Template NewTemplate(string template)
        {
            var result = new Template();

            switch (template)
            {
                case "Aberrant Horror":
                    result = AberrantHorror();
                    break;
                case "Fiend":
                    result = Fiend();
                    break;
                case "Lich":
                    result = Lich();
                    break;
                case "Lycanthrope":
                    result = Lycanthrope();
                    break;
                case "Seraph":
                    result = Seraph();
                    break;
                case "Vampire":
                    result = Vampire();
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
        public static Template AberrantHorror()
        {
            var result = new Template();

            result.Milestones.Add("Defeating a powerful Aberration and absorbing its power.");
            result.Milestones.Add("Undergoing a dangerous and costly experiment.");
            result.Milestones.Add("Surviving a magical mishap.");
            result.Milestones.Add("Acquiring the strength to give birth to a more powerful version of yourself, which then consumes your old self.");
            result.Milestones.Add("Fulfilling an eldritch prophecy written in the stars.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                result.Boons.Add("Aberrant Adaptations: " +
                    "\nChitinous Shell(bonus, 1 min, +2 AC, speed -10ft)" +
                    "\nEldritch Limbs(when atk, unarmed atks becomes 1D6 dmg of choice, can't hold anything in that hand)");
                result.Boons.Add("Aberrant Form: your type becomes Aberration");
                result.Flaws.Add("Unstable Mutations: after LR roll D% for Unstable Form, if same as previous reroll");
            }
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Efficient Killer", "Otherworldy Tendrils", "Situational Evolution" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: Bludgeoning(unarm dmg + 1D6, same atk roll vs adj to do 1D6 + Str dmg)" +
                            $"\nPiercing(ranged atk, 30ft, 2D6 + Str dmg), Slashing(unarm dmg + 1D6, Con save - 1 min, bleeding: no healing)");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: bonus to grow, bonus to use, 10ft, unarm atk, 1D4 + Str" +
                            $"\nToxic Spray(Con save - poison, disadv on atks/ability checks), Constrict(no dmg, grapple check = atk roll)" +
                            $"\nHypnotic Trance(Wis save - adv on atks on vs target)");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: action to change Adaptation" +
                            $"\nScopulae(climb as move speed), Gills/Flippers(swim as move speed)" +
                            $"\nRegenerative Tissues(regen Con HP, negate if take fire/acid dmg)");
                        break;
                }
                result.Flaws.Add("Hideous Appearance: true form revealed if (use conc spell, unconscious, hallowed ground, or DM Con save)" +
                    "\nNon-evil creatures who see your true form instantly become hostile unless GM decides overwise");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Wings", "Additional Tendrils", "Enhanced Hypertrophy" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: SR, bonus, 10 min, gain fly = move speed");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: bonus, atk per tendril (2 or 3 if lvl 4)");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: unarm dmg = D8, or 1 higher base die (D6 = D8, etc)");
                        break;
                }
                result.Flaws.Add("Unstable Existence: reveal Hideous Appearance on rolls of 1, 2, or 3 on saves vs magic");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Savage Predator", "Master of the Deep", "Extremophilic Conditioning" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: on nat 20, dmg + 6D6 and 30ft, Wis save - 1 min, fear");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: SR, action, 15ft, Dex save - 1 min, poison, disadv on atks/ability checks" +
                            $"\nspeed = 0, adv on atks vs target");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: Metamorphosis(action to switch benefits)" +
                            $"\n-Resist bludg, pierc, slash and fall dmg = 1 per 10ft, max 20" +
                            $"\n-Resist fire, lightning, acid and immune to hot climates" +
                            $"\n-Resist cold, thunder, poison and immune to cold climates");
                        break;
                }
                result.Flaws.Add("Entropic Abomination: on failed save vs magic, roll Unstable Mutation - if lower than current replace it");
            }

            return result;
        }
        public static Template Fiend()
        {
            var result = new Template();

            result.Milestones.Add("Defeating a greater rival Fiend and taking their place in the hierarchy.");
            result.Milestones.Add("Ensnaring a particularly powerful or influential soul with a contract.");
            result.Milestones.Add("Establishing a cult of worshipers who offer their strength to you.");
            result.Milestones.Add("Establishing a portal between the material plane and the Netherworld.");
            result.Milestones.Add("Killing or corrupting a Seraph.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                int cost = 50 * lvl;
                result.Boons.Add($"Gifts of Damnation: each contract requires magical ink and paper worth {cost}gp");
                result.Boons.Add("Fiendish Form: your type becomes Fiend");
                result.Flaws.Add("Planar Binding: disadv on death saves, on death GM takes control of the character");
            }
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Brand of the Chainer's Gaze", "Brand of the Tyrant's Hellfire", "Brand of the Deceiver's Guile" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: Cha/LR, bonus, 60ft, Int save, 1 min, target atks - 1D6");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: Cha/LR, bonus, 60ft, Cha save, 1 min, on hit +1D6 fire dmg");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: Cha/LR, bonus, 60ft, Int save, 1 min, target atks - 1D6");
                        break;
                }
                result.Flaws.Add("Hideous Appearance: true form revealed if (use conc spell, unconscious, hallowed ground, or DM Con save)" +
                    "\nNon-evil creatures who see your true form instantly become hostile unless GM decides overwise");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Alluring Deceit", "Infernal Resistance", "Nether Blade" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: gain prof in Deception and Persuasion or double your prof bonus if already prof" +
                            $"\nMagic always identifies you as telling the truth and you can't be compelled to tell the truth");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: reaction, if you take magical dmg - half the dmg");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: bonus to summon, +2D6 fire dmg, bright light 5ft/dim light 5ft, can't be disarmed");
                        break;
                }
                result.Flaws.Add("True Name: you are reborn - choose new name, receive a brass/brimstone talisman with your name on it" +
                    "\nA creature that knows your true name - action, 10ft, Wis save - charm 8hr, must obey commands");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Commanding Obedience", "Brimstone Pyrolysis", "Infernal Summoning" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: 30ft, on a fail vs non-cantrip spell - must take turn to kneel (become prone)");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: kill with fire, turn into statue - action, 10ft, Dex save, detonate statue 3D6 fire");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: LR, action, summon 4 Imps, no action to issue commands");
                        break;
                }
                result.Flaws.Add("Pull of the Netherworld: when roll 1 on save vs magic, take 1D6 per 2 lvls (lvl 8 = 4D6)");
            }

            return result;
        }
        public static Template Lich()
        {
            var result = new Template();

            result.Milestones.Add("Discover ancient and dark arcane knowledge.");
            result.Milestones.Add("Consume the soul of an exceptionally powerful spellcaster.");
            result.Milestones.Add("Build a monument to your power to serve as a giant arcane focus.");
            result.Milestones.Add("Create an army of undead.");
            result.Milestones.Add("Kill a god.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                result.Boons.Add("Harvester of Souls: when kill, phylactery charge lvl = CR (max 27, below 1/4 is too low)" +
                    "\naction, expend charge lvls to regain spell slot = 1/3 of charges consumed");
                result.Boons.Add("Undead Form: your type becomes Undead, you don't require air, food, drink, or sleep" +
                    "\nhealing gives you temp HP instead of real HP, you no longer age/immune to aging effects");
                result.Flaws.Add("Phylactery: AC 18, HP 90, immune to poison, psychic, and nonmagical B/P/S" +
                    "\nResistant to necrotic, cold, thunder, lightning, force, fire" +
                    "\nIf phylactery is destroyed you die instantly, if you die and it has charges - your body is reconstructed in 7 days");
            }
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Puppet Master", "Lichdom of the Arcane", "Rift of the dreadscapes" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: reanimated Undead CR 1- are permanently under your control, no one else can take control");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: when you kill with a spell, gain an additional effect" +
                            $"\nFire(create smoke that heavily obscures adj creatures)" +
                            $"\nNecrotic(regain Int + lvl HP)" +
                            $"\nPoison(10ft, Con save, 1 min, poisoned - disadv on atks/ability checks)");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: LR, action, 5ft, 20ft radius, 1 min, Con save, 10D10 necrotic dmg, Undead are immune");
                        break;
                }
                result.Flaws.Add("Hideous Appearance: true form revealed if (use conc spell, unconscious, hallowed ground, or DM Con save)" +
                    "\nNon-evil creatures who see your true form instantly become hostile unless GM decides overwise");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Relentless Undead", "Arcane Supremacy", "Staff of Dreadscapes" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: ");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: ");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: ");
                        break;
                }
                result.Flaws.Add("Necromatic Dystrophy: ");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Lord of Undeath", "Arcane Omniscience", "Deathly Being" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: ");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: ");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: ");
                        break;
                }
                result.Flaws.Add("Weight of Ages: ");
            }

            return result;
        }
        public static Template Lycanthrope()
        {
            var result = new Template();

            result.Milestones.Add("Establishing a pack of other Lycanthropes.");
            result.Milestones.Add("Killing an Alpha Lycanthrope.");
            result.Milestones.Add("Gaining control of your animalistic urges.");
            result.Milestones.Add("Unleashing the beast within and losing your humanity.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                result.Boons.Add("Hybrid Transformation: ");
                result.Boons.Add("Shapechanger's Form: ");
                result.Flaws.Add("Lust for the Hunt: ");
            }
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Iron Pelt", "Hunter's Howl", "Kindred Form" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: ");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: ");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: ");
                        break;
                }
                result.Flaws.Add("Silver Sensitivity: ");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Titanic Vigor", "Predatory Leap", "Beastial Savagery" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: ");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: ");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: ");
                        break;
                }
                result.Flaws.Add("Fraying Memories: ");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Savage Instincts", "Kindred Affinity", "Unstoppable Rage" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: ");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: ");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: ");
                        break;
                }
                result.Flaws.Add("Predatory Nature: ");
            }

            return result;
        }
        public static Template Seraph()
        {
            var result = new Template();

            result.Milestones.Add("Defeating a powerful force of darkness.");
            result.Milestones.Add("Create a hallowed landmark for pilgrims.");
            result.Milestones.Add("Establish a parish of worshipers who uphold your virtue.");
            result.Milestones.Add("Establish a portal between the Material Plane and the Empyrium.");
            result.Milestones.Add("Redeem a soul that was considered beyond redemption.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                result.Boons.Add("Celestial Form: your type becomes Celestial");
                result.Boons.Add("Angelic Wings: you have a fly speed = move speed");
                result.Flaws.Add("Planar Binding: disadv on death saves, on death GM takes control of the character");
            }
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Divine Retribution", "Divine Clemency", "Divine Expedition" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: Wis/LR, reaction, 30ft, you or ally bonus, dmg + 1D8 radiant");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: Wis/LR, reaction, 60ft, when dmg is taken, cast a non-cantrip healing spell");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: Wis/LR, reaction, 60ft, you or ally extra move action with no atk ops");
                        break;
                }
                result.Flaws.Add("Divine Appearance: true form revealed if (use conc spell, unconscious, hallowed ground, or DM Con save)" +
                    "\nEvil creatures who see your true form instantly become hostile unless GM decides overwise");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Radiant Strike", "Cleanse Affliction", "Bow of Celestial Judgment" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: melee dmg + 1D6 radiant or 2D6 if Fiend, Fey, or Undead");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: when you cast a heal spell, also remove any condition caused by a spell or ability");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: bonus to summon longbow, doesn't require ammo, bright light 5ft/dim light 5ft" +
                            $"\ndmg + 1D8 radiant or 2D8 if Fiend, Fey, or Undead");
                        break;
                }
                result.Flaws.Add("Beacon to Darkness: when an act of greater evil is committed within 30ft - gain 1 corruption pt" +
                    "\natks/saves vs evil take minus = corruption pts (SR/LR and 1hr prayer reduces pts by 1)");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Aura of Holy Purge", "Aura of Merciful Blessing", "Aura of Empyreal Valor" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: you or ally, 20ft, make hit a crit, LR to benefit from it again");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: you or ally, 20ft, 0HP = 1HP, LR to benefit from it again");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: 20ft, +5 Init, adv on atks vs creatures who haven't gone, LR to benefit from it again");
                        break;
                }
                result.Flaws.Add("Pull of the Empyrean: when roll 1 on save vs magic, take 1D6 per 2 lvls (lvl 8 = 4D6)");
            }

            return result;
        }
        public static Template Vampire()
        {
            var result = new Template();

            result.Milestones.Add("Establish a coven of vampire spawn.");
            result.Milestones.Add("Drink the blood of a legendary monster.");
            result.Milestones.Add("Learn the great secrets of vampirism from a Vampire Lord.");
            result.Milestones.Add("Learn to embrace your Hideous Form and lose the ability to conceal it.");
            result.Milestones.Add("Discover the lost crypts of an ancient vampire and consume its essence.");

            Console.WriteLine("What level is your template? Enter a number 1-4.");
            int lvl = CLIHelper.GetNumberInRange(1, 4);

            if (lvl >= 1)
            {
                result.Boons.Add("Blood Fury: ");
                result.Boons.Add("Undead Form: ");
                result.Flaws.Add("The Curse Sanguine: ");
            }
            if (lvl >= 2)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Dread Knight Combat Training", "Sanguine Magic", "Shapechanger" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: ");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: ");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: ");
                        break;
                }
                result.Flaws.Add("Hideous Appearance: true form revealed if (use conc spell, unconscious, hallowed ground, or DM Con save)" +
                    "\nNon-evil creatures who see your true form instantly become hostile unless GM decides overwise");
            }
            if (lvl >= 3)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Cruel Riposte", "Creatures of the Night", "Captivating Glance" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: ");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: ");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: ");
                        break;
                }
                result.Flaws.Add("Greater Sanguine Curse");
            }
            if (lvl >= 4)
            {
                string pickMsg = "Pick your template boon for this level.";
                var boons = new List<string> { "Grim Executioner", "Beguiler's Entrancement", "Regenerate" };
                int index = CLIHelper.PrintChoices(pickMsg, boons);

                switch (index)
                {
                    case 0:
                        result.Boons.Add($"{boons[0]}: ");
                        break;
                    case 1:
                        result.Boons.Add($"{boons[1]}: ");
                        break;
                    case 2:
                        result.Boons.Add($"{boons[2]}: ");
                        break;
                }
                result.Flaws.Add("Stake to the Heart");
            }

            return result;
        }
    }
}
