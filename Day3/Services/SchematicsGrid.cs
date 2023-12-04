using Day3.Model;
using Services.Grid;

namespace Day3.Services
{
    public class SchematicsGrid : Grid<SchematicsCell>
    {
        private readonly Dictionary<SchematicsCell, Part> _partsLookupTable = new Dictionary<SchematicsCell, Part>();

        public SchematicsGrid(IEnumerable<IEnumerable<SchematicsCell>> cells) : base(cells)
        {
            //Parts = parts;
            //Gears = gears;
        }
    }
}