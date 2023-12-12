using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Services.Grid
{
    public class Grid<TCell> : IEnumerable<TCell> where TCell : Cell
    {
        public IEnumerable<IEnumerable<TCell>> Cells { get; init; }

        public Grid(IEnumerable<IEnumerable<TCell>> cells)
        {
            Cells = cells;
        }

        public Direction GetOppositeDirection(Direction direction) => direction switch
        {
            Direction.North => Direction.South,
            Direction.NorthEast => Direction.SouthWest,
            Direction.East => Direction.West,
            Direction.SouthEast => Direction.NorthWest,
            Direction.South => Direction.North,
            Direction.SouthWest => Direction.NorthEast,
            Direction.West => Direction.East,
            Direction.NorthWest => Direction.SouthEast,
        };

        public IDictionary<Direction, TCell> GetNeighbours(TCell cell)
        {
            return new Dictionary<Direction, TCell>
            {
                { Direction.North, GetNeighbourNorth(cell) },
                { Direction.NorthEast, GetNeighbourNorthEast(cell) },
                { Direction.East, GetNeighbourEast(cell) },
                { Direction.SouthEast, GetNeighbourSouthEast(cell) },
                { Direction.South, GetNeighbourSouth(cell) },
                { Direction.SouthWest, GetNeighbourSouthWest(cell) },
                { Direction.West, GetNeighbourWest(cell) },
                { Direction.NorthWest, GetNeighbourNorthWest(cell) },
            };
        }

        public IDictionary<Direction, TCell> GetNeighboursOrthogonal(TCell cell)
        {
            return new Dictionary<Direction, TCell>
            {
                { Direction.North, GetNeighbourNorth(cell) },
                { Direction.East, GetNeighbourEast(cell) },
                { Direction.South, GetNeighbourSouth(cell) },
                { Direction.West, GetNeighbourWest(cell) },
            };
        }

        public TCell GetNeighbour(TCell cell, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return GetNeighbourNorth(cell);
                case Direction.NorthEast:
                    return GetNeighbourNorthEast(cell);
                case Direction.East:
                    return GetNeighbourEast(cell);
                case Direction.SouthEast:
                    return GetNeighbourSouthEast(cell);
                case Direction.South:
                    return GetNeighbourSouth(cell);
                case Direction.SouthWest:
                    return GetNeighbourSouthWest(cell);
                case Direction.West:
                    return GetNeighbourWest(cell);
                case Direction.NorthWest:
                    return GetNeighbourNorthWest(cell);
                default:
                    return null;
            }
        }

        public TCell GetNeighbourNorth(TCell cell)
        {
            int y = cell.Y - 1;

            if (y >= 0)
            {
                return Cells.ElementAt(y).ElementAt(cell.X);
            }

            return null;
        }

        public TCell GetNeighbourSouth(TCell cell)
        {
            int y = cell.Y + 1;

            if (y < Cells.Count())
            {
                return Cells.ElementAt(y).ElementAt(cell.X);
            }

            return null;
        }

        public TCell GetNeighbourEast(TCell cell)
        {
            int x = cell.X + 1;

            if (x < Cells.ElementAt(cell.Y).Count())
            {
                return Cells.ElementAt(cell.Y).ElementAt(x);
            }

            return null;
        }

        public TCell GetNeighbourWest(TCell cell)
        {
            int x = cell.X - 1;

            if (x >= 0)
            {
                return Cells.ElementAt(cell.Y).ElementAt(x);
            }

            return null;
        }

        public TCell GetNeighbourNorthEast(TCell cell)
        {
            TCell north = GetNeighbourNorth(cell);

            if (north != null)
            {
                TCell northeast = GetNeighbourEast(north);

                if (northeast != null)
                {
                    return northeast;
                }
            }

            return null;
        }

        public TCell GetNeighbourNorthWest(TCell cell)
        {
            TCell north = GetNeighbourNorth(cell);

            if (north != null)
            {
                TCell northwest = GetNeighbourWest(north);

                if (northwest != null)
                {
                    return northwest;
                }
            }

            return null;
        }

        public TCell GetNeighbourSouthEast(TCell cell)
        {
            TCell south = GetNeighbourSouth(cell);

            if (south != null)
            {
                TCell southeast = GetNeighbourEast(south);

                if (southeast != null)
                {
                    return southeast;
                }
            }

            return null;
        }

        public TCell GetNeighbourSouthWest(TCell cell)
        {
            TCell south = GetNeighbourSouth(cell);

            if (south != null)
            {
                TCell southwest = GetNeighbourWest(south);

                if (southwest != null)
                {
                    return southwest;
                }
            }

            return null;
        }

        public IEnumerator<TCell> GetEnumerator()
        {
            foreach(IEnumerable<TCell> row in Cells)
            {
                foreach (TCell cell in row)
                {
                    yield return cell;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}