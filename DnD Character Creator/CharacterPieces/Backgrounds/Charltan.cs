using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;
using System;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Charltan : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "I fall in and out of love easily, and am always pursuing someone.",
            "I have a joke for every occasion, especially occasions where humor is inappropriate.",
            "Flattery is my preferred trick for getting what I want.",
            "I’m a born gambler who can't resist taking a risk for a potential payoff.",
            "I lie about almost everything, even when there’s no good reason to.",
            "Sarcasm and insults are my weapons of choice.",
            "I keep multiple holy symbols on me and invoke whatever deity might come in useful at any given moment.",
            "I pocket anything I see that might have some value.",
        };
        public static string[] Ideal { get; set; } =
        {
            "Independence. I am a free spirit - no one tells me what to do. (Chaotic)",
            "Fairness. I never target people who can’t afford to lose a few coins. (Lawful)",
            "Charity. I distribute the money I acquire to the people who really need it. (Good)",
            "Creativity. I never run the same con twice. (Chaotic)",
            "Friendship. Material goods come and go.Bonds of friendship last forever. (Good)",
            "Aspiration. I’m determined to make something of myself. (Any)"
        };
        public static string[] Bond { get; set; } =
        {
            "I fleeced the wrong person and must work to ensure that person never crosses paths with me or my loved ones.",
            "I owe everything to my mentor - a horrible person who’s probably rotting in jail somewhere.",
            "Somewhere out there, I have a child who doesn’t know me. I’m making the world better for him or her.",
            "I come from a noble family, and one day I’ll reclaim my lands and title from those who stole them from me.",
            "A powerful person killed someone I love.Some day soon, I’ll have my revenge.",
            "I swindled/ruined someone who didn’t deserve it. I seek to atone for misdeeds, I might never forgive myself."
        };
        public static string[] Flaw { get; set; } = 
        {
            "I can’t resist a pretty face.",
            "I'm always in debt. I spend my ill-gotten gains on decadent luxuries faster than I bring them in...",
            "I’m convinced that no one could ever fool me the way I fool others.",
            "I’m too greedy for my own good. I can’t resist taking a risk if there’s money involved.",
            "I can’t resist swindling people who are more powerful than me.",
            "I hate to admit it/will hate myself for it, but I'll run to preserve my own hide if the going gets tough."
        };
        public static string[] FavoriteScam { get; set; } =
        {
            "I cheat at games of chance.",
            "I shave coins or forge documents.",
            "I insinuate myself into people’s lives to prey on their weakness and secure their fortunes.",
            "I put on new identities like clothes.",
            "I run sleight of hand cons on street corners.",
            "I convince people that worthless junk is worth their hard-earned money."
        };
        public static void AddStatics(Character character)
        {
            character.SkillProficiencies.Add("Deception");
            character.SkillProficiencies.Add("Sleight of Hand");
            character.ToolProficiencies.Add("Disguise Kit");
            character.ToolProficiencies.Add("Forgery Kit");
            character.Equipment.Add("Fine clothes");
            character.Equipment.Add("Disguise Kit");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 15;
            character.BackgroundFeature = "False Identity: you have documentation, established acquaintances, and disguises for a second persona. You can also forge documents" +
                "\n     as long as you've seen as example of that kind of document/handwriting.";
            
            Console.WriteLine("Every charltan has an angle he/she uses in preference to other schemes.");
            int scamIndex = Prompts.BackgroundPrompts("favorite scam", FavoriteScam);
            character.FavoriteScam = FavoriteScam[scamIndex];

            switch (scamIndex)
            {
                case 0:
                    character.Equipment.Add("Set of weighted dice");
                    break;
                case 2:
                    character.Equipment.Add("Signet ring of imaginary duke");
                    break;
                case 4:
                    character.Equipment.Add("Deck of marked cards");
                    break;
                case 5:
                    character.Equipment.Add("10 stoppered bottles of colored liquid");
                    break;
            }
        }
    }
}
