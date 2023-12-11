using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class GearParseService : AbstractFactory<(IEnumerable<Part> parts, Grid<SchematicsCell> grid), IEnumerable<Gear>>
    {
        public override IEnumerable<Gear> Create((IEnumerable<Part> parts, Grid<SchematicsCell> grid) input)
        {
            List<Gear> gears = new List<Gear>();

            foreach (SchematicsCell cell in input.grid)
            {
                if (IsGear(cell))
                {
                    IDictionary<Direction, SchematicsCell> neighbours = input.grid.GetNeighbours(cell);
                    HashSet<Part> relevantParts = new HashSet<Part>(input.parts.Where(x => x.Cells.Any(y => neighbours.Values.Contains(y))));

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