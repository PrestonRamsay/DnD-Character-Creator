using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;
using System;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class CityWatch : Background
    {
        public static void AddStatics(Character character)
        {
            Console.WriteLine("Would you like the Investigator variant of the City Watch background?");
            int choice = CLIHelper.GetChoiceFromPair("Yes", "No");

            if (choice == 1)
            {
                character.SkillProficiencies.Add("Investigation");
                character.ChosenBackground += "(Investigator)";
            }
            else
            {
                character.SkillProficiencies.Add("Athletics");
            }
            character.SkillProficiencies.Add("Insight");
            for (int i = 0; i < 2; i++)
            {
                BEHelper.AddLanguage(character, "background");
            }
            character.Equipment.Add("Unit unifrom with rank");
            character.Equipment.Add("Horn to summon help");
            character.Equipment.Add("Set of manacles");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 10;
            character.BackgroundFeature = "Locate local barracks or criminal dens (more likely welcome at barracks)";
        }

    }
}
