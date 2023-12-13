using Services.Grid;

namespace Day11.Model
{
    public class SpaceCell : Cell
    {
        public char Character { get; init; }

        public SpaceCell(int x, int y, char @char) : base(x, y)
        {
            Character = @char;
        }
    }
}