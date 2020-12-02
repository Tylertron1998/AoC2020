using System.Linq;

namespace DayOne.Solvers
{
    public class ThreeAnswerSolver : ISolver
    {
        public int Solve(string[] inputs)
        {
            var values = inputs.Select(int.Parse);
            
            foreach (var firstNumericValue in values)
            {
                foreach (var secondNumericValue in values)
                {
                    foreach (var thirdNumericValue in values)
                    {
                        if (firstNumericValue + secondNumericValue + thirdNumericValue == 2020)
                        {
                            return firstNumericValue * secondNumericValue * thirdNumericValue;
                        }
                    }
                }
            }

            return default;
        }
    }
}