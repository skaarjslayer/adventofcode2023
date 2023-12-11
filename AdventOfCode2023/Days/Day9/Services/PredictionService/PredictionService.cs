namespace Day9.Services.PredictionService
{
    public class PredictionService : IPredictionService
    {
        public int GetFuturePrediction(IEnumerable<int> sequence)
        {
            IEnumerable<int> differences = GetDifferences(sequence);

            if (differences.All(x => x == 0))
            {
                return sequence.Last() + differences.Last();
            }
            else
            {
                return sequence.Last() + GetFuturePrediction(differences);
            }
        }

        public int GetPastPrediction(IEnumerable<int> sequence)
        {
            IEnumerable<int> differences = GetDifferences(sequence);

            if (differences.All(x => x == 0))
            {
                return sequence.First() - differences.First();
            }
            else
            {
                return sequence.First() - GetPastPrediction(differences);
            }
        }

        private IEnumerable<int> GetDifferences(IEnumerable<int> sequence)
        {
            List<int> differences = new List<int>();

            for (int i = 1; i < sequence.Count(); i++)
            {
                differences.Add(sequence.ElementAt(i) - sequence.ElementAt(i - 1));
            }

            return differences;
        }
    }
}