namespace Day5.Model
{
    public class RangeMap
    {
        public long DestinationStart { get; init; }
        public long SourceStart { get; init; }
        public long SourceEnd => SourceStart + Length - 1;
        public long DestinationEnd => DestinationStart + Length - 1;
        public long Length { get; init; }

        public RangeMap(long destinationStart, long sourceStart, long length)
        {
            DestinationStart = destinationStart;
            SourceStart = sourceStart;
            Length = length;
        }
    }
}