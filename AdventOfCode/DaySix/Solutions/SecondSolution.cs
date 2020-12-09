using System.Collections.Generic;
using AdventOfCode.Shared.Solutions;

namespace DaySix.Solutions
{
	public class SecondSolution : ISolution
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
				var answers = new Dictionary<char, int>();

				foreach (var person in group)
				{
					foreach (var answer in person)
					{
						if (answers.ContainsKey(answer))
						{
							answers[answer] += 1;
						}
						else
						{
							answers.Add(answer, 1);
						}
					}
				}

				foreach (var (key, value) in answers)
				{
					if (value == group.Length) sum += 1;
				}
				
			}

			return sum.ToString();
		}
	}
}