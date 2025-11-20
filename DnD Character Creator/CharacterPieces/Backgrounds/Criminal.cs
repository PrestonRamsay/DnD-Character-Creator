using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;
using System;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Criminal : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "I always have a plan for what to do when things go wrong.",
            "I am always calm, no matter what the situation. I never raise my voice or let my emotions control me.",
            "The first thing I do in a new place is notice everything valuable (or where such things could be hidden).",
            "I would rather make a new friend than a new enemy.",
            "I am incredibly slow to trust. Those who seem the fairest often have the most to hide.",
            "I don't pay attention to the risks in a situation. Never tell me the odds.",
            "The best way to get me to do something is to tell me I can't do it.",
            "I blow up at the slightest insult."
        };
        public static string[] Ideal { get; set; } =
        {
            "Honor. I don’t steal from others in the trade. (Lawful)",
            "Freedom. Chains are meant to be broken, as are those who would forge them. (Chaotic)",
            "Charity. I steal from the wealthy so that I can help people in need. (Good)",
            "Greed. I will do whatever it takes to become wealthy. (Evil)",
            "People. I’m loyal to my friends, not ideals. Everyone else can go down the Styx for all I care. (Neutral)",
            "Redemption. There’s a spark of good in everyone. (Good)"
        };
        public static string[] Bond { get; set; } =
        {
            "I’m trying to pay off an old debt I owe to a generous benefactor.",
            "My ill-gotten gains go to support my family.",
            "Something important was taken from me, and I aim to steal it back.",
            "I will become the greatest thief that ever lived.",
            "I’m guilty of a terrible crime. I hope I can redeem myself for it.",
            "Someone I loved died because of a mistake I made. That will never happen again."
        };
        public static string[] Flaw { get; set; } = 
        {
            "When I see something valuable, I can’t think about anything but how to steal it.",
            "When faced with a choice between money and my friends, I usually choose the money.",
            "If there’s a plan, I’ll forget it.If I don’t forget it, I’ll ignore it.",
            "I have a “tell” that reveals when I'm lying.",
            "I turn tail and run when things look bad.",
            "An innocent person is in prison for a crime that I committed.I’m okay with that."
        };
        public string[] Specialty { get; set; } =
        {
            "Blackmailer",
            "Burglar",
            "Enforcer",
            "Fence",
            "Highway robber",
            "Hired killer",
            "Pickpocket",
            "Smuggler"
        };
        public static void AddStatics(Character character)
        {
            Console.WriteLine("Would you like the Spy variant of the Criminal background?");
            int choice = CLIHelper.GetChoiceFromPair("Yes", "No");

            if (choice == 1)
            {
                character.ChosenBackground += "(Spy)";
            }
            character.SkillProficiencies.Add("Deception");
            character.SkillProficiencies.Add("Stealth");
            string msg = "Pick a gaming set";
            string game = CLIHelper.GetNew(Options.GamingSets, character.ToolProficiencies, msg);
            character.ToolProficiencies.Add(game);
            character.ToolProficiencies.Add("Thieves' Tools");
            character.Equipment.Add("Dark common clothes with a hood");
            character.Equipment.Add("Crowbar");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 15;
            character.BackgroundFeature = "Criminal Contact: you have a reliable contact who acts as your liason to a criminal network. You can get them messages over" +
                "\n     long distances because you know local/corrupt individuals who can deliver the messages.";

            Console.WriteLine("There are many kinds of criminals, but every criminal has a preference for certain kinds of crime.");
            Criminal criminal = new Criminal();
            int specialtyIndex = Prompts.BackgroundPrompts("specialty", criminal.Specialty);
            character.Specialty = criminal.Specialty[specialtyIndex];
        }
    }
}
