using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class ClericSpecifics
    {
        public static string DivineDomain { get; set; }
        public static Dictionary<int, List<string>> DomainSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
        };
        public static CharacterClass Features(CharacterClass result, Character character)
        {
            int lvl = result.Lvl;
            string errorMsg = "";

            result.ClassFeatures.Add("Spellcasting", "use Wis for spell DCs, you use a Holy Symbol as a spell focus");
            string msg = "Pick a Divine Domain that will give you features at levels 2, 6, 8, and 17.";
            var archetype = new List<string> { "Ambition", "Arcana", "Death", "Forge", "Grave", "Ice", "Knowledge", "Life", "Light",
                "Nature", "Order", "Peace", "Solidarity", "Strength", "Tempest", "Trickery", "Twilight", "War", "Zeal" };
            int input = CLIHelper.PrintChoices(msg, archetype);
            DivineDomain = archetype[input];

            switch (DivineDomain)
            {
                case "Ambition":
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

                    result.ClassFeatures.Add("Warding Flare", "Wis/LR, reaction, 30ft, impose disadv, attacker can't be immune to blinding");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Invoke Duplicity)", "action, conc 1 min, 30ft, create illusory double, bonus to move it 30ft" +
                            "\nit must remain within 120ft, if you and double are within 5ft of target you gain adv on atks");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Cloak of Shadows)", "action, 1 turn, become invisible");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Potent Spellcasting", "cantrips + Wis dmg");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Improved Duplicity", "create 4 copies instead of 1, bonus to move any number of them");
                    }
                    break;
                case "Arcana":
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

                    result.ClassFeatures.Add("Arcane Initiate", "gain prof in Arcana and learn 2 Wizard cantrips");
                    character.SkillProficiencies.Add("Arcana");
                    Console.WriteLine("Arcane Initiate: gain prof in Arcana and 2 Wizard cantrips");
                    var wizCantrips = new List<string>();
                    wizCantrips.AddRange(WizardSpells.Cantrips);
                    string cantrip = CLIHelper.PrintChoices(wizCantrips);
                    character.Cantrips.Add(cantrip);
                    wizCantrips.Remove(cantrip);
                    cantrip = CLIHelper.PrintChoices(wizCantrips);
                    character.Cantrips.Add(cantrip);
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Arcane Abjuration)", "action, 30ft, 1 celestial/elemental/fey/fiend, present Holy Symbol, Wis save, the creature is turned");
                    }
                    if (lvl >= 5)
                    {
                        if (lvl < 8)
                        {
                            result.ClassFeatures["Channel Divinity(Arcane Abjuration)"] += "\nbanish CR 1/2 or lower for 1 min, no conc";
                        }
                        else
                        {
                            int CR = 1;
                            for (int i = 11; i <= lvl; i += 3)
                            {
                                CR++;
                            }
                            result.ClassFeatures["Channel Divinity(Arcane Abjuration)"] += $"\nbanish CR {CR} or lower for 1 min, no conc";
                        }
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Spellbreaker", "When you heal an ally, end 1 spell whose lvl is = or lower than the healing spell's lvl");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Potent Spellcasting", "cantrips + Wis dmg");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Arcane Mastery", "gain 6th, 7th, 8th, and 9th lvl Wizard spells (one each) as Domain spells");
                        Console.WriteLine("Arcane Mastery: gain 6th, 7th, 8th, and 9th lvl Wizard spells (one each) as Domain spells");
                        int wizSpellLvl = 6;
                        AllSpells wizSpells = new AllSpells("Wizard");
                        for (int i = 0; i < 4; i++)
                        {
                            string spell = CLIHelper.PrintChoices(wizSpells.Wizard[wizSpellLvl]);
                            character.Spells[wizSpellLvl].Add(spell + "*");
                            wizSpellLvl++;
                        }
                    }
                    break;
                case "Death":
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

                    result.Proficiencies.Add("Martial Weapons");
                    var necroCantrips = new List<string> { "Chill Touch", "Sapping Strike", "Spare the Dying", "Toll the Dead" };
                    Console.WriteLine("Pick a Necromancy cantrip");
                    string necro = CLIHelper.PrintChoices(necroCantrips);
                    result.Cantrips.Add(necro);
                    result.ClassFeatures.Add("Reaper", "Necromancy cantrips that target 1 creature can target 2 if adj");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Touch of Death)", "when you hit with melee, extra Necrotic dmg = 5 + (lvl x 2)");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Inescapable Destruction", "spells and Channel Divinity that deal Necrotic dmg ignore Resistance");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Necrotic dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Necrotic dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Improved Reaper", "Necromancy spells 1st-5th that target 1 creature can target 2 if adj");
                    }
                    break;
                case "Forge":
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

                    result.Proficiencies.Add("Heavy Armor");
                    result.Proficiencies.Add("Smith's Tools");
                    result.ClassFeatures.Add("Blessing of the Forge", "LR, enchant one item, +1 AC or +1 atk/dmg");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Artisan's Blessing)", "ritual, 1 hr, create metal equipment, can duplicate items if you have the original");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Soul of the Forge", "gain Resistance to Fire, +1 AC while wearing Heavy Armor");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Cold dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Cold dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Saints of Forge and Fire", "gain immunity to Fire, while wearing Heavy Armor, gain Resistance to nonmagical B/P/S");
                    }
                    break;
                case "Grave":
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

                    result.ClassFeatures.Add("Circle of Mortality", "when you use heal spell on ally with 0 HP, heal max on spell");
                    result.Cantrips.Add("Spare the Dying(bonus, 30ft)");
                    result.ClassFeatures.Add("Eyes of the Grave", "Wis/LR, action, 60ft, not behind total cover, detect the location of undead");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Path to the Grave)", "action, 30ft, one creature, suffer vulnerability on next hit");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Senitel at Death's Door", "Wis/LR, reaction, 30ft, when you or an ally suffers a crit, turn the crit into a normal hit");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Potent Spellcasting", "cantrips + Wis dmg");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Keeper of Souls", "1/turn, 60ft, when a creature dies, you or an ally regain HP = creature's HitDice");
                    }
                    break;
                case "Ice":
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

                    result.ClassFeatures.Add("Disciple of Water", "Waterbreathing, Swim 30ft, communicate basic ideas with sea creatures");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Call Sea Creatures", "total CR = 1/2 cleric lvl");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Fluid Movement", "reaction, +1D8 to AC");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Cold dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Cold dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Torrent of Water", "1/LR, cast Tsunami");
                    }
                    break;
                case "Knowledge":
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

                    result.ClassFeatures.Add("Blessings of Knowledge", "gain 2 languages and 2 skills");
                    var skills = new List<string> { "Arcana", "History", "Nature", "Religion" };
                    Console.WriteLine($"Clerics of Knowledge gain 2 languages and 2 skills from: {String.Join(", ", skills)}");
                    string msg1 = "Pick the 1st language now";
                    errorMsg = "You already have that language, try again.";
                    string firstLanguage = CLIHelper.GetNew(Options.Languages, character.Languages, msg, errorMsg);
                    character.Languages.Add(firstLanguage);
                    msg1 = "Pick the 2nd language now";
                    string secondLanguage = CLIHelper.GetNew(Options.Languages, character.Languages, msg, errorMsg);
                    character.Languages.Add(secondLanguage);
                    msg1 = "Pick the 1st skill now";
                    errorMsg = "You are already trained in that skill, pick a different skill.";
                    string firstSkill = CLIHelper.GetNew(skills, character.SkillProficiencies, msg1, errorMsg);
                    character.SkillProficiencies.Add(firstSkill);
                    msg1 = "Pick the 2nd skill now";
                    string secondSkill = CLIHelper.GetNew(skills, character.SkillProficiencies, msg1, errorMsg);
                    character.SkillProficiencies.Add(secondSkill);

                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Knowledge of the Ages)", "gain prof in 1 skill or tool for 10min");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Read Thoughts)", "LR, action, 60ft, Wis save, 1 min - read surface thoughts, auto-fail for Suggestion spell");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Potent Spellcasting", "cantrip dmg + Wis");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Visions of the Past", "1/SR, meditate for 1 min - Object reading: see visions of previous owner," +
                            "\nArea Reading: see visions of recent or significant events");
                    }
                    break;
                case "Life":
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
                    result.ClassFeatures.Add("Disciple of Life", "healing spells heal extra 2 + spell lvl HP");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Preserve Life)", "action, 30ft, heal lvl x 5 HP, can't go above bloody value, can divide among creatures");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Blessed Healer", "when you cast healing spell, heal yourself 2 + spell lvl HP");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Radiant dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Radiant dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Supreme Healing", "max all healing dice rolls");
                    }
                    break;
                case "Light":
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
                    result.ClassFeatures.Add("Warding Flare", "Wis/LR, reaction, 30ft, impose disadv, attacker can't be immune to blinding");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Radiance of Dawn)", "action, 30ft, Con save, 2D10 + lvl Radiant dmg, dispel magical darkness");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Improved Flare", "you can use Warding Flare when an ally is attacked");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Potent Spellcasting", "dmg + Wis with cantrips");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Corona of Light", "action, 1 min, bright light 60ft, disadv on saves vs Fire or Radiant dmg");
                    }
                    break;
                case "Nature":
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

                    result.ClassFeatures.Add("Acolyte of Nature", "learn a Druid cantrip and a skill");
                    msg = "Pick a Druid cantrip";
                    int index = CLIHelper.PrintChoices(msg, DruidSpells.Cantrips);
                    string druidCantrip = DruidSpells.Cantrips[index];
                    character.Cantrips.Add(druidCantrip);
                    var list = new List<string> { "Animal Handling", "Nature", "Survival" };
                    msg = "Pick a skill from the list";
                    errorMsg = "You already know that skill";
                    string skill = CLIHelper.GetNew(list, character.SkillProficiencies, msg, errorMsg);
                    character.SkillProficiencies.Add(skill);
                    character.Proficiencies.Add("Heavy Armor");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Charm Animals and Plants)", "action, 30ft, Wis save, charm 1 min");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Dampen Elements", "reaction, when you or ally within 30ft takes Cold, Fire, or Lighting dmg - gain Resistance");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Cold, Fire, or Lighting dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Cold, Fire, or Lighting dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Master of Nature", "bonus, command creatures charmed by your Channel Divinity");
                    }
                    break;
                case "Order":
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

                    result.Proficiencies.Add("Heavy Armor");
                    Console.WriteLine("Pick a skill to gain proficiency in");
                    string skillProf = String.Join(", ", character.SkillProficiencies);
                    Console.WriteLine($"Your skill proficiencies are: {skillProf}");
                    CLIHelper.Print2Choices("Intimidation", "Persuasion");
                    int num = CLIHelper.GetNumberInRange(1, 2);
                    if (num == 1)
                    {
                        result.SkillProficiencies.Add("Intimidation");
                    }
                    else
                    {
                        result.SkillProficiencies.Add("Persuasion");
                    }
                    result.ClassFeatures.Add("Voice of Authority", "when you cast a non-cantrip spell on an ally, 1 ally can use reaction to make a weapon atk");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Order's Demand)", "action, 30ft, Wis save, charm, drop what they're holding");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Embodiment of the Law", "Wis/LR, Enchantment spells that require an action can be cast as a bonus");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Psychic dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Psychic dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Order's Wrath", "1/turn, curse a creature you dmg with Divine Strike, next ally's dmg + 2D8 Psychic");
                    }
                    break;
                case "Peace":
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
                    skillProf = String.Join(", ", character.SkillProficiencies);
                    Console.WriteLine($"Your skill proficiencies are: {skillProf}");
                    CLIHelper.Print3Choices("Insight", "Performance", "Persuasion");
                    num = CLIHelper.GetNumberInRange(1, 3);
                    if (num == 1)
                    {
                        result.SkillProficiencies.Add("Insight");
                    }
                    else if (num == 2)
                    {
                        result.SkillProficiencies.Add("Performance");
                    }
                    else
                    {
                        result.SkillProficiencies.Add("Persuasion");
                    }
                    result.ClassFeatures.Add("Emboldening Bond", "PB/LR, action, 10 min, 30ft, PB creatures, 1/turn, when 30ft from ally - atk, check, save + 1D4");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Balm of Peace)", "action, move your speed no atk op, when adj to ally - heal ally 2D6 + Wis");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Protective Bond", "reaction, 30ft, when creature with Emboldening Bond takes dmg, you and allies can teleport adj and take all dmg instead");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Potent Spellcasting", "cantrips + Wis dmg");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Expansive Bond", "the range on Emboldening and Protective Bond = 60ft, Protective Bond grants Resistance");
                    }
                    break;
                case "Solidarity":
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

                    result.Proficiencies.Add("Heavy Armor");
                    result.ClassFeatures.Add("Solidarity's Action", "Wis/LR, bonus, when you take Help action, make a weapon atk");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinty(Preserve Life)", "action, 30ft, distribute HP to regain = lvl x 5");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Oketra's Blessing)", "reaction, 30ft, 1 creature, when an atk is made gain +10 atk");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 weapon dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 weapon dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Supreme Healing", "when you roll to restore HP, treat the dice as their max value");
                    }
                    break;
                case "Strength":
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

                    result.ClassFeatures.Add("Acolyte of Strength", "gain a Druid cantrip and a skill");
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
                    result.Cantrips.Add(newCantrip);
                    var str = new List<string> { "Animal Handling", "Athletics", "Nature", "Survival" };
                    string allSkills = String.Join(", ", character.SkillProficiencies);
                    Console.WriteLine($"Pick a skill your proficiencies are: {allSkills}");
                    string strSkill = CLIHelper.PrintChoices(str);
                    character.SkillProficiencies.Add(strSkill);
                    result.Proficiencies.Add("Heavy Armor");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Feat of Strength)", "when you make a Str check, atk or save, after roll, atk + 10");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Rhona's Blessing)", "reaction, 30ft, 1 creature, when a Str check, atk or save is made, after roll, atk + 10");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 weapon dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 weapon dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Avatar of Battle", "gain Resistance to nonmagical B/P/S");
                    }
                    break;
                case "Tempest":
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

                    result.ClassFeatures.Add("Wrath of the Storm", "Wis/LR, reaction, Dex save, deal 2D8 Lightning or Thunder dmg");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Destructive Wrath)", "max Lightning or Thunder dmg");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Thunderbolt Strike", "when you deal Lightning dmg, push 10ft");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Thunder dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Thunder dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Stormborn", "gain fly speed = land speed when not underground or indoors");
                    }
                    break;
                case "Trickery":
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

                    result.ClassFeatures.Add("Blessing of the Trickster", "action, give ally adv on Stealth for 1 hr");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Invoke Duplicity)", "action, conc 1 min, 30ft, create illusory double, bonus to move it 30ft" +
                            "\nit must remain within 120ft, if you and double are within 5ft of target you gain adv on atks");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Cloak of Shadows)", "action, 1 turn, become invisible");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Poison dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Poison dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Improved Duplicity", "create 4 copies instead of 1, bonus to move any number of them");
                    }
                    break;
                case "Twilight":
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

                    result.Proficiencies.Add("Heavy Armor");
                    result.Proficiencies.Add("Martial Weapons");
                    result.ClassFeatures.Add("Eyes of Night", "LR or spell slot, action, 1 hr, 10ft, Wis creatures, share Darkvision" +
                        "\ngain Darkvision 300ft, dim light = bright light, darkness = dim light,");
                    character.Vision = "Darkvision 300ft";
                    result.ClassFeatures.Add("Vigilant Blessing", "action, touch, 1 creature, give adv on Init");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Twilight Sanctuary)", "action, 1 min, 30ft, dim light, 1/turn - (grant temp HP = 1D6 + lvl) or (end charm or fear)");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Steps of Night", "PB/LR, bonus, 1 min, while in dim light or darkness, gain Fly speed");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 Radiant dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 Radiant dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Twilight Shroud", "you and allies in Twilight Sanctuary have half cover");
                    }
                    break;
                case "War":
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
                    result.ClassFeatures.Add("War Priest", "Wis/LR, atk as bonus");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Guided Strike)", "+10 atk, after roll");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Channel Divinity(War God's Blessing)", "reaction, 30ft, give ally +10 atk");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 weapon dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 weapon dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Avatar of Battle", "gain Resistance to nonmagical B/P/S");
                    }
                    break;
                case "Zeal":
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

                    result.Proficiencies.Add("Heavy Armor");
                    result.Proficiencies.Add("Martial Weapons");
                    result.ClassFeatures.Add("Priest of Zeal", "Wis/LR, atk as bonus");
                    if (lvl >= 2)
                    {
                        result.ClassFeatures.Add("Channel Divinity(Consuming Fervor)", "max Fire or Thunder dmg");
                    }
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Resounding Strike", "when you deal Thunder dmg, push 10ft");
                    }
                    if (lvl >= 8)
                    {
                        result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 weapon dmg");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 weapon dmg";
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("Blaze of Glory", "LR, reaction, when you drop to 0 HP - move speed to attacker, mak an atk with adv, dmg + 5D10 weapon + 5D10 Fire");
                    }
                    break;
            }

            result.Spells[1].AddRange(DomainSpells[1]);
            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Channel Divinity(Turn Undead)", "action, 30ft, Wis save - turn 1 min");
                result.ClassFeatures.Add("Channel Divinity uses", "1/SR");
                result.ClassFeatures.Add("Harness Divine Power", "bonus, expend a Channel Divinity use to regain a spell slot = 1/2 PB");
            }
            if (lvl >= 3)
            {
                result.ClassFeatures.Add("Cantrip Versatility", "When you get an Ability Score Improvement, you can replace a cantrip");
            }
            if (lvl >= 4)
            {
                result.Spells[1].AddRange(DomainSpells[2]);
            }
            if (lvl >= 5)
            {
                result.Spells[1].AddRange(DomainSpells[3]);
                int CR = 0;
                result.ClassFeatures.Add("Destroy Undead", "CR under 1/2 that fail against Turn Undead are instantly destroyed");
                for (int i = 8; i <= lvl ; i += 3)
                {
                    CR++;
                    result.ClassFeatures["Destroy Undead"] = $"CR under {CR} that fail against Turn Undead are instantly destroyed";
                }
            }
            if (lvl >= 6)
            {
                result.ClassFeatures["Channel Divinity uses"] = "2/SR";
            }
            if (lvl >= 7)
            {
                result.Spells[1].AddRange(DomainSpells[4]);
            }
            if (lvl >= 8)
            {
                result.ClassFeatures.Add("Blessed Strikes", "instead of Divine Strike or Potent Spellcasting, weapon or cantrip dmg + 1D8 Radiant");
            }
            if (lvl >= 9)
            {
                result.Spells[1].AddRange(DomainSpells[5]);
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Divine Intervention", "if % dice roll <= lvl, DM decides nature of intervention, recharge 7 days, retry LR");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures["Channel Divinity uses"] = "3/SR";
            }
            if (lvl >= 20)
            {
                result.ClassFeatures["Divine Intervention"] = "automatically succeed, DM decides nature of intervention";
            }
            //spells code
            string pickMsg = "Pick a cantrip.";
            string str2 = "You already have that cantrip.";
            int spellLvl = 1;
            AllSpells spells = new AllSpells(character.ChosenClass);
            for (int i = 0; i < result.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(spells.Cleric[0], result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
                spells.Cleric[0].Remove(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            for (int i = 1; i <= lvl; i++)
            {
                if (i % 2 != 0)
                {
                    if (3 <= i && i <= 17)
                    {
                        spellLvl++;
                    }
                    if (i == 3)
                    {
                        pickMsg = "Pick a 2nd level spell.";
                    }
                    if (i == 5)
                    {
                        pickMsg = "Pick a 3rd level spell.";
                    }
                    if (i >= 7)
                    {
                        pickMsg = $"Pick a {spellLvl}th level spell.";
                    }
                    if (lvl <= 5)
                    {
                        string spell2 = CLIHelper.GetNew(spells.Cleric[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                        result.Spells[spellLvl].Add(spell2);
                    }
                    if (lvl >= 13)
                    {
                        string spell2 = CLIHelper.GetNew(spells.Cleric[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                        result.Spells[spellLvl].Add(spell2);
                    }
                }
                if (lvl <= 11)
                {
                    string spell = CLIHelper.GetNew(spells.Cleric[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                    result.Spells[spellLvl].Add(spell);
                    spells.Cleric[spellLvl].Remove(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
