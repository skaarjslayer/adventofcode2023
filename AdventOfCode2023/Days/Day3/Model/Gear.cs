namespace Day3.Model
{
    public class Gear
    {
        public SchematicsCell Cell { get; init; }
        public IEnumerable<Part> Parts { get; init; }

        public Gear(SchematicsCell cell, IEnumerable<Part> parts)
        {
            Cell = cell;
            Parts = parts;
        }

        public int GetRatio()
        {
            return Parts.Aggregate(1, (x, y) => x * y.GetId());
        }
    }
}