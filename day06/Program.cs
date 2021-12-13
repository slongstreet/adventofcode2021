namespace day06
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Program
    {
        public const int MAXAGE = 8;

        static void Main(string[] args)
        {
            string input = File.ReadAllText("input/input.txt");
            List<int> fishStatus = new List<int>();
            foreach (string fish in input.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                fishStatus.Add(int.Parse(fish));
            }

            SimulateFishPopulation(fishStatus, 80);
            Console.WriteLine("[PART1] Fish population: {0}", fishStatus.Count);

            // To avoid managing a list of billions of integers for part 2, let's just sum up how
            // many fish should be in each status every day!
            long[] fishCounter = new long[MAXAGE+1];  // all fish are 0-8 days old.

            // We already have 80 days simulated, so let's reuse the data!
            foreach (int f in fishStatus)
            {
                fishCounter[f]++;
            }

            // Now let's track the number of fish that should be in each status for the remaining days.
            for (int day = 80; day < 256; ++day)
            {
                long born = fishCounter[0];
                for (int j = 0; j < MAXAGE; ++j)
                {
                    fishCounter[j] = fishCounter[j+1];
                }
                fishCounter[6] += born;
                fishCounter[MAXAGE] = born;
            }

            Console.WriteLine("[PART2] Fish population: {0}", fishCounter.Sum());
        }

        private static void SimulateFishPopulation(List<int> fishStatus, int iterations)
        {
            for (int i = 0; i < iterations; ++i)
            {
                int newFish = 0;
                for (int j = 0; j < fishStatus.Count; ++j)
                {
                    --fishStatus[j];
                    if (fishStatus[j] < 0)
                    {
                        fishStatus[j] = 6;
                        ++newFish;
                    }
                }

                for (int n = 0; n < newFish; ++n)
                {
                    fishStatus.Add(8);
                }
            }
        }
    }
}