using Day12.Factory;
using Day12.Model;
using Services;

namespace Day12.Services
{
    /// <summary>
    /// A service for solving Day 12 puzzles.
    /// </summary>
    public class Day12SolverService : ISolverService
    {
        #region Fields

        private readonly AbstractFactory<SpringInfoCreateArgs, SpringInfo> _springInfoFactory;
        private readonly AbstractFactory<TextToSpringInfoCreateArgs, IEnumerable<SpringInfo>> _textToSpringInfoFactory;

        #endregion Fields

        #region Constructors

        public Day12SolverService(AbstractFactory<SpringInfoCreateArgs, SpringInfo> springInfoFactory, AbstractFactory<TextToSpringInfoCreateArgs, IEnumerable<SpringInfo>> textToSpringInfoFactory)
        {
            _springInfoFactory = springInfoFactory;
            _textToSpringInfoFactory = textToSpringInfoFactory;
        }

        #endregion Constructors

        #region ISolverService Implementation

        /// <inheritdoc/>
        public void Execute()
        {
            ExecuteS1(Resources.Resource.Test);
            ExecuteS1(Resources.Resource.Puzzle);
            ExecuteS2(Resources.Resource.Test);
            ExecuteS2(Resources.Resource.Puzzle);
        }

        #endregion ISolverService Implementation

        #region Private Methods

        /// <summary>
        /// Executes the solution for Star 1 using the provided input string.
        /// </summary>
        /// <param name="input">The input string for the puzzle.</param>
        private void ExecuteS1(string input)
        {
            IEnumerable<SpringInfo> springSets = _textToSpringInfoFactory.Create(new TextToSpringInfoCreateArgs(input, 1));
            Dictionary<SpringInfo, long> cache = new Dictionary<SpringInfo, long>();

            Console.WriteLine($"The sum of all arrangements is {springSets.Sum(x => GetArrangementCountRecursive(in cache, x))}");
        }

        /// <summary>
        /// Executes the solution for Star 2 using the provided input string.
        /// </summary>
        /// <param name="input">The input string for the puzzle.</param>
        private void ExecuteS2(string input)
        {
            IEnumerable<SpringInfo> springSets = _textToSpringInfoFactory.Create(new TextToSpringInfoCreateArgs(input, 5));
            Dictionary<SpringInfo, long> cache = new Dictionary<SpringInfo, long>();

            Console.WriteLine($"The sum of all arrangements is {springSets.Sum(x => GetArrangementCountRecursive(in cache, x))}");
        }

        /// <summary>
        /// Recursively calculates the arrangement count for a given spring info.
        /// </summary>
        /// <param name="springInfo">The spring info to calculate the arrangement count for.</param>
        /// <param name="cache">A cache of previously calculated arrangement counts.</param>
        /// <returns>The arrangement count for the given spring info.</returns>
        private long GetArrangementCountRecursive(in Dictionary<SpringInfo, long> cache, SpringInfo springInfo)
        {
            const char OperationalSpring = '.';
            const char DamagedSpring = '#';

            // If we have already calculated the arrangement count for this spring info, return it from the cache.
            if (cache.ContainsKey(springInfo))
            {
                return cache[springInfo];
            }

            // Recursively calculate the arrangement count for the spring info, iterating each spring left to right.
            if (springInfo.Springs.Count() > 0)
            {
                char spring = springInfo.Springs.First();

                switch(spring)
                {
                    case OperationalSpring:
                        return GetArrangementCountOperationalSpring(in cache, springInfo);
                    case DamagedSpring:
                        return GetArrangementCountDamagedSpring(in cache, springInfo);
                    default:
                        return GetArrangementCountUnknownSpring(in cache, springInfo);
                }
            }

            /* If there are no more springs, return 1 if there are no more damaged groups, or 0 if there are.
             * This is because we have reached the end of the recursion, and we have successfully accounted for all groups. */
            return springInfo.KnownDamagedGroups.Count() > 0 ? 0 : 1;
        }

        /// <summary>
        /// Recursively calculates the arrangement count for a given spring info, assuming the first spring is operational.
        /// </summary>
        /// <param name="springInfo">The spring info to calculate the arrangement count for.</param>
        /// <param name="cache">A cache of previously calculated arrangement counts.</param>
        /// <returns>The arrangement count for the given spring info.</returns>
        private long GetArrangementCountOperationalSpring(in Dictionary<SpringInfo, long> cache, SpringInfo springInfo)
        {
            /* If the first spring is operational, we can ignore it and continue to the next level of recursion
             * using a substring that omits the first spring. */

            SpringInfo newSpringInfo = _springInfoFactory.Create(new SpringInfoCreateArgs(springInfo.Springs.Substring(1, springInfo.Springs.Length - 1), springInfo.KnownDamagedGroups.ToList()));
            long value = GetArrangementCountRecursive(in cache, newSpringInfo);

            if (!cache.ContainsKey(newSpringInfo))
            {
                cache[newSpringInfo] = value;
            }

            return value;
        }

        /// <summary>
        /// Recursively calculates the arrangement count for a given spring info, assuming the first spring is damaged.
        /// </summary>
        /// <param name="springInfo">The spring info to calculate the arrangement count for.</param>
        /// <param name="cache">A cache of previously calculated arrangement counts.</param>
        /// <returns>The arrangement count for the given spring info.</returns>
        private long GetArrangementCountDamagedSpring(in Dictionary<SpringInfo, long> cache, SpringInfo springInfo)
        {
            /* If the first spring is damaged, we need to process it along with the next contiguous group of springs.
             * However, to optimize the recursion, we can check for a few conditions that would result in an invalid
             * arrangement so we can exit early out of this entire recursion branch. */

            const char OperationalSpring = '.';
            const char DamagedSpring = '#';

            // If there are no more groups, this is an invalid arrangement and we can exit early.
            if (springInfo.KnownDamagedGroups.Count() == 0)
            {
                if (!cache.ContainsKey(springInfo))
                {
                    cache[springInfo] = 0;
                }

                return 0;
            }

            // If the sum of remaining contiguous groups is larger than the number of remaining non-operational springs, this is an invalid arrangement and we can exit early.
            if (springInfo.Springs.Where(c => c != OperationalSpring).Count() < springInfo.KnownDamagedGroups.Sum())
            {
                if (!cache.ContainsKey(springInfo))
                {
                    cache[springInfo] = 0;
                }

                return 0;
            }

            // If the first group is larger than the number of remaining springs, this is an invalid arrangement and we can exit early.
            int group = springInfo.KnownDamagedGroups.First();
            if (group > springInfo.Springs.Length)
            {
                if (!cache.ContainsKey(springInfo))
                {
                    cache[springInfo] = 0;
                }

                return 0;
            }

            // If any of the springs in the first group are operational, this is an invalid arrangement and we can exit early.
            for (int i = 0; i < group; i++)
            {
                if (springInfo.Springs[i] == OperationalSpring)
                {
                    if (!cache.ContainsKey(springInfo))
                    {
                        cache[springInfo] = 0;
                    }

                    return 0;
                }
            }

            // If there are characters after the first group, and the character immediately after that group is damaged, this is an invalid arrangement and we can exit early.
            if (group < springInfo.Springs.Length)
            {
                if (springInfo.Springs[group] == DamagedSpring)
                {
                    if (!cache.ContainsKey(springInfo))
                    {
                        cache[springInfo] = 0;
                    }

                    return 0;
                }
            }

            char[] newOutcome = springInfo.Springs.Substring(group, springInfo.Springs.Length - group).ToCharArray();
            
            if (newOutcome.Length > 0)
            {
                // The first spring after a damaged group is always operational.
                newOutcome[0] = OperationalSpring;
            }

            // Remove the first group from the list of known damaged groups so that it is no longer considered in further levels of recursion.
            List<int> newKnownDamagedGroups = springInfo.KnownDamagedGroups.ToList();
            newKnownDamagedGroups.RemoveAt(0);

            SpringInfo newSpringInfo = _springInfoFactory.Create(new SpringInfoCreateArgs(new string(newOutcome), newKnownDamagedGroups));
            long value = GetArrangementCountRecursive(in cache, newSpringInfo);

            if (!cache.ContainsKey(newSpringInfo))
            {
                cache[newSpringInfo] = value;
            }

            return value;
        }

        /// <summary>
        /// Recursively calculates the arrangement count for a given spring info, assuming the first spring is unknown.
        /// </summary>
        /// <param name="springInfo">The spring info to calculate the arrangement count for.</param>
        /// <param name="cache">A cache of previously calculated arrangement counts.</param>
        /// <returns>The arrangement count for the given spring info.</returns>
        private long GetArrangementCountUnknownSpring(in Dictionary<SpringInfo, long> cache, SpringInfo springInfo)
        {
            /* If the first spring is unknown, we create two branches of recursion: one where we assume the spring
             * is damaged, and one where we assume it is operational. */

            const char OperationalSpring = '.';
            const char DamagedSpring = '#';

            char[] firstSpringPossibility = springInfo.Springs.ToCharArray();
            firstSpringPossibility[0] = OperationalSpring;

            char[] secondSpringPossibility = springInfo.Springs.ToCharArray();
            secondSpringPossibility[0] = DamagedSpring;

            SpringInfo firstSpringInfo = _springInfoFactory.Create(new SpringInfoCreateArgs(new string(firstSpringPossibility), springInfo.KnownDamagedGroups.ToList()));
            SpringInfo secondSpringInfo = _springInfoFactory.Create(new SpringInfoCreateArgs(new string(secondSpringPossibility), springInfo.KnownDamagedGroups.ToList()));

            long firstValue = GetArrangementCountRecursive(in cache, firstSpringInfo);
            long secondValue = GetArrangementCountRecursive(in cache, secondSpringInfo);

            if (!cache.ContainsKey(springInfo))
            {
                cache[springInfo] = firstValue + secondValue;
            }

            return firstValue + secondValue;
        }

        #endregion Private Methods
    }
}