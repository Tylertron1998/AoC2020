using System.Linq;
using AdventOfCode.Shared.Solutions;
using DayFour.Parsing;

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