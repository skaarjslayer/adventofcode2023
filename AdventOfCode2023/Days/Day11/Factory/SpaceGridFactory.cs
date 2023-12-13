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

            for (int y = 0; y < input.Length; y++)
            {
                List<SpaceCell> rowCells = new List<SpaceCell>();

                for(int x = 0; x < input[y].Length; x++)
                {
                    rowCells.Add(_spaceCellFactory.Create(new SpaceCellCreateArgs() { Character = input[y][x], X = x, Y = y }));
                }

                cells.Add(rowCells);
            }

            for (int y = 0; y < cells.Count(); y++)
            {
                if (!cells[y].Any(x => x is GalaxyCell))
                {
                    cells.Insert(y, new List<SpaceCell>(cells[y]));
                    y++;
                }
            }

            return new Grid<SpaceCell>(cells);
        }
    }
}