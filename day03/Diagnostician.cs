namespace day03
{
    public class Diagnostician
    {
        private const string keyFormat = "{0}.{1}";

        public Diagnostician() 
        {
            this.ReportData = new Dictionary<string, int>();
            this.RawData = null;
        }

        public string[]? RawData { get; private set; }

        public int DataWidth { get; private set; }

        public int GammaRate { get; private set; }

        public int EpsilonRate { get; private set; }

        private Dictionary<string, int> ReportData { get; set; }

        public void LoadData(string[] reportLines)
        {
            this.RawData = reportLines;
            this.ReportData.Clear();

            // Process the report data to count bit frequency at each position.
            foreach (string line in reportLines)
            {
                if (this.DataWidth == 0)
                    this.DataWidth = line.Length;

                for (int i = 0; i < this.DataWidth; ++i)
                {
                    string key = string.Format(keyFormat, i, line[i]);
                    if (this.ReportData.ContainsKey(key))
                        this.ReportData[key]++;
                    else this.ReportData[key] = 1;
                }
            }
        }

        public int CalculatePowerConsumption()
        {
            // Determine the gamma and epsilon rates by evaluating the most and least common bits, respectively.
            int gamma = 0, epsilon = 0;
            for (int i = 0; i < this.DataWidth; ++i)
            {
                if (this.ReportData[string.Format(keyFormat, i, 1)] >= this.ReportData[string.Format(keyFormat, i, 0)])
                    gamma += (int)Math.Pow(2, this.DataWidth - 1 - i);
                else epsilon += (int)Math.Pow(2, this.DataWidth - 1 - i);
            }

            this.GammaRate = gamma;
            this.EpsilonRate = epsilon;

            // Finally, multiply the two rates to calculate the power consumption.
            return this.GammaRate * this.EpsilonRate;
        }

        public int CalculateOxygenRating(IEnumerable<string> samples, int position)
        {
            List<string> zeroes = new List<string>();
            List<string> ones = new List<string>();

            foreach (string str in samples)
            {
                if (str[position] == '0')
                    zeroes.Add(str);
                else ones.Add(str);
            }
            
            if (ones.Count >= zeroes.Count)
            {
                return ones.Count == 1 ? 
                    this.GetIntegerFromBinaryString(ones[0]) : 
                    this.CalculateOxygenRating(ones, position + 1);
            }
            
            return zeroes.Count == 1 ?
                this.GetIntegerFromBinaryString(zeroes[0]) :
                this.CalculateOxygenRating(zeroes, position + 1);
        }

        public int CalculateCO2Rating(IEnumerable<string> samples, int position)
        {
            List<string> zeroes = new List<string>();
            List<string> ones = new List<string>();

            foreach (string str in samples)
            {
                if (str[position] == '0')
                    zeroes.Add(str);
                else ones.Add(str);
            }
            
            if (zeroes.Count <= ones.Count)
            {
                return zeroes.Count == 1 ? 
                    this.GetIntegerFromBinaryString(zeroes[0]) : 
                    this.CalculateCO2Rating(zeroes, position + 1);
            }
            
            return ones.Count == 1 ?
                this.GetIntegerFromBinaryString(ones[0]) :
                this.CalculateCO2Rating(ones, position + 1);
        }

        public int CalculateLifeSupportRating()
        {
            if (this.RawData == null)
                return 0;

            return this.CalculateOxygenRating(this.RawData, 0) * 
                this.CalculateCO2Rating(this.RawData, 0);
        }

        private int GetIntegerFromBinaryString(string input)
        {
            int val = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '1')
                    val += (int)Math.Pow(2, input.Length - 1 - i);
            }

            return val;
        }
    }
}