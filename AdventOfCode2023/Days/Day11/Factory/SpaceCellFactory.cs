using Day11.Model;
using Services;

namespace Day11.Factory
{
    public class SpaceCellCreateArgs
    {
        public char Character { get; init; }
        public int X { get; init; }
        public int Y { get; init; }
    }

    public class SpaceCellFactory : AbstractFactory<SpaceCellCreateArgs, SpaceCell>
    {
        public override SpaceCell Create(SpaceCellCreateArgs input) => input.Character switch
        {
            '#' => new GalaxyCell(input.X, input.Y),
            _ => new SpaceCell(input.X, input.Y)
        };
    }
}