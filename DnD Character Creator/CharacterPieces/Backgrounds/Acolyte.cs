using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.Helper_Classes;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Acolyte : Background
    {
        //public static List<string> PersonalityTrait { get; set; } = new List<string>
        //{
        //    "I idolize a particular hero of my faith, and constantly refer to that person’s deeds and example.",
        //    "I can find common ground between the fiercest enemies, empathizing with them and always working toward peace.",
        //    "I see omens in every event and action. The gods try to speak to us, we just need to listen.",
        //    "Nothing can shake my optimistic attitude.",
        //    "I quote(or misquote) sacred texts and proverbs in almost every situation.",
        //    "I am tolerant(or intolerant) of other faiths and respect (or condemn) the worship of other gods.",
        //    "I've enjoyed fine food, drink, and high society among my temple’s elite. Rough living grates on me.",
        //    "I’ve spent so long in the temple that I have little practical experience"
        //};
        public static string[] PersonalityTrait { get; set; } =
        {
            "I idolize a particular hero of my faith, and constantly refer to that person’s deeds and example.",
            "I can find common ground between the fiercest enemies, empathizing with them and always working toward peace.",
            "I see omens in every event and action. The gods try to speak to us, we just need to listen.",
            "Nothing can shake my optimistic attitude.",
            "I quote(or misquote) sacred texts and proverbs in almost every situation.",
            "I am tolerant(or intolerant) of other faiths and respect (or condemn) the worship of other gods.",
            "I've enjoyed fine food, drink, and high society among my temple’s elite. Rough living grates on me.",
            "I’ve spent so long in the temple that I have little practical experience"
        };
        public static string[] Ideal { get; set; } =
        {
            "Tradition. The ancient traditions of worship and sacrifice must be preserved and upheld. (Lawful)",
            "Charity. I always try to help those in need, no matter what the personal cost. (Good)",
            "Change. We must help bring about the changes the gods are constantly working in the world. (Chaotic)",
            "Power. I hope to one day rise to the top of my faith’s religious hierarchy. (Lawful)",
            "Faith. I trust that my deity will guide me, I have faith that if I work hard, things will go well. (Lawful)",
            "Aspiration. I seek to prove myself worthy of my god’s favor by matching my actions to their teachings. (Any)"
        };
        public static string[] Bond { get; set; } =
        {
            "I would die to recover an ancient relic of my faith that was lost long ago.",
            "I will someday get revenge on the corrupt temple hierarchy who branded me a heretic.",
            "I owe my life to the priest who took me in when my parents died.",
            "Everything I do is for the common people.",
            "I will do anything to protect the temple where I served.",
            "I seek to preserve a sacred text that my enemies consider heretical and seek to destroy."
        };
        public static string[] Flaw { get; set; } = 
        {
            "I judge others harshly, and myself even more severely.",
            "I put too much trust in those who wield power within my temple’s hierarchy.",
            "My piety sometimes leads me to blindly trust those that profess faith in my god.",
            "I am inflexible in my thinking.",
            "I am suspicious of strangers and expect the worst of them.",
            "Once I pick a goal, I become obsessed with it to the detriment of everything else in my life."
        };
        public static void AddStatics(Character character)
        {
            character.SkillProficiencies.Add("Insight");
            character.SkillProficiencies.Add("Religion");
            for (int i = 0; i < 2; i++)
            {
                BEHelper.AddLanguage(character, "background");
            }
            character.Equipment.Add("Prayer robes");
            BEHelper.AddHolySymbol(character);
            character.Equipment.Add("Prayer book or Prayer wheel");
            character.Equipment.Add("5 sticks of incense");
            character.Equipment.Add("Vestments");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 15;
            character.BackgroundFeature = "Shelter of the Faithful: you can perform religious ceremonies of your deity, you and your party can expect to receive free healing and" +
                "\n     care at a temple, shrine or other established presence, but you must provide the spell components. You (and only you) will be supported for" +
                "\n     a modest lifestyle. You have a residence at your home temple, and the priests there will provide you assistance as long as it isn't hazardous.";
        }

    }
}
