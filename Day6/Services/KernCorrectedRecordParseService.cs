using Day6.Model;
using Services;
using System.Diagnostics;

namespace Day6.Services
{
    public class KernCorrectedRecordParseService : IParseService<string, IEnumerable<Record>>
    {
        public IEnumerable<Record> Parse(string input)
        {
            List<Record> records = new List<Record>();

            string[] parts = input.Split("\r\n");
            string[] timesData = parts.First().Split(':');
            string[] distancesData = parts.Last().Split(':');

            string times = timesData.Last().Trim(' ').Replace(" ", "");
            string distances = distancesData.Last().Trim(' ').Replace(" ", "");
            ;

            //  Debug.Assert(times.Length == distances.Length);

            //  for (int i = 0; i < times.Length; i++)
            //  {
            records.Add(new Record(long.Parse(distances), long.Parse(times)));
          //  }
        //
            return records;
        }
    }
}