namespace Day5.Model
{
    public class RangeMap
    {
        public ulong DestinationStart { get; init; }
        public ulong SourceStart { get; init; }
        public ulong Length { get; init; }

        public RangeMap(ulong destinationStart, ulong sourceStart, ulong length)
        {
            DestinationStart = destinationStart;
            SourceStart = sourceStart;
            Length = length;
        }
    }
}