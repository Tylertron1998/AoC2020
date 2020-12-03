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

            var solution = default(ISolution);

            if (part == Part.One)
            {
                solution = new FirstSolution();
            }
            else if (part == Part.Two)
            {
                solution = new SecondSolution
                {
                    RightStride = new[] {1, 3, 5, 7, 1},
                    DownStride = new[] {1, 1, 1, 1, 2}
                };
            }

            var output = solution.Solve(lines);

            Console.WriteLine(output);
        }
    }
}