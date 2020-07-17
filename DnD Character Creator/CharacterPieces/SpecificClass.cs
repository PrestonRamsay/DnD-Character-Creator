using DnD_Character_Creator.Races;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces
{
    public static class SpecificClass
    {
        public static CharacterClass Barbarian(CharacterClass result)
        {
            int lvl = result.Lvl;
            double numberOfRages = 2;
            int rageDamage = 2;

            result.ClassFeatures.Add("Unarmored Defense", "AC + Con, while wearing no armor");

            if (lvl > 1)
            {
                numberOfRages++;
                result.ClassFeatures.Add("", "");
                result.ClassFeatures.Add("", "");
            }
            if (lvl > 2)
            {
                numberOfRages++;
                result.ClassFeatures.Add("", "");
            }
            if (lvl > 3)
            {
                
            }
            if (lvl > 4)
            {
                result.ClassFeatures.Add("", "");
                result.ClassFeatures.Add("", "");
            }
            if (lvl > 5)
            {
                result.ClassFeatures.Add("", "");
            }
            if (lvl > 6)
            {
                numberOfRages++;
                result.ClassFeatures.Add("", "");
            }
            if (lvl > 7)
            {

            }
            if (lvl > 8)
            {
                rageDamage++;
            }
            if (lvl > 9)
            {

            }
            if (lvl > 10)
            {

            }
            if (lvl > 11)
            {
                numberOfRages++;
            }
            if (lvl > 12)
            {

            }
            if (lvl > 13)
            {

            }
            if (lvl > 14)
            {

            }
            if (lvl > 15)
            {
                numberOfRages++;
                rageDamage++;
            }
            if (lvl > 16)
            {

            }
            if (lvl > 17)
            {

            }
            if (lvl > 18)
            {
                
            }

            result.ClassFeatures.Add("Rage", $"{numberOfRages}/day: bonus, 1min, adv on Str checks/saves, Str melee dmg+{rageDamage}," +
                $"\ngain Resistance to Bludgeoning, Piercing, Slashing (end as bonus or if you don't atk or take dmg)");
            
            if (lvl > 19)
            {
                result.ClassFeatures.Remove("Rage");
                result.ClassFeatures.Add("Rage", $"(Unlimited): bonus, 1min, adv on Str checks/saves, Str melee dmg+{rageDamage}," +
                $"\ngain Resistance to Bludgeoning, Piercing, Slashing (end as bonus or if you don't atk or take dmg)");
            }

            return result;
        }
    }
}
