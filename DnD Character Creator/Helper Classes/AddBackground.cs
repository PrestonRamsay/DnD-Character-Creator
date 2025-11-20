using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.CharacterPieces.Backgrounds;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class AddBackground
    {
        public static void NewBackground(Character character)
        {
            switch (character.ChosenBackground)
            {
                case "Acolyte":
                    AddTrait(character, Acolyte.PersonalityTrait);
                    AddIdeal(character, Acolyte.Ideal);
                    AddBond(character, Acolyte.Bond);
                    AddFlaw(character, Acolyte.Flaw);
                    Acolyte.AddStatics(character);
                    break;
                case "Anthropologist":
                    AddTrait(character, Anthropologist.PersonalityTrait);
                    AddIdeal(character, Anthropologist.Ideal);
                    AddBond(character, Anthropologist.Bond);
                    AddFlaw(character, Anthropologist.Flaw);
                    Anthropologist.AddStatics(character);
                    break;
                case "Archaeologist":
                    AddTrait(character, Archaeologist.PersonalityTrait);
                    AddIdeal(character, Archaeologist.Ideal);
                    AddBond(character, Archaeologist.Bond);
                    AddFlaw(character, Archaeologist.Flaw);
                    Archaeologist.AddStatics(character);
                    break;
                case "Athlete":
                    AddTrait(character, Athlete.PersonalityTrait);
                    AddIdeal(character, Athlete.Ideal);
                    AddBond(character, Athlete.Bond);
                    AddFlaw(character, Athlete.Flaw);
                    Athlete.AddStatics(character);
                    break;
                case "Charltan":
                    AddTrait(character, Charltan.PersonalityTrait);
                    AddIdeal(character, Charltan.Ideal);
                    AddBond(character, Charltan.Bond);
                    AddFlaw(character, Charltan.Flaw);
                    Charltan.AddStatics(character);
                    break;
                case "City Watch":
                    AddTrait(character, Soldier.PersonalityTrait);
                    AddIdeal(character, Soldier.Ideal);
                    AddBond(character,  Soldier.Bond);
                    AddFlaw(character,  Soldier.Flaw);
                    CityWatch.AddStatics(character);
                    break;
                case "Clan Crafter":
                    AddTrait(character, ClanCrafter.PersonalityTrait);
                    AddIdeal(character, ClanCrafter.Ideal);
                    AddBond(character, ClanCrafter.Bond);
                    AddFlaw(character, ClanCrafter.Flaw);
                    ClanCrafter.AddStatics(character);
                    break;
                case "Cloistered Scholar":
                    AddTrait(character, CloisteredScholar.PersonalityTrait);
                    AddIdeal(character, CloisteredScholar.Ideal);
                    AddBond(character, CloisteredScholar.Bond);
                    AddFlaw(character, CloisteredScholar.Flaw);
                    CloisteredScholar.AddStatics(character);
                    break;
                case "Courtier":
                    AddTrait(character, Courtier.PersonalityTrait);
                    AddIdeal(character, Courtier.Ideal);
                    AddBond(character, Courtier.Bond);
                    AddFlaw(character, Courtier.Flaw);
                    Courtier.AddStatics(character);
                    break;
                case "Criminal":
                    AddTrait(character, Criminal.PersonalityTrait);
                    AddIdeal(character, Criminal.Ideal);
                    AddBond(character, Criminal.Bond);
                    AddFlaw(character, Criminal.Flaw);
                    Criminal.AddStatics(character);
                    break;
                case "Entertainer":
                    AddTrait(character, Entertainer.PersonalityTrait);
                    AddIdeal(character, Entertainer.Ideal);
                    AddBond(character, Entertainer.Bond);
                    AddFlaw(character, Entertainer.Flaw);
                    Entertainer.AddStatics(character);
                    break;
                case "Faceless":
                    AddTrait(character, Faceless.PersonalityTrait);
                    AddIdeal(character, Faceless.Ideal);
                    AddBond(character, Faceless.Bond);
                    AddFlaw(character, Faceless.Flaw);
                    Faceless.AddStatics(character);
                    break;
                case "Faction Agent":
                    AddTrait(character, FactionAgent.PersonalityTrait);
                    AddIdeal(character, FactionAgent.Ideal);
                    AddBond(character, FactionAgent.Bond);
                    AddFlaw(character, FactionAgent.Flaw);
                    FactionAgent.AddStatics(character);
                    break;
                case "Far Traveler":
                    AddTrait(character, FarTraveler.PersonalityTrait);
                    AddIdeal(character, FarTraveler.Ideal);
                    AddBond(character, FarTraveler.Bond);
                    AddFlaw(character, FarTraveler.Flaw);
                    FarTraveler.AddStatics(character);
                    break;
                case "Feylost":
                    AddTrait(character, Feylost.PersonalityTrait);
                    AddIdeal(character, Feylost.Ideal);
                    AddBond(character, Feylost.Bond);
                    AddFlaw(character, Feylost.Flaw);
                    Feylost.AddStatics(character);
                    break;
                case "Fisher":
                    AddTrait(character, Fisher.PersonalityTrait);
                    AddIdeal(character, Fisher.Ideal);
                    AddBond(character, Fisher.Bond);
                    AddFlaw(character, Fisher.Flaw);
                    Fisher.AddStatics(character);
                    break;
                case "Folk Hero":
                    AddTrait(character, FolkHero.PersonalityTrait);
                    AddIdeal(character, FolkHero.Ideal);
                    AddBond(character, FolkHero.Bond);
                    AddFlaw(character, FolkHero.Flaw);
                    FolkHero.AddStatics(character);
                    break;
                case "Guild Artisan":
                    AddTrait(character, GuildArtisan.PersonalityTrait);
                    AddIdeal(character, GuildArtisan.Ideal);
                    AddBond(character, GuildArtisan.Bond);
                    AddFlaw(character, GuildArtisan.Flaw);
                    GuildArtisan.AddStatics(character);
                    break;
                case "Haunted One":
                    AddTrait(character, HauntedOne.PersonalityTrait);
                    AddIdeal(character, HauntedOne.Ideal);
                    AddBond(character, HauntedOne.Bond);
                    AddFlaw(character, HauntedOne.Flaw);
                    HauntedOne.AddStatics(character);
                    break;
                case "Hermit":
                    AddTrait(character, Hermit.PersonalityTrait);
                    AddIdeal(character, Hermit.Ideal);
                    AddBond(character, Hermit.Bond);
                    AddFlaw(character, Hermit.Flaw);
                    Hermit.AddStatics(character);
                    break;
                case "House Agent":
                    AddTrait(character, HouseAgent.PersonalityTrait);
                    AddIdeal(character, HouseAgent.Ideal);
                    AddBond(character, HouseAgent.Bond);
                    AddFlaw(character, HouseAgent.Flaw);
                    HouseAgent.AddStatics(character);
                    break;
                case "Inheritor":
                    AddTrait(character, Inheritor.PersonalityTrait);
                    AddIdeal(character, Inheritor.Ideal);
                    AddBond(character, Inheritor.Bond);
                    AddFlaw(character, Inheritor.Flaw);
                    Inheritor.AddStatics(character);
                    break;
                case "Investigator":
                    AddTrait(character, Investigator.PersonalityTrait);
                    AddIdeal(character, Investigator.Ideal);
                    AddBond(character, Investigator.Bond);
                    AddFlaw(character, Investigator.Flaw);
                    Investigator.AddStatics(character);
                    break;
                case "Knight of the Order":
                    AddTrait(character, KnightOfTheOrder.PersonalityTrait);
                    AddIdeal(character, KnightOfTheOrder.Ideal);
                    AddBond(character, KnightOfTheOrder.Bond);
                    AddFlaw(character, KnightOfTheOrder.Flaw);
                    KnightOfTheOrder.AddStatics(character);
                    break;
                case "Marine":
                    AddTrait(character, Marine.PersonalityTrait);
                    AddIdeal(character, Marine.Ideal);
                    AddBond(character, Marine.Bond);
                    AddFlaw(character, Marine.Flaw);
                    Marine.AddStatics(character);
                    break;
                case "Mercenary Veteran":
                    AddTrait(character, MercenaryVeteran.PersonalityTrait);
                    AddIdeal(character, MercenaryVeteran.Ideal);
                    AddBond(character, MercenaryVeteran.Bond);
                    AddFlaw(character, MercenaryVeteran.Flaw);
                    MercenaryVeteran.AddStatics(character);
                    break;
                case "Noble":
                    AddTrait(character, Noble.PersonalityTrait);
                    AddIdeal(character, Noble.Ideal);
                    AddBond(character, Noble.Bond);
                    AddFlaw(character, Noble.Flaw);
                    Noble.AddStatics(character);
                    break;
                case "Outlander":
                    AddTrait(character, Outlander.PersonalityTrait);
                    AddIdeal(character, Outlander.Ideal);
                    AddBond(character, Outlander.Bond);
                    AddFlaw(character, Outlander.Flaw);
                    Outlander.AddStatics(character);
                    break;
                case "Sage":
                    AddTrait(character, Sage.PersonalityTrait);
                    AddIdeal(character, Sage.Ideal);
                    AddBond(character, Sage.Bond);
                    AddFlaw(character, Sage.Flaw);
                    Sage.AddStatics(character);
                    break;
                case "Sailor":
                    AddTrait(character, Sailor.PersonalityTrait);
                    AddIdeal(character, Sailor.Ideal);
                    AddBond(character, Sailor.Bond);
                    AddFlaw(character, Sailor.Flaw);
                    Sailor.AddStatics(character);
                    break;
                case "Soldier":
                    AddTrait(character, Soldier.PersonalityTrait);
                    AddIdeal(character, Soldier.Ideal);
                    AddBond(character, Soldier.Bond);
                    AddFlaw(character, Soldier.Flaw);
                    Soldier.AddStatics(character);
                    break;
                case "Shipwright":
                    AddTrait(character, Shipwright.PersonalityTrait);
                    AddIdeal(character, Shipwright.Ideal);
                    AddBond(character, Shipwright.Bond);
                    AddFlaw(character, Shipwright.Flaw);
                    Shipwright.AddStatics(character);
                    break;
                case "Smuggler":
                    AddTrait(character, Smuggler.PersonalityTrait);
                    AddIdeal(character, Smuggler.Ideal);
                    AddBond(character, Smuggler.Bond);
                    AddFlaw(character, Smuggler.Flaw);
                    Smuggler.AddStatics(character);
                    break;
                case "Urban Bounty Hunter":
                    AddTrait(character, UrbanBountyHunter.PersonalityTrait);
                    AddIdeal(character, UrbanBountyHunter.Ideal);
                    AddBond(character, UrbanBountyHunter.Bond);
                    AddFlaw(character, UrbanBountyHunter.Flaw);
                    UrbanBountyHunter.AddStatics(character);
                    break;
                case "Urchin":
                    AddTrait(character, Urchin.PersonalityTrait);
                    AddIdeal(character, Urchin.Ideal);
                    AddBond(character, Urchin.Bond);
                    AddFlaw(character, Urchin.Flaw);
                    Urchin.AddStatics(character);
                    break;

            }
        }
        //public static void PersonalCharacteristics(Character character, Background background)
        //{
        //    int traitIndex = Prompts.BackgroundPrompts("personality trait", background.PersonalityTrait);
        //    character.PersonalityTrait = background.PersonalityTrait[traitIndex];

        //    int idealIndex = Prompts.BackgroundPrompts("ideal", background.Ideal);
        //    character.Ideal = background.Ideal[idealIndex];

        //    int bondIndex = Prompts.BackgroundPrompts("bond", background.Bond);
        //    character.Bond = background.Bond[bondIndex];

        //    int flawIndex = Prompts.BackgroundPrompts("flaw", background.Flaw);
        //    character.Flaw = background.Flaw[flawIndex];
        //}
        public static void AddTrait(Character character, string[] personalityTrait)
        {
            int traitIndex = Prompts.BackgroundPrompts("personality trait", personalityTrait);
            character.PersonalityTrait = personalityTrait[traitIndex];
        }
        public static void AddIdeal(Character character, string[] ideal)
        {
            int idealIndex = Prompts.BackgroundPrompts("ideal", ideal);
            character.Ideal = ideal[idealIndex];
        }
        public static void AddBond(Character character, string[] bond)
        {
            int bondIndex = Prompts.BackgroundPrompts("bond", bond);
            character.Bond = bond[bondIndex];
        }
        public static void AddFlaw(Character character, string[] flaw)
        {
            int flawIndex = Prompts.BackgroundPrompts("flaw", flaw);
            character.Flaw = flaw[flawIndex];
        }
        //public static Background AddGHBackground(GHBackground background)
        //{
        //    var result = new Background();

        //    background.PersonalityTrait.CopyTo(result.PersonalityTrait, 0);
        //    background.Ideal.CopyTo(result.Ideal, 0);
        //    background.Bond.CopyTo(result.Bond, 0);
        //    background.Flaw.CopyTo(result.Flaw, 0);
        //    background.FavoriteScam.CopyTo(result.FavoriteScam, 0);
        //    background.Routine.CopyTo(result.Routine, 0);
        //    background.GuildBusiness.CopyTo(result.GuildBusiness, 0);

        //    return result;
        //}
    }
}
