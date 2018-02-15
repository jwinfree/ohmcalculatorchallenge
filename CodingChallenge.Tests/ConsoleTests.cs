using System;
using CodingChallenge.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingChallenge.CLI;
using CommandLine;

namespace CodingChallenge.Tests
{
    [TestClass]
    public class ConsoleTests
    {
        //For some reason the HelpWriter was blowing up during the unit tests due to 
        //an issue in the CommandLine library. Since I don't really need the help text, 
        //this is a good workaround.
        internal static Parser unitTestParser = new Parser(with => with.HelpWriter = null);

        [TestMethod]
        public void Test_ParseArgs_Sucess()
        {
            string[] args = { "GREEN", "BLUE", "BROWN", "BLACK" };

            Program.ParseArgsAndRun(args, unitTestParser).Should().Be((int)CLIExitCodes.Success);
        }

        [TestMethod]
        public void Test_ParseArgs_ParsingError()
        {
            string[] args = { "abcd", "efgh" };

            Program.ParseArgsAndRun(args, unitTestParser).Should().Be((int)(CLIExitCodes.ParsingError));
        }

        [TestMethod]
        public void Test_ParseArgs_ArgumentError()
        {
            string[] args = new string[] { "BROWN", "BLUE", "YELLER", "RED" };

            Program.ParseArgsAndRun(args, unitTestParser).Should().Be((int)(CLIExitCodes.ArgumentError));
        }

        [TestMethod]
        public void Test_Help()
        {
            var args = new string[] { "--help" };

            Program.ParseArgsAndRun(args, unitTestParser).Should().Be((int)CLIExitCodes.HelpRequested);
        }
    }
}
