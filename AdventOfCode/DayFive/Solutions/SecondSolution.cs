using System;
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

			var ids = inputs.Select(parser.Parse).ToArray();
			

			var mySeat = -1;

			var seats = new int[128, 8];

			foreach (var (row, column, id) in ids)
			{
				if (row == 0 || row == 127) seats[row, column] = 1;
				seats[row, column] = id;
			}

			for (var x = 0; x < 128; x++)
			{
				for (var y = 0; y < 8; y++)
				{
					var seat = seats[x, y];
					if (seat == 0) mySeat = (x * 8) + y;
				}
			}
				

			if (mySeat == -1) throw new ArgumentException();

			return mySeat.ToString();

		}
	}
}