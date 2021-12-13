namespace day08
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Program
    {
        static void Main(string[] args)
        {
            List<Display> displays = new List<Display>();
            displays.AddRange(File.ReadAllLines("input/input.txt").Select(line => new Display(line)));

            // Part1 - determine the frequency of unique output digits (1, 4, 7, 8).
            int uniqueDigitCount = displays.Sum(d => d.GetUniqueOutputDigitCount());
            Console.WriteLine("[PART1] The unique digits appear {0} times.", uniqueDigitCount);

            // Part2 - determine the wiring of the displays based on the information given.
            int totalSum = displays.Sum(d => d.GetOutputValue());
            Console.WriteLine("[PART2] The total output value of all displays is {0}.", totalSum);
        }
    }
}