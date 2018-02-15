using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Brains;
using CodingChallenge.Models;
using CommandLine;

namespace CodingChallenge.CLI
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return ParseArgsAndRun(args, null);
        }

        public static int ParseArgsAndRun(string[] args, Parser parser = null) 
        {
            if (parser == null)
            {
                parser = Parser.Default;
            }

            int returnCode;

            try
            {
                returnCode = parser.ParseArguments<Options>(args)
                                .MapResult(
                                       (Options opts) => CalculateFromColors(opts),
                                       errs => HandleParseErrors(errs));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error occurred: {ex.Message}");

                returnCode = (int)CLIExitCodes.UnknownError;
            }

            return returnCode;
        }

        public static int CalculateFromColors(Options opt) 
        {
            try
            {
                int ohms = new OhmValueCalculator().CalculateOhmValue(opt.FirstColor, opt.SecondColor, opt.ThirdColor, opt.FourthColor);
                Console.WriteLine(ohms.ToString());

                return (int)CLIExitCodes.Success;
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);

                return (int)CLIExitCodes.ArgumentError;
            }
        }

        public static int HandleParseErrors(IEnumerable<Error> errors)
        {
            if (errors.Any(x => x.Tag == ErrorType.HelpRequestedError))
            {
                return (int)CLIExitCodes.HelpRequested;
            }

            return (int)CLIExitCodes.ParsingError;
        }
    }
}