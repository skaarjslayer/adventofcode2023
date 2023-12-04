using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Services.Grid
{
    public class Grid<TCell> : IEnumerable<TCell> where TCell : Cell
    {
        public enum GridDirection
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest
        }

        protected readonly IEnumerable<IEnumerable<TCell>> _cells;

        public Grid(IEnumerable<IEnumerable<TCell>> cells)
        {
            _cells = cells;
        }

        public IReadOnlyDictionary<GridDirection, TCell> GetNeighbours(TCell cell)
        {
            return new Dictionary<GridDirection, TCell>
            {
                { GridDirection.North, GetNeighbourNorth(cell) },
                { GridDirection.NorthEast, GetNeighbourNorthEast(cell) },
                { GridDirection.East, GetNeighbourEast(cell) },
                { GridDirection.SouthEast, GetNeighbourSouthEast(cell) },
                { GridDirection.South, GetNeighbourSouth(cell) },
                { GridDirection.SouthWest, GetNeighbourSouthWest(cell) },
                { GridDirection.West, GetNeighbourWest(cell) },
                { GridDirection.NorthWest, GetNeighbourNorthWest(cell) },
            };
        }

        public IReadOnlyDictionary<GridDirection, TCell> GetNeighboursOrthogonal(TCell cell)
        {
            return new Dictionary<GridDirection, TCell>
            {
                { GridDirection.North, GetNeighbourNorth(cell) },
                { GridDirection.East, GetNeighbourEast(cell) },
                { GridDirection.South, GetNeighbourSouth(cell) },
                { GridDirection.West, GetNeighbourWest(cell) },
            };
        }

        public TCell GetNeighbourNorth(TCell cell)
        {
            int y = cell.Y - 1;

            if (y >= 0)
            {
                return _cells.ElementAt(y).ElementAt(cell.X);
            }

            return null;
        }

        public TCell GetNeighbourSouth(TCell cell)
        {
            int y = cell.Y + 1;

            if (y < _cells.Count())
            {
                return _cells.ElementAt(y).ElementAt(cell.X);
            }

            return null;
        }

        public TCell GetNeighbourEast(TCell cell)
        {
            int x = cell.X + 1;

            if (x < _cells.ElementAt(cell.Y).Count())
            {
                return _cells.ElementAt(cell.Y).ElementAt(x);
            }

            return null;
        }

        public TCell GetNeighbourWest(TCell cell)
        {
            int x = cell.X - 1;

            if (x > 0)
            {
                return _cells.ElementAt(cell.Y).ElementAt(x);
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
            foreach(IEnumerable<TCell> row in _cells)
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