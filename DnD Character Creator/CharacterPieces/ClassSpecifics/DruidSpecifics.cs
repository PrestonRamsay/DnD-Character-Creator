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
            { 0, new List<string>() },
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
                    "Circle of Spores", "Circle of Stars", "Circle of Wildfire" };
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
                        result.Cantrips.Add("Chill Touch");
                        CircleSpells[2].Add("Blindness/Deafness*");
                        CircleSpells[2].Add("Gentle Repose*");
                        CircleSpells[3].Add("Animate Dead*");
                        CircleSpells[3].Add("Gaseous Form*");
                        CircleSpells[4].Add("Blight*");
                        CircleSpells[4].Add("Confusion*");
                        CircleSpells[5].Add("Cloudkill*");
                        CircleSpells[5].Add("Contagion*");

                        int dmg = 4;
                        for (int i = 6; i <= lvl; i += 4)
                        {
                            if (i <= 14)
                            {
                                dmg += 2;
                            }
                        }
                        result.ClassFeatures.Add("Halo of Spores", $"reaction, 10ft, Con save, 1D{dmg} Necrotic dmg");
                        result.ClassFeatures.Add("Symbiotic Entity", "action, 10 min or temp HP = 0, expend Wild Shape use, gain temp HP = lvl x 4, Halo of Spores dmg = 2 dice, melee dmg + 1D6 Necrotic");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Fungal Infestation", "Wis/LR, reaction, 1 hr, 10ft, Small or Medium beast or humanoid dies, raise as Zombie with 1 HP, can only make 1 melee atk");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Spreading Spores", "bonus, 1 min, 30ft - 10ft cube, while Symbiotic Entity is active, Halo of Spores actives there instead");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Fungal Body", "Immunity to blindness, deafness, fear, poison(condition), and crits");
                        }
                        break;
                    case "Stars":
                        result.Cantrips.Add("Guidance");
                        result.Spells[1].Add("Guiding Bolt*");
                        result.ClassFeatures.Add("Star Map", "can use as a spell focus / PB/LR, cast Guiding Bolt without using a slot");
                        result.ClassFeatures.Add("Starry Form", "bonus, 10 min, expend Wild Shape use, bright light 10ft/dim light 10ft - pick a form to gain benefits" +
                            "\nArcher(when activated or bonus, ranged spell atk, 60ft, 1D8 + Wis Radiant dmg)" +
                            "\nChalice(30ft, 1 creature, when you cast a heal spell, restore HP = 1D8 + Wis)" +
                            "\nDragon(when you make an Int or Wis check or a Con save, treats rolls 9 or lower as a 10)");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Cosmic Omen", "PB/LR, gain a reaction, on LR, roll any die, whether its even or odd determines the effect" +
                                "\neven = Weal(reaction, 30ft - atk, check or save + 1D6)" +
                                "\nodd = Woe(reaction, 30ft - atk, check, or save - 1D6)");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Twinkling Constellations", "you can change your Starry Form at the start of each turn");
                            result.ClassFeatures["Starry Form"] = "bonus, 10 min, expend Wild Shape use, bright light 10ft/dim light 10ft - pick a form to gain benefits" +
                            "\nArcher(when activated or bonus, ranged spell atk, 60ft, 2D8 + Wis Radiant dmg)" +
                            "\nChalice(30ft, 1 creature, when you cast a heal spell, restore HP = 2D8 + Wis)" +
                            "\nDragon(gain Fly 20ft and Hvoer, when you make an Int or Wis check or a Con save, treats rolls 9 or lower as a 10)");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Full of Stars", "while in Starry Form, gain Resistance to B/P/S");
                        }
                        break;
                    case "Wildfire":
                        result.Spells[1].Add("Burning Hands*");
                        result.Spells[1].Add("Cure Wounds*");
                        CircleSpells[2].Add("Blindness/Deafness*");
                        CircleSpells[2].Add("Gentle Repose*");
                        CircleSpells[3].Add("Animate Dead*");
                        CircleSpells[3].Add("Gaseous Form*");
                        CircleSpells[4].Add("Blight*");
                        CircleSpells[4].Add("Confusion*");
                        CircleSpells[5].Add("Cloudkill*");
                        CircleSpells[5].Add("Contagion*");

                        result.ClassFeatures.Add("Summon Wildfire Spirit", "action, 1 hr, 30ft, expend Wild Shape use, summon wildfire spirit, 10ft, Dex save, 2D6 Fire dmg, bonus to command");
                        if (lvl >= 6)
                        {
                            result.ClassFeatures.Add("Enhanced Bond", "Healing and Fire dmg spells + 1D8, spells with range not self can originate from your wildfire spirit");
                        }
                        if (lvl >= 10)
                        {
                            result.ClassFeatures.Add("Cauterizing Flames", "PB/LR, reaction, 1 min, 30ft(or spirit), when creature dies, create spectral flame - if touched, 2D10 + Wis Fire dmg or healing");
                        }
                        if (lvl >= 14)
                        {
                            result.ClassFeatures.Add("Blazing Revival", "LR, if spirit is within 120ft when you drop to 0 HP, cause spirit to drop to 0 HP, regain 1/2 max HP and stand up");
                        }
                        break;
                }
            }
            int num = 2;
            for (int i = 3; i <= lvl; i += 2)
            {
                if (i <= 9)
                {
                    result.Spells[num].AddRange(CircleSpells[num]);
                    num++;
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
