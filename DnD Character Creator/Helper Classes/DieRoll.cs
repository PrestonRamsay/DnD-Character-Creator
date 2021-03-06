﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator
{
    class DieRoll
    {
        public int NumberOfSides { get; private set; }
        public Random Rng { get; private set; }
        public DieRoll(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
            Rng = new Random();
        }
        public int RollDie()
        {
            return Rng.Next(1, NumberOfSides + 1);
        }
    }
}
