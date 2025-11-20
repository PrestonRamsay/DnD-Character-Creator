
namespace DnD_Character_Creator
{
    class Program
    {
        static void Main()
        {
            bool creatingCharacter = true;
            CharacterCreatorCLI cli = new CharacterCreatorCLI();
            cli.PrintHeader();

            while (creatingCharacter)
            {
                cli = new CharacterCreatorCLI();
                Character newCharacter = new Character();

                //cli.RunGetLvl(newCharacter);
                //cli.RunAddStats(newCharacter);
                //cli.RunAddRace(newCharacter);
                ////cli.RunAddTemplate(newCharacter);
                cli.RunAddBackground(newCharacter);
                //cli.RunAddClass(newCharacter);
                cli.WriteCharacterToDocument(newCharacter);

                creatingCharacter = cli.FinalPrompt();
            }
        }    
    }
}
