using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Urchin : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "I hide scraps of food and trinkets away in my pockets.",
            "I ask a lot of questions.",
            "I like to squeeze into small places where no one else can get to me.",
            "I sleep with my back to a wall or tree, with everything I own wrapped in a bundle in my arms.",
            "I eat like a pig and have bad manners.",
            "I think anyone who’s nice to me is hiding evil intent.",
            "I don’t like to bathe.",
            "I bluntly say what other people are hinting at or hiding."
        };
        public static string[] Ideal { get; set; } =
        {
            "Respect. All people, rich or poor, deserve respect. (Good)",
            "Community. We have to take care of each other, because no one else is going to do it. (Lawful)",
            "Change. The low are lifted up, the high & mighty are brought down. Such is the nature of life. (Chaotic)",
            "Retribution. The rich need to be shown what life and death are like in the gutters. (Evil)",
            "People. I help the people who help me - that’s what keeps us alive. (Neutral)",
            "Aspiration. I'm going to prove that I'm worthy of a better life."
        };
        public static string[] Bond { get; set; } =
        {
            "My town or city is my home, and I’ll fight to defend it.",
            "I sponsor an orphanage to keep others from enduring what I was forced to endure.",
            "I owe my survival to another urchin who taught me to live on the streets.",
            "I owe a debt I can never repay to the person who took pity on me.",
            "I escaped my life of poverty by robbing an important person, and I’m wanted for it.",
            "No one else should have to endure the hardships I’ve been through."
        };
        public static string[] Flaw { get; set; } = 
        {
            "If I'm outnumbered, I will run away from a fight.",
            "Gold seems like a lot of money to me, and I’ll do just about anything for more of it.",
            "I will never fully trust anyone other than myself.",
            "I’d rather kill someone in their sleep then fight fair.",
            "It’s not stealing if I need it more than someone else.",
            "People who can't take care of themselves get what they deserve."
        };
        public static void AddStatics(Character character)
        {
            character.SkillProficiencies.Add("Sleight of Hand");
            character.SkillProficiencies.Add("Stealth");
            character.ToolProficiencies.Add("Disguise Kit");
            character.ToolProficiencies.Add("Thieves' Tools");
            character.Equipment.Add("Common clothes");
            character.Equipment.Add("Small knife");
            character.Equipment.Add("Map of your home city");
            character.Equipment.Add("Pet mouse");
            character.Equipment.Add("Token to remember your parents by");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 15;
            character.BackgroundFeature = "City Secrets: you know secret passages through the urban sprawl. Outside of combat, you can travel through any two locations in the" +
                "\n     city twice as fast as your speed normally allows.";
            
            
            
            
        }

    }
}
