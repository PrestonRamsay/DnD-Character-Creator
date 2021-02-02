using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Races
{
    public class Race
    {        
        public Race()
        {
            MaxAgeEnd = 100;
            RacialStr = 0;
            RacialDex = 0;
            RacialCon = 0;
            RacialInt = 0;
            RacialWis = 0;
            RacialCha = 0;
        }
        public int RacialStr { get; set; }
        public int RacialDex { get; set; }
        public int RacialCon { get; set; }
        public int RacialInt { get; set; }
        public int RacialWis { get; set; }
        public int RacialCha { get; set; }
        public List<string> RacialTraits { get; protected set; } = new List<string>();
        public int MinHeight { get; protected set; }
        public int MaxHeight { get; protected set; }
        public string Size { get; set; }
        public int MinWeight { get; protected set; }
        public int MaxWeight { get; protected set; }
        public string Speed { get; set; }
        public string Vision { get; set; }
        public List<string> Alignment { get; set; } = new List<string>();
        public int AdultAge { get; set; }
        public int FullyGrownAge { get; set; }
        public int MaxAgeStart { get; set; }
        public int MaxAgeEnd { get; set; }
        public List<string> Languages { get; set; } = new List<string>();
        public List<string> SkillProficiencies { get; set; } = new List<string>();
        public List<string> ToolProficiencies { get; set; } = new List<string>();
        public List<string> Proficiencies { get; set; } = new List<string>();
        public List<string> Cantrips { get; set; } = new List<string>();
        public List<string> Feats { get; set; } = new List<string>();
        public string DragonColor { get; set; }
        public static Race Dragonborn()
        {           
            Race result = new Race();
            string msg = "Pick a dragon color for your ancestry";
            List<string> colorList = new List<string> { "Black", "Blue", "Brass", "Bronze", "Copper", "Gold", "Green",
                "Red", "Silver", "White" };
            int index = CLIHelper.PrintChoices(msg, colorList);
            string color = colorList[index];
            result.DragonColor = color;

            if (color == "Black")
            {
                result.RacialTraits.Add("Damage Resistance: gain Resistance to Acid");
                result.RacialTraits.Add("Breath Weapon: deals 2D6 + (1D6 per 5 levels above 1st) damage, " +
                    "\nrecharge SR or LR, Con-based DC. 5 by 30ft line of Acid - Dex save");
            }
            else if (color == "Blue")
            {
                result.RacialTraits.Add("Damage Resistance: gain Resistance to Lightning");
                result.RacialTraits.Add("Breath Weapon: deals 2D6 + (1D6 per 5 levels above 1st) damage, " +
                    "\nrecharge SR or LR, Con-based DC. 5 by 30ft line of Lightning - Dex save");
            }
            else if (color == "Brass")
            {
                result.RacialTraits.Add("Damage Resistance: gain Resistance to Fire");
                result.RacialTraits.Add("Breath Weapon: deals 2D6 + (1D6 per 5 levels above 1st) damage, " +
                    "\nrecharge SR or LR, Con-based DC. 5 by 30ft line of Fire - Dex save");
            }
            else if (color == "Bronze")
            {
                result.RacialTraits.Add("Damage Resistance: gain Resistance to Lightning");
                result.RacialTraits.Add("Breath Weapon: deals 2D6 + (1D6 per 5 levels above 1st) damage, " +
                    "\nrecharge SR or LR, Con-based DC. 5 by 30ft line of Lightning - Dex save");
            }
            else if (color == "Copper")
            {
                result.RacialTraits.Add("Damage Resistance: gain Resistance to Acid");
                result.RacialTraits.Add("Breath Weapon: deals 2D6 + (1D6 per 5 levels above 1st) damage, " +
                    "\nrecharge SR or LR, Con-based DC. 5 by 30ft line of Acid - Dex save");
            }
            else if (color == "Gold")
            {
                result.RacialTraits.Add("Damage Resistance: gain Resistance to Fire");
                result.RacialTraits.Add("Breath Weapon: deals 2D6 + (1D6 per 5 levels above 1st) damage, " +
                    "\nrecharge SR or LR, Con-based DC. 15ft cone of Fire - Dex save");
            }
            else if (color == "Green")
            {
                result.RacialTraits.Add("Damage Resistance: gain Resistance to Poison");
                result.RacialTraits.Add("Breath Weapon: deals 2D6 + (1D6 per 5 levels above 1st) damage, " +
                    "\nrecharge SR or LR, Con-based DC. 15ft cone of Poison - Con save");
            }
            else if (color == "Red")
            {
                result.RacialTraits.Add("Damage Resistance: gain Resistance to Fire");
                result.RacialTraits.Add("Breath Weapon: deals 2D6 + (1D6 per 5 levels above 1st) damage, " +
                    "\nrecharge SR or LR, Con-based DC. 15ft cone of Fire - Dex save");
            }
            else if (color == "Silver")
            {
                result.RacialTraits.Add("Damage Resistance: gain Resistance to Cold");
                result.RacialTraits.Add("Breath Weapon: deals 2D6 + (1D6 per 5 levels above 1st) damage, " +
                    "\nrecharge SR or LR, Con-based DC. 15ft cone of Cold - Con save");
            }
            else
            {
                result.RacialTraits.Add("Damage Resistance: gain Resistance to Cold");
                result.RacialTraits.Add("Breath Weapon: deals 2D6 + (1D6 per 5 levels above 1st) damage, " +
                    "\nrecharge SR or LR, Con-based DC. 15ft cone of Cold - Con save");
            }

            result.RacialStr = 2;
            result.RacialCha = 1;
            result.MinHeight = 75;
            result.MaxHeight = 81;
            result.MinWeight = 200;
            result.MaxWeight = 350;
            result.Speed = "30ft";
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("N-G");
            result.Alignment.Add("TN");
            result.Alignment.Add("N-E");
            result.FullyGrownAge = 3;
            result.AdultAge = 15;
            result.MaxAgeStart = 80;
            result.Languages.Add("Draconic");

            return result;
        }
        public static Race HillDwarf()
        {
            Race result = new Race();
            string msg = "Pick a Tool Proficiency from: Brewer's Supplies, Mason's Tools, or Smith's Tools";
            List<string> toolsList = new List<string> { "Brewer", "Mason", "Smith" };
            int index = CLIHelper.PrintChoices(msg, toolsList);
            string toolProficiency = toolsList[index];
            if (toolProficiency == "Brewer")
            {
                result.ToolProficiencies.Add("Brewer's Supplies");
            }
            else if (toolProficiency == "Mason")
            {
                result.ToolProficiencies.Add("Mason's Tools");
            }
            else
            {
                result.ToolProficiencies.Add("Smith's Tools");
            }

            result.RacialCon = 2;
            result.RacialWis = 1;
            result.RacialTraits.Add("Dwarven Resilience: gain Resistance to Poison, and advantage on saves vs Poison");
            result.RacialTraits.Add("Stonecunning: History checks on stonework are treated as if you are proficient and " +
                "\ngain add your Proficiency bonus x2");
            result.RacialTraits.Add("Dwarven Toughness");
            result.MinHeight = 48;
            result.MaxHeight = 60;
            result.MinWeight = 100;
            result.MaxWeight = 200;
            result.Speed = "25ft, no speed penalty when wearing heavy armor";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("L-N");
            result.AdultAge = 50;
            result.MaxAgeStart = 350;
            result.Languages.Add("Dwarven");
            result.Proficiencies.Add("Battleaxes");
            result.Proficiencies.Add("Handaxes");
            result.Proficiencies.Add("Throwing Hammers");
            result.Proficiencies.Add("Warhammers");

            return result;
        }
        public static Race MountainDwarf()
        {
            Race result = new Race();
            string msg = "Pick a Tool Proficiency from: Brewer's Supplies, Mason's Tools, or Smith's Tools";
            List<string> toolsList = new List<string> { "Brewer", "Mason", "Smith" };
            int index = CLIHelper.PrintChoices(msg, toolsList);
            string toolProficiency = toolsList[index];
            if (toolProficiency == "Brewer")
            {
                result.ToolProficiencies.Add("Brewer's Supplies");
            }
            else if (toolProficiency == "Mason")
            {
                result.ToolProficiencies.Add("Mason's Tools");
            }
            else
            {
                result.ToolProficiencies.Add("Smith's Tools");
            }

            result.RacialStr = 2;
            result.RacialCon = 2;
            result.RacialTraits.Add("Dwarven Resilience: gain Resistance to Poison, and Advantage on saves vs Poison");
            result.RacialTraits.Add("Stonecunning: History checks on stonework are treated as if you are proficient and " +
                "\ngain add your Proficiency bonus x2");
            result.MinHeight = 48;
            result.MaxHeight = 60;
            result.MinWeight = 100;
            result.MaxWeight = 200;
            result.Speed = "25ft, no speed penalty when wearing heavy armor";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("L-N");
            result.AdultAge = 50;
            result.MaxAgeStart = 350;
            result.Languages.Add("Dwarven");
            result.Proficiencies.Add("Light Armor");
            result.Proficiencies.Add("Medium Armor");
            result.Proficiencies.Add("Battleaxes");
            result.Proficiencies.Add("Handaxes");
            result.Proficiencies.Add("Throwing Hammers");
            result.Proficiencies.Add("Warhammers");

            return result;
        }
        public static Race Drow()
        {
            Race result = new Race();

            result.RacialDex = 2;
            result.RacialCha = 1;
            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
            result.RacialTraits.Add("Sunlight Sensitivity: take a Disadvantage on attacks and Perception checks that rely " +
                "\non sight while you or the target of your check/attack is in direct sunlight");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = "30ft";
            result.Vision = "Superior Darkvision 120ft";
            result.Alignment.Add("C-N");
            result.Alignment.Add("N-E");
            result.Alignment.Add("C-E");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.Languages.Add("Undercommon");
            result.SkillProficiencies.Add("Perception");
            result.Proficiencies.Add("Shortswords");
            result.Proficiencies.Add("Rapiers");
            result.Proficiencies.Add("Hand Crossbows");
            result.Cantrips.Add("Dancing Lights - use Cha to cast");

            return result;
        }
        public static Race HighElf()
        {
            Race result = new Race();

            result.RacialDex = 2;
            result.RacialInt = 1;
            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = "30ft";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("N-G");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.Languages.Add("Choice");
            result.SkillProficiencies.Add("Perception");
            result.Proficiencies.Add("Shortswords");
            result.Proficiencies.Add("Shortbows");
            result.Proficiencies.Add("Longswords");
            result.Proficiencies.Add("Longbows");
            int index = CLIHelper.PrintChoices("Pick a cantrip from the Wizard's spell list.", WizardSpells.Cantrips);
            string cantrip = WizardSpells.Cantrips[index];
            result.Cantrips.Add($"{cantrip} - use Int to cast");

            return result;
        }
        public static Race WoodElf()
        {
            Race result = new Race();

            result.RacialDex = 2;
            result.RacialWis = 1;
            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.RacialTraits.Add("Trance: you don't need sleep, instead you meditate in a semiconscious state for 4hr. " +
                "\nAfter resting in such a way, you gain the benefits of a long rest");
            result.RacialTraits.Add("Mask of the Wild: you can attempt to hide even when you are only lightly obscured " +
                "\nby foliage, heavy rain, falling snow, mist, and other natural phenomena.");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 120;
            result.MaxWeight = 180;
            result.Speed = "35ft";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-G");
            result.Alignment.Add("C-N");
            result.AdultAge = 100;
            result.MaxAgeStart = 750;
            result.Languages.Add("Elven");
            result.SkillProficiencies.Add("Perception");
            result.Proficiencies.Add("Shortswords");
            result.Proficiencies.Add("Shortbows");
            result.Proficiencies.Add("Longswords");
            result.Proficiencies.Add("Longbows");

            return result;
        }
        public static Race ForestGnome()
        {
            Race result = new Race();

            result.RacialInt = 2;
            result.RacialDex = 1;
            result.RacialTraits.Add("Gnome Cunning: you gain Advantage on Int, Wis, and Cha saves vs magic");
            result.RacialTraits.Add("Speak with Small Beasts: Through sounds and gestures, you can communicate with " +
                "\nsimple ideas to small or smaller beasts");            
            result.MinHeight = 36;
            result.MaxHeight = 48;
            result.Size = "Small";
            result.MinWeight = 30;
            result.MaxWeight = 50;
            result.Speed = "25ft";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("N-G");
            result.Alignment.Add("C-G");
            result.AdultAge = 40;
            result.MaxAgeStart = 350;
            result.MaxAgeEnd = 500;
            result.Languages.Add("Gnomish");
            result.Cantrips.Add("Minor Illusion - use Int to cast");

            return result;
        }

        public static Race RockGnome()
        {
            Race result = new Race();

            result.RacialInt = 2;
            result.RacialCon = 1;
            result.RacialTraits.Add("Gnome Cunning: you gain Advantage on Int, Wis, and Cha saves vs magic");
            result.RacialTraits.Add("Artificer's Lore: History checks on items or devices that are based on magic, " +
                "\ntechnology, or alchemy are treated as if you are proficient and add your Proficiency bonus x2");
            result.RacialTraits.Add("Tinker: you can spend 1hr and 10gp to create a tiny clockwork device that has 1HP and " +
                "\nan AC of 5. The device ceases to function after 24hr unless you spend 1hr to repair it. You can also use " +
                "\nyour action to dismantle the device and reclaim it's materials. You can make: a fire starter(creates " +
                "\nminiature flame), a music box(single song at a moderate volume), or a clockwork toy(moves 5ft in a random " +
                "\ndirection and makes noise approriate to the creature it represents).");
            result.MinHeight = 36;
            result.MaxHeight = 48;
            result.Size = "Small";
            result.MinWeight = 30;
            result.MaxWeight = 50;
            result.Speed = "25ft";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("N-G");
            result.AdultAge = 40;
            result.MaxAgeStart = 350;
            result.MaxAgeEnd = 500;
            result.Languages.Add("Gnomish");

            return result;
        }
        public static Race HalfElf()
        {
            Race result = new Race();

            Console.WriteLine("Pick a stat to increase by 1 by typing 'Str', 'Dex', 'Con', 'Int', or 'Wis'.");
            var statOptions = new List<string>();
            statOptions.AddRange(Options.Stats);
            statOptions.Remove("Cha");
            string firstStat = CLIHelper.GetStringInList(statOptions);
            if (firstStat == "Str")
            {
                result.RacialStr = 1;
            }
            else if (firstStat == "Dex")
            {
                result.RacialDex = 1;
            }
            else if (firstStat == "Con")
            {
                result.RacialCon = 1;
            }
            else if (firstStat == "Int")
            {
                result.RacialInt = 1;
            }
            else if (firstStat == "Wis")
            {
                result.RacialWis = 1;
            }
            statOptions.Remove(firstStat);

            Console.WriteLine("Pick another stat to increase by 1 by typing 'Str', 'Dex', 'Con', 'Int', or 'Wis'." +
                "\n(Note you can't pick the same stat that you picked last time.)");
            string secondStat = CLIHelper.GetStringInList(statOptions);
            if (secondStat == "Str")
            {
                result.RacialStr = 1;
            }
            else if (secondStat == "Dex")
            {
                result.RacialDex = 1;
            }
            else if (secondStat == "Con")
            {
                result.RacialCon = 1;
            }
            else if (secondStat == "Int")
            {
                result.RacialInt = 1;
            }
            else if (secondStat == "Wis")
            {
                result.RacialWis = 1;
            }

            result.RacialCha = 2;
            result.RacialTraits.Add("Fey Ancestry: gain Advantage on saves vs charms and magic can't put you to sleep");
            result.MinHeight = 60;
            result.MaxHeight = 72;
            result.MinWeight = 100;
            result.MaxWeight = 250;
            result.Speed = "30ft";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-N");
            result.AdultAge = 20;
            result.MaxAgeStart = 180;
            result.Languages.Add("Elven");
            result.Languages.Add("Choice");

            Console.WriteLine("Half-Elves are very versatile. You get you pick two extra skill proficiencies.");
            var skillList = new List<string>();
            skillList.AddRange(Options.Skills);
            string msg = "Pick your first skill here.";
            int index = CLIHelper.PrintChoices(msg, skillList);
            string skill = skillList[index];
            result.SkillProficiencies.Add(skill);
            skillList.Remove(skill);

            msg = "Enter your second skill here.";
            index = CLIHelper.PrintChoices(msg, skillList);
            skill = skillList[index];
            result.SkillProficiencies.Add(skill);

            return result;
        }
        public static Race HalfOrc()
        {
            Race result = new Race();

            result.RacialStr = 2;
            result.RacialCon = 1;
            result.RacialTraits.Add("Savage Attacks: when you crit on an attack roll, add 1 die to your damage roll");
            result.RacialTraits.Add("Relentless Endurance: 1/long rest, when you drop to 0HP, drop to 1HP instead");
            result.MinHeight = 72;
            result.MaxHeight = 84;
            result.MinWeight = 180;
            result.MaxWeight = 250;
            result.Speed = "30ft";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-N");
            result.Alignment.Add("C-E");
            result.AdultAge = 14;
            result.MaxAgeStart = 75;
            result.Languages.Add("Orc");
            result.SkillProficiencies.Add("Intimidate");

            return result;
        }
        public static Race LightfootHalfling()
        {
            Race result = new Race();

            result.RacialDex = 2;
            result.RacialCha = 1;
            result.RacialTraits.Add("Lucky: when you roll a 1 you can reroll it once");
            result.RacialTraits.Add("Brave: you have Advantage on saves vs fear effects");
            result.RacialTraits.Add("Halfling Nimbleness: you can move through squares occupied by creatures who are larger than you");
            result.RacialTraits.Add("Naturally Stealthy: you can attempt to hide when you are obscured by a creature larger than you");
            result.MinHeight = 34;
            result.MaxHeight = 38;
            result.Size = "Small";
            result.MinWeight = 35;
            result.MaxWeight = 45;
            result.Speed = "25ft";
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("L-G");
            result.AdultAge = 20;
            result.MaxAgeStart = 200;
            result.Languages.Add("Halfling");


            return result;
        }
        public static Race StoutHalfling()
        {
            Race result = new Race();

            result.RacialDex = 2;
            result.RacialCon = 1;
            result.RacialTraits.Add("Lucky: when you roll a 1 you can reroll it once");
            result.RacialTraits.Add("Brave: you have Advantage on saves vs fear effects");
            result.RacialTraits.Add("Halfling Nimbleness: you can move through squares occupied by creatures who are larger than you");
            result.RacialTraits.Add("Stout Resilience: gain Resistance to Poison, and Advantage on saves vs Poison");
            result.MinHeight = 34;
            result.MaxHeight = 38;
            result.Size = "Small";
            result.MinWeight = 35;
            result.MaxWeight = 45;
            result.Speed = "25ft";
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("L-G");
            result.AdultAge = 20;
            result.MaxAgeStart = 200;
            result.Languages.Add("Halfling");

            return result;
        }
        public static Race VariantHuman()
        {
            Race result = new Race();

            Console.WriteLine("Pick a stat to increase by 1 by typing 'Str', 'Dex', 'Con', 'Int', 'Wis', or 'Cha'.");
            var statOptions = Options.Stats;
            string firstStat = CLIHelper.GetStringInList(statOptions);
            if (firstStat == "Str")
            {
                result.RacialStr = 1;
                statOptions.Remove("Str");
            }
            else if (firstStat == "Dex")
            {
                result.RacialDex = 1;
                statOptions.Remove("Dex");
            }
            else if (firstStat == "Con")
            {
                result.RacialCon = 1;
                statOptions.Remove("Con");
            }
            else if (firstStat == "Int")
            {
                result.RacialInt = 1;
                statOptions.Remove("Int");
            }
            else if (firstStat == "Wis")
            {
                result.RacialWis = 1;
                statOptions.Remove("Wis");
            }
            else
            {
                result.RacialCha = 1;
                statOptions.Remove("Cha");
            }
            Console.WriteLine("Pick another stat to increase by 1 by typing 'Str', 'Dex', 'Con', 'Int', 'Wis', or 'Cha'." +
                "\n(Note you can't pick the same stat as you picked last time.)");
            string secondStat = CLIHelper.GetStringInList(statOptions);
            if (secondStat == "Str")
            {
                result.RacialStr = 1;
            }
            else if (secondStat == "Dex")
            {
                result.RacialDex = 1;
            }
            else if (secondStat == "Con")
            {
                result.RacialCon = 1;
            }
            else if (secondStat == "Int")
            {
                result.RacialInt = 1;
            }
            else if (secondStat == "Wis")
            {
                result.RacialWis = 1;
            }
            else
            {
                result.RacialCha = 1;
            }

            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 300;
            result.Speed = "30ft";
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("L-N");
            result.Alignment.Add("L-E");
            result.Alignment.Add("C-G");
            result.Alignment.Add("C-N");
            result.Alignment.Add("C-E");
            result.Alignment.Add("N-G");
            result.Alignment.Add("TN");
            result.Alignment.Add("N-E");
            result.AdultAge = 18;
            result.MaxAgeStart = 80;
            result.Languages.Add("Choice");
            string msg = "You get to pick an extra skill proficiency. Enter the skill you'd like here.";
            int index = CLIHelper.PrintChoices(msg, Options.Skills);
            string pickedSkill = Options.Skills[index];
            result.SkillProficiencies.Add(pickedSkill);
            msg = "You get to pick a feat. Enter the feat you'd like here.";
            index = CLIHelper.PrintChoices(msg, Options.Feats);
            string feat = Options.Feats[index];
            result.Feats.Add(feat);

            return result;
        }
        public static Race Human()
        {
            Race result = new Race();

            result.RacialStr = 1;
            result.RacialDex = 1;
            result.RacialCon = 1;
            result.RacialInt = 1;
            result.RacialWis = 1;
            result.RacialCha = 1;
            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 300;
            result.Speed = "30ft";
            result.Vision = "Lowlight 60ft";
            result.Alignment.Add("L-G");
            result.Alignment.Add("L-N");
            result.Alignment.Add("L-E");
            result.Alignment.Add("C-G");
            result.Alignment.Add("C-N");
            result.Alignment.Add("C-E");
            result.Alignment.Add("N-G");
            result.Alignment.Add("TN");
            result.Alignment.Add("N-E");
            result.AdultAge = 18;
            result.MaxAgeStart = 80;
            result.Languages.Add("Choice");

            return result;
        }
        public static Race Tiefling()
        {
            Race result = new Race();

            result.RacialCha = 2;
            result.RacialInt = 1;
            result.RacialTraits.Add("Hellish Resistance: gain Resistance to Fire");
            result.MinHeight = 60;
            result.MaxHeight = 78;
            result.MinWeight = 100;
            result.MaxWeight = 200;
            result.Speed = "30ft";
            result.Vision = "Darkvision 60ft";
            result.Alignment.Add("C-N");
            result.Alignment.Add("C-E");
            result.AdultAge = 18;
            result.MaxAgeStart = 80;
            result.Languages.Add("Infernal");
            result.Cantrips.Add("Vicious Mockery - use Cha to cast");

            return result;
        }
    }
}
