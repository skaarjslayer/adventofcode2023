using Day9.Model;

namespace Day9.Services.PredictionService
{
    public interface IPredictionService
    {
        int GetFuturePrediction(IEnumerable<int> sequence);
        int GetPastPrediction(IEnumerable<int> sequence);
    }
}