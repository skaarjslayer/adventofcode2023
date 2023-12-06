using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class GearParseService : IParseService<(IEnumerable<Part> parts, Grid<SchematicsCell> grid), IEnumerable<Gear>>
    {
        public IEnumerable<Gear> Parse((IEnumerable<Part> parts, Grid<SchematicsCell> grid) input)
        {
            List<Gear> gears = new List<Gear>();

            foreach (SchematicsCell cell in input.grid)
            {
                if (IsGear(cell))
                {
                    IEnumerable<SchematicsCell> neighbours = input.grid.GetNeighbours(cell);
                    HashSet<Part> relevantParts = new HashSet<Part>(input.parts.Where(x => x.Cells.Any(y => neighbours.Contains(y))));

                    if (relevantParts.Count() == 2)
                    {
                        gears.Add(new Gear(cell, relevantParts));
                    }
                }
            }

            return gears;
        }

        private bool IsGear(SchematicsCell cell)
        {
            return cell.CharacterValue == '*';
        }
    }
}