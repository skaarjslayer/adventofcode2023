namespace Day6.Model
{
    public class Record
    {
        public long Distance { get; init; }
        public long Time { get; init; }

        public Record(long distance, long time)
        {
            Distance = distance;
            Time = time;
        }
    }
}