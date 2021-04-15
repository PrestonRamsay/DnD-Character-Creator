using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class ArtificerSpecifics
    {
        public static string ArtificerSpecialist { get; set; }
        public static Dictionary<int, List<string>> ExpandedSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() }
        };
        public static CharacterClass Features(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;
            result.ClassFeatures.Add("Magical Tinkering", "action, must have spell focus, give Tiny nonmagical object one of four properties" +
                "\n        (bright light 5ft/dim light 5ft), (tapping plays 6 sec recorded message, can be heard from 10ft)" +
                "\n        (emits odor or nonverbal sound, can be perceived from 10ft), or (visual effect on object's surface - pic, up to 25 words, etc)");
            result.ClassFeatures.Add("Spellcasting", "use Int for spell DCs, you use Thieves' Tools or Artisan's Tools as a spell focus");

            if (lvl >= 2)
            {
                var infusionList = new List<string>();
                infusionList.AddRange(Options.BaseInfusions);
                if (lvl >= 6)
                {
                    infusionList.AddRange(Options.Lvl6Infusions);
                }
                if (lvl >= 10)
                {
                    infusionList.Add("Helm of Awareness");
                }
                if (lvl >= 14)
                {
                    infusionList.Add("Arcane Propulsion Armor");
                }
                infusionList.Sort();
                int infusions = 4;
                for (int i = 6; i <= lvl; i += 4)
                {
                    infusions++;
                }
                int maxItems = infusions / 2;
                result.ClassFeatures.Add("Infuse Item", $"on LR, touch specific items to infuse/attune, max items = {maxItems}");
                result.ClassFeatures.Add("Infusions", "\n        ------------------------------------");
                for (int i = 0; i < infusions; i++)
                {
                    string newInfusion = CLIHelper.PrintChoices(Options.Infusions, infusionList, "Pick a new infusion");
                    result.ClassFeatures["Infusions"] += $"\n        {newInfusion}({Options.Infusions[newInfusion]})";
                    if (newInfusion != "Replicate Magic Item")
                    {
                        infusionList.Remove(newInfusion);
                    }
                }
            }
            if (lvl >= 3)
            {
                result.ClassFeatures.Add("The Right Tool for the Job", "");
                string msg = "Pick a type of Specialist that will give you features at levels 3, 5, 9, and 15.";
                var archetype = new List<string> { "Alchemist", "Armorer", "Artillerist", "Battle Smith" };
                int input = CLIHelper.PrintChoices(msg, archetype);
                ArtificerSpecialist = archetype[input];

                switch (ArtificerSpecialist)
                {
                    case "Alchemist":
                        Alchemist(character, result);
                        break;
                    case "Armorer":
                        Armorer(character, result);
                        break;
                    case "Artillerist":
                        Artillerist(character, result);
                        break;
                    case "Battle Smith":
                        BattleSmith(character, result);
                        break;
                }
            }
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Tool Expertise", "add double PB to checks made with prof tools");
                var prof = new List<string>();
                prof.AddRange(character.ToolProficiencies);
                string expertise = CLIHelper.PrintChoices(prof);
                character.ToolProficiencies.Remove(expertise);
                character.ToolProficiencies.Add(expertise + "(Expertise)");
            }
            if (lvl >= 7)
            {
                result.ClassFeatures.Add("Flash of Genius", "Int/LR, reaction, 30ft, 1 creature, check or save + Int");
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Magic Item Adept", "attune up to 4 magic items, creating common or uncommon items - 1/4 time and 1/2 gold");
            }
            if (lvl >= 11)
            {
                result.ClassFeatures.Add("Spell-Storing Item", "on LR, weapon or spell focus gains 1st or 2nd lvl Artificer spell (cast time 1 action), Int x 2 uses, action to release spell");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Magic Item Savant", "attune up to 5 magic items / ignore all class, race, spell, and lvl requirements for using/attuning magic items");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Magic Item Master", "attune up to 6 magic items");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Soul of Artifice", "saves + 1 per magic item attuned / reaction, when you drop to 0 HP, end an infusion to drop to 1 HP instead");
            }
            Spells(result);

            return result;
        }
        public static void Alchemist(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;
            ExpandedSpells[1].Add("Healing Word*");
            ExpandedSpells[1].Add("Ray of Sickness*");
            ExpandedSpells[2].Add("Flaming Sphere*");
            ExpandedSpells[2].Add("Melf's Acid Arrow*");
            ExpandedSpells[3].Add("Gaseous Form*");
            ExpandedSpells[3].Add("Mass Healing Word*");
            ExpandedSpells[4].Add("Blight*");
            ExpandedSpells[4].Add("Death Ward*");
            ExpandedSpells[5].Add("Cloudkill*");
            ExpandedSpells[5].Add("Raise Dead*");
            AddNewTool(character, result, "Alchemist's Supplies");
            int elixirs = 1;
            for (int i = 6; i <= lvl; i += 9)
            {
                elixirs++;
            }
            result.ClassFeatures.Add("Experimental Elixir", $"{elixirs}/LR or 1st lvl spell, action to create, roll 1D6 for effect, action to use" +
                $"\n        (1)Healing(heal 2D4 + Int HP), (2)Swiftness(speed +10ft for 1 hr), (3)Resilience(+1 AC for 10 min)" +
                $"\n        (4)Boldness(saves and atks + 1D4 for 1 min), (5)Flight(gain Fly 10ft for 10 min), (6)Transformation(as Alter Self spell for 10 min)");
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Alchemical Savant", "when you cast a spell, healing or dmg + Int (dmg must be Acid, Fire, Necrotic, or Poison)");
            }
            if (lvl >= 9)
            {
                result.ClassFeatures.Add("Restorative Reagents", "when a creature drinks an Experimental Elixir, it gains temp HP = 2D6 + Int" +
                    "\n        Int/LR, cast Lesser Restoration without using a spell slot");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures.Add("Chemical Mastery", "gain Resistance to Acid and Poison, gain Immunity to poison(condition)" +
                    "\n        LR, cast Greater Restoration or Heal without using a spell slot");
            }
        }
        public static void Armorer(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;
            ExpandedSpells[1].Add("Magic Missile*");
            ExpandedSpells[1].Add("Thunderwave*");
            ExpandedSpells[2].Add("Mirror Image*");
            ExpandedSpells[2].Add("Shatter*");
            ExpandedSpells[3].Add("Hypnotic Pattern*");
            ExpandedSpells[3].Add("Lightning Bolt*");
            ExpandedSpells[4].Add("Fire Shield*");
            ExpandedSpells[4].Add("Greater Invisibility*");
            ExpandedSpells[5].Add("Passwall*");
            ExpandedSpells[5].Add("Wall of Force*");
            AddNewTool(character, result, "Smith's Tools");
            result.ClassFeatures.Add("Arcane Armor", "action, gains magical benefits(no Str req, use armor as spell focus, can't be removed, replaces limbs, doff/don as action)");
            result.ClassFeatures.Add("Arcane Model", "on SR, pick a model to gain a special atk and secondary abilities" +
                "\n        Guardian(Thunder Gauntlets - unarmed dmg = 1D8 Thunder, impose disadv on atks vs allies / Defensive Field - PB/LR, bonus, gain temp HP = lvl)" +
                "\n        Infiltrator(Lightning Launcher - ranged atk = 1D6 Lightning dmg, range 90/300 - 1/turn dmg + 1D6 / speed +5ft, gain adv on Stealth)");
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
            }
            if (lvl >= 9)
            {
                result.ClassFeatures.Add("Armor Modifications", "gain max Infused Items + 2, your Arcane Armor counts as 3 piece(boots, chest piece, helmet)");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures.Add("Perfected Armor", "gain benefits to Arcane Armor based on model" +
                    "\n        Guardian(PB/LR, reaction, 30ft, Huge or smaller creature, pull 30ft - if adj, melee atk)" +
                    "\n        Infiltrator(on hit with Lightning Launcher, impose disadv on atk, 5ft of dim light, adv on next atk - hit = dmg + 1D6)");
            }
        }
        public static void Artillerist(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;
            ExpandedSpells[1].Add("Shield*");
            ExpandedSpells[1].Add("Thunderwave*");
            ExpandedSpells[2].Add("Scorching Ray*");
            ExpandedSpells[2].Add("Shatter*");
            ExpandedSpells[3].Add("Fireball*");
            ExpandedSpells[3].Add("Wind Wall*");
            ExpandedSpells[4].Add("Ice Storm*");
            ExpandedSpells[4].Add("Wall of Fire*");
            ExpandedSpells[5].Add("Cone of Cold*");
            ExpandedSpells[5].Add("Wall of Force*");
            AddNewTool(character, result, "Woodcarver's Tools");
            int dmg = 2;
            if (lvl >= 9)
            {
                dmg++;
            }
            result.ClassFeatures.Add("Eldritch Cannon", "LR or spell slot, action, 1 hr, create Small or Tiny cannon - pick an option" +
                "\n        AC 18, HP = lvl x 5, Immunity to Poison and Psychic, saves = 0, Mending heals 2D6 HP / bonus, 60ft, activate and walk/climb 15ft" +
                $"\n        Flamethrower(15ft cone, Dex save, {dmg}D8 Fire dmg)" +
                $"\n        Force Ballista(ranged spell atk, 120ft, {dmg}D8 Force dmg)" +
                "\n        Protector(10ft, grant temp HP = 1D8 + Int)");
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Arcane Firearm", "on LR, turn rod/staff/wand into an Arcane Firearm, dmg + 1D8");
            }
            if (lvl >= 9)
            {
                result.ClassFeatures.Add("Explosive Cannon", "action, 20ft, destroy cannon, Dex save, 3D8 Force dmg");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures.Add("Fortified Position", "10ft, allies gain half cover(+2 AC, Dex saves) / create and control 2 cannons");
            }
        }
        public static void BattleSmith(Character character, CharacterClass result)
        {
            int lvl = result.Lvl;
            ExpandedSpells[1].Add("Heroism*");
            ExpandedSpells[1].Add("Shield*");
            ExpandedSpells[2].Add("Branding Smite*");
            ExpandedSpells[2].Add("Warding Bond*");
            ExpandedSpells[3].Add("Aura of Vitality*");
            ExpandedSpells[3].Add("Conjure Barrage*");
            ExpandedSpells[4].Add("Aura of Purity*");
            ExpandedSpells[4].Add("Fire Shield*");
            ExpandedSpells[5].Add("Banishing Smite*");
            ExpandedSpells[5].Add("Mass Cure Wounds*");
            AddNewTool(character, result, "Smith's Tools");
            result.ClassFeatures.Add("Battle Ready", "use Int instead of Str/Dex for wep atks");
            result.Proficiencies.Add("Martial Weapons");
            result.ClassFeatures.Add("Steel Defender", "companion, 2 or 4 legs, uses your PB, defaults to Dodge, bonus to command, Mending heals 2D6 HP" +
                "expend a spell slot, action, after 1 min revive with max HP, TCE pg 19");
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Extra Attack", "When using an atk action, atk twice");
            }
            if (lvl >= 9)
            {
                int dmg = 2;
                if (lvl >= 15)
                {
                    dmg = 4;
                }
                result.ClassFeatures.Add("Arcane Jolt", $"Int/LR, when you or steel defender hit - (dmg + {dmg}D6 Force) or (30ft, ally heals {dmg}D6 HP)");
            }
            if (lvl >= 15)
            {
                result.ClassFeatures.Add("Improved Defender", "steel defender AC + 2, when it uses Deflect action - Int + 1D4 Force dmg");
            }
        }
        public static void Spells(CharacterClass result)
        {
            CLIHelper.AddSpells(result, ExpandedSpells);
            string str2 = "You already have that spell";
            string pickMsg = "Pick a 1st level spell.";
            AllSpells spells = new AllSpells("Artificer");
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
                    string spell = CLIHelper.GetNew(spells.Artificer[slotLvl], result.Spells[slotLvl], pickMsg, str2);
                    result.Spells[slotLvl].Add(spell);
                    spells.Artificer[slotLvl].Remove(spell);
                }
            }
        }
        public static void AddNewTool(Character character, CharacterClass result, string newTool)
        {
            if (result.ToolProficiencies.Contains(newTool) || character.ToolProficiencies.Contains(newTool))
            {
                var allToolProf = new List<string>();
                allToolProf.AddRange(result.ToolProficiencies);
                allToolProf.AddRange(character.ToolProficiencies);
                string msg = "Pick a set of Artisan's Tools to gain proficiency in";
                string tool = CLIHelper.GetNew(Options.ArtisanTools, allToolProf, msg, "You already have prof with that tool");
                result.ToolProficiencies.Add(tool);
            }
            else
            {
                result.ToolProficiencies.Add(newTool);
            }
        }
    }
}
