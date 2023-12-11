using Day9.Model;

namespace Day9.Services.PredictionService
{
    public interface IPredictionService
    {
        int GetPrediction(IEnumerable<int> sequence);
    }
}