using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Shared.Solutions;
using DayFour.Parsing;
using DayFour.Solutions;

namespace DayFour
{
    public static class Program
    {

        public static string TestString =
            "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980\nhcl:#623a2f\n\neyr:2029 ecl:blu cid:129 byr:1989\niyr:2014 pid:896056539 hcl:#a97842 hgt:165cm\n\nhcl:#888785\nhgt:164cm byr:2001 iyr:2015 cid:88\npid:545766238 ecl:hzl\neyr:2022\n\niyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719";
        
        public static async Task Main(FileInfo file = null, Part part = Part.Two)
        {

            var split = TestString.Split('\n');
            var parser = new Parser();
            var result = parser.Parse(split, ValidationType.ValidatePassportAndValues);

            Console.WriteLine(result.Count());
            return;
            
            
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