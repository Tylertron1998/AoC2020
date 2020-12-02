﻿using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Shared.Solutions;
using DayOne.Solutions;

namespace DayOne
{
    public static class Program
    {
        public static async Task Main(FileInfo file = null, Part part = Part.One)
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
                solution = new SecondSolution();
            }

            var answer = solution.Solve(lines);
            Console.WriteLine(answer);
        }
    }
}