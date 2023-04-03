using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    public class AllSpells
    {
        public AllSpells(string classStr)
        {
            switch (classStr)
            {
                case "Cleric":
                    Stat = "Cha";
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
                    GetSpellDesc(Cleric);
                    break;
                //for Sorceror only ^^
                case "Sorcerer":
                    Stat = "Cha";
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
                    GetSpellDesc(Sorcerer);
                    break;
                case "Wizard":
                    Stat = "Wis";
                    Wizard.Add(0, WizardSpells.Cantrips);
                    Wizard.Add(6, WizardSpells.SixthLvls);
                    Wizard.Add(7, WizardSpells.SeventhLvls);
                    Wizard.Add(8, WizardSpells.EigthLvls);
                    Wizard.Add(9, WizardSpells.NinthLvls);
                    GetSpellDesc(Wizard);
                    break;
                //for Cleric only ^^
            }
        }
        public AllSpells(Character character)
        {
            Lvl = character.Lvl;
            string classStr = character.ChosenClass;
            string archetype = character.Archetype;
            if (classStr == "Artificer" || classStr == "Fighter" || classStr == "Rogue" || classStr == "Wizard")
            {
                Stat = "Int";
            }
            else if (classStr == "Bloodhunter" || classStr == "Cleric" || classStr == "Druid" || classStr == "Ranger")
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
                    GetSpellDesc(Artificer);
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
                    GetSpellDesc(Bard);
                    break;
                case "Bloodhunter":
                    Warlock.Add(0, WarlockSpells.Cantrips);
                    Warlock.Add(1, WarlockSpells.FirstLvls);
                    Warlock.Add(2, WarlockSpells.SecondLvls);
                    Warlock.Add(3, WarlockSpells.ThirdLvls);
                    Warlock.Add(4, WarlockSpells.FourthLvls);
                    GetSpellDesc(Warlock);
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
                    GetSpellDesc(Cleric);
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
                    GetSpellDesc(Druid);
                    break;
                case "Fighter":
                    Fighter.Add(0, FighterSpells.Cantrips);
                    Fighter.Add(1, FighterSpells.FirstLvls);
                    Fighter.Add(2, FighterSpells.SecondLvls);
                    Fighter.Add(3, FighterSpells.ThirdLvls);
                    Fighter.Add(4, FighterSpells.FourthLvls);
                    GetSpellDesc(Fighter);
                    Wizard.Add(0, WizardSpells.Cantrips);
                    Wizard.Add(1, WizardSpells.FirstLvls);
                    Wizard.Add(2, WizardSpells.SecondLvls);
                    Wizard.Add(3, WizardSpells.ThirdLvls);
                    Wizard.Add(4, WizardSpells.FourthLvls);
                    GetSpellDesc(Wizard);
                    break;
                case "Paladin":
                    Paladin.Add(1, PaladinSpells.FirstLvls);
                    Paladin.Add(2, PaladinSpells.SecondLvls);
                    Paladin.Add(3, PaladinSpells.ThirdLvls);
                    Paladin.Add(4, PaladinSpells.FourthLvls);
                    Paladin.Add(5, PaladinSpells.FifthLvls);
                    GetSpellDesc(Paladin);
                    break;
                case "Ranger":
                    Ranger.Add(1, RangerSpells.FirstLvls);
                    Ranger.Add(2, RangerSpells.SecondLvls);
                    Ranger.Add(3, RangerSpells.ThirdLvls);
                    Ranger.Add(4, RangerSpells.FourthLvls);
                    Ranger.Add(5, RangerSpells.FifthLvls);
                    GetSpellDesc(Ranger);
                    break;
                case "Rogue":
                    Rogue.Add(0, RogueSpells.Cantrips);
                    Rogue.Add(1, RogueSpells.FirstLvls);
                    Rogue.Add(2, RogueSpells.SecondLvls);
                    Rogue.Add(3, RogueSpells.ThirdLvls);
                    Rogue.Add(4, RogueSpells.FourthLvls);
                    GetSpellDesc(Rogue);
                    Wizard.Add(0, WizardSpells.Cantrips);
                    Wizard.Add(1, WizardSpells.FirstLvls);
                    Wizard.Add(2, WizardSpells.SecondLvls);
                    Wizard.Add(3, WizardSpells.ThirdLvls);
                    Wizard.Add(4, WizardSpells.FourthLvls);
                    GetSpellDesc(Wizard);
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
                    GetSpellDesc(Psion);
                    break;
                case "Swordmage":
                    Swordmage.Add(0, SwordmageSpells.Cantrips);
                    Swordmage.Add(1, SwordmageSpells.FirstLvls);
                    Swordmage.Add(2, SwordmageSpells.SecondLvls);
                    Swordmage.Add(3, SwordmageSpells.ThirdLvls);
                    Swordmage.Add(4, SwordmageSpells.FourthLvls);
                    Swordmage.Add(5, SwordmageSpells.FifthLvls);
                    GetSpellDesc(Swordmage);
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
                    GetSpellDesc(Warlock);
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
            "Green-Flame Blade",
            "Guidance",
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
        public static Dictionary<int, List<string>> GetSpellDesc(Dictionary<int, List<string>> castingClass)
        {
            for (int spellLvl = 0; spellLvl < castingClass.Count; spellLvl++)
            {
                if (castingClass.ContainsKey(spellLvl))
                {
                    for (int spellIndex = 0; spellIndex < castingClass[spellLvl].Count; spellIndex++)
                    {
                        string spell = castingClass[spellLvl][spellIndex];

                        if (Descriptions.ContainsKey(spell))
                        {
                            castingClass[spellLvl][spellIndex] += $": {Descriptions[spell]}";
                        }
                    }
                }
            }
            
            var tempDict = new Dictionary<int, List<string>>();
            var tempList = new List<string>();

            foreach (var item in castingClass.Keys)
            {
                tempDict.Add(item, castingClass[item]);
            }
            foreach (int spellLvl in tempDict.Keys)
            {
                tempList.Clear();
                tempList.AddRange(castingClass[spellLvl]);
                foreach (string spell in tempList)
                {
                    if (Descriptions.ContainsKey(spell))
                    {
                        int index = tempList.IndexOf(spell);
                        castingClass[spellLvl][index] += $": {Descriptions[spell]}";
                    }
                }
            }

            return castingClass;
        }
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
                "\n     if D8s are both the same number: 30ft, ranged spell atk vs new target, repeat dmg/effect, higher lvls" },
            { "Charm Monster", "30ft, 1hr, Wis save, target gains adv if fighting the party, charms to be friendly, higher lvls" },
            { "Charm Person", "" },
            { "Chill Touch", $"120ft, ranged spell atk, {CantripDmg}D8 Necrotic" },
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
            { "Compelled Duel", "30ft, conc 1 min, 1 creature, Wis save, impose disadv on atk vs not you, Wis save to move when outside of 30ft radius" },
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
            { "Counterspell", $"reaction, 60ft, 3rd or lower - spell fails, 4th or higher - {Stat} DC 10 + spell lvl, higher lvls" },
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
            { "Dancing Lights", "120ft, conc 1 min, create 4 orbs - dim light 10ft, bonus move lights 60ft, lights must be within 20ft of each other" },
            { "Danse Macabre", $"60ft, conc 1hr, 5 Small or Medium corpses, each becomes zombie or skeleton: atk/dmg + {Stat} / bonus, 60ft, mentally command, higher lvls" },
            { "Dark Star", "" },
            { "Darkness", "60ft/15ft radius, conc 10 min, can't be see through with Darkvision, dispels 2nd or lower light spells" },
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
            { "Dispel Magic", $"120ft, 1 creature/object/effect, 3rd lvl or lower - spells ends, 4th or higher - {Stat} DC 10 + spell lvl, higher lvls" },
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
            { "Druidcraft", "30ft, pick an effect - 1 round, create a tiny prediction of weather for the day(24hr) / make a seed open or flower/leaf bud bloom" +
                "\n     5ft cube, create a harmless sensory effect the reproduces nature / light or snuff out a candle, torch, or small campfire" },
            { "Dust Devil", "60ft, conc 1 min, adj creatures, Str save, 1D8 Bludgeoning or 1/2, push 10ft / bonus, move 30ft - 10ft radius heavily obscures, higher lvls" },
            { "Earthbind", "300ft, conc 1 min, Str save, reduce Fly speed to 0, descend 60ft/round" },
            { "Earth Tremor", "10ft radius, Dex save, 1D6 Bludgeoning, knock prone, higher lvls" },
            { "Earthquake", "" },
            { "Eldritch Blast", $"120ft, ranged spell atk, make {CantripDmg} atks against up to {CantripDmg} creatures, beams deal 1D10 Force" },
            { "Elemental Bane", "90ft, conc 1 min, Con save, choose Acid/Cold/Fire/Lightning/Thunder, negate Resistance, next hit with dmg type + 2D6, higher lvls" },
            { "Elemental Weapon", "" },
            { "Encode Thoughts", "up to 8hr, create a Tiny/weightless/semisolid thought strand of a memory/idea/message, if used with spells like 'Detect Thoughts" +
                "\n     or 'Modify Memory' you can transform thought strand into the target's, you can receive info from thought strands with this spell or 'Detect Thoughts'" },
            { "Enemies Abound", "120ft, conc 1 min, Int save, if Immunity to fear: auto-success, views all creatures as hostile, targets randomly, makes op atks" },
            { "Enervation", "60ft, conc 1 min, Dex save, 4D8 Necrotic or 2D8 Necrotic / action, deal 4D8 Necrotic / heal HP = 1/2 Necrotic dmg" },
            { "Enhance Ability", "touch, conc 1hr, pick an effect - Bull's Strength(adv on Str checks, double carrying capacity)" +
                "\n     Cat's Grace(adv on Dex checks, no fall dmg 20ft or less), Bear's Endurance(adv on Str checks, gain 2D6 temp HP), Fox's Cunning(adv on Int checks)" +
                "\n     Owl's Wisdom(adv on Wis checks), Eagle's Splendor(adv on Cha checks), higher lvls" },
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
            { "Faerie Fire", "60ft/20ft cube, conc 1 min, Dex save, objects and creatures are outlined in colored dim light 10ft" +
                "outlined creatures can't be invisible and grant adv on atks vs them" },
            { "False Life", "1hr, gain 1D4 + 4 temp HP, higher lvls" },
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
            { "Fire Bolt", $"120ft, ranged spell atk, {CantripDmg}D10 Fire" },
            { "Fire Shield", "" },
            { "Firestorm", "" },
            { "Fireball", "150ft/20ft radius, Dex save, 8D6 Fire or 1/2, higher lvls" },
            { "Flame Arrows", "touch, conc 1hr, imbue 12 pieces of ammo, dmg + 1D6 Fire, higher lvls(more ammo)" },
            { "Flame Blade", "" },
            { "Flame Strike", "" },
            { "Flaming Sphere", "" },
            { "Flesh to Stone", "" },
            { "Flock of Familiars", "" },
            { "Fly", "touch, conc 10 min, 1 creature, gain Fly 60ft, higher lvls" },
            { "Fog Cloud", "" },
            { "Forbiddance", "" },
            { "Forcecage", "" },
            { "Foresight", "" },
            { "Fortune's Favor", "" },
            { "Freedom of Movement", "" },
            { "Freezing Sphere", "" },
            { "Friends", "conc 1 min, 1 creature, gain adv on all Cha checks, after duration the creature becomes hostile" },
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
            { "Guiding Bolt", "120ft, ranged spell atk, 4D6 Radiant and gain adv on next atk vs target" },
            { "Gust", "30ft, choose 1 of 3 effects: (1)Str save, push 5ft (2)not worn/carried 5lb object, push 10ft (3)harmless sensory effect using air" },
            { "Gust of Wind", "" },
            { "Hail of Thorns", "" },
            { "Hallow", "" },
            { "Hallucinatory Terrain", "" },
            { "Harm", "" },
            { "Haste", "" },
            { "Heal", "" },
            { "Healing Spirit", "" },
            { "Healing Word", $"bonus, 60ft, heal 1D4 + {Stat} HP" },
            { "Heat Metal", "" },
            { "Hellish Rebuke", "" },
            { "Heroes' Feast", "" },
            { "Heroism", $"touch, conc 1 min, 1 creature, gain Immunity to fear and temp HP = {Stat} & 1/turn, gain temp HP = {Stat}" },
            { "Hex", "bonus, 90ft, conc 1hr, 1 creature, dmg + 1D6 Necrotic, if target drops to 0 HP, mark a new target, higher lvls" },
            { "Hold Monster", "" },
            { "Hold Person", "" },
            { "Holy Aura", "" },
            { "Holy Weapon", "" },
            { "Hunger of Hadar", "" },
            { "Hunter's Mark", "bonus, 90ft, conc 1hr, 1 creature, dmg + 1D6 wep dmg, gain adv on Perception and Survival, if target drops to 0 HP, mark a new target, higher lvls" },
            { "Hypnotic Pattern", "" },
            { "Ice Knife", "60ft, ranged spell atk, 1D10 Piercing / target and adj creatures, Dex save, 2D6 Cold, higher lvls" },
            { "Ice Storm", "300ft, 20ft radius/40ft high, Dex save, 2D8 Bludgeoning and 4D6 Cold or 1/2, create difficult terrain 1 turn, higher lvls" },
            { "Identify", "" },
            { "Illusory Dragon", "" },
            { "Illusory Script", "" },
            { "Immolation", "90ft, conc 1 min, Dex save, 7D6 Fire or 1/2, bright light 30ft/dim light 30ft, 1/turn - 3D6 Fire, can't be nonmagically extinguished" },
            { "Immovable Object", "" },
            { "Imprisonment", "" },
            { "Incediary Cloud", "" },
            { "Incite Greed", "" },
            { "Infernal Calling", "" },
            { "Infestation", $"30ft, Con save, create cloud of mites/fleas/parasites, {CantripDmg}D6 Poison, uses 5ft to move randomly, 1D4 for direction - 1(N) 2(S) 3(E) 4(W)" },
            { "Inflict Wounds", "" },
            { "Insect Plague", "" },
            { "Intellect Fortress", "" },
            { "Investiture of Flame", "self, conc 10 min, gain Immunity to Fire and Resistance to Cold, bright light 30ft/dim light 30ft" +
                "\n     adj creatures take 1D10 Fire / action, 15ft line, Dex save, 4D8 Fire or 1/2" },
            { "Investiture of Ice", "self, conc 10 min, gain Immunity to Cold and Resistance to Fire, ignore difficult terrain from ice/snow" +
                "\n     10ft radius, creates icy difficult terrain / action, 15ft cone, Con save, 4D6 Cold or 1/2" },
            { "Investiture of Stone", "self, conc 10 min, gain Resistance to nonmagical B/P/S, ignore difficult terrain of stone, move through stone like air" +
                "\n     can't end turn inside stone - ejected and stunned / action, 15ft radius, Dex save, knock prone" },
            { "Investiture of Wind", "self, conc 10 min, impose disadv on ranged atks, gain Fly 60ft / action, 60/15ft cube, Con save, 2D10 Bludgeoning, push Large 10ft" },
            { "Invisibility", "" },
            { "Invulnerability", "conc 10 min, gain Immunity to all dmg" },
            { "Jim's Glowing Coin", "" },
            { "Jim's Magic Missile", "" },
            { "Jump", "" },
            { "Knock", "" },
            { "Legend Lore", "" },
            { "Leomund's Secret Chest", "" },
            { "Leomund's Tiny Hut", "" },
            { "Lesser Restoration", "" },
            { "Levitate", "60ft, conc 10 min, 1 creature or object up to 500 lbs, Con save, lift 20ft in air / action(or part of move), change altitude 20ft" },
            { "Life Transference", "30ft, 1 ally, take 4D8 Necrotic dmg then heal ally HP = dmg x 2, higher lvls" },
            { "Light", "touch, 1hr, 10ft obj, Dex save(if hostile), create bright light 20ft/dim light 20ft" },
            { "Lightning Arrow", "" },
            { "Lightning Bolt", "100ft line, Dex save, 8D6 Lightning or 1/2, ignites flammable objects, higher lvls" },
            { "Lightning Lure", $"15ft, Str save, {CantripDmg}D8 Lightning, pull 10ft" },
            { "Locate Animals or Plants", "" },
            { "Locate Creature", "" },
            { "Locate Object", "1000ft, conc 10 min, an object you've seen within 30ft or a kind of object, blocked by lead, learn its direction and if moving its movement direction" },
            { "Longstrider", "" },
            { "Maddening Darkness", "150ft/60ft radius, conc 10 min, Wis save, 8D8 Psychic or 1/2, can't be negated by darkvision or non-9th lvl light spells" },
            { "Maelstrom", "120ft/30ft radius, conc 1 min, Str save, 6D6 Bludgeoning, pull 10ft to center, difficult terrain" },
            { "Mage Armor", "" },
            { "Mage Hand", "30ft, 1 min, create hand / 30ft, action, move hand, pick an option - manipulate an obj, open unlocked door/container," +
                "\n     stow/retrieve an item from an open container, or pour contents from vial (can't attack, use magic items, or carry more than 10lb.)" },
            { "Magic Circel", "" },
            { "Magic Jar", "" },
            { "Magic Missile", "120ft, up to 3 creatures, create 3 darts that deal 1D4 + 1 Force and auto-hit, higher lvls" },
            { "Magic Mouth", "" },
            { "Magic Stone", $"bonus, 1 min, imbue 3 pebbles(60ft, ranged spell atk, 1D6 + {Stat} Bludgeoning)" },
            { "Magic Weapon", "bonus, conc 1hr, a nonmagical weapon becomes magical and gains +1 atk/dmg, higher lvls" },
            { "Magnify Gravity", "" },
            { "Major Image", "" },
            { "Mass Cure Wounds", "" },
            { "Mass Heal", "" },
            { "Mass Healing Word", "" },
            { "Mass Polymorph", "120ft, conc 1hr, 10 creatures, Wis save, shapechangers auto-succeed, turn target into beast of your choice CR = 1/2 lvl" +
                "\n     targets gain temp HP = beast HP" },
            { "Mass Suggestion", "" },
            { "Maximilain's Earth Grasp", "30ft, conc 1 min, Str save, 2D6 Bludgeoning, restrain, action to move or grab new creature" },
            { "Maze", "" },
            { "Meld Into Stone", "" },
            { "Melf's Acid Arrow", "" },
            { "Melf's Minute Meteors", "120ft, conc 10 min, adj creatures, Dex save, create 6 meteors, bonus to use 1 or 2, 2D6 Fire/meteor, higher lvls" },
            { "Mending", "touch, 1 obj, repair a single, physical break/tear no bigger than 1ft" },
            { "Mental Prison", "60ft, conc 1 min, " },
            { "Message", "120ft, send a whisper telepathically that only ally can hear, they can reply the same way, doesn't have to be straight line" },
            { "Meteor Swarm", "" },
            { "Mighty Fortress", "" },
            { "Mind Blank", "" },
            { "Mind Sliver", $"60ft, 1 round, Int save, {CantripDmg}D6 Psychic, next save - 1D4" },
            { "Mind Spike", "" },
            { "Minor Illusion", "30ft, 1 min, Investigation vs DC, create sound(whisper to scream, any sound, can alter) or image(5ft cube, no sensory effects)" },
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
            { "Phantasmal Force", "60ft, conc 1 min, Int save, no undead/constructs, create 10ft cube of illusion, 1D6 Psychic, negate with Investigation" },
            { "Phantasmal Killer", "" },
            { "Phantom Steed", "" },
            { "Planar Ally", "" },
            { "Planar Binding", "" },
            { "Plane Shift", "" },
            { "Plant Growth", "" },
            { "Poison Spray", $"10ft, Con save, {CantripDmg}D12 Poison" },
            { "Polymorph", "" },
            { "Power Word Heal", "" },
            { "Power Word Kill", "" },
            { "Power Word Pain", "" },
            { "Power Word Stun", "" },
            { "Prayer of Healing", "" },
            { "Prestidigitation", "10ft, pick an effect - create a harmless sensory effect / light or snuff out a candle, torch, or small campfire" +
                "\n     clean or soil a 1ft obj / 1hr - chill, warm, or flavor 1ft of nonliving matter / create a handhel, nonmagical trinket or illusory image" +
                "\n     1hr - create a color, mark, or symbol on an obj or surface / you can use up to 3 non-instanteous options if cast multiple times" },
            { "Primal Savagery", $"melee spell atk, {CantripDmg}D10 Acid" },
            { "Primordial Ward", "conc 1 min, gain Resistance to Acid/Cold/Fire/Lightning/Thunder" +
                "\n     reaction, 1 turn, gain Immunity to 1 dmg type, lose Resistances, after end spell" },
            { "Prismatic Spray", "" },
            { "Prismatic Wall", "" },
            { "Produce Flame", $"30ft, 10 min, ranged spell attack, {CantripDmg}D8 Fire, bright light 10ft/dim light 10ft" },
            { "Programmed Illusion", "" },
            { "Project Image", "" },
            { "Protection from Energy", "" },
            { "Protection from Evil and Good", "" },
            { "Protection from Poison", "" },
            { "Psychic Scream", "" },
            { "Pulse Wave", "" },
            { "Purify Food and Drink", "10ft/5ft radius, all nonmagical food and drink become free of poison and disease" },
            { "Pyrotechnics", "60ft, create Fireworks(10ft, Con save, blind 1 turn) or Smoke(20ft radius, 1 min, heavily obscures)" },
            { "Raise Dead", "" },
            { "Rary's Telepathic Bond", "" },
            { "Ravenous Void", "" },
            { "Ray of Enfeeblement", "" },
            { "Ray of Frost", $"60ft, ranged spell atk, {CantripDmg}D8 Cold" },
            { "Ray of Sickness", "" },
            { "Reality Break", "" },
            { "Regenerate", "" },
            { "Reincarnate", "" },
            { "Remove Curse", "" },
            { "Resilient Sphere", "" },
            { "Resistance", "touch, conc 1 min, 1 creature, one save + 1D4" },
            { "Resurrection", "" },
            { "Reverse Gravity", "" },
            { "Revivify", "" },
            { "Rope Trick", "" },
            { "Sacred Flame", $"60ft, Dex save, {CantripDmg}D8 Radiant" },
            { "Sanctuary", "" },
            { "Sapping Sting", $"30ft, Con save, {CantripDmg}D4 Necrotic and knock prone" },
            { "Scatter", "" },
            { "Scorching Ray", "" },
            { "Scrying", "" },
            { "Searing Smite", "bonus, conc 1 min, next hit dmg + 1D6 Fire and Con save for ongoing 1D6 Fire, higher lvls" },
            { "See Invisibility", "" },
            { "Seeming", "" },
            { "Sending", "" },
            { "Sequester", "" },
            { "Shadow Blade", "bonus, conc 1 min, simple melee(2D8 Psychic, Finesse, Light, Thrown 20/60), if in dim light or darkness gain adv on atk" +
                "\n     if it leaves your hand it dissipates at end of turn, bonus to resummon" },
            { "Shadow of Moil", "" },
            { "Shapechange", "" },
            { "Shape Water", "30ft, 5ft cube of water, choose 1 of 4 effects: (1) move/change flow (2) 1hr, form/animate into simple shapes" +
                "\n     (3) 1hr, change color/opacity (4) 1hr, freeze water as long as no creature is occupying it" },
            { "Shatter", "" },
            { "Shield", "reaction, 1 round, +5 AC, negate dmg from Magic Missile" },
            { "Shield of Faith", "bonus, 60ft, conc 10 min, 1 creature, gain +2 AC" },
            { "Shillelagh", $"bonus, 1 min, use {Stat} for atk/dmg, wep = D8, magical" },
            { "Shocking Grasp", $"melee spell atk, {CantripDmg}D8 Lightning and can't take reactions" },
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
            { "Spare the Dying", "touch, creature at 0 HP becomes stable" },
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
            { "Thaumaturgy", "30ft, pick an effect - 1 min, voice booms 3x louder / flames flicker, brighten, dim, or change color / 1 min, cause harmless tremors" +
                "\n     create a sound of your choice / cause unlocked door or window to fly open or shut / 1 min, alter your eyes' appearance / up to 3 options if multiple casts" },
            { "Thorn Whip", $"30ft, melee spell atk, {CantripDmg}D6 Piercing, Large or smaller creatures - pull 10ft" },
            { "Thunderclap", $"5ft radius, Con save, {CantripDmg}D6 Thunder, create 100ft thunder sound" },
            { "Thunderous Smite", "bonus, conc 1 min, Str save, next hit - dmg + 2D6 Thunder, push 10ft and knock prone, audible thunder 300ft" },
            { "Thunder Step", "" },
            { "Thunder Wave", "" },
            { "Tidal Wave", "120ft/30ft long x 10ft x 10ft, Dex save, 4D8 Bludgeoning or 1/2, knock prone, water spreads out 30ft - extinguishing fires" },
            { "Time Ravage", "" },
            { "Time Stop", "" },
            { "Tiny Servant", "" },
            { "Toll the Dead", $"60ft, Wis save, {CantripDmg}D8 Necrotic or {CantripDmg}D12 Necrotic if target is below max HP" },
            { "Tongues", "" },
            { "Transmute Rock", "120ft/40ft cube, Rock to Mud(movement cost x 4, Str save - restrain, action to end OR Dex save, 4D8 Bludgeoning or 1/2)" +
                "\n     Mud to Rock(Dex save, restrain - Str DC 20 or 25 dmg to escape)" },
            { "Transport via Plants", "" },
            { "Tree Stride", "" },
            { "True Polymorph", "" },
            { "True Resurrection", "" },
            { "True Seeing", "" },
            { "True Strike", "30ft, conc 1 round, 1 target, gain adv on first atk vs target" },
            { "Tsunami", "" },
            { "Unseen Servant", "" },
            { "Vampiric Touch", "" },
            { "Vicious Mockery", $"60ft, Wis save, {CantripDmg}D4 Psychic and suffers disadv on next atk before end of its turn" },
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
            { "Warding Bond", "60ft, 1hr, 1 ally, while in radius - gain +1 AC, Resistance to all dmg / when ally takes dmg, you take equal dmg" },
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
            { "Word of Radiance", $"5ft, 1 creature, Con save, {CantripDmg}D6 Radiant" },
            { "Word of Recall", "" },
            { "Wrath of Nature", "" },
            { "Wrathful Smite", "" },
            { "Wristpocket", "" },
            { "Zephyr Strike", "" },
            { "Zone of Truth", "60ft/15ft radius, 10 min, Cha save, can't tell a deliberate lie, you know if they fail/succeed save, creatures are aware of spell" }
        };
    }
}
