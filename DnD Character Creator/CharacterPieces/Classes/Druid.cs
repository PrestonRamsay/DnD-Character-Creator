using DnD_Character_Creator.CharacterPieces.Spells;
using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Classes
{
    public static class Druid
    {
        public static string DruidCircle { get; set; }
        public static Dictionary<int, List<string>> CircleSpells { get; set; } = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() }
        };
        public static void Base(Character character)
        {
            List<string> classSkills = new List<string> { "Arcana", "Animal Handling", "Insight", "Medicine", "Nature",
                "Perception", "Religion", "Survival" };

            character.GP += 50;
            character.HitDie = 8;
            Console.WriteLine("Druids will not wear armor or use shields made of metal");
            character.Proficiencies.Add("Light armor");
            character.Proficiencies.Add("Medium armor");
            character.Proficiencies.Add("Shields");
            character.Proficiencies.Add("Clubs");
            character.Proficiencies.Add("Daggers");
            character.Proficiencies.Add("Darts");
            character.Proficiencies.Add("Javelins");
            character.Proficiencies.Add("Maces");
            character.Proficiencies.Add("Quarterstaffs");
            character.Proficiencies.Add("Scimitars");
            character.Proficiencies.Add("Sickles");
            character.Proficiencies.Add("Slings");
            character.Proficiencies.Add("Spears");
            character.ToolProficiencies.Add("Herbalism Kit");
            character.Saves.Add("Int");
            character.Saves.Add("Wis");

            BEHelper.GetSkills(character, classSkills, 2);
        }
        public static void Equipment(Character character)
        {
            Console.WriteLine("You have the choice for some of your equipment. Pick a number.");
            CLIHelper.Print2Choices("Scimitar", "Any simple melee weapon");
            int input2 = CLIHelper.GetNumberInRange(1, 2);
            if (input2 == 1)
            {
                character.Equipment.Add(Options.MartialMeleeWeapons[12]);
            }
            else
            {
                BEHelper.AddSimpleMeleeWeapon(character);
            }
            CLIHelper.Print2Choices("Wooden shield", "Any simple weapon");
            int input1 = CLIHelper.GetNumberInRange(1, 2);
            if (input1 == 1)
            {
                character.Equipment.Add("Wooden shield(+2 AC)(10gp, 6lb.)");
            }
            else
            {
                BEHelper.AddSimpleMeleeWeapon(character);
            }

            character.Equipment.Add(Options.LightArmor[1]);
            character.Equipment.Add(Options.Packs[4]);
            string msg = "Pick a druidic focus. Enter a number.";
            var focuses = new List<string> { "Sprig of mistletoe", "Totem", "Wooden Staff", "Yew wand" };
            int focus = CLIHelper.PrintChoices(msg, focuses);

            switch (focus)
            {
                case 1:
                    character.Equipment.Add(Options.DruidicFocuses[0]);
                    break;
                case 2:
                    character.Equipment.Add(Options.DruidicFocuses[1]);
                    break;
                case 3:
                    character.Equipment.Add(Options.DruidicFocuses[2]);
                    break;
                case 4:
                    character.Equipment.Add(Options.DruidicFocuses[3]);
                    break;
            }
        }
        public static void Features(Character character)
        {
            int lvl = character.Lvl;

            character.ClassFeatures.Add("Druidic","DC 15 to spot a message");
            character.Languages.Add("Druidic");
            try
            {
                character.ClassFeatures.Add("Spellcasting", "use Wis for spell DCs, you use a Druidic Focus as a spell focus");
            }
            catch (Exception)
            {
                Console.WriteLine("*Note* You have 2 classes with spellcasting");
                throw;
            }

            if (lvl >= 2)
            {
                character.ClassFeatures.Add("Wild Shape", "2/SR, duration = 1/2 lvl hr, max CR 1/4 - no swimming or flying");
                character.ClassFeatures.Add("Wild Companion", "action, hr = 1/2 lvl, expend a Wild Shape use, cast Find Familiar, familiar is a Fey");
                string msg = "Pick a Druid Circle that will give you features at levels 2, 6, 10, and 14.";
                var archetypes = new List<string> { "Circle of Dreams", "Circle of the Land", "Circle of the Moon", "Circle of the Shepherd",
                    "Circle of Spores", "Circle of Stars", "Circle of Wildfire" };
                int input = CLIHelper.PrintChoices(msg, archetypes);

                if (input == 1 || input == 2 || input == 3)
                {
                    DruidCircle = archetypes[input].Substring(14);
                }
                else
                {
                    DruidCircle = archetypes[input].Substring(10);
                }

                switch (DruidCircle)
                {
                    case "Dreams":
                        Dreams(character);
                        break;
                    case "Land":
                        Land(character);
                        break;
                    case "Moon":
                        Moon(character);
                        break;
                    case "Shepherd":
                        Shepherd(character);
                        break;
                    case "Spores":
                        Spores(character);
                        break;
                    case "Stars":
                        Stars(character);
                        break;
                    case "Wildfire":
                        Wildfire(character);
                        break;
                }
            }
            if (lvl >= 4 && DruidCircle != "Moon")
            {
                character.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR 1/2 - no flying";
                character.ClassFeatures.Add("Cantrip Versatility", "When you get an Ability Score Improvement, you can replace a cantrip");
            }
            if (lvl >= 8 && DruidCircle != "Moon")
            {
                character.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR 1, no limits";
            }
            if (lvl >= 18)
            {
                character.ClassFeatures.Add("Timeless Body", "10yr = 1yr for age");
                character.ClassFeatures.Add("Beast Spells", "cast while in Wild Shape");
            }
            if (lvl >= 20)
            {
                character.ClassFeatures.Add("Archdruid", "can use Wild Shape unlimited times");
            }
            Spells(character);

            
        }
        public static void Dreams(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Balm of the Summer Court", "LR, bonus, 120ft, one creature, # of D6 = lvl, spend up to 1/2 lvl to heal #D6 + # temp HP");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Hearth of Moonlight and Shadow", "30ft, during rest +5 on Stealth and Perception and no light escapes");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Hidden Paths", "(Wis/LR) bonus, teleport 60ft / action, teleport an ally 30ft");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Walker in Dreams", "LR, after SR, cast Dream(you as messenger), Scrying, or Teleportation Circle(opens a portal to the last place you took LR)");
            }
        }
        public static void Land(Character character)
        {
            int lvl = character.Lvl;
            string msg = "Pick a cantrip.";
            string cantrip = CLIHelper.GetNew(DruidSpells.Cantrips, character.Cantrips, msg);
            character.Cantrips.Add(cantrip);
            character.ClassFeatures.Add("Natural Recovery", "during SR, regain spell slots = 1/2 lvl, can't be 6th lvl or higher");
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

            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Land's Stride", "move through difficult terrain and plants that cause dmg, adv vs spells that impede movement");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Nature's Ward", "can't be charmed or frightened by elementals or fey, gain Immunity to disease and poison");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Nature's Sanctuary", "beasts or plants that atk, Wis save, choose another target");
            }
        }
        public static void Moon(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Combat Wild Shape", "bonus to Wild Shape, expend spell slot to gain 1D8 HP per slot lvl");
            character.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR 1 - no swimming or flying";
            if (lvl >= 4)
            {
                character.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR 1 - no flying";
            }
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Primal Strike", "your beast form atks count as magical");
                character.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR = lvl / 3, no flying";
            }
            if (lvl >= 8)
            {
                character.ClassFeatures["Wild Shape"] = "2/SR, duration = 1/2 lvl hr, max CR = lvl / 3, no limits";
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Elemental Wild Shape", "expend 2 uses of Wild Shape to turn into an elemental");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Thousand Forms", "cast Alter Self spell at will");
            }
        }
        public static void Shepherd(Character character)
        {
            int lvl = character.Lvl;
            character.ClassFeatures.Add("Speech of the Woods", "you can communicate with beasts and they can relay recent events");
            character.Languages.Add("Sylvan");
            character.ClassFeatures.Add("Spirit Totem", "SR, bonus, 1 min, 60ft, spirit creates 30ft aura, bonus move spirit up to 60ft" +
                "\n        Bear(everyone regains HP = 5 + lvl, adv on Str saves and checks)" +
                "\n        Hawk(reaction, when an atk is made, grant adv on atk, adv on Perception)" +
                "\n        Unicorn(adv on all detection ability checks, when you use a heal spell, everyone regains HP = lvl)");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Mighty Summoner", "beasts and fey summoned get +2 HD and atks are considered magical");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Guardian Spirit", "beasts or fey that end their turn in your Spirit Totem aura regain HP = 1/2 lvl");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Faithful Summons", "LR, if drop to 0 HP or become incap, gain benefits of Conjure Animals at 9th lvl," +
                    "\n        four beasts CR 2 or lower are summoned and they defend/attack without commands");
            }
        }
        public static void Spores(Character character)
        {
            int lvl = character.Lvl;
            character.Cantrips.Add("Chill Touch");
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
            character.ClassFeatures.Add("Halo of Spores", $"reaction, 10ft, Con save, 1D{dmg} Necrotic dmg");
            character.ClassFeatures.Add("Symbiotic Entity", "action, 10 min or temp HP = 0, expend Wild Shape use, gain temp HP = lvl x 4, Halo of Spores dmg = 2 dice, melee dmg + 1D6 Necrotic");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Fungal Infestation", "Wis/LR, reaction, 1 hr, 10ft, Small or Medium beast or humanoid dies, raise as Zombie with 1 HP, can only make 1 melee atk");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Spreading Spores", "bonus, 1 min, 30ft - 10ft cube, while Symbiotic Entity is active, Halo of Spores actives there instead");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Fungal Body", "Immunity to blindness, deafness, fear, poison(condition), and crits");
            }
        }
        public static void Stars(Character character)
        {
            int lvl = character.Lvl;
            character.Cantrips.Add("Guidance");
            character.Spells[1].Add("Guiding Bolt*");
            character.ClassFeatures.Add("Star Map", "can use as a spell focus / PB/LR, cast Guiding Bolt without using a slot");
            character.ClassFeatures.Add("Starry Form", "bonus, 10 min, expend Wild Shape use, bright light 10ft/dim light 10ft - pick a form to gain benefits" +
                "\n        Archer(when activated or bonus, ranged spell atk, 60ft, 1D8 + Wis Radiant dmg)" +
                "\n        Chalice(30ft, 1 creature, when you cast a heal spell, restore HP = 1D8 + Wis)" +
                "\n        Dragon(when you make an Int or Wis check or a Con save, treats rolls 9 or lower as a 10)");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Cosmic Omen", "PB/LR, gain a reaction, on LR, roll any die, whether its even or odd determines the effect" +
                    "\n        even = Weal(reaction, 30ft - atk, check or save + 1D6)" +
                    "\n        odd = Woe(reaction, 30ft - atk, check, or save - 1D6)");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Twinkling Constellations", "you can change your Starry Form at the start of each turn");
                character.ClassFeatures["Starry Form"] = "bonus, 10 min, expend Wild Shape use, bright light 10ft/dim light 10ft - pick a form to gain benefits" +
                "\n        Archer(when activated or bonus, ranged spell atk, 60ft, 2D8 + Wis Radiant dmg)" +
                "\n        Chalice(30ft, 1 creature, when you cast a heal spell, restore HP = 2D8 + Wis)" +
                "\n        Dragon(gain Fly 20ft and Hover, when you make an Int or Wis check or a Con save, treats rolls 9 or lower as a 10)";
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Full of Stars", "while in Starry Form, gain Resistance to B/P/S");
            }
        }
        public static void Wildfire(Character character)
        {
            int lvl = character.Lvl;
            character.Spells[1].Add("Burning Hands*");
            character.Spells[1].Add("Cure Wounds*");
            CircleSpells[2].Add("Blindness/Deafness*");
            CircleSpells[2].Add("Gentle Repose*");
            CircleSpells[3].Add("Animate Dead*");
            CircleSpells[3].Add("Gaseous Form*");
            CircleSpells[4].Add("Blight*");
            CircleSpells[4].Add("Confusion*");
            CircleSpells[5].Add("Cloudkill*");
            CircleSpells[5].Add("Contagion*");

            character.ClassFeatures.Add("Summon Wildfire Spirit", "action, 1 hr, 30ft, expend Wild Shape use, summon wildfire spirit, 10ft, Dex save, 2D6 Fire dmg, bonus to command, TCE pg 40");
            if (lvl >= 6)
            {
                character.ClassFeatures.Add("Enhanced Bond", "Healing and Fire dmg spells + 1D8, spells with range not self can originate from your wildfire spirit");
            }
            if (lvl >= 10)
            {
                character.ClassFeatures.Add("Cauterizing Flames", "PB/LR, reaction, 1 min, 30ft(or spirit), when creature dies, create spectral flame - if touched, 2D10 + Wis Fire dmg or healing");
            }
            if (lvl >= 14)
            {
                character.ClassFeatures.Add("Blazing Revival", "LR, if spirit is within 120ft when you drop to 0 HP, cause spirit to drop to 0 HP, regain 1/2 max HP and stand up");
            }
        }
        public static void Spells(Character character)
        {
            BEHelper.AddPrimSpells(character, CircleSpells);
            int lvl = character.Lvl;
            string pickMsg = "Pick a cantrip.";
            AllSpells spells = new AllSpells(character);
            for (int i = 0; i < character.CantripsKnown; i++)
            {
                string spell = CLIHelper.GetNew(spells.Druid[0], character.Cantrips, pickMsg);
                character.Cantrips.Add(spell);
                spells.Druid[0].Remove(spell);
            }
            pickMsg = "Pick a 1st level spell.";
            foreach (var slotLvl in character.SpellSlots.Keys)
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
                int slots = character.SpellSlots[slotLvl];
                for (int i = 0; i < slots; i++)
                {
                    string spell = CLIHelper.GetNew(spells.Druid[slotLvl], character.Spells[slotLvl], pickMsg);
                    character.Spells[slotLvl].Add(spell);
                    spells.Druid[slotLvl].Remove(spell);
                }
            }
        }
    }
}
