namespace day01
{
    public class Program 
    {
        static void Main(string[] args)
        {
            // Build depth set from Part1 input file.
            var rawInput = File.ReadAllText("input/part1.txt");
            DepthSet depthSet = DepthSet.FromRawText(rawInput);

            // Count the number of depth increasees.
            Console.WriteLine("[PART1]: Num increases: {0}.", depthSet.CountDepthIncreases());

            // Reuse depth set from Part1 input to calculate window depth increases.
            Console.WriteLine("[PART2]: Num window increases: {0}.", depthSet.CountSlidingWindowIncreases());
        }

        private static void ValidateSampleInput()
        {
            var rawInput = File.ReadAllText("input/sample.txt");
            DepthSet depthSet = DepthSet.FromRawText(rawInput);

            Console.WriteLine("Num increases: {0}.  Expected: {1}.", depthSet.CountDepthIncreases(), 7);
            Console.WriteLine("Num window increases: {0}.  Expected: {1}.", depthSet.CountSlidingWindowIncreases(), 5);
        }
    }
}