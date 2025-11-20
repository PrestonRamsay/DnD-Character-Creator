using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.CharacterPieces.Races;
using DnD_Character_Creator.Helper_Classes;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System;
using System.Runtime.InteropServices;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Athlete : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "I feel most at peace during physical exertion, whether exercise or battle.",
            "I don't like to sit idle.",
            "I have a daily exercise routine I refuse to break.",
            "Obstacles exist to be overcome.",
            "When I see others struggling, I offer to help.",
            "I love to trade banter and gibes.",
            "Anything worth doing is worth doing best.",
            "I get irritated if people praise someone else and not me."
        };
        public static string[] Ideal { get; set; } =
        {
            "Competition. I strive to test myself in all things. (Chaotic)",
            "Triumph. The best part of winning is seeing my rivals brought low. (Evil)",
            "Camaraderie. The strongest bonds are forged through struggle. (Good)",
            "People. I strive to inspire my spectators. (Neutral)",
            "Tradition. Every game has rules, and the playing field must be level. (Lawful)",
            "Growth. Lessons hide in victory and defeat. (Any)"
        };
        public static string[] Bond { get; set; } =
        {
            "My teammates are my family.",
            "I will overcome a rival and prove myself their better.",
            "My mistake got someone hurt. Ill never make that mistake again.",
            "I will be the best for the honor and glory of my home.",
            "The person who trained me is the most important person in my world.",
            "I strive to live up to a specific hero's example."
        };
        public static string[] Flaw { get; set; } =
        {
            "I indulge in a habit that threatens my reputation or health.",
            "I'll do absolutely anything to win.",
            "I ignore anyone who doesn't compete and anyone who loses to me.",
            "I have lingering pain of old injuries.",
            "Any defeat or failure on my part is because my opponents cheated.",
            "I must be the captain of any group I join."
        };
        public static string[] FavoredEvent { get; set; } =
        {
            "Marathon",
            "Long-distance running",
            "Wrestling",
            "Boxing",
            "Chariot or horse race",
            "Pankration(mixed unarmed combat)",
            "Hoplite race(racing in full armor with a unit)",
            "Pentathlon(running, long jump, discus, javelin, wrestling)"
        };
        public static void AddStatics(Character character)
        {
            Console.WriteLine("Pick one to add to your inventory");
            //CLIHelper.Print2Choices("Bronze discus", "Leather ball");
            int item = CLIHelper.GetChoiceFromPair("Bronze discus", "Leather ball");

            if (item == 1)
            {
                character.Equipment.Add("Bronze discus");
            }
            else
            {
                character.Equipment.Add("Leather ball");
            }
            Console.WriteLine("Pick one to add to your inventory");
            //CLIHelper.Print2Choices("Lucky charm", "Past trophy");
            item = CLIHelper.GetChoiceFromPair("Lucky charm", "Past trophy");

            if (item == 1)
            {
                character.Equipment.Add("Lucky charm");
            }
            else
            {
                character.Equipment.Add("Past trophy");
            }
            character.SkillProficiencies.Add("Acrobatics");
            character.SkillProficiencies.Add("Athletics");
            BEHelper.AddLanguage(character, "background");
            character.ToolProficiencies.Add("Vechiles(land)");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 10;
            character.BackgroundFeature = "Echoes of Victory: At a settlement within 100miles of where you grew up, 50% chance you can find someone who " +
                "\n     admires you and provides info/temp shelter. You can compete in athletic events as a profession during downtime.";

            Console.WriteLine("While many athletes practice various games and events, most excel at a single form of competition.");
            int favoredEvent = Prompts.BackgroundPrompts("favored event", FavoredEvent);
            character.BackgroundCharacteristic = FavoredEvent[favoredEvent];
        }

    }
}
