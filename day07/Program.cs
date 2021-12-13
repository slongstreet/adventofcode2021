namespace day07
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input/input.txt");
            List<int> positionList = new List<int>();
            positionList.AddRange(input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(p => int.Parse(p)));

            int cheapestTarget = 0, cheapestFuel = int.MaxValue;

            for (int i = positionList.Min(); i <= positionList.Max(); ++i)
            {
                int fuel = CalculateFuelRequired(positionList, i);
                if (fuel < cheapestFuel)
                {
                    cheapestFuel = fuel;
                    cheapestTarget = i;
                }
            }

            Console.WriteLine("[PART1] Cheapest target is {0} with fuel cost {1}.", cheapestTarget, cheapestFuel);

            // Part 2 - modified calculation
            cheapestTarget = 0;
            cheapestFuel = int.MaxValue;

            for (int i = positionList.Min(); i <= positionList.Max(); ++i)
            {
                int fuel = CalculateUpdatedFuelRequired(positionList, i);
                if (fuel < cheapestFuel)
                {
                    cheapestFuel = fuel;
                    cheapestTarget = i;
                }
            }

            Console.WriteLine("[PART2] Cheapest target is {0} with fuel cost {1}.", cheapestTarget, cheapestFuel);
        }

        private static int CalculateFuelRequired(IEnumerable<int> positions, int target)
        {
            return positions.Select(p => Math.Abs(p - target)).Sum();
        }

        private static int CalculateUpdatedFuelRequired(IEnumerable<int> positions, int target)
        {
            return positions.Select(p => (p - target).GetTotalValue()).Sum();
        }

        // Extension method on int to calculate total value.
        // e.g. 4 => 4+3+2+1 = 10
        public static int GetTotalValue(this int input)
        {
            int sum = 0;
            for (int i = Math.Abs(input); i > 0; --i)
            {
                sum += i;
            }

            return sum;
        }
    }
}