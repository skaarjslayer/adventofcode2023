using Day3.Model;
using Services;

namespace Day3.Services
{
    public class SchematicsGridParseService : IParseService<string, SchematicsGrid>
    {
        private readonly IParseService<IEnumerable<IEnumerable<SchematicsCell>>, IEnumerable<Part>> _partParseService;

        public SchematicsGridParseService(IParseService<IEnumerable<IEnumerable<SchematicsCell>>, IEnumerable<Part>> partParseService)
        {
            _partParseService = partParseService;
        }

        public SchematicsGrid Parse(string input)
        {
            List<List<SchematicsCell>> cells = new List<List<SchematicsCell>>();
            List<Part> parts = new List<Part>();

            string[] rows = input.Split("\r\n");

            for (int y = 0; y < rows.Length; y++)
            {
                List<SchematicsCell> rowList = new List<SchematicsCell>();

                for (int x = 0; x < rows[y].Length; x++)
                {
                    if(IsGear(rows[y][x]))
                    {

                    }
                    else if(IsPartNumber())
                    rowList.Add(new SchematicsCell(x, y, rows[y][x]));
                }

                cells.Add(rowList);
            }

            SchematicsGrid grid = new SchematicsGrid(cells, _partParseService.Parse(cells));
            return new SchematicsGrid(cells);
        }

        private bool IsGear(char @char)
        {
            return @char == '*';
        }

        private bool IsPartNumber(char @char)
        {
            return char.IsDigit(@char);
        }
    }
}