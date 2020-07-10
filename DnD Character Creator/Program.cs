using DnD_Character_Creator.Races;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;

namespace DnD_Character_Creator
{
    class Program
    {
        static void Main()
        {            
            CharacterCreatorCLI cli = new CharacterCreatorCLI();
            Character newCharacter = new Character();
            cli.PrintHeader();

            //cli.RunAddStats(newCharacter);
            cli.RunAddRace(newCharacter);
            cli.RunAddBackground(newCharacter);
            cli.RunGetLvl(newCharacter);
            cli.RunAddClass(newCharacter);
        }    
    }
}
