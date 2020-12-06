using System.Linq;
using AdventOfCode.Shared.Solutions;

namespace DayTwo.Solutions
{
	public class FirstSolution : ISolution
	{
		public string Solve(string[] inputs)
		{
			var valid = 0;
			foreach (var line in inputs)
			{
				var (minimum, maximum, character, password) = Parser.Parse(line);

				var amount = password.Count(x => x == character);

				if (amount >= minimum && amount <= maximum)
				{
					valid += 1;
				}
			}

			return valid.ToString();
		}
	}
}