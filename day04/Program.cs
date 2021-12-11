namespace day04
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input/input.txt");
            
            IEnumerable<BingoCard> cards = CreateCardsFromInput(lines.Skip(1).ToArray());

            // Turn the first line of input in an array of numbers.
            IEnumerable<int> numbers = lines[0].Split(',').Select(x => Convert.ToInt32(x));
            foreach (int num in numbers)
            {
                foreach (BingoCard card in cards)
                {
                    if (!card.HasWon && card.MarkNumber(num) && card.CheckForWin())
                    {
                        Console.WriteLine("Winning card found on number {0}! Score: {1}", num, card.GetScore(num));
                    }
                }
            }
        }

        static IEnumerable<BingoCard> CreateCardsFromInput(string[] inputLines)
        {
            List<BingoCard> cards = new List<BingoCard>();
            int i = 0;
            while (i < inputLines.Length)
            {
                if (inputLines[i] == string.Empty)
                {
                    ++i;
                    continue;
                }
                
                cards.Add(BingoCard.FromInputStrings(inputLines.Skip(i).Take(5).ToArray()));
                i += 5;
            }

            return cards;
        }
    }
}