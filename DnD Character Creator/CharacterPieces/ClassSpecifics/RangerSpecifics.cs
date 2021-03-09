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
        public static CharacterClass Features(CharacterClass result)
        {
            int lvl = result.Lvl;
            List<string> enemyTypes = new List<string> { "Aberrations", "Beasts", "Celestials", "Constructs", "Dragons", "Elementals", "Fey",
                "Fiends", "Giants","Humanoids", "Monstrosities", "Oozes", "Plants", "Undead" };
            string msg = "Pick an enemy type for your Favored Enemy";
            int index = CLIHelper.PrintChoices(msg, enemyTypes);
            string enemy = enemyTypes[index];
            msg = "Pick a Favored Terrain";
            List<string> terrains = new List<string> { "Arctic", "Coast", "Desert", "Forest", "Grassland", "Mountain", "Swamp", "Underdark" };
            index = CLIHelper.PrintChoices(msg, terrains);
            string land = terrains[index];
            result.ClassFeatures.Add($"Favored Enemy({enemy})", "adv on Survival checks, gain 1 lang, +2 dmg");
            result.ClassFeatures.Add($"Natural Explorer({land})", "no difficult terrain, move stealthily at normal pace, forage x 2, learn exact number/size of creatures");

            string enemy2 = "";
            string land2 = "";
            string enemy3 = "";
            string land3 = "";

            if (lvl >= 6)
            {
                result.ClassFeatures.Remove($"Favored Enemy({enemy})");
                result.ClassFeatures.Remove($"Natural Explorer({land})");
                enemyTypes.Remove(enemy);
                terrains.Remove(land);
                msg = "Pick an additional enemy type for your Favored Enemies";
                index = CLIHelper.PrintChoices(msg, enemyTypes);
                enemy2 = enemyTypes[index];
                msg = "Pick an additional Favored Terrain";
                index = CLIHelper.PrintChoices(msg, terrains);
                land2 = terrains[index];
                result.ClassFeatures.Add($"Favored Enemy({enemy}, {enemy2})", "adv on Survival checks, gain 1 lang, +2 dmg");
                result.ClassFeatures.Add($"Natural Explorer({land}, {land2})", "no difficult terrain, move stealthily at normal pace, forage x 2, learn exact number/size of creatures");
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Remove($"Favored Enemy({enemy}, {enemy2})");
                result.ClassFeatures.Remove($"Natural Explorer({land}, {land2})");
                enemyTypes.Remove(enemy2);
                terrains.Remove(land2);
                msg = "Pick an additional enemy type for your Favored Enemies";
                index = CLIHelper.PrintChoices(msg, enemyTypes);
                enemy3 = enemyTypes[index];
                msg = "Pick an additional Favored Terrain";
                index = CLIHelper.PrintChoices(msg, terrains);
                land3 = terrains[index];
                result.ClassFeatures.Add($"Favored Enemy({enemy}, {enemy2}, {enemy3})", "adv on Survival checks, gain 1 lang, +2 dmg");
                result.ClassFeatures.Add($"Natural Explorer({land}, {land2}, {land3})", "no difficult terrain, move stealthily at normal pace, forage x 2, learn exact number/size of creatures");
            }

            if (lvl >= 2)
            {
                string fightStyleMsg = "Pick a fighting style.";
                List<string> styleList = new List<string>();
                foreach (var style in Options.FightingStyles.Keys)
                {
                    if (style != "Great Weapon Fighting" && style != "Protection")
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
                msg = "Pick a Ranger Archetype that will give you features at levels 3, 7, 11, and 15.";
                var archetype = new List<string> { "Hunter", "Beast Master" };
                int input = CLIHelper.PrintChoices(msg, archetype);
                result.ClassFeatures.Add("Primeval Awareness", "expend spell slot, 1 min per spell lvl sense presence of aberrations, celestials," +
                    "\ndragons, elementals, fey, fiends, and undead within 1 mile or 6 mile if favored terrain");

                if (input == 0)
                {
                    RangerArchetype = archetype[0];
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
                }
                else if (input == 1)
                {
                    RangerArchetype = archetype[1];
                    result.ClassFeatures.Add("Ranger's Companion", "medium beast, CR 1/4 or lower, + prof bonus to AC, atks, dmg, saves, skills, HP = normal or lvl x 4" +
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
                }
                //else if (input == 2)
                //{
                //    RangerArchetype = archetype[2];

                //if (lvl >= 3)
                //{
                //    result.ClassFeatures.Add("", "");
                //}
                //if (lvl >= 7)
                //{
                //    result.ClassFeatures.Add("", "");
                //}
                //if (lvl >= 11)
                //{
                //    result.ClassFeatures.Add("", "");
                //}
                //if (lvl >= 15)
                //{
                //    result.ClassFeatures.Add("", "");
                //}
                //}
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
                result.ClassFeatures.Add("Hide in Plain Sight", "spend 1 min to camouflage self, gain +10 to Stealth without moving");
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
                    string spell = CLIHelper.GetNew(spells.Ranger[slotLvl], result.Spells[slotLvl], pickMsg, str2);
                    result.Spells[slotLvl].Add(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
