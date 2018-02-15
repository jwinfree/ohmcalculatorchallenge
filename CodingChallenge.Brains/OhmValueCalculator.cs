using System;
using CodingChallenge.Models;
using CodingChallenge.Models.Validation;

namespace CodingChallenge.Brains
{
    public class OhmValueCalculator : IOhmValueCalculator
    {
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var color1 = ColorCodes.Parse(bandAColor);
            var color2 = ColorCodes.Parse(bandBColor);
            var color3 = ColorCodes.Parse(bandCColor);
            var color4 = ColorCodes.Parse(bandDColor);

            return CalculateOhmValue(color1.FourBand.FirstPosition, color2.FourBand.SecondPosition, color3.FourBand.Multiplier);
        }

        public int CalculateOhmValue(ColorCode band1, ColorCode band2, ColorCode band3, ColorCode band4) 
        {
            band1.ThrowIfNullOrEmpty(nameof(band1));
            band2.ThrowIfNullOrEmpty(nameof(band2));
            band3.ThrowIfNullOrEmpty(nameof(band3));
            band4.ThrowIfNullOrEmpty(nameof(band4));

            return CalculateOhmValue(band1.FourBand, band2.FourBand, band3.FourBand, band4.FourBand);
        }

        public int CalculateOhmValue(FourBandValues band1, FourBandValues band2, FourBandValues band3, FourBandValues band4)
        {
            band1.ThrowIfNullOrEmpty(nameof(band1));
            band2.ThrowIfNullOrEmpty(nameof(band2));
            band3.ThrowIfNullOrEmpty(nameof(band3));
            band4.ThrowIfNullOrEmpty(nameof(band4));

            return CalculateOhmValue(band1.FirstPosition, band2.SecondPosition, band3.Multiplier);
        }

        public int CalculateOhmValue(int firstDigit, int secondDigit, int multiplier) 
        {
            return (firstDigit * 10 + secondDigit) * multiplier;
        }
    }
}