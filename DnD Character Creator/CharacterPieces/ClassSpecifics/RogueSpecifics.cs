using DnD_Character_Creator.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.ClassSpecifics
{
    public static class RogueSpecifics
    {
        public static string RoguishArchetype { get; set; }
        public static CharacterClass Features(CharacterClass result)
        {
            int lvl = result.Lvl;
            int sneakAtkDice = 1;

            result.ClassFeatures.Add("","");

            if (lvl >= 2)
            {

            }
            if (lvl >= 3)
            {
                string msg = "Pick a Roguish Archetype that will give you features at levels 3, 9, 13, and 17.";
                var archetype = new List<string> { "Thief", "Assassin", "Arcane Trickster" };
                int input = CLIHelper.PrintChoices(msg, archetype);

                if (input == 0)
                {
                    RoguishArchetype = archetype[0];

                    if (lvl >= 3)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 9)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 13)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                }
                else if (input == 1)
                {
                    RoguishArchetype = archetype[1];

                    if (lvl >= 3)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 9)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 13)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                }
                else if (input == 2)
                {
                    RoguishArchetype = archetype[2];

                    if (lvl >= 3)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 9)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 13)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                    if (lvl >= 17)
                    {
                        result.ClassFeatures.Add("", "");
                    }
                }
            }
            if (lvl >= 5)
            {

            }
            if (lvl >= 6)
            {

            }
            if (lvl >= 7)
            {

            }
            if (lvl >= 10)
            {

            }
            if (lvl >= 11)
            {

            }
            if (lvl >= 14)
            {

            }
            if (lvl >= 15)
            {

            }
            if (lvl >= 17)
            {

            }
            if (lvl >= 18)
            {

            }
            if (lvl >= 20)
            {

            }

            return result;
        }
    }
}
