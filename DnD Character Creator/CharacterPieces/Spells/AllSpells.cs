using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public class AllSpells
    {
        public AllSpells(string classStr)
        {
            Stat = "Cha";
            switch (classStr)
            {
                case "Cleric":
                    Cleric.Add(0, ClericSpells.Cantrips);
                    Cleric.Add(1, ClericSpells.FirstLvls);
                    Cleric.Add(2, ClericSpells.SecondLvls);
                    Cleric.Add(3, ClericSpells.ThirdLvls);
                    Cleric.Add(4, ClericSpells.FourthLvls);
                    Cleric.Add(5, ClericSpells.FifthLvls);
                    Cleric.Add(6, ClericSpells.SixthLvls);
                    Cleric.Add(7, ClericSpells.SeventhLvls);
                    Cleric.Add(8, ClericSpells.EigthLvls);
                    Cleric.Add(9, ClericSpells.NinthLvls);
                    break;
                case "Sorcerer":
                    Sorcerer.Add(0, SorcererSpells.Cantrips);
                    Sorcerer.Add(1, SorcererSpells.FirstLvls);
                    Sorcerer.Add(2, SorcererSpells.SecondLvls);
                    Sorcerer.Add(3, SorcererSpells.ThirdLvls);
                    Sorcerer.Add(4, SorcererSpells.FourthLvls);
                    Sorcerer.Add(5, SorcererSpells.FifthLvls);
                    Sorcerer.Add(6, SorcererSpells.SixthLvls);
                    Sorcerer.Add(7, SorcererSpells.SeventhLvls);
                    Sorcerer.Add(8, SorcererSpells.EigthLvls);
                    Sorcerer.Add(9, SorcererSpells.NinthLvls);
                    break;
            }
        }
        //for Sorceror only ^^
        public AllSpells(Character character)
        {
            Lvl = character.Lvl;
            string classStr = character.ChosenClass;
            string archetype = character.Archetype;
            if (classStr == "Artificer" || classStr == "Fighter" || classStr == "Rogue" || classStr == "Wizard")
            {
                Stat = "Int";
            }
            else if (classStr == "Cleric" || classStr == "Druid" || classStr == "Ranger")
            {
                Stat = "Wis";
            }
            else if (classStr == "Bard" || classStr == "Paladin" || classStr == "Sorcerer" || classStr == "Swordmage" || classStr == "Warlock")
            {
                Stat = "Cha";
            }
            if (classStr == "Psion")
            {
                switch (archetype)
                {
                    case "Clairsentience(Seer)":
                        Stat = "Wis";
                        break;
                    case "Metacreativity(Shaper)":
                        Stat = "Int";
                        break;
                    case "Psychokinesis(Savant)":
                        Stat = "Str";
                        break;
                    case "Psychometabolism(Egoist)":
                        Stat = "Con";
                        break;
                    case "Psychoportation(Nomad)":
                        Stat = "Dex";
                        break;
                    case "Telepathy(Telepath)":
                        Stat = "Cha";
                        break;
                }
            }
            switch (classStr)
            {
                case "Artificer":
                    Artificer.Add(0, ArtificerSpells.Cantrips);
                    Artificer.Add(1, ArtificerSpells.FirstLvls);
                    Artificer.Add(2, ArtificerSpells.SecondLvls);
                    Artificer.Add(3, ArtificerSpells.ThirdLvls);
                    Artificer.Add(4, ArtificerSpells.FourthLvls);
                    Artificer.Add(5, ArtificerSpells.FifthLvls);
                    break;
                case "Bard":
                    Bard.Add(0, BardSpells.Cantrips);
                    Bard.Add(1, BardSpells.FirstLvls);
                    Bard.Add(2, BardSpells.SecondLvls);
                    Bard.Add(3, BardSpells.ThirdLvls);
                    Bard.Add(4, BardSpells.FourthLvls);
                    Bard.Add(5, BardSpells.FifthLvls);
                    Bard.Add(6, BardSpells.SixthLvls);
                    Bard.Add(7, BardSpells.SeventhLvls);
                    Bard.Add(8, BardSpells.EigthLvls);
                    Bard.Add(9, BardSpells.NinthLvls);
                    break;
                case "Cleric":
                    Cleric.Add(0, ClericSpells.Cantrips);
                    Cleric.Add(1, ClericSpells.FirstLvls);
                    Cleric.Add(2, ClericSpells.SecondLvls);
                    Cleric.Add(3, ClericSpells.ThirdLvls);
                    Cleric.Add(4, ClericSpells.FourthLvls);
                    Cleric.Add(5, ClericSpells.FifthLvls);
                    Cleric.Add(6, ClericSpells.SixthLvls);
                    Cleric.Add(7, ClericSpells.SeventhLvls);
                    Cleric.Add(8, ClericSpells.EigthLvls);
                    Cleric.Add(9, ClericSpells.NinthLvls);
                    break;
                case "Druid":
                    Druid.Add(0, DruidSpells.Cantrips);
                    Druid.Add(1, DruidSpells.FirstLvls);
                    Druid.Add(2, DruidSpells.SecondLvls);
                    Druid.Add(3, DruidSpells.ThirdLvls);
                    Druid.Add(4, DruidSpells.FourthLvls);
                    Druid.Add(5, DruidSpells.FifthLvls);
                    Druid.Add(6, DruidSpells.SixthLvls);
                    Druid.Add(7, DruidSpells.SeventhLvls);
                    Druid.Add(8, DruidSpells.EigthLvls);
                    Druid.Add(9, DruidSpells.NinthLvls);
                    break;
                case "Fighter":
                    Fighter.Add(0, FighterSpells.Cantrips);
                    Fighter.Add(1, FighterSpells.FirstLvls);
                    Fighter.Add(2, FighterSpells.SecondLvls);
                    Fighter.Add(3, FighterSpells.ThirdLvls);
                    Fighter.Add(4, FighterSpells.FourthLvls);
                    Wizard.Add(0, WizardSpells.Cantrips);
                    Wizard.Add(1, WizardSpells.FirstLvls);
                    Wizard.Add(2, WizardSpells.SecondLvls);
                    Wizard.Add(3, WizardSpells.ThirdLvls);
                    Wizard.Add(4, WizardSpells.FourthLvls);
                    break;
                case "Paladin":
                    Paladin.Add(1, PaladinSpells.FirstLvls);
                    Paladin.Add(2, PaladinSpells.SecondLvls);
                    Paladin.Add(3, PaladinSpells.ThirdLvls);
                    Paladin.Add(4, PaladinSpells.FourthLvls);
                    Paladin.Add(5, PaladinSpells.FifthLvls);
                    break;
                case "Ranger":
                    Ranger.Add(1, RangerSpells.FirstLvls);
                    Ranger.Add(2, RangerSpells.SecondLvls);
                    Ranger.Add(3, RangerSpells.ThirdLvls);
                    Ranger.Add(4, RangerSpells.FourthLvls);
                    Ranger.Add(5, RangerSpells.FifthLvls);
                    break;
                case "Rogue":
                    Rogue.Add(0, RogueSpells.Cantrips);
                    Rogue.Add(1, RogueSpells.FirstLvls);
                    Rogue.Add(2, RogueSpells.SecondLvls);
                    Rogue.Add(3, RogueSpells.ThirdLvls);
                    Rogue.Add(4, RogueSpells.FourthLvls);
                    Wizard.Add(0, WizardSpells.Cantrips);
                    Wizard.Add(1, WizardSpells.FirstLvls);
                    Wizard.Add(2, WizardSpells.SecondLvls);
                    Wizard.Add(3, WizardSpells.ThirdLvls);
                    Wizard.Add(4, WizardSpells.FourthLvls);
                    break;
                case "Psion":
                    Psion.Add(0, PsionSpells.Cantrips);
                    Psion.Add(1, PsionSpells.FirstLvls);
                    Psion.Add(2, PsionSpells.SecondLvls);
                    Psion.Add(3, PsionSpells.ThirdLvls);
                    Psion.Add(4, PsionSpells.FourthLvls);
                    Psion.Add(5, PsionSpells.FifthLvls);
                    Psion.Add(6, PsionSpells.SixthLvls);
                    Psion.Add(7, PsionSpells.SeventhLvls);
                    Psion.Add(8, PsionSpells.EigthLvls);
                    Psion.Add(9, PsionSpells.NinthLvls);
                    break;
                case "Swordmage":
                    Swordmage.Add(0, SwordmageSpells.Cantrips);
                    Swordmage.Add(1, SwordmageSpells.FirstLvls);
                    Swordmage.Add(2, SwordmageSpells.SecondLvls);
                    Swordmage.Add(3, SwordmageSpells.ThirdLvls);
                    Swordmage.Add(4, SwordmageSpells.FourthLvls);
                    Swordmage.Add(5, SwordmageSpells.FifthLvls);
                    break;
                case "Warlock":
                    Warlock.Add(0, WarlockSpells.Cantrips);
                    Warlock.Add(1, WarlockSpells.FirstLvls);
                    Warlock.Add(2, WarlockSpells.SecondLvls);
                    Warlock.Add(3, WarlockSpells.ThirdLvls);
                    Warlock.Add(4, WarlockSpells.FourthLvls);
                    Warlock.Add(5, WarlockSpells.FifthLvls);
                    Warlock.Add(6, WarlockSpells.SixthLvls);
                    Warlock.Add(7, WarlockSpells.SeventhLvls);
                    Warlock.Add(8, WarlockSpells.EigthLvls);
                    Warlock.Add(9, WarlockSpells.NinthLvls);
                    break;
                case "Wizard":
                    Wizard.Add(0, WizardSpells.Cantrips);
                    Wizard.Add(1, WizardSpells.FirstLvls);
                    Wizard.Add(2, WizardSpells.SecondLvls);
                    Wizard.Add(3, WizardSpells.ThirdLvls);
                    Wizard.Add(4, WizardSpells.FourthLvls);
                    Wizard.Add(5, WizardSpells.FifthLvls);
                    Wizard.Add(6, WizardSpells.SixthLvls);
                    Wizard.Add(7, WizardSpells.SeventhLvls);
                    Wizard.Add(8, WizardSpells.EigthLvls);
                    Wizard.Add(9, WizardSpells.NinthLvls);
                    break;
            }
        }
        public static int Lvl { get; set; }
        public static string Stat { get; set; }
        public Dictionary<int, List<string>> Artificer { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Bard { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Cleric { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Druid { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Fighter { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Paladin { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Ranger { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Rogue { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Psion { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Sorcerer { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Swordmage { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Warlock { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Wizard { get; set; } = new Dictionary<int, List<string>>();
        public static List<string> AllCantrips { get; set; } = new List<string>
        {
            "Acid Splash",
            "Blade Ward",
            "Booming Blade",
            "Chill Touch",
            "Control Flames",
            "Create Bonfire",
            "Dancing Lights",
            "Druidcraft",
            "Eldritch Blast",
            "Encode Thoughts",
            "Fire Bolt",
            "Friends",
            "Frostbite",
            "Green-Flame blade",
            "Gust",
            "Infestation",
            "Light",
            "Lightning Lure",
            "Mage Hand",
            "Magic Stone",
            "Mending",
            "Message",
            "Mind Sliver",
            "Minor Illusion",
            "Mold Earth",
            "Poison Spray",
            "Prestidigitation",
            "Primal Savagery",
            "Produce Flame",
            "Ray of Frost",
            "Resistance",
            "Sacred Flame",
            "Sapping Sting",
            "Shape Water",
            "Shillelagh",
            "Shocking Grasp",
            "Spare the Dying",
            "Sword Burst",
            "Thaumaturgy",
            "Thorn Whip",
            "Thunderclap",
            "Toll the Dead",
            "True Strike",
            "Vicious Mockery",
            "Word of Radiance"
        };
        public static List<string> FirstLvlDivination { get; set; } = new List<string>
        {
            "Beast Bond",
            "Comprehend Languages",
            "Detect Evil and Good",
            "Detect Magic",
            "Detect Poison and Disease",
            "Gift of Alacrity",
            "Hunter's Mark",
            "Identify",
            "Speak with Animals"
        };
        public static List<string> FirstLvlEnchantment { get; set; } = new List<string>
        {
            "Animal Friendship",
            "Bane",
            "Bless",
            "Charm Person",
            "Command",
            "Compelled Duel",
            "Dissonant Whispers",
            "Heroism",
            "Hex",
            "Sleep",
            "Tasha's Hideous Laughter"
        };
        public static List<string> FirstLvlIllusion { get; set; } = new List<string>
        {
            "Color Spray",
            "Disguise Self",
            "Distort Value",
            "Illusory Script",
            "Silent Image"
        };
        public static List<string> FirstLvlNecromancy { get; set; } = new List<string>
        {
            "Cause Fear",
            "False Life",
            "Inflict Wounds",
            "Ray of Sickness"
        };
        public static int CantripDmg
        {
            get
            {
                return GetDice(Lvl);
            }
        }
        public static int GetDice(int lvl)
        {
            int numOfDice = 1;
            for (int i = 1; i <= lvl; i += 4)
            {
                numOfDice++;
                if (i == 5 || i == 11)
                {
                    i += 2;
                }
            }
            return numOfDice;
        }
        public static string GreenFlameBlade()
        {
            int fireDice = CantripDmg - 1;
            string returnString = $"5ft, melee atk with a weapon / deal {Stat} Fire dmg to adj creature";
            
            if (Lvl >= 5)
            {
                returnString = $"5ft, melee atk with a weapon, dmg + {fireDice}D8 Fire / deal {Stat} + {fireDice}D8 Fire dmg to adj creature";
            }

            return returnString;
        }
        public static Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>
        {
            { "Abi-Dalzim’s Horrid Wilting", "150ft/30ft cube, Con save, constructs/undead are immune, plants/water elementals suffer disadv, 12D8 Necrotic or 1/2" +
                "\n          nonmagical plants wither instantly" },
            { "Absorb Elements", "reaction, 1 round, when you take dmg, gain Resistance, next melee dmg + 1D6, higher lvls" },
            { "Acid Arrow", "90ft, ranged spell atk, 4D4 Acid + 2D4 Acid next turn, miss = 1/2 of 4D4, higher lvls" },
            { "Acid Splash", $"60ft, 1 or 2 creatures, must be adj, Dex save, {CantripDmg}D6 Acid" },
            { "Aganazzar’s Scorcher", "30ft line, Dex save, 3D8 Fire or 1/2, higher lvls" },
            { "Aid", "30ft, 3 creatures, 8hr, +5 HP, higher lvls" },
            { "Alarm", "1 min, 30ft, 8hr, choose door/window/20ft area, know when creature enters if within 1 mile, bell rings within 60ft" },
            { "Alter Self", "action, conc 1hr, assume 1 of 3 forms: Aquatic - gain Waterbreathing and Swim speed, Change Appearance - can become another race but" +
                "\n     can't grow limbs, Natural Weapons - gain claws, fangs, horns, etc / unarmed dmg = 1D6 B/P/S as approriate, unarmed atk/dmg + 1" },
            { "Animal Friendship", "30ft, 24hr, Wis save, Int >= 4 spell fails, beast is charmed and won't harm you, higher lvls" },
            { "Animal Messenger", "30ft, 24hr, Tiny beast delivers 25 word msg to location you've visited to general desc of recipient" +
                "\n     speed = 50 miles/24hr for Flying or 25 miles/24hr, higher lvls" },
            { "Animal Shapes", "30ft, conc 24hr, any willing creatures, transform into Large or smaller beast CR 4 or lower" +
                "\n     1/turn, action, shift forms / stats and HP as Druid's Wild Shape" },
            { "Animate Dead", "1 min, 10ft, 24hr, corpse becomes zombie or skeleton, bonus to command, higher lvls" },
            { "Animate Objects", "120ft, conc 1 min, bring objects to life - 10 Small objects, Medium = 2 objects, Large = 4 objects, Huge = 8 objects" +
                "\n     500ft, bonus to command, if no command they only defend themselves, see PH for stats, higher lvls" },
            { "Antilife Shell", "10ft, conc 1hr, creatures except undead or constructs can't move within the area" },
            { "Antimagic Field", "10ft, conc 1hr, spells that target have no effect, AoE spells can't enter area, active spells and magic items are suppressed" +
                "\n     magical travel fails and portals close, summoned objects and creatures temporarily disappear, spells like dispel magic don't work" },
            { "Antipathy/Sympathy", "1hr, 60ft/200ft cube, 10 days, Wis save, target attracts or repels certain creatures" +
                "\n     Antipathy - sight or 60ft, fear / Sympathy - sight or 60ft, must move toward target" },
            { "Arcane Eye", "30ft, conc 1hr, create invisible floating eye, has Darkvision 30ft, action to move eye 30ft, can move through 1 inch opening" },
            { "Arcane Gate", "500ft, conc 10 min, create 2 connected 10ft portals, only 1 active side, bonus to rotate active side" },
            { "Arcane Lock", "touch, lock a closed door, window, gate, chest, or entryway / can set password that suppresses spell for 1 min" +
                "\n     Knock spell can suppress spell for 10 min, DCs to break or lockpick increase by 10" },
            { "Armor of Agathys", "1hr, gain 5 temp HP, if hit by melee deal 5 Cold dmg, higher lvls" },
            { "Arms of Hadar", "10ft radius, Str save, 2D6 Necrotic or 1/2 and can't take reactions, higher lvls" },
            { "Astral Projection", "1hr, 10ft, you and 8 creatures, bodies go unconscious and don't need food/air and don't age / silvery cord connects" +
                "\n     your mind and body together, if cut you die instantly, you can move freely and use portals to transport your body" },
            { "Augury", "1 min, self, DM chooses omen for next 30 min: Weal(good), Woe(bad), Weal and Woe, or Nothing" +
                "\n     casting again before LR causes 25% chance of random omen" },
            { "Aura of Life", "30ft radius, conc 10 min, grant Resistance to Necrotic, HP max can't be reduced, at start of turn if 0 HP - gain 1 HP" },
            { "Aura of Purity", "30ft radius, conc 10 min, grant Immunity to disease, Resistance to Poison dmg, and adv vs blind/charm/deaf/fear/paralyze/poison/stun" },
            { "Aura of Vitality", "action, 30ft radius, conc 1 min, 1 creature, bonus to heal 2D6 HP" },
            { "Awaken", "8hr, touch, Huge or smaller beast or plant, must have Int < 3, target gains Int 10, 1 language" +
                "\n     if plant: gain ability to move / 30 days, charmed, after it chooses to remain friendly or not based on your treatment" },
            { "Bane", "30ft, conc 1 min, 3 creatures, Cha save, atks/saves - 1D4, higher lvls" },
            { "Banishing Smite", "bonus, conc 1 min, next hit dmg + 5D10 Force, if atk reduces HP <= 50, banish the target" },
            { "Banishment", "60ft, conc 1 min, 1 creature, Cha save, banish the target, higher lvls" },
            { "Barkskin", "touch, conc 1hr, target's min AC = 16" },
            { "Beacon of Hope", "30ft, conc 1 min, grant adv on Wis saves and death saves, healing spells are maxed when used on the target" },
            { "Beast Bond", "touch, conc 10 min, Int >= 4 spell fails, communicate telepathically, beast gains adv on atk vs creatures adj to you" },
            { "Beast Sense", "touch, conc 1hr, you see and hear through beast until action to end, blind and deaf to your own surroundings" },
            { "Bestow Curse", "touch, conc 1 min, Wis save, choose 1 of 4 curses: impose disadv on checks/saves with 1 stat, impose disadv on atk vs you" +
                "\n     1/turn - Wis save or do nothing, or dmg + 1D8 Necrotic vs target, higher lvls" },
            { "Bigby's Hand", "120ft, conc 1 min, AC 20, HP = max HP, Str 26, bonus to move 60ft and cause 1 of 4 effects:" +
                $"\n     Clenched Fist(melee atk, 4D8 Force), Forceful Hand(Str check vs Athletics, if Medium or smaller gain adv, push {Stat} + 5ft, hand moves adj)" +
                "\n     Grasping Hand(grapple Huge or smaller creature, if Medium or smaller gain adv, while grappled - bonus to deal 2D6 Bludgeoning)" +
                "\n     Interposing Hand(provides half cover(+2 AC, Dex saves), target can't move through hand if Str < 26, else difficult terrain), higher lvls +2" },
            { "Blade Barrier", "90ft, conc 10 min, Dex save, create wall 100ft long or 60ft diamater ring, 20ft high, 5ft thick, provides 3/4 cover(+5 AC, Dex saves)" +
                "\n     barrier is difficult terrain and deals 6D10 Slashing dmg" },
            { "Blade of Diaster", "bonus, 60ft, conc 1 min, 2 melee atks, crit 18-20, 4D12 Force (if crit, total dmg = 12D12), bonus to move & make 2 atks" },
            { "Blade Ward", "1 round, gain Resistance to B/P/S from weapons" },
            { "Bless", "30ft, conc 1 min, 3 creatures, atks/saves + 1D4, higher lvls" },
            { "Blight", "30ft, Con save, plants suffer disadv, 8D8 Necrotic or 1/2, nonmagical/noncreature plants instantly wither and die, higher lvls" },
            { "Blinding Smite", "bonus, conc 1 min, next hit dmg + 3D8 Radiant / Con save, blind the target" },
            { "Blindness/Deafness", "30ft, 1 min, Con save, blind of deafen target, higher lvls" },
            { "Blink", "1/turn, roll 1D20 - 11+ = vanish and appear on Ethereal Plane for 1 turn, reappear within 10ft" },
            { "Blur", "conc 1 min, no effect if attacker has Blindsight, Truesight, or can see through Illusions, impose disadv on atks" },
            { "Bones of the Earth", "120ft, Dex save, create 6 pillars(AC 5, HP = 30) 5ft x 30ft, if ceiling - 6D6 Bludgeoning and restrain, Str or Dex save to escape" },
            { "Booming Blade", $"5ft, 1 round, melee atk with a weapon, if target moves - {CantripDmg}D8 Thunder" },
            { "Branding Smite", "bonus, conc 1 min, next hit dmg + 2D6 Radiant, negate invisibility, cause target to shine dim light 5ft, higher lvls" },
            { "Burning Hands", "15ft cone, Dex save, 3D6 Fire or 1/2, ignites flammable objects not worn/carried, higher lvls" },
            { "Call Lightning", "120ft, conc 10 min, 60ft radius, 10ft tall, all adj creatures, Dex save, 3d10, if there's already a storm - dmg + 1D10" +
                "\n     action to repeat, higher lvls" },
            { "Calm Emotions", "60ft/20ft radius, conc 1 min, Cha save, suppress charm or fear / end hostility (won't atk unless sees allies hurt)" },
            { "Catapult", "60ft/90ft, Dex save, choose 1-5 lb object to launch, 3D8 Bludgeoning, higher lvls" },
            { "Catnap", "30ft, 10 min, 3 creatures, fall unconscious, gain benefits of SR, higher lvsls" },
            { "Cause Fear", "60ft, conc 1 min, constructs/undead are immune, frightened condition, higher lvls" },
            { "Ceremony", "1hr, touch, choose a rite: Atonement(DC 20 Insight check to restore alignment), Bless Water(create vial of holy water)" +
                "\n          Coming of Age(24hr, 1 newly adult humanoid, ability check + 1D4), Dedication(24hr, saves + 1D4), Funeral Rite(7 days, corpse, can't become undead)" +
                "\n          Wedding(7 days, a couple willing to be married, +2 AC if within 30ft)" },
            { "Chain Lightning", "" },
            { "Chaos Bolt", "120ft, ranged spell atk, 2D8 + 1D6 pick D8 for dmg type - (1)Acid (2)Cold (3)Fire (4)Force (5)Lightning (6)Poison (7)Psychic (8)Thunder" +
                "\n     if D8s are both the same number: 30ft, ranged spell atk, repeat previous dmg/effect, higher lvls" },
            { "Charm Monster", "30ft, 1hr, Wis save, target gains adv if fighting the party, charms to be friendly, higher lvls" },
            { "Charm Person", "" },
            { "Chill Touch", "" },
            { "Chromatic Orb", "" },
            { "Cirle of Death", "" },
            { "Cirle of Power", "" },
            { "Clairvoyance", "" },
            { "Clone", "" },
            { "Cloud of Daggers", "" },
            { "Cloudkill", "" },
            { "Color Spray", "" },
            { "Command", "60ft, Wis save, auto-fail if undead/no lang/harmful command, must be 1-word, ex: Approach, Drop, Flee, Grovel, Halt / higher lvls" },
            { "Commune", "" },
            { "Commune with Nature", "" },
            { "Compelled Duel", "" },
            { "Comprehend Languages", "" },
            { "Compulsion", "" },
            { "Cone of Cold", "" },
            { "Confusion", "" },
            { "Conjure Animals", "" },
            { "Conjure Barrage", "" },
            { "Conjure Celestial", "" },
            { "Conjure Elemental", "" },
            { "Conjure Fey", "" },
            { "Conjure Minor Elementals", "" },
            { "Conjure Volley", "" },
            { "Conjure Woodland Beings", "" },
            { "Contact Other Plane", "" },
            { "Contagion", "" },
            { "Contingency", "" },
            { "Continual Flame", "" },
            { "Control Flames", "60ft, 5ft nonmagical flame, choose 1 of 4 effects: (1) expand 5ft (2) extinguish (3) 1hr, create simple shapes like an object/location" +
                "\n     (4) 1hr, double or halve brightness, change color, or both" },
            { "Control Water", "" },
            { "Control Weather", "" },
            { "Control Winds", "300ft, conc 1hr, choose 1 of 3 effects: Gusts(impose disadv on ranged atks, can choose to double movement cost, calm wind is a choice), " +
                "\n     Downdraft(impose disadv on ranged atks, Str save, knock flying creature prone), Updraft(1/2 fall dmg, high jump +10ft)" },
            { "Cordon of Arrows", "" },
            { "Counterspell", "" },
            { "Create Bonfire", $"60ft, conc 1 min, Dex save, {CantripDmg}D8 Fire, create 5ft bonfire" },
            { "Create Food and Water", "" },
            { "Create Homunculus", "1hr, touch, take 2D4 Piercing, create Homunculus / Homunculus dies if you die / if Homunculus dies, regain spent HP(see below)" +
                "\n     on LR, spend 1/2 HD, reduce max HP by each roll + Con, increase Homunculus max HP by total" },
            { "Create Magen", "1hr, touch, sacrifice CR max HP to create (CR 2)Demos(fighter/guard), (CR 3)Galvan(fly/electric), or (CR 1)Hypnos(psychic/telepath) Magen" },
            { "Create or Destroy Water", "" },
            { "Create Undead", "" },
            { "Creation", "" },
            { "Crown of Madness", "" },
            { "Crown of Stars", "1hr, create 7 star-like motes / bonus, 120ft, ranged spell atk, shoot 1 mote, 4D12 Radiant" +
                "\n     4+ motes = bright light 30ft/dim light 30ft, 1-3 motes = dim light 30ft, higher lvls" },
            { "Crusader's Mantle", "" },
            { "Cure Wounds", "" },
            { "Dancing Lights", "" },
            { "Danse Macabre", $"60ft, conc 1hr, 5 Small or Medium corpses, each becomes zombie or skeleton: atk/dmg + {Stat} / bonus, 60ft, mentally command, higher lvls" },
            { "Dark Star", "" },
            { "Darkness", "" },
            { "Darkvision", "" },
            { "Dawn", "60ft/30ft radius/40ft tall, conc 1 min, Con save, 4D10 Radiant or 1/2, area is sunlight, dmg 1/turn and when created / bonus, 60ft, move cylinder 60ft" },
            { "Daylight", "" },
            { "Death Ward", "" },
            { "Delayed Fireball", "" },
            { "Demiplane", "" },
            { "Destructive Wave", "" },
            { "Detect Evil and Good", "" },
            { "Detect Magic", "30ft, conc 10 min, blocked by 1ft stone/1 inch metal/thin lead/3ft wood or dirt, action to see auras and learn school of magic" },
            { "Detect Poison and Disease", "" },
            { "Detect Thoughts", "" },
            { "Dimension Door", "" },
            { "Disguise Self", "" },
            { "Disintegrate", "" },
            { "Dispel Evil and Good", "" },
            { "Dispel Magic", "" },
            { "Dissonant Whispers", "" },
            { "Distort Value", "" },
            { "Divination", "" },
            { "Divine Favor", "" },
            { "Divine Word", "" },
            { "Dominate Beast", "" },
            { "Dominate Monster", "" },
            { "Dominate Person", "" },
            { "Dragon's Breath", "bonus, touch, conc 1 min, choose Acid/Cold/Fire/Lightning/Poison, targets gains: 15ft cone, Dex save, 3D6 dmg, higher lvls" },
            { "Drawmij's Instant Summons", "" },
            { "Dream", "" },
            { "Dream of the Blue Veil", "" },
            { "Druid Grove", "10 min, touch, 24hr, 30-90ft cube, allies can be immune, set a password, effects: Grasping Undergrowth(5ft, as Entangle spell)" +
                "\n     Grove Guardians(4 trees become Awakened Trees), Solid Fog(5ft, 10ft tall, heavily obscures, movement cost x2)" +
                "\n     Additional Spell Effect(Gust of Wind in 2 locations, Spike Growth in 1 location, or Wind Wall in 2 locations)" },
            { "Druidcraft", "" },
            { "Dust Devil", "60ft, conc 1 min, adj creatures, Str save, 1D8 Bludgeoning or 1/2, push 10ft / bonus, move 30ft - 10ft radius heavily obscures, higher lvls" },
            { "Earthbind", "300ft, conc 1 min, Str save, reduce Fly speed to 0, descend 60ft/round" },
            { "Earth Tremor", "10ft radius, Dex save, 1D6 Bludgeoning, knock prone, higher lvls" },
            { "Earthquake", "" },
            { "Eldritch Blase", "" },
            { "Elemental Bane", "90ft, conc 1 min, Con save, choose Acid/Cold/Fire/Lightning/Thunder, negate Resistance, next hit with dmg type + 2D6, higher lvls" },
            { "Elemental Weapon", "" },
            { "Encode Thoughts", "" },
            { "Enemies Abound", "120ft, conc 1 min, Int save, if Immunity to fear: auto-success, views all creatures as hostile, targets randomly, makes op atks" },
            { "Enervation", "60ft, conc 1 min, Dex save, 4D8 Necrotic or 2D8 Necrotic / action, deal 4D8 Necrotic / heal HP = 1/2 Necrotic dmg" },
            { "Enhance Ability", "" },
            { "Enlarge/Reduce", "" },
            { "Ensnaring Strike", "bonus, conc 1 min, Str save, Large gains adv, restrain, 1/turn - 1D6 Piercing, ally can use action to Str save, higher lvls" },
            { "Entangle", "" },
            { "Enthrall", "" },
            { "Erupting Earth", "120ft/20ft cube, Dex save, 3D12 Bludgeoning or 1/2, creates difficult terrain - 1 min to clear by hand, higher lvls" },
            { "Etherealness", "" },
            { "Evard's Black Tentacles", "" },
            { "Expeditious Retreat", "" },
            { "Eyebite", "" },
            { "Fabricate", "" },
            { "Faerie Fire", "" },
            { "False Life", "" },
            { "Far Step", "bonus, conc 1 min, teleport 60ft" },
            { "Fast Friends", "" },
            { "Fear", "" },
            { "Featherfall", "" },
            { "Feeblemind", "" },
            { "Feign Death", "" },
            { "Find Familiar", "" },
            { "Find Greater Steed", "10 min, 30ft, summon a Griffon, Pegasus, Peryton, Dire Wolf, Rhinoceros, or Saber-Toothed Tiger / creature is a Celestial, Fey, or Fiend" +
                "\n     Int <= 5, gain Int 6 / understands 1 language / 1 mile, communicate telepathically / share spells" },
            { "Find Steed", "10 min, 30ft, summon a Warhorse, Pony, Camel, Elk, or Mastiff / creature is a Celestial, Fey, or Fiend" +
                "\n     Int <= 5, gain Int 6 / understands 1 language / 1 mile, communicate telepathically / share spells" },
            { "Find the Path", "" },
            { "Find Traps", "" },
            { "Finger of Death", "" },
            { "Fire Bolt", "" },
            { "Fire Shield", "" },
            { "Firestorm", "" },
            { "Fireball", "" },
            { "Flame Arrows", "touch, conc 1hr, imbue 12 pieces of ammo, dmg + 1D6 Fire, higher lvls(more ammo)" },
            { "Flame Blade", "" },
            { "Flame Strike", "" },
            { "Flaming Sphere", "" },
            { "Flesh to Stone", "" },
            { "Flock of Familiars", "" },
            { "Fly", "" },
            { "Fog Cloud", "" },
            { "Forbiddance", "" },
            { "Forcecage", "" },
            { "Foresight", "" },
            { "Fortune's Favor", "" },
            { "Freedom of Movement", "" },
            { "Freezing Sphere", "" },
            { "Friends", "" },
            { "Frostbite", $"60ft, Con save, {CantripDmg}D6 Cold" },
            { "Frost Fingers", "15ft cone, Con save, 2D8 Cold, freezes nonmagical liquids not worn/carried, higher lvls" },
            { "Galder's Speedy Courier", "" },
            { "Galder's Tower", "" },
            { "Gaseous Form", "" },
            { "Gate", "" },
            { "Geas", "" },
            { "Gentle Repose", "" },
            { "Giant Insect", "" },
            { "Gift of Alacrity", "" },
            { "Gift of Gab", "" },
            { "Globe of Invulnerability", "" },
            { "Glyph of Warding", "" },
            { "Goodberry", "" },
            { "Grasping Vine", "" },
            { "Gravity Fissure", "" },
            { "Gravity Sinkhole", "" },
            { "Grease", "" },
            { "Greater Invisibility", "" },
            { "Greater Restoration", "" },
            { "Green-Flame Blade", GreenFlameBlade() },
            { "Guardian of Faith", "" },
            { "Guardian of Nature", "bonus, conc 1 min, transform into Primal Beast(speed +10ft, gain Darkvision 120ft, gain adv on Str-based atks, melee dmg + 1D6)" +
                "\n     or Great Tree(gain 10 temp HP, gain adv on Con saves, gain adv on Dex/Wis-based atks / 15ft radius, difficult terrain)" },
            { "Guards and Wards", "" },
            { "Guidance", "" },
            { "Guiding Bolt", "" },
            { "Gust of Wind", "" },
            { "Gust", "30ft, choose 1 of 3 effects: (1)Str save, push 5ft (2)not worn/carried 5lb object, push 10ft (3)harmless sensory effect using air" },
            { "Hail of Thorns", "" },
            { "Hallow", "" },
            { "Hallucinatory Terrain", "" },
            { "Harm", "" },
            { "Haste", "" },
            { "Heal", "" },
            { "Healing Spirit", "" },
            { "Healing Word", "" },
            { "Heat Metal", "" },
            { "Hellish Rebuke", "" },
            { "Heroes' Feast", "" },
            { "Heroism", "" },
            { "Hex", "bonus, 90ft, conc 1hr, 1 creature, dmg + 1D6 Necrotic, if target drops to 0 HP, mark a new target, higher lvls" },
            { "Hold Monster", "" },
            { "Hold Person", "" },
            { "Holy Aura", "" },
            { "Holy Weapon", "" },
            { "Hunger of Hadar", "" },
            { "Hunter's Mark", "bonus, 90ft, conc 1hr, 1 creature, dmg + 1D6 wep dmg, gain adv on Perception and Survival, if target drops to 0 HP, mark a new target, higher lvls" },
            { "Hypnotic Pattern", "" },
            { "Ice Knife", "60ft, ranged spell atk, 1D10 Piercing / target and adj creatures, Dex save, 2D6 Cold, higher lvls" },
            { "Ice Storm", "" },
            { "Identify", "" },
            { "Illusory Dragon", "" },
            { "Illusory Script", "" },
            { "Immolation", "90ft, conc 1 min, Dex save, 7D6 Fire or 1/2, bright light 30ft/dim light 30ft, 1/turn - 3D6 Fire, can't be nonmagically extinguished" },
            { "Immovable Object", "" },
            { "Imprisonment", "" },
            { "Incediary Cloud", "" },
            { "Incite Greed", "" },
            { "Infernal Calling", "" },
            { "Infestation", "" },
            { "Inflict Wounds", "" },
            { "Insect Plague", "" },
            { "Instant Summons", "" },
            { "Intellect Fortress", "" },
            { "Investiture of Flame", "self, conc 10 min, gain Immunity to Fire and Resistance to Cold, bright light 30ft/dim light 30ft" +
                "\n     adj creatures take 1D10 Fire / action, 15ft line, Dex save, 4D8 Fire or 1/2" },
            { "Investiture of Ice", "self, conc 10 min, gain Immunity to Cold and Resistance to Fire, ignore difficult terrain from ice/snow" +
                "\n     10ft radius, creates icy difficult terrain / action, 15ft cone, Con save, 4D6 Cold or 1/2" },
            { "Investiture of Stone", "self, conc 10 min, gain Resistance to nonmagical B/P/S, ignore difficult terrain of stone, move through stone like air" +
                "\n     can't end turn inside stone - ejected and stunned / action, 15ft radius, Dex save, knock prone" },
            { "Investiture of Wind", "self, conc 10 min, impose disadv on ranged atks, gain Fly 60ft / action, 60/15ft cube, Con save, 2D10 Bludgeoning, push Large 10ft" },
            { "Invisibility", "" },
            { "Invulnerability", "" },
            { "Jim's Glowing Coin", "" },
            { "Jim's Magic Missile", "" },
            { "Jump", "" },
            { "Knock", "" },
            { "Legend Lore", "" },
            { "Leomund's Secret Chest", "" },
            { "Leomund's Tiny Hut", "" },
            { "Lesser Restoration", "" },
            { "Levitate", "" },
            { "Life Transference", "" },
            { "Light", "" },
            { "Lightning Arrow", "" },
            { "Lightning Bolt", "" },
            { "Lightning Lure", $"15ft, Str save, {CantripDmg}D8 Lightning, pull 10ft" },
            { "Locate Animals or Plants", "" },
            { "Locate Creature", "" },
            { "Locate Object", "" },
            { "Longstrider", "" },
            { "Maddening Darkness", "" },
            { "Maelstrom", "120ft/30ft radius, conc 1 min, Str save, 6D6 Bludgeoning, pull 10ft to center, difficult terrain" },
            { "Mage Armor", "" },
            { "Mage Hand", "" },
            { "Magic Circel", "" },
            { "Magic Jar", "" },
            { "Magic Missile", "" },
            { "Magic Mouth", "" },
            { "Magic Stone", $"bonus, 1 min, imbue 3 pebbles(60ft, ranged spell atk, 1D6 + {Stat} Bludgeoning)" },
            { "Magic Weapon", "" },
            { "Magnify Gravity", "" },
            { "Major Image", "" },
            { "Mass Cure Wounds", "" },
            { "Mass Heal", "" },
            { "Mass Healing Word", "" },
            { "Mass Polymorph", "" },
            { "Mass Suggestion", "" },
            { "Maximilain's Earth Grasp", "30ft, conc 1 min, Str save, 2D6 Bludgeoning, restrain, action to move or grab new creature" },
            { "Maze", "" },
            { "Meld Into Stone", "" },
            { "Melf's Acid Arrow", "" },
            { "Melf's Minute Meteors", "120ft, conc 10 min, adj creatures, Dex save, create 6 meteors, bonus to use 1 or 2, 2D6 Fire/meteor, higher lvls" },
            { "Mending", "" },
            { "Mental Prison", "" },
            { "Message", "" },
            { "Meteor Swarm", "" },
            { "Mighty Fortress", "" },
            { "Mind Blank", "" },
            { "Mind Sliver", "" },
            { "Mind Spike", "" },
            { "Minor Illusion", "" },
            { "Mirage Arcana", "" },
            { "Mirror Image", "" },
            { "Mislead", "" },
            { "Misty Step", "bonus, teleport 30ft" },
            { "Modify Memory", "" },
            { "Mold Earth", "30ft, 5ft of dirt or stone, choose 1 of 3 effects: (1) move 5ft cube 5ft (2) 1hr, use shapes/color to create words/images (3) 1hr, create difficult terrain" },
            { "Moonbeam", "120ft, 40ft high/5ft radius, conc 1 min, Con save, shapechangers suffer disadv, 2D10 Radiant or 1/2, dim light, shapechangers revert to true form" +
                "\n     action to move cylinder 60ft, higher lvls" },
            { "Mordenkainen’s Faithful Hound", "" },
            { "Mordenkainen’s Private Sanctum", "" },
            { "Mordenkainen’s Sword", "" },
            { "Mordenkainen’s Magnificent Mansion", "" },
            { "Motivational Speech", "" },
            { "Move Earth", "" },
            { "Negative Energy Flood", "" },
            { "Nondetection", "" },
            { "Nystul's Magic Aura", "" },
            { "Otiluke's Resilient Sphere", "" },
            { "Otiluke's Freezing Sphere", "" },
            { "Otto's Irresistable Dance", "" },
            { "Pass without Trace", "" },
            { "Passwall", "" },
            { "Phantasmal Force", "" },
            { "Phantasmal Killer", "" },
            { "Phantom Steed", "" },
            { "Planar Ally", "" },
            { "Planar Binding", "" },
            { "Plane Shift", "" },
            { "Plant Growth", "" },
            { "Poison Spray", "" },
            { "Polymorph", "" },
            { "Power Word Heal", "" },
            { "Power Word Kill", "" },
            { "Power Word Pain", "" },
            { "Power Word Stun", "" },
            { "Prayer of Healing", "" },
            { "Prestidigitation", "" },
            { "Primal Savagery", "" },
            { "Primordial Ward", "conc 1 min, gain Resistance to Acid/Cold/Fire/Lightning/Thunder" +
                "\n     reaction, 1 turn, gain Immunity to 1 dmg type, lose Resistances, after end spell" },
            { "Prismatic Spray", "" },
            { "Prismatic Wall", "" },
            { "Produce Flame", "" },
            { "Programmed Illusion", "" },
            { "Project Image", "" },
            { "Protection from Energy", "" },
            { "Protection from Evil and Good", "" },
            { "Protection from Poison", "" },
            { "Psychic Scream", "" },
            { "Pulse Wave", "" },
            { "Purify Food and Drink", "" },
            { "Pyrotechnics", "60ft, create Fireworks(10ft, Con save, blind 1 turn) or Smoke(20ft radius, 1 min, heavily obscures)" },
            { "Raise Dead", "" },
            { "Rary's Telepathic Bond", "" },
            { "Ravenous Void", "" },
            { "Ray of Enfeeblement", "" },
            { "Ray of Frost", "" },
            { "Ray of Sickness", "" },
            { "Reality Break", "" },
            { "Regenerate", "" },
            { "Reincarnate", "" },
            { "Remove Curse", "" },
            { "Resilient Sphere", "" },
            { "Resistance", "" },
            { "Resurrection", "" },
            { "Reverse Gravity", "" },
            { "Revivify", "" },
            { "Rope Trick", "" },
            { "Sacred Flame", "" },
            { "Sanctuary", "" },
            { "Sapping Sting", "" },
            { "Scatter", "" },
            { "Scorching Ray", "" },
            { "Scrying", "" },
            { "Searing Smite", "" },
            { "See Invisibility", "" },
            { "Seeming", "" },
            { "Sending", "" },
            { "Sequester", "" },
            { "Shadow Blade", "" },
            { "Shadow of Moil", "" },
            { "Shapechange", "" },
            { "Shape Water", "30ft, 5ft cube of water, choose 1 of 4 effects: (1) move/change flow (2) 1hr, form/animate into simple shapes" +
                "\n     (3) 1hr, change color/opacity (4) 1hr, freeze water as long as no creature is occupying it" },
            { "Shatter", "" },
            { "Shield", "" },
            { "Shield of Faith", "bonus, 60ft, conc 10 min, 1 creature, gain +2 AC" },
            { "Shillelagh", "" },
            { "Shocking Grasp", "" },
            { "Sickening Radiance", "" },
            { "Silence", "" },
            { "Silent Image", "" },
            { "Simulacrum", "" },
            { "Skill Empowerment", "" },
            { "Skywrite", "sight, conc 1hr, form 10 cloud words, strong wind can dissipate early" },
            { "Sleep", "" },
            { "Sleet Storm", "" },
            { "Slow", "" },
            { "Snare", "" },
            { "Snilloc’s Snowball Swarm", "90ft/5ft radius, Dex save, 3D6 Cold, higher lvls" },
            { "Soul Cage", "" },
            { "Spare the Dying", "" },
            { "Speak with Animals", "10 min, comprehend and communicate verbally with beasts, give info about nearby locations/enemies" +
                "\n     DM's discretion to use Persausion to gain a small favor from a beast" },
            { "Speak with Dead", "" },
            { "Speak with Plants", "" },
            { "Spiderclimb", "" },
            { "Spike Growth", "" },
            { "Spirit Guardians", "" },
            { "Spirit Shroud", "" },
            { "Spiritual Weapon", "" },
            { "Staggering Smite", "" },
            { "Steel Wind Strike", "" },
            { "Stinking Cloud", "" },
            { "Stoneshape", "" },
            { "Stoneskin", "" },
            { "Storm of Vengeance", "" },
            { "Storm Sphere", "150ft/20ft radius, conc 1 min, Str save, 2D6 Bludgeoning, difficult terrain / 30ft from sphere, disadv on listen Perception" +
                "\n     bonus, 60ft, ranged spell atk, adv if in sphere, 4D6 Lightning, higher lvls" },
            { "Sugeestion", "" },
            { "Summon Aberration", "" },
            { "Summon Beast", "" },
            { "Summon Celestial", "" },
            { "Summon Construct", "" },
            { "Summon Elemental", "" },
            { "Summon Fey", "" },
            { "Summon Fiend", "" },
            { "Summon Greater Demon", "" },
            { "Summon Lesser Demon", "" },
            { "Summon Shadowspawn", "" },
            { "Summon Undead", "" },
            { "Sunbeam", "" },
            { "Sunburst", "" },
            { "Swift Quiver", "" },
            { "Sword Burst", $"all adj creatures, Dex save, {CantripDmg}D6 Force" },
            { "Symbol", "" },
            { "Synaptic Static", "" },
            { "Tasha's Hideous Laughter", "" },
            { "Tasha's Caustic Brew", "" },
            { "Tasha's Mind Whip", "" },
            { "Tasha's Otherworldly Guise", "" },
            { "Telekinesis", "" },
            { "Telepathic Bond", "" },
            { "Telepathy", "" },
            { "Teleport", "" },
            { "Teleportation Circle", "" },
            { "Temple of the Gods", "" },
            { "Temporal Shunt", "" },
            { "Tenser's Floating Disk", "" },
            { "Tenser's Transformation", "" },
            { "Tether Essence", "" },
            { "Thaumaturgy", "" },
            { "Thorn Whip", "" },
            { "Thunderclap", $"5ft radius, Con save, {CantripDmg}D6 Thunder, create 100ft thunder sound" },
            { "Thunderous Smite", "bonus, conc 1 min, Str save, next hit - dmg + 2D6 Thunder, push 10ft and knock prone, audible thunder 300ft" },
            { "Thunder Step", "" },
            { "Thunder Wave", "" },
            { "Tidal Wave", "120ft/30ft long x 10ft x 10ft, Dex save, 4D8 Bludgeoning or 1/2, knock prone, water spreads out 30ft - extinguishing fires" },
            { "Time Ravage", "" },
            { "Time Stop", "" },
            { "Tiny Servant", "" },
            { "Toll the Dead", "" },
            { "Tongues", "" },
            { "Transmute Rock", "120ft/40ft cube, Rock to Mud(movement cost x 4, Str save - restrain, action to end OR Dex save, 4D8 Bludgeoning or 1/2)" +
                "\n     Mud to Rock(Dex save, restrain - Str DC 20 or 25 dmg to escape)" },
            { "Transport via Plants", "" },
            { "Tree Stride", "" },
            { "True Polymorph", "" },
            { "True Resurrection", "" },
            { "True Seeing", "" },
            { "True Strike", "" },
            { "Tsunami", "" },
            { "Unseen Servant", "" },
            { "Vampiric Touch", "" },
            { "Vicious Mockery", "" },
            { "Vitriolic Sphere", "150ft/20ft radius, Dex save, 10D4 Acid or 1/2, 5D4 Acid next turn, higher lvls" },
            { "Wall of Fire", "" },
            { "Wall of Force", "" },
            { "Wall of Ice", "" },
            { "Wall of Light", "" },
            { "Wall of Sand", "90ft/30ft long x 10ft x 10ft, conc 10 min, heavily obscures, movement cost x 3" },
            { "Wall of Stone", "" },
            { "Wall of Thorns", "" },
            { "Wall of Water", "60ft/30ft long/10ft high/1ft thick or ring 20ft diameter/20ft high, difficult terrain, impose disadv on ranged atks, 1/2 Fire dmg" +
                "\n     Cold dmg causes AC 5, HP 15, destroyed section doesn't fill with water" },
            { "Warding Bond", "" },
            { "Warding Wind", "10ft radius, conc 10 min, 20mph wind, deafens, extinguishes small flames, difficult terrain, impose disadv on ranged atks, disperses gases/vapors/fog" },
            { "Waterbreathing", "" },
            { "Water Walk", "" },
            { "Watery Sphere", "90ft/10ft radius, conc 1 min, Str save, Huge or larger auto-succeeds, restrain and knock prone 4 Medium creatures or 1 Large" },
            { "Web", "" },
            { "Weird", "" },
            { "Whirlwind", "300ft/10ft radius/30ft high, Dex save, 10D6 Bludgeoning or 1/2, sucks up Medium or smaller objects / action to move 30ft" +
                "\n     Large or smaller creature, Str save, restrain - Str or Dex to escape, hurled 3D6 x 10ft in random direction" },
            { "Wind Walk", "" },
            { "Wish", "" },
            { "Witch Bolt", "" },
            { "Word of Radiance", "" },
            { "Word of Recall", "" },
            { "Wrath of Nature", "" },
            { "Wrathful Smite", "" },
            { "Wristpocket", "" },
            { "Zephyr Strike", "" },
            { "Zone of Truth", "60ft/15ft radius, 10 min, Cha save, can't tell a deliberate lie, you know if they fail/succeed save, creatures are aware of spell" }
        };
    }
}
