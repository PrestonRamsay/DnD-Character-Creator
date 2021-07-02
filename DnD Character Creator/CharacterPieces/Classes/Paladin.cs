using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Paladin
    {
        public static string SacredOath { get; set; }
        public static void Base(Character character)
        {
            List<string> classSkills = new List<string> { "Athletics", "Insight", "Intimidation", "Medicine", "Persuasion", "Religion" };

            character.GP += 125;
            character.HitDie = 10;
            character.Proficiencies.Add("Light armor");
            character.Proficiencies.Add("Medium armor");
            character.Proficiencies.Add("Heavy armor");
            character.Proficiencies.Add("Shields");
            character.Proficiencies.Add("Simple weapons");
            character.Proficiencies.Add("Martial weapons");
            character.Saves.Add("Wis");
            character.Saves.Add("Cha");

            BEHelper.GetSkills(character, classSkills, 2);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Any martial weapon and a shield", "Two martial weapons");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("5 Javelins", "Any simple weapon");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Priest's Pack", "Explorer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                BEHelper.AddMartialWeapon(character);
                character.Equipment.Add("Shield(+2 AC)(10gp, 6lb.)");
            }
            else
            {
                BEHelper.AddMartialWeapon(character);
                BEHelper.AddMartialWeapon(character);
            }
            if (input2 == 1)
            {
                character.Equipment.Add($"5 {Options.SimpleMeleeWeapons[4]}");
            }
            else
            {
                BEHelper.AddSimpleWeapon(character);
            }
            if (input3 == 1)
            {
                character.Equipment.Add(Options.Packs[5]);
            }
            else
            {
                character.Equipment.Add(Options.Packs[4]);
            }

            character.Equipment.Add(Options.HeavyArmor[3]);
            BEHelper.AddHolySymbol(character);
        }
        public static Dictionary<int, List<string>> OathSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() }
        };
        public static void Features(Character character)
        {
            int lvl = character.Lvl;
            character.Tenets = new List<string> { "Bravery", "Content", "Honesty", "Honor", "Humility", "Kindness", "Leadership",
                "Piety", "Respect", "Tolerance", "Unselfishness", "Utilitarian" };

            character.ClassFeatures.Add("Divine Sense","action, 60ft, 1 + Cha/LR, know location and type of celestials, fiend, undead");
            character.ClassFeatures.Add("Lay on Hands", "heal lvl x 5 HP");

            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Divine Smite", "2D8 Radiant + 1D8/lvl(above 1), +1D8 if undead/fiend");
                character.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use a Holy Symbol as a spell focus");
                string fightStyleMsg = "Pick a fighting style.";
                List<string> styleList = new List<string> { "Blessed Warrior", "Blind Fighting", "Defense", "Dueling", "Great Weapon Fighting",
                    "Interception", "Protection" };
                string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                string fightStyleKey = $"Fighting Style({fightStyle})";
                string fightStyleValue = Options.FightingStyles[fightStyle];
                character.ClassFeatures.Add(fightStyleKey, fightStyleValue);
                if (fightStyle == "Blessed Warrior")
                {
                    Console.WriteLine("Pick two cantrips from the Cleric's list");
                    string cantrip = CLIHelper.PrintChoices(ClericSpells.Cantrips);
                    character.Cantrips.Add(cantrip);
                    cantrip = CLIHelper.PrintChoices(ClericSpells.Cantrips);
                    character.Cantrips.Add(cantrip);
                }
            }
            if (lvl >= 3)
            {
                character.ClassFeatures.Add("Divine Health", "gain Immunity to disease");
                int uses = 1;
                for (int i = 7; i <= lvl; i += 8)
                {
                    uses++;
                }
                character.ClassFeatures.Add("Harness Divine Power", $"{uses}/LR, bonus, expend a Channel Divinity use to regain a spell slot = 1/2 PB");
                character.ClassFeatures.Add("Channel Divinity uses", "1/SR");
                string msg = "Pick a Sacred Oath that will give you features at levels 3, 7, 15, and 20.";
                var archetype = new List<string> { "Oath of the Ancients", "Oath of Conquest", "Oath of the Crown", "Oath of Devotion",
                    "Oath of Glory", "Oath of Redemption", "Oath of Vengeance", "Oath of the Watchers", "Oathbreaker" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                if (answer == 0 || answer == 2 || answer == 7)
                {
                    SacredOath = archetype[answer].Substring(12);
                }
                else if (answer == 8)
                {
                    SacredOath = "Oathbreaker";
            }
                else
                {
                    SacredOath = archetype[answer].Substring(8);
                }

                switch (SacredOath)
                {
                    case "Ancients":
                        Ancients(character);
                        break;
                    case "Conquest":
                        Conquest(character);
                        break;
                    case "Crown":
                        Crown(character);
                        break;
                    case "Devotion":
                        Devotion(character);
                        break;
                    case "Glory":
                        Glory(character);
                        break;
                    case "Oathbreaker":
                        Oathbreaker(character);
                        break;
                    case "Redemption":
                        Redemption(character);
                        break;
                    case "Vengeance":
                        Vengeance(character);
                        break;
                    case "Watchers":
                        Watchers(character);
                        break;
                }
            }
            if (lvl >= 4)
            {
                character.ClassFeatures.Add("Martial Versatility", "When you gain an Ability Score Improvement, you can replace a Fighting Style");
            }
            if (lvl >= 5)
            {
                character.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Aura of Protection", "10ft, saves + Cha");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Aura of Courage", "10ft, can't be frightened");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Improved Divine Smite", "all melee +1D8 Radiant");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Cleansing Touch", "action, Cha/LR, dispel on creatures");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures["Aura of Protection"] = "30ft, saves + Cha";
                character.ClassFeatures["Aura of Courage"] = "30ft, can't be frightened";
                switch (SacredOath)
                {
                    case "Ancients":
                        character.ClassFeatures["Aura of Warding"] = "30ft, Resistance to spell dmg";
                        break;
                    case "Devotion":
                        character.ClassFeatures["Aura of Devotion"] = "30ft, gain Immunity to charm";
                        break;
                    case "Glory":
                        character.ClassFeatures["Aura of Alacrity"] = "10ft, allies' speed +10ft";
                        break;
                    case "Oathbreaker":
                        character.ClassFeatures["Aura of Hate"] = "30ft, fiends and undead dmg + Cha";
                        break;
                    case "Redemption":
                        character.ClassFeatures["Aura of Guardian"] = "30ft, reaction, take ally dmg instead";
                        break;
                    case "Watchers":
                        character.ClassFeatures["Aura of the Sentinel"] = "30ft, Init + PB";
                        break;
                }
            }
            Spells(character);
        }
        public static void Ancients(Character character)
        {
            int lvl = character.Lvl;
            var tenets = new List<string> { "Be the Light*", "Kindle the Light*", "Preserve Your Own Light*", "Shelter the Light*" };
            character.Tenets.AddRange(tenets);
            OathSpells[1].Add("Ensnaring Strike*");
            OathSpells[1].Add("Speak with Animals*");
            OathSpells[2].Add("Misty Step*");
            OathSpells[2].Add("Moonbeam*");
            OathSpells[3].Add("Plant Growth*");
            OathSpells[3].Add("Protection from Energy*");
            OathSpells[4].Add("Ice Storm*");
            OathSpells[4].Add("Stoneskin*");
            OathSpells[5].Add("Commune with Nature*");
            OathSpells[5].Add("Tree Stride*");

            character.ClassFeatures.Add("Channel Divinity(Nature's Wrath)", "action, 10ft, Str/Dex save - restrain");
            character.ClassFeatures.Add("Channel Divinity(Turn the Faithless)", "action, 30ft, 1min, Wis save, turn fiend/fey");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Aura of Warding", "10ft, Resistance to spell dmg");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Undying Sentinel", "LR, when you drop to 0 HP - drop to 1 HP instead");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Elder Champion", "action, 1min, transform - regen 10, spells as bonus, enemies in 10ft" +
                    "\n        disadv vs paladin spells/channel divinity");
            }
        }
        public static void Conquest(Character character)
        {
            int lvl = character.Lvl;
            var tenets = new List<string> { "Douse the Flame of Hope*", "Rule with an Iron Fist*", "Strength Above All*" };
            character.Tenets.AddRange(tenets);
            OathSpells[1].Add("Armor of Agathys*");
            OathSpells[1].Add("Command*");
            OathSpells[2].Add("Hold Person*");
            OathSpells[2].Add("Spiritual Weapon*");
            OathSpells[3].Add("Bestow Curse*");
            OathSpells[3].Add("Fear*");
            OathSpells[4].Add("Dominate Beast*");
            OathSpells[4].Add("Stoneskin*");
            OathSpells[5].Add("Cloudkill*");
            OathSpells[5].Add("Dominate Person*");

            character.ClassFeatures.Add("Channel Divinity(Conquering Presence)", "action, 30ft, Wis save, 1 min, fear");
            character.ClassFeatures.Add("Channel Divinity(Guided Strike)", "+10 atk on 1 roll, before determine hit or miss");
            if (lvl >= 7)
            {
                int aura = 10;
                if (lvl >= 18)
                {
                    aura = 30;
                }
                character.ClassFeatures.Add("Aura of Conquest", $"{aura}ft, if creature has fear, speed = 0, Psychic dmg = 1/2 lvl");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Scornful Rebuke", "When hit, attacker takes Cha Psychic dmg");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Invincible Conqueror", "LR, action, 1 min, gain Resistance to all dmg, Attack action - gain extra atk, crit on 19 or 20");
            }
        }
        public static void Crown(Character character)
        {
            int lvl = character.Lvl;
            var tenets = new List<string> { "Courage*", "Law*", "Loyalty*", "Responsibilty*" };
            character.Tenets.AddRange(tenets);
            OathSpells[1].Add("Command*");
            OathSpells[1].Add("Compelled Duel*");
            OathSpells[2].Add("Warding Bond*");
            OathSpells[2].Add("Zone of Truth*");
            OathSpells[3].Add("Aura of Vitality*");
            OathSpells[3].Add("Spirit Guardians*");
            OathSpells[4].Add("Banishment*");
            OathSpells[4].Add("Guardian of Faith*");
            OathSpells[5].Add("Circle of Power*");
            OathSpells[5].Add("Geas*");

            character.ClassFeatures.Add("Channel Divinity(Champion Challenge)", "no action, 30ft, Wis save, can't move more than 30ft away from you");
            character.ClassFeatures.Add("Channel Divinity(Turn the Tides)", "bonus, 30ft, regain HP = 1D6 + Cha");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Divine Allegiance", "reaction, if adj ally takes dmg, you take the dmg instead");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Unyielding Spirit", "adv on saves vs paralyze or stun");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Exalted Champion", "action, 1 hr, Resist nonmagical B/P/S, adv on Wis saves, 30ft - allies gain adv on Wis and death saves");
            }
        }
        public static void Devotion(Character character)
        {
            int lvl = character.Lvl;
            var tenets = new List<string> { "Compassion*", "Courage*", "Duty*" };
            character.Tenets.AddRange(tenets);
            OathSpells[1].Add("Protection from Evil and Good*");
            OathSpells[1].Add("Sanctuary*");
            OathSpells[2].Add("Lesser Restoration*");
            OathSpells[2].Add("Zone of Truth*");
            OathSpells[3].Add("Beacon of Hope*");
            OathSpells[3].Add("Dispel Magic*");
            OathSpells[4].Add("Freedom of Movement*");
            OathSpells[4].Add("Guardian of Faith*");
            OathSpells[5].Add("Commune*");
            OathSpells[5].Add("Flame Strike*");

            character.ClassFeatures.Add("Channel Divinity(Sacred Weapon)", "action, 1 min, atk + Cha, magical, bright 20ft/dim 20ft");
            character.ClassFeatures.Add("Channel Divinity(Turn the Unholy)", "action, 30ft, 1min, Wis save, turn fiend/undead");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Aura of Devotion", "10ft, gain Immunity to charm");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Purity of Spirit", "constant Protection from Evil and Good");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Holy Nimbus", "LR, action, 1 min, bright 30ft/dim 30ft - start in bright 10 Radiant dmg," +
                    "\n        adv on saves vs fiend/undead spells");
            }
        }
        public static void Glory(Character character)
        {
            int lvl = character.Lvl;
            var tenets = new List<string> { "Actions over Words*", "Challenges Are but Tests*", "Hone the Body*", "Discipline the Soul*" };
            character.Tenets.AddRange(tenets);
            OathSpells[1].Add("Guiding Bolt*");
            OathSpells[1].Add("Heroism*");
            OathSpells[2].Add("Enhance Ability*");
            OathSpells[2].Add("Magic Weapon*");
            OathSpells[3].Add("Haste*");
            OathSpells[3].Add("Protection from Energy*");
            OathSpells[4].Add("Compulsion*");
            OathSpells[4].Add("Freedom of Movement*");
            OathSpells[5].Add("Commune*");
            OathSpells[5].Add("Flame Strike*");

            character.ClassFeatures.Add("Channel Divinity(Peerless Athlete)", "bonus, 10 min, gain adv on Acrobatics and Athletics, push/lift/drag twice as much, jump distance +10ft");
            character.ClassFeatures.Add("Channel Divinity(Inspiring Smire)", "bonus, 30ft, after smiting, distribute temp HP = 2D8 + lvl among you and allies");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Aura of Alacrity", "adj allies gain speed +10ft");
                character.Speed += 10;
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Glorious Defense", "Cha/LR, reaction, 10ft, when you or ally is hit, AC + Cha - if atk misses, make atk if within range");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Living Legend", "LR or 5th lvl spell slot, bonus, 1 min, gain adv on Cha checks / 1/turn - on miss, atk hits instead / reaction, reroll a save");
            }
        }
        public static void Oathbreaker(Character character)
        {
            int lvl = character.Lvl;
            var tenets = new List<string> { "Ambition*", "Corruption*", "Fear*", "Hatred*", "Honorless*", "Power*", "Villainous*" };
            character.Tenets.Clear();
            character.Tenets.AddRange(tenets);
            OathSpells[1].Add("Hellish Rebuke*");
            OathSpells[1].Add("Inflict Wounds*");
            OathSpells[2].Add("Crown of Madness*");
            OathSpells[2].Add("Darkness*");
            OathSpells[3].Add("Animate Dead*");
            OathSpells[3].Add("Bestow Curse*");
            OathSpells[4].Add("Blight*");
            OathSpells[4].Add("Confusion*");
            OathSpells[5].Add("Contagion*");
            OathSpells[5].Add("Dominate Person*");

            character.ClassFeatures.Add("Channel Divinity(Control Undead)", "action, 24hr, 30ft, 1 undead CR < lvl, Wis save, obeys commands");
            character.ClassFeatures.Add("Channel Divinity(Dreadful Aspect)", "action, 30ft, Wis save, fear 1 min, if more than 30ft Wis save to end");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Aura of Hate", "10ft, fiends and undead dmg + Cha");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Supernatural Resistance", "gain Resistance to nonmagical B/P/S");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Dread Lord", "LR, action, 1 min, 30ft, aura reduces bright light to dim light, if fear in aura - 4D10 Psychic dmg" +
                    "you and allies of choice impose disadv on atk / bonus, melee spell atk, 3D10 + Cha Necrotic dmg");
            }
        }
        public static void Redemption(Character character)
        {
            int lvl = character.Lvl;
            var tenets = new List<string> { "Innocence*", "Patience*", "Peace*", "Wisdom*" };
            character.Tenets.AddRange(tenets);
            OathSpells[1].Add("Sanctuary*");
            OathSpells[1].Add("Sleep*");
            OathSpells[2].Add("Calm Emotions*");
            OathSpells[2].Add("Hold Person*");
            OathSpells[3].Add("Counterspell*");
            OathSpells[3].Add("Hypnotic Pattern*");
            OathSpells[4].Add("Otiluke’s Resilient Sphere*");
            OathSpells[4].Add("Stoneskin*");
            OathSpells[5].Add("Hold Monster*");
            OathSpells[5].Add("Wall of Force*");

            character.ClassFeatures.Add("Channel Divinity(Emissary of Peace)", "bonus, 10min, +5 Persuasion");
            character.ClassFeatures.Add("Channel Divinity(Rebuke the Violent)", "30ft, ally takes dmg, Wis save - 1/2 Radiant dmg on fail");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Aura of Guardian", "10ft, reaction, take ally dmg instead");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Protective Spirit", "when bloodied, regen 1D6 + 1/2 lvl");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Emissary of Redemption", "Resist all dmg, when hit deal 1/2 Radiant dmg");
            }
        }
        public static void Vengeance(Character character)
        {
            int lvl = character.Lvl;
            var tenets = new List<string> { "Fight the Greater Evil*", "No Mercy for the Wicked*", "By Any Means Necessary*", "Restitution*" };
            character.Tenets.AddRange(tenets);
            OathSpells[1].Add("Bane*");
            OathSpells[1].Add("Hunter's Mark*");
            OathSpells[2].Add("Hold Person*");
            OathSpells[2].Add("Misty Step*");
            OathSpells[3].Add("Haste*");
            OathSpells[3].Add("Protection from Energy*");
            OathSpells[4].Add("Banishment*");
            OathSpells[4].Add("Dimension Door*");
            OathSpells[5].Add("Hold Monster*");
            OathSpells[5].Add("Scrying*");

            character.ClassFeatures.Add("Channel Divinity(Abjure Enemy)", "action, 60ft, 1 creature, Wis save, fear & speed = 0");
            character.ClassFeatures.Add("Channel Divinity(Vow of Enmity)", "bonus, 10ft, 1 min, adv on atks vs 1 creature");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Relentless Avenger", "op atk hit, move 1/2 speed no atk ops");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Soul of Vengeance", "reaction, if vow of enmity tar atks, melee weapon atk");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Avenging Angel", "action, 1hr, wings(fly 60ft), aura of menace 30ft - Wis save, fear 1 min");
            }
        }
        public static void Watchers(Character character)
        {
            int lvl = character.Lvl;
            var tenets = new List<string> { "Vigilance*", "Loyalty*", "Discipline*" };
            character.Tenets.AddRange(tenets);
            OathSpells[1].Add("Alarm*");
            OathSpells[1].Add("Detect Magic*");
            OathSpells[2].Add("Moonbeam*");
            OathSpells[2].Add("See Invisibilty*");
            OathSpells[3].Add("Counterspell*");
            OathSpells[3].Add("Nondetection*");
            OathSpells[4].Add("Aura of Purity*");
            OathSpells[4].Add("Banishment*");
            OathSpells[5].Add("Hold Monster*");
            OathSpells[5].Add("Scrying*");

            character.ClassFeatures.Add("Channel Divinity(Watcher's Will)", "action, 1 min, 30ft, Cha creatures, gain adv on Int, Wis, and Cha saves");
            character.ClassFeatures.Add("Channel Divinity(Abjure the Extraplanar)", "action, 1 min, 30ft, Wis save - turn all aberration/celestial/elemental/fey/fiend");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Aura of the Sentinel", "10ft, Init + PB");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Vigilant Rebuke", "reaction, 30ft, when you or ally succeeds on Int, Wis or Cha save - deal 2D8 + Cha Force dmg to whoever forced the save");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Mortal Bulwark", "LR or 5th lvl spell slot, bonus, 1 min, gain Truesight 120ft, gain adv on atks vs aberrations/celestials/elementals/fey/fiends" +
                    "\n        when you deal dmg, Cha save, banish creature to its native plane of existence for 24hr");
            }
        }
        public static void Spells(Character character)
        {
            BEHelper.AddSecSpells(character, OathSpells);
            string pickMsg = "Pick a 1st level spell.";
            AllSpells spells = new AllSpells("Paladin");
            foreach (var slotLvl in character.SpellSlots.Keys)
            {
                if (slotLvl == 2)
                {
                    pickMsg = "Pick a 2nd level spell.";
                }
                if (slotLvl == 3)
                {
                    pickMsg = "Pick a 3rd level spell.";
                }
                if (slotLvl >= 4)
                {
                    pickMsg = $"Pick a {slotLvl}th level spell.";
                }
                int slots = character.SpellSlots[slotLvl];
                for (int i = 0; i < slots; i++)
                {
                    string spell = CLIHelper.GetNew(spells.Paladin[slotLvl], character.Spells[slotLvl], pickMsg);
                    character.Spells[slotLvl].Add(spell);
                    spells.Paladin[slotLvl].Remove(spell);
                }
            }
        }
    }
}
