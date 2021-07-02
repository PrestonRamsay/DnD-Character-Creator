using DnD_Character_Creator.Helper_Classes;
using System.Collections.Generic;

namespace DnD_Character_Creator.CharacterPieces.Races
{
    public static class Dwarf
    {
        public static void Hill(Character character)
        {
            string msg = "Pick a Tool Proficiency from: Brewer's Supplies, Mason's Tools, or Smith's Tools";
            List<string> toolsList = new List<string> { "Brewer", "Mason", "Smith" };
            int index = CLIHelper.PrintChoices(msg, toolsList);
            string toolProficiency = toolsList[index];
            if (toolProficiency == "Brewer")
            {
                character.ToolProficiencies.Add("Brewer's Supplies");
            }
            else if (toolProficiency == "Mason")
            {
                character.ToolProficiencies.Add("Mason's Tools");
            }
            else
            {
                character.ToolProficiencies.Add("Smith's Tools");
            }

            character.RacialTraits.Add("Dwarven Resilience: gain Resistance to Poison, and advantage on saves vs Poison");
            character.RacialTraits.Add("Stonecunning: History checks on stonework are treated as if you are proficient and " +
                "\n        gain add your Proficiency bonus x2");
            character.RacialTraits.Add("Dwarven Toughness");
            character.MinHeight = 48;
            character.MaxHeight = 60;
            character.MinWeight = 100;
            character.MaxWeight = 200;
            character.Speed += 25;
            character.Speedstring += ", no speed penalty when wearing heavy armor";
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AlignmentOptions.Add("L-N");
            character.AdultAge = 50;
            character.MaxAgeStart = 350;
            character.Languages.Add("Dwarven");
            character.Proficiencies.Add("Battleaxes");
            character.Proficiencies.Add("Handaxes");
            character.Proficiencies.Add("Throwing Hammers");
            character.Proficiencies.Add("Warhammers");
        }
        public static void Mountain(Character character)
        {
            string msg = "Pick a Tool Proficiency from: Brewer's Supplies, Mason's Tools, or Smith's Tools";
            List<string> toolsList = new List<string> { "Brewer", "Mason", "Smith" };
            int index = CLIHelper.PrintChoices(msg, toolsList);
            string toolProficiency = toolsList[index];
            if (toolProficiency == "Brewer")
            {
                character.ToolProficiencies.Add("Brewer's Supplies");
            }
            else if (toolProficiency == "Mason")
            {
                character.ToolProficiencies.Add("Mason's Tools");
            }
            else
            {
                character.ToolProficiencies.Add("Smith's Tools");
            }

            character.RacialTraits.Add("Dwarven Resilience: gain Resistance to Poison, and Advantage on saves vs Poison");
            character.RacialTraits.Add("Stonecunning: History checks on stonework are treated as if you are proficient and " +
                "\n        gain add your Proficiency bonus x2");
            character.MinHeight = 48;
            character.MaxHeight = 60;
            character.MinWeight = 100;
            character.MaxWeight = 200;
            character.Speed += 25;
            character.Speedstring += ", no speed penalty when wearing heavy armor";
            character.Vision = "Darkvision 60ft";
            character.AlignmentOptions.Add("L-G");
            character.AlignmentOptions.Add("L-N");
            character.AdultAge = 50;
            character.MaxAgeStart = 350;
            character.Languages.Add("Dwarven");
            character.Proficiencies.Add("Light Armor");
            character.Proficiencies.Add("Medium Armor");
            character.Proficiencies.Add("Battleaxes");
            character.Proficiencies.Add("Handaxes");
            character.Proficiencies.Add("Throwing Hammers");
            character.Proficiencies.Add("Warhammers");
        }
    }
}
