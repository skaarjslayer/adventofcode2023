using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class GridParseService : IParseService<string, Grid<SchematicCell>>
    {
        public Grid<SchematicCell> Parse(string input)
        {
            List<List<SchematicCell>> cells = new List<List<SchematicCell>>();

            string[] rows = input.Split("\r\n");

            for (int y = 0; y < rows.Length; y++)
            {
                List<SchematicCell> rowList = new List<SchematicCell>();

                for (int x = 0; x < rows[y].Length; x++)
                {
                    rowList.Add(new SchematicCell(x, y, rows[y][x]));
                }

                cells.Add(rowList);
            }

            return new Grid<SchematicCell>(cells);
        }
    }
}