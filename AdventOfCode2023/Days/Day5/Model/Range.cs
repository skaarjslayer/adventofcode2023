namespace Day5.Model
{
    public class Range
    {
        public long Start { get; init; }
        public long End { get; init; }
        public long Length => End - Start + 1;

        public Range(long start, long end)
        {
            Start = start;
            End = end;
        }
    }
}