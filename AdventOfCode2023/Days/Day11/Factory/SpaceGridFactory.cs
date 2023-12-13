using Day11.Model;
using Services;
using Services.Grid;

namespace Day11.Factory
{
    public class SpaceGridFactory : AbstractFactory<string[], Grid<SpaceCell>>
    {
        private readonly AbstractFactory<SpaceCellCreateArgs, SpaceCell> _spaceCellFactory;

        public SpaceGridFactory(AbstractFactory<SpaceCellCreateArgs, SpaceCell> spaceCellFactory)
        {
            _spaceCellFactory = spaceCellFactory;
        }

        public override Grid<SpaceCell> Create(string[] input)
        {
            List<List<SpaceCell>> cells = new List<List<SpaceCell>>();

            int xActual = -1;
            int yActual = -1;
            for (int y = 0; y < input.Length; y++)
            {
                List<SpaceCell> rowCells = new List<SpaceCell>();
                yActual++;

                for (int x = 0; x < input[y].Length; x++)
                {
                    xActual++;
                    rowCells.Add(_spaceCellFactory.Create(new SpaceCellCreateArgs() { Character = input[y][x], X = xActual, Y = yActual }));

                    // Column expansion
                    if (!input.Any(row => IsGalaxy(row[x])))
                    {
                        xActual++;
                        rowCells.Add(_spaceCellFactory.Create(new SpaceCellCreateArgs() { Character = input[y][x], X = xActual, Y = yActual }));
                    }
                }

                cells.Add(rowCells);
                xActual = -1;

                // Row expansion
                if (!rowCells.Any(cell => IsGalaxy(cell.Character)))
                {
                    yActual++;
                    IEnumerable<SpaceCellCreateArgs> args = rowCells.Select(cell => new SpaceCellCreateArgs() { Character = '.', X = cell.X, Y = yActual });
                    cells.Add(_spaceCellFactory.CreateMany(args).ToList());
                }
            }

            return new Grid<SpaceCell>(cells);
        }

        private bool IsGalaxy(char @char)
        {
            return @char == '#';
        }
    }
}