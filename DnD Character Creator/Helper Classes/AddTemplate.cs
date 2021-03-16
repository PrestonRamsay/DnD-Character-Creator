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
            foreach (var item in template.Boons.Keys)
            {
                character.Boons.Add(item, template.Boons[item]);
            }
            foreach (var item in template.Flaws.Keys)
            {
                character.Flaws.Add(item, template.Flaws[item]);
            }
        }
    }
}
