using System.Linq;
using AdventOfCode.Shared.Solutions;

namespace DayOne.Solutions
{
	public class SecondSolution : ISolution
	{
		public string Solve(string[] inputs)
		{
			var values = inputs.Select(int.Parse);

			foreach (var firstNumericValue in values)
			foreach (var secondNumericValue in values)
			foreach (var thirdNumericValue in values)
			{
				if (firstNumericValue + secondNumericValue + thirdNumericValue == 2020)
				{
					var answer = firstNumericValue * secondNumericValue * thirdNumericValue;
					return answer.ToString();
				}
			}

			return default;
		}
	}
}