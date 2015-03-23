using System;
using System.Collections.Generic;

namespace Todo
{
    public class Constants
    {
        public static Dictionary<string, string> AlcoolColors = new Dictionary<string, string>
        {
            { "Vodka", Colors.VodkaHex },
            { "Gin", Colors.GinHex },  
            { "Tequilla", Colors.TequillaHex },         
            { "Rhum", Colors.RhumHex },
            { "Whiskey", Colors.WhiskeyHex },         
            { "Bourbon", Colors.BourbonHex },
            { "Scotch", Colors.ScotchHex },     
            { "Others", Colors.OthersHex },
        };

        public static Dictionary<string, string> GlassWare = new Dictionary<string, string>
        {
            { "Champagne flute", Colors.VodkaHex },
            { "Coupe Glass", Colors.GinHex },  
            { "Highball Glass", Colors.TequillaHex },         
            { "Mason Jar", Colors.RhumHex },
            { "Mule Cup", Colors.WhiskeyHex },         
            { "Old-Fashioned Glass", Colors.BourbonHex },
            { "Pilsner Glass", Colors.ScotchHex },     
            { "Punch Bowl", Colors.OthersHex },
            { "Shot Glass", Colors.OthersHex },
            { "Tiki Mug", Colors.OthersHex },
            { "Wine Glass", Colors.OthersHex },
            { "Other", Colors.OthersHex },
        };

        public static Dictionary<string, string> Measure = new Dictionary<string, string>
        {
            { "Oz", Colors.OthersHex },
            { "Dash", Colors.OthersHex },
            { "Top", Colors.OthersHex },
            { "Tbsp.", Colors.OthersHex },
            { "--", Colors.OthersHex },
        };
    }
}

