namespace day03
{
    public class Program
    {
        static void Main(string[] args)
        {
            Diagnostician diag = new Diagnostician();
            diag.LoadData(File.ReadAllLines("input/input.txt"));
            
            int power = diag.CalculatePowerConsumption();
            Console.WriteLine("[PART1] Gamma: {0}, Epsilon: {1}, Power: {2}", diag.GammaRate, diag.EpsilonRate, power);

            int life = diag.CalculateLifeSupportRating();
            Console.WriteLine("[PART2] Life Support Rating: {0}", life);
        }

        private static void ValidateSampleInput()
        {
            Diagnostician diag = new Diagnostician();
            diag.LoadData(File.ReadAllLines("input/sample.txt"));
            int power = diag.CalculatePowerConsumption();

            Console.WriteLine("Gamma: {0}, Epsilon: {1}, Power: {2}", diag.GammaRate, diag.EpsilonRate, power);

            if (diag.RawData != null)
            {
                Console.WriteLine("Oxygen Generator Rating: {0}", diag.CalculateOxygenRating(diag.RawData, 0));
                Console.WriteLine("CO2 Scrubber Rating: {0}", diag.CalculateCO2Rating(diag.RawData, 0));
                Console.WriteLine("Life Support Rating: {0}", diag.CalculateLifeSupportRating());
            }
        }
    }
}