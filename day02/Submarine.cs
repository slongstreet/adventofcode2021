namespace day02
{
    public enum Direction { Forward, Down, Up }

    public class Submarine
    {
        public int HorizontalPosition { get; private set; }
        public int Depth { get; private set; }
        public int Aim { get; private set; }

        public Submarine() { }

        public int Move(Direction dir, int dist)
        {
            switch (dir)
            {
                case Direction.Forward:
                    this.HorizontalPosition += dist;
                    break;

                case Direction.Down:
                    this.Depth += dist;
                    break;

                case Direction.Up:
                    this.Depth -= dist;
                    break;
            }

            return this.GetPosition();
        }

        public int MoveAdvanced(Direction dir, int dist)
        {
            switch (dir)
            {
                case Direction.Forward:
                    this.HorizontalPosition += dist;
                    if (this.Aim != 0)
                    {
                        this.Depth += dist * this.Aim;
                    }
                    break;

                case Direction.Down:
                    this.Aim += dist;
                    break;

                case Direction.Up:
                    this.Aim -= dist;
                    break;
            }

            return this.GetPosition();
        }

        public int GetPosition()
        {
            return this.HorizontalPosition * this.Depth;
        }
    }
}