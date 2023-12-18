using Day12.Factory;
using Day12.Model;
using Services;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Day12.Services
{
    public class Day12SolverService : ISolverService
    {
        private readonly AbstractFactory<SpringSetCreateArgs, SpringSet> _springSetFactory;

        public Day12SolverService(AbstractFactory<SpringSetCreateArgs, SpringSet> springSetFactory)
        {
            _springSetFactory = springSetFactory;
        }

        public void Execute()
        {
            ExecuteS1(Day12.Resources.Resource.Test);
            ExecuteS1(Day12.Resources.Resource.Puzzle);
            ExecuteS2(Day12.Resources.Resource.Test);
            ExecuteS2(Day12.Resources.Resource.Puzzle);
        }

        public void ExecuteS1(string data)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            IEnumerable<SpringSetCreateArgs> args = data.Split("\r\n").Select(x => new SpringSetCreateArgs() { Springs = x, Copies = 1 });
            IEnumerable<SpringSet> springSets = _springSetFactory.CreateMany(args);

            Console.WriteLine($"The sum of all arrangements is: {springSets.Sum(x => GetDamagedGroupArrangementCount(x, new Dictionary<SpringSet, long>()))}");
            
            sw.Stop();
            Console.WriteLine($"Done: {sw.ElapsedMilliseconds}ms");
        }

        public void ExecuteS2(string data)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            IEnumerable<SpringSetCreateArgs> args = data.Split("\r\n").Select(x => new SpringSetCreateArgs() { Springs = x, Copies = 5 });
            IEnumerable<SpringSet> springSets = _springSetFactory.CreateMany(args);

            Console.WriteLine($"The sum of all arrangements is: {springSets.Sum(x => GetDamagedGroupArrangementCount(x, new Dictionary<SpringSet, long>()))}");

            sw.Stop();
            Console.WriteLine($"Done: {sw.ElapsedMilliseconds}ms");
        }

        public long GetDamagedGroupArrangementCount(SpringSet springSet, Dictionary<SpringSet, long> cache)
        {
            List<int> newGroup = new List<int>(springSet.DamagedGroups);

            if (cache.ContainsKey(springSet))
            {
                return cache[springSet];
            }

            if (springSet.Springs.Count() > 0)
            {
                char spring = springSet.Springs.First();

                if (IsOperational(spring))
                {
                    SpringSet newSpringSet = new SpringSet() { Springs = springSet.Springs.Substring(1, springSet.Springs.Length - 1), DamagedGroups = newGroup };
                    long value = GetDamagedGroupArrangementCount(newSpringSet, cache);
                    if (!cache.ContainsKey(newSpringSet))
                    {
                        cache[newSpringSet] = value;
                    }

                    return value;
                }
                else if (IsDamaged(spring))
                {
                    // Invalid branch if we're processing a damaged spring, but there are no more groups to process.
                    if (newGroup.Count() == 0)
                    {
                        return 0;
                    }

                    // Invalid branch if there are not enough damaged springs (or possibly damaged springs) to satisfy the remaining known groups.
                    if (springSet.Springs.Where(c => !IsOperational(c)).Count() < newGroup.Sum())
                    {
                        return 0;
                    }

                    // Invalid branch if there are not enough springs left to process the next group.
                    int group = newGroup.First();
                    if (group > springSet.Springs.Length)
                    {
                        return 0;
                    }

                    // Invalid branch if any of the springs in the group are known to be operational.
                    for (int i = 0; i < group; i++)
                    {
                        if (IsOperational(springSet.Springs[i]))
                        {
                            return 0;
                        }
                    }

                    char[] newOutcome = springSet.Springs.Substring(group, springSet.Springs.Length - group).ToCharArray();
                    if (newOutcome.Length > 0)
                    {
                        // Invalid branch if the next spring is known to be damaged. We just processed a group, so the following spring has to be operational to be valid.
                        if (IsDamaged(newOutcome[0]))
                        {
                            return 0;
                        }

                        newOutcome[0] = '.';
                    }

                    newGroup.RemoveAt(0);

                    SpringSet newSpringSet = new SpringSet() { Springs = new string(newOutcome), DamagedGroups = newGroup };
                    long value = GetDamagedGroupArrangementCount(newSpringSet, cache);

                    if (!cache.ContainsKey(newSpringSet))
                    {
                        cache[newSpringSet] = value;
                    }

                    return value;
                }
                else
                {
                    char[] firstPossibility = springSet.Springs.ToCharArray();
                    firstPossibility[0] = '.';

                    char[] secondPossibility = springSet.Springs.ToCharArray();
                    secondPossibility[0] = '#';

                    SpringSet newSpringSet1 = new SpringSet() { Springs = new string(firstPossibility), DamagedGroups = newGroup };
                    SpringSet newSpringSet2 = new SpringSet() { Springs = new string(secondPossibility), DamagedGroups = newGroup };

                    long value1 = GetDamagedGroupArrangementCount(newSpringSet1, cache);
                    long value2 = GetDamagedGroupArrangementCount(newSpringSet2, cache);

                    if (!cache.ContainsKey(newSpringSet1))
                    {
                        cache[newSpringSet1] = value1;
                    }

                    if (!cache.ContainsKey(newSpringSet2))
                    {
                        cache[newSpringSet2] = value2;
                    }

                    return value1 + value2;
                }
            }

            return newGroup.Count() > 0 ? 0 : 1;
        }

        private bool IsOperational(char spring)
        {
            return spring == '.';
        }

        private bool IsDamaged(char spring)
        {
            return spring == '#';
        }
    }
}