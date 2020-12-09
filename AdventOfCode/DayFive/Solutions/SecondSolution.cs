using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Shared.Solutions;
using DayFive.Parsing;

namespace DayFive.Solutions
{
	public class SecondSolution : ISolution
	{
		public string Solve(string[] inputs)
		{
			var parser = new TicketParser();

			var parsed = inputs.Select(parser.Parse).ToArray();
			

			var mySeat = -1;

			var seats = new HashSet<int>(parsed.Select(x =>
			{
				var (_, _, id) = x;
				return id;
			}));

			for (var x = 0; x < ((128 * 8) + 8); x++)
			{
				if (seats.TryGetValue(x, out _))
				{
					if (seats.TryGetValue(x + 2, out _))
					{
						if (seats.TryGetValue(x + 1, out _)) continue;
						mySeat = x + 1;
					}
				}
			}

			if (mySeat == -1) throw new ArgumentException();

			return mySeat.ToString();

		}
	}
}