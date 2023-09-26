using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Ranger
    {
        public static string RangerArchetype { get; set; }
        public static Dictionary<int, List<string>> PrimalAwarenessSpells { get; set; } = new Dictionary<int, List<string>>
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() }
        };
        public static Dictionary<int, List<string>> ExpandedSpells { get; set; } = new Dictionary<int, List<string>>
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() }
        };
        public static void Base(Character character)
        {
            List<string> classSkills = new List<string> { "Animal Handling", "Athletics", "Insight", "Investigation", "Nature",
                "Perception", "Stealth", "Survival" };

            character.GP += 125;
            character.HitDie = 10;
            character.Proficiencies.Add("Light armor");
            character.Proficiencies.Add("Medium armor");
            character.Proficiencies.Add("Shields");
            character.Proficiencies.Add("Simple weapons");
            character.Proficiencies.Add("Martial weapons");
            character.Saves.Add("Str");
            character.Saves.Add("Dex");

            BEHelper.GetSkills(character, classSkills, 3);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Scale mail", "Leather armor");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Two shortswords", "Two simple melee weapons");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            CLIHelper.Print2Choices("Dungeoneer's Pack", "Explorer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                character.Equipment.Add(Options.MediumArmor[2]);
            }
            else if (input2 == 2)
            {
                character.Equipment.Add(Options.LightArmor[1]);
            }
            if (input2 == 1)
            {
                character.Equipment.Add($"2 {Options.MartialMeleeWeapons[13]}");
            }
            else
            {
                BEHelper.AddSimpleMeleeWeapon(character);
            }
            if (input3 == 1)
            {
                character.Equipment.Add(Options.Packs[2]);
            }
            else
            {
                character.Equipment.Add(Options.Packs[4]);
            }

            character.Equipment.Add(Options.MartialRangedWeapons[3]);
            character.Equipment.Add("Quiver(20 arrows)");
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;
            string msg = "";
            //begin lvl 1
            int favoredNum = 1;
            if (lvl >= 6)
            {
                favoredNum++;
            }
            if (lvl >= 10)
            {
                favoredNum++;
            }
            Console.WriteLine("Pick a Ranger class feature");
            CLIHelper.Print2Choices("Natural Explorer", "Deft Explorer");
            int num = CLIHelper.GetNumberInRange(1, 2);
            if (num == 1)
            {
                List<string> terrainTypes = new List<string> { "Arctic", "Coast", "Desert", "Forest", "Grassland", "Mountain", "Swamp","Underdark" };
                List<string> favoredTerrains = new List<string>();
                for (int i = 0; i < favoredNum; i++)
                {
                    msg = "Pick a Favored Terrain";
                    int index = CLIHelper.PrintChoices(msg, terrainTypes);
                    string land = terrainTypes[index];
                    favoredTerrains.Add(land);
                    terrainTypes.Remove(land);
                }
                string terrains = String.Join(", ", favoredTerrains);
                character.ClassFeatures.Add($"Natural Explorer({terrains})", "no difficult terrain, move stealthily at normal pace, forage x 2, " +
                    "learn exact number/size of creatures");
            }
            else
            {
                character.ClassFeatures.Add("Canny", "gain Expertise in 1 skill, gain 2 languages");
                Console.WriteLine("Pick a skill to gain Expertise in");
                var prof = new List<string>();
                prof.AddRange(character.SkillProficiencies);
                string expertise = CLIHelper.PrintChoices(prof);
                BEHelper.AddSkillExpertise(expertise, character);
                string lang = CLIHelper.GetNew(Options.Languages, character.Languages, "Pick a language");
                character.Languages.Add(lang);
                lang = CLIHelper.GetNew(Options.Languages, character.Languages, "Pick a language");
                character.Languages.Add(lang);
                if (lvl >= 6)
                {
                    character.ClassFeatures.Add("Roving", "speed +5ft, gain a Climb or Swim speed");
                    character.Speed += 5;
                    Console.WriteLine("Gain a Climb or Swim speed");
                    CLIHelper.Print2Choices("Climb speed", "Swim speed");
                    num = CLIHelper.GetNumberInRange(1, 2);
                    if (num == 1)
                    {
                        character.Speedstring += $", Climb {character.Speed}ft";
                    }
                    else
                    {
                        character.Speedstring += $", Swim {character.Speed}ft";
                    }
                }
                if (lvl >= 10)
                {
                    character.ClassFeatures.Add("Tireless", "on SR, decrease Exhaustion lvl by 1 / PB/LR, action, gain temp HP = 1D8 + Wis");
                }
            }
            Console.WriteLine("Pick a Ranger class feature");
            CLIHelper.Print2Choices("Favored Enemy", "Favored Foe");
            num = CLIHelper.GetNumberInRange(1, 2);
            if (num == 1)
            {
                List<string> enemyTypes = new List<string> { "Aberrations", "Beasts", "Celestials", "Constructs", "Dragons", "Elementals", "Fey",
                "Fiends", "Giants","Humanoids", "Monstrosities", "Oozes", "Plants", "Undead" };
                List<string> favoredEnemies = new List<string>();
                for (int i = 0; i < favoredNum; i++)
                {
                    msg = "Pick an enemy type for your Favored Enemy";
                    int index = CLIHelper.PrintChoices(msg, enemyTypes);
                    string enemy = enemyTypes[index];
                    favoredEnemies.Add(enemy);
                    enemyTypes.Remove(enemy);
                }
                string enemies = String.Join(", ", favoredEnemies);
                character.ClassFeatures.Add($"Favored Enemy({enemies})", "adv on Survival checks, gain 1 lang");
            }
            else
            {
                int dmg = 4;
                for (int i = 6; i <= lvl; i += 8)
                {
                    dmg += 2;
                }
                character.ClassFeatures.Add("Favored Foe", $"PB/LR, on hit, mark 1 min conc, dmg + 1D{dmg}");
            }
            //end lvl 1

            if (lvl >= 2)
            {
                try
                {
                    character.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use a component pouch to cast spells");
                }
                catch (Exception)
                {
                    Console.WriteLine("*Note* You have 2 classes with spellcasting");
                    throw;
                }
                string fightStyleMsg = "Pick a fighting style.";
                List<string> styleList = new List<string> { "Archery", "Blind Fighting", "Defense", "Druidic Warrior", "Dueling",
                    "Thrown Weapon Fighting", "Two-Weapon Fighting" };
                string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                string fightStyleKey = $"Fighting Style({fightStyle})";
                string fightStyleValue = Options.FightingStyles[fightStyle];
                character.ClassFeatures.Add(fightStyleKey, fightStyleValue);
                if (fightStyle == "Druidic Warrior")
                {
                    Console.WriteLine("Pick two cantrips from the Druid's list");
                    string cantrip = CLIHelper.PrintChoices(DruidSpells.Cantrips);
                    character.Cantrips.Add(cantrip);
                    cantrip = CLIHelper.PrintChoices(DruidSpells.Cantrips);
                    character.Cantrips.Add(cantrip);
                }
            }
            if (lvl >= 3)
            {
                Console.WriteLine("Pick a Ranger class feature");
                CLIHelper.Print2Choices("Primeval Awareness", "Primal Awareness");
                num = CLIHelper.GetNumberInRange(1, 2);
                if (num == 1)
                {
                    character.ClassFeatures.Add("Primeval Awareness", "expend spell slot, 1 min per spell lvl sense presence of aberrations, celestials," +
                        "\n        dragons, elementals, fey, fiends, and undead within 1 mile or 6 mile if favored terrain");
                }
                else
                {
                    PrimalAwarenessSpells[1].Add("Speak with Animals");
                    PrimalAwarenessSpells[2].Add("Beast Sense");
                    PrimalAwarenessSpells[3].Add("Speak with Plants");
                    PrimalAwarenessSpells[4].Add("Locate Creature");
                    PrimalAwarenessSpells[5].Add("Commune with Nature");
                    BEHelper.AddSecSpells(character, PrimalAwarenessSpells);
                }
                msg = "Pick a Ranger Archetype that will give you features at levels 3, 7, 11, and 15.";
                var archetype = new List<string> { "Beast Master", "Fey Wanderer", "Gloom Stalker", "Horizon Walker", "Hunter",
                    "Monster Slayer", "Swarmkeeper" };
                int input = CLIHelper.PrintChoices(msg, archetype);
                RangerArchetype = archetype[input];
                var ExpandedSpells = new Dictionary<int, string>();

                switch (RangerArchetype)
                {
                    case "Beast Master":
                        BeastMaster(character);
                        break;
                    case "Fey Wanderer":
                        FeyWanderer(character);
                        break;
                    case "Gloom Stalker":
                        GloomStalker(character);
                        break;
                    case "Horizon Walker":
                        HorizonWalker(character);
                        break;
                    case "Hunter":
                        Hunter(character);
                        break;
                    case "Monster Slayer":
                        MonsterSlayer(character);
                        break;
                    case "Swarmkeeper":
                        Swarmkeeper(character);
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
            if (lvl >= 8)
            {
                character.ClassFeatures.Add("Land's Stride", "move through difficult terrain and plants that cause dmg, adv vs spells that impede movement");
            }
            if (lvl >= 10)
            {
                Console.WriteLine("Pick a Ranger class feature");
                CLIHelper.Print2Choices("Hide in Plain Sight", "Nature's Veil");
                num = CLIHelper.GetNumberInRange(1, 2);
                if (num == 1)
                {
                    character.ClassFeatures.Add("Hide in Plain Sight", "spend 1 min to camouflage self, gain +10 to Stealth without moving");
                }
                else
                {
                    character.ClassFeatures.Add("Nature's Veil", "PB/LR, bonus, become invisible");
                }
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Vanish", "Hide as bonus, can't be tracked nonmagically");
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Feral Senses", "creatures you can't see don't impose disadv, know location of invisible creatures within 30ft");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Foe Slayer", "1/turn, + Wis to atk or dmg against favored enemy");
            }
            Spells(character);
        }
        public static void BeastMaster(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Ranger's Companion", "medium beast, CR 1/4 or lower, + PB to AC, atks, dmg, saves, skills, HP = normal or lvl x 4" +
                "\bonus to command it to atk, Dash, Disengage, Dodge, or Help - if you have extra atk, you can atk and command beast");

            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Exceptional Training", "bonus, if beast doesn't atk - command beast to Dash, Disengage, Dodge, or Help");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Bestial Fury", "when beast atks, it can make 2 atks or use Multiattack action if it has it");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Share Spells", "when you cast a spell on yourself, if beast is within 30ft - it gains benefits too");
            }
        }
        public static void FeyWanderer(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Charm Person");
            ExpandedSpells[2].Add("Misty Step");
            ExpandedSpells[3].Add("Dispel Magic");
            ExpandedSpells[4].Add("Dimension Door");
            ExpandedSpells[5].Add("Mislead");
            var gifts = new List<string> { "Illusory butterflies flutter around you when you take SR or LR",
                            "Fresh, seasonal flowers sprout from your hair each dawn", "Your shadow dances when no one is looking directly at it",
                            "You faintly smell of cinnamon, lavender, nutmeg, or another comforting herb or spice",
                            "Horns or antlers sprout from your head", "Your skin and hair change color to match the season each dawn" };
            Console.WriteLine("Pick a Feywild gift that affects your appearance");
            string gift = CLIHelper.PrintChoices(gifts);
            character.ClassFeatures.Add("Feywild Gift", gift);
            int dmg = 4;
            if (lvl >= 11)
            {
                dmg += 2;
            }
            character.ClassFeatures.Add("Dreadful Strikes", $"1/turn, on hit, 1D{dmg} Psychic dmg");
            character.ClassFeatures.Add("Otherworldly Glamour", "Cha checks + Wis");
            var skills = new List<string> { "Deception", "Performance", "Persuasion" };
            string skill = CLIHelper.GetNew(skills, character.SkillProficiencies, "Pick a skill");
            character.SkillProficiencies.Add(skill);
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Beguiling Twist", "gain adv on saves vs charm and fear / reaction, 120ft, successful save vs charm or fear, Wis save, charm or fear 1 min");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Fey Reinforcements", "LR, cast Summon Fey without using a spell slot - can modify duration from conc to 1 min");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Misty Wanderer", "LR, cast Misty Step without using a spell slot - can also teleport adj ally");
            }
        }
        public static void GloomStalker(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Disguise Self");
            ExpandedSpells[2].Add("Rope Trick");
            ExpandedSpells[3].Add("Fear");
            ExpandedSpells[4].Add("Greater Invisibility");
            ExpandedSpells[5].Add("Seeming");
            if (!character.Vision.Contains("Darkvision"))
            {
                character.Vision = "Darkvision 60ft";
            }
            else
            {
                string vision = character.Vision;
                if (vision.Contains("Superior"))
                {
                    character.Vision = "Superior Darkvision 150ft";
                }
                else
                {
                    character.Vision = "Darkvision 90ft";
                }
            }
            character.ClassFeatures.Add("Umbral Sight", "While in darkness, you are invisible to creatures who rely on Darkvision");
            character.ClassFeatures.Add("Dread Ambusher", "Init + Wis, 1st turn, speed +10ft, gain extra atk, dmg + 1D8 on that atk");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Iron Mind", "gain prof in Wis saves(if already have gain Int or Cha instead)");
                character.Saves.Add("Wis");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Stalker's Flurry", "1/turn, when you miss an atk, make an extra atk");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Shadowy Dodge", "reaction, when an enemy atk doesn't have adv, impose disadv");
            }
        }
        public static void HorizonWalker(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Protection from Evil and Good");
            ExpandedSpells[2].Add("Misty Step");
            ExpandedSpells[3].Add("Haste");
            ExpandedSpells[4].Add("Banishment");
            ExpandedSpells[5].Add("Teleportation Circle");
            character.ClassFeatures.Add("Detect Portal", "SR, action, 1 mile, detect distance and direction of nearest planar portal");
            int planarDice = 1;
            if (lvl >= 11)
            {
                planarDice++;
            }
            character.ClassFeatures.Add("Planar Warrior", $"bonus, 30ft, next atk's dmg becomes force, +{planarDice}D8 force dmg");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Ethereal Step", "SR, bonus, cast Etherealness");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Distant Strike", "When you use Attack action, teleport 10ft, if you atk 2 creatures - gain extra atk vs a 3rd creature");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Spectral Defense", "reaction, when hit, gain Resistance to dmg");
            }
        }
        public static void Hunter(Character character)
        {
            int lvl = character.Lvl;
            string msg = "Pick one of the following features";
            if (lvl >= 3)
            {
                Console.WriteLine(msg);
                CLIHelper.Print3Choices("Colossus Slayer", "Giant Killer", "Horde Breaker");
                int choice = CLIHelper.GetNumberInRange(1, 3);
                if (choice == 1)
                {
                    character.ClassFeatures.Add("Colossus Slayer", "1/turn, if enemy is not max HP, +1D8 dmg");
                }
                else if (choice == 2)
                {
                    character.ClassFeatures.Add("Giant Killer", "reaction, if Large or larger creature atks, free atk if within 5ft");
                }
                else if (choice == 3)
                {
                    character.ClassFeatures.Add("Horde Breaker", "1/turn, make extra wep atk against 2nd creature");
                }
            }
            if (lvl >= 7)
            {
                Console.WriteLine(msg);
                CLIHelper.Print3Choices("Escape the Horde", "Multiattack Defense", "Steel Will");
                int choice = CLIHelper.GetNumberInRange(1, 3);
                if (choice == 1)
                {
                    character.ClassFeatures.Add("Escape the Horde", "enemy op atks are made at disadv");
                }
                else if (choice == 2)
                {
                    character.ClassFeatures.Add("Multiattack Defense", "after being hit, gain +4 AC");
                }
                else if (choice == 3)
                {
                    character.ClassFeatures.Add("Steel Will", "adv on saves vs fear");
                }
            }
            if (lvl >= 11)
            {
                Console.WriteLine(msg);
                CLIHelper.Print2Choices("Volley", "Whirlwind Attack");
                int choice = CLIHelper.GetNumberInRange(1, 2);
                if (choice == 1)
                {
                    character.ClassFeatures.Add("Volley", "action, atk all creatures you can see within 10ft");
                }
                else if (choice == 2)
                {
                    character.ClassFeatures.Add("Whirlwind Attack", "action, melee atk all creatures within 5ft");
                }
            }
            if (lvl >= 15)
            {
                Console.WriteLine(msg);
                CLIHelper.Print3Choices("Evasion", "Stand Against the Tide", "Uncanny Dodge");
                int choice = CLIHelper.GetNumberInRange(1, 3);
                if (choice == 1)
                {
                    character.ClassFeatures.Add("Evasion", "Dex saves = 1/2 or no dmg");
                }
                else if (choice == 2)
                {
                    character.ClassFeatures.Add("Stand Against the Tide", "reaction, when enemy misses melee atk, force enemy to atk another creature");
                }
                else if (choice == 3)
                {
                    character.ClassFeatures.Add("Uncanny Dodge", "reaction, 1/2 dmg");
                }
            }
        }
        public static void MonsterSlayer(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Protection from Evil and Good");
            ExpandedSpells[2].Add("Zone of Truth");
            ExpandedSpells[3].Add("Magic Circle");
            ExpandedSpells[4].Add("Banishment");
            ExpandedSpells[5].Add("Hold Monster");
            character.ClassFeatures.Add("Hunter's Sense", "Wis/LR, action, 60ft, learn Immunities, Resistances, Vulnerabilities of an enemy");
            character.ClassFeatures.Add("Slayer's Prey", "SR, bonus, 60ft, 1/turn, dmg + 1D6");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Supernatural Defense", "when your Slayer's Prey target makes you roll a save/opposed grapple gain +1D6");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Magic-User's Nemesis", "reaction, 60ft, Wis save, when a spell is cast or a creature teleports, their spell or teleport fails");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Slayer's Counter", "reaction, before your Slayer's Prey makes you roll a save, make an atk - if it hits, auto-success on your save");
            }
        }
        public static void Swarmkeeper(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Faerie Fire");
            ExpandedSpells[1].Add("Mage Hand");
            ExpandedSpells[2].Add("Web"); ;
            ExpandedSpells[3].Add("Gaseous Form");
            ExpandedSpells[4].Add("Arcane Eye");
            ExpandedSpells[5].Add("Insect Plague");
            var swarmList = new List<string> { "Swarming Insects", "Miniature Twig Blights", "Fluttering Birds", "Playful Pixies" };
            Console.WriteLine("Pick an appearance for your swarm");
            string swarm = CLIHelper.PrintChoices(swarmList);
            int swarmDmg = 6;
            if (lvl >= 11)
            {
                swarmDmg += 2;
            }
            character.ClassFeatures.Add("Gathered Swarm", $"1/turn, on hit, pick an effect - (dmg + 1D{swarmDmg} Piercing), (Str save, slide enemy 15ft), or (move 5ft, costs no movement)" +
                $"\n        Swarm Appearance - {swarm}");
            if (lvl >= 7)
            {
                character.ClassFeatures.Add("Writhing Tide", "PB/LR, bonus, 1 min, gain Hover and Fly 10ft");
            }
            if (lvl >= 11)
            {
                character.ClassFeatures.Add("Mighty Swarm", "if a creature fails Str save vs Gathered Swarm - knock prone" +
                    "\n        when you move with Gathered Swarm - gain half cover(+2 AC, Dex saves) 1 turn");
            }
            if (lvl >= 15)
            {
                character.ClassFeatures.Add("Swarming Dispersal", "PB/LR, reaction, when you take dmg, gain Resistance to dmg and teleport 30ft");
            }
        }
        public static void Spells(Character character)
        {
            var archList = new List<string> { "Fey Wanderer", "Gloom Stalker", "Horizon Walker", "Monster Slayer", "Swarmkeeper" };
            if (archList.Contains(RangerArchetype))
            {
                BEHelper.AddSecSpells(character, ExpandedSpells);
            }
            string pickMsg = "Pick a 1st level spell.";
            AllSpells spells = new AllSpells(character);

            for (int i = 1; i <= character.SpellsKnown; i++)
            {
                int spellLvl = 1;
                if (i >= 4 && i % 2 == 0)
                {
                    spellLvl++;
                }
                pickMsg = CLIHelper.pickSpellLevel(i, 4, 6, 8, pickMsg, spellLvl);
                string spell = CLIHelper.GetNew(spells.Ranger[spellLvl], character.Spells[spellLvl], pickMsg);
                character.Spells[spellLvl].Add(spell);
                spells.Ranger[spellLvl].Remove(spell);
            }
        }
    }
}
