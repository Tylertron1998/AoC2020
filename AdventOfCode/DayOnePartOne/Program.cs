using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DayOnePartOne
{
    public static class Program
    {
        public static async Task Main(FileInfo file = null)
        {
            file ??= new FileInfo("input.txt");
            
            var path = file.FullName;
            var lines = await File.ReadAllLinesAsync(path);
            var values = lines.Select(int.Parse);


            foreach (var firstNumericValue in values)
            {
                foreach (var secondNumericValue in values)
                {
                    if (firstNumericValue + secondNumericValue == 2020)
                    {
                        Console.WriteLine(firstNumericValue * secondNumericValue);
                        return;
                    }
                }
            }
        }
    }
}