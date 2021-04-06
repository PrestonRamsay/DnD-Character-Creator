using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class RangerSpecifics
    {
        public static string RangerArchetype { get; set; }
        public static Dictionary<int, string> PrimalAwarenessSpells { get; set; } = new Dictionary<int, string>()
        {
            { 1, "Speak with Animals" },
            { 2, "Beast Sense" },
            { 3, "Speak with Plants" },
            { 4, "Locate Creature" },
            { 5, "Commune with Nature" }
        };
        public static CharacterClass Features(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;
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
                result.ClassFeatures.Add($"Natural Explorer({terrains})", "no difficult terrain, move stealthily at normal pace, forage x 2, " +
                    "learn exact number/size of creatures");
            }
            else
            {
                result.ClassFeatures.Add("Canny", "gain Expertise in 1 skill, gain 2 languages");
                Console.WriteLine("Pick a skill to gain Expertise in");
                var prof = new List<string>();
                prof.AddRange(character.SkillProficiencies);
                string expertise = CLIHelper.PrintChoices(prof);
                character.Skills[expertise] += character.ProficiencyBonus;
                string lang = CLIHelper.GetNew(Options.Languages, character.Languages, "Pick a language", "You already know that language");
                character.Languages.Add(lang);
                lang = CLIHelper.GetNew(Options.Languages, character.Languages, "Pick a language", "You already know that language");
                character.Languages.Add(lang);
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Roving", "speed +5ft, gain a Climb or Swim speed");
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
                    result.ClassFeatures.Add("Tireless", "on SR, decrease Exhaustion lvl by 1 / PB/LR, action, gain temp HP = 1D8 + Wis");
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
                result.ClassFeatures.Add($"Favored Enemy({enemies})", "adv on Survival checks, gain 1 lang");
            }
            else
            {
                int dmg = 4;
                for (int i = 6; i <= lvl; i += 8)
                {
                    dmg += 2;
                }
                result.ClassFeatures.Add("Favored Foe", $"PB/LR, on hit, mark 1 min conc, dmg + 1D{dmg}");
            }
            //end lvl 1

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use a component pouch to cast spells");
                string fightStyleMsg = "Pick a fighting style.";
                List<string> styleList = new List<string> { "Archery", "Blind Fighting", "Defense", "Druidic Warrior", "Dueling",
                    "Thrown Weapon Fighting", "Two-Weapon Fighting" };
                string fightStyle = CLIHelper.PrintChoices(Options.FightingStyles, styleList, fightStyleMsg);
                string fightStyleKey = $"Fighting Style({fightStyle})";
                string fightStyleValue = Options.FightingStyles[fightStyle];
                result.ClassFeatures.Add(fightStyleKey, fightStyleValue);
                if (fightStyle == "Druidic Warrior")
                {
                    Console.WriteLine("Pick two cantrips from the Druid's list");
                    string cantrip = CLIHelper.PrintChoices(DruidSpells.Cantrips);
                    result.Cantrips.Add(cantrip);
                    cantrip = CLIHelper.PrintChoices(DruidSpells.Cantrips);
                    result.Cantrips.Add(cantrip);
                }
            }
            if (lvl >= 3)
            {
                Console.WriteLine("Pick a Ranger class feature");
                CLIHelper.Print2Choices("Primeval Awareness", "Primal Awareness");
                num = CLIHelper.GetNumberInRange(1, 2);
                if (num == 1)
                {
                    result.ClassFeatures.Add("Primeval Awareness", "expend spell slot, 1 min per spell lvl sense presence of aberrations, celestials," +
                        "\ndragons, elementals, fey, fiends, and undead within 1 mile or 6 mile if favored terrain");
                }
                else
                {
                    result.Spells[1].Add("Speak with Animals");
                    CLIHelper.AddSpells(result, PrimalAwarenessSpells);
                }
                msg = "Pick a Ranger Archetype that will give you features at levels 3, 7, 11, and 15.";
                var archetype = new List<string> { "Beast Master", "Fey Wanderer", "Gloom Stalker", "Horizon Walker", "Hunter",
                    "Monster Slayer", "Swarmkeeper" };
                int input = CLIHelper.PrintChoices(msg, archetype);
                RangerArchetype = archetype[input];
                var extendedSpells = new Dictionary<int, string>();

                switch (RangerArchetype)
                {
                    case "Beast Master":
                        result.ClassFeatures.Add("Ranger's Companion", "medium beast, CR 1/4 or lower, + PB to AC, atks, dmg, saves, skills, HP = normal or lvl x 4" +
                            "\naction to command it to atk, Dash, Disengage, Dodge, or Help - if you have extra atk, you can atk and command beast");

                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Exceptional Training", "bonus, if beast doesn't atk - command beast to Dash, Disengage, Dodge, or Help");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Bestial Fury", "when beast atks, it can make 2 atks or use Multiattack action if it has it");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Share Spells", "when you cast a spell on yourself, if beast is within 30ft - it gains benefits too");
                        }
                        break;
                    case "Fey Wanderer":
                        extendedSpells = new Dictionary<int, string> {
                            { 2, "Misty Step" },
                            { 3, "Dispel Magic" },
                            { 4, "Dimension Door" },
                            { 5, "Mislead" }
                        };
                        result.Spells[1].Add("Charm Person");
                        CLIHelper.AddSpells(result, extendedSpells);
                        var gifts = new List<string> { "Illusory butterflies flutter around you when you take SR or LR", 
                            "Fresh, seasonal flowers sprout from your hair each dawn", "Your shadow dances when no one is looking directly at it",
                            "You faintly smell of cinnamon, lavender, nutmeg, or another comforting herb or spice",
                            "Horns or antlers sprout from your head", "Your skin and hair change color to match the season each dawn" };
                        Console.WriteLine("Pick a Feywild gift that affects your appearance");
                        string gift = CLIHelper.PrintChoices(gifts);
                        result.ClassFeatures.Add("Feywild Gift", gift);
                        int dmg = 4;
                        if (lvl >= 11)
                        {
                            dmg += 2;
                        }
                        result.ClassFeatures.Add("Dreadful Strikes", $"1/turn, on hit, 1D{dmg} Psychic dmg");
                        result.ClassFeatures.Add("Otherworldly Glamour", "Cha checks + Wis");
                        var skills = new List<string> { "Deception", "Performance", "Persuasion" };
                        Console.WriteLine("Pick a skill");
                        string skill = CLIHelper.PrintChoices(skills);
                        result.SkillProficiencies.Add(skill);
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Beguiling Twist", "gain adv on saves vs charm and fear / reaction, 120ft, successful save vs charm or fear, Wis save, charm or fear 1 min");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Fey Reinforcements", "LR, cast Summon Fey without using a spell slot - can modify duration from conc to 1 min");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Misty Wanderer", "LR, cast Misty Step without using a spell slot - can also teleport adj ally");
                        }
                        break;
                    case "Gloom Stalker":
                        extendedSpells = new Dictionary<int, string> {
                            { 2, "Rope Trick" },
                            { 3, "Fear" },
                            { 4, "Greater Invisibility" },
                            { 5, "Seeming" }
                        };
                        result.Spells[1].Add("Disguise Self");
                        CLIHelper.AddSpells(result, extendedSpells);
                        if (!character.Vision.Contains("Darkvision"))
                        {
                            character.Vision = "Darkvision 60ft";
                        }
                        else
                        {
                            string vision = character.Vision;
                            if (vision.Contains("Superior"))
                            {
                                character.Vision = vision.Substring(0, vision.Length - 5) + "150ft";
                            }
                            else
                            {
                                character.Vision = vision.Substring(0, vision.Length - 4) + "90ft";
                            }
                        }
                        result.ClassFeatures.Add("Umbral Sight", "While in darkness, you are invisible to creatures who rely on Darkvision");
                        result.ClassFeatures.Add("Dread Ambusher", "Init + Wis, 1st turn, speed +10ft, gain extra atk, dmg + 1D8 on that atk");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Iron Mind", "gain prof in Wis saves(if already have gain Int or Cha instead)");
                            character.Saves.Add("Wis");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Stalker's Flurry", "1/turn, when you miss an atk, make an extra atk");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Shadowy Dodge", "reaction, when an enemy atk doesn't have adv, impose disadv");
                        }
                        break;
                    case "Horizon Walker":
                        extendedSpells = new Dictionary<int, string> {
                            { 2, "Misty Step" },
                            { 3, "Haste" },
                            { 4, "Banishment" },
                            { 5, "Teleportation Circle" }
                        };
                        result.Spells[1].Add("Protection from Evil and Good");
                        CLIHelper.AddSpells(result, extendedSpells);
                        result.ClassFeatures.Add("Detect Portal", "SR, action, 1 mile, detect distance and direction of nearest planar portal");
                        int planarDice = 1;
                        if (lvl >= 11)
                        {
                            planarDice++;
                        }
                        result.ClassFeatures.Add("Planar Warrior", $"bonus, 30ft, next atk's dmg becomes force, +{planarDice}D8 force dmg");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Ethereal Step", "SR, bonus, cast Etherealness");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Distant Strike", "When you use Attack action, teleport 10ft, if you atk 2 creatures - gain extra atk vs a 3rd creature");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Spectral Defense", "reaction, when hit, gain Resistance to dmg");
                        }
                        break;
                    case "Hunter":
                        msg = "Pick one of the following features";
                        if (lvl >= 3)
                        {
                            Console.WriteLine(msg);
                            CLIHelper.Print3Choices("Colossus Slayer", "Giant Killer", "Horde Breaker");
                            int choice = CLIHelper.GetNumberInRange(1, 3);
                            if (choice == 1)
                            {
                                result.ClassFeatures.Add("Colossus Slayer", "1/turn, if enemy is not max HP, +1D8 dmg");
                            }
                            else if (choice == 2)
                            {
                                result.ClassFeatures.Add("Giant Killer", "reaction, if Large or larger creature atks, free atk if within 5ft");
                            }
                            else if (choice == 3)
                            {
                                result.ClassFeatures.Add("Horde Breaker", "1/turn, make extra wep atk against 2nd creature");
                            }
                        }
                        if (lvl >= 7)
                        {
                            Console.WriteLine(msg);
                            CLIHelper.Print3Choices("Escape the Horde", "Multiattack Defense", "Steel Will");
                            int choice = CLIHelper.GetNumberInRange(1, 3);
                            if (choice == 1)
                            {
                                result.ClassFeatures.Add("Escape the Horde", "enemy op atks are made at disadv");
                            }
                            else if (choice == 2)
                            {
                                result.ClassFeatures.Add("Multiattack Defense", "after being hit, gain +4 AC");
                            }
                            else if (choice == 3)
                            {
                                result.ClassFeatures.Add("Steel Will", "adv on saves vs fear");
                            }
                        }
                        if (lvl >= 11)
                        {
                            Console.WriteLine(msg);
                            CLIHelper.Print2Choices("Volley", "Whirlwind Attack");
                            int choice = CLIHelper.GetNumberInRange(1, 2);
                            if (choice == 1)
                            {
                                result.ClassFeatures.Add("Volley", "action, atk all creatures you can see within 10ft");
                            }
                            else if (choice == 2)
                            {
                                result.ClassFeatures.Add("Whirlwind Attack", "action, melee atk all creatures within 5ft");
                            }
                        }
                        if (lvl >= 15)
                        {
                            Console.WriteLine(msg);
                            CLIHelper.Print3Choices("Evasion", "Stand Against the Tide", "Uncanny Dodge");
                            int choice = CLIHelper.GetNumberInRange(1, 3);
                            if (choice == 1)
                            {
                                result.ClassFeatures.Add("Evasion", "Dex saves = 1/2 or no dmg");
                            }
                            else if (choice == 2)
                            {
                                result.ClassFeatures.Add("Stand Against the Tide", "reaction, when enemy misses melee atk, force enemy to atk another creature");
                            }
                            else if (choice == 3)
                            {
                                result.ClassFeatures.Add("Uncanny Dodge", "reaction, 1/2 dmg");
                            }
                        }
                        break;
                    case "Monster Slayer":
                        extendedSpells = new Dictionary<int, string> {
                            { 2, "Zone of Truth" },
                            { 3, "Magic Circle" },
                            { 4, "Banishment" },
                            { 5, "Hold Monster" }
                        };
                        result.Spells[1].Add("Protection from Evil and Good");
                        CLIHelper.AddSpells(result, extendedSpells);
                        result.ClassFeatures.Add("Hunter's Sense", "Wis/LR, action, 60ft, learn Immunities, Resistances, Vulnerabilities of an enemy");
                        result.ClassFeatures.Add("Slayer's Prey", "SR, bonus, 60ft, 1/turn, dmg + 1D6");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Supernatural Defense", "when your Slayer's Prey target makes you roll a save/opposed grapple gain +1D6");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Magic-User's Nemesis", "reaction, 60ft, Wis save, when a spell is cast or a creature teleports, their spell or teleport fails");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Slayer's Counter", "reaction, before your Slayer's Prey makes you roll a save, make an atk - if it hits, auto-success on your save");
                        }
                        break;
                    case "Swarmkeeper":
                        extendedSpells = new Dictionary<int, string> {
                            { 2, "Web" },
                            { 3, "Gaseous Form" },
                            { 4, "Arcane Eye" },
                            { 5, "Insect Plague" }
                        };
                        result.Spells[1].Add("Faerie Fire");
                        result.Spells[1].Add("Mage Hand");
                        CLIHelper.AddSpells(result, extendedSpells);
                        var swarmList = new List<string> { "Swarming Insects", "Miniature Twig Blights", "Fluttering Birds", "Playful Pixies" };
                        Console.WriteLine("Pick an appearance for your swarm");
                        string swarm = CLIHelper.PrintChoices(swarmList);
                        int swarmDmg = 6;
                        if (lvl >= 11)
                        {
                            swarmDmg += 2;
                        }
                        result.ClassFeatures.Add("Gathered Swarm", $"1/turn, on hit, pick an effect - (dmg + 1D{swarmDmg} piercing), (Str save, slide enemy 15ft), or (move 5ft, costs no movement)" +
                            $"\nSwarm Appearance - {swarm}");
                        if (lvl >= 7)
                        {
                            result.ClassFeatures.Add("Writhing Tide", "PB/LR, bonus, 1 min, gain Hover and Fly 10ft");
                        }
                        if (lvl >= 11)
                        {
                            result.ClassFeatures.Add("Mighty Swarm", "if a creature fails Str save vs Gathered Swarm - knock prone" +
                                "\nwhen you move with Gathered Swarm - gain half cover(+2 AC, Dex saves) 1 turn");
                        }
                        if (lvl >= 15)
                        {
                            result.ClassFeatures.Add("Swarming Dispersal", "PB/LR, reaction, when you take dmg, gain Resistance to dmg and teleport 30ft");
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
            if (lvl >= 8)
            {
                result.ClassFeatures.Add("Land's Stride", "move through difficult terrain and plants that cause dmg, adv vs spells that impede movement");
            }
            if (lvl >= 10)
            {
                Console.WriteLine("Pick a Ranger class feature");
                CLIHelper.Print2Choices("Hide in Plain Sight", "Nature's Veil");
                num = CLIHelper.GetNumberInRange(1, 2);
                if (num == 1)
                {
                    result.ClassFeatures.Add("Hide in Plain Sight", "spend 1 min to camouflage self, gain +10 to Stealth without moving");
                }
                else
                {
                    result.ClassFeatures.Add("Nature's Veil", "PB/LR, bonus, become invisible");
                }
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Vanish", "Hide as bonus, can't be tracked nonmagically");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Feral Senses", "creatures you can't see don't impose disadv, know location of invisible creatures within 30ft");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Foe Slayer", "1/turn, + Wis to atk or dmg against favored enemy");
            }
            //spells code
            string str2 = "You already have that spell";
            string pickMsg = "Pick a 1st level spell.";
            AllSpells spells = new AllSpells("Ranger");
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
                    string spell = CLIHelper.GetNew(spells.Ranger[slotLvl], result.Spells[slotLvl], pickMsg, str2);
                    result.Spells[slotLvl].Add(spell);
                    spells.Ranger[slotLvl].Remove(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
