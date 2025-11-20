using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.CharacterPieces.Classes;
using DnD_Character_Creator.Helper_Classes;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Archaeologist : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "I love a good puzzle or mystery.",
            "I'm a pack rat who never throws anything away.",
            "Fame is more important to me than money.",
            "I have no qualms about stealing from the dead.",
            "I'm happier in a dusty old tomb than I am in the centers of civilization.",
            "Traps don't make me nervous. Idiots who trigger traps make me nervous.",
            "I might fail, but I will never give up.",
            "You might think I'm a scholar, but I love a good brawl. These fists were made for punching."
        };
        public static string[] Ideal { get; set; } =
        {
            "Preservation. That artifact belongs in a museum. (Good)",
            "Greed. I won't risk my life for nothing. I expect some kind of payment. (Any)",
            "Death Wish. Nothing is more exhilarating than a narrow escape from the jaws of death. (Chaotic)",
            "Dignity. The dead and their belongings deserve to be treated with respect. (Lawful)",
            "Immortality. All my exploring is part of a plan to find the secret of everlasting life. (Any)",
            "Danger. With every great discovery comes grave danger. The two walk hand in hand. (Any)"
        };
        public static string[] Bond { get; set; } =
        {
            "Ever since I was a child, I've heard stories about a lost city. I aim to find it, learn its secrets, and earn my place in the history books.",
            "I want to find my mentor, who disappeared on an expedition some time ago.",
            "I have a friendly rival. Only one of us can be the best, and I aim to prove it's me.",
            "I won't sell an art object or other treasure that has historical significance or is one of a kind.",
            "I'm secretly in love with the wealthy patron who sponsors my archaeological exploits.",
            "I hope to bring prestige to a library, a museum, or a university."
        };
        public static string[] Flaw { get; set; } = 
        {
            "I have a secret fear of some common wild animal – and in my work, I see them everywhere.",
            "I can't leave a room without searching it for secret doors.",
            "When I'm not exploring dungeons or ruins, I get jittery and impatient.",
            "I have no time for friends or family. I spend every waking moment thinking about and preparing for my next expedition.",
            "When given the choice of going left or right, I always go left.",
            "I can't sleep except in total darkness."
        };
        public static string[] SignatureObject { get; set; } =
        {
            "10-foot pole",
            "Medallion",
            "Crowbar",
            "Shovel",
            "Hat",
            "Sledgehammer",
            "Hooded lantern",
            "Whip"
        };
        public static void AddStatics(Character character)
        {
            Console.WriteLine("Pick which tool you'd like to gain proficiency in");
            //CLIHelper.Print2Choices("Cartographer's Tools", "Navigator's Tools");
            int tool = CLIHelper.GetChoiceFromPair("Cartographer's Tools", "Navigator's Tools");

            if (tool == 1)
            {
                character.Equipment.Add("Cartographer's Tools");
            }
            else
            {
                character.Equipment.Add("Navigator's Tools");
            }

            character.SkillProficiencies.Add("History");
            character.SkillProficiencies.Add("Survival");
            BEHelper.AddLanguage(character, "background");
            character.Equipment.Add("Wooden case containing ruin/dungeon map");
            character.Equipment.Add("Bullseye lantern");
            character.Equipment.Add("Travler's clothes");
            character.Equipment.Add("Miner's pick");
            character.Equipment.Add("Shovel");
            character.Equipment.Add("2-person tent");
            character.Equipment.Add("Trinket from a dig site");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 25;
            character.BackgroundFeature = "Historical Knowledge: you can ascertain the purpose and builders of dungeons/ruins." +
                " You can accurately appraise 100+ yr old art";

            Console.WriteLine("Prior to becoming an adventurer, you spent most of your young life crawling around in the dust, " +
                "pilfering relics of questionable value from crypts and ruins. Though you managed to sell a few of your discoveries " +
                "and earn enough coin to buy proper adventuring gear, you have held onto an item that has great emotional value to you.");
            int signatureObject = Prompts.BackgroundPrompts("signature object", SignatureObject);
            character.BackgroundCharacteristic = SignatureObject[signatureObject];
        }

    }
}
