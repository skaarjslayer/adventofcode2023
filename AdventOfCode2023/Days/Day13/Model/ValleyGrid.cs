using Services.Grid;

namespace Day13.Model
{
    public class ValleyGrid : Grid<ValleyCell>
    {
        public ValleyGrid(IEnumerable<IEnumerable<ValleyCell>> cells) : base(cells)
        {
        }

        public int GetPointOfIncidence()
        {
            // Row-first search
            foreach (IEnumerable<ValleyCell> row in Cells)
            {
                foreach (IEnumerable<ValleyCell> otherRow in Cells.Where(x => x != row))
                {

                }
            }
        }
    }
}