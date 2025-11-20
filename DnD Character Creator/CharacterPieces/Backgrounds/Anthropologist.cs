using DnD_Character_Creator.Backgrounds;
using DnD_Character_Creator.CharacterPieces.Classes;
using DnD_Character_Creator.Helper_Classes;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;

namespace DnD_Character_Creator.CharacterPieces.Backgrounds
{
    public class Anthropologist : Background
    {
        public static string[] PersonalityTrait { get; set; } = 
        {
            "I prefer the company of those who aren't like me, including people of other races.",
            "I'm a stickler when it comes to observing proper etiquette and local customs.",
            "I would rather observe than meddle.",
            "By living among violent people, I have become desensitized to violence.",
            "I would risk life and limb to discover a new culture or unravel the secrets of a dead one.",
            "When I arrive at a new settlement for the first time, I must learn all its customs."
        };
        public static string[] Ideal { get; set; } =
        {
            "Discovery. I want to be the first person to discover a lost culture. (Any)",
            "Distance. One must not interfere with the affairs of another culture – even one in need of aid. (Lawful)",
            "Knowledge. By understanding other races and cultures, we learn to understand ourselves. (Any)",
            "Power. Common people crave strong leadership, and I do my utmost to provide it. (Lawful)",
            "Protection. I must do everything possible to save a society facing extinction. (Good)",
            "Indifferent. Life is cruel. What's the point in saving people if they're going to die anyway? (Chaotic)"
        };
        public static string[] Bond { get; set; } =
        {
            "My mentor gave me a journal filled with lore and wisdom. Losing it would devastate me.",
            "Having lived among the people of a primeval tribe or clan, I long to return and see how they are faring.",
            "Years ago, tragedy struck the members of an isolated society I befriended, and I will honor them.",
            "I want to learn more about a particular humanoid culture that fascinates me.",
            "I seek to avenge a clan, tribe, kingdom, or empire that was wiped out.",
            "I have a trinket that I believe is the key to finding a long-lost society."
        };
        public static string[] Flaw { get; set; } = 
        {
            "Boats make me seasick.",
            "I talk to myself, and I don't make friends easily.",
            "I believe that I'm intellectually superior to people from other cultures and have much to teach them.",
            "I've picked up some unpleasant habits living among races such as goblins, lizardfolk, or orcs.",
            "I complain about everything.",
            "I wear a tribal mask and never take it off."
        };
        public static void AddStatics(Character character)
        {
            character.SkillProficiencies.Add("Insight");
            character.SkillProficiencies.Add("Religion");
            for (int i = 0; i < 2; i++)
            {
                BEHelper.AddLanguage(character, "background");
            }
            character.Equipment.Add("Traveler's clothes");
            character.Equipment.Add("Bottle of ink");
            character.Equipment.Add("Ink pen");
            character.Equipment.Add("Leather diary");
            character.Equipment.Add("Trinket of significance");
            character.Equipment.Add("Belt pouch for coins");
            character.GP += 10;
            character.BackgroundFeature = "Cultural Chameleon: Choose a race whose culture you've adopted." +
                "\nAdept Linguist: can communicate with humanoids who don't share a language after observing them for a day.";
        }

    }
}
