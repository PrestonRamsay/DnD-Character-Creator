using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class DruidSpecifics
    {
        public static string DruidCircle { get; set; }
        public static Dictionary<int, List<string>> CircleSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
        };
        public static CharacterClass Features(CharacterClass result, Character character)
        {
            int lvl = result.Lvl;

            result.ClassFeatures.Add("Druidic","DC 15 to spot a message");
            character.Languages.Add("Druidic");
            result.ClassFeatures.Add("Spellcasting", "use Wis for spell DCs, you use a Druidic Focus as a spell focus");

            if (lvl >= 2)
            {
                result.ClassFeatures.Add("Wild Shape", "2/SR, duration = 1/2 lvl hr, max CR 1/4 - no swimming or flying");
                result.ClassFeatures.Add("Wild Companion", "action, hr = 1/2 lvl, expend a Wild Shape use, cast Find Familiar, familiar is a Fey");
                string msg = "Pick a Druid Circle that will give you features at levels 2, 6, 10, and 14.";
                var archetypes = new List<string> { "Circle of Dreams", "Circle of the Land", "Circle of the Moon", "Circle of the Shepherd",
                    "Circle of Spores*", "Circle of Stars*", "Circle of Wildfire*" };
                int input = CLIHelper.PrintChoices(msg, archetypes);

                if (input == 1 || input == 2 || input == 3)
                {
                    DruidCircle = archetypes[input].Substring(13);
                }
                else
                {
                    DruidCircle = archetypes[input].Substring(9);
                }

                switch (DruidCircle)
                {
                    case "Dreams":
                        result.ClassFeatures.Add("Balm of the Summer Court", "LR, bonus, 120ft, one creature, # of D6 = lvl, spend up to 1/2 lvl to heal #D6 + # temp HP");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Hearth of Moonlight and Shadow", "30ft, during rest +5 on Stealth and Perception and no light escapes ");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Hidden Paths", "Wis/LR, bonus, teleport 60ft or action, teleport an ally 30ft");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Walker in Dreams", "LR, after SR, cast Dream(you as messenger), Scrying, or Teleportation Circle(opens a portal to the last place you took LR)");
                        }
                        break;
                    case "Land":
                        msg = "Pick a cantrip.";
                        string str = "You already have that cantrip.";
                        string cantrip = CLIHelper.GetNew(DruidSpells.Cantrips, result.Cantrips, msg, str);
                        result.Cantrips.Add(cantrip);
                        result.ClassFeatures.Add("Natural Recovery", "during SR, regain spell slots = 1/2 lvl, can't be 6th lvl or higher");
                        var lands = new List<string> { "Arctic", "Coast", "Desert", "Forest", "Grassland", "Mountain", "Swamp", "Underdark" };
                        msg = "Pick a land where you became a Druid to determine your Circle spells";
                        int index = CLIHelper.PrintChoices(msg, lands);

                        if (index == 0)
                        {
                            CircleSpells[2].Add("Hold Person*");
                            CircleSpells[2].Add("Spike Growth*");
                            CircleSpells[3].Add("Sleet Storm*");
                            CircleSpells[3].Add("Slow*");
                            CircleSpells[4].Add("Freedom of Movement*");
                            CircleSpells[4].Add("Ice Storm*");
                            CircleSpells[5].Add("Commune with Nature*");
                            CircleSpells[5].Add("Cone of Cold*");
                        }
                        else if (index == 1)
                        {
                            CircleSpells[2].Add("Mirror Image*");
                            CircleSpells[2].Add("Misty Step*");
                            CircleSpells[3].Add("Waterbreathing*");
                            CircleSpells[3].Add("Waterwalk*");
                            CircleSpells[4].Add("Control Water*");
                            CircleSpells[4].Add("Freedom of Movement*");
                            CircleSpells[5].Add("Conjure Elemental*");
                            CircleSpells[5].Add("Scrying*");
                        }
                        else if (index == 2)
                        {
                            CircleSpells[2].Add("Blur*");
                            CircleSpells[2].Add("Silence*");
                            CircleSpells[3].Add("Create Food and Water*");
                            CircleSpells[3].Add("Protection from Energy*");
                            CircleSpells[4].Add("Blight*");
                            CircleSpells[4].Add("Hallucinatory Terrain*");
                            CircleSpells[5].Add("Insect Plague*");
                            CircleSpells[5].Add("Wall of Stone*");
                        }
                        else if (index == 3)
                        {
                            CircleSpells[2].Add("Barkskin*");
                            CircleSpells[2].Add("Spiderclimb*");
                            CircleSpells[3].Add("Call Lightning*");
                            CircleSpells[3].Add("Plant Growth*");
                            CircleSpells[4].Add("Divination*");
                            CircleSpells[4].Add("Freedom of Movement*");
                            CircleSpells[5].Add("Commune with Nature*");
                            CircleSpells[5].Add("Tree Stride*");
                        }
                        else if (index == 4)
                        {
                            CircleSpells[2].Add("Invisibility*");
                            CircleSpells[2].Add("Pass without Trace*");
                            CircleSpells[3].Add("Daylight*");
                            CircleSpells[3].Add("Haste*");
                            CircleSpells[4].Add("Divination*");
                            CircleSpells[4].Add("Freedom of Movement*");
                            CircleSpells[5].Add("Dream*");
                            CircleSpells[5].Add("Insect Plague*");
                        }
                        else if (index == 5)
                        {
                            CircleSpells[2].Add("Spiderclimb*");
                            CircleSpells[2].Add("Spike Growth*");
                            CircleSpells[3].Add("Lightning Bolt*");
                            CircleSpells[3].Add("Meld Into Stone*");
                            CircleSpells[4].Add("Stoneshape*");
                            CircleSpells[4].Add("Stoneskin*");
                            CircleSpells[5].Add("Passwall*");
                            CircleSpells[5].Add("Wall of Stone*");
                        }
                        else if (index == 6)
                        {
                            CircleSpells[2].Add("Darkness*");
                            CircleSpells[2].Add("Melf's Acid Arrow*");
                            CircleSpells[3].Add("Waterwalk*");
                            CircleSpells[3].Add("Stinking Cloud*");
                            CircleSpells[4].Add("Freedom of Movement*");
                            CircleSpells[4].Add("Locate Creature*");
                            CircleSpells[5].Add("Insect Plague*");
                            CircleSpells[5].Add("Scrying*");
                        }
                        else if (index == 7)
                        {
                            CircleSpells[2].Add("Spiderclimb*");
                            CircleSpells[2].Add("Web*");
                            CircleSpells[3].Add("Gaseous Form*");
                            CircleSpells[3].Add("Stinking Cloud*");
                            CircleSpells[4].Add("Greater Invisibility*");
                            CircleSpells[4].Add("Stoneshape*");
                            CircleSpells[5].Add("Cloudkill*");
                            CircleSpells[5].Add("Insect Plague*");
                        }
                        if (lvl >= 3)
                        {
                            result.Spells[2].AddRange(CircleSpells[2]);
                        }
                        if (lvl >= 5)
                        {
                            result.Spells[3].AddRange(CircleSpells[3]);
                        }
                        if (lvl >= 7)
                        {
                            result.Spells[4].AddRange(CircleSpells[4]);
                        }
                        if (lvl >= 9)
                        {
                            result.Spells[5].AddRange(CircleSpells[5]);
                        }

                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Land's Stride", "move through difficult terrain and plants that cause dmg, adv vs spells that impede movement");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Nature's Ward", "can't be charmed or frightened by elementals or fey, gain Immunity to disease and poison");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Nature's Sanctuary", "beasts or plants that atk, Wis save, choose another target");
                        }
                        break;
                    case "Moon":
                        result.ClassFeatures.Add("Combat Wild Shape", "bonus to Wild Shape, expend spell slot to gain 1D8 HP per slot lvl");
                        result.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR 1 - no swimming or flying";
                        if (lvl >= 4)
                        {
                            result.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR 1 - no flying";
                        }
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Primal Strike", "your beast form atks count as magical");
                            result.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR = lvl / 3, no flying";
                        }
                        if (lvl >= 8)
                        {
                            result.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR = lvl / 3, no limits";
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Elemental Wild Shape", "expend 2 uses of Wild Shape to turn into an elemental");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Thousand Forms", "cast Alter Self spell at will");
                        }
                        break;
                    case "Shepherd":
                        result.ClassFeatures.Add("Speech of the Woods", "you can communicate with beasts and they can relay recent events");
                        character.Languages.Add("Sylvan");
                        result.ClassFeatures.Add("Spirit Totem", "SR, bonus, 1 min, 60ft, spirit creates 30ft aura, bonus move spirit up to 60ft" +
                            "\nBear(everyone regains HP = 5 + lvl, adv on Str saves and checks)" +
                            "\nHawk(reaction, when an atk is made, grant adv on atk, adv on Perception)" +
                            "\nUnicorn(adv on all detection ability checks, when you use a heal spell, everyone regains HP = lvl)");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Mighty Summoner", "beasts and fey summoned get +2 HD and atks are considered magical");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Guardian Spirit", "beasts or fey that end their turn in your Spirit Totem aura regain HP = 1/2 lvl");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Faithful Summons", "LR, if drop to 0 HP or become incap, gain benefits of Conjure Animals at 9th lvl," +
                                "\nfour beasts CR 2 or lower are summoned and they defend/attack without commands");
                        }
                        break;
                    case "Spores":
                        //result.ClassFeatures.Add("", "");
                        //if (lvl >= 6)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 10)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 14)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        break;
                    case "Stars":
                        //result.ClassFeatures.Add("", "");
                        //if (lvl >= 6)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 10)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 14)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        break;
                    case "Wildfire":
                        //result.ClassFeatures.Add("", "");
                        //if (lvl >= 6)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 10)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        //if (lvl >= 14)
                        //{
                        //    result.ClassFeatures.Add("", "");
                        //}
                        break;
                }
            }
            if (lvl >= 4 && DruidCircle != "Moon")
            {
                result.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR 1/2 - no flying";
                result.ClassFeatures.Add("Cantrip Versatility", "When you get an Ability Score Improvement, you can replace a cantrip");
            }
            if (lvl >= 8 && DruidCircle != "Moon")
            {
                result.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR 1, no limits";
            }
            if (lvl >= 18)
            {
                result.ClassFeatures.Add("Timeless Body", "10yr = 1yr for age");
                result.ClassFeatures.Add("Beast Spells", "cast while in Wild Shape");
            }
            if (lvl >= 20)
            {
                result.ClassFeatures.Add("Archdruid", "can use Wild Shape unlimited times");
            }
            //spells code
            string pickMsg = "Pick a cantrip.";
            string str2 = "You already have that cantrip.";
            int spellLvl = 1;
            AllSpells spells = new AllSpells(character.ChosenClass);
            for (int i = 0; i < result.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(spells.Druid[0], result.Cantrips, pickMsg, str2);
                result.Cantrips.Add(spell);
                spells.Druid[0].Remove(spell);
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
                        string spell2 = CLIHelper.GetNew(spells.Druid[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                        result.Spells[spellLvl].Add(spell2);
                    }
                    if (lvl >= 13)
                    {
                        string spell2 = CLIHelper.GetNew(spells.Druid[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                        result.Spells[spellLvl].Add(spell2);
                    }
                }
                if (lvl <= 11)
                {
                    string spell = CLIHelper.GetNew(spells.Druid[spellLvl], result.Spells[spellLvl], pickMsg, str2);
                    result.Spells[spellLvl].Add(spell);
                    spells.Druid[spellLvl].Remove(spell);
                }
            }
            //end spells code

            return result;
        }
    }
}
