using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class SwordmageSpecifics
    {
        public static string ArcaneSwordStyle { get; set; }
        public static Dictionary<int, List<string>> ExpandedSpells { get; set; } = new Dictionary<int, List<string>>()
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
            result.ClassFeatures.Add("Weaponized Arcana", "use Cha for atk/dmg with melee");
            result.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use your sword as a spell focus");

            if (lvl >= 2)
            {
                string fightStyleMsg = "Pick a fighting style.";
                var styleList = new List<string> { "Blind Fighting", "Defense", "Dueling", "Great Weapon Fighting", "Interception",
                    "Protection", "Two-Weapon Fighting" };
                string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                string fightStyleKey = $"Fighting Style({fightStyle})";
                string fightStyleValue = Options.FightingStyles[fightStyle];
                result.ClassFeatures.Add(fightStyleKey, fightStyleValue);
                result.ClassFeatures.Add("Enchanted Blade", "bonus to teleport to you, +1D6 dmg, on SR/LR - change the dmg type to: " +
                    "\nCold, Fire, Force, Lightning, Necrotic, or Radiant (pick one to have at base)");
            }
            if (lvl >= 3)
            {
                result.ClassFeatures.Add("Protective Personality", "saves + Cha");
                string msg = "Pick an Arcane Sword Style that will give you features at levels 3, 7, and 15.";
                var archetype = new List<string> { "Assault Style", "Ensnaring Style", "Shielding Style" };
                int answer = CLIHelper.PrintChoices(msg, archetype);
                string style = archetype[answer];
                ArcaneSwordStyle = style.Substring(0, style.Length - 6);

                switch (ArcaneSwordStyle)
                {
                    case "Assault":
                        ExpandedSpells[1].Add("Hex*");
                        ExpandedSpells[1].Add("Hunter's Mark*");
                        ExpandedSpells[2].Add("Blindness/Deafness*");
                        ExpandedSpells[2].Add("Magic Weapon*");
                        ExpandedSpells[3].Add("Bestow Curse*");
                        ExpandedSpells[3].Add("Crusader's Mantle*");
                        ExpandedSpells[4].Add("Fire Shield*");
                        ExpandedSpells[4].Add("Ice Storm*");
                        ExpandedSpells[5].Add("Hold Monster*");
                        ExpandedSpells[5].Add("Negative Energy Flood*");
                        result.ClassFeatures.Add("Supernatural Focus", "SR, atk + 10, after roll before hit or miss");

                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Persistent Swordsman", "hit with atk op, teleport 20ft toward enemy");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Duelist Strike", "mark as bonus, if target atks, reaction melee atk");
                        }
                        break;
                    case "Ensnaring":
                        ExpandedSpells[1].Add("Arms of Hadar*");
                        ExpandedSpells[1].Add("Ensnaring Strike*");
                        ExpandedSpells[2].Add("Hold Person*");
                        ExpandedSpells[2].Add("Spike Growth*");
                        ExpandedSpells[3].Add("Plant Growth*");
                        ExpandedSpells[3].Add("Sleet Storm*");
                        ExpandedSpells[4].Add("Evard's Black Tentacles*");
                        ExpandedSpells[4].Add("Grasping Vine*");
                        ExpandedSpells[5].Add("Dominate Person*");
                        ExpandedSpells[5].Add("Wrath of Nature*");
                        result.ClassFeatures.Add("Debilitating Hex", "mark as bonus, target has disadv on atk for 1 min");

                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Countercharm", "action, 30ft, end charm/fear effects");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Arcane Redirect", "Cha/LR, 60ft, decrease atk/dmg/save of enemy by D10");
                        }
                        break;
                    case "Shielding":
                        ExpandedSpells[1].Add("Sanctuary*");
                        ExpandedSpells[1].Add("Shield of Faith*");
                        ExpandedSpells[2].Add("Calm Emotions*");
                        ExpandedSpells[2].Add("Warding Bond*");
                        ExpandedSpells[3].Add("Glyph of Warding*");
                        ExpandedSpells[3].Add("Remove Curse*");
                        ExpandedSpells[4].Add("Death Ward*");
                        ExpandedSpells[4].Add("Guardian of Faith*");
                        ExpandedSpells[5].Add("Circle of Power*");
                        ExpandedSpells[5].Add("Wall of Force*");
                        result.ClassFeatures.Add("Arcane Wards", "action, 30ft, wards provide 5 temp HP, # wards = lvl");
                        result.Proficiencies.Add("Shields");

                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Aura of Shielding", "20ft, you and allies gain Resistance vs spells");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Aura of Absorption", "reaction, 30ft, if you or allies take dmg, reduce dmg by 1D12 + Con");
                        }
                        break;
                }
            }
            if (lvl >= 4)
            {
                result.ClassFeatures.Add("Martial Versatility", "When you gain an Ability Score Improvement, you can replace a Fighting Style");
            }
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
            }
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Channel Spell", "3D6 + 1D6/lvl(above 1) of your Enchanted Blade's dmg type," +
                    "\nif you cast Flame Blade or Shadow Blade, infuse your weapon instead of conjuring a new one");
                result.ClassFeatures.Add("War Magic", "When you cast a cantrip, bonus melee atk");
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Natural Teleporter", "SR, use Move action to teleport 30ft without atk op");
                result.ClassFeatures.Add("Teleporting Combat", "When using an atk action, teleport 15ft - if you atk 2 creatures, bonus atk");
            }
            if (lvl >= 11)
            {
                result.ClassFeatures.Remove("Channel Spell");
                result.ClassFeatures.Add("Improved Channel Spell", "4D6 + 1D6/lvl(above 1) of your Enchanted Blade's dmg type");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Grand Reach", "action, 60ft cone, Dex save, 3D8 of your Enchanted Blade's dmg type");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Archaic Rune of Restoration", "LR, when you drop to 0 HP - drop to 1 HP instead");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Arcane Burst", "LR, 60ft radius, Con save, 15D6 force, knock prone and fear 1 min");
            }

            //spells code
            string pickMsg = "Pick a cantrip.";
            string errorMsg = "You already have that cantrip.";
            AllSpells spells = new AllSpells("Swordmage");

            for (int i = 0; i < result.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(spells.Swordmage[0], result.Cantrips, pickMsg, errorMsg);
                result.Cantrips.Add(spell);
                spells.Swordmage[0].Remove(spell);
            }
            errorMsg = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            int spellLvl = 1;

            for (int i = 1; i <= result.SpellsKnown; i++)
            {
                
                if (i == 6)
                {
                    spellLvl++;
                    pickMsg = "Pick a 2nd level spell.";
                }
                if (i == 10)
                {
                    spellLvl++;
                    pickMsg = "Pick a 3rd level spell.";
                }
                if (i == 12 || i == 14)
                {
                    spellLvl++;
                    pickMsg = $"Pick a {spellLvl}th level spell.";
                }
                string spell = CLIHelper.GetNew(spells.Swordmage[spellLvl], result.Spells[spellLvl], pickMsg, errorMsg);
                result.Spells[spellLvl].Add(spell);
                spells.Swordmage[spellLvl].Remove(spell);
            }
            //end spells code

            return result;
        }
    }
}
