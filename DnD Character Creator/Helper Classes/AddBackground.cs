using DnD_Character_Creator.Backgrounds;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class AddBackground
    {
        public static void PersonalCharacteristics(Character character, Background background)
        {
            int traitIndex = Prompts.BackgroundPrompts("personality trait", background.PersonalityTrait);
            character.PersonalityTrait = background.PersonalityTrait[traitIndex];

            int idealIndex = Prompts.BackgroundPrompts("ideal", background.Ideal);
            character.Ideal = background.Ideal[idealIndex];

            int bondIndex = Prompts.BackgroundPrompts("bond", background.Bond);
            character.Bond = background.Bond[bondIndex];

            int flawIndex = Prompts.BackgroundPrompts("flaw", background.Flaw);
            character.Flaw = background.Flaw[flawIndex];
        }
        public static void BackgroundSpecifics(Character character, Background backgroundObject)
        {
            string background = character.ChosenBackground;

            if (background == "Criminal" || background == "Sage" || background == "Soldier")
            {
                if (background == "Criminal")
                {
                    Console.WriteLine("There are many kinds of criminals, but every criminal has a preference for certain kinds of crime.");
                }
                else if (background == "Sage")
                {
                    Console.WriteLine("What was the nature of your scholarly training?");
                }
                else
                {
                    Console.WriteLine("During your time as a soldier you had a specific role to play in your unit or army.");
                }

                int specialtyIndex = Prompts.BackgroundPrompts("specialty", backgroundObject.Specialty);
                character.Specialty = backgroundObject.Specialty[specialtyIndex];
            }
            else if (background.Contains("Charltan"))
            {
                Console.WriteLine("Every charltan has an angle he/she uses in preference to other schemes.");
                int scamIndex = Prompts.BackgroundPrompts("favorite scam", backgroundObject.FavoriteScam);
                character.FavoriteScam = backgroundObject.FavoriteScam[scamIndex];

                if (scamIndex == 0)
                {
                    character.Equipment.Add("Set of weighted dice");
                }
                else if (scamIndex == 2)
                {
                    character.Equipment.Add("Signet ring of imaginary duke");
                }
                else if (scamIndex == 4)
                {
                    character.Equipment.Add("Deck of marked cards");
                }
                else if (scamIndex == 5)
                {
                    character.Equipment.Add("10 stoppered bottles of colored liquid");
                }
            }
            else if (background.Contains("Entertainer"))
            {
                Console.WriteLine("A good entertainer is versatile, spicing things up every performance with a variety of different routines." +
                    "\n        You can have up to 3 routines that define your expertise. Enter a number(1-3) to decide how many routines you have.");
                int routines = CLIHelper.GetNumberInRange(1, 3);
                for (int i = 0; i < routines; i++)
                {
                    int routineIndex = Prompts.BackgroundPrompts("routine", backgroundObject.Routine);
                    character.Routines.Add(backgroundObject.Routine[routineIndex]);
                }
            }
            else if (background.Contains("Merchant"))
            {
                Console.WriteLine("Guilds are groups of several merchants who practice the same trade. Pick one good to specialize in.");
                int businessIndex = Prompts.BackgroundPrompts("nature of your guild business", backgroundObject.GuildBusiness);
                character.GuildBusiness = backgroundObject.GuildBusiness[businessIndex];
            }
            else if (background == "Folk Hero")
            {
                Console.WriteLine("You previously lived a simple life, but something happened that set you on a different path and marked you for greatness.");
                int eventIndex = Prompts.BackgroundPrompts("defining event", backgroundObject.DefiningEvent);
                character.DefiningEvent = backgroundObject.DefiningEvent[eventIndex];
            }
            else if (background == "Guild Artisan")
            {
                Console.WriteLine("Guilds are groups of several artisans who practice the same trade. Pick one good to specialize in.");
                int businessIndex = Prompts.BackgroundPrompts("nature of your guild business", backgroundObject.GuildBusiness);
                character.GuildBusiness = backgroundObject.GuildBusiness[businessIndex];
            }
            else if (background == "Hermit")
            {
                Console.WriteLine("What was the reason for your isolation? What changed allowing you to end your solitude?");
                int seclusionIndex = Prompts.BackgroundPrompts("nature of your seclusion", backgroundObject.LifeOfSeclusion);
                character.LifeOfSeclusion = backgroundObject.LifeOfSeclusion[seclusionIndex];
            }
            else if (background == "Outlander")
            {
                backgroundObject = Background.Outlander(character);
                Console.WriteLine("What was your occupation during your time in the wild?");
                int originIndex = Prompts.BackgroundPrompts("origin", backgroundObject.Origin);
                character.Origin = backgroundObject.Origin[originIndex];
            }

        }
        public static Background AddGHBackground(GHBackground background)
        {
            var result = new Background();

            background.PersonalityTrait.CopyTo(result.PersonalityTrait, 0);
            background.Ideal.CopyTo(result.Ideal, 0);
            background.Bond.CopyTo(result.Bond, 0);
            background.Flaw.CopyTo(result.Flaw, 0);
            background.FavoriteScam.CopyTo(result.FavoriteScam, 0);
            background.Routine.CopyTo(result.Routine, 0);
            background.GuildBusiness.CopyTo(result.GuildBusiness, 0);

            return result;
        }
    }
}
