using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class ClericSpecifics
    {
        public static string DivineDomain { get; set; }
        public static Dictionary<int, List<string>> DomainSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
        };
        public static CharacterClass Features(CharacterClass result, Character character)
        {
            int lvl = result.Lvl;

            string msg = "Pick a Divine Domain that will give you features at levels 2, 6, 8, and 17.";
            var archetype = new List<string> { "Ice", "Knowledge", "Life", "Light", "Nature", "Tempest", "Trickery", "War" };
            int input = CLIHelper.PrintChoices(msg, archetype);

            if (input == 0)
            {
                DivineDomain = archetype[0];
                DomainSpells[1].Add("Fog Cloud*");
                DomainSpells[1].Add("Ice Knife*");
                DomainSpells[2].Add("Gust of Wind*");
                DomainSpells[2].Add("Misty Step*");
                DomainSpells[3].Add("Tidal Wave*");
                DomainSpells[3].Add("Wall of Water*");
                DomainSpells[4].Add("Ice Storm*");
                DomainSpells[4].Add("Watery Sphere*");
                DomainSpells[5].Add("Cone of Cold*");
                DomainSpells[5].Add("Maelstrom*");
                result.ClassFeatures.Add("Disciple of Water", "Waterbreathing, Swim 30ft, communicate basic ideas with sea creatures");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("Call Sea Creatures", "total CR = 1/2 cleric lvl");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Fluid Movement", "reaction, +1D8 to AC");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 cold dmg");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 cold dmg";
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("Torrent of Water", "1/LR, cast Tsunami");
                }
            }
            else if (input == 1)
            {
                DivineDomain = archetype[1];
                DomainSpells[1].Add("Command*");
                DomainSpells[1].Add("Identify*");
                DomainSpells[2].Add("Augury*");
                DomainSpells[2].Add("Suggestion*");
                DomainSpells[3].Add("Nondetection*");
                DomainSpells[3].Add("Speak with Dead*");
                DomainSpells[4].Add("Arcane Eye*");
                DomainSpells[4].Add("Confusion*");
                DomainSpells[5].Add("Legend Lore*");
                DomainSpells[5].Add("Scrying*");
                result.ClassFeatures.Add("Blessings of Knowledge", "gain 2 languages and 2 skills");

                var skills = new List<string> { "Arcana", "History", "Nature", "Religion" };
                Console.WriteLine($"Clerics of Knowledge gain 2 languages and 2 skills from: {String.Join(", ", skills)}");
                string msg1 = "Pick the 1st language now";
                string errorMsg = "You already have that language, try again.";
                string firstLanguage = CLIHelper.GetNew(Options.Languages, character.Languages, msg, errorMsg);
                character.Languages.Add(firstLanguage);
                msg1 = "Pick the 2nd language now";
                string secondLanguage = CLIHelper.GetNew(Options.Languages, character.Languages, msg, errorMsg);
                character.Languages.Add(secondLanguage);
                msg1 = "Pick the 1st skill now";
                errorMsg = "You are already trained in that skill, pick a different skill.";
                string firstSkill = CLIHelper.GetNew(skills, character.SkillProficiencies, msg1, errorMsg);
                character.SkillProficiencies.Add(firstSkill);
                msg1 = "Pick the 2nd skill now";
                string secondSkill = CLIHelper.GetNew(skills, character.SkillProficiencies, msg1, errorMsg);
                character.SkillProficiencies.Add(secondSkill);


                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("Channel Divinity(Knowledge of the Ages)", "gain prof in 1 skill or tool for 10min");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Channel Divinity(Read Thoughts)", "action, 1/LR, 60ft, Wis save, 1 min - read surface thoughts, auto-fail for Suggestion spell");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("Potent Spellcasting", "cantrip dmg + Wis");
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("Visions of the Past", "1/SR, meditate for 1 min - Object reading: see visions of previous owner," +
                        "\nArea Reading: see visions of recent or significant events");
                }
            }
            else if (input == 2)
            {
                DivineDomain = archetype[2];
                DomainSpells[1].Add("Bless*");
                DomainSpells[1].Add("Cure Wounds*");
                DomainSpells[2].Add("Lesser Restoration*");
                DomainSpells[2].Add("Spiritual Weapon*");
                DomainSpells[3].Add("Beacon of Hope*");
                DomainSpells[3].Add("Revivify*");
                DomainSpells[4].Add("Death Ward*");
                DomainSpells[4].Add("Guardian of Faith*");
                DomainSpells[5].Add("Mass Cure Wounds*");
                DomainSpells[5].Add("Raise Dead*");
                character.Proficiencies.Add("Heavy Armor");
                result.ClassFeatures.Add("Disciple of Life", "healing spells heal extra 2 + spell lvl HP");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("Channel Divinity(Preserve Life)", "action, 30ft, heal lvl x 5 HP, can't go above bloody value, can divide among creatures");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Blessed Healer", "when you cast healing spell, heal yourself 2 + spell lvl HP");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 radiant dmg");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 radiant dmg";
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("Supreme Healing", "max all healing dice rolls");
                }
            }
            if (input == 3)
            {
                DivineDomain = archetype[3];
                DomainSpells[1].Add("Burning Hands*");
                DomainSpells[1].Add("Faerie Fire*");
                DomainSpells[2].Add("Flaming Sphere*");
                DomainSpells[2].Add("Scorching Ray*");
                DomainSpells[3].Add("Daylight*");
                DomainSpells[3].Add("Fireball*");
                DomainSpells[4].Add("Guardian of Faith*");
                DomainSpells[4].Add("Wall of Fire*");
                DomainSpells[5].Add("Flame Strike*");
                DomainSpells[5].Add("Scrying*");
                character.Cantrips.Add("Light");
                result.ClassFeatures.Add("Warding Flare", "Wis/LR, reaction, 30ft, impose disadv, attacker can't be immune to blinding");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("Channel Divinity(Radiance of Dawn)", "action, 30ft, Con save, 2D10 + lvl radiant dmg, dispel magical darkness");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Improved Flare", "you can use Warding Flare when an ally is attacked");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("Potent Spellcasting", "dmg + Wis with cantrips");
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("Corona of Light", "action, 1 min, bright light 60ft, disadv on saves vs fire or radiant dmg");
                }
            }
            else if (input == 4)
            {
                DivineDomain = archetype[4];
                DomainSpells[1].Add("Animal Friendship*");
                DomainSpells[1].Add("Speak with Animals*");
                DomainSpells[2].Add("Barkskin*");
                DomainSpells[2].Add("Spike Growth*");
                DomainSpells[3].Add("Plant Growth*");
                DomainSpells[3].Add("Wind Wall*");
                DomainSpells[4].Add("Dominate Beast*");
                DomainSpells[4].Add("Grasping Vine*");
                DomainSpells[5].Add("Insect Plague*");
                DomainSpells[5].Add("Tree Stride*");
                msg = "Pick a Druid cantrip";
                int index = CLIHelper.PrintChoices(msg, DruidSpells.Cantrips);
                string druidCantrip = DruidSpells.Cantrips[index];
                character.Cantrips.Add(druidCantrip);
                var list = new List<string> { "Animal Handling", "Nature", "Survival" };
                msg = "Pick a skill from the list";
                string errorMsg = "You already know that skill";
                string skill = CLIHelper.GetNew(list, character.SkillProficiencies, msg, errorMsg);
                character.SkillProficiencies.Add(skill);
                character.Proficiencies.Add("Heavy Armor");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("Channel Divinity(Charm Animals and Plants)", "action, 30ft, Wis save, charm 1 min");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Dampen Elements", "reaction, when you or ally within 30ft takes cold, fire, or lighting dmg - gain Resistance");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 cold, fire, or lightning dmg");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 cold, fire, or lightning dmg";
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("Master of Nature", "bonus, command creatures charmed by your Channel Divinity");
                }
            }
            else if (input == 5)
            {
                DivineDomain = archetype[5];
                DomainSpells[1].Add("Fog Cloud*");
                DomainSpells[1].Add("Thunderwave*");
                DomainSpells[2].Add("Gust of Wind*");
                DomainSpells[2].Add("Shatter*");
                DomainSpells[3].Add("Call Lightning*");
                DomainSpells[3].Add("Thunder Step*");
                DomainSpells[4].Add("Lightning Bolt*");
                DomainSpells[4].Add("Storm Sphere*");
                DomainSpells[5].Add("Control Winds*");
                DomainSpells[5].Add("Destructive Wave*");
                result.ClassFeatures.Add("Wrath of the Storm", "Wis/LR, reaction, Dex save, deal 2D8 lightning or thunder dmg");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("Channel Divinity(Destructive Wrath)", "max lightning or thunder dmg");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Thunderbolt Strike", "when you deal lightning dmg, push 10ft");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 thunder dmg");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 thunder dmg";
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("Stormborn", "gain fly speed = land speed when not underground or indoors");
                }
            }
            if (input == 6)
            {
                DivineDomain = archetype[6];
                DomainSpells[1].Add("Charm Person*");
                DomainSpells[1].Add("Disguise Self*");
                DomainSpells[2].Add("Mirror Image*");
                DomainSpells[2].Add("Pass Without Trace*");
                DomainSpells[3].Add("Blink*");
                DomainSpells[3].Add("Dispel Magic*");
                DomainSpells[4].Add("Dimension Door*");
                DomainSpells[4].Add("Polymorph*");
                DomainSpells[5].Add("Dominate Person*");
                DomainSpells[5].Add("Modify Memory*");
                result.ClassFeatures.Add("Blessing of the Trickster", "action, give ally adv on Stealth for 1 hr");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("Channel Divinity(Invoke Duplicity)", "action, conc 1 min, 30ft, create illusory double, bonus to move it 30ft" +
                        "\nit must remain within 120ft, if you and double are within 5ft of target you gain adv on atks");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Channel Divinity(Cloak of Shadows)", "action, become invisible");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 poison dmg");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 poison dmg";
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("Improved Duplicity", "create 4 copies instead of 1, bonus to move any number of them");
                }
            }
            else if (input == 7)
            {
                DivineDomain = archetype[7];
                DomainSpells[1].Add("Divine Favor*");
                DomainSpells[1].Add("Shield of Faith*");
                DomainSpells[2].Add("Magic Weapon*");
                DomainSpells[2].Add("Spiritual Weapon*");
                DomainSpells[3].Add("Crusader's Mantle*");
                DomainSpells[3].Add("Spirit Guardians*");
                DomainSpells[4].Add("Freedom of Movement*");
                DomainSpells[4].Add("Stoneskin*");
                DomainSpells[5].Add("Flame Strike*");
                DomainSpells[5].Add("Hold Monster*");
                character.Proficiencies.Add("Heavy Armor");
                character.Proficiencies.Add("Martial Weapons");
                result.ClassFeatures.Add("War Priest", "Wis/LR, atk as bonus");

                if (lvl >= 2)
                {
                    result.ClassFeatures.Add("Channel Divinity(Guided Strike)", "+10 atk, after roll");
                }
                if (lvl >= 6)
                {
                    result.ClassFeatures.Add("Channel Divinity(War God's Blessing)", "reaction, 30ft, give ally +10 atk");
                }
                if (lvl >= 8)
                {
                    result.ClassFeatures.Add("Divine Strike", "1/turn, +1D8 weapon dmg");
                }
                if (lvl >= 14)
                {
                    result.ClassFeatures["Divine Strike"] = "1/turn, +2D8 weapon dmg";
                }
                if (lvl >= 17)
                {
                    result.ClassFeatures.Add("Avatar of Battle", "gain Resistance to Bludgeoning, Piercing, Slashing from nonmagical weapons");
                }
            }
            result.Spells[1].AddRange(DomainSpells[1]);

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Channel Divinity(Turn Undead)", "1/SR, action, 30ft, Wis save - turn 1 min");
            }
            if (lvl >= 3)
            {
                result.Spells[1].AddRange(DomainSpells[2]);
            }
            if (lvl >= 5)
            {
                result.Spells[1].AddRange(DomainSpells[3]);
                int CR = 0;
                result.ClassFeatures.Add("Destroy Undead", "CR under 1/2 that fail against Turn Undead are instantly destroyed");
                for (int i = 8; i <= lvl ; i += 3)
                {
                    CR++;
                    result.ClassFeatures["Destroy Undead"] = $"CR under {CR} that fail against Turn Undead are instantly destroyed";
                }
            }
            if (lvl >= 6)
            {
                result.ClassFeatures["Channel Divinity(Turn Undead)"] = "2/SR, action, 30ft, Wis save - turn 1 min";
            }
            if (lvl >= 7)
            {
                result.Spells[1].AddRange(DomainSpells[4]);
            }
            if (lvl >= 9)
            {
                result.Spells[1].AddRange(DomainSpells[5]);
            }
            if (lvl >= 10)
            {
                result.ClassFeatures.Add("Divine Intervention", "if % dice roll <= lvl, DM decides nature of intervention, recharge 7 days, retry LR");
            }
            if (lvl >= 18)
            {
                result.ClassFeatures["Channel Divinity(Turn Undead)"] = "3/SR, action, 30ft, Wis save - turn 1 min";
            }
            if (lvl >= 20)
            {
                result.ClassFeatures["Divine Intervention"] = "automatically succeed, DM decides nature of intervention";
            }
            //spells code
            string pickMsg = "Pick a cantrip.";
            string str2 = "You already have that cantrip.";
            int spellLvl = 1;
            AllSpells spells = new AllSpells();
            for (int i = 0; i < result.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(ClericSpells.Cantrips, result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
            }
            str2 = "You already have that spell";
            pickMsg = "Pick a 1st level spell.";
            for (int i = 1; i <= lvl; i++)
            {
                if (i % 2 != 0)
                {
                    if (3 <= i && i <= 17)
                    {
                        spellLvl++;
                    }
                    if (i == 3)
                    {
                        pickMsg = "Pick a 2nd level spell.";
                    }
                    if (i == 5)
                    {
                        pickMsg = "Pick a 3rd level spell.";
                    }
                    if (i >= 7)
                    {
                        pickMsg = $"Pick a {spellLvl}th level spell.";
                    }
                    if (lvl <= 5)
                    {
                        string spell2 = CLIHelper.GetNew(spells.Cleric[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                        result.Spells[spellLvl].Add(spell2);
                    }
                    if (lvl >= 13)
                    {
                        string spell2 = CLIHelper.GetNew(spells.Cleric[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                        result.Spells[spellLvl].Add(spell2);
                    }
                }
                if (lvl <= 11)
                {
                    string spell = CLIHelper.GetNew(spells.Cleric[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                    result.Spells[spellLvl].Add(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
