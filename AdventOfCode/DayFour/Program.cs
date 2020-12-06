using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Shared.Solutions;
using DayFour.Solutions;

namespace DayFour
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
				Part.Two => new SecondSolution(),
				_ => default(ISolution)
			};

			var answer = solution.Solve(lines);

			Console.WriteLine(answer);
		}
	}
}