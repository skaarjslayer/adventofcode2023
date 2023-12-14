using Services.Grid;

namespace Day11.Model
{
    public class SpaceGrid : Grid<SpaceCell>
    {
        private readonly IEnumerable<int> _emptyRowIndices;
        private readonly IEnumerable<int> _emptyColumnIndices;

        public SpaceGrid(IEnumerable<IEnumerable<SpaceCell>> cells, IEnumerable<int> emptyRowIndices, IEnumerable<int> emptyColumnIndices) : base(cells)
        {
            _emptyRowIndices = emptyRowIndices;
            _emptyColumnIndices = emptyColumnIndices;
        }

        public IEnumerable<SpaceCell> GetAllGalaxies()
        {
            return Cells.SelectMany(x => x).Where(x => IsGalaxy(x.Character));
        }

        public long CalculateDistance(SpaceCell cell, SpaceCell otherCell, int cosmicExpansionRate)
        {
            long xMin = Math.Min(cell.X, otherCell.X);
            long xMax = Math.Max(cell.X, otherCell.X);
            long yMin = Math.Min(cell.Y, otherCell.Y);
            long yMax = Math.Max(cell.Y, otherCell.Y);
            long columnsCrossedCount = _emptyColumnIndices.Where(x => x >= xMin && x <= xMax).Count() * (cosmicExpansionRate - 1);
            long rowsCrossedCount = _emptyRowIndices.Where(y => y >= yMin && y <= yMax).Count() * (cosmicExpansionRate - 1);

            return (Math.Abs(cell.X - otherCell.X) + columnsCrossedCount) + (Math.Abs(cell.Y - otherCell.Y) + rowsCrossedCount);
        }

        private bool IsGalaxy(char @char)
        {
            return @char == '#';
        }
    }
}