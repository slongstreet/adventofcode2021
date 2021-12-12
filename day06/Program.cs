namespace day06
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input/sample.txt");
            List<int> fishStatus = new List<int>();
            foreach (string fish in input.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                fishStatus.Add(int.Parse(fish));
            }

            SimulateFishPopulation(fishStatus, 80);
            Console.WriteLine("[PART1] Fish population: {0}", fishStatus.Count);

            SimulateFishPopulation(fishStatus, 256-80);
            Console.WriteLine("[PART2] Fish population: {0}", fishStatus.Count);
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