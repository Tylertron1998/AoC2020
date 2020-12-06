using AdventOfCode.Shared.Solutions;
using DayThree.Objects;

namespace DayThree.Solutions
{
	public class FirstSolution : ISolution
	{
		public string Solve(string[] inputs)
		{
			var grid = new Grid(inputs);
			var boat = new Boat(grid);

			var trees = 0;

			while (!boat.HasFinished)
			{
				boat.Stride();

				if (boat.HasEncounteredTree)
				{
					trees += 1;
				}
			}

			return trees.ToString();
		}
	}
}