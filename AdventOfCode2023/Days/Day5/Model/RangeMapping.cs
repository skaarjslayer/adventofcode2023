namespace Day5.Model
{
    public class RangeMapping
    {
        public Range SourceRange { get; init; }
        public Range DestinationRange { get; init; }
        public long Offset => DestinationRange.Start - SourceRange.Start;

        public RangeMapping(Range sourceRange, Range destinationRange)
        {
            SourceRange = sourceRange;
            DestinationRange = destinationRange;
        }
    }
}