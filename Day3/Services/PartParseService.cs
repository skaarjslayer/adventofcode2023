using Day3.Model;
using Services;

namespace Day3.Services
{
    public class PartParseService : IParseService<IEnumerable<IEnumerable<SchematicsCell>>, IEnumerable<IEnumerable<SchematicsCell>>>
    {
        public IEnumerable<IEnumerable<SchematicsCell>> Parse(IEnumerable<IEnumerable<SchematicsCell>> input)
        {
            List<List<SchematicsCell>> parts = new List<List<SchematicsCell>>();
            List<SchematicsCell> partBuffer = new List<SchematicsCell>();

            foreach (IEnumerable<SchematicsCell> row in input)
            {
                foreach (SchematicsCell cell in row)
                {
                    if (char.IsDigit(cell.Value))
                    {
                        partBuffer.Add(cell);
                    }
                    else
                    {
                        parts.Add(new List<SchematicsCell>(partBuffer));
                        partBuffer.Clear();
                    }
                }
            }

            return parts;
        }

        private bool IsValidPart(IEnumerable<SchematicsCell> cells, SchematicsGrid grid)
        {
            return cells.Count() > 0 && cells.Any(x => grid.GetNeighbours(x).Values.Any(y => y != null && !char.IsDigit(y.Value) && y.Value != '.'));
        }

        private int GetPartId(IEnumerable<SchematicsCell> cells)
        {
            return int.Parse(string.Concat(cells.Select(x => x.Value)));
        }
    }
}