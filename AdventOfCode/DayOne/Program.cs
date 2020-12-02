using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DayOne
{
    public static class Program
    {
        public static async Task Main(FileInfo file = null)
        {
            file ??= new FileInfo("input.txt");
            
            var path = file.FullName;
            var firstList = await File.ReadAllLinesAsync(path);
            var secondList = firstList.Clone() as string[];

            var lhs = 0;
            var rhs = 0;

            foreach (var x in firstList)
            {
                var firstNumericValue = int.Parse(x);

                foreach (var y in secondList)
                {
                    var secondNumericValue = int.Parse(y);

                    if (firstNumericValue + secondNumericValue == 2020)
                    {
                        lhs = firstNumericValue;
                        rhs = secondNumericValue;
                    }
                }
            }


            Console.WriteLine(lhs * rhs);
        }
    }
}