using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;
using System;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Outlander : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "I’m driven by a wanderlust that led me away from home.",
            "I watch over my friends as if they were a litter of newborn pups.",
            "I once ran 25 miles without stopping to warn to my clan of an approaching horde. I’d do it again if I had to.",
            "I have a lesson for every situation, drawn from observing nature.",
            "I place no stock in wealthy or well-mannered folk. Money and manners won’t save you from a hungry owlbear.",
            "I’m always picking things up, absently fiddling with them, and sometimes accidentally breaking them.",
            " I feel far more comfortable around animals than people.",
            "I was, in fact, raised by wolves.",
            
        };
        public static string[] Ideal { get; set; } =
        {
            "Change. Life is like the seasons, in constant change, and we must change with it. (Chaotic)",
            "Greater Good. It is each person’s responsibility to make the most happiness for the whole tribe. (Good)",
            "Honor. If I dishonor myself, I dishonor my whole clan. (Lawful)",
            "Might. The strongest are meant to rule. (Evil)",
            "Nature. The natural world is more important than all the constructs of civilization. (Neutral)",
            "Glory. I must earn glory in battle, for myself and my clan. (Any)"
        };
        public static string[] Bond { get; set; } =
        {
            "My family, clan, or tribe is the most important thing in my life, even when they are far from me.",
            "An injury to the unspoiled wilderness of my home is an injury to me.",
            "I will bring terrible wrath down on the evildoers who destroyed my homeland.",
            "I am the last of my tribe, and it is up to me to ensure their names enter legend.",
            "I suffer awful visions of a coming disaster and will do anything to prevent it.",
            "It is my duty to provide children to sustain my tribe."
        };
        public static string[] Flaw { get; set; } = 
        {
            "I am too enamored of ale, wine, and other intoxicants.",
            "There’s no room for caution in a life lived to the fullest.",
            "I remember every insult I’ve received and nurse a silent resentment toward anyone who’s ever wronged me.",
            "I am slow to trust members of other races, tribes, and societies.",
            "Violence is my answer to almost any challenge.",
            "I won't save those who can’t save themselves. Nature’s way is for the strong thrive and the weak perish."
        };
        public string[] Origin { get; set; } =
        {
            "Forester",
            "Trapper",
            "Homesteader",
            "Guide",
            "Exile or outcast",
            "Bounty hunter",
            "Pilgrim",
            "Tribal nomad",
            "Hunter-gatherer",
            "Tribal marauder"
        };
        public static void AddStatics(Character character)
        {
            character.SkillProficiencies.Add("Athletics");
            character.SkillProficiencies.Add("Survival");
            string pickMsg = "Pick a musical instrument you'd like to be proficient with";
            string instrument = CLIHelper.GetNew(Options.MusicalInstruments, character.ToolProficiencies, pickMsg);
            character.ToolProficiencies.Add(instrument);
            BEHelper.AddLanguage(character, "background");
            character.Equipment.Add("Traveler's clothes");
            character.Equipment.Add("Staff");
            character.Equipment.Add("Hunting trap");
            character.Equipment.Add("Trophy from a killed animal");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 10;
            character.BackgroundFeature = "Wanderer: you can always recall the general layout of terrain, settlements, and other features around you. You can find food and" +
                "\n     fresh water for yourself and up to 5 people each day, as long as the land offers berries, small game, water, etc.";

            Console.WriteLine("What was your occupation during your time in the wild?");
            Outlander outlander = new Outlander();
            int originIndex = Prompts.BackgroundPrompts("origin", outlander.Origin);
            character.Origin = outlander.Origin[originIndex];
        }

    }
}
