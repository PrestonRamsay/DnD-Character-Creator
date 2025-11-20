using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class UrbanBountyHunter : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            ""
        };
        public static string[] Ideal { get; set; } =
        {
            ""
        };
        public static string[] Bond { get; set; } =
        {
            ""
        };
        public static string[] Flaw { get; set; } = 
        {
            ""
        };
        public static void AddStatics(Character character)
        {
            character.SkillProficiencies.Add("");
            character.SkillProficiencies.Add("");
            for (int i = 0; i < 2; i++)
            {
                BEHelper.AddLanguage(character, "background");
            }
            character.Equipment.Add("");
            //BEHelper.AddHolySymbol(character);
            character.Equipment.Add("");
            character.Equipment.Add("");
            character.Equipment.Add("");
            character.Equipment.Add("");
            character.GP += 15;
            character.BackgroundFeature = "";
        }

    }
}
