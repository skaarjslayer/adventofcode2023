namespace Day12.Model
{
    /// <summary>
    /// Represents information pertaining to a particular group of springs such as the
    /// status of each spring, how many groups of damaged springs there, and how many
    /// damaged springs are in each group.
    /// </summary>
    public class SpringInfo
    {
        #region Properties

        public string Springs { get; init; }
        public IEnumerable<int> KnownDamagedGroups { get; init; }

        #endregion Properties

        #region Constructors

        public SpringInfo(string springs, IEnumerable<int> knownDamagedGroups)
        {
            Springs = springs;
            KnownDamagedGroups = knownDamagedGroups;
        }

        #endregion Constructors

        #region Object Overrides

        /// <summary>
        /// Overrides the default Equals method to return true if the SpringInfo object's properties are equal to the given object's properties.
        /// </summary>
        /// <param name="obj">The object we are comparing to.</param>
        /// <returns>A flag indicating whether or not the two objects are equal.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is SpringInfo springInfo)
            {
                return springInfo.Springs == Springs && springInfo.KnownDamagedGroups.SequenceEqual(KnownDamagedGroups);
            }

            return false;
        }

        /// <summary>
        /// Overrides the default GetHashCode method to return a hash code based on the SpringInfo object's properties.
        /// </summary>
        /// <returns>The hashcode for the SpringInfo object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Springs.GetHashCode();

                foreach (int group in KnownDamagedGroups)
                {
                    hash = hash * 23 + group.GetHashCode();
                }

                return hash;
            }
        }

        #endregion Object Overrides
    }
}