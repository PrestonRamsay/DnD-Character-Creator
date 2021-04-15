using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces
{
    public static class Feats
    {
        public static List<string> FeatNames { get; set; } = new List<string> { "Acute Fighting", "Alert", "Arcane Initiate", "Athlete", 
            "Actor", "Charger", "Chef", "Crossbow Expert", "Crusher", "Defensive Duelist", "Dual Wielder", "Dungeon Delver", "Durable", 
            "Eldritch Adept", "Elemental Adept", "Fey Touched", "Fighting Initiate", "Finesse Weapon Master", "Grappler", "Great Weapon Master", 
            "Gunner", "Healer", "Heavily Armored", "Heavy Armor Master", "Improved Critical", "Insightful Reflexes", "Inspiring Leader", 
            "Jack of All Trades", "Keen Mind", "Lightly Armored", "Linguist", "Lucky", "Mage Slayer", "Magic Initiate", "Martial Adept", 
            "Medium Armor Master", "Metamagic Adept", "Mobile", "Moderately Armored", "Mounted Combatant", "Observant", "Piercer", 
            "Point Blank Shot", "Poisoner", "Polearm Master", "Rapid Shot", "Regeneration", "Resilient", "Ritual Caster", "Savage Attacker", 
            "Sentinel", "Shadow Touched", "Sharpshooter", "Shield Master", "Skill Expert", "Skilled", "Skirmisher", "Skulker", "Slasher", 
            "Spell Focus", "Spell Sniper", "Tavern Brawler", "Telekinetic", "Telepathic", "Tough", "Unarmored Defense", "War Caster", 
            "Weapon Focus", "Weapon Master", "Whirlwind Attack" };
        public static List<string> OneStatFeats { get; set; } = new List<string> { "Actor", "Durable", "Dwarven Fortitude", "Gunner", 
            "Heavy Armor Master", "Heavily Armored", "Infernal Constitution", "Keen Mind", "Lingusit" };
        public static List<string> StatFeats { get; set; } = new List<string> { "Chef", "Crusher", "Dragon Fear", "Dragon Hide",
            "Elven Accuracy", "Fey Teleportation", "Flames of Phlegethos", "Observant", "Orcish Fury", "Second Chance" };
        public static List<string> StrDexFeats { get; set; } = new List<string> { "Athlete", "Lightly Armored", "Moderately Armored", 
            "Piercer", "Slasher", "Squat Nimbleness", "Tavern Brawler", "Weapon Master" };
        public static List<string> IntWisChaFeats { get; set; } = new List<string> { "Fey Touched", "Shadow Touched", "Telekinetic", 
            "Telepathic" };
        public static List<string> SpellFeats { get; set; } = new List<string> { "Arcane Initiate", "Drow High Magic", "Fey Touched", 
            "Magic Initiate", "Ritual Caster", "Shadow Touched", "Telekinetic", "Wood Elf Magic" };
        public static void AddFeat(Character character)
        {
            string race = "";
            var elves = new List<string> { "Avariel", "Eladrin", "Moon Elf", "Sea Elf", "Shadar-Kai", "Wild Elf" };
            if (character.ChosenRace.Contains("Dwarf"))
            {
                race = "Dwarf";
            }
            else if (elves.Contains(character.ChosenRace))
            {
                race = "Elf";
            }
            else if (character.ChosenRace.Contains("Gnome"))
            {
                race = "Gnome";
            }
            else if (character.ChosenRace.Contains("Halfling"))
            {
                race = "Halfling";
            }
            else if (character.ChosenRace.Contains("Human"))
            {
                race = "Human";
            }
            else if (character.ChosenRace.Contains("Tiefling"))
            {
                race = "Tiefling";
            }
            else
            {
                race = character.ChosenRace;
            }
            switch (race)
            {
                case "Cambion":
                    FeatNames.Add("Flames of Phlegethos");
                    FeatNames.Add("Infernal Constitution");
                    break;
                case "Dragonborn":
                    FeatNames.Add("Dragon Fear");
                    FeatNames.Add("Dragon Hide");
                    break;
                case "Dwarf":
                    FeatNames.Add("Dwarven Fortitude");
                    FeatNames.Add("Squat Nimbleness");
                    break;
                case "Elf":
                    FeatNames.Add("Elven Accuracy");
                    break;
                case "Drow":
                    FeatNames.Add("Drow High Magic");
                    FeatNames.Add("Elven Accuracy");
                    break;
                case "High Elf":
                    FeatNames.Add("Elven Accuracy");
                    FeatNames.Add("Fey Teleportation");
                    break;
                case "Wood Elf":
                    FeatNames.Add("Elven Accuracy");
                    FeatNames.Add("Wood Elf Magic");
                    break;
                case "Gnome":
                    FeatNames.Add("Fade Away");
                    FeatNames.Add("Squat Nimbleness");
                    break;
                case "Half-Elf":
                    FeatNames.Add("Elven Accuracy");
                    FeatNames.Add("Prodigy");
                    break;
                case "Half-Orc":
                    FeatNames.Add("Orcish Fury");
                    FeatNames.Add("Prodigy");
                    break;
                case "Halfling":
                    FeatNames.Add("Bountiful Luck");
                    FeatNames.Add("Second Chance");
                    FeatNames.Add("Squat Nimbleness");
                    break;
                case "Human":
                    FeatNames.Add("Prodigy");
                    break;
                case "Tiefling":
                    FeatNames.Add("Flames of Phlegethos");
                    FeatNames.Add("Infernal Constitution");
                    break;
            }
            FeatNames.Sort();
            string feat = CLIHelper.PrintChoices(Options.FeatDefinitions, FeatNames, "Pick a feat");
            character.Feats.Add(feat, Options.FeatDefinitions[feat]);
            FeatNames.Remove(feat);
            AddFeatBenefits(character, feat);
        }
        public static void AddFeatBenefits(Character character, string feat)
        {
            string stat = "";
            if (OneStatFeats.Contains(feat))
            {
                stat = Options.FeatDefinitions[feat].Substring(8, 3);
                Stats.IncreaseStat(character, stat, 1);
            }
            var choices = new List<string>();
            switch (feat)
            {
                case "Chef":
                    choices = new List<string> { "Con", "Wis" };
                    character.Proficiencies.Add("Cook's Utensils");
                    break;
                case "Crusher":
                    choices = new List<string> { "Str", "Con" };
                    break;
                case "Dragon Fear":
                    choices = new List<string> { "Str", "Con", "Cha" };
                    break;
                case "Dragon Hide":
                    choices = new List<string> { "Str", "Con", "Cha" };
                    break;
                case "Elven Accuracy":
                    choices = new List<string> { "Dex", "Int", "Wis", "Cha" };
                    break;
                case "Fey Teleportation":
                    choices = new List<string> { "Int", "Cha" };
                    character.Languages.Add("Sylvan");
                    break;
                case "Flames of Phlegethos":
                    choices = new List<string> { "Int", "Cha" };
                    break;
                case "Observant":
                    choices = new List<string> { "Int", "Wis" };
                    break;
                case "Orcish Fury":
                    choices = new List<string> { "Str", "Con" };
                    break;
                case "Second Chance":
                    choices = new List<string> { "Dex", "Con", "Cha" };
                    break;
            }
            if (StrDexFeats.Contains(feat))
            {
                choices = new List<string> { "Str", "Dex" };
                StatFeats.AddRange(StrDexFeats);
            }
            if (IntWisChaFeats.Contains(feat))
            {
                choices = new List<string> { "Int", "Wis", "Cha" };
                StatFeats.AddRange(IntWisChaFeats);
            }
            if (StatFeats.Contains(feat))
            {
                Console.WriteLine("Pick a stat to increase by 1");
                stat = CLIHelper.PrintChoices(choices);
                Stats.IncreaseStat(character, stat, 1);
            }

            if (SpellFeats.Contains(feat))
            {
                string cantrip = "";
                string spell = "";
                switch (feat)
                {
                    case "Arcane Initiate":
                        Console.WriteLine("Pick an Artificer cantrip");
                        cantrip = CLIHelper.PrintChoices(ArtificerSpells.Cantrips);
                        character.Cantrips.Add(cantrip);
                        Console.WriteLine("Pick a 1st lvl Artificer spell");
                        spell = CLIHelper.PrintChoices(ArtificerSpells.FirstLvls);
                        character.Spells[1].Add(spell);
                        Console.WriteLine("Pick a set of Artisan's Tools to gain proficiency with");
                        string tool = CLIHelper.PrintChoices(Options.ArtisanTools);
                        character.ToolProficiencies.Add(tool);
                        break;
                    case "Drow High Magic":
                        character.Spells[1].Add("Detect Magic(at-will)");
                        character.Spells[2].Add("Levitate(1/LR, Cha to cast)");
                        character.Spells[3].Add("Dispel Magic(1/LR, Cha to cast)");
                        break;
                    case "Fey Touched":
                        choices.AddRange(AllSpells.FirstLvlDivination);
                        choices.AddRange(AllSpells.FirstLvlEnchantment);
                        choices.Sort();
                        Console.WriteLine("Pick a 1st lvl divination or enchantment spell");
                        spell = CLIHelper.PrintChoices(choices);
                        character.Spells[1].Add(spell + "(Fey Touched)");
                        break;
                    case "Magic Initiate":
                        Tuple<Dictionary<int, List<string>>, string> spellClass = PickClassForSpells();
                        Dictionary<int, List<string>> spellList = spellClass.Item1;
                        stat = spellClass.Item2;
                        Console.WriteLine("Pick 2 cantrips");
                        cantrip = CLIHelper.PrintChoices(spellList[0]);
                        character.Cantrips.Add(cantrip);
                        spellList[0].Remove(cantrip);
                        cantrip = CLIHelper.PrintChoices(spellList[0]);
                        character.Cantrips.Add(cantrip);
                        int index = CLIHelper.PrintChoices("Pick a 1st lvl spell", spellList[1]);
                        spell = spellList[1][index];
                        character.Spells[1].Add(spell + $"(1/LR, {stat} to cast)");
                        break;
                    case "Ritual Caster":
                        var classes = new List<string> { "Bard", "Cleric", "Druid", "Sorcerer", "Warlock", "Wizard" };
                        index = CLIHelper.PrintChoices("Pick a class that will determine the spells you can gain", classes);
                        string spellcastingClass = classes[index];
                        Tuple<List<string>, string> ritualClass = PickClassForSpells(spellcastingClass);
                        List<string> ritualSpellList = ritualClass.Item1;
                        stat = ritualClass.Item2;
                        Console.WriteLine("Pick 2 ritual spells");
                        spell = CLIHelper.PrintChoices(ritualSpellList);
                        character.Spells[1].Add(spell + $"({stat} to cast)");
                        ritualSpellList.Remove(spell);
                        spell = CLIHelper.PrintChoices(ritualSpellList);
                        character.Spells[1].Add(spell + $"ritual, ({stat} to cast)");
                        break;
                    case "Shadow Touched":
                        choices.AddRange(AllSpells.FirstLvlIllusion);
                        choices.AddRange(AllSpells.FirstLvlNecromancy);
                        choices.Sort();
                        Console.WriteLine("Pick a 1st lvl divination or enchantment spell");
                        spell = CLIHelper.PrintChoices(choices);
                        character.Spells[1].Add(spell + "(Fey Touched)");
                        break;
                    case "Telekinetic":
                        character.Cantrips.Add("Mage Hand(feat)");
                        break;
                    case "Wood Elf Magic":
                        Console.WriteLine("Pick a Druid cantrip");
                        cantrip = CLIHelper.PrintChoices(DruidSpells.Cantrips);
                        character.Cantrips.Add(cantrip);
                        character.Spells[1].Add("Longstrider(1/LR, Wis to cast)");
                        character.Spells[2].Add("Pass without Trace(1/LR, Wis to cast)");
                        break;
                }
            }
            switch (feat)
            {
                case "Alert":
                    character.Init += 5;
                    break;
                case "Dual Wielder":
                    character.AC += 1;
                    break;
                case "Eldritch Adept":
                    var invoc = new List<string> { "Armor of Shadows", "Beast Speech", "Beguiling Influence", "Devil's Sight",
                            "Eldritch Mind", "Eldritch Sight", "Eyes of the Rune Keeper", "Fiendish Vigor", "Gaze of Two Minds",
                            "Grasp of Hadar", "Lance of Lethargy", "Mask of Many Faces", "Misty Visions", "Thief of Five Fates" };
                    string newInvoc = CLIHelper.PrintChoices(Options.AllInvocations, invoc, "Pick an Invocation");
                    character.ClassFeatures.Add("Invocations", "\n        ------------------------------------");
                    character.ClassFeatures.Add(newInvoc, Options.AllInvocations[newInvoc]);
                    invoc.Remove(newInvoc);
                    newInvoc = CLIHelper.PrintChoices(Options.AllInvocations, invoc, "Pick an Invocation");
                    character.ClassFeatures.Add(newInvoc, Options.AllInvocations[newInvoc]);
                    break;
                case "Fighting Initiate":
                    string fightStyleMsg = "Pick a fighting style.";
                    List<string> styleList = new List<string>();
                    foreach (var style in Options.FightingStyles.Keys)
                    {
                        if (style != "Blessed Warrior" || style != "Druidic Warrior" || style != "Superior Technique")
                        {
                            styleList.Add(style);
                        }
                    }
                    string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                    string fightStyleKey = $"Fighting Style({fightStyle})";
                    string fightStyleValue = Options.FightingStyles[fightStyle];
                    character.ClassFeatures.Add(fightStyleKey, fightStyleValue);
                    break;
                case "Gunner":
                    character.Proficiencies.Add("Firearms");
                    break;
                case "Heavily Armored":
                    character.Proficiencies.Add("Heavy Armor");
                    break;
                case "Lightly Armored":
                    character.Proficiencies.Add("Light Armor");
                    break;
                case "Lingusit":
                    Console.WriteLine("You gain 3 languages of your choice. Pick the first language now");
                    string pickMsg = "Pick another language";
                    string errorMsg = "You already have that language";
                    string lang = CLIHelper.PrintChoices(Options.Languages);
                    character.Languages.Add(lang);
                    lang = CLIHelper.GetNew(Options.Languages, character.Languages, pickMsg, errorMsg);
                    character.Languages.Add(lang);
                    lang = CLIHelper.GetNew(Options.Languages, character.Languages, pickMsg, errorMsg);
                    character.Languages.Add(lang);
                    break;
                case "Martial Adept":
                    List<string> maneuvers = CLIHelper.GetDictionaryOptions(Options.Maneuvers, 2, "Pick a new maneuver");
                    character.ClassFeatures.Add("Maneuvers(D6)", "\n        ------------------------------------");
                    foreach (var item in maneuvers)
                    {
                        character.ClassFeatures.Add(item, Options.Maneuvers[item]);
                    }
                    break;
                case "Medium Armor Master":
                    character.AC += 1;
                    break;
                case "Metamagic Adept":
                    var metamagicList = new List<string>();
                    foreach (var item in Options.Metamagic.Keys)
                    {
                        metamagicList.Add(item);
                    }
                    Console.WriteLine("You get 2 metamagic options of your choice");
                    string metamagic = CLIHelper.PrintChoices(Options.Metamagic, metamagicList, "Pick an option");
                    character.ClassFeatures.Add("Metamagic Options", "\n        ------------------------------------");
                    character.ClassFeatures.Add(metamagic, Options.Metamagic[metamagic]);
                    metamagicList.Remove(metamagic);
                    break;
                case "Mobile":
                    character.Speed += 10;
                    break;
                case "Moderately Armored":
                    character.Proficiencies.Add("Heavy Armor");
                    break;
                case "Prodigy":
                    break;
                case "Resilient":
                    string resStat = Stats.IncreaseStat(character, 1, true);
                    character.Saves.Add(resStat);
                    break;
                case "Skill Expert":
                    Stats.IncreaseStat(character, 1);
                    Console.WriteLine("Pick a skill to gain Expertise in");
                    var prof = new List<string>();
                    prof.AddRange(character.SkillProficiencies);
                    string expertise = CLIHelper.PrintChoices(prof);
                    character.Skills[expertise] += character.ProficiencyBonus;
                    int index = CLIHelper.PrintChoices("Pick a skill to gain proficiency", Options.Skills);
                    character.SkillProficiencies.Add(Options.Skills[index]);
                    break;
                case "Squat Nimbleness":
                    var skills = new List<string> { "Acrobatics", "Athletics" };
                    index = CLIHelper.PrintChoices("Pick a skill", skills);
                    character.SkillProficiencies.Add(skills[index]);
                    break;
                case "Tavern Brawler":
                    character.Proficiencies.Add("Improvised Weapons");
                    character.Proficiencies.Add("Unarmed Strike");
                    break;
            }
        }
        public static Tuple<Dictionary<int, List<string>>, string> PickClassForSpells()
        {
            var result = new Dictionary<int, List<string>>();
            string stat = "";
            var classes = new List<string> { "Bard", "Cleric", "Druid", "Sorcerer", "Warlock", "Wizard" };
            int index = CLIHelper.PrintChoices("Pick a class that will determine the spells you can gain", classes);
            string spellcastingClass = classes[index];
            AllSpells spells = new AllSpells(spellcastingClass);

            switch (spellcastingClass)
            {
                case "Bard":
                    foreach (var item in spells.Bard.Keys)
                    {
                        result.Add(item, spells.Bard[item]);
                    }
                    stat = "Cha";
                    break;
                case "Cleric":
                    foreach (var item in spells.Cleric.Keys)
                    {
                        result.Add(item, spells.Cleric[item]);
                    }
                    stat = "Wis";
                    break;
                case "Druid":
                    foreach (var item in spells.Druid.Keys)
                    {
                        result.Add(item, spells.Druid[item]);
                    }
                    stat = "Wis";
                    break;
                case "Sorcerer":
                    foreach (var item in spells.Sorcerer.Keys)
                    {
                        result.Add(item, spells.Sorcerer[item]);
                    }
                    stat = "Cha";
                    break;
                case "Warlock":
                    foreach (var item in spells.Warlock.Keys)
                    {
                        result.Add(item, spells.Warlock[item]);
                    }
                    stat = "Cha";
                    break;
                case "Wizard":
                    foreach (var item in spells.Wizard.Keys)
                    {
                        result.Add(item, spells.Wizard[item]);
                    }
                    stat = "Int";
                    break;
            }
            return new Tuple<Dictionary<int, List<string>>, string>(result, stat);
        }
        public static Tuple<List<string>, string> PickClassForSpells(string spellcastingClass)
        {
            var result = new List<string>();
            string stat = "";

            switch (spellcastingClass)
            {
                case "Bard":
                    result = new List<string> { "Comprehend Languages", "Detect Magic", "Identify", "Illusory Script", 
                        "Speak with Animals", "Unseen Servant" };
                    stat = "Cha";
                    break;
                case "Cleric":
                    result = new List<string> { "Ceremony", "Detect Magic", "Detect Poison and Disease", "Purify Food and Drink" };
                    stat = "Wis";
                    break;
                case "Druid":
                    result = new List<string> { "Detect Magic", "Detect Poison and Disease", "Purify Food and Drink", "Speak with Animals" };
                    stat = "Wis";
                    break;
                case "Sorcerer":
                    result = new List<string> { "Comprehend Languages", "Detect Magic" };
                    stat = "Cha";
                    break;
                case "Warlock":
                    result = new List<string> { "Comprehend Languages", "Illusory Script", "Unseen Servant" };
                    stat = "Cha";
                    break;
                case "Wizard":
                    result = new List<string> { "Alarm", "Comprehend Languages", "Detect Magic", "Find Familiar", "Identify", 
                        "Illusory Script", "Tenser's Floating Disk", "Unseen Servant" };
                    stat = "Int";
                    break;
            }
            return new Tuple<List<string>, string>(result, stat);
        }
        public static void GetSkillsOrTools(Character character)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Do you want a skill proficiency or a tool proficiency?");
                CLIHelper.Print2Choices("Skill proficiency", "Tool proficiency");
                int num = CLIHelper.GetNumberInRange(1, 2);
                if (num == 1)
                {
                    string skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, "Pick a skill", "You already have that skill");
                    character.SkillProficiencies.Add(skill);
                }
                else
                {
                    var allTools = new List<string>();
                    allTools.AddRange(Options.Tools);
                    allTools.AddRange(Options.ArtisanTools);
                    allTools.AddRange(Options.MusicalInstruments);
                    allTools.Remove("Artisan's Tools");
                    allTools.Remove("Musical Instrument");
                    string tool = CLIHelper.GetNew(allTools, character.ToolProficiencies, "Pick a tool", "You already have proficiency with that tool");
                    character.ToolProficiencies.Add(tool);
                }
            }
            if (character.Feats.ContainsKey("Prodigy"))
            {
                Console.WriteLine("Pick a skill to gain Expertise in");
                var prof = new List<string>();
                prof.AddRange(character.SkillProficiencies);
                string expertise = CLIHelper.PrintChoices(prof);
                character.Skills[expertise] += character.ProficiencyBonus;
                string skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, "Pick a skill", "You already have that skill");
                character.SkillProficiencies.Add(skill);
                var allTools = new List<string>();
                allTools.AddRange(Options.Tools);
                allTools.AddRange(Options.ArtisanTools);
                allTools.AddRange(Options.MusicalInstruments);
                allTools.Remove("Artisan's Tools");
                allTools.Remove("Musical Instrument");
                string tool = CLIHelper.GetNew(allTools, character.ToolProficiencies, "Pick a tool", "You already have proficiency with that tool");
                character.ToolProficiencies.Add(tool);
                string lang = CLIHelper.GetNew(Options.Languages, character.Languages, "Pick a language", "You already know that language");
                character.Languages.Add(lang);
            }
        }
    }
}
