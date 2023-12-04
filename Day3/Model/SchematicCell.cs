using Services.Grid;

namespace Day3.Model
{
    public class SchematicCell : Cell
    {
        public char Value { get; private set; }

        public SchematicCell(int x, int y, char value) : base(x, y)
        {
            Value = value;
        }
    }
}