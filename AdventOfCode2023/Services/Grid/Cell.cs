namespace Services.Grid
{
    public abstract class Cell
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}