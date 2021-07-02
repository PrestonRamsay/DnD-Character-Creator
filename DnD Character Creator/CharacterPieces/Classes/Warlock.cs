using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Warlock
    {
        public static string OtherworldlyPatron { get; set; }
        public static string PactBoon { get; set; }
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
            List<string> classSkills = new List<string> { "Arcana", "Deception", "History", "Intimidation", "Investigation",
                "Nature", "Religion" };

            character.GP += 100;
            character.HitDie = 8;
            character.Proficiencies.Add("Light armor");
            character.Proficiencies.Add("Simple weapons");
            character.Saves.Add("Wis");
            character.Saves.Add("Cha");

            BEHelper.GetSkills(character, classSkills, 2);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Light crossbow and 20 bolts", "Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);

            if (input1 == 1)
            {
                character.Equipment.Add(Options.SimpleRangedWeapons[0]);
                character.Equipment.Add("20 bolts");
            }
            else
            {
                BEHelper.AddSimpleWeapon(character);
            }

            CLIHelper.Print2Choices("Component pouch", "Arcane focus");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            if (input2 == 1)
            {
                character.Equipment.Add("Component pouch");
            }
            else
            {
                var focuses = new List<string> { "Crystal", "Orb", "Rod", "Staff", "Wand" };
                int index = CLIHelper.PrintChoices("Pick an arcane focus.", focuses);
                character.Equipment.Add(Options.ArcaneFocuses[index]);
            }

            CLIHelper.Print2Choices("Scholar's Pack", "Dungeoneer's Pack");
            int input3 = CLIHelper.GetNumberInRange(1, 2);
            if (input3 == 1)
            {
                character.Equipment.Add(Options.Packs[6]);
            }
            else
            {
                character.Equipment.Add(Options.Packs[2]);
            }

            character.Equipment.Add(Options.LightArmor[1]);
            character.Equipment.Add($"2 {Options.SimpleMeleeWeapons[1]}");
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;

            character.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use an Arcane Focus as a spell focus");
            string msg = "Pick an Otherworldly Patron that will give you features at levels 1, 6, 10, and 14.";
            var archetype = new List<string> { "Archfey", "Celestial", "The Fathomless", "Fiend", "Genie", "Hexblade",
                "The Great Old One", "The Undying" };
            int answer = CLIHelper.PrintChoices(msg, archetype);
            OtherworldlyPatron = archetype[answer];

            switch (OtherworldlyPatron)
            {
                case "Archfey":
                    Archfey(character);
                    break;
                case "Celestial":
                    Celestial(character);
                    break;
                case "The Fathomless":
                    TheFathomless(character);
                    break;
                case "Fiend":
                    Fiend(character);
                    break;
                case "Genie":
                    Genie(character);
                    break;
                case "Hexblade":
                    Hexblade(character);
                    break;
                case "The Great Old One":
                    TheGreatOldOne(character);
                    break;
                case "The Undying":
                    TheUndying(character);
                    break;
            }

            if (lvl >= 3)
            {
                msg = "Pick a Pact Boon to determine your class feature";
                var pactBoons = new List<string> { "Pact of the Chain", "Pact of the Blade", "Pact of the Talisman", "Pact of the Tome" };
                int index = CLIHelper.PrintChoices(msg, pactBoons);

                if (index == 0)
                {
                    PactBoon = pactBoons[0];
                    character.ClassFeatures.Add(PactBoon, "learn Find Familiar spell, can take special forms: Imp, Pseudodragon, Quasit, or Sprite - can forgo atk to have familiar atk");
                }
                else if (index == 1)
                {
                    PactBoon = pactBoons[1];
                    character.ClassFeatures.Add(PactBoon, "action, create pact Blade that counts as magical");
                }
                else if (index == 2)
                {
                    PactBoon = pactBoons[2];
                    character.ClassFeatures.Add(PactBoon, "gain an amulet Talisman - PB/LR, when wearer fails a check, check + 1D4");
                }
                else if (index == 3)
                {
                    PactBoon = pactBoons[3];
                    character.ClassFeatures.Add(PactBoon, "pick 3 cantrips from any spell list");
                    var allCantrips = new List<string>();
                    foreach (var item in allCantrips)
                    {
                        if (WarlockSpells.Cantrips.Contains(item))
                        {
                            allCantrips.Remove(item);
                        }
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        string newCantrip = CLIHelper.GetNew(allCantrips, character.Cantrips, "Pick a cantrip");
                        character.Cantrips.Add(newCantrip);
                        allCantrips.Remove(newCantrip);
                    }
                }
            }
            if (lvl >= 2)
            {
                int invocations = 2;
                for (int i = 2; i <= lvl; i++)
                {
                    if (5 <= i && i <= 9 && i % 2 != 0)
                    {
                        invocations++;
                    }
                    if (i == 12 || i == 15 || i == 18)
                    {
                        invocations++;
                    }
                }
                character.ClassFeatures.Add("Invocations", "\n        ------------------------------------");
                var invocDictionary = Invocations(PactBoon, lvl);
                List<string> invocList = CLIHelper.GetDictionaryOptions(invocDictionary, invocations, "Pick an new Invocation");
                foreach (var item in invocList)
                {
                    character.ClassFeatures.Add(item, Options.AllInvocations[item]);
                }
            }
            if (lvl >= 4)
            {
                character.ClassFeatures.Add("Eldritch Versatility", "When you gain an Ability Score Improvement, change your Pact Boon, replace a cantrip, or replace a Mystic Arcanum spell");
            }
            int mysticLvl = 5;
            for (int i = 11; i <= lvl; i += 2)
            {
                if (i <= 17)
                {
                    mysticLvl++;
                    character.ClassFeatures.Add($"Mystic Arcanum({mysticLvl}th)", "1/LR cast a warlock spell of this lvl");
                }
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Eldritch Master", "1/LR, spend 1 min to regain all spell slots");
            }
            Spells(character);

            
        }
        public static void Archfey(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Faerie Fire");
            ExpandedSpells[1].Add("Sleep");
            ExpandedSpells[2].Add("Calm Emotions");
            ExpandedSpells[2].Add("Phantasmal Force");
            ExpandedSpells[3].Add("Blink");
            ExpandedSpells[3].Add("Plant Growth");
            ExpandedSpells[4].Add("Dominate Best");
            ExpandedSpells[4].Add("Greater Invisibility");
            ExpandedSpells[5].Add("Dominate Person");
            ExpandedSpells[5].Add("Seeming");

            character.ClassFeatures.Add("Fey Presence", "SR, action, 10ft, Wis save, charm creatures");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Misty Escape", "SR, reaction, when you take dmg - teleport 60ft and become invisible for 1 turn");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Beguiling Defenses", "gain Immunity to charm, use reaction to turn charm back - Wis save, 1 min charm");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Dark Delirium", "SR, action, 60ft, 1 min, 1 creature, Wis save, charm or frighten - they think their lost in a misty realm");
            }
        }
        public static void Celestial(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Cure Wounds");
            ExpandedSpells[1].Add("Guiding Bolt");
            ExpandedSpells[2].Add("Flaming Sphere");
            ExpandedSpells[2].Add("Lesser Restoration");
            ExpandedSpells[3].Add("Daylight");
            ExpandedSpells[3].Add("Revivify");
            ExpandedSpells[4].Add("Guardian of Faith");
            ExpandedSpells[4].Add("Wall of Fire");
            ExpandedSpells[5].Add("Flame Strike");
            ExpandedSpells[5].Add("Greater Restoration");
            character.Cantrips.Add("Light");
            character.Cantrips.Add("Sacred Flame");

            character.ClassFeatures.Add("Healing Light", "LR, gain D6 pool = 1 + lvl, bonus, 60ft, 1 creature, heal D6s - max dice spent at once = Cha");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Radiant Soul", "gain Resistance to Fire, when you cast a Radiant or Fire dmg spell, dmg + Cha Radiant or Fire");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Celestial Resilience", "on SR/LR gain temp HP = lvl + Cha, choose up to 5 creatures - they gain temp HP = 1/2 lvl + Cha");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Searing Vengeance", "LR, when your turn starts with a death save, regain HP = 1/2 max HP and stand up " +
                    "\n        each creature, 30ft, 2D8 + Cha Radiant dmg and blinded");
            }
        }
        public static void TheFathomless(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Create or Destroy Water");
            ExpandedSpells[1].Add("Thunderwave");
            ExpandedSpells[2].Add("Gust of Wind");
            ExpandedSpells[2].Add("Silence");
            ExpandedSpells[3].Add("Lightning Bolt");
            ExpandedSpells[3].Add("Sleet Storm");
            ExpandedSpells[4].Add("Control Water");
            ExpandedSpells[4].Add("Summon Elemental(water only)");
            ExpandedSpells[5].Add("Bigby's Hand(appears as tentacle)");
            ExpandedSpells[5].Add("Cone of Cold");

            int tentacle = 1;
            if (lvl >= 10)
            {
                tentacle++;
            }

            character.ClassFeatures.Add("Tentacle of the Deeps", $"PB/LR, bonus, 1 min, 60ft, create 10ft tentacle - make melee spell atk, {tentacle}D8 Cold, reduce speed by 10ft" +
                "\n        bonus, move tentacle 30ft and atk again");
            character.ClassFeatures.Add("Gift of the Sea", "gain waterbreathing and Swim 40ft");
            character.Speedstring += ", Swim 40ft";
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Oceanic Soul", "gain Resistance to Cold dmg, if you and another creature are fully submerged - understand each other");
                int dmg = 1;
                if (lvl >= 10)
                {
                    dmg++;
                }
                character.ClassFeatures.Add("Guardian Coil", $"reaction, 10ft, reduce dmg by {dmg}D8");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Grasping Tentacles", "LR, cast Evard's Black Tentacles without using a spell slot" +
                    "\n        whenever you cast Evard's Black Tentacles, gain temp HP = lvl, dmg can't break conc");
                character.Spells[4].Add("Evard's Black Tentacles");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Fathomless Plunge", "action, 30ft, 5 creatures, teleport up to 1 mile in or 30ft from body of water you've seen (everyone must be within 30ft)");
            }
        }
        public static void Fiend(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Burning Hands");
            ExpandedSpells[1].Add("Command");
            ExpandedSpells[2].Add("Blindness/Deafness");
            ExpandedSpells[2].Add("Scorching Ray");
            ExpandedSpells[3].Add("Fireball");
            ExpandedSpells[3].Add("Stinking Cloud");
            ExpandedSpells[4].Add("Fire Shield");
            ExpandedSpells[4].Add("Wall of Fire");
            ExpandedSpells[5].Add("Flame Strike");
            ExpandedSpells[5].Add("Hallow");

            character.ClassFeatures.Add("Dark One's Blessing", "on kill, gain temp HP = Cha + lvl");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Dark One's Own Luck", "SR, on ability check, Init, or save + 1D10");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Fiendish Resilience", "on SR/LR choose Resistance to one dmg type - bypassed by magical/silver weps");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Hurl Through Hell", "on hit, disappears til next turn - if not a fiend, take 10D10 Psychic dmg");
            }
        }
        public static void Genie(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Detect Evil and Good");
            ExpandedSpells[2].Add("Phatasmal Force");
            ExpandedSpells[3].Add("Create Food and Water");
            ExpandedSpells[4].Add("Phantasmal Killer");
            ExpandedSpells[5].Add("Creation");
            var genies = new List<string> { "Dao(Earth)", "Djinni(Air)", "Efreeti(Fire)", "Marid(Water)" };
            Console.WriteLine("Pick which kind of Genie you want your Otherworldly Patron to be");
            string patron = CLIHelper.PrintChoices(genies);
            string dmgType = "";
            switch (patron)
            {
                case "Dao(Earth)":
                    OtherworldlyPatron += "(Dao)";
                    ExpandedSpells[1].Add("Sanctuary");
                    ExpandedSpells[2].Add("Spike Growth");
                    ExpandedSpells[3].Add("Meld Into Stone");
                    ExpandedSpells[4].Add("Stoneshape");
                    ExpandedSpells[5].Add("Wall of Stone");
                    dmgType = "Bludgeoning";
                    break;
                case "Djinni(Air)":
                    OtherworldlyPatron += "(Djinni)";
                    ExpandedSpells[1].Add("Thunderwave");
                    ExpandedSpells[2].Add("Gust of Wind");
                    ExpandedSpells[3].Add("Wind Wall");
                    ExpandedSpells[4].Add("Greater Invisibility");
                    ExpandedSpells[5].Add("Seeming");
                    dmgType = "Thunder";
                    break;
                case "Efreeti(Fire)":
                    OtherworldlyPatron += "(Efreeti)";
                    ExpandedSpells[1].Add("Burning Hands");
                    ExpandedSpells[2].Add("Scorching Ray");
                    ExpandedSpells[3].Add("Fireball");
                    ExpandedSpells[4].Add("Fire Shield");
                    ExpandedSpells[5].Add("Flame Strike");
                    dmgType = "Fire";
                    break;
                case "Marid(Water)":
                    OtherworldlyPatron += "(Marid)";
                    ExpandedSpells[1].Add("Fog Cloud");
                    ExpandedSpells[2].Add("Blur");
                    ExpandedSpells[3].Add("Sleet Storm");
                    ExpandedSpells[4].Add("Control Water");
                    ExpandedSpells[5].Add("Cone of Cold");
                    dmgType = "Cold";
                    break;
            }

            character.ClassFeatures.Add("Genie's Vessel", "AC = spell DC, HP = lvl + PB, Immunity to Poison and Psychic" +
                "\n        Bottled Respite(LR, action, PB x 2 hr, enter/exit extradimensional space inside the vessel)" +
                $"\n        Genie's Wrath(1/turn, on hit, dmg + PB {dmgType})");
            character.ClassFeatures["Spellcasting"] = "use Cha for spell DCs, use Arcane Focus or Genie Vessel as a spell focus";
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Elemental Gift", $"gain Resistance to {dmgType} / PB/LR, bonus, 10 min, gain Hover and Fly 30ft");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Sanctuary Vessel", "you can bring 5 creatures when you use Bottled Respite, bonus to eject / 10 min = SR, Hit Dice + PB for healing");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Limited Wish", "1D4 LR, action, gain effect of any 6th lvl or lower spell (cast time 1 action)");
            }
        }
        public static void Hexblade(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Shield");
            ExpandedSpells[1].Add("Wrathful Smite");
            ExpandedSpells[2].Add("Blur");
            ExpandedSpells[2].Add("Branding Smite");
            ExpandedSpells[3].Add("Blink");
            ExpandedSpells[3].Add("Elemental Weapon");
            ExpandedSpells[4].Add("Phantasmal Killer");
            ExpandedSpells[4].Add("Staggering Smite");
            ExpandedSpells[5].Add("Banishing Smite");
            ExpandedSpells[5].Add("Cone of Cold");

            character.ClassFeatures.Add("Hexblade's Curse", "bonus, 30ft, 1 min, dmg + Prof, crit on 19, on death - regain HP = lvl + Cha");
            character.ClassFeatures.Add("Hex Warrior", "on LR, touch One-Handed wep, use Cha for atk/dmg (Pact Weapon auto-gets this feature)");
            character.Proficiencies.Add("Medium Armor");
            character.Proficiencies.Add("Shields");
            character.Proficiencies.Add("Martial Weapons");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Accursed Specter", "LR, on kill, raise humanoid as specter - it gains temp HP = 1/2 lvl, atk + Cha, obeys verbal commands");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Armor of Hexes", "reaction, if Hexblade Curse target hits, roll 1D6 - if 4+ then atk misses");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Master of Hexes", "Hexblade Curse target dies, 30ft, apply Curse to new target instead of regaining HP");
            }
        }
        public static void TheGreatOldOne(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Dissonant Whispers");
            ExpandedSpells[1].Add("Tasha's Hideous Laughter");
            ExpandedSpells[2].Add("Detect Thoughts");
            ExpandedSpells[2].Add("Phantasmal Force");
            ExpandedSpells[3].Add("Clairvoyance");
            ExpandedSpells[3].Add("Sending");
            ExpandedSpells[4].Add("Dominate Beast");
            ExpandedSpells[4].Add("Evard's Black Tentacles");
            ExpandedSpells[5].Add("Dominate Person");
            ExpandedSpells[5].Add("Telekinesis");

            character.ClassFeatures.Add("Awakened Mind", "30ft, commmunicate telepathically without common language");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Entropic Ward", "SR, reaction, impose disadv on atk - if miss, gain adv on next atk");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Thought Shield", "Resistance to Psychic, thoughts can't be telepathically read unless you allow it");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Create Thrall", "action, touch incapacitated humanoid, charmed until Remove Curse is cast, can communicate telepathically");
            }
        }
        public static void TheUndying(Character character)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("False Life");
            ExpandedSpells[1].Add("Ray of Sickness");
            ExpandedSpells[2].Add("Blindness/Deafness");
            ExpandedSpells[2].Add("Silence");
            ExpandedSpells[3].Add("Feign Death");
            ExpandedSpells[3].Add("Speak with Dead");
            ExpandedSpells[4].Add("Aura of Lif");
            ExpandedSpells[4].Add("Death Ward");
            ExpandedSpells[5].Add("Contagion");
            ExpandedSpells[5].Add("Legend Lore");

            character.ClassFeatures.Add("Among the Dead", "adv on saves vs disease, undead must make Wis save to atk, on fail must choose new target");
            character.Cantrips.Add("Spare the Dying");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Defy Death", "LR, when you use Spare the Dying or you succeed on a death save, regain 1D8 + Con HP");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Undying Nature", "for every 10yr you only age 1 yr, can't be aged magically, you don't need to eat, drink, sleep, or breathe");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Indestructible Life", "SR, bonus, regain HP = 1D8 + lvl, can reattach severed limbs");
            }
        }
        public static Dictionary<string, string> Invocations(string pact, int lvl)
        {
            var invoc = new List<string>();
            invoc.AddRange(Options.BaseInvocations);
            
            if (pact == "Pact of the Blade")
            {
                invoc.Add("Improved Pact Weapon");
                if (lvl >= 5)
                {
                    invoc.Add("Eldritch Smite");
                    invoc.Add("Thirsting Blade");
                }
                if (lvl >= 12)
                {
                    invoc.Add("Lifedrinker");

                }
            }
            else if (pact == "Pact of the Chain")
            {
                invoc.Add("Gift of the Ever-Living Ones");
                invoc.Add("Investment of the Chain Master");
                invoc.Add("Voice of the Chain Master");
                if (lvl >= 15)
                {
                    invoc.Add("Chains of Carceri");
                }
            }
            else if (pact == "Pact of the Talisman")
            {
                invoc.Add("Protector of the Talisman");
                if (lvl >= 9)
                {
                    invoc.Add("Rebuke of the Talisman");
                }
                if (lvl >= 12)
                {
                    invoc.Add("Bond of the Talisman");
                }
            }
            else if (pact == "Pact of the Tome")
            {
                invoc.Add("Aspect of the Moon");
                invoc.Add("Book of Ancient Secrets");
                if (lvl >= 5)
                {
                    invoc.Add("Far Scribe");
                }
                if (lvl >= 9)
                {
                    invoc.Add("Gift of the Protectors");
                }
            }
            if (lvl >= 5)
            {
                invoc.AddRange(Options.LvlFiveInvoc);
            }
            if (lvl >= 7)
            {
                invoc.AddRange(Options.LvlSevenInvoc);

            }
            if (lvl >= 9)
            {
                invoc.AddRange(Options.LvlNineInvoc);
            }
            if (lvl >= 15)
            {
                invoc.AddRange(Options.LvlFifteenInvoc);
            }
            invoc.Sort();
            var dict = new Dictionary<string, string>();
            foreach (var item in invoc)
            {
                dict.Add(item, Options.AllInvocations[item]);
            }

            return dict;
        }
        public static void Spells(Character character)
        {
            int lvl = character.Lvl;
            string pickMsg = "Pick a cantrip.";
            int spellLvl = 1;
            AllSpells spells = new AllSpells(character);
            foreach (var newLvl in ExpandedSpells.Keys)
            {
                spells.Warlock[newLvl].AddRange(ExpandedSpells[newLvl]);
            }
            if (OtherworldlyPatron.Contains("Genie"))
            {
                spells.Warlock[9].Add("Wish");
            }

            for (int i = 0; i < character.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(WarlockSpells.Cantrips, character.Cantrips, pickMsg);
                character.Cantrips.Add(spell);
            }
            pickMsg = "Pick a 1st level spell.";
            for (int i = 1; i <= character.SpellsKnown; i++)
            {
                if (4 <= i && i <= 10 && i % 2 == 0)
                {
                    spellLvl++;
                }
                if (i == 4)
                {
                    pickMsg = "Pick a 2nd level spell.";
                }
                if (i == 6)
                {
                    pickMsg = "Pick a 3rd level spell.";
                }
                if (i >= 8)
                {
                    pickMsg = $"Pick a {spellLvl}th level spell.";
                }
                string spell = CLIHelper.GetNew(spells.Warlock[spellLvl], character.Spells[spellLvl], pickMsg);
                character.Spells[spellLvl].Add(spell);
                spells.Warlock[spellLvl].Remove(spell);
            }
        }
    }
}
