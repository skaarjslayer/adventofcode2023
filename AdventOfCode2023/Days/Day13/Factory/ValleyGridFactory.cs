using Day13.Model;
using Services.Grid;
using Services;

namespace Day13.Factory
{
    public class ValleyGridFactory : AbstractFactory<string, Grid<ValleyCell>>
    {
        public override Grid<ValleyCell> Create(string input)
        {
            List<List<ValleyCell>> cells = new List<List<ValleyCell>>();

            string[] rows = input.Split("\r\n");
            cells.Add(new List<ValleyCell>());

            for (int y = 0; y < rows.Length; y++)
            {
                for (int x = 0; x < rows[y].Length; x++)
                {
                    cells[y].Add(new ValleyCell(x, y, rows[y][x]));
                }
            }

            return new Grid<ValleyCell>(cells);
        }
    }
}