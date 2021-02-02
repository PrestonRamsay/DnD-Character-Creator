using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.CharacterPieces.Spells
{
    class AllSpells
    {
        public AllSpells()
        {
            Bard.Add(0, BardSpells.Cantrips);
            Bard.Add(1, BardSpells.FirstLvls);
            Bard.Add(2, BardSpells.SecondLvls);
            Bard.Add(3, BardSpells.ThirdLvls);
            Bard.Add(4, BardSpells.FourthLvls);
            Bard.Add(5, BardSpells.FifthLvls);
            Bard.Add(6, BardSpells.SixthLvls);
            Bard.Add(7, BardSpells.SeventhLvls);
            Bard.Add(8, BardSpells.EigthLvls);
            Bard.Add(9, BardSpells.NinthLvls);

            Cleric.Add(0, ClericSpells.Cantrips);
            Cleric.Add(1, ClericSpells.FirstLvls);
            Cleric.Add(2, ClericSpells.SecondLvls);
            Cleric.Add(3, ClericSpells.ThirdLvls);
            Cleric.Add(4, ClericSpells.FourthLvls);
            Cleric.Add(5, ClericSpells.FifthLvls);
            Cleric.Add(6, ClericSpells.SixthLvls);
            Cleric.Add(7, ClericSpells.SeventhLvls);
            Cleric.Add(8, ClericSpells.EigthLvls);
            Cleric.Add(9, ClericSpells.NinthLvls);

            Druid.Add(0, DruidSpells.Cantrips);
            Druid.Add(1, DruidSpells.FirstLvls);
            Druid.Add(2, DruidSpells.SecondLvls);
            Druid.Add(3, DruidSpells.ThirdLvls);
            Druid.Add(4, DruidSpells.FourthLvls);
            Druid.Add(5, DruidSpells.FifthLvls);
            Druid.Add(6, DruidSpells.SixthLvls);
            Druid.Add(7, DruidSpells.SeventhLvls);
            Druid.Add(8, DruidSpells.EigthLvls);
            Druid.Add(9, DruidSpells.NinthLvls);

            Fighter.Add(0, FighterSpells.Cantrips);
            Fighter.Add(1, FighterSpells.FirstLvls);
            Fighter.Add(2, FighterSpells.SecondLvls);
            Fighter.Add(3, FighterSpells.ThirdLvls);
            Fighter.Add(4, FighterSpells.FourthLvls);

            Paladin.Add(1, PaladinSpells.FirstLvls);
            Paladin.Add(2, PaladinSpells.SecondLvls);
            Paladin.Add(3, PaladinSpells.ThirdLvls);
            Paladin.Add(4, PaladinSpells.FourthLvls);
            Paladin.Add(5, PaladinSpells.FifthLvls);

            Ranger.Add(1, RangerSpells.FirstLvls);
            Ranger.Add(2, RangerSpells.SecondLvls);
            Ranger.Add(3, RangerSpells.ThirdLvls);
            Ranger.Add(4, RangerSpells.FourthLvls);
            Ranger.Add(5, RangerSpells.FifthLvls);

            Sorcerer.Add(0, SorcererSpells.Cantrips);
            Sorcerer.Add(1, SorcererSpells.FirstLvls);
            Sorcerer.Add(2, SorcererSpells.SecondLvls);
            Sorcerer.Add(3, SorcererSpells.ThirdLvls);
            Sorcerer.Add(4, SorcererSpells.FourthLvls);
            Sorcerer.Add(5, SorcererSpells.FifthLvls);
            Sorcerer.Add(6, SorcererSpells.SixthLvls);
            Sorcerer.Add(7, SorcererSpells.SeventhLvls);
            Sorcerer.Add(8, SorcererSpells.EigthLvls);
            Sorcerer.Add(9, SorcererSpells.NinthLvls);

            Warlock.Add(0, WarlockSpells.Cantrips);
            Warlock.Add(1, WarlockSpells.FirstLvls);
            Warlock.Add(2, WarlockSpells.SecondLvls);
            Warlock.Add(3, WarlockSpells.ThirdLvls);
            Warlock.Add(4, WarlockSpells.FourthLvls);
            Warlock.Add(5, WarlockSpells.FifthLvls);
            Warlock.Add(6, WarlockSpells.SixthLvls);
            Warlock.Add(7, WarlockSpells.SeventhLvls);
            Warlock.Add(8, WarlockSpells.EigthLvls);
            Warlock.Add(9, WarlockSpells.NinthLvls);

            Wizard.Add(0, WizardSpells.Cantrips);
            Wizard.Add(1, WizardSpells.FirstLvls);
            Wizard.Add(2, WizardSpells.SecondLvls);
            Wizard.Add(3, WizardSpells.ThirdLvls);
            Wizard.Add(4, WizardSpells.FourthLvls);
            Wizard.Add(5, WizardSpells.FifthLvls);
            Wizard.Add(6, WizardSpells.SixthLvls);
            Wizard.Add(7, WizardSpells.SeventhLvls);
            Wizard.Add(8, WizardSpells.EigthLvls);
            Wizard.Add(9, WizardSpells.NinthLvls);
        }
        public Dictionary<int, List<string>> Bard { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Cleric { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Druid { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Fighter { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Paladin { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Ranger { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Sorcerer { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Warlock { get; set; } = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> Wizard { get; set; } = new Dictionary<int, List<string>>();
    }
}
