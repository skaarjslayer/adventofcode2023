namespace Day12.Model
{
    public class SpringSet
    {
        public string Springs { get; init; }
        public List<int> DamagedGroups { get; init; }

        public override bool Equals(object? obj)
        {
            SpringSet springSet = obj as SpringSet;

            if (springSet == null)
            {
                return false;
            }

            return springSet.Springs == Springs && springSet.DamagedGroups.SequenceEqual(DamagedGroups);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Springs.GetHashCode();

                foreach (int group in DamagedGroups)
                {
                    hash = hash * 23 + group.GetHashCode();
                }

                return hash;
            }
        }
    }
}