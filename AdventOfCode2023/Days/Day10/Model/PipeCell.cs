using Services.Grid;

namespace Day10.Model
{
    public class PipeCell : Cell
    {
        public IEnumerable<Direction> Directions { get; set; }

        public PipeCell(int x, int y, IEnumerable<Direction> directions) : base(x, y)
        {
            Directions = directions;
        }

        public static bool IsValidConnection(Direction direction, PipeCell cell)
        {
            switch (direction)
            {
                case Direction.North:
                    return cell.Directions.Any(x => x == Direction.South);
                case Direction.South:
                    return cell.Directions.Any(x => x == Direction.North);
                case Direction.West:
                    return cell.Directions.Any(x => x == Direction.East);
                case Direction.East:
                    return cell.Directions.Any(x => x == Direction.West);
                default:
                    return false;
            }
        }
    }
}