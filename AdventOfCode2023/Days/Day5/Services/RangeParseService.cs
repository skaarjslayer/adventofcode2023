using Services;

namespace Day5.Services
{
    public class RangeParseService : IParseService<(long start, long end), Model.Range>
    {
        public Model.Range Parse((long start, long end) input)
        {
            return new Model.Range(input.start, input.end);
        }
    }
}