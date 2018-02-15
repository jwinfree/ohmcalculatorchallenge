using System;
using CodingChallenge.Brains;
using CodingChallenge.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallenge.Tests
{
    [TestClass]
    public class OhmValueCalculatorTests
    {
        [TestMethod]
        public void Test_CalculateOhmValue_FromStrings_Validation() 
        {
            Action act = null;
            var calc = new OhmValueCalculator();

            act = () => calc.CalculateOhmValue("", "", "", "");
            act.Should().Throw<ArgumentNullException>();

            act = () => calc.CalculateOhmValue("RED", "", "", "");
            act.Should().Throw<ArgumentNullException>();

            act = () => calc.CalculateOhmValue("RED", "BROWN", "", "");
            act.Should().Throw<ArgumentNullException>();

            act = () => calc.CalculateOhmValue("RED", "BROWN", "BLUE", "");
            act.Should().Throw<ArgumentNullException>();

            act = () => calc.CalculateOhmValue("AQUA", "BROWN", "RED", "BLUE");
            act.Should().Throw<ArgumentException>();

            act = () => calc.CalculateOhmValue("RED", "BROWN", "BLUE", "BLACK");
            act.Should().NotThrow();
        }

        [TestMethod]
        public void Test_CalculateOhmValue_FromColorCode_Validation()
        {
            Action act = null;
            var calc = new OhmValueCalculator();

            act = () => calc.CalculateOhmValue(ColorCodes.Black, null, null, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => calc.CalculateOhmValue(ColorCodes.Black, ColorCodes.Brown, null, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => calc.CalculateOhmValue(ColorCodes.Black, ColorCodes.Blue, ColorCodes.Red, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => calc.CalculateOhmValue(ColorCodes.Black, ColorCodes.Blue, ColorCodes.Red, ColorCodes.Brown);
            act.Should().NotThrow();
        }

        [TestMethod]
        public void Test_CalculateOhmValue_FromFourBandValues_Validation()
        {
            Action act = null;
            var calc = new OhmValueCalculator();

            act = () => calc.CalculateOhmValue(ColorCodes.Black.FourBand, null, null, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => calc.CalculateOhmValue(ColorCodes.Black.FourBand, ColorCodes.Brown.FourBand, null, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => calc.CalculateOhmValue(ColorCodes.Black.FourBand, ColorCodes.Blue.FourBand, ColorCodes.Red.FourBand, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => calc.CalculateOhmValue(ColorCodes.Black.FourBand, ColorCodes.Blue.FourBand, ColorCodes.Red.FourBand, ColorCodes.Brown.FourBand);
            act.Should().NotThrow();
        }
    }
}