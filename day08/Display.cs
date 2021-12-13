namespace day08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Display
    {
        public IEnumerable<string> Inputs { get; private set; }

        public IEnumerable<string> Outputs { get; private set; }

        public Display(string inputString)
        {
            string[] parts = inputString.Split('|');
            this.Inputs = parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            this.Outputs = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        public int GetUniqueOutputDigitCount()
        {
            int[] uniqueDigitLengths = new int[] { 2, 3, 4, 7 };
            return this.Outputs.Count(o => uniqueDigitLengths.Contains(o.Length));
        }

        public int GetOutputValue()
        {
            Dictionary<string, int> digitMap = new Dictionary<string, int>();
            Dictionary<int, char[]> digitKey = new Dictionary<int, char[]>();
            List<string> unknowns = new List<string>();

            // begin by loading the digit map with the digits we can identify by length
            foreach (string digit in this.Outputs.Union(this.Inputs))
            {
                switch (digit.Length)
                {
                    case 2:
                        digitMap[digit] = 1;
                        break;
                    case 3:
                        digitMap[digit] = 7;
                        digitKey[7] = digit.ToCharArray();
                        break;
                    case 4:
                        digitMap[digit] = 4;
                        digitKey[4] = digit.ToCharArray();
                        break;
                    case 7:
                        digitMap[digit] = 8;
                        break;
                    default:
                        unknowns.Add(digit);
                        break;
                }
            }

            // next deduce the unknown digits
            foreach (string unknown in unknowns)
            {
                if (digitMap.ContainsKey(unknown))
                {
                    // we've alredy deduced this digit, so skip to the next one.
                    continue;
                }

                if (unknown.Length == 5)  // length 5 candidates: 2, 3, 5
                {
                    // clue 1: only 3 shares the same segments as 7
                    if (unknown.ToCharArray().Intersect(digitKey[7]).Count() == 3)
                    {
                        digitMap[unknown] = 3;
                        continue;
                    }
                    
                    // clue 2: 5 shares 3 segments with 4; 2 shares only 2 segments
                    if (unknown.ToCharArray().Intersect(digitKey[4]).Count() == 3)
                        digitMap[unknown] = 5;
                    else digitMap[unknown] = 2;
                }
                else if (unknown.Length == 6)  // length 6 candidates: 0, 6, 9
                {
                    // clue 3: 9 shares four segments with 4; 0 and 6 do not
                    if (unknown.ToCharArray().Intersect(digitKey[4]).Count() == 4)
                    {
                        digitMap[unknown] = 9;
                        continue;
                    }

                    // clue 4: 0 shares three segments with 7; 6 does not
                    if (unknown.ToCharArray().Intersect(digitKey[7]).Count() == 3)
                        digitMap[unknown] = 0;
                    else digitMap[unknown] = 6;
                }
            }

            // finally, build the output value using the map of digits
            StringBuilder sb = new StringBuilder();
            foreach (string output in this.Outputs)
            {
                sb.Append(digitMap[output]);
            }

            return int.Parse(sb.ToString());
        }
    }
}