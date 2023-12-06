using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class GridParseService : IParseService<string, Grid<SchematicsCell>>
    {
        public Grid<SchematicsCell> Parse(string input)
        {
            List<List<SchematicsCell>> cells = new List<List<SchematicsCell>>();

            string[] rows = input.Split("\r\n");

            for (int y = 0; y < rows.Length; y++)
            {
                List<SchematicsCell> rowList = new List<SchematicsCell>();

                for (int x = 0; x < rows[y].Length; x++)
                {
                    rowList.Add(new SchematicsCell(x, y, rows[y][x]));
                }

                cells.Add(rowList);
            }

            return new Grid<SchematicsCell>(cells);
        }
    }
}