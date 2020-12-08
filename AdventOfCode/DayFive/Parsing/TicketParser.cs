using System;

namespace DayFive.Parsing
{
	public class TicketParser
	{
		public (int, int, int) Parse(string input)
		{
			var rowString = input[..^3];
			var columnString = input[^3..];

			var row = ParseRowString(rowString);
			var column = ParseColumnString(columnString);

			var id = (row * 8) + column;

			return (row, column, id);
		}

		private int ParseRowString(string input)
		{
			var a = input.Replace('F', '0');
			var b = a.Replace('B', '1');

			return Convert.ToInt32(b, 2);
		}

		private int ParseColumnString(string input)
		{
			var a = input.Replace('L', '0');
			var b = a.Replace('R', '1');

			return Convert.ToInt32(b, 2);
		}
	}
}