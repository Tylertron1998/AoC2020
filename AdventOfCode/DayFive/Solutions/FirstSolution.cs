using System.Linq;
using AdventOfCode.Shared.Solutions;
using DayFive.Parsing;

namespace DayFive.Solutions
{
	public class FirstSolution : ISolution
	{
		public string Solve(string[] inputs)
		{
			var parser = new TicketParser();
			
			var ids = inputs.Select(parser.Parse).Select(x => x.Item3).OrderByDescending(id => id);

			return ids.First().ToString();

		}

	}
}