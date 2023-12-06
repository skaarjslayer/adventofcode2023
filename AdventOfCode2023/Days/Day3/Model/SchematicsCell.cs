using Services.Grid;

namespace Day3.Model
{
   public class SchematicsCell : Cell
    {
        public char CharacterValue { get; private set; }

        public SchematicsCell(int x, int y, char characterValue) : base(x, y)
        {
            CharacterValue = characterValue;
        }
    }
}