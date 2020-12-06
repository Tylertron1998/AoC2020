using System;

namespace DayTwo
{
	public static class Parser
	{
		public static (int minimum, int maximum, char character, string password) Parse(ReadOnlySpan<char> input)
		{
			var index = input.IndexOf(":");
			var rule = input[..index].Trim();
			var password = input[(index + 1)..].Trim();

			var ruleIndex = rule.IndexOf(" ");
			var range = rule[..ruleIndex];
			var ruleChar = rule[^1];

			var rangeIndex = range.IndexOf("-");
			var minimum = int.Parse(range[..rangeIndex]);
			var maxmimum = int.Parse(range[(rangeIndex + 1)..]);

			return (minimum, maxmimum, ruleChar, password.ToString());
		}
	}
}