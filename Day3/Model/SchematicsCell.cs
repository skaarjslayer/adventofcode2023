using Services.Grid;

namespace Day3.Model
{
    public class SchematicsCell : Cell
    {
        public char Value { get; private set; }

        public SchematicsCell(int x, int y, char value) : base(x, y)
        {
            Value = value;
        }
    }
}