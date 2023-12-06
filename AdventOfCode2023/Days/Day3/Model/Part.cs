namespace Day3.Model
{
    public class Part
    {
        public IEnumerable<SchematicsCell> Cells { get; init; }

        public Part(IEnumerable<SchematicsCell> cells)
        {
            Cells = cells;
        }

        public int GetId()
        {
            return int.Parse(string.Concat(Cells.Select(x => x.CharacterValue)));
        }
    }
}