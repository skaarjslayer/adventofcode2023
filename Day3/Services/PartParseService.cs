using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class PartParseService : IParseService<Grid<SchematicCell>, IEnumerable<Part>>
    {
        public IEnumerable<Part> Parse(Grid<SchematicCell> input)
        {
            List<Part> parts = new List<Part>();
            List<SchematicCell> partCodeBuffer = new List<SchematicCell>();

            foreach (SchematicCell cell in input)
            {
                if(char.IsDigit(cell.Value))
                {
                    partCodeBuffer.Add(cell);
                }
                else
                {
                    if (partCodeBuffer.Count > 0)
                    {
                        parts.Add(new Part(new List<SchematicCell>(partCodeBuffer)));
                        partCodeBuffer.Clear();
                    }
                }
            }

            return parts;
        }
    }
}