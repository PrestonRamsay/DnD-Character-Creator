using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;
using System;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Noble : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "My eloquent flattery makes everyone I talk to feel like the most wonderful and important person in the world.",
            "The common folk love me for my kindness and generosity.",
            "No one could doubt by looking at my regal bearing that I am a cut above the unwashed masses.",
            "I take great pains to always look my best and follow the latest fashions.",
            "I don’t like to get my hands dirty, and I won’t be caught dead in unsuitable accommodations.",
            "Despite my noble birth, I do not place myself above other folk.We all have the same blood.",
            "My favor, once lost, is lost forever.",
            "If you do me an injury, I will crush you, ruin your name, and salt your fields."
        };
        public static string[] Ideal { get; set; } =
        {
            "Respect. Respect is due to me because of my position, but all people deserve to be treated with dignity. (Good)",
            "Responsibility. It is everyone's duty to respect the authority of those above them. (Lawful)",
            "Independence. I must prove that I can handle myself without the coddling of my family. (Chaotic)",
            "Power. If I can attain more power, no one will tell me what to do. (Evil)",
            "Family. Blood runs thicker than water. (Any)",
            "Noble Obligation. It is my duty to protect and care for the people beneath me. (Good)"
        };
        public static string[] Bond { get; set; } =
        {
            "I will face any challenge to win the approval of my family.",
            "My house’s alliance with another noble family must be sustained at all costs.",
            "Nothing is more important than the other members of my family.",
            "I am in love with the heir of a family that my family despises.",
            "My loyalty to my sovereign is unwavering.",
            "The common folk must see me as a hero of the people."
        };
        public static string[] Flaw { get; set; } =
        {
            "I secretly believe that everyone is beneath me.",
            "I hide a truly scandalous secret that could ruin my family forever.",
            "I too often hear veiled insults and threats in every word addressed to me, and I’m quick to anger.",
            "I have an insatiable desire for carnal pleasures.",
            "In fact, the world does revolve around me.",
            "By my words and actions, I often bring shame to my family."
        };
        public static void AddStatics(Character character)
        {
            Console.WriteLine("Would you like the Knight variant of the Noble background?");
            int choice = CLIHelper.GetChoiceFromPair("Yes", "No");

            if (choice == 1)
            {
                character.ChosenBackground += "(Knight)";
                character.BackgroundFeature = "Retainers: 3 commoners are loyal to your family - one is a squire in training of noble birth and the other two may be attendants, messagers" +
                    "\n     a groom for your horse, or a servant to polish your armor" +
                    "\n     They can perform mundane tasks, will not fight or follow you into dangerous areas. They will leave if frequently endangered or abused.";

                Console.WriteLine("Would you like to add a banner or other token from a lord/lady?");
                choice = CLIHelper.GetChoiceFromPair("Yes", "No");

                if (choice == 1)
                {
                    character.Equipment.Add("Banner/Token of Lord/Lady");
                }
            }
            else
            {
                Console.WriteLine("Would you like the Position of Privilege feature or the Retainers feature");
                choice = CLIHelper.GetChoiceFromPair("Position of Privilege", "Retainers");

                if(choice == 1)
                {
                    character.BackgroundFeature = "Position of Privilege: people are inclined to think better of you, you are welcome in high society, and people assume you have the right" +
                        "\n     to be wherever you are. Common folk make every effort to accomodate you and avoid your displeasure. Other people of high birth treat you as a" +
                        "\n     member of the same social sphere. You can secure an audience with a local noble if you need to.";
                }
                else
                {
                    character.BackgroundFeature = "Retainers: 3 commoners are loyal to your family, they are attendants or messagers (one may be a majordomo)." +
                        "\n     They can perform mundane tasks, will not fight or follow you into dangerous areas. They will leave if frequently endangered or abused.";
                }
            }
            character.SkillProficiencies.Add("History");
            character.SkillProficiencies.Add("Persuasion");
            string msg = "Pick a gaming set";
            string game = CLIHelper.GetNew(Options.GamingSets, character.ToolProficiencies, msg);
            character.ToolProficiencies.Add(game);
            BEHelper.AddLanguage(character, "background");
            character.Equipment.Add("Fine clothes");
            character.Equipment.Add("Signet ring");
            character.Equipment.Add("Scroll of pedigree");
            character.Equipment.Add("Coin purse");
            character.GP += 25;
            
        }

    }
}
