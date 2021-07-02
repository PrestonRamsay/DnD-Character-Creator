using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Demigod
    {
        public static void Base(Character character)
        {
            character.RacialTraits.Add("Powerful Build: count as Large for carry capacity, etc");
            character.RacialTraits.Add("Godly Strength: adv on Str checks");
            character.RacialTraits.Add("Godly Protection: +2 AC");
            character.RacialTraits.Add("Divine Intervention: LR, gain adv on atk, save, or ability check");
            character.MinHeight = 60;
            character.MaxHeight = 78;
            character.MinWeight = 100;
            character.MaxWeight = 300;
            character.Speed += 40;
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("N-G");
            character.AlignmentOptions.Add("C-G");
            character.AlignmentOptions.Add("C-N");
            character.AdultAge = 30;
            character.MaxAgeStart = 800;
            character.MaxAgeEnd = 1200;
            character.Languages.Add("Celestial");
            BEHelper.AddLanguage(character, "race");

            int index = -1;
            switch (character.DemigodDomain)
            {
                case "Beauty":
                    character.RacialTraits.Add("Child of Love: impose disadv vs Enchantment spells");
                    character.RacialTraits.Add("Compelling Beauty: bonus, Cha save, disadv on atks, if attempt to move away from you Cha save");
                    character.Cantrips.Add("Friends(Cha to cast)");
                    character.SkillProficiencies.Add("Deception");
                    character.SkillProficiencies.Add("Persuasion");
                    break;
                case "Knowledge":
                    character.RacialTraits.Add("Child of Wisdom: gain 1 skill, 1 tool, and Expertise in 1 skill");
                    character.RacialTraits.Add("Wit Without Measure: adv on all Int-based DCs");
                    character.Cantrips.Add("Guidance(Int to cast)");
                    index = CLIHelper.PrintChoices("Pick a skill", Options.Skills);
                    character.SkillProficiencies.Add(Options.Skills[index]);
                    BEHelper.GetTool(character);
                    break;
                case "Life":
                    character.RacialTraits.Add("Child of Life: healing spells heal extra HP = Wis");
                    character.RacialTraits.Add("Refute Death: LR, 30ft, you or ally auto-succeeds on 1 death save");
                    character.Cantrips.Add("Spare the Dying(Wis to cast)");
                    break;
                case "Luck":
                    character.RacialTraits.Add("Child of Luck: Cha/LR, add 1D6 to any atk, save, or ability check");
                    character.RacialTraits.Add("Auspicious Dodge: LR, reaction, when hit - cause atk to miss");
                    character.RacialTraits.Add("Favored Attack: LR, on hit, cause atk to crit");
                    character.RacialTraits.Add("Prosperous Life: whenever you find treasure or try to sell goods, increase its value by 30%");
                    break;
                case "Madness":
                    character.RacialTraits.Add("Child of Madness: auto-succeed on all Con checks for drinking, gain Immunity to charm, fear, and poison");
                    character.RacialTraits.Add("Party Starter: Cha check in social area, gain adv on all Cha-based DCs for 2hr");
                    character.SkillProficiencies.Add("Acrobatics");
                    character.SkillProficiencies.Add("Persuasion");
                    character.Cantrips.Add("Create Bonfire(Cha to cast)");
                    character.Cantrips.Add("Dancing Lights(Cha to cast)");
                    break;
                case "Music":
                    character.RacialTraits.Add("Child of Music: creatures with Int 8 or less are charmed by music");
                    character.RacialTraits.Add("Devastating Notes: SR, Cha save, 30ft, all hostiles, 1 min, disadv on atks and saves");
                    character.SkillProficiencies.Add("Performance");
                    character.ToolProficiencies.Add("All instruments");
                    character.Cantrips.Add("Vicious Mockery(Cha to cast)");
                    break;
                case "Protection":
                    character.RacialTraits.Add("Child of Protection: Dodge as a bonus, +2 HP/lvl");
                    character.RacialTraits.Add("Experienced Knight: gain the Protection fighting style");
                    character.SkillProficiencies.Add("Athletics");
                    character.Proficiencies.Add("All armor and shields");
                    character.Cantrips.Add("Blade Ward(Cha to cast)");
                    break;
                case "Smithing":
                    character.RacialTraits.Add("Child of Creation: LR, create an object of any combination of wood, stone, iron, crystal, rope, or cloth" +
                        "The object must smaller than a 5ft cube, and the object must be in a form that you have seen before");
                    character.RacialTraits.Add("Child of the Forge: gain Immunity to Fire, adv on all tool checks you're prof in");
                    character.ToolProficiencies.Add("Carpenter's Tools");
                    character.ToolProficiencies.Add("Cobbler's Tools");
                    character.ToolProficiencies.Add("Mason's Tools");
                    character.ToolProficiencies.Add("Smith's Tools");
                    character.ToolProficiencies.Add("Tinker's Tools");
                    character.Cantrips.Add("Sword Burst(Wis to cast)");
                    break;
                case "The Earth":
                    character.RacialTraits.Add("Child of Nature: 30ft, create difficult terrain made of foliage, Str save or be restrained");
                    character.RacialTraits.Add("Earth Control: LR, cast Stoneshape or Wall of Stone");
                    character.SkillProficiencies.Add("Nature");
                    character.Cantrips.Add("Druidcraft(Wis to cast)");
                    break;
                case "The Hunt":
                    character.RacialTraits.Add("Child of the Hunt: adv on Survival, identify creatures from tracks");
                    character.RacialTraits.Add("Hunter's Eyes: gain Superior Darkvision 120ft, 1/SR - cast Detect Poison and Disease");
                    character.Vision = "Superior Darkvision 120ft";
                    character.RacialTraits.Add("Godly Precision: +2 to atk/dmg with ranged wep");
                    character.SkillProficiencies.Add("Survival");
                    character.Proficiencies.Add("All ranged weapons");
                    character.Cantrips.Add("Thorn Whip(Wis to cast)");
                    break;
                case "The Sea":
                    character.RacialTraits.Add("Child of the Sea: waterbreathing, swim 40ft");
                    character.RacialTraits.Add("Caress of the Ocean: gain regen = 1/4 lvl while in water");
                    character.Cantrips.Add("Shape Water(Int to cast)");
                    break;
                case "The Sky":
                    character.RacialTraits.Add("Child of the Sky: gain Resistance Thunder and Lightning");
                    character.RacialTraits.Add("Lightning Wielder: +2 to atk/dmg while unarmed, 1/LR - Cha spell atk, range 30/120, 4D8 + Cha Lightning dmg");
                    character.Cantrips.Add("Gust(Cha to cast)");
                    break;
                case "The Sun":
                    character.RacialTraits.Add("Child of the Sun: during the day, gain +2 Str, Dex, Con/at night, gain -2 Str, Dex, Con");
                    character.RacialTraits.Add("Solar Burst: LR, Con save - 30ft, 5D8 Radiant dmg, Con save - blindness");
                    character.Cantrips.Add("Light(Cha to cast)");
                    break;
                case "Travel":
                    character.RacialTraits.Add("Child of Travel: move speed +10ft");
                    character.Speed += 50;
                    character.RacialTraits.Add("Fast Travel: LR, cast Teleport");
                    character.Cantrips.Add("Message(Wis to cast)");
                    break;
                case "Trickery":
                    character.RacialTraits.Add("Child of Shadows: adv with Stealth and Thieves' Tools");
                    character.SkillProficiencies.Add("Deception");
                    character.SkillProficiencies.Add("Sleight of Hand");
                    character.SkillProficiencies.Add("Stealth");
                    character.ToolProficiencies.Add("Thieves' Tools");
                    character.Cantrips.Add("Minor Illusion(Int to cast)");
                    break;
                case "Undead":
                    character.RacialTraits.Add("Child of Death: gain Resistance to Necrotic, Superior Darkvision 120ft");
                    character.Vision = "Superior Darkvision 120ft";
                    character.RacialTraits.Add("Undead Affinity: SR, action, conjure 3 skeletons or zombies");
                    character.Cantrips.Add("Toll the Dead - Int or Wis to cast");
                    break;
                case "War":
                    character.RacialTraits.Add("Child of War: can't be surprised, +5 on Init, use Str for Intimiation");
                    character.RacialTraits.Add("Aura of War: LR, 30ft, Con save, fear and prone, you and allies gain Str temp HP");
                    character.RacialTraits.Add("Godly Precision: +2 atk/dmg with melee");
                    character.Proficiencies.Add("All weapons and armor");
                    break;
            }
        }
    }
}
