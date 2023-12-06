namespace Day1.Model
{
    public class Calibration
    {
        private string _input = string.Empty;

        public Calibration(string input)
        {
            _input = input;
        }

        public override string ToString()
        {
            return _input;
        }
    }
}