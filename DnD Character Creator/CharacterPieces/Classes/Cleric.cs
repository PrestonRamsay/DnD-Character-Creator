using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Cleric
    {
        public static string DivineDomain { get; set; }
        public static Dictionary<int, List<string>> DomainSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() }
        };
        public static void Base(Character character)
        {
            List<string> classSkills = new List<string> { "History", "Insight", "Medicine", "Persuasion", "Religion" };

            character.GP += 125;
            character.HitDie = 8;
            character.Proficiencies.Add("Light Armor");
            character.Proficiencies.Add("Medium Armor");
            character.Proficiencies.Add("Shields");
            character.Proficiencies.Add("Simple Weapons");
            character.Saves.Add("Wis");
            character.Saves.Add("Cha");

            BEHelper.GetSkills(character, classSkills, 2);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Mace", "Warhammer (if proficient)");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print3Choices("Scale mail", "Leather armor", "Chain mail (if proficient)");
            int input2 = CLIHelper.GetNumberInRange(1, 3);
            CLIHelper.Print2Choices("Light crossbow and 20 bolts", "Any simple weapon");
            int input3 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Priest's Pack", "Explorer's Pack");
            int input4 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                character.Equipment.Add(Options.SimpleMeleeWeapons[6]);
            }
            else
            {
                character.Equipment.Add(Options.MartialMeleeWeapons[16]);
            }
            if (input2 == 1)
            {
                character.Equipment.Add(Options.MediumArmor[2]);
            }
            else if (input2 == 2)
            {
                character.Equipment.Add(Options.LightArmor[1]);
            }
            else
            {
                character.Equipment.Add(Options.HeavyArmor[1]);
            }
            if (input3 == 1)
            {
                character.Equipment.Add(Options.SimpleRangedWeapons[0]);
                character.Equipment.Add("20 bolts");
            }
            else
            {
                BEHelper.AddSimpleWeapon(character);
            }
            if (input4 == 1)
            {
                character.Equipment.Add(Options.Packs[5]);
            }
            else
            {
                character.Equipment.Add(Options.Packs[4]);
            }

            character.Equipment.Add("Shield(+2 AC)(10gp, 6lb.)");
            BEHelper.AddHolySymbol(character);
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;
            try
            {
                character.ClassFeatures.Add("Spellcasting", "use Wis for spell DCs, you use a Holy Symbol as a spell focus");
            }
            catch (Exception)
            {
                Console.WriteLine("*Note* You have 2 classes with spellcasting");
                throw;
            }
            
            string msg = "Pick a Divine Domain that will give you features at levels 2, 6, 8, and 17.";
            var archetype = new List<string> { "Ambition", "Arcana", "Death", "Forge", "Grave", "Knowledge", "Life", "Light",
                "Nature", "Order", "Peace", "Solidarity", "Strength", "Tempest", "Trickery", "Twilight", "War", "Water", "Zeal" };
            int input = CLIHelper.PrintChoices(msg, archetype);
            DivineDomain = archetype[input];

            switch (DivineDomain)
            {
                case "Ambition":
                    Ambition(character);
                    break;
                case "Arcana":
                    Arcana(character);
                    break;
                case "Death":
                    Death(character);
                    break;
                case "Forge":
                    Forge(character);
                    break;
                case "Grave":
                    Grave(character);
                    break;
                case "Knowledge":
                    Knowledge(character);
                    break;
                case "Life":
                    Life(character);
                    break;
                case "Light":
                    Light(character);
                    break;
                case "Nature":
                    Nature(character);
                    break;
                case "Order":
                    Order(character);
                    break;
                case "Peace":
                    Peace(character);
                    break;
                case "Solidarity":
                    Solidarity(character);
                    break;
                case "Strength":
                    Strength(character);
                    break;
                case "Tempest":
                    Tempest(character);
                    break;
                case "Trickery":
                    Trickery(character);
                    break;
                case "Twilight":
                    Twilight(character);
                    break;
                case "War":
                    War(character);
                    break;
                case "Water":
                    Water(character);
                    break;
                case "Zeal":
                    Zeal(character);
                    break;
            }
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Turn Undead)", "action, 30ft, Wis save - turn 1 min");
                character.ClassFeatures.Add("Channel Divinity uses", "1/SR");
                character.ClassFeatures.Add("Harness Divine Power", "bonus, expend a Channel Divinity use to regain a spell slot = 1/2 PB");
            }
            if (lvl >= 3)
            {
                character.ClassFeatures.Add("Cantrip Versatility", "When you get an Ability Score Improvement, you can replace a cantrip");
            }
            if (lvl >= 5)
            {
                int CR = 0;
                character.ClassFeatures.Add("Destroy Undead", "CR under 1/2 that fail against Turn Undead are instantly destroyed");
                for (int i = 8; i <= lvl ; i += 3)
                {
                    CR++;
                    character.ClassFeatures["Destroy Undead"] = $"CR under {CR} that fail against Turn Undead are instantly destroyed";
                }
            }
            if (lvl >= 6)
            {
                character.ClassFeatures["Channel Divinity uses"] = "2/SR";
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Blessed Strikes", "instead of Divine Strike or Potent Spellcasting, weapon or cantrip dmg + 1D8 Radiant");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Divine Intervention", "if % dice roll <= lvl, DM decides nature of intervention, recharge 7 days, retry LR");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures["Channel Divinity uses"] = "3/SR";
            }
            if (lvl >= 20)
            {
                character.ClassFeatures["Divine Intervention"] = "automatically succeed, DM decides nature of intervention";
            }
            Spells(character);
        }
        public static void Ambition(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Bane*");
            DomainSpells[1].Add("Disguise Self*");
            DomainSpells[2].Add("Mirror Image*");
            DomainSpells[2].Add("Ray of Enfeeblement*");
            DomainSpells[3].Add("Bestow Curse*");
            DomainSpells[3].Add("Vampiric Touch*");
            DomainSpells[4].Add("Death Ward*");
            DomainSpells[4].Add("Dimension Door*");
            DomainSpells[5].Add("Dominate Person*");
            DomainSpells[5].Add("Modify Memory*");

            character.ClassFeatures.Add("Warding Flare", "Wis/LR, reaction, 30ft, impose disadv, attacker can't be immune to blinding");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Invoke Duplicity)", "action, conc 1 min, 30ft, create illusory double, bonus to move it 30ft" +
                    "\n        it must remain within 120ft, if you and double are within 5ft of target you gain adv on atks");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Channel Divinity(Cloak of Shadows)", "action, 1 turn, become invisible");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Potent Spellcasting", "cantrips + Wis dmg");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Improved Duplicity", "create 4 copies instead of 1, bonus to move any number of them");
            }
        }
        public static void Arcana(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Detect Magic*");
            DomainSpells[1].Add("Magic Missile*");
            DomainSpells[2].Add("Magic Weapon*");
            DomainSpells[2].Add("Nystul's Magic Aura*");
            DomainSpells[3].Add("Dispel Magic*");
            DomainSpells[3].Add("Magic Circle*");
            DomainSpells[4].Add("Arcane Eye*");
            DomainSpells[4].Add("Leomund's Secret Chest*");
            DomainSpells[5].Add("Planar Binding*");
            DomainSpells[5].Add("Teleportation Circle*");

            character.ClassFeatures.Add("Arcane Initiate", "gain prof in Arcana and learn 2 Wizard cantrips");
            character.SkillProficiencies.Add("Arcana");
            Console.WriteLine("Arcane Initiate: gain prof in Arcana and 2 Wizard cantrips");
            AllSpells spells = new AllSpells("Wizard");
            var wizCantrips = new List<string>();
            wizCantrips.AddRange(spells.Wizard[0]);
            string cantrip = CLIHelper.PrintChoices(wizCantrips);
            character.Cantrips.Add(cantrip);
            wizCantrips.Remove(cantrip);
            cantrip = CLIHelper.PrintChoices(wizCantrips);
            character.Cantrips.Add(cantrip);
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Arcane Abjuration)", "action, 30ft, 1 celestial/elemental/fey/fiend, present Holy Symbol, Wis save, the creature is turned");
            }
            if (lvl >= 5)
            {
                if (lvl < 8)
                {
                    character.ClassFeatures["Channel Divinity(Arcane Abjuration)"] += "\n        banish CR 1/2 or lower for 1 min, no conc";
                }
                else
                {
                    int CR = 1;
                    for (int i = 11; i <= lvl; i += 3)
                    {
                        CR++;
                    }
                    character.ClassFeatures["Channel Divinity(Arcane Abjuration)"] += $"\n        banish CR {CR} or lower for 1 min, no conc";
                }
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Spellbreaker", "When you heal an ally, end 1 spell whose lvl is = or lower than the healing spell's lvl");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Potent Spellcasting", "cantrips + Wis dmg");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Arcane Mastery", "gain 6th, 7th, 8th, and 9th lvl Wizard spells (one each) as Domain spells");
                Console.WriteLine("Arcane Mastery: gain 6th, 7th, 8th, and 9th lvl Wizard spells (one each) as Domain spells");
                int wizSpellLvl = 6;
                for (int i = 0; i < 4; i++)
                {
                    string spell = CLIHelper.PrintChoices(spells.Wizard[wizSpellLvl]);
                    character.Spells[wizSpellLvl].Add(spell + "*");
                    wizSpellLvl++;
                }
            }
        }
        public static void Death(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("False Life*");
            DomainSpells[1].Add("Ray of Sickness*");
            DomainSpells[2].Add("Blindness/Deafness*");
            DomainSpells[2].Add("Ray of Enfeeblement*");
            DomainSpells[3].Add("Animate Dead*");
            DomainSpells[3].Add("Vampiric Touch*");
            DomainSpells[4].Add("Blight*");
            DomainSpells[4].Add("Death Ward*");
            DomainSpells[5].Add("Antilife Shell*");
            DomainSpells[5].Add("Cloudkill*");

            character.Proficiencies.Add("Martial Weapons");
            var necroCantrips = new List<string> { "Chill Touch", "Sapping Strike", "Spare the Dying", "Toll the Dead" };
            Console.WriteLine("Pick a Necromancy cantrip");
            string necro = CLIHelper.PrintChoices(necroCantrips);
            character.Cantrips.Add(necro);
            character.ClassFeatures.Add("Reaper", "Necromancy cantrips that target 1 creature can target 2 if adj");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Touch of Death)", "when you hit with melee, extra Necrotic dmg = 5 + (lvl x 2)");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Inescapable Destruction", "spells and Channel Divinity that deal Necrotic dmg ignore Resistance");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Necrotic dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Necrotic dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Improved Reaper", "Necromancy spells 1st-5th that target 1 creature can target 2 if adj");
            }
        }
        public static void Forge(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Identify*");
            DomainSpells[1].Add("Searing Smite*");
            DomainSpells[2].Add("Heat Metal*");
            DomainSpells[2].Add("Magic Weapon*");
            DomainSpells[3].Add("Elemental Weapon*");
            DomainSpells[3].Add("Protection from Energy*");
            DomainSpells[4].Add("Fabricate*");
            DomainSpells[4].Add("Wall of Fire*");
            DomainSpells[5].Add("Animate Objects*");
            DomainSpells[5].Add("Creation*");

            character.Proficiencies.Add("Heavy Armor");
            character.Proficiencies.Add("Smith's Tools");
            character.ClassFeatures.Add("Blessing of the Forge", "LR, enchant one item, +1 AC or +1 atk/dmg");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Artisan's Blessing)", "ritual, 1 hr, create metal equipment, can duplicate items if you have the original");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Soul of the Forge", "gain Resistance to Fire, +1 AC while wearing Heavy Armor");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Cold dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Cold dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Saints of Forge and Fire", "gain immunity to Fire, while wearing Heavy Armor, gain Resistance to nonmagical B/P/S");
            }
        }
        public static void Grave(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Bane*");
            DomainSpells[1].Add("False Life*");
            DomainSpells[2].Add("Gentle Repose*");
            DomainSpells[2].Add("Ray of Enfeeblement*");
            DomainSpells[3].Add("Revivify*");
            DomainSpells[3].Add("Vampiric Touch*");
            DomainSpells[4].Add("Blight*");
            DomainSpells[4].Add("Death Ward*");
            DomainSpells[5].Add("Antilife Shell*");
            DomainSpells[5].Add("Raise Dead*");

            character.ClassFeatures.Add("Circle of Mortality", "when you use heal spell on ally with 0 HP, heal max on spell");
            character.Cantrips.Add("Spare the Dying(bonus, 30ft)");
            character.ClassFeatures.Add("Eyes of the Grave", "Wis/LR, action, 60ft, not behind total cover, detect the location of undead");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Path to the Grave)", "action, 30ft, one creature, suffer vulnerability on next hit");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Senitel at Death's Door", "Wis/LR, reaction, 30ft, when you or an ally suffers a crit, turn the crit into a normal hit");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Potent Spellcasting", "cantrips + Wis dmg");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Keeper of Souls", "1/turn, 60ft, when a creature dies, you or an ally regain HP = creature's HitDice");
            }
        }
        public static void Knowledge(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Command*");
            DomainSpells[1].Add("Identify*");
            DomainSpells[2].Add("Augury*");
            DomainSpells[2].Add("Suggestion*");
            DomainSpells[3].Add("Nondetection*");
            DomainSpells[3].Add("Speak with Dead*");
            DomainSpells[4].Add("Arcane Eye*");
            DomainSpells[4].Add("Confusion*");
            DomainSpells[5].Add("Legend Lore*");
            DomainSpells[5].Add("Scrying*");

            character.ClassFeatures.Add("Blessings of Knowledge", "gain 2 languages and 2 skills");
            var skills = new List<string> { "Arcana", "History", "Nature", "Religion" };
            Console.WriteLine($"Clerics of Knowledge gain 2 languages and 2 skills from: {String.Join(", ", skills)}");
            string msg = "Pick the 1st language now";
            string firstLanguage = CLIHelper.GetNew(Options.Languages, character.Languages, msg);
            character.Languages.Add(firstLanguage);
            msg = "Pick the 2nd language now";
            string secondLanguage = CLIHelper.GetNew(Options.Languages, character.Languages, msg);
            character.Languages.Add(secondLanguage);
            msg = "Pick the 1st skill now";
            string firstSkill = CLIHelper.GetNew(skills, character.SkillProficiencies, msg);
            character.SkillProficiencies.Add(firstSkill);
            msg = "Pick the 2nd skill now";
            string secondSkill = CLIHelper.GetNew(skills, character.SkillProficiencies, msg);
            character.SkillProficiencies.Add(secondSkill);

            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Knowledge of the Ages)", "gain prof in 1 skill or tool for 10min");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Channel Divinity(Read Thoughts)", "LR, action, 60ft, Wis save, 1 min - read surface thoughts, auto-fail for Suggestion spell");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Potent Spellcasting", "cantrip dmg + Wis");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Visions of the Past", "1/SR, meditate for 1 min - Object reading: see visions of previous owner," +
                    "\n        Area Reading: see visions of recent or significant events");
            }
        }
        public static void Life(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Bless*");
            DomainSpells[1].Add("Cure Wounds*");
            DomainSpells[2].Add("Lesser Restoration*");
            DomainSpells[2].Add("Spiritual Weapon*");
            DomainSpells[3].Add("Beacon of Hope*");
            DomainSpells[3].Add("Revivify*");
            DomainSpells[4].Add("Death Ward*");
            DomainSpells[4].Add("Guardian of Faith*");
            DomainSpells[5].Add("Mass Cure Wounds*");
            DomainSpells[5].Add("Raise Dead*");

            character.Proficiencies.Add("Heavy Armor");
            character.ClassFeatures.Add("Disciple of Life", "healing spells heal extra 2 + spell lvl HP");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Preserve Life)", "action, 30ft, heal lvl x 5 HP, can't go above bloody value, can divide among creatures");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Blessed Healer", "when you cast healing spell, heal yourself 2 + spell lvl HP");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Radiant dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Radiant dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Supreme Healing", "max all healing dice rolls");
            }
        }
        public static void Light(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Burning Hands*");
            DomainSpells[1].Add("Faerie Fire*");
            DomainSpells[2].Add("Flaming Sphere*");
            DomainSpells[2].Add("Scorching Ray*");
            DomainSpells[3].Add("Daylight*");
            DomainSpells[3].Add("Fireball*");
            DomainSpells[4].Add("Guardian of Faith*");
            DomainSpells[4].Add("Wall of Fire*");
            DomainSpells[5].Add("Flame Strike*");
            DomainSpells[5].Add("Scrying*");

            character.Cantrips.Add("Light");
            character.ClassFeatures.Add("Warding Flare", "Wis/LR, reaction, 30ft, impose disadv, attacker can't be immune to blinding");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Radiance of Dawn)", "action, 30ft, Con save, 2D10 + lvl Radiant dmg, dispel magical darkness");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Improved Flare", "you can use Warding Flare when an ally is attacked");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Potent Spellcasting", "dmg + Wis with cantrips");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Corona of Light", "action, 1 min, bright light 60ft, disadv on saves vs Fire or Radiant dmg");
            }
        }
        public static void Nature(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Animal Friendship*");
            DomainSpells[1].Add("Speak with Animals*");
            DomainSpells[2].Add("Barkskin*");
            DomainSpells[2].Add("Spike Growth*");
            DomainSpells[3].Add("Plant Growth*");
            DomainSpells[3].Add("Wind Wall*");
            DomainSpells[4].Add("Dominate Beast*");
            DomainSpells[4].Add("Grasping Vine*");
            DomainSpells[5].Add("Insect Plague*");
            DomainSpells[5].Add("Tree Stride*");

            character.ClassFeatures.Add("Acolyte of Nature", "learn a Druid cantrip and a skill");
            string msg = "Pick a Druid cantrip";
            int index = CLIHelper.PrintChoices(msg, DruidSpells.Cantrips);
            string druidCantrip = DruidSpells.Cantrips[index];
            character.Cantrips.Add(druidCantrip);
            var list = new List<string> { "Animal Handling", "Nature", "Survival" };
            msg = "Pick a skill from the list";
            string skill = CLIHelper.GetNew(list, character.SkillProficiencies, msg);
            character.SkillProficiencies.Add(skill);
            character.Proficiencies.Add("Heavy Armor");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Charm Animals and Plants)", "action, 30ft, Wis save, charm 1 min");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Dampen Elements", "reaction, when you or ally within 30ft takes Cold, Fire, or Lighting dmg - gain Resistance");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Cold, Fire, or Lighting dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Cold, Fire, or Lighting dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Master of Nature", "bonus, command creatures charmed by your Channel Divinity");
            }
        }
        public static void Order(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Command*");
            DomainSpells[1].Add("Heroism*");
            DomainSpells[2].Add("Hold Person*");
            DomainSpells[2].Add("Zone of Truth*");
            DomainSpells[3].Add("Mass Healing Word*");
            DomainSpells[3].Add("Slow*");
            DomainSpells[4].Add("Compulsion*");
            DomainSpells[4].Add("Locate Creature*");
            DomainSpells[5].Add("Commune*");
            DomainSpells[5].Add("Dominate Person*");

            character.Proficiencies.Add("Heavy Armor");
            Console.WriteLine("Pick a skill to gain proficiency in");
            string skillProf = String.Join(", ", character.SkillProficiencies);
            Console.WriteLine($"Your skill proficiencies are: {skillProf}");
            CLIHelper.Print2Choices("Intimidation", "Persuasion");
            int num = CLIHelper.GetNumberInRange(1, 2);
            if (num == 1)
            {
                character.SkillProficiencies.Add("Intimidation");
            }
            else
            {
                character.SkillProficiencies.Add("Persuasion");
            }
            character.ClassFeatures.Add("Voice of Authority", "when you cast a non-cantrip spell on an ally, 1 ally can use reaction to make a weapon atk");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Order's Demand)", "action, 30ft, Wis save, charm, drop what they're holding");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Embodiment of the Law", "Wis/LR, Enchantment spells that require an action can be cast as a bonus");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Psychic dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Psychic dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Order's Wrath", "1/turn, curse a creature you dmg with Divine Strike, next ally's dmg + 2D8 Psychic");
            }
        }
        public static void Peace(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Heroism*");
            DomainSpells[1].Add("Sanctuary*");
            DomainSpells[2].Add("Aid*");
            DomainSpells[2].Add("Warding Bond*");
            DomainSpells[3].Add("Beacon of Hope*");
            DomainSpells[3].Add("Sending*");
            DomainSpells[4].Add("Aura of Purity*");
            DomainSpells[4].Add("Otiluke's Resilient Sphere*");
            DomainSpells[5].Add("Greater Restoration*");
            DomainSpells[5].Add("Rary's Telepathic Bond*");

            Console.WriteLine("Pick a skill to gain proficiency in");
            string skillProf = String.Join(", ", character.SkillProficiencies);
            Console.WriteLine($"Your skill proficiencies are: {skillProf}");
            CLIHelper.Print3Choices("Insight", "Performance", "Persuasion");
            int num = CLIHelper.GetNumberInRange(1, 3);
            if (num == 1)
            {
                character.SkillProficiencies.Add("Insight");
            }
            else if (num == 2)
            {
                character.SkillProficiencies.Add("Performance");
            }
            else
            {
                character.SkillProficiencies.Add("Persuasion");
            }
            character.ClassFeatures.Add("Emboldening Bond", "PB/LR, action, 10 min, 30ft, PB creatures, 1/turn, when 30ft from ally - atk, check, save + 1D4");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Balm of Peace)", "action, move your speed no atk op, when adj to ally - heal ally 2D6 + Wis");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Protective Bond", "reaction, 30ft, when creature with Emboldening Bond takes dmg, you and allies can teleport adj and take all dmg instead");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Potent Spellcasting", "cantrips + Wis dmg");
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Expansive Bond", "the range on Emboldening and Protective Bond = 60ft, Protective Bond grants Resistance");
            }
        }
        public static void Solidarity(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Bless*");
            DomainSpells[1].Add("Guiding Bolt*");
            DomainSpells[2].Add("Aid*");
            DomainSpells[2].Add("Warding Bond*");
            DomainSpells[3].Add("Beacon of Hope*");
            DomainSpells[3].Add("Crusader's Mantle*");
            DomainSpells[4].Add("Aura of Life*");
            DomainSpells[4].Add("Guardian of Faith*");
            DomainSpells[5].Add("Circle of Power*");
            DomainSpells[5].Add("Mass Cure Wounds*");

            character.Proficiencies.Add("Heavy Armor");
            character.ClassFeatures.Add("Solidarity's Action", "Wis/LR, bonus, when you take Help action, make a weapon atk");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinty(Preserve Life)", "action, 30ft, distribute HP to regain = lvl x 5");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Channel Divinity(Oketra's Blessing)", "reaction, 30ft, 1 creature, when an atk is made gain +10 atk");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 weapon dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 weapon dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Supreme Healing", "when you roll to restore HP, treat the dice as their max value");
            }
        }
        public static void Strength(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Divine Favor*");
            DomainSpells[1].Add("Shield of Faith*");
            DomainSpells[2].Add("Enhance Ability*");
            DomainSpells[2].Add("Protection from Poison*");
            DomainSpells[3].Add("Haste*");
            DomainSpells[3].Add("Protection from Energy*");
            DomainSpells[4].Add("Dominate Beast*");
            DomainSpells[4].Add("Stoneskin*");
            DomainSpells[5].Add("Destructive Wave*");
            DomainSpells[5].Add("Insect Plague*");

            character.ClassFeatures.Add("Acolyte of Strength", "gain a Druid cantrip and a skill");
            var cantripsToPick = new List<string>();
            foreach (var item in DruidSpells.Cantrips)
            {
                if (!ClericSpells.Cantrips.Contains(item))
                {
                    cantripsToPick.Add(item);
                }
            }
            Console.WriteLine("Pick a Druid cantrip");
            string newCantrip = CLIHelper.PrintChoices(cantripsToPick);
            character.Cantrips.Add(newCantrip);
            var str = new List<string> { "Animal Handling", "Athletics", "Nature", "Survival" };
            string allSkills = String.Join(", ", character.SkillProficiencies);
            Console.WriteLine($"Pick a skill your proficiencies are: {allSkills}");
            string strSkill = CLIHelper.PrintChoices(str);
            character.SkillProficiencies.Add(strSkill);
            character.Proficiencies.Add("Heavy Armor");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Feat of Strength)", "when you make a Str check, atk or save, after roll, atk + 10");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Channel Divinity(Rhona's Blessing)", "reaction, 30ft, 1 creature, when a Str check, atk or save is made, after roll, atk + 10");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 weapon dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 weapon dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Avatar of Battle", "gain Resistance to nonmagical B/P/S");
            }
        }
        public static void Tempest(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Fog Cloud*");
            DomainSpells[1].Add("Thunderwave*");
            DomainSpells[2].Add("Gust of Wind*");
            DomainSpells[2].Add("Shatter*");
            DomainSpells[3].Add("Call Lightning*");
            DomainSpells[3].Add("Thunder Step*");
            DomainSpells[4].Add("Lightning Bolt*");
            DomainSpells[4].Add("Storm Sphere*");
            DomainSpells[5].Add("Control Winds*");
            DomainSpells[5].Add("Destructive Wave*");

            character.ClassFeatures.Add("Wrath of the Storm", "Wis/LR, reaction, when you are hit, Dex save, deal 2D8 Lightning or Thunder dmg");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Destructive Wrath)", "max Lightning or Thunder dmg");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Thunderbolt Strike", "when you deal Lightning dmg, push 10ft");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Thunder dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Thunder dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Stormborn", "gain fly speed = land speed when not underground or indoors");
            }
        }
        public static void Trickery(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Charm Person*");
            DomainSpells[1].Add("Disguise Self*");
            DomainSpells[2].Add("Mirror Image*");
            DomainSpells[2].Add("Pass Without Trace*");
            DomainSpells[3].Add("Blink*");
            DomainSpells[3].Add("Dispel Magic*");
            DomainSpells[4].Add("Dimension Door*");
            DomainSpells[4].Add("Polymorph*");
            DomainSpells[5].Add("Dominate Person*");
            DomainSpells[5].Add("Modify Memory*");

            character.ClassFeatures.Add("Blessing of the Trickster", "action, give ally adv on Stealth for 1 hr");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Invoke Duplicity)", "action, conc 1 min, 30ft, create illusory double, bonus to move it 30ft" +
                    "\n        it must remain within 120ft, if you and double are within 5ft of target you gain adv on atks");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Channel Divinity(Cloak of Shadows)", "action, 1 turn, become invisible");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Poison dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Poison dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Improved Duplicity", "create 4 copies instead of 1, bonus to move any number of them");
            }
        }
        public static void Twilight(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Faerie Fire*");
            DomainSpells[1].Add("Sleep*");
            DomainSpells[2].Add("Moonbeam*");
            DomainSpells[2].Add("See Invisibility*");
            DomainSpells[3].Add("Aura of Vitality*");
            DomainSpells[3].Add("Leomund's Tiny Hut*");
            DomainSpells[4].Add("Aura of Life*");
            DomainSpells[4].Add("Greater Invisibility*");
            DomainSpells[5].Add("Circle of Power*");
            DomainSpells[5].Add("Mislead*");

            character.Proficiencies.Add("Heavy Armor");
            character.Proficiencies.Add("Martial Weapons");
            character.ClassFeatures.Add("Eyes of Night", "LR or spell slot, action, 1 hr, 10ft, Wis creatures, share Darkvision" +
                "\n        gain Darkvision 300ft, dim light = bright light, darkness = dim light");
            character.Vision = "Darkvision 300ft";
            character.ClassFeatures.Add("Vigilant Blessing", "action, touch, 1 creature, give adv on Init");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Twilight Sanctuary)", "action, 1 min, 30ft, dim light, 1/turn - (grant temp HP = 1D6 + lvl) or (end charm or fear)");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Steps of Night", "PB/LR, bonus, 1 min, while in dim light or darkness, gain Fly speed");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Radiant dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Radiant dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Twilight Shroud", "you and allies in Twilight Sanctuary have half cover(+2 AC, Dex saves)");
            }
        }
        public static void War(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Divine Favor*");
            DomainSpells[1].Add("Shield of Faith*");
            DomainSpells[2].Add("Magic Weapon*");
            DomainSpells[2].Add("Spiritual Weapon*");
            DomainSpells[3].Add("Crusader's Mantle*");
            DomainSpells[3].Add("Spirit Guardians*");
            DomainSpells[4].Add("Freedom of Movement*");
            DomainSpells[4].Add("Stoneskin*");
            DomainSpells[5].Add("Flame Strike*");
            DomainSpells[5].Add("Hold Monster*");

            character.Proficiencies.Add("Heavy Armor");
            character.Proficiencies.Add("Martial Weapons");
            character.ClassFeatures.Add("War Priest", "Wis/LR, atk as bonus");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Guided Strike)", "+10 atk, after roll");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Channel Divinity(War God's Blessing)", "reaction, 30ft, give ally +10 atk");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 weapon dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 weapon dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Avatar of Battle", "gain Resistance to nonmagical B/P/S");
            }
        }
        public static void Water(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Fog Cloud*");
            DomainSpells[1].Add("Ice Knife*");
            DomainSpells[2].Add("Gust of Wind*");
            DomainSpells[2].Add("Misty Step*");
            DomainSpells[3].Add("Tidal Wave*");
            DomainSpells[3].Add("Wall of Water*");
            DomainSpells[4].Add("Ice Storm*");
            DomainSpells[4].Add("Watery Sphere*");
            DomainSpells[5].Add("Cone of Cold*");
            DomainSpells[5].Add("Maelstrom*");

            character.ClassFeatures.Add("Disciple of Water", "Waterbreathing, Swim 30ft, communicate basic ideas with sea creatures");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Call Sea Creatures", "total CR = 1/2 cleric lvl");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Fluid Movement", "reaction, +1D8 to AC");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Cold dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Cold dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Torrent of Water", "1/LR, cast Tsunami");
            }
        }
        public static void Zeal(Character character)
        {
            int lvl = character.Lvl;
            DomainSpells[1].Add("Searing Smite*");
            DomainSpells[1].Add("Thunderous Smite*");
            DomainSpells[2].Add("Magic Weapon*");
            DomainSpells[2].Add("Shatter*");
            DomainSpells[3].Add("Haste*");
            DomainSpells[3].Add("Fireball*");
            DomainSpells[4].Add("Fire Shield(warm only)*");
            DomainSpells[4].Add("Freedom of Movement*");
            DomainSpells[5].Add("Destructive Wave*");
            DomainSpells[5].Add("Flame Strike*");

            character.Proficiencies.Add("Heavy Armor");
            character.Proficiencies.Add("Martial Weapons");
            character.ClassFeatures.Add("Priest of Zeal", "Wis/LR, atk as bonus");
            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Channel Divinity(Consuming Fervor)", "max Fire or Thunder dmg");
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Resounding Strike", "when you deal Thunder dmg, push 10ft");
            }
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 weapon dmg");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures["Divine Strike"] = "1/turn, +2D8 weapon dmg";
            }
            if (lvl >= 17)
            {
                character.ClassFeatures.Add("Blaze of Glory", "LR, reaction, when you drop to 0 HP - move speed to attacker, mak an atk with adv, dmg + 5D10 weapon + 5D10 Fire");
            }
        }
        public static void Spells(Character character)
        {
            BEHelper.AddPrimSpells(character, DomainSpells);
            string pickMsg = "Pick a cantrip.";
            AllSpells spells = new AllSpells(character);
            for (int i = 0; i < character.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(spells.Cleric[0], character.Cantrips, pickMsg);
                character.Cantrips.Add(spell);
                spells.Cleric[0].Remove(spell);
            }
            pickMsg = "Pick a 1st level spell.";
            foreach (var slotLvl in character.SpellSlots.Keys)
            {
                pickMsg = CLIHelper.pickSpellLevel(slotLvl, pickMsg);
                int slots = character.SpellSlots[slotLvl];
                for (int i = 0; i < slots; i++)
                {
                    string spell = CLIHelper.GetNew(spells.Cleric[slotLvl], character.Spells[slotLvl], pickMsg);
                    character.Spells[slotLvl].Add(spell);
                    spells.Cleric[slotLvl].Remove(spell);
                }
            }
        }
    }
}
