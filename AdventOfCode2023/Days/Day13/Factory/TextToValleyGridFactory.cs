using Day13.Model;
using Services;
using Services.Grid;

namespace Day13.Factory
{
    public class TextToValleyGridFactory : AbstractFactory<string, IEnumerable<Grid<ValleyCell>>>
    {
        private readonly AbstractFactory<string, Grid<ValleyCell>> _valleyGridFactory;

        public TextToValleyGridFactory(AbstractFactory<string, Grid<ValleyCell>> valleyGridFactory)
        {
            _valleyGridFactory = valleyGridFactory;
        }

        public override IEnumerable<Grid<ValleyCell>> Create(string input)
        {
            List<Grid<ValleyCell>> grids = new List<Grid<ValleyCell>>();

            string[] gridData = input.Split("\r\n\r\n");
            
            for (int i = 0; i < gridData.Length; i++)
            {
                grids.Add(_valleyGridFactory.Create(gridData[i]));
            }   

            return grids;
        }
    }
}