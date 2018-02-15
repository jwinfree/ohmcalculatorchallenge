using System;
using CodingChallenge.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallenge.Tests
{
    [TestClass]
    public class ColorCodesTests
    {
        [TestMethod]
        public void Test_GetColorNames()
        {
            var colors = ColorCodes.GetColorNames();

            colors.Should().NotBeNullOrEmpty();
            colors.Should().HaveCount(10);
        }

        [TestMethod]
        public void Test_Validate() 
        {
            Action act = null;

            act = () => ColorCodes.Validate("");
            act.Should().Throw<ArgumentNullException>();

            act = () => ColorCodes.Validate(String.Empty);
            act.Should().Throw<ArgumentNullException>();

            act = () => ColorCodes.Validate(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => ColorCodes.Validate("PINK");
            act.Should().Throw<ArgumentException>();

            act = () => ColorCodes.Validate("brown");
            act.Should().NotThrow();

            act = () => ColorCodes.Validate("RED");
            act.Should().NotThrow();
        }

        [TestMethod]
        public void Test_Parse() 
        {
            var result = ColorCodes.Parse("RED");
            result.Should().NotBeNull();
            result.Should().BeOfType<RedColorCode>();

            result = ColorCodes.Parse("white");
            result.Should().BeOfType<WhiteColorCode>();

            result = ColorCodes.Parse(" grey ");
            result.Should().BeOfType<GreyColorCode>();

            Action act = () => ColorCodes.Parse(String.Empty);
            act.Should().Throw<ArgumentNullException>();

            act = () => ColorCodes.Parse("CHARTREUSE");
            act.Should().Throw<ArgumentException>().And.Message.Should().Contain("Invalid color name specified");
        }

        [TestMethod]
        public void Test_ColorCode()
        {
            var black = new BlackColorCode();
            black.Name.Should().Be(ColorNames.Black);
            black.FourBand.FirstPosition.Should().Be(0);

            var red = ColorCodes.Red;
            red.Name.Should().Be(ColorNames.Red);
            red.FourBand.SecondPosition.Should().Be(2);
        }
    }
}