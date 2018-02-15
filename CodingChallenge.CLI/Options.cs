using System;
using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace CodingChallenge.CLI
{
    public class Options
    {
        [Value((0), Required = true, HelpText = "Color in first position")]
        public string FirstColor { get; set; }

        [Value((1), Required = true, HelpText = "Color in second position")]
        public string SecondColor { get; set; }

        [Value((2), Required = true, HelpText = "Color in third position (multiplier)")]
        public string ThirdColor { get; set; }

        [Value((3), Required = true, HelpText = "Color in fourth position (tolerance)")]
        public string FourthColor { get; set; }

        [Usage(ApplicationAlias = "OhmCalculator")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Normal scenario", new Options
                {
                    FirstColor = "RED",
                    SecondColor = "GREEN",
                    ThirdColor = "BLUE",
                    FourthColor = "BROWN"
                });
            }
        }
    }
}