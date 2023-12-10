using Services;

namespace Day5.Services
{
    public class RangeParseService : AbstractFactory<(long start, long end), Model.Range>
    {
        public override Model.Range Create((long start, long end) input)
        {
            return new Model.Range(input.start, input.end);
        }
    }
}