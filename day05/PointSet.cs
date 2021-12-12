namespace day05
{
    public enum LineType { Horizontal, Vertical, Diagonal }

    public class PointSet
    {
        public PointSet() { }

        public int X1 { get; private set; }

        public int Y1 { get; private set; }

        public int X2 { get; private set; }

        public int Y2 { get; private set; }

        public LineType GetLineType()
        {
            if (this.X1 == this.X2)
            {
                return LineType.Vertical;
            }
            else if (this.Y1 == this.Y2)
            {
                return LineType.Horizontal;
            }
            
            return LineType.Diagonal;
        }

        public static PointSet FromInputLine(string input)
        {
            // example: 0,9 -> 5,9
            string[] points = input.Split("->", System.StringSplitOptions.RemoveEmptyEntries);
            
            PointSet ps = new PointSet();
            string[] parts = points[0].Split(',');
            ps.X1 = int.Parse(parts[0]);
            ps.Y1 = int.Parse(parts[1]);

            parts = points[1].Split(',');
            ps.X2 = int.Parse(parts[0]);
            ps.Y2 = int.Parse(parts[1]);

            return ps;
        }
    }
}