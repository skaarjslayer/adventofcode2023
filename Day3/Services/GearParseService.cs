using Day3.Model;
using Services;

namespace Day3.Services
{
    public class GearParseService : IParseService<IEnumerable<IEnumerable<SchematicsCell>>, IEnumerable<SchematicsCell>>
    {
        public IEnumerable<SchematicsCell> Parse(IEnumerable<IEnumerable<SchematicsCell>> input)
        {
            List<SchematicsCell> gears = new List<SchematicsCell>();

            foreach (IEnumerable<SchematicsCell> row in input)
            {
                foreach (SchematicsCell cell in row)
                {
                    if (cell.Value == '*')
                    {
                        gears.Add(cell);
                    }
                }
            }

            return gears;
        }
    }
}