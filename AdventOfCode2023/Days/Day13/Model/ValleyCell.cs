using Services.Grid;

namespace Day13.Model
{
    public class ValleyCell : Cell
    {
        public char Character { get; init; }

        public ValleyCell(int x, int y, char character) : base(x, y)
        {
            Character = character;
        }
    }
}