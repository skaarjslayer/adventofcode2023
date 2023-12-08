using Services;

namespace Day5.Services
{
    public class RangeParseService : IFactory<(long start, long end), Model.Range>
    {
        public Model.Range Create((long start, long end) input)
        {
            return new Model.Range(input.start, input.end);
        }
    }
}