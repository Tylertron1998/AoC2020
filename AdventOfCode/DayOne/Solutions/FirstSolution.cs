using System.Linq;
using AdventOfCode.Shared.Solutions;

namespace DayOne.Solutions
{
    public class FirstSolution : ISolution
    {
        public string Solve(string[] inputs)
        {
            var values = inputs.Select(int.Parse);
            
            foreach (var firstNumericValue in values)
            {
                foreach (var secondNumericValue in values)
                {
                    if (firstNumericValue + secondNumericValue == 2020)
                    {
                        var answer = firstNumericValue * secondNumericValue;
                        return answer.ToString();
                    }
                }
            }

            return default;
        }
    }
}