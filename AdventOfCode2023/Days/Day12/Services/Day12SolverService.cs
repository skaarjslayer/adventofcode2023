using Day12.Factory;
using Day12.Model;
using Services;

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
            IEnumerable<SpringSetCreateArgs> args = data.Split("\r\n").Select(x => new SpringSetCreateArgs() { Springs = x, Copies = 1 });
            IEnumerable<SpringSet> springSets = _springSetFactory.CreateMany(args);

            Console.WriteLine($"The sum of all arrangements is: {springSets.Sum(x => GetDamagedGroupArrangementCount(x.Springs, x.DamagedGroups))}");
        }

        public void ExecuteS2(string data)
        {
            IEnumerable<SpringSetCreateArgs> args = data.Split("\r\n").Select(x => new SpringSetCreateArgs() { Springs = x, Copies = 5 });
            IEnumerable<SpringSet> springSets = _springSetFactory.CreateMany(args);

            foreach (SpringSet springSet in springSets)
            {
                Console.WriteLine($"Springset {springSet.Springs} count = {GetDamagedGroupArrangementCount(springSet.Springs, springSet.DamagedGroups)}");
            }

            Console.WriteLine("Done!");
      //      Console.WriteLine($"The sum of all arrangements is: {springSets.Sum(x => GetDamagedGroupArrangementCount(x.Springs, x.DamagedGroups))}");
        }

        public int GetDamagedGroupArrangementCount(string springs, List<int> damagedGroups)
        {
            List<int> newGroup = new List<int>(damagedGroups);

            if (springs.Count() > 0)
            {
                char spring = springs.First();

                if (IsOperational(spring))
                {
                    return GetDamagedGroupArrangementCount(springs.Substring(1, springs.Length - 1), newGroup);
                }
                else if (IsDamaged(spring))
                {
                    // Invalid branch if we're processing a damaged spring, but there are no more groups to process.
                    if (damagedGroups.Count() == 0)
                    {
                        return 0;
                    }

                    // Invalid branch if there are not enough damaged springs (or possibly damaged springs) to satisfy the remaining known groups.
                    if (springs.Where(c => !IsOperational(c)).Count() < damagedGroups.Sum())
                    {
                        return 0;
                    }

                    // Invalid branch if there are not enough springs left to process the next group.
                    int group = damagedGroups.First();
                    if (group > springs.Length)
                    {
                        return 0;
                    }

                    // Invalid branch if any of the springs in the group are known to be operational.
                    for (int i = 0; i < group; i++)
                    {
                        if (IsOperational(springs[i]))
                        {
                            return 0;
                        }
                    }

                    char[] newOutcome = springs.Substring(group, springs.Length - group).ToCharArray();
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
                    return GetDamagedGroupArrangementCount(new string(newOutcome), newGroup);
                }
                else
                {
                    char[] firstPossibility = springs.ToCharArray();
                    firstPossibility[0] = '.';

                    char[] secondPossibility = springs.ToCharArray();
                    secondPossibility[0] = '#';
                    List<int> newList = newGroup;
                    return GetDamagedGroupArrangementCount(new string(firstPossibility), newList) +
                           GetDamagedGroupArrangementCount(new string(secondPossibility), newList);
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