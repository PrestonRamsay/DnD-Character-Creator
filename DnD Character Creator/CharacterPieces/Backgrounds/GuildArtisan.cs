using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;
using System;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class GuildArtisan : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "I believe that anything worth doing is worth doing right. I can’t help it - I’m a perfectionist.",
            "I’m a snob who looks down on those who can’t appreciate fine art.",
            "I always want to know how things work and what makes people tick.",
            "I’m full of witty aphorisms and have a proverb for every occasion.",
            "I’m rude to people who lack my commitment to hard work and fair play.",
            "I like to talk at length about my profession.",
            "I don’t part with my money easily and will haggle tirelessly to get the best deal possible.",
            "I’m well known for my work. I'm always taken aback when people haven’t heard of me."
        };
        public static string[] Ideal { get; set; } =
        {
            "Community. Everyone's duty is to strengthen the bonds of community and civilization's security. (Lawful)",
            "Generosity. My talents were given to me so that I could use them to benefit the world. (Good)",
            "Freedom. Everyone should be free to pursue his or her own livelihood. (Chaotic)",
            "Greed. I’m only in it for the money. (Evil)",
            "People. I’m committed to the people I care about, not to ideals. (Neutral)",
            "Aspiration. I work hard to be the best there is at my craft. (Any)"
        };
        public static string[] Bond { get; set; } =
        {
            "The workshop where I learned my trade is the most important place in the world to me.",
            "I created a great work for someone, then found them unworthy of it. I’m still looking for someone worthy.",
            "I owe my guild a great debt for forging me into the person I am today.",
            "I pursue wealth to secure someone’s love.",
            "One day I will return to my guild and prove that I am the greatest artisan of them all.",
            "I will get revenge on the evil forces that destroyed my place of business and ruined my livelihood."
        };
        public static string[] Flaw { get; set; } = 
        {
            "I’ll do anything to get my hands on something rare or priceless.",
            "I’m quick to assume that someone is trying to cheat me.",
            "No one must ever learn that I once stole money from guild coffers.",
            "I’m never satisfied with what I have— I always want more.",
            "I would kill to acquire a noble title.",
            "I’m horribly jealous of anyone who can outshine my handiwork.Everywhere I go, I’m surrounded by rivals."
        };
        public static string[] GuildBusiness { get; set; } =
        {
            "Alchemists and apothecaries",
            "Armorers, locksmiths, and finesmiths",
            "Brewers, distillers, and vintners",
            "Calligraphers, scribes, and scriveners",
            "Carpenters, roofers, and plasterers",
            "Cartographers, surveyors, and chart-makers",
            "Cobblers and shoemakers",
            "Cooks and bakers",
            "Glassblowers and glaziers",
            "Jewelers and gemcutters",
            "Leatherworkers, skinners, and tanners",
            "Masons and stonecutters",
            "Painters, limners, and sign-makers",
            "Potters and tile-makers",
            "Shipwrights and sailmakers",
            "Smiths and metal-forgers",
            "Tinkers, pewterers, and casters",
            "Wagon-makers and wheelwrights",
            "Weavers and dyers",
            "Woodcarvers, coopers, and bowyers"
        };
        public static void AddStatics(Character character)
        {
            Console.WriteLine("Would you like the Guild Merchant variant of the Guild Artisan background?");
            int choice = CLIHelper.GetChoiceFromPair("Yes", "No");

            if (choice == 1)
            {
                character.ChosenBackground = "Guild Merchant";
                Console.WriteLine("Would you like proficiency in Navigator's Tools or another Language?");
                int input = CLIHelper.GetChoiceFromPair("Navigator's Tools", "Language");

                if (input == 1)
                {
                    character.ToolProficiencies.Add("Navigator's Tools");
                    character.Equipment.Add("Navigator's Tools");
                }
                else
                {
                    BEHelper.AddLanguage(character, "background");
                }
                character.Equipment.Add("Cart");
                character.Equipment.Add("Mule");
            }
            else
            {
                string pickMsg = "Pick a set of Artisan's Tools you'd like to be proficient with";
                string tool = CLIHelper.GetNew(Options.ArtisanTools, character.ToolProficiencies, pickMsg);
                character.ToolProficiencies.Add(tool);
                character.Equipment.Add(tool);
            }
            character.SkillProficiencies.Add("Insight");
            character.SkillProficiencies.Add("Persuasion");
            BEHelper.AddLanguage(character, "background");
            character.Equipment.Add("Traveler's clothes");
            character.Equipment.Add("Letter of introduction from the guild");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 15;
            character.BackgroundFeature = "Guild Membership: guild members will provide you with food and lodging if necessary (they'll also pay for your funeral if necessary)." +
                "\n     The guild hall offers a place for you to meet others in your profession, potential patrons, allies, or hirelings. Guilds wield tremendous" +
                "\n     political power - if accused of a crime, they will support you if a good case can be made or if the crime is justifiable. You can gain " +
                "\n     access to political figures, if you're in good standing, but a donation of money or magical items to the guild coffers might be required." +
                "\n     You must pay the guild 5GP per month. If you fall behind to can backpay missed dues to remain in good standing.";

            Console.WriteLine("Guilds are groups of several artisans who practice the same trade. Pick one good to specialize in.");
            int businessIndex = Prompts.BackgroundPrompts("nature of your guild business", GuildBusiness);
            character.GuildBusiness = GuildBusiness[businessIndex];
        }

    }
}
