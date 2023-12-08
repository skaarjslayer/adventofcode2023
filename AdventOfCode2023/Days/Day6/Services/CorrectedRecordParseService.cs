using Day6.Model;
using Services;

namespace Day6.Services
{
    public class CorrectedRecordParseService : IFactory<string, Record>
    {
        public Record Create(string input)
        {
            string[] parts = input.Split("\r\n");
            string[] timesData = parts.First().Split(':');
            string[] distancesData = parts.Last().Split(':');
            string time = timesData.Last().Trim(' ').Replace(" ", "");
            string distance = distancesData.Last().Trim(' ').Replace(" ", "");

            return new Record(long.Parse(distance), long.Parse(time));
        }
    }
}