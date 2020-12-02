using System;
using System.IO;
using System.Threading.Tasks;
using DayOne.Solvers;

namespace DayOne
{
    public static class Program
    {
        public static async Task Main(FileInfo file = null, SolverType type = SolverType.Three)
        {
            file ??= new FileInfo("input.txt");
            
            var path = file.FullName;
            var lines = await File.ReadAllLinesAsync(path);

            var solver = default(ISolver);
            
            if (type == SolverType.Two)
            {
                solver = new TwoAnswerSolver();
            } 
            else if (type == SolverType.Three)
            {
                solver = new ThreeAnswerSolver();
            }

            var output = solver.Solve(lines);
            Console.WriteLine(output);
        }
    }

    public enum SolverType
    {
        Two,
        Three
    }
}