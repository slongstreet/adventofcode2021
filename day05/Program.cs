namespace day05
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Program
    {
        public const string KeyFormat = "{0},{1}";

        static void Main(string[] args)
        {
            string[] inputLines = File.ReadAllLines("input/input.txt");
            List<PointSet> points = new List<PointSet>();
            foreach (string line in inputLines)
            {
                points.Add(PointSet.FromInputLine(line));
            }

            // Part1: Only consider horizontal or vertical lines.
            Dictionary<string, int> map = new Dictionary<string, int>();
            string key;
            foreach (PointSet ps in points.Where(p => p.GetLineType() != LineType.Diagonal))
            {
                int x = ps.X1, y = ps.Y1;
                while (!(x == ps.X2 && y == ps.Y2))
                {
                    key = string.Format(KeyFormat, x, y);
                    if (!map.ContainsKey(key))
                        map.Add(key, 1);
                    else map[key]++;

                    if (ps.X1 < ps.X2)
                        ++x;
                    else if (ps.X1 > ps.X2)
                        --x;

                    if (ps.Y1 < ps.Y2)
                        ++y;
                    else if (ps.Y1 > ps.Y2)
                        --y;
                }

                // Finally, add an entry for X2,Y2.
                key = string.Format(KeyFormat, x, y);
                if (!map.ContainsKey(key))
                    map.Add(key, 1);
                else map[key]++;
            }

            int atLeastTwo = CountPointsWithMinTwoOverlaps(map);
            Console.WriteLine("[PART1] Points with at least two lines overlapping: {0}", atLeastTwo);

            // Part2: Consider diagonal lines too.
            map.Clear();
            foreach (PointSet ps in points)
            {
                int x = ps.X1, y = ps.Y1;
                while (!(x == ps.X2 && y == ps.Y2))
                {
                    key = string.Format(KeyFormat, x, y);
                    if (!map.ContainsKey(key))
                        map.Add(key, 1);
                    else map[key]++;

                    if (ps.X1 < ps.X2)
                        ++x;
                    else if (ps.X1 > ps.X2)
                        --x;

                    if (ps.Y1 < ps.Y2)
                        ++y;
                    else if (ps.Y1 > ps.Y2)
                        --y;
                }

                // Finally, add an entry for X2,Y2.
                key = string.Format(KeyFormat, x, y);
                if (!map.ContainsKey(key))
                    map.Add(key, 1);
                else map[key]++;
            }

            atLeastTwo = CountPointsWithMinTwoOverlaps(map);
            Console.WriteLine("[PART2] Points with at least two lines overlapping: {0}", atLeastTwo);
        }

        private static int CountPointsWithMinTwoOverlaps(IDictionary<string,int> map)
        {
            int atLeastTwo = 0;
            foreach (KeyValuePair<string, int> entry in map)
            {
                if (entry.Value >= 2)
                    ++atLeastTwo;
            }

            return atLeastTwo;
        }
    }
}