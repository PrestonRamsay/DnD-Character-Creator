using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Helper_Classes
{
    public class XPDecider
    {
        public XPDecider(int lvl)
        {
            Level = lvl;
        }
        public int Level { get; set; }
        public void SetXP(Character character)
        {
            if (Level == 1)
            {
                character.XP = 0;
            }
            else if (Level == 2)
            {
                character.XP = 300;
            }
            else if (Level == 3)
            {
                character.XP = 900;
            }
            else if (Level == 4)
            {
                character.XP = 2700;
            }
            else if (Level == 5)
            {
                character.XP = 6500;
            }
            else if (Level == 6)
            {
                character.XP = 14000;
            }
            else if (Level == 7)
            {
                character.XP = 23000;
            }
            else if (Level == 8)
            {
                character.XP = 34000;
            }
            else if (Level == 9)
            {
                character.XP = 48000;
            }
            else if (Level == 10)
            {
                character.XP = 64000;
            }
            else if (Level == 11)
            {
                character.XP = 85000;
            }
            else if (Level == 12)
            {
                character.XP = 100000;
            }
            else if (Level == 13)
            {
                character.XP = 120000;
            }
            else if (Level == 14)
            {
                character.XP = 140000;
            }
            else if (Level == 15)
            {
                character.XP = 165000;
            }
            else if (Level == 16)
            {
                character.XP = 195000;
            }
            else if (Level == 17)
            {
                character.XP = 225000;
            }
            else if (Level == 18)
            {
                character.XP = 265000;
            }
            else if (Level == 19)
            {
                character.XP = 305000;
            }
            else
            {
                character.XP = 355000;
            }
        }
    }
}
