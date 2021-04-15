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
            { 5, new List<string>() }
        };
        public static AllSpells SorcSpells { get; set; } = new AllSpells("Sorcerer");
        public static List<string> Cantrips { get; set; } = new List<string>();
        public static Dictionary<int, List<string>> Spells { get; set; } = new Dictionary<int, List<string>>();
        public static CharacterClass Features(CharacterClass result, Character character)
        {
            int lvl = result.Lvl;
            result.ClassFeatures.Add("Spellcasting", "use Cha for spell DCs, you use an Arcane Focus as a spell focus");

            string msg = "Pick a Sorcerous Origin that will give you features at levels 1, 6, 14, and 18.";
            var archetypes = new List<string> { "Aberrant Mind", "Clockwork Soul", "Divine Soul", "Draconic Bloodline", "Phoenix", "Pyromancer",
                "Sea Sorcery", "Shadow Magic", "Stone Sorcery", "Storm Sorcery", "Wild Magic" };
            int archetype = CLIHelper.PrintChoices(msg, archetypes);
            SorcerousOrigin = archetypes[archetype];

            switch (SorcerousOrigin)
            {
                case "Aberrant Mind":
                    AberrantMind(character, result);
                    break;
                case "Clockwork Soul":
                    ClockworkSoul(character, result);
                    break;
                case "Divine Soul":
                    DivineSoul(character, result);
                    break;
                case "Draconic Bloodline":
                    DraconicBloodline(character, result);
                    break;
                case "Phoenix":
                    Phoenix(character, result);
                    break;
                case "Pyromancer":
                    Pyromancer(character, result);
                    break;
                case "Sea Sorcery":
                    SeaSorcery(character, result);
                    break;
                case "Shadow Magic":
                    ShadowMagic(character, result);
                    break;
                case "Stone Sorcery":
                    StoneSorcery(character, result);
                    break;
                case "Storm Sorcery":
                    StormSorcery(character, result);
                    break;
                case "Wild Magic":
                    WildMagic(character, result);
                    break;
            }

            int sorceryPts = lvl;
            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Font of Magic", $"you have {sorceryPts} sorcery pts and Flexible Casting" +
                    "\n        1st = 2pts" +
                    "\n        2nd = 3pts" +
                    "\n        3rd = 5pts" +
                    "\n        4th = 6pts" +
                    "\n        5th = 7pts");
            }
            string metamagic = "";
            var metamagicList = new List<string>();
            foreach (var item in Options.Metamagic.Keys)
            {
                metamagicList.Add(item);
            }
            if (lvl >= 3)
            {
                int options = 2;
                for (int i = 10; i <= lvl; i += 7)
                {
                    options++;
                }
                for (int i = 0; i < options; i++)
                {
                    if (i == 0)
                    {
                        msg = "You get 2 Metamagic options of your choice";
                    }
                    else
                    {
                        msg = "Pick a new Metamagic option";
                    }
                    metamagic = CLIHelper.PrintChoices(Options.Metamagic, metamagicList, msg);
                    metamagicList.Remove(metamagic);
                    result.ClassFeatures["Metamagic"] += $"\n        {metamagic}({Options.Metamagic[metamagic]})";
                }
            }
            if (lvl >= 4)
            {
                result.ClassFeatures.Add("Sorcerous Versatility", "When you get an Ability Score Improvement, you can replace a Metamagic option or Sorcerer cantrip");
            }
            if (lvl >= 5)
            {
                result.ClassFeatures.Add("Magical Guidance", "1 sorcery pt, when you fail a check, reroll the check, must use new roll");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Sorcerous Restoration", "gain 4 sorcery pt from SR");
            }
            AddSpells(character, result, Cantrips, Spells);
            return result;
        }
        public static void AberrantMind(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
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
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Psionic Sorcery", "sorcery pt = spell lvl, cast a Psionic Spell without V/S components");
                result.ClassFeatures.Add("Psychic Defenses", "gain adv vs charm/fear, gain Resistance to Psychic dmg");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Revelation in Flesh", "bonus, 10 min, sorcery pts = options - (see invisible creatures 60ft), (gain Hover and Fly speed)" +
                    "\n        (gain Swim speed = speed x 2), or (become slime - move through 1 inch spaces, spend 5ft movement to escape nonmagical restraints/grapples)");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Warping Implosion", "LR or 5 sorcery pts, action, 30ft(previous location), teleport 120ft, Str save, 3D10 Force dmg, pull to center");
            }
        }
        public static void ClockworkSoul(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
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
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Bastion of Law", "action, 1-5 sorcery pts, 30ft, 1 creature, gain sorcery pt dice, reduce dmg by # of dice expended");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Trance of Order", "LR or 5 sorcery pts, bonus, 1 min, atks against you can't have adv / atks, checks, saves below 10 are treated as 10s");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Clockwork Cavalcade", "LR or 7 sorcery pts, action, 30ft, restore up to 100 HP, repair damaged objects, end all 6th lvl or lower spells");
            }
        }
        public static void DivineSoul(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            Cantrips.AddRange(ClericSpells.Cantrips);
            AllSpells clericSpells = new AllSpells("Cleric");
            foreach (var item in clericSpells.Cleric.Keys)
            {
                Spells.Add(item, SorcSpells.Cleric[item]);
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
        }
        public static void DraconicBloodline(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            character.Languages.Add("Draconic");
            string msg = "Pick a color for your draconic ancestry";
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

            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Elemental Affinity", $"when you cast a {dmgType} dmg spell, dmg + Cha, spend 1 sorcery pt" +
                    $"\n        to gain Resistance to {dmgType} for 1 hr");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Dragon Wings", "bonus, sprout wings with fly speed = land speed");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Draconic Presence", "action, 5 sorcery pts, 60ft, Wis save or fear");
            }
        }
        public static void Phoenix(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            result.ClassFeatures.Add("Ignite", "magically start a fire by touching a flammable object");
            result.ClassFeatures.Add("Mantle of Flame", "LR, bonus, 1 min, bright light 30ft/dim light 30ft, if hit by melee - Cha Fire dmg, Fire spells dmg + Cha");
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Phoenix Spark", "LR, reaction, 10ft, when you drop to 0 HP drop to 1 instead, deal Fire dmg = 1/2 lvl + Cha" +
                    "\n        if using Mantle of Flame when you activate - Fire dmg = lvl + Cha x 2 instead");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Nourishing Fire", "when you cast a Fire dmg spell, gain HP = spell lvl + Cha");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Form of the Phoenix", "gain Fly 40ft, gain Resistance to all dmg, Phoenix Spark dmg + 20");
            }
        }
        public static void Pyromancer(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
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
        }
        public static void SeaSorcery(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            result.ClassFeatures.Add("Soul of the Sea", "gain Swim speed and waterbreathing");
            result.ClassFeatures.Add("Curse of the Sea", "on cantrip hit - mark target, when you cast Cold or Lightning dmg spell or a spell that forces movement, gain extra benefit" +
                "\n        Cold dmg(reduce target speed by 15ft), Lightning dmg(dmg + Cha), forced movement(increase dist by 15ft)");
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Watery Defense", "SR, when hit by B/P/S, reduce dmg by Cha and move 30ft without atk op");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Shifting Form", "can move through enemies, gain Resistance to dmg from atk op, move through 3 inch space");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Water Soul", "don't need to eat, drink, or sleep / negate crits / gain Resistance to B/P/S");
            }
        }
        public static void ShadowMagic(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            result.ClassFeatures.Add("Eyes of the Dark", "gain Superior Darkvision 120ft");
            result.ClassFeatures.Add("Strength of the Grave", "LR, if you drop to 0 HP, Cha save(DC 5 + dmg), drop to 1 HP - can't be used if dmg is Radiant or a crit");
            if (lvl >= 3)
            {
                result.Spells[2].Add("Darkness");
                result.ClassFeatures["Eyes of the Dark"] += ", cast Darkness for 2 sorcery pt - if so, you can see through the darkness";
            }
            if (lvl >= 6)
            {
                result.ClassFeatures.Add("Hound of Ill Omen", "bonus, 120ft, 1 target, 3 sorcery pts, as Dire Wolf except its a Monstrosity, temp HP = 1/2 lvl" +
                    "\n        it can move through creatures and objects as difficult terrain, auto-knows location of target (negates hiding)" +
                    "\n        target has disadv vs your spells if hound is adj");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Shadow Walk", "bonus, in dim light or darkness, teleport 120ft into dim light or darkness");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Umbral Form", "bonus, 1 min, 6 sorcery pts, gain Resistance to all dmg except Radiant, move through creatures and objects as difficult terrain");
            }
        }
        public static void StoneSorcery(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
            ExpandedSpells[1].Add("Compelled Duel");
            ExpandedSpells[1].Add("Searing Smite");
            ExpandedSpells[1].Add("Thunderous Smite");
            ExpandedSpells[1].Add("Wrathful Smite");
            ExpandedSpells[2].Add("Branding Smite");
            ExpandedSpells[2].Add("Magic Weapon");
            ExpandedSpells[3].Add("Blinding Smite");
            ExpandedSpells[3].Add("Elemental Weapon");
            ExpandedSpells[4].Add("Staggering Smite");
            result.Proficiencies.Add("Shields");
            result.Proficiencies.Add("Simple weapons");
            result.Proficiencies.Add("Martial weapons");
            result.ClassFeatures.Add("Stone's Durability", "increase HP by 1 per lvl, AC = 13 + Dex");
            character.HP += lvl;
            if (lvl >= 6)
            {
                int dmg = 1;
                for (int i = 11; i <= lvl; i += 6)
                {
                    dmg++;
                }
                result.ClassFeatures.Add("Stone Aegis", "bonus, 60ft, 1 min, 1 ally, reduce B/P/S dmg by 2 + 1/4 lvl" +
                    $"\n        reaction, when ally is hit, teleport adj and make melee atk, dmg = {dmg}D10 Force");
            }
            if (lvl >= 14)
            {
                result.ClassFeatures.Add("Stone's Edge", "1/spell, 1 creature, dmg + 1/2 lvl Force");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Stone Master's Aegis", "give Stone Aegis benefits to 3 allies");
            }
        }
        public static void StormSorcery(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
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
                    "\n        SR - action, 1 hr, 30ft, 3 + Cha creatures, reduce fly speed to 30ft to give fly speed (30ft) to allies");
                character.Speedstring = ", Fly 60ft";
            }
        }
        public static void WildMagic(Character character, CharacterClass result)
        {
            int lvl = character.Lvl;
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
        }
        public static void AddSpells(Character character, CharacterClass result, List<string> cantrips, Dictionary<int, List<string>> spells)
        {
            int lvl = character.Lvl;
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
            foreach (var item in SorcSpells.Sorcerer.Keys)
            {
                spells.Add(item, SorcSpells.Sorcerer[item]);
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
        }
    }
}
