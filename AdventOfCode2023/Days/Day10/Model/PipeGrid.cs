using Services.Grid;

namespace Day10.Model
{
    public class PipeGrid : Grid<PipeCell>
    {
        public PipeCell StartingCell { get; init; }

        public PipeGrid(PipeCell startingCell, IEnumerable<IEnumerable<PipeCell>> cells) : base(cells)
        {
            StartingCell = startingCell;
        }
    }
}