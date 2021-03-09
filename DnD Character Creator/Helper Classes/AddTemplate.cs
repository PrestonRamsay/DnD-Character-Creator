using DnD_Character_Creator.Races;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Helper_Classes
{
    public static class AddTemplate
    {
        public static void TemplateBenefits(Character character, Template template)
        {
            character.TemplateProgression.AddRange(template.Milestones);
            character.Boons.AddRange(template.Boons);
            character.Flaws.AddRange(template.Flaws);
        }
    }
}
