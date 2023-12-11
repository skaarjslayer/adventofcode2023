using Services;
using Services.Grid;

namespace Day10.Model
{
    public class PipeCellCreateArgs
    {
        public int X { get; init; }
        public int Y { get; init; }
        public char Character { get; init; }
    }

    public class PipeCellFactory : AbstractFactory<PipeCellCreateArgs, PipeCell>
    {
        public override PipeCell Create(PipeCellCreateArgs input) => input.Character switch
        {
            '|' => new PipeCell(input.X, input.Y, new List<Direction>() { Direction.North, Direction.South }),
            '-' => new PipeCell(input.X, input.Y, new List<Direction>() { Direction.East, Direction.West }),
            'L' => new PipeCell(input.X, input.Y, new List<Direction>() { Direction.North, Direction.East }),
            'J' => new PipeCell(input.X, input.Y, new List<Direction>() { Direction.North, Direction.West }),
            '7' => new PipeCell(input.X, input.Y, new List<Direction>() { Direction.South, Direction.West }),
            'F' => new PipeCell(input.X, input.Y, new List<Direction>() { Direction.South, Direction.East }),
            'S' => new PipeCell(input.X, input.Y, new List<Direction>() { Direction.North, Direction.South, Direction.East, Direction.West }),
            _ => new PipeCell(input.X, input.Y, new List<Direction>()),
        };
    }
}