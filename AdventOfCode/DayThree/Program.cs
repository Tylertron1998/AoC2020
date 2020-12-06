using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Shared.Solutions;
using DayThree.Solutions;

namespace DayThree
{
	public static class Program
	{
		public static async Task Main(FileInfo file = null, Part part = Part.Two)
		{
			file ??= new FileInfo("input.txt");

			var path = file.FullName;
			var lines = await File.ReadAllLinesAsync(path);

			var solution = part switch
			{
				Part.One => new FirstSolution(),
				Part.Two => new SecondSolution
				{
					RightStride = new[] {1, 3, 5, 7, 1}, DownStride = new[] {1, 1, 1, 1, 2}
				},
				_ => default(ISolution)
			};

			var output = solution.Solve(lines);

			Console.WriteLine(output);
		}
	}
}