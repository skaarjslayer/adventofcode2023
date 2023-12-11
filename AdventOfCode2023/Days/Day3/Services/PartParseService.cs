using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class PartParseService : AbstractFactory<Grid<SchematicsCell>, IEnumerable<Part>>
    {
        public override IEnumerable<Part> Create(Grid<SchematicsCell> input)
        {
            List<Part> parts = new List<Part>();
            List<SchematicsCell> partBuffer = new List<SchematicsCell>();

            foreach (SchematicsCell cell in input)
            {
                if (IsPartNumber(cell))
                {
                    partBuffer.Add(cell);
                }
                else
                {
                    if (IsValidPart(partBuffer, input))
                    {
                        parts.Add(new Part(new List<SchematicsCell>(partBuffer)));
                    }

                    partBuffer.Clear();
                }
            }

            return parts;
        }

        private bool IsPartNumber(SchematicsCell cell)
        {
            return char.IsDigit(cell.CharacterValue);
        }

        private bool IsValidPart(IEnumerable<SchematicsCell> cells, Grid<SchematicsCell> grid)
        {
            return cells.Any(x => grid.GetNeighbours(x).Any(y => y.Value != null && !char.IsLetterOrDigit(y.Value.CharacterValue) && y.Value.CharacterValue != '.'));
        }
    }
}