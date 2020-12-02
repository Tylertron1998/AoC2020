using System.Linq;

namespace DayOne.Solvers
{
    public class TwoAnswerSolver : ISolver
    {
        public int Solve(string[] inputs)
        {
            var values = inputs.Select(int.Parse);
            
            foreach (var firstNumericValue in values)
            {
                foreach (var secondNumericValue in values)
                {
                    if (firstNumericValue + secondNumericValue == 2020)
                    {
                        return firstNumericValue * secondNumericValue;
                    }
                }
            }

            return default;
        }
    }
}