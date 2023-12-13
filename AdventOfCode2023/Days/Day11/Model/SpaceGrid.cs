using Services.Grid;

namespace Day11.Model
{
    public class SpaceGrid : Grid<SpaceCell>
    {
        public SpaceGrid(IEnumerable<IEnumerable<SpaceCell>> cells) : base(cells)
        {
        }
    }
}