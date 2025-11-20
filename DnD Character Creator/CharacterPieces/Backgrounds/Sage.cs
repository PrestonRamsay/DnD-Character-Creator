using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;
using System;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Sage : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "I use polysyllabic words that convey the impression of great erudition.",
            "I've read every book in the world’s greatest libraries - or I like to boast that I have.",
            "I'm used to helping out those who aren’t as smart as I am. I patiently explain anything/everything to others.",
            "There’s nothing I like more than a good mystery.",
            "I’m willing to listen to every side of an argument before I make my own judgment.",
            "I... speak... slowly... when talking... to idiots... which... almost... everyone... is... compared... to me.",
            "I am horribly, horribly awkward in social situations.",
            "I’m convinced that people are always trying to steal my secrets."
        };
        public static string[] Ideal { get; set; } =
        {
            "Knowledge. The path to power and self-improvement is through knowledge. (Neutral)",
            "Beauty. What is beautiful points us beyond itself toward what is true. (Good)",
            "Logic. Emotions must not cloud our logical thinking. (Lawful)",
            "No Limits. Nothing should fetter the infinite possibility inherent in all existence. (Chaotic)",
            "Power. Knowledge is the path to power and domination. (Evil)",
            "Self-Improvement. The goal of a life of study is the betterment of oneself. (Any)"
        };
        public static string[] Bond { get; set; } =
        {
            "It is my duty to protect my students.",
            "I have an ancient text that holds terrible secrets that must not fall into the wrong hands.",
            "I work to preserve a library, university, scriptorium, or monastery.",
            "My life’s work is a series o f tomes related to a specific field of lore.",
            "I've been searching my whole life for the answer to a certain question.",
            "I sold my soul for knowledge.I hope to do great deeds and win it back."
        };
        public static string[] Flaw { get; set; } = 
        {

            "I am easily distracted by the promise of information.",
            "Most people scream and run when they see a demon. I stop and take notes on its anatomy.",
            "Unlocking an ancient mystery is worth the price of a civilization.",
            "I overlook obvious solutions in favor of complicated ones.",
            "I speak without really thinking through my words, invariably insulting others.",
            "I can’t keep a secret to save my life, or anyone else’s."
        };
        public string[] Specialty { get; set; } =
        {
            "Alchemist",
            "Astronomer",
            "Discredited academic",
            "Librarian",
            "Professor",
            "Researcher",
            "Wizard’s apprentice",
            "Scribe"
        };
        public static void AddStatics(Character character)
        {
            character.SkillProficiencies.Add("Arcana");
            character.SkillProficiencies.Add("History");
            for (int i = 0; i < 2; i++)
            {
                BEHelper.AddLanguage(character, "background");
            }
            character.Equipment.Add("Common clothes");
            character.Equipment.Add("Quill and ink");
            character.Equipment.Add("Small knife");
            character.Equipment.Add("Letter from a dead colleague posing an unanswered question");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 10;
            character.BackgroundFeature = "Researcher: when you want to learn new lore, you usually know where to find it - whether it's in a book, a sage or other creature" +
                "\n     knows it, etc. The DM may rule the knowledge is inaccessible.";

            Console.WriteLine("What was the nature of your scholarly training?");
            Sage sage = new Sage();
            int specialtyIndex = Prompts.BackgroundPrompts("specialty", sage.Specialty);
            character.Specialty = sage.Specialty[specialtyIndex];
        }

    }
}
