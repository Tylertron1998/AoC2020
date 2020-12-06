using AdventOfCode.Shared.Solutions;
using DayThree.Objects;

namespace DayThree.Solutions
{
	public class SecondSolution : ISolution
	{
		public int[] RightStride { get; set; }
		public int[] DownStride { get; set; }

		public string Solve(string[] inputs)
		{
			var trees = new int[RightStride.Length];

			var grid = new Grid(inputs);

			for (var i = 0; i < RightStride.Length; i++)
			{
				var localTrees = 0;

				var rightStride = RightStride[i];
				var downStride = DownStride[i];

				var boat = new Boat(grid, downStride, rightStride);

				while (!boat.HasFinished)
				{
					boat.Stride();

					if (boat.HasEncounteredTree)
					{
						localTrees += 1;
					}
				}

				trees[i] = localTrees;
			}

			long finalSum = trees[0];

			for (var i = 1; i < trees.Length; i++)
			{
				finalSum *= trees[i];
			}

			return finalSum.ToString();
		}
	}
}