using Day10.Model;
using Services;

namespace Day10.Factory
{
    public class PipeGridFactory : AbstractFactory<string[], PipeGrid>
    {
        private readonly PipeCellFactory _pipeGridCellFactory;

        public PipeGridFactory(PipeCellFactory pipeGridCellFactory)
        {
            _pipeGridCellFactory = pipeGridCellFactory;
        }

        public override PipeGrid Create(string[] input)
        {
            List<List<PipeCell>> cells = new List<List<PipeCell>>();
            PipeCell startingCell = null;

            int x = 0;
            int y = 0;
            foreach (string row in input)
            {
                List<PipeCell> cellRow = new List<PipeCell>();
                cells.Add(cellRow);

                foreach (char @char in row)
                {
                    PipeCell cell = _pipeGridCellFactory.Create(new PipeCellCreateArgs() { X = x, Y = y, Character = @char });

                    if (@char == 'S')
                    {
                        startingCell = cell;
                    }

                    cellRow.Add(cell);
                    x++;
                }

                y++;
                x = 0;
            }

            return new PipeGrid(startingCell, cells);
        }
    }
}