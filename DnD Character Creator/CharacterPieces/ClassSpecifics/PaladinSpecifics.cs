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
        public static CharacterClass Features(CharacterClass result)
        {
            int lvl = result.Lvl;

            result.ClassFeatures.Add("Divine Sense","action, 60ft, 1 + Cha/LR, know location and type of celestials, fiend, undead");
            result.ClassFeatures.Add("Lay on Hands", "heal lvl x 5 HP");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Divine Smite", "2D8 + 1D8/lvl(above 1), +1D8 if undead/fiend");
                string fightStyleMsg = "Pick a fighting style.";
                List<string> styleList = new List<string>();
                foreach (var style in Options.FightingStyles.Keys)
                {
                    if (style != "Archery" && style != "Two-Weapon Fighting")
                    {
                        styleList.Add(style);
                    }
                }
                int input = CLIHelper.PrintChoices(fightStyleMsg, styleList);
                string fightStyleKey = "Fighting Style";
                fightStyleKey += $"({styleList[input]})";
                result.ClassFeatures.Add(fightStyleKey, Options.FightingStyles[styleList[input]]);
            }
            if (lvl >= 3)
            {
                result.ClassFeatures.Add("Divine Health", "disease immunity");
                string msg = "Pick a Sacred Oath that will give you features at levels 3, 7, 15, and 20.";
                var archetype = new List<string> { "Oath of Devotion", "Oath of the Ancients", "Oath of Vengeance", "Oath of Redemption" };
                int answer = CLIHelper.PrintChoices(msg, archetype);

                if (answer == 0)
                {
                    SacredOath = "Devotion";
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
                        result.ClassFeatures.Add("Holy Nimbus", "action, 1min, LR, bright 30ft/dim 30ft - start in bright 10 radiant dmg," +
                            "\nadv on saves vs fiend/undead spells");
                    }
                }
                else if (answer == 1)
                {
                    SacredOath = "Ancients";
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
                        result.ClassFeatures.Add("Undying Sentinel", "LR, when 0HP - 1HP instead");
                    }
                    if (lvl >= 20)
                    {
                        result.ClassFeatures.Add("Elder Champion", "action, 1min, transform - regen 10, spells as bonus, enemies in 10ft" +
                            "\ndisadv vs paladin spells/channel divinity");
                    }
                }
                else if (answer == 2)
                {
                    SacredOath = "Vengeance";
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
                }
                else if (answer == 3)
                {
                    SacredOath = "Redemption";
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
                    result.ClassFeatures.Add("Channel Divinity(Rebuke the Violent)", "30ft, ally takes dmg, Wis save - 1/2 radiant dmg on fail");
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
                        result.ClassFeatures.Add("Emissary of Redemption", "Resist all dmg, when hit deal 1/2 radiant dmg");
                    }
                }
                result.Spells[1].AddRange(OathSpells[1]);
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
                result.ClassFeatures.Add("Improved Divine Smite", "all melee +1D8 radiant");
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
                if (SacredOath == "Devotion")
                {
                    result.ClassFeatures["Aura of Devotion"] = "30ft, can't be charmed";
                }
                if (SacredOath == "Ancients")
                {
                    result.ClassFeatures["Aura of Warding"] = "30ft, Resistance to spell dmg";
                }
                if (SacredOath == "Redemption")
                {
                    result.ClassFeatures["Aura of Guardian"] = "30ft, reaction, take ally dmg instead";
                }
            }
            //spells code
            string str2 = "You already have that spell";
            string pickMsg = "Pick a 1st level spell.";
            AllSpells spells = new AllSpells();
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
                }
            }
            //end spells code

            return result;
        }
    }
}
