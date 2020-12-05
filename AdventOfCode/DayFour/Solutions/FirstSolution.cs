using System;
using System.CommandLine.Parsing;
using System.Linq;
using AdventOfCode.Shared.Solutions;
using Token = DayFour.Objects.Token;
using TokenType = DayFour.Objects.TokenType;

namespace DayFour.Solutions
{
    public class FirstSolution : ISolution
    {
        public string Solve(string[] inputs)
        {
            var parser = new Parser();
            var result = parser.Parse(inputs);
            return result.Count().ToString();
        }
    }
}