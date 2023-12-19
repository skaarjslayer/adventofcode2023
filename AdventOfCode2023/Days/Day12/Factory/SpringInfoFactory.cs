using Day12.Model;
using Services;

namespace Day12.Factory
{
    /// <summary>
    /// A parameter object for passing arguments to a factory for creating spring information objects.
    /// </summary>
    public struct SpringInfoCreateArgs
    {
        public string Springs { get; init; }
        public IEnumerable<int> KnownDamagedGroups { get; init; }

        public SpringInfoCreateArgs(string springs, IEnumerable<int> knownDamagedGroups)
        {
            Springs = springs;
            KnownDamagedGroups = knownDamagedGroups;
        }
    }

    /// <summary>
    /// A factory for creating spring information objects.
    /// </summary>
    public class SpringInfoFactory : AbstractFactory<SpringInfoCreateArgs, SpringInfo>
    {
        #region AbstractFactory Implementation

        /// <inheritdoc/>
        public override SpringInfo Create(SpringInfoCreateArgs input)
        {
            return new SpringInfo(input.Springs, input.KnownDamagedGroups);
        }

        #endregion AbstractFactory Implementation
    }
}