using System.Linq;
using AdventOfCode.Shared.Solutions;
using DayFour.Parsing;

namespace DayFour.Solutions
{
    public class SecondSolution : ISolution
    {
        public string Solve(string[] inputs)
        {
            var parser = new Parser();
            var result = parser.Parse(inputs, ValidationType.ValidatePassportAndValues);
            return result.Count().ToString();
        }
    }
}