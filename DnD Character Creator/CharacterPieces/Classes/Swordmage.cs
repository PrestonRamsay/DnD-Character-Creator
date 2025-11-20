using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Swordmage
    {
        public static string ArcaneSwordStyle { get; set; }
        public static Dictionary<int, List<string>> ExpandedSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() }
        };
        public static void Base(Character character)
        {
            var classSkills = new List<string> { "Acrobatics", "Arcana", "Athletics", "Deception", "History", "Intimidation",
                "Perception", "Persuasion" };
            var swords = new List<string> { "Claymore", "Greatsword", "Longsword", "Rapier", "Sabre", "Scimitar", "Shortsword" };

            character.GP += 125;
            character.HitDie = 10;
            character.Proficiencies.Add("Light armor");
            character.Proficiencies.Add("Medium armor");
            character.Proficiencies.Add("Simple weapons");
            foreach (var item in swords)
            {
                character.Proficiencies.Add(item + "s");
            }
            character.Saves.Add("Dex");
            character.Saves.Add("Cha");

            BEHelper.GetSkills(character, classSkills, 2);
        }
        public static void Equipment(Character character)
        {
            var swords = new List<string> { "Claymore", "Greatsword", "Longsword", "Rapier", "Sabre", "Scimitar", "Shortsword" };
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            //CLIHelper.Print2Choices("Scalemail", "Leather");
            int input1 = CLIHelper.GetChoiceFromPair("Scalemail", "Leather");
            string sword = CLIHelper.PrintChoices(swords);
            var allMelee = new List<string>();
            allMelee.AddRange(Options.MartialMeleeWeapons);
            allMelee.AddRange(Options.AdvancedMeleeWeapons);
            foreach (var item in allMelee)
            {
                if (item.Contains(sword))
                {
                    character.Equipment.Add(item);
                }
            }
            BEHelper.AddSimpleWeapon(character);
            //CLIHelper.Print2Choices("Dungeoneer's Pack", "Explorer's Pack");
            int input2 = CLIHelper.GetChoiceFromPair("Dungeoneer's Pack", "Explorer's Pack");

            if (input1 == 1)
            {
                character.Equipment.Add(Options.MediumArmor[2]);
            }
            else
            {
                character.Equipment.Add(Options.LightArmor[1]);
            }
            if (input2 == 1)
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
            character.ClassFeatures.Add("Weaponized Arcana", "use Cha for atk/dmg with melee");
            try
            {
                character.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use your sword as a spell focus");
            }
            catch (Exception)
            {
                Console.WriteLine("*Note* You have 2 classes with spellcasting");
                throw;
            }

            if (lvl >= 2)
            {
                string fightStyleMsg = "Pick a fighting style.";
                var styleList = new List<string> { "Blind Fighting", "Defense", "Dueling", "Great Weapon Fighting", "Interception",
                    "Protection", "Two-Weapon Fighting" };
                string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                string fightStyleKey = $"Fighting Style({fightStyle})";
                string fightStyleValue = Options.FightingStyles[fightStyle];
                character.ClassFeatures.Add(fightStyleKey, fightStyleValue);
                character.ClassFeatures.Add("Enchanted Blade", "bonus to teleport to you, +1D6 dmg, on SR/LR - change the dmg type to: " +
                    "\n        Cold, Fire, Force, Lightning, Necrotic, or Radiant (pick one to have at base)");
            }
            if (lvl >= 3)
            {
                character.ClassFeatures.Add("Protective Personality", "saves + Cha");
                string msg = "Pick an Arcane Sword Style that will give you features at levels 3, 7, and 15.";
                var archetype = new List<string> { "Assault Style", "Ensnaring Style", "Shielding Style" };
                int answer = CLIHelper.PrintChoices(msg, archetype);
                string style = archetype[answer];
                ArcaneSwordStyle = style.Substring(0, style.Length - 6);

                switch (ArcaneSwordStyle)
                {
                    case "Assault":
                        Assault(character);
                        break;
                    case "Ensnaring":
                        Ensnaring(character);
                        break;
                    case "Shielding":
                        Shielding(character);
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
                character.ClassFeatures.Add("Channel Spell", "3D6 + 1D6/lvl(above 1) of your Enchanted Blade's dmg type," +
                    "\n        if you cast Flame Blade or Shadow Blade, infuse your weapon instead of conjuring a new one");
                character.ClassFeatures.Add("War Magic", "When you cast a cantrip, bonus melee atk");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Natural Teleporter", "SR, use Move action to teleport 30ft without atk op");
                character.ClassFeatures.Add("Teleporting Combat", "When using an atk action, teleport 15ft - if you atk 2 creatures, bonus atk");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Remove("Channel Spell");
                character.ClassFeatures.Add("Improved Channel Spell", "4D6 + 1D6/lvl(above 1) of your Enchanted Blade's dmg type");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Grand Reach", "action, 60ft cone, Dex save, 3D8 of your Enchanted Blade's dmg type");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Archaic Rune of Restoration", "LR, when you drop to 0 HP - drop to 1 HP instead");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Arcane Burst", "LR, 60ft radius, Con save, 15D6 force, knock prone and fear 1 min");
            }
            Spells(character);

            
        }
        public static void Assault(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Hex");
            ExpandedSpells[1].Add("Hunter's Mark");
            ExpandedSpells[2].Add("Blindness/Deafness");
            ExpandedSpells[2].Add("Magic Weapon");
            ExpandedSpells[3].Add("Bestow Curse");
            ExpandedSpells[3].Add("Crusader's Mantle");
            ExpandedSpells[4].Add("Fire Shield");
            ExpandedSpells[4].Add("Ice Storm");
            ExpandedSpells[5].Add("Hold Monster");
            ExpandedSpells[5].Add("Negative Energy Flood");
            character.ClassFeatures.Add("Supernatural Focus", "SR, atk + 10, after roll before hit or miss");

            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Persistent Swordsman", "hit with atk op, teleport 20ft toward enemy");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Duelist Strike", "mark as bonus, if target atks, reaction melee atk");
            }
        }
        public static void Ensnaring(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Arms of Hadar");
            ExpandedSpells[1].Add("Ensnaring Strike");
            ExpandedSpells[2].Add("Hold Person");
            ExpandedSpells[2].Add("Spike Growth");
            ExpandedSpells[3].Add("Plant Growth");
            ExpandedSpells[3].Add("Sleet Storm");
            ExpandedSpells[4].Add("Evard's Black Tentacles");
            ExpandedSpells[4].Add("Grasping Vine");
            ExpandedSpells[5].Add("Dominate Person");
            ExpandedSpells[5].Add("Wrath of Nature");
            character.ClassFeatures.Add("Debilitating Hex", "mark as bonus, target has disadv on atk for 1 min");

            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Countercharm", "action, 30ft, end charm/fear effects");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Arcane Redirect", "Cha/LR, 60ft, decrease atk/dmg/save of enemy by D10");
            }
        }
        public static void Shielding(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Sanctuary");
            ExpandedSpells[1].Add("Shield of Faith");
            ExpandedSpells[2].Add("Calm Emotions");
            ExpandedSpells[2].Add("Warding Bond");
            ExpandedSpells[3].Add("Glyph of Warding");
            ExpandedSpells[3].Add("Remove Curse");
            ExpandedSpells[4].Add("Death Ward");
            ExpandedSpells[4].Add("Guardian of Faith");
            ExpandedSpells[5].Add("Circle of Power");
            ExpandedSpells[5].Add("Wall of Force");
            character.ClassFeatures.Add("Arcane Wards", "action, 30ft, wards provide 5 temp HP, # wards = lvl");
            character.Proficiencies.Add("Shields");

            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Aura of Shielding", "20ft, you and allies gain Resistance vs spells");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Aura of Absorption", "reaction, 30ft, if you or allies take dmg, reduce dmg by 1D12 + Con");
            }
        }
        public static void Spells(Character character)
        {
            BEHelper.AddSecSpells(character, ExpandedSpells);
            string pickMsg = "Pick a cantrip.";
            AllSpells spells = new AllSpells(character);

            for (int i = 0; i < character.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(spells.Swordmage[0], character.Cantrips, pickMsg);
                character.Cantrips.Add(spell);
                spells.Swordmage[0].Remove(spell);
            }
            pickMsg = "Pick a 1st level spell.";
            int spellLvl = 1;

            for (int i = 1; i <= character.SpellsKnown; i++)
            {
                var lvlsToIncSpellLvl = new List<int> { 6, 9, 12, 14 };

                if (lvlsToIncSpellLvl.Contains(i))
                {
                    spellLvl++;
                }
                pickMsg = CLIHelper.pickSpellLevel(i, 6, 9, 12, pickMsg, spellLvl);
                string spell = CLIHelper.GetNew(spells.Swordmage[spellLvl], character.Spells[spellLvl], pickMsg);
                character.Spells[spellLvl].Add(spell);
                spells.Swordmage[spellLvl].Remove(spell);
            }
        }
    }
}
