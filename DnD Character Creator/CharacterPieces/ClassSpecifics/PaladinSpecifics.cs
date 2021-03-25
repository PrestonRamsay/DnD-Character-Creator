using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class PaladinSpecifics
    {
        public static string SacredOath { get; set; }
        public static Dictionary<int, List<string>> OathSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
        };
        public static CharacterClass Features(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;

            result.ClassFeatures.Add("Divine Sense","action, 60ft, 1 + Cha/LR, know location and type of celestials, fiend, undead");
            result.ClassFeatures.Add("Lay on Hands", "heal lvl x 5 HP");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Divine Smite", "2D8 Radiant + 1D8/lvl(above 1), +1D8 if undead/fiend");
                result.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use a Holy Symbol as a spell focus");
                string fightStyleMsg = "Pick a fighting style.";
                List<string> styleList = new List<string> { "Blessed Warrior", "Blind Fighting", "Defense", "Dueling", "Great Weapon Fighting",
                    "Interception", "Protection" };
                string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                string fightStyleKey = $"Fighting Style({fightStyle})";
                string fightStyleValue = Options.FightingStyles[fightStyle];
                result.ClassFeatures.Add(fightStyleKey, fightStyleValue);
                if (fightStyle == "Blessed Warrior")
                {
                    Console.WriteLine("Pick two cantrips from the Cleric's list");
                    string cantrip = CLIHelper.PrintChoices(ClericSpells.Cantrips);
                    result.Cantrips.Add(cantrip);
                    cantrip = CLIHelper.PrintChoices(ClericSpells.Cantrips);
                    result.Cantrips.Add(cantrip);
                }
            }
            if (lvl >= 3)
            {
                var tenets = new List<string>();
                result.ClassFeatures.Add("Divine Health", "gain Immunity to disease");
                int uses = 1;
                for (int i = 7; i <= lvl; i += 8)
                {
                    uses++;
                }
                result.ClassFeatures.Add("Harness Divine Power", $"{uses}/LR, bonus, expend a Channel Divinity use to regain a spell slot = 1/2 PB");
                result.ClassFeatures.Add("Channel Divinity uses", "1/SR");
                string msg = "Pick a Sacred Oath that will give you features at levels 3, 7, 15, and 20.";
                var archetype = new List<string> { "Oath of the Ancients", "Oath of Conquest", "Oath of the Crown", "Oath of Devotion",
                    "Oath of Glory*", "Oath of Redemption", "Oath of Vengeance", "Oath of the Watchers*", "Oathbreaker" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                if (answer == 0 || answer == 2 || answer == 7)
                {
                    SacredOath = archetype[answer].Substring(11);
                }
                else if (answer == 8)
                {
                    SacredOath = "Oathbreaker";
            }
                else
                {
                    SacredOath = archetype[answer].Substring(7);
                }

                switch (SacredOath)
                {
                    case "Ancients":
                        tenets = new List<string> { "Be the Light*", "Kindle the Light*", "Preserve Your Own Light*", "Shelter the Light*" };
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

                        result.ClassFeatures.Add("Channel Divinity(Nature's Wrath)", "action, 10ft, Str/Dex save - restrain");
                        result.ClassFeatures.Add("Channel Divinity(Turn the Faithless)", "action, 30ft, 1min, Wis save, turn fiend/fey");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Aura of Warding", "10ft, Resistance to spell dmg");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Undying Sentinel", "LR, when you drop to 0 HP - drop to 1 HP instead");
                        }
                        if (lvl >= 20)
                        {
                            result.ClassFeatures.Add("Elder Champion", "action, 1min, transform - regen 10, spells as bonus, enemies in 10ft" +
                                "\ndisadv vs paladin spells/channel divinity");
                        }
                        break;
                    case "Conquest":
                        tenets = new List<string> { "Douse the Flame of Hope*", "Rule with an Iron Fist*", "Strength Above All*" };
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

                        result.ClassFeatures.Add("Channel Divinity(Conquering Presence)", "action, 30ft, Wis save, 1 min, fear");
                        result.ClassFeatures.Add("Channel Divinity(Guided Strike)", "+10 atk on 1 roll, before determine hit or miss");
                        if (lvl >= 7)
                        {
                            int aura = 10;
                            if (lvl >= 18)
                            {
                                aura = 30;
                            }
                            result.ClassFeatures.Add("Aura of Conquest", $"{aura}ft, if creature has fear, speed = 0, Psychic dmg = 1/2 lvl");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Scornful Rebuke", "When hit, attacker takes Cha Psychic dmg");
                        }
                        if (lvl >= 20)
                        {
                            result.ClassFeatures.Add("Invincible Conqueror", "LR, action, 1 min, gain Resistance to all dmg, Attack action - gain extra atk, crit on 19 or 20");
                        }
                        break;
                    case "Crown":
                        tenets = new List<string> { "Courage*", "Law*", "Loyalty*", "Responsibilty*" };
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

                        result.ClassFeatures.Add("Channel Divinity(Champion Challenge)", "no action, 30ft, Wis save, can't move more than 30ft away from you");
                        result.ClassFeatures.Add("Channel Divinity(Turn the Tides)", "bonus, 30ft, regain HP = 1D6 + Cha");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Divine Allegiance", "reaction, if adj ally takes dmg, you take the dmg instead");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Unyielding Spirit", "adv on saves vs paralyze or stun");
                        }
                        if (lvl >= 20)
                        {
                            result.ClassFeatures.Add("Exalted Champion", "action, 1 hr, Resist nonmagical B/P/S, adv on Wis saves, 30ft - allies gain adv on Wis and death saves");
                        }
                        break;
                    case "Devotion":
                        tenets = new List<string> { "Compassion*", "Courage*", "Duty*" };
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

                        result.ClassFeatures.Add("Channel Divinity(Sacred Weapon)", "action, 1 min, atk + Cha, magical, bright 20ft/dim 20ft");
                        result.ClassFeatures.Add("Channel Divinity(Turn the Unholy)", "action, 30ft, 1min, Wis save, turn fiend/undead");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Aura of Devotion", "10ft, can't be charmed");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Purity of Spirit", "constant Protection from Evil and Good");
                        }
                        if (lvl >= 20)
                        {
                            result.ClassFeatures.Add("Holy Nimbus", "LR, action, 1 min, bright 30ft/dim 30ft - start in bright 10 Radiant dmg," +
                                "\nadv on saves vs fiend/undead spells");
                        }
                        break;
                    case "Glory":
                        //tenets = new List<string> { "*", "*", "*", "*" };
                        //character.Tenets.AddRange(tenets);
                        //OathSpells[1].Add("*");
                        //OathSpells[1].Add("*");
                        //OathSpells[2].Add("*");
                        //OathSpells[2].Add("*");
                        //OathSpells[3].Add("*");
                        //OathSpells[3].Add("*");
                        //OathSpells[4].Add("*");
                        //OathSpells[4].Add("*");
                        //OathSpells[5].Add("*");
                        //OathSpells[5].Add("*");

                        //result.ClassFeatures.Add("Channel Divinity()", "");
                        //result.ClassFeatures.Add("Channel Divinity()", "");
                        //if (lvl >= 7)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 15)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 20)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        break;
                    case "Redemption":
                        tenets = new List<string> { "Innocence*", "Patience*", "Peace*", "Wisdom*" };
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

                        result.ClassFeatures.Add("Channel Divinity(Emissary of Peace)", "bonus, 10min, +5 Persuasion");
                        result.ClassFeatures.Add("Channel Divinity(Rebuke the Violent)", "30ft, ally takes dmg, Wis save - 1/2 Radiant dmg on fail");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Aura of Guardian", "10ft, reaction, take ally dmg instead");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Protective Spirit", "when bloodied, regen 1D6 + 1/2 lvl");
                        }
                        if (lvl >= 20)
                        {
                            result.ClassFeatures.Add("Emissary of Redemption", "Resist all dmg, when hit deal 1/2 Radiant dmg");
                        }
                        break;
                    case "Vengeance":
                        tenets = new List<string> { "Fight the Greater Evil*", "No Mercy for the Wicked*", "By Any Means Necessary*", "Restitution*" };
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

                        result.ClassFeatures.Add("Channel Divinity(Abjure Enemy)", "action, 60ft, 1 creature, Wis save, fear & speed = 0");
                        result.ClassFeatures.Add("Channel Divinity(Vow of Enmity)", "bonus, 10ft, 1 min, adv on atks vs 1 creature");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Relentless Avenger", "op atk hit, move 1/2 speed no atk ops");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Soul of Vengeance", "reaction, if vow of enmity tar atks, melee weapon atk");
                        }
                        if (lvl >= 20)
                        {
                            result.ClassFeatures.Add("Avenging Angel", "action, 1hr, wings(fly 60ft), aura of menace 30ft - Wis save, fear 1 min");
                        }
                        break;
                    case "Watchers":
                        //tenets = new List<string> { "*", "*", "*", "*" };
                        //character.Tenets.AddRange(tenets);
                        //OathSpells[1].Add("*");
                        //OathSpells[1].Add("*");
                        //OathSpells[2].Add("*");
                        //OathSpells[2].Add("*");
                        //OathSpells[3].Add("*");
                        //OathSpells[3].Add("*");
                        //OathSpells[4].Add("*");
                        //OathSpells[4].Add("*");
                        //OathSpells[5].Add("*");
                        //OathSpells[5].Add("*");

                        //result.ClassFeatures.Add("Channel Divinity()", "");
                        //result.ClassFeatures.Add("Channel Divinity()", "");
                        //if (lvl >= 7)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 15)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 20)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        break;
                    case "Oathbreaker":
                        tenets = new List<string> { "Ambition*", "Corruption*", "Fear*", "Hatred*", "Honorless*", "Power*", "Villainous*" };
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

                        result.ClassFeatures.Add("Channel Divinity(Control Undead)", "action, 24hr, 30ft, 1 undead CR < lvl, Wis save, obeys commands");
                        result.ClassFeatures.Add("Channel Divinity(Dreadful Aspect)", "action, 30ft, Wis save, fear 1 min, if more than 30ft Wis save to end");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Aura of Hate", "10ft, fiends and undead dmg + Cha");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Supernatural Resistance", "gain Resistance to nonmagical B/P/S");
                        }
                        if (lvl >= 20)
                        {
                            result.ClassFeatures.Add("Dread Lord", "LR, action, 1 min, 30ft, aura reduces bright light to dim light, if fear in aura - 4D10 Psychic dmg" +
                                "you and allies of choice impose disadv on atk / bonus, melee spell atk, 3D10 + Cha Necrotic dmg");
                        }
                        break;
                }
                result.Spells[1].AddRange(OathSpells[1]);
            }
            if (lvl >= 4)
            {
                result.ClassFeatures.Add("Martial Versatility", "When you gain an Ability Score Improvement, you can replace a Fighting Style");
            }
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
                result.Spells[2].AddRange(OathSpells[2]);
            }
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Aura of Protection", "10ft, saves + Cha");
            }
            if (lvl >= 9)
            {
                result.Spells[3].AddRange(OathSpells[3]);
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Aura of Courage", "10ft, can't be frightened");
            }
            if (lvl >= 11)
            {
                result.ClassFeatures.Add("Improved Divine Smite", "all melee +1D8 Radiant");
            }
            if (lvl >= 13)
            {
                result.Spells[3].AddRange(OathSpells[4]);
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Cleansing Touch", "action, Cha/LR, dispel on creatures");
            }
            if (lvl >= 17)
            {
                result.Spells[4].AddRange(OathSpells[5]);
            }
            if (lvl >= 18)
            {
                result.ClassFeatures["Aura of Protection"] = "30ft, saves + Cha";
                result.ClassFeatures["Aura of Courage"] = "30ft, can't be frightened";
                switch (SacredOath)
                {
                    case "Devotion":
                        result.ClassFeatures["Aura of Devotion"] = "30ft, can't be charmed";
                        break;
                    case "Ancients":
                        result.ClassFeatures["Aura of Warding"] = "30ft, Resistance to spell dmg";
                        break;
                    case "Redemption":
                        result.ClassFeatures["Aura of Guardian"] = "30ft, reaction, take ally dmg instead";
                        break;
                    case "Oathbreaker":
                        result.ClassFeatures["Aura of Hate"] = "30ft, fiends and undead dmg + Cha";
                        break;
                }
            }
            //spells code
            string str2 = "You already have that spell";
            string pickMsg = "Pick a 1st level spell.";
            AllSpells spells = new AllSpells("Paladin");
            foreach (var slotLvl in result.SpellSlots.Keys)
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
                int slots = result.SpellSlots[slotLvl];
                for (int i = 0; i < slots; i++)
                {
                    string spell = CLIHelper.GetNew(spells.Paladin[slotLvl], result.Spells[slotLvl], pickMsg, str2);
                    result.Spells[slotLvl].Add(spell);
                    spells.Paladin[slotLvl].Remove(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
