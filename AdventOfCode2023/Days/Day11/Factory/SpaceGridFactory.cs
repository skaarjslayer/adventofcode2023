using Day11.Model;
using Services;

namespace Day11.Factory
{
    public class SpaceGridFactory : AbstractFactory<string[], SpaceGrid>
    {
        private readonly AbstractFactory<SpaceCellCreateArgs, SpaceCell> _spaceCellFactory;

        public SpaceGridFactory(AbstractFactory<SpaceCellCreateArgs, SpaceCell> spaceCellFactory)
        {
            _spaceCellFactory = spaceCellFactory;
        }

        public override SpaceGrid Create(string[] input)
        {
            List<List<SpaceCell>> cells = new List<List<SpaceCell>>();
            List<int> emptyRowIndices = new List<int>();
            List<int> emptyColumnIndices = new List<int>();

            for (int y = 0; y < input.Length; y++)
            {
                List<SpaceCell> rowCells = new List<SpaceCell>();

                for (int x = 0; x < input[y].Length; x++)
                {
                    rowCells.Add(_spaceCellFactory.Create(new SpaceCellCreateArgs() { Character = input[y][x], X = x, Y = y }));

                    // Column expansion
                    if (!emptyColumnIndices.Contains(x) && !input.Any(row => IsGalaxy(row[x])))
                    {
                        emptyColumnIndices.Add(x);
                    }
                }

                cells.Add(rowCells);

                // Row expansion
                if (!emptyRowIndices.Contains(y) && !rowCells.Any(cell => IsGalaxy(cell.Character)))
                {
                    emptyRowIndices.Add(y);
                }
            }

            return new SpaceGrid(cells, emptyRowIndices, emptyColumnIndices);
        }

        private bool IsGalaxy(char @char)
        {
            return @char == '#';
        }
    }
}