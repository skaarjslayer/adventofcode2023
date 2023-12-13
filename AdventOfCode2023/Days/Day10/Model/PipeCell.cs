using Services.Grid;

namespace Day10.Model
{
    public class PipeCell : Cell
    {
        public IEnumerable<Direction> Directions { get; set; }

        public PipeCell(int x, int y, IEnumerable<Direction> directions) : base(x, y)
        {
            Directions = directions;
        }
    }
}