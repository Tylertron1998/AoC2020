using System;
using AdventOfCode.Shared.Solutions;

namespace DayTwo.Solutions
{
    public class SecondSolution : ISolution
    {
        public string Solve(string[] inputs)
        {
            var valid = 0;
            foreach (var input in inputs)
            {
                var (firstPos, secondPos, character, password) = Parser.Parse(input);

                firstPos -= 1; // the input is non zero index based.
                secondPos -= 1;

                var firstFound = password[firstPos] == character;
                var secondFound = password[secondPos] == character;

                if ((firstFound && !secondFound) || (secondFound && !firstFound))
                {
                    valid += 1;
                }
            }

            return valid.ToString();
        }
    }
}