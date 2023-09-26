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
            foreach (var feat in character.Feats.Keys)
            {
                if (FeatNames.Contains(feat))
                {
                    FeatNames.Remove(feat);
                }
            }
            Console.Clear();
            string newFeat = CLIHelper.PrintChoices(Options.FeatDefinitions, FeatNames, "Pick a feat");
            character.Feats.Add(newFeat, Options.FeatDefinitions[newFeat]);
            AddFeatBenefits(character, newFeat);
        }
        public static void AddFeatBenefits(Character character, string feat)
        {
            string stat = "";
            string lang = "";
            string expertise = "";
            var prof = new List<string>();

            if (OneStatFeats.Contains(feat))
            {
                stat = Options.FeatDefinitions[feat].Substring(9, 3);
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
                        choices.Clear();
                        choices.AddRange(AllSpells.FirstLvlDivination);
                        choices.AddRange(AllSpells.FirstLvlEnchantment);
                        choices.Sort();
                        Console.WriteLine("Pick a 1st lvl divination or enchantment spell");
                        spell = CLIHelper.PrintChoices(choices);
                        character.Spells[1].Add(spell + "(Fey Touched)");
                        break;
                    case "Magic Initiate":
                        Tuple<Dictionary<int, List<string>>, string> spellClass = PickClassForSpells(character);
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
                        choices.Clear();
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
            //all other feats
            switch (feat)
            {
                case "Alert":
                    character.Init += 5;
                    break;
                case "Athlete":
                    character.Speedstring += $", Climb {character.Speed}ft";
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
                    for (int i = 0; i < 3; i++)
                    {
                        lang = CLIHelper.GetNew(Options.Languages, character.Languages, pickMsg);
                        character.Languages.Add(lang);
                    }
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
                    character.ClassFeatures.Add("Metamagic", "Gain 2 Metamgagic options, can only use 1 option at a time");
                    Console.WriteLine("You get 2 metamagic options of your choice");
                    for (int i = 0; i < 2; i++)
                    {
                        string metamagic = CLIHelper.PrintChoices(Options.Metamagic, metamagicList, "Pick an option");
                        character.Metamagic.Add(metamagic);
                        character.ClassFeatures["Metamagic"] += $"\n{metamagic}: {Options.Metamagic[metamagic]}";
                        metamagicList.Remove(metamagic);
                    }
                    break;
                case "Mobile":
                    character.Speed += 10;
                    break;
                case "Moderately Armored":
                    character.Proficiencies.Add("Heavy Armor");
                    break;
                case "Prodigy":
                    string skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, "Pick a skill to gain proficiency");
                    character.SkillProficiencies.Add(skill);
                    prof.AddRange(character.SkillProficiencies);
                    expertise = CLIHelper.PrintChoices(prof);
                    BEHelper.AddSkillExpertise(expertise, character);
                    BEHelper.GetTool(character);
                    lang = CLIHelper.GetNew(Options.Languages, character.Languages, "Pick a language");
                    character.Languages.Add(lang);
                    break;
                case "Resilient":
                    string resStat = Stats.IncreaseStat(character, 1, true);
                    character.Saves.Add(resStat);
                    break;
                case "Skill Expert":
                    Stats.IncreaseStat(character, 1);
                    Console.WriteLine("Pick a skill to gain Expertise in");
                    prof.AddRange(character.SkillProficiencies);
                    expertise = CLIHelper.PrintChoices(prof);
                    BEHelper.AddSkillExpertise(expertise, character);
                    int index = CLIHelper.PrintChoices("Pick a skill to gain proficiency", Options.Skills);
                    character.SkillProficiencies.Add(Options.Skills[index]);
                    break;
                case "Skilled":
                    GetSkillsOrTools(character);
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
                case "Tough":
                    character.HP += character.Lvl * 2;
                    break;
                case "Unarmored Defense":
                    character.Feats.Remove("Unarmored Defense");
                    Console.WriteLine("Pick a Stat that determines your AC benefits");
                    CLIHelper.Print2Choices("Con", "Wis");
                    int input = CLIHelper.GetNumberInRange(1, 2);

                    if (input == 1)
                    {
                        character.Feats.Add("Unarmored Defense(Con)", "while wearing no armor, AC = 10 + Dex + Con");
                    }
                    else
                    {
                        character.Feats.Add("Unarmored Defense(Wis)", "while wearing no armor, AC = 10 + Dex + Wis");
                    }
                    break;
            }
        }
        public static Tuple<Dictionary<int, List<string>>, string> PickClassForSpells(Character character)
        {
            var result = new Dictionary<int, List<string>>();
            var tempChar = new Character();
            tempChar.Lvl = character.Lvl;
            var classes = new List<string> { "Bard", "Cleric", "Druid", "Sorcerer", "Warlock", "Wizard" };
            int index = CLIHelper.PrintChoices("Pick a class that will determine the spells you can gain", classes);
            string spellcastingClass = classes[index];
            tempChar.ChosenClass = spellcastingClass;
            AllSpells spells = new AllSpells(tempChar);
            string stat = "";

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
                    string skill = CLIHelper.GetNew(Options.Skills, character.SkillProficiencies, "Pick a skill");
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
                    string tool = CLIHelper.GetNew(allTools, character.ToolProficiencies, "Pick a tool");
                    character.ToolProficiencies.Add(tool);
                }
            }
        }
        public static void WeaponMaster(Character character)
        {
            var allWep = new List<string>();
            allWep.AddRange(Options.SimpleMeleeWeapons);
            allWep.AddRange(Options.MartialMeleeWeapons);
            allWep.AddRange(Options.SimpleRangedWeapons);
            allWep.AddRange(Options.MartialRangedWeapons);
            var unknownWep = new List<string>();
            foreach (var wep in allWep)
            {
                int index = wep.IndexOf("(");
                string wepProf = wep.Substring(0, index) + "s";
                if (!character.Proficiencies.Contains(wepProf))
                {
                    unknownWep.Add(wepProf);
                }
            }
            if (character.Proficiencies.Contains("Simple Weapons"))
            {
                var simpleWep = new List<string>();
                simpleWep.AddRange(Options.SimpleMeleeWeapons);
                simpleWep.AddRange(Options.SimpleRangedWeapons);
                foreach (var wep in simpleWep)
                {
                    int index = wep.IndexOf("(");
                    string wepProf = wep.Substring(0, index) + "s";
                    unknownWep.Remove(wepProf);
                }
            }
            if (character.Proficiencies.Contains("Martial Weapons"))
            {
                var martialWep = new List<string>();
                martialWep.AddRange(Options.MartialMeleeWeapons);
                martialWep.AddRange(Options.MartialRangedWeapons);
                foreach (var wep in martialWep)
                {
                    int index = wep.IndexOf("(");
                    string wepProf = wep.Substring(0, index) + "s";
                    unknownWep.Remove(wepProf);
                }
            }
            unknownWep.Sort();
            Console.WriteLine("Pick 4 weapons to gain proficiency with");
            for (int i = 0; i < 4; i++)
            {
                string newWep = CLIHelper.PrintChoices(unknownWep);
                character.Proficiencies.Add(newWep);
                unknownWep.Remove(newWep);
            }
        }
    }
}
