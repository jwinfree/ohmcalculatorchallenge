using System;
using System.Collections.Generic;
using CodingChallenge.Models.Validation;

namespace CodingChallenge.Models
{
    public static class ColorCodes
    {
        public static BlackColorCode Black { get; } = new BlackColorCode();
        public static BrownColorCode Brown { get; } = new BrownColorCode();
        public static RedColorCode Red { get; } = new RedColorCode();
        public static OrangeColorCode Orange { get; } = new OrangeColorCode();
        public static YellowColorCode Yellow { get; } = new YellowColorCode();
        public static GreenColorCode Green { get; } = new GreenColorCode();
        public static BlueColorCode Blue { get; } = new BlueColorCode();
        public static VioletColorCode Violet { get; } = new VioletColorCode();
        public static GreyColorCode Grey { get; } = new GreyColorCode();
        public static WhiteColorCode White { get; } = new WhiteColorCode();

        private static Dictionary<string, IColorCode> ColorLookup = BuildColorCodeLookup();

        public static IColorCode Parse(string colorName) 
        {
            Validate(colorName);

            return ColorLookup[colorName.Trim().ToUpper()];
        }

        public static void Validate(string colorName)
        {
            colorName.ThrowIfNullOrEmpty(nameof(colorName));

            colorName = colorName.Trim().ToUpper();

            if (!ColorLookup.ContainsKey(colorName))
            {
                throw new ArgumentException($"Invalid color name specified. Valid values are: {ValidationExtensions.GetStringConstantValuesFormatted(typeof(ColorNames))}");
            }
        }

        public static List<string> GetColorNames() 
        {
            return typeof(ColorNames).GetStringConstants();
        }

        internal static Dictionary<string, IColorCode> BuildColorCodeLookup() 
        {
            return new Dictionary<string, IColorCode>()
            {
                {ColorNames.Black, ColorCodes.Black},
                {ColorNames.Brown, ColorCodes.Brown},
                {ColorNames.Red, ColorCodes.Red},
                {ColorNames.Orange, ColorCodes.Orange},
                {ColorNames.Yellow, ColorCodes.Yellow},
                {ColorNames.Green, ColorCodes.Green},
                {ColorNames.Blue, ColorCodes.Blue},
                {ColorNames.Violet, ColorCodes.Violet},
                {ColorNames.Grey, ColorCodes.Grey},
                {ColorNames.White, ColorCodes.White}
            };
        }
    }

    public class ColorCode : IColorCode
    {
        public string Name { get; set; }

        public FourBandValues FourBand { get; set; }
    }

    public class BlackColorCode : ColorCode
    {
        public BlackColorCode()
        {
            Name = ColorNames.Black;
            FourBand = new FourBandValues() { FirstPosition = 0, SecondPosition = 0, Multiplier = 1, Tolerance = 0 };
        }
    }

    public class BrownColorCode : ColorCode 
    {
        public BrownColorCode()
        {
            Name = ColorNames.Brown;
            FourBand = new FourBandValues() { FirstPosition = 1, SecondPosition = 1, Multiplier = 10, Tolerance = 1 };
        }
    }

    public class RedColorCode : ColorCode 
    {
        public RedColorCode()
        {
            Name = ColorNames.Red;
            FourBand = new FourBandValues() { FirstPosition = 2, SecondPosition = 2, Multiplier = 100, Tolerance = 2 };
        }
    }

    public class OrangeColorCode : ColorCode 
    {
        public OrangeColorCode()
        {
            Name = ColorNames.Orange;
            FourBand = new FourBandValues() { FirstPosition = 3, SecondPosition = 3, Multiplier = 1000, Tolerance = 3 };
        }
    }

    public class YellowColorCode : ColorCode
    {
        public YellowColorCode()
        {
            Name = ColorNames.Yellow;
            FourBand = new FourBandValues() { FirstPosition = 4, SecondPosition = 4, Multiplier = 10000, Tolerance = 4 };
        }
    }

    public class GreenColorCode : ColorCode
    {
        public GreenColorCode()
        {
            Name = ColorNames.Green;
            FourBand = new FourBandValues() { FirstPosition = 5, SecondPosition = 5, Multiplier = 100000, Tolerance = 0.5F };
        }
    }

    public class BlueColorCode : ColorCode 
    {
        public BlueColorCode()
        {
            Name = ColorNames.Blue;
            FourBand = new FourBandValues() { FirstPosition = 6, SecondPosition = 6, Multiplier = 1000000, Tolerance = 0.25F };
        }
    }

    public class VioletColorCode : ColorCode
    {
        public VioletColorCode()
        {
            Name = ColorNames.Violet;
            FourBand = new FourBandValues() { FirstPosition = 7, SecondPosition = 7, Multiplier = 10000000, Tolerance = 0.15F };
        }
    }

    public class GreyColorCode : ColorCode
    {
        public GreyColorCode()
        {
            Name = ColorNames.Grey;
            FourBand = new FourBandValues() { FirstPosition = 8, SecondPosition = 8, Multiplier = 100000000, Tolerance = 0.05F };
        }
    }

    public class WhiteColorCode : ColorCode
    {
        public WhiteColorCode()
        {
            Name = ColorNames.White;
            FourBand = new FourBandValues() { FirstPosition = 9, SecondPosition = 9, Multiplier = 1000000000, Tolerance = 0 };
        }
    }
}