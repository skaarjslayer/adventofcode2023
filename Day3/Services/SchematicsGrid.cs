using Day3.Model;
using Services.Grid;

namespace Day3.Services
{
    public class SchematicsGrid : Grid<SchematicsCell>
    {
        private readonly Dictionary<SchematicsCell, Part> _partsLookupTable = new Dictionary<SchematicsCell, Part>();

        private readonly IEnumerable<Part> _parts;
        private readonly IEnumerable<Gear> _gears;

        public SchematicsGrid(IEnumerable<IEnumerable<SchematicsCell>> cells, IEnumerable<SchematicsCell> parts, IEnumerable<SchematicsCell> gears) : base(cells)
        {
            _parts = parts;
            _gears = gears;
        }
    }
}