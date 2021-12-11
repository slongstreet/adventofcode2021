namespace day04
{
    public class BingoCard
    {
        public struct Cell
        {
            public int Value;
            public bool IsMarked;
        }

        private BingoCard()
        {
            this.Cells = new Cell[5][];
        }

        public Cell[][] Cells { get; private set; }

        public bool HasWon { get; private set; }

        public bool MarkNumber(int number)
        {
            for (int i = 0; i < this.Cells.Length; ++i)
            {
                for (int j = 0; j < this.Cells[i].Length; ++j)
                {
                    if (this.Cells[i][j].Value == number)
                    {
                        this.Cells[i][j].IsMarked = true;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckForWin()
        {
            // 1. Check horizontal lines
            for (int i = 0; i < this.Cells.Length; ++i)
            {
                if (CheckAllCellsAreMarked(this.Cells[i]))
                {
                    this.HasWon = true;
                    return true;
                }
            }

            // 2. Check vertical lines
            for (int i = 0; i < this.Cells.Length; ++i)
            {
                if (CheckAllCellsAreMarked(new Cell[]
                    {
                        this.Cells[0][i],
                        this.Cells[1][i],
                        this.Cells[2][i],
                        this.Cells[3][i],
                        this.Cells[4][i]
                    }))
                    {
                        this.HasWon = true;
                        return true;
                    }
            }

            // 3. Check both diagonals
            /*
            if (CheckAllCellsAreMarked(new Cell[]
                {
                    this.Cells[0][0],
                    this.Cells[1][1],
                    this.Cells[2][2],
                    this.Cells[3][3],
                    this.Cells[4][4]
                }) ||
                CheckAllCellsAreMarked(new Cell[]
                {
                    this.Cells[0][4],
                    this.Cells[1][3],
                    this.Cells[2][2],
                    this.Cells[3][1],
                    this.Cells[4][0]
                }))
                return true;
            */

            return false;
        }

        public int GetScore(int numDrawn)
        {
            int sum = this.Cells.SelectMany(c => c).Where(c => !c.IsMarked).Sum(c => c.Value);
            return sum * numDrawn;
        }

        public static BingoCard FromInputStrings(string[] lines)
        {
            BingoCard card = new BingoCard();

            for (int i = 0; i < lines.Length; ++i)
            {
                card.Cells[i] = new Cell[5];
                string[] parts = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 5; ++j)
                {
                    card.Cells[i][j] = new Cell { Value = Convert.ToInt32(parts[j]) };
                }
            }

            return card;
        }

        public static bool CheckAllCellsAreMarked(IEnumerable<Cell> cells)
        {
            // If none of the provided cells are unmarked, we have a win.
            return cells.Count(c => c.IsMarked == false) == 0;
        }
    }
}