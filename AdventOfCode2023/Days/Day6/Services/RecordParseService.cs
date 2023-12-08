using Day6.Model;
using Services;
using System.Diagnostics;

namespace Day6.Services
{
    public class RecordParseService : IFactory<string, IEnumerable<Record>>
    {
        public IEnumerable<Record> Create(string input)
        {
            List<Record> records = new List<Record>();

            string[] parts = input.Split("\r\n");
            string[] timesData = parts.First().Split(':');
            string[] distancesData = parts.Last().Split(':');
            string[] times = timesData.Last().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            string[] distances = distancesData.Last().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            Debug.Assert(times.Length == distances.Length);

            for (int i = 0; i < times.Length; i++)
            {
                records.Add(new Record(int.Parse(distances[i]), int.Parse(times[i])));
            }

            return records;
        }
    }
}