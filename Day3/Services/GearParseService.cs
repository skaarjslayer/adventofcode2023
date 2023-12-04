using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class GearParseService : IParseService<Grid<SchematicsCell>, IEnumerable<Gear>>
    {
        public IEnumerable<Gear> Parse(Grid<SchematicsCell> input)
        {
            List<Gear> gears = new List<Gear>();

            foreach (SchematicsCell gear in input)
            {
              //  gears.Add(new Gear(gear));
            }

            return gears;
        }

        private bool IsGear(SchematicsCell cell)
        {
            return cell.CharacterValue == '*';
        }

        private bool IsValidGear(IEnumerable<SchematicsCell> cells, Grid<SchematicsCell> grid)
        {
            return cells.Any(x => grid.GetNeighbours(x).Any(y => y != null && !char.IsLetterOrDigit(y.CharacterValue) && y.CharacterValue != '.'));
        }
    }
}