using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class SorcererSpecifics
    {
        public static string SorcerousOrigin { get; set; }
        public static Dictionary<int, List<string>> ExpandedSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 0, new List<string>() },
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
        };
        public static CharacterClass Features(CharacterClass result, Character character)
        {
            int lvl = result.Lvl;
            result.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use an Arcane Focus as a spell focus");
            var cantrips = new List<string>();
            AllSpells sorcSpells = new AllSpells(character.ChosenClass);
            var spells = new Dictionary<int, List<string>>();

            string msg = "Pick a Sorcerous Origin that will give you features at levels 1, 6, 14, and 18.";
            var archetypes = new List<string> { "Aberrant Mind*", "Clockwork Soul*", "Divine Soul", "Draconic Bloodline", "Pyromancer",
                "Shadow Magic", "Storm Sorcery", "Wild Magic" };
            //"Phoenix*", "Sea Sorcery*", "Stone Sorcery*", 
            int archetype = CLIHelper.PrintChoices(msg, archetypes);
            SorcerousOrigin = archetypes[archetype];

            switch (SorcerousOrigin)
            {
                case "Aberrant Mind":
                    ExpandedSpells[0].Add("Mind Sliver");
                    ExpandedSpells[1].Add("Arms of Hadar");
                    ExpandedSpells[1].Add("Dissonant Whispers");
                    ExpandedSpells[2].Add("Calm Emotions");
                    ExpandedSpells[2].Add("Detect Thoughts");
                    ExpandedSpells[3].Add("Hunger of Hadar");
                    ExpandedSpells[3].Add("Sending");
                    ExpandedSpells[4].Add("Evard's Black Tentacles");
                    ExpandedSpells[4].Add("Summon Aberration");
                    ExpandedSpells[5].Add("Rary's Telepathic Bond");
                    ExpandedSpells[5].Add("Telekinesis");

                    result.ClassFeatures.Add("Psionic Spells", "your spell list gains additional spells based on your lvl");
                    result.ClassFeatures.Add("Telepathic Speech", "bonus, lvl min, 30ft, 1 creature, speak telepathically from Cha miles");
                    //if (lvl >= 6)
                    //{
                    //    result.ClassFeatures.Add("", "");
                    //}
                    //if (lvl >= 14)
                    //{
                    //    result.ClassFeatures.Add("", "");
                    //}
                    //if (lvl >= 18)
                    //{
                    //    result.ClassFeatures.Add("", "");
                    //}
                    break;
                case "Clockwork Soul":
                    ExpandedSpells[1].Add("Alarm");
                    ExpandedSpells[1].Add("Protection from Evil and Good");
                    ExpandedSpells[2].Add("Aid");
                    ExpandedSpells[2].Add("Lesser Restoration");
                    ExpandedSpells[3].Add("Dispel Magic");
                    ExpandedSpells[3].Add("Protection from Energy");
                    ExpandedSpells[4].Add("Freedom of Movement");
                    ExpandedSpells[4].Add("Summon Construct");
                    ExpandedSpells[5].Add("Greater Restoration");
                    ExpandedSpells[5].Add("Wall of Force");

                    result.ClassFeatures.Add("Clockwork Magic", "your spell list gains additional spells based on your lvl");
                    result.ClassFeatures.Add("Restore Balance", "PB/LR, reaction, 60ft, when a creature rolls with adv or disadv - negate the adv or disadv");
                    //if (lvl >= 6)
                    //{
                    //    result.ClassFeatures.Add("", "");
                    //}
                    //if (lvl >= 14)
                    //{
                    //    result.ClassFeatures.Add("", "");
                    //}
                    //if (lvl >= 18)
                    //{
                    //    result.ClassFeatures.Add("", "");
                    //}
                    break;
                case "Divine Soul":
                    cantrips.AddRange(ClericSpells.Cantrips);
                    AllSpells clericSpells = new AllSpells("Cleric");
                    foreach (var item in clericSpells.Cleric.Keys)
                    {
                        spells.Add(item, sorcSpells.Cleric[item]);
                    }
                    var affinity = new List<string> { "Good", "Evil", "Law", "Chaos", "Neutrality" };
                    Console.WriteLine("Pick an affinity to an alignment that is the source of your divine power");
                    string alignment = CLIHelper.PrintChoices(affinity);
                    string wingType = "";
                    switch (alignment)
                    {
                        case "Good":
                            result.Spells[1].Add("Cure Wounds");
                            wingType = "eagle";
                            break;
                        case "Evil":
                            result.Spells[1].Add("Inflict Wounds");
                            wingType = "bat";
                            break;
                        case "Law":
                            result.Spells[1].Add("Bless");
                            wingType = "eagle";
                            break;
                        case "Chaos":
                            result.Spells[1].Add("Bane");
                            wingType = "bat";
                            break;
                        case "Neutrality":
                            result.Spells[1].Add("Protection from Evil and Good");
                            wingType = "dragonfly";
                            break;
                    }
                    result.ClassFeatures.Add("Divine Magic", "gain access to the Cleric spell list");
                    result.ClassFeatures.Add("Favored by the Gods", "SR, if you fail a save or miss an atk, +2D4 to the save or atk");
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Empowered Healing", "1/turn, 1 sorcery pt, when you or adj ally rolls to recover HP, reroll the dice once");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Otherworldly Wings", $"bonus, manifest spectral {wingType} wings, gain Fly speed 30ft");
                        if (!character.Speedstring.Contains("Fly"))
                        {
                            character.Speedstring += ", Fly 30ft";
                        }
                    }
                    if (lvl >= 18)
                    {
                        result.ClassFeatures.Add("Unearthly Recovery", "LR, bonus, when bloodied, regain HP = 1/2 max HP");
                    }
                    break;
                case "Draconic Bloodline":
                    character.Languages.Add("Draconic");
                    msg = "Pick a color for your draconic ancestry";
                    List<string> colorList = new List<string> { "Black", "Blue", "Brass", "Bronze", "Copper", "Gold", "Green",
                        "Red", "Silver", "White" };
                    int index = CLIHelper.PrintChoices(msg, colorList);
                    string color = colorList[index];
                    string dmgType = "";

                    if (color == "Black" || color == "Copper")
                    {
                        dmgType = "Acid";
                    }
                    else if (color == "Blue" || color == "Bronze")
                    {
                        dmgType = "Lightning";
                    }
                    else if (color == "Brass")
                    {
                        dmgType = "Fire";
                    }
                    else if (color == "Gold" || color == "Red")
                    {
                        dmgType = "Fire";
                    }
                    else if (color == "Green")
                    {
                        dmgType = "Poison";
                    }
                    else if (color == "Silver" || color == "White")
                    {
                        dmgType = "Cold";
                    }
                    result.ClassFeatures.Add("Dragon Ancestor", $"double PB on Cha checks when interacting with {color} Dragons");
                    result.ClassFeatures.Add("Draconic Resilience", "increase HP by 1 per lvl, AC = 13 + Dex");
                    character.HP += lvl;
                    character.AC += 3;

                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Elemental Affinity", $"when you cast a spell that deals {dmgType} dmg, add Cha to dmg, spend 1 sorcery pt" +
                            $"\nto gain Resistance to {dmgType} for 1 hr");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Dragon Wings", "bonus, sprout wings with fly speed = land speed");
                    }
                    if (lvl >= 18)
                    {
                        result.ClassFeatures.Add("Draconic Presence", "action, 5 sorcery pts, 60ft, Wis save or fear");
                    }
                    break;
                case "Pyromancer":
                    result.ClassFeatures.Add("Heart of Fire", "when you cast a fire dmg spell, 10ft, creatures of your choice, fire dmg = 1/2 lvl");
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Fire in the Veins", "gain Resistance to Fire, your spells ignore Fire Resistance");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Pyromancer's Fury", "reaction, when hit by melee, Fire dmg = lvl, ignores Fire Resistance");
                    }
                    if (lvl >= 18)
                    {
                        result.ClassFeatures.Add("Fiery Soul", "gain Immunity to Fire, all spells and effects ignore Fire Resistance and treat Immunity as Resistance");
                    }
                    break;
                case "Shadow Magic":
                    result.ClassFeatures.Add("Eyes of the Dark", "gain Superior Darkvision 120ft");
                    result.ClassFeatures.Add("Strength of the Grave", "LR, if you drop to 0 HP, Cha save(DC 5 + dmg), drop to 1 HP - can't be used if dmg is Radiant or a crit");
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Hound of Ill Omen", "bonus, 120ft, 1 target, 3 sorcery pts, as Dire Wolf except its a Monstrosity, temp HP = 1/2 lvl" +
                            "\nit can move through creatures and objects as difficult terrain, auto-knows location of target (negates hiding)" +
                            "\ntarget has disadv vs your spells if hound is adj");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Shadow Walk", "bonus, in dim light or darkness, teleport 120ft into dim light or darkness");
                    }
                    if (lvl >= 18)
                    {
                        result.ClassFeatures.Add("Umbral Form", "bonus, 1 min, 6 sorcery pts, gain Resistance to all dmg except Radiant, move through creatures and objects as difficult terrain");
                    }
                    break;
                case "Storm Sorcery":
                    character.Languages.Add("Primordial");
                    result.ClassFeatures.Add("Tempestous Magic", "bonus, after you cast non-cantrip, fly 10ft no atk op");
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Heart of the Storm", "gain Resistance to Lightning and Thunder, after you cast non-cantrip, 10ft, 1/2 lvl Lightning or Thunder dmg");
                        result.ClassFeatures.Add("Storm Guide", "action, 20ft, stop rain around you / bonus, 1 turn, 100ft, choose direction of the wind");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Storm's Fury", "reaction, when hit by melee, Lightning dmg = lvl, Str save, push 20ft");
                    }
                    if (lvl >= 18)
                    {
                        result.ClassFeatures.Add("Wind Soul", "gain Immunity to Lightning and Thunder, gain fly speed" +
                            "\nSR - action, 1 hr, 30ft, 3 + Cha creatures, reduce fly speed to 30ft to give fly speed (30ft) to allies");
                        character.Speedstring = ", Fly 60ft";
                    }
                    break;
                case "Wild Magic":
                    result.ClassFeatures.Add("Wild Surge", "after casting a spell, roll D20 if its 1 - roll on Wild Magic table");
                    result.ClassFeatures.Add("Tides of Chaos", "1/LR, gain adv on atk, save, check - before regaining use roll on Wild Magic table to regain use");
                    if (lvl >= 6)
                    {
                        result.ClassFeatures.Add("Bend Luck", "reaction, 2 sorcery pt, +/- 1D4 to atk, save, check of enemy or ally you can see");
                    }
                    if (lvl >= 14)
                    {
                        result.ClassFeatures.Add("Controlled Chaos", "when you roll on Wild Magic table roll twice and use either result");
                    }
                    if (lvl >= 18)
                    {
                        result.ClassFeatures.Add("Spell Bombardment", "1/turn when you roll max on a die, reroll it and add both results");
                    }
                    break;
            }

            int sorceryPts = lvl;
            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Font of Magic", $"you have {sorceryPts} sorcery pts and Flexible Casting" +
                    "\n1st = 2pts" +
                    "\n2nd = 3pts" +
                    "\n3rd = 5pts" +
                    "\n4th = 6pts" +
                    "\n5th = 7pts");
            }
            string metamagic = "";
            var metamagicList = new List<string>();
            foreach (var item in Options.Metamagic.Keys)
            {
                metamagicList.Add(item);
            }
            if (lvl >= 3)
            {
                msg = "You get 2 metamagic options of your choice";
                metamagic = CLIHelper.PrintChoices(Options.Metamagic, metamagicList, msg);
                metamagicList.Remove(metamagic);
                string metamagic1 = CLIHelper.PrintChoices(Options.Metamagic, metamagicList, msg);
                metamagicList.Remove(metamagic1);
                result.ClassFeatures.Add("Metamagic", $"{metamagic}({Options.Metamagic[metamagic]})" +
                    $"\n{metamagic1}({Options.Metamagic[metamagic1]})");
                if (archetypes[archetype] == "Shadow Magic")
                {
                    result.Spells[2].Add("Darkness");
                    result.ClassFeatures["Eyes of the Dark"] += ", cast Darkness for 2 sorcery pt - if so, you can see through the darkness";
                }
            }
            if (lvl >= 4)
            {
                result.ClassFeatures.Add("Sorcerous Versatility", "When you get an Ability Score Improvement, you can replace a Metamagic option or Sorcerer cantrip");
            }
            if (lvl >= 3)
            {
                result.ClassFeatures.Add("Magical Guidance", "1 sorcery pt, when you fail a check, reroll the check, must use new roll");
            }
            if (lvl >= 10)
            {
                msg = "Pick a new metamagic option";
                metamagic = CLIHelper.PrintChoices(Options.Metamagic, metamagicList, msg);
                metamagicList.Remove(metamagic);
                result.ClassFeatures["Metamagic"] += $"\n{metamagic}({Options.Metamagic[metamagic]})";
            }
            if (lvl >= 17)
            {
                msg = "Pick a new metamagic option";
                metamagic = CLIHelper.PrintChoices(Options.Metamagic, metamagicList, msg);
                result.ClassFeatures["Metamagic"] += $"\n{metamagic}({Options.Metamagic[metamagic]})";
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Sorcerous Restoration", "gain 4 sorcery pt from SR");
            }
            //spells code - some parts are moved up to the top due to the divine soul archetype
            string pickMsg = "Pick a cantrip.";
            string str2 = "You already have that cantrip.";
            cantrips.AddRange(SorcererSpells.Cantrips); //modification
            if (SorcerousOrigin == "Aberrant Mind")
            {
                cantrips.AddRange(ExpandedSpells[0]);
            }
            for (int i = 0; i < result.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(cantrips, result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            int spellLvl = 1;
            //AllSpells spells = new AllSpells(character.ChosenClass); moved to top
            foreach (var item in sorcSpells.Sorcerer.Keys)
            {
                spells.Add(item, sorcSpells.Sorcerer[item]);
            }
            if (SorcerousOrigin == "Aberrant Mind" || SorcerousOrigin == "Clockwork Soul")
            {
                for (int i = 1; i < 6; i++)
                {
                    spells[i].AddRange(ExpandedSpells[i]);
                    spells[i].Sort();
                }
            }
            for (int i = 1; i <= result.SpellsKnown; i++)
            {
                if (4 >= i && i >= 14 && i % 2 == 0)
                {
                    spellLvl++;
                }
                if (i == 13 || i == 15)
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
                string spell = CLIHelper.GetNew(spells[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                result.Spells[spellLvl].Add(spell);
                spells[spellLvl].Remove(spell);
            }
            //end spells code

            return result;
        }
    }
}
