using Services.Grid;

namespace Day3.Model
{
    public class Part
    {
        private readonly IEnumerable<SchematicCell> _cells;

        public Part(IEnumerable<SchematicCell> cells)
        {
            _cells = cells;
        }

        public int GetId()
        {
            return int.Parse(string.Concat(_cells.Select(x => x.Value)));
        }

        public bool IsValid(Grid<SchematicCell> grid)
        {
            return _cells.Any(x => grid.GetNeighbours(x).Values.Any(y => y != null && !char.IsDigit(y.Value) && y.Value != '.'));
        }
    }
}