using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    class AllSpells
    {
        public AllSpells(string classString)
        {
            switch (classString)
            {
                case "Bard":
                    Bard.Add(0, BardSpells.Cantrips);
                    Bard.Add(1, BardSpells.FirstLvls);
                    Bard.Add(2, BardSpells.SecondLvls);
                    Bard.Add(3, BardSpells.ThirdLvls);
                    Bard.Add(4, BardSpells.FourthLvls);
                    Bard.Add(5, BardSpells.FifthLvls);
                    Bard.Add(6, BardSpells.SixthLvls);
                    Bard.Add(7, BardSpells.SeventhLvls);
                    Bard.Add(8, BardSpells.EigthLvls);
                    Bard.Add(9, BardSpells.NinthLvls);
                    break;
                case "Cleric":
                    Cleric.Add(0, ClericSpells.Cantrips);
                    Cleric.Add(1, ClericSpells.FirstLvls);
                    Cleric.Add(2, ClericSpells.SecondLvls);
                    Cleric.Add(3, ClericSpells.ThirdLvls);
                    Cleric.Add(4, ClericSpells.FourthLvls);
                    Cleric.Add(5, ClericSpells.FifthLvls);
                    Cleric.Add(6, ClericSpells.SixthLvls);
                    Cleric.Add(7, ClericSpells.SeventhLvls);
                    Cleric.Add(8, ClericSpells.EigthLvls);
                    Cleric.Add(9, ClericSpells.NinthLvls);
                    break;
                case "Druid":
                    Druid.Add(0, DruidSpells.Cantrips);
                    Druid.Add(1, DruidSpells.FirstLvls);
                    Druid.Add(2, DruidSpells.SecondLvls);
                    Druid.Add(3, DruidSpells.ThirdLvls);
                    Druid.Add(4, DruidSpells.FourthLvls);
                    Druid.Add(5, DruidSpells.FifthLvls);
                    Druid.Add(6, DruidSpells.SixthLvls);
                    Druid.Add(7, DruidSpells.SeventhLvls);
                    Druid.Add(8, DruidSpells.EigthLvls);
                    Druid.Add(9, DruidSpells.NinthLvls);
                    break;
                case "Fighter":
                    Fighter.Add(0, FighterSpells.Cantrips);
                    Fighter.Add(1, FighterSpells.FirstLvls);
                    Fighter.Add(2, FighterSpells.SecondLvls);
                    Fighter.Add(3, FighterSpells.ThirdLvls);
                    Fighter.Add(4, FighterSpells.FourthLvls);
                    Wizard.Add(0, WizardSpells.Cantrips);
                    Wizard.Add(1, WizardSpells.FirstLvls);
                    Wizard.Add(2, WizardSpells.SecondLvls);
                    Wizard.Add(3, WizardSpells.ThirdLvls);
                    Wizard.Add(4, WizardSpells.FourthLvls);
                    break;
                case "Paladin":
                    Paladin.Add(1, PaladinSpells.FirstLvls);
                    Paladin.Add(2, PaladinSpells.SecondLvls);
                    Paladin.Add(3, PaladinSpells.ThirdLvls);
                    Paladin.Add(4, PaladinSpells.FourthLvls);
                    Paladin.Add(5, PaladinSpells.FifthLvls);
                    break;
                case "Ranger":
                    Ranger.Add(1, RangerSpells.FirstLvls);
                    Ranger.Add(2, RangerSpells.SecondLvls);
                    Ranger.Add(3, RangerSpells.ThirdLvls);
                    Ranger.Add(4, RangerSpells.FourthLvls);
                    Ranger.Add(5, RangerSpells.FifthLvls);
                    break;
                case "Rogue":
                    Rogue.Add(0, RogueSpells.Cantrips);
                    Rogue.Add(1, RogueSpells.FirstLvls);
                    Rogue.Add(2, RogueSpells.SecondLvls);
                    Rogue.Add(3, RogueSpells.ThirdLvls);
                    Rogue.Add(4, RogueSpells.FourthLvls);
                    Wizard.Add(0, WizardSpells.Cantrips);
                    Wizard.Add(1, WizardSpells.FirstLvls);
                    Wizard.Add(2, WizardSpells.SecondLvls);
                    Wizard.Add(3, WizardSpells.ThirdLvls);
                    Wizard.Add(4, WizardSpells.FourthLvls);
                    break;
                case "Sorcerer":
                    Sorcerer.Add(0, SorcererSpells.Cantrips);
                    Sorcerer.Add(1, SorcererSpells.FirstLvls);
                    Sorcerer.Add(2, SorcererSpells.SecondLvls);
                    Sorcerer.Add(3, SorcererSpells.ThirdLvls);
                    Sorcerer.Add(4, SorcererSpells.FourthLvls);
                    Sorcerer.Add(5, SorcererSpells.FifthLvls);
                    Sorcerer.Add(6, SorcererSpells.SixthLvls);
                    Sorcerer.Add(7, SorcererSpells.SeventhLvls);
                    Sorcerer.Add(8, SorcererSpells.EigthLvls);
                    Sorcerer.Add(9, SorcererSpells.NinthLvls);
                    break;
                case "Swordmage":
                    Swordmage.Add(0, SwordmageSpells.Cantrips);
                    Swordmage.Add(1, SwordmageSpells.FirstLvls);
                    Swordmage.Add(2, SwordmageSpells.SecondLvls);
                    Swordmage.Add(3, SwordmageSpells.ThirdLvls);
                    Swordmage.Add(4, SwordmageSpells.FourthLvls);
                    Swordmage.Add(5, SwordmageSpells.FifthLvls);
                    break;
                case "Warlock":
                    Warlock.Add(0, WarlockSpells.Cantrips);
                    Warlock.Add(1, WarlockSpells.FirstLvls);
                    Warlock.Add(2, WarlockSpells.SecondLvls);
                    Warlock.Add(3, WarlockSpells.ThirdLvls);
                    Warlock.Add(4, WarlockSpells.FourthLvls);
                    Warlock.Add(5, WarlockSpells.FifthLvls);
                    Warlock.Add(6, WarlockSpells.SixthLvls);
                    Warlock.Add(7, WarlockSpells.SeventhLvls);
                    Warlock.Add(8, WarlockSpells.EigthLvls);
                    Warlock.Add(9, WarlockSpells.NinthLvls);
                    break;
                case "Wizard":
                    Wizard.Add(0, WizardSpells.Cantrips);
                    Wizard.Add(1, WizardSpells.FirstLvls);
                    Wizard.Add(2, WizardSpells.SecondLvls);
                    Wizard.Add(3, WizardSpells.ThirdLvls);
                    Wizard.Add(4, WizardSpells.FourthLvls);
                    Wizard.Add(5, WizardSpells.FifthLvls);
                    Wizard.Add(6, WizardSpells.SixthLvls);
                    Wizard.Add(7, WizardSpells.SeventhLvls);
                    Wizard.Add(8, WizardSpells.EigthLvls);
                    Wizard.Add(9, WizardSpells.NinthLvls);
                    break;
            } 
        }
        public Dictionary<int, List<string>> Bard { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Cleric { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Druid { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Fighter { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Paladin { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Ranger { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Rogue { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Sorcerer { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Swordmage { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Warlock { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Wizard { get; set; } = new Dictionary<int, List<string>>();
        public static List<string> AllCantrips { get; set; } = new List<string>
        {
            "Acid Splash",
            "Blade Ward",
            "Booming Blade",
            "Chill Touch",
            "Control Flames",
            "Create Bonfire",
            "Dancing Lights",
            "Druidcraft",
            "Eldritch Blast",
            "Encode Thoughts",
            "Fire Bolt",
            "Friends",
            "Frostbite",
            "Green-Flame blade",
            "Gust",
            "Infestation",
            "Light",
            "Lightning Lure",
            "Mage Hand",
            "Magic Stone",
            "Mending",
            "Message",
            "Mind Sliver",
            "Minor Illusion",
            "Mold Earth",
            "Poison Spray",
            "Prestidigitation",
            "Primal Savagery",
            "Produce Flame",
            "Ray of Frost",
            "Resistance",
            "Sacred Flame",
            "Sapping Sting",
            "Shape Water",
            "Shillelagh",
            "Shocking Grasp",
            "Spare the Dying",
            "Sword Burst",
            "Thaumaturgy",
            "Thorn Whip",
            "Thunderclap",
            "Toll the Dead",
            "True Strike",
            "Vicious Mockery",
            "Word of Radiance"
        };
        public static Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>
        {
            { "Abi-Dalzim’s Horrid Wilting", "" },
            { "Absorb Elements", "" },
            { "Acid Arrow", "" },
            { "Acid Splash", "" },
            { "Aganazzar’s Scorcher", "" },
            { "Aid", "" },
            { "Alarm", "" },
            { "Alter Self", "" },
            { "Animal Friendship", "" },
            { "Animal Messenger", "" },
            { "Animal Shapes", "" },
            { "Animate Dead", "" },
            { "Antilife Shell", "" },
            { "Antimagic Field", "" },
            { "Antipathy/Sympathy", "" },
            { "Arcane Eye", "" },
            { "Arcane Gate", "" },
            { "Arcane Hand", "" },
            { "Arcane Lock", "" },
            { "Armor of Agathys", "" },
            { "Arms of Hadar", "" },
            { "Astral Projection", "" },
            { "Augury", "" },
            { "Aura of Life", "" },
            { "Aura of Purity", "" },
            { "Aura of Vitality", "" },
            { "Awaken", "" },
            { "Bane", "" },
            { "Banishing Smite", "" },
            { "Banishment", "" },
            { "Barkskin", "" },
            { "Beacon of Hope", "" },
            { "Beast Bond", "" },
            { "Beast Sense", "" },
            { "Bestow Curse", "" },
            { "Blade Barrier", "" },
            { "Blade of Diaster", "" },
            { "Blade Ward", "" },
            { "Bless", "" },
            { "Blight", "" },
            { "Blinding Smite", "" },
            { "Blindness/Deafness", "" },
            { "Blink", "" },
            { "Blur", "" },
            { "Bones of the Earth", "" },
            { "Booming Blade", "" },
            { "Branding Smite", "" },
            { "Burning Hands", "" },
            { "Call Lightning", "" },
            { "Calm Emotions", "" },
            { "Catapult", "" },
            { "Catnap", "" },
            { "Cause Fear", "" },
            { "Ceremony", "" },
            { "Chain Lightning", "" },
            { "Chaos Bolt", "" },
            { "Charm Monster", "" },
            { "Charm Person", "" },
            { "Chill Touch", "" },
            { "Chromatic Orb", "" },
            { "Cirle of Death", "" },
            { "Cirle of Power", "" },
            { "Clairvoyance", "" },
            { "Clone", "" },
            { "Cloud of Daggers", "" },
            { "Cloudkill", "" },
            { "Color Spray", "" },
            { "Command", "" },
            { "Commune", "" },
            { "Commune with Nature", "" },
            { "Compelled Duel", "" },
            { "Comprehend Languages", "" },
            { "Compulsion", "" },
            { "Cone of Cold", "" },
            { "Confusion", "" },
            { "Conjure Animals", "" },
            { "Conjure Barrage", "" },
            { "Conjure Celestial", "" },
            { "Conjure Elemental", "" },
            { "Conjure Fey", "" },
            { "Conjure Minor Elementals", "" },
            { "Conjure Volley", "" },
            { "Conjure Woodland Beings", "" },
            { "Contact Other Plane", "" },
            { "Contagion", "" },
            { "Contingency", "" },
            { "Continual Flame", "" },
            { "Control Flames", "" },
            { "Control Water", "" },
            { "Control Weather", "" },
            { "Control Winds", "" },
            { "Cordon of Arrows", "" },
            { "Counterspell", "" },
            { "Create Bonfire", "" },
            { "Create Food and Water", "" },
            { "Create Homunculus", "" },
            { "Create Magen", "" },
            { "Create or Destroy Water", "" },
            { "Create Undead", "" },
            { "Creation", "" },
            { "Crown of Madness", "" },
            { "Crown of Stars", "" },
            { "Crusader's Mantle", "" },
            { "Cure Wounds", "" },
            { "Dancing Lights", "" },
            { "Danse Macabre", "" },
            { "Dark Star", "" },
            { "Darkness", "" },
            { "Darkvision", "" },
            { "Dawn", "" },
            { "Daylight", "" },
            { "Death Ward", "" },
            { "Delayed Fireball", "" },
            { "Demiplane", "" },
            { "Destructive Wave", "" },
            { "Detect Evil and Good", "" },
            { "Detect Magic", "" },
            { "Detect Poison and Disease", "" },
            { "Detect Thoughts", "" },
            { "Dimension Door", "" },
            { "Disguise Self", "" },
            { "Disintegrate", "" },
            { "Dispel Evil and Good", "" },
            { "Dispel Magic", "" },
            { "Dissonant Whispers", "" },
            { "Distort Value", "" },
            { "Divination", "" },
            { "Divine Favor", "" },
            { "Divine Word", "" },
            { "Dominate Beast", "" },
            { "Dominate Monster", "" },
            { "Dominate Person", "" },
            { "Dragon's Breath", "" },
            { "Drawmij's Instant Summons", "" },
            { "Dream", "" },
            { "Dream of the Blue Veil", "" },
            { "Druid Grove", "" },
            { "Druidcraft", "" },
            { "Dust Devil", "" },
            { "Earth Tremor", "" },
            { "Earthbind", "" },
            { "Earthquake", "" },
            { "Eldritch Blase", "" },
            { "Elemental Bane", "" },
            { "Elemental Weapon", "" },
            { "Encode Thoughts", "" },
            { "Enemies Abound", "" },
            { "Enervation", "" },
            { "Enhance Ability", "" },
            { "Enlarge/Reduce", "" },
            { "Ensnaring Strike", "" },
            { "Entangle", "" },
            { "Enthrall", "" },
            { "Erupting Earth", "" },
            { "Etherealness", "" },
            { "Evard's Black Tentacles", "" },
            { "Expeditious Retreat", "" },
            { "Eyebite", "" },
            { "Fabricate", "" },
            { "Faerie Fire", "" },
            { "False Life", "" },
            { "Far Step", "" },
            { "Fast Friends", "" },
            { "Fear", "" },
            { "Featherfall", "" },
            { "Feeblemind", "" },
            { "Feign Death", "" },
            { "Find Familiar", "" },
            { "Find Greater Steed", "" },
            { "Find Steed", "" },
            { "Find the Path", "" },
            { "Find Traps", "" },
            { "Finger of Death", "" },
            { "Fire Bolt", "" },
            { "Fire Shield", "" },
            { "Firestorm", "" },
            { "Fireball", "" },
            { "Flame Arrows", "" },
            { "Flame Blade", "" },
            { "Flame Strike", "" },
            { "Flaming Sphere", "" },
            { "Flesh to Stone", "" },
            { "Flock of Familiars", "" },
            { "Fly", "" },
            { "Fog Cloud", "" },
            { "Forbiddance", "" },
            { "Forcecage", "" },
            { "Foresight", "" },
            { "Fortune's Favor", "" },
            { "Freedom of Movement", "" },
            { "Freezing Sphere", "" },
            { "Friends", "" },
            { "Frost Fingers", "" },
            { "Frostbite", "" },
            { "Galder's Speedy Courier", "" },
            { "Galder's Tower", "" },
            { "Gaseous Form", "" },
            { "Gate", "" },
            { "Geas", "" },
            { "Gentle Repose", "" },
            { "Giant Insect", "" },
            { "Gift of Alacrity", "" },
            { "Gift of Gab", "" },
            { "Globe of Invulnerability", "" },
            { "Glyph of Warding", "" },
            { "Goodberry", "" },
            { "Grasping Vine", "" },
            { "Gravity Fissure", "" },
            { "Gravity Sinkhole", "" },
            { "Grease", "" },
            { "Greater Invisibility", "" },
            { "Greater Restoration", "" },
            { "Green-Flame Blade", "" },
            { "Guardian of Faith", "" },
            { "Guardian of Nature", "" },
            { "Guards and Wards", "" },
            { "Guidance", "" },
            { "Guiding Bolt", "" },
            { "Gust", "" },
            { "Gust of Wind", "" },
            { "Hail of Thorns", "" },
            { "Hallow", "" },
            { "Hallucinatory Terrain", "" },
            { "Harm", "" },
            { "Haste", "" },
            { "Heal", "" },
            { "Healing Spirit", "" },
            { "Healing Word", "" },
            { "Heat Metal", "" },
            { "Hellish Rebuke", "" },
            { "Heroes' Feast", "" },
            { "Heroism", "" },
            { "Hex", "" },
            { "Hold Monster", "" },
            { "Hold Person", "" },
            { "Holy Aura", "" },
            { "Holy Weapon", "" },
            { "Hunger of Hadar", "" },
            { "Hunter's Mark", "" },
            { "Hypnotic Pattern", "" },
            { "Ice Knife", "" },
            { "Ice Storm", "" },
            { "Identify", "" },
            { "Illusory Dragon", "" },
            { "Illusory Script", "" },
            { "Immolation", "" },
            { "Immovable Object", "" },
            { "Imprisonment", "" },
            { "Incediary Cloud", "" },
            { "Incite Greed", "" },
            { "Infernal Calling", "" },
            { "Infestation", "" },
            { "Inflict Wounds", "" },
            { "Insect Plague", "" },
            { "Instant Summons", "" },
            { "Intellect Fortress", "" },
            { "Investiture of Flame", "" },
            { "Investiture of Ice", "" },
            { "Investiture of Stone", "" },
            { "Investiture of Wind", "" },
            { "Invisibility", "" },
            { "Invulnerability", "" },
            { "Jim's Glowing Coin", "" },
            { "Jim's Magic Missile", "" },
            { "Jump", "" },
            { "Knock", "" },
            { "Legend Lore", "" },
            { "Leomund's Secret Chest", "" },
            { "Leomund's Tiny Hut", "" },
            { "Lesser Restoration", "" },
            { "Levitate", "" },
            { "Life Transference", "" },
            { "Light", "" },
            { "Lightning Arrow", "" },
            { "Lightning Bolt", "" },
            { "Lightning Lure", "" },
            { "Locate Animals or Plants", "" },
            { "Locate Creature", "" },
            { "Locate Object", "" },
            { "Longstrider", "" },
            { "Maddening Darkness", "" },
            { "Maelstrom", "" },
            { "Mage Armor", "" },
            { "Mage Hand", "" },
            { "Magic Circel", "" },
            { "Magic Jar", "" },
            { "Magic Missile", "" },
            { "Magic Mouth", "" },
            { "Magic Stone", "" },
            { "Magic Weapon", "" },
            { "Magnify Gravity", "" },
            { "Major Image", "" },
            { "Mass Cure Wounds", "" },
            { "Mass Heal", "" },
            { "Mass Healing Word", "" },
            { "Mass Polymorph", "" },
            { "Mass Suggestion", "" },
            { "Maximilain's Earth Grasp", "" },
            { "Maze", "" },
            { "Meld Into Stone", "" },
            { "Melf's Acid Arrow", "" },
            { "Melf's Minute Meteors", "" },
            { "Mending", "" },
            { "Mental Prison", "" },
            { "Message", "" },
            { "Meteor Swarm", "" },
            { "Mighty Fortress", "" },
            { "Mind Blank", "" },
            { "Mind Sliver", "" },
            { "Mind Spike", "" },
            { "Minor Illusion", "" },
            { "Mirage Arcana", "" },
            { "Mirror Image", "" },
            { "Mislead", "" },
            { "Misty Step", "" },
            { "Modify Memory", "" },
            { "Mold Earth", "" },
            { "Moonbeam", "" },
            { "Mordenkainen’s Faithful Hound", "" },
            { "Mordenkainen’s Private Sanctum", "" },
            { "Mordenkainen’s Sword", "" },
            { "Mordenkainen’s Magnificent Mansion", "" },
            { "Motivational Speech", "" },
            { "Move Earth", "" },
            { "Negative Energy Flood", "" },
            { "Nondetection", "" },
            { "Nystul's Magic Aura", "" },
            { "Otiluke's Resilient Sphere", "" },
            { "Otiluke's Freezing Sphere", "" },
            { "Otto's Irresistable Dance", "" },
            { "Pass without Trace", "" },
            { "Passwall", "" },
            { "Phantasmal Force", "" },
            { "Phantasmal Killer", "" },
            { "Phantom Steed", "" },
            { "Planar Ally", "" },
            { "Planar Binding", "" },
            { "Plane Shift", "" },
            { "Plant Growth", "" },
            { "Poison Spray", "" },
            { "Polymorph", "" },
            { "Power Word Heal", "" },
            { "Power Word Kill", "" },
            { "Power Word Pain", "" },
            { "Power Word Stun", "" },
            { "Prayer of Healing", "" },
            { "Prestidigitation", "" },
            { "Primal Savagery", "" },
            { "Primordial Ward", "" },
            { "Prismatic Spray", "" },
            { "Prismatic Wall", "" },
            { "Produce Flame", "" },
            { "Programmed Illusion", "" },
            { "Project Image", "" },
            { "Protection from Energy", "" },
            { "Protection from Evil and Good", "" },
            { "Protection from Poison", "" },
            { "Psychic Scream", "" },
            //{ "Pulse Wave", "" }, explorer's guide to wildemount
            { "Purify Food and Drink", "" },
            { "Pyrotechnics", "" },
            { "Raise Dead", "" },
            { "Rary's Telepathic Bond", "" },
            { "Ravenous Void", "" },
            { "Ray of Enfeeblement", "" },
            { "Ray of Frost", "" },
            { "Ray of Sickness", "" },
            //{ "Reality Break", "" }, explorer's guide to wildemount
            { "Regenerate", "" },
            { "Reincarnate", "" },
            { "Remove Curse", "" },
            { "Resilient Sphere", "" },
            { "Resistance", "" },
            { "Resurrection", "" },
            { "Reverse Gravity", "" },
            { "Revivify", "" },
            { "Rope Trick", "" },
            { "Sacred Flame", "" },
            { "Sanctuary", "" },
            { "Sapping Sting", "" },
            { "Scatter", "" },
            { "Scorching Ray", "" },
            { "Scrying", "" },
            { "Searing Smite", "" },
            { "See Invisibility", "" },
            { "Seeming", "" },
            { "Sending", "" },
            { "Sequester", "" },
            { "Shadow Blade", "" },
            { "Shadow of Moil", "" },
            { "Shape Water", "" },
            { "Shapechange", "" },
            { "Shatter", "" },
            { "Shield", "" },
            { "Shield of Faith", "" },
            { "Shillelagh", "" },
            { "Shocking Grasp", "" },
            { "Sickening Radiance", "" },
            { "Silence", "" },
            { "Silent Image", "" },
            { "Simulacrum", "" },
            { "Skill Empowerment", "" },
            { "Skywrite", "" },
            { "Sleep", "" },
            { "Sleet Storm", "" },
            { "Slow", "" },
            { "Snare", "" },
            { "Snilloc’s Snowball Swarm", "" },
            { "Soul Cage", "" },
            { "Spare the Dying", "" },
            { "Speak with Animals", "" },
            { "Speak with Dead", "" },
            { "Speak with Plants", "" },
            { "Spiderclimb", "" },
            { "Spike Growth", "" },
            { "Spirit Guardians", "" },
            { "Spirit Shroud", "" },
            { "Spiritual Weapon", "" },
            { "Staggering Smite", "" },
            { "Steel Wind Strike", "" },
            { "Stinking Cloud", "" },
            { "Stoneshape", "" },
            { "Stoneskin", "" },
            { "Storm of Vengeance", "" },
            { "Storm Sphere", "" },
            { "Sugeestion", "" },
            { "Summon Aberration", "" },
            { "Summon Beast", "" },
            { "Summon Celestial", "" },
            { "Summon Construct", "" },
            { "Summon Elemental", "" },
            { "Summon Fey", "" },
            { "Summon Fiend", "" },
            { "Summon Greater Demon", "" },
            { "Summon Lesser Demon", "" },
            { "Summon Shadowspawn", "" },
            { "Summon Undead", "" },
            { "Sunbeam", "" },
            { "Sunburst", "" },
            { "Swift Quiver", "" },
            { "Sword Burst", "" },
            { "Symbol", "" },
            { "Synaptic Static", "" },
            { "Tasha's Hideous Laughter", "" },
            { "Tasha's Caustic Brew", "" },
            { "Tasha's Mind Whip", "" },
            { "Tasha's Otherworldly Guise", "" },
            { "Telekinesis", "" },
            { "Telepathic Bond", "" },
            { "Telepathy", "" },
            { "Teleport", "" },
            { "Teleportation Circle", "" },
            { "Temple of the Gods", "" },
            //{ "Temporal Shunt", "" }, explorer's guide to wildemount
            { "Tenser's Floating Disk", "" },
            { "Tenser's Transformation", "" },
            //{ "Tether Essence", "" }, explorer's guide to wildemount
            { "Thaumaturgy", "" },
            { "Thorn Whip", "" },
            { "Thunder Step", "" },
            { "Thunderclap", "" },
            { "Thunderous Smite", "" },
            { "Thunder Wave", "" },
            { "Tidal Wave", "" },
            //{ "Time Ravage", "" }, explorer's guide to wildemount
            { "Time Stop", "" },
            { "Tiny Servant", "" },
            { "Toll the Dead", "" },
            { "Tongues", "" },
            { "Transmute Rock", "" },
            { "Transport via Plants", "" },
            { "Tree Stride", "" },
            { "True Polymorph", "" },
            { "True Resurrection", "" },
            { "True Seeing", "" },
            { "True Strike", "" },
            { "Tsunami", "" },
            { "Unseen Servant", "" },
            { "Vampiric Touch", "" },
            { "Vicious Mockery", "" },
            { "Vitrolic Sphere", "" },
            { "Wall of Fire", "" },
            { "Wall of Force", "" },
            { "Wall of Ice", "" },
            { "Wall of Light", "" },
            { "Wall of Sand", "" },
            { "Wall of Stone", "" },
            { "Wall of Thorns", "" },
            { "Wall of Water", "" },
            { "Warding Bond", "" },
            { "Warding Wind", "" },
            { "Waterbreathing", "" },
            { "Water Walk", "" },
            { "Watery Sphere", "" },
            { "Web", "" },
            { "Weird", "" },
            { "Whirlwind", "" },
            { "Wind Walk", "" },
            { "Wish", "" },
            { "Witch Bolt", "" },
            { "Word of Radiance", "" },
            { "Word of Recall", "" },
            { "Wrath of Nature", "" },
            { "Wrathful Smite", "" },
            { "Wristpocket", "" },
            { "Zephyr Strike", "" },
            { "Zone of Truth", "" }
        };
    }
}
