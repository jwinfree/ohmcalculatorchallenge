using System;

namespace CodingChallenge.Models
{
    public enum CLIExitCodes
    {
        UnknownError = -1,
        Success = 0,
        ParsingError = 1,
        ArgumentError = 2,
        HelpRequested = 10
    }
}