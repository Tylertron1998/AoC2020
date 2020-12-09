using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Shared.Solutions;

namespace DaySix.Solutions
{
	public class FirstSolution : ISolution
	{
		public string Solve(string[] inputs)
		{
			var groups = new List<string[]>();

			var head = 0;
			var tail = 0;
			
			foreach (var line in inputs)
			{
				if (string.IsNullOrEmpty(line))
				{
					groups.Add(inputs[head..tail]);
					tail += 1;
					head = tail;
				}
				else
				{
					tail += 1;
				}
			}
			
			groups.Add(inputs[head..tail]);

			var sum = 0;

			foreach (var group in groups)
			{
				var joined = string.Concat(group);
				sum += joined.Distinct().Count();
			}

			return sum.ToString();
		}
	}
}