using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class WarlockSpecifics
    {
        public static string OtherworldlyPatron { get; set; }
        public static Dictionary<int, List<string>> ExpandedSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
        };
        public static CharacterClass Features(CharacterClass result)
        {
            int lvl = result.Lvl;

            string msg = "Pick an Otherworldly Patron that will give you features at levels 1, 6, 10, and 14.";
            var archetype = new List<string> { "Archfey", "Fiend", "The Great Old One" };
            int answer = CLIHelper.PrintChoices(msg, archetype);

            if (answer == 0)
            {
                OtherworldlyPatron = archetype[0];
                ExpandedSpells[1].Add("Faerie Fire*");
                ExpandedSpells[1].Add("Sleep*");
                ExpandedSpells[2].Add("Calm Emotions*");
                ExpandedSpells[2].Add("Phantasmal Force*");
                ExpandedSpells[3].Add("Blink*");
                ExpandedSpells[3].Add("Plant Growth*");
                ExpandedSpells[4].Add("Dominate Best*");
                ExpandedSpells[4].Add("Greater Invisibility*");
                ExpandedSpells[5].Add("Dominate Person*");
                ExpandedSpells[5].Add("Seeming*");
                result.ClassFeatures.Add("Fey Presence", "1/SR, action, 10ft, Wis save, charm creatures");

                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Misty Escape", "1/SR, reaction, when you take dmg - teleport 60ft and become invisible");
                }
                if (lvl >= 10)
                {
                    result.ClassFeatures.Add("Beguiling Defenses", "immune to charm, use reaction to turn charm back - Wis save, 1 min charm");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures.Add("Dark Delirium", "1/SR, action, 60ft, 1 min, 1 creature, Wis save, charm or frighten - they think their lost in a misty realm");
                }
            }
            else if (answer == 1)
            {
                OtherworldlyPatron = archetype[1];
                ExpandedSpells[1].Add("Burning Hands*");
                ExpandedSpells[1].Add("Command*");
                ExpandedSpells[2].Add("Blindness/Deafness*");
                ExpandedSpells[2].Add("Scorching Ray*");
                ExpandedSpells[3].Add("Fireball*");
                ExpandedSpells[3].Add("Stinking Cloud*");
                ExpandedSpells[4].Add("Fire Shield*");
                ExpandedSpells[4].Add("Wall of Fire*");
                ExpandedSpells[5].Add("Flame Strike*");
                ExpandedSpells[5].Add("Hallow*");
                result.ClassFeatures.Add("Dark One's Blessing", "on kill, gain temp HP = Cha + lvl");

                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Dark One's Own Luck", "1/SR, on ability check, Init, or save + 1D10");
                }
                if (lvl >= 10)
                {
                    result.ClassFeatures.Add("Fiendish Resilience", "on SR/LR choose Resistance to one dmg type - bypassed by magical/silver weps");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures.Add("Hurl Through Hell", "on hit, disappears til next turn - if not a fiend, take 10D10 psychic dmg");
                }
            }
            else if (answer == 2)
            {
                OtherworldlyPatron = "Great Old One";
                ExpandedSpells[1].Add("Dissonant Whispers*");
                ExpandedSpells[1].Add("Tasha's Hideous Laughter*");
                ExpandedSpells[2].Add("Detect Thoughts*");
                ExpandedSpells[2].Add("Phantasmal Force*");
                ExpandedSpells[3].Add("Clairvoyance*");
                ExpandedSpells[3].Add("Sending*");
                ExpandedSpells[4].Add("Dominate Beast*");
                ExpandedSpells[4].Add("Evard's Black Tentacles*");
                ExpandedSpells[5].Add("Dominate Person*");
                ExpandedSpells[5].Add("Telekinesis*");
                result.ClassFeatures.Add("Awakened Mind", "30ft, commmunicate telepathically without common language");

                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Entropic Ward", "1/SR, reaction, impose disadv on atk - if miss, gain adv on next atk");
                }
                if (lvl >= 10)
                {
                    result.ClassFeatures.Add("Thought Shield", "Resistance on psychic, thoughts can't be telepathically read unless you allow it");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures.Add("Create Thrall", "action, touch incapacitated humanoid, charmed until Remove Curse is cast, can communicate telepathically");
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
                result.ClassFeatures.Add("Invocations", "");
                msg = "Pick an new Invocation";
                var invocList = new List<string>();
                invocList.AddRange(Options.Invocations.Keys);

                for (int i = 0; i < invocations; i++)
                {
                    int index = CLIHelper.PrintChoices(msg, invocList);
                    string newInvoc = invocList[index];
                    invocList.Remove(newInvoc);
                    result.ClassFeatures.Add(newInvoc, Options.Invocations[newInvoc]);
                }
            }
            if (lvl >= 3)
            {
                msg = "Pick a Pact Boon to determine your class feature";
                var pactBoons = new List<string> { "Pact of the Chain", "Pact of the Blade", "Pact of the Tome" };
                int index = CLIHelper.PrintChoices(msg, pactBoons);

                if (index == 0)
                {
                    result.ClassFeatures.Add(pactBoons[0], "learn Find Familiar spell, can take special forms: Imp, Pseudodragon, Quasit, or Sprite - can forgo atk to have familiar atk");
                }
                else if (index == 1)
                {
                    result.ClassFeatures.Add(pactBoons[1], "action, create pact Blade that counts as magical");
                }
                else if (index == 2)
                {
                    result.ClassFeatures.Add(pactBoons[2], "pick 3 cantrips from any spell list");
                }
            }
            int mysticLvl = 5;
            for (int i = 11; i <= lvl; i++)
            {
                if (i % 2 != 0 && i <= 17)
                {
                    mysticLvl++;
                    result.ClassFeatures.Add($"Mystic Arcanum({mysticLvl}th)", "1/LR cast a warlock spell of this lvl");
                }
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Eldritch Master", "1/LR, spend 1 min to regain all spell slots");
            }
            //spells code
            string pickMsg = "Pick a cantrip.";
            string str2 = "You already have that cantrip.";
            int spellLvl = 1;
            AllSpells spells = new AllSpells();
            spells.Warlock[1].AddRange(ExpandedSpells[1]);
            spells.Warlock[2].AddRange(ExpandedSpells[2]);
            spells.Warlock[3].AddRange(ExpandedSpells[3]);
            spells.Warlock[4].AddRange(ExpandedSpells[4]);
            spells.Warlock[5].AddRange(ExpandedSpells[5]);

            for (int i = 0; i < result.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(WarlockSpells.Cantrips, result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            for (int i = 1; i <= result.SpellsKnown; i++)
            {
                if (4 >= i && i >= 10 && i % 2 == 0)
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
                string spell = CLIHelper.GetNew(spells.Warlock[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                result.Spells[spellLvl].Add(spell);
            }
            //end spells code

            return result;
        }
    }
}
