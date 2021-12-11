namespace day02
{
    public class Program
    {
        static void Main(string[] args)
        {
            Submarine sub = new Submarine();

            foreach (string line in File.ReadAllLines("input/part1.txt"))
            {
                var command = ParseCommand(line);
                sub.Move(command.Item1, command.Item2);
            }

            Console.WriteLine("[PART1]: Final sub position: {0}.", sub.GetPosition());

            // Part 2 - Advanced movement
            sub = new Submarine();

            foreach (string line in File.ReadAllLines("input/part1.txt"))
            {
                var command = ParseCommand(line);
                sub.MoveAdvanced(command.Item1, command.Item2);
            }

            Console.WriteLine("[PART2]: Final sub position: {0}.", sub.GetPosition());
        }

        private static Tuple<Direction, int> ParseCommand(string line)
        {
            string[] parts = line.Split(' ');
            int distance;
            if (!int.TryParse(parts[1], out distance))
            {
                throw new ArgumentOutOfRangeException(String.Format("Distance argument was out of range.  Expected int.  Actual: {0}", parts[1]));
            }

            switch (parts[0].ToLower())
            {
                case "forward":
                    return new Tuple<Direction, int>(Direction.Forward, distance);

                case "down":
                    return new Tuple<Direction, int>(Direction.Down, distance);

                case "up":
                    return new Tuple<Direction, int>(Direction.Up, distance);

                default:
                    throw new ArgumentOutOfRangeException("Direction argument was out of range: {0}", parts[0]);
            }
        }

        private static void ValidateSampleInput()
        {
            Submarine sub = new Submarine();

            foreach (string line in File.ReadAllLines("input/sample.txt"))
            {
                var command = ParseCommand(line);
                sub.Move(command.Item1, command.Item2);
            }

            Console.WriteLine("Sub horizontal position: {0}.  Expected: {1}.", sub.HorizontalPosition, 15);
            Console.WriteLine("Sub depth: {0}.  Expected: {1}.", sub.Depth, 10);
            Console.WriteLine("Sub position: {0}.  Expected: {1}.", sub.GetPosition(), 150);
        }
    }
}