using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Backgrounds
{
    public class Background
    {
        public static string[] PersonalityTrait { get; set; } = new string[8];
        public static string[] Ideal { get; set; } = new string[6];
        public static string[] Bond { get; set; } = new string[6];
        public static string[] Flaw { get; set; } = new string[6];
        public static string[] FavoriteScam { get; protected set; } = new string[6];
        public static string[] Routine { get; protected set; } = new string[10];
        public static string[] GuildBusiness { get; protected set; } = new string[20];

    }
}
