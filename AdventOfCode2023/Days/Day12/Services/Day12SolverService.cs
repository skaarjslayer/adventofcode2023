
using Day12.Model;
using Services;
using System.Globalization;

namespace Day12.Services
{
    public class Day12SolverService : ISolverService
    {
        public Day12SolverService()
        {
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
            int test = GetDamagedGroupArrangementCount("???.###", new List<int> { 1, 1, 3 });
        }

        public void ExecuteS2(string data)
        {
        }


        public int GetDamagedGroupArrangementCount(string springs, List<int> damagedGroups)
        {
         //   bool isImpossible = springs.Where(c => c == '?' || c == '#').Count() < damagedGroups.Sum();

            if (springs.Count() > 0)
            {
                char firstSpring = springs.First();

                if (IsOperational(firstSpring))
                {
                    return GetDamagedGroupArrangementCount(springs.Substring(1, springs.Length - 1), new List<int>(damagedGroups));
                }
                else if (IsDamaged(firstSpring))
                {
                    int firstDamagedGroup = damagedGroups.First();
                    bool isValidGroup = true;

                    for (int i = 0; i < firstDamagedGroup; i++)
                    {
                        if (springs[i] == '.')
                            isValidGroup = false;
                    }

                    if (firstDamagedGroup < springs.Length && springs[firstDamagedGroup] == '#')
                    {
                        isValidGroup = false;
                    }

                    if (isValidGroup)
                    {
                        char[] newOutcome = springs.Substring(firstDamagedGroup, springs.Length - firstDamagedGroup).ToCharArray();
                        damagedGroups.Remove(firstDamagedGroup);

                        if (newOutcome.Length > 0)
                        {
                            newOutcome[0] = '.';
                            return GetDamagedGroupArrangementCount(new string(newOutcome), new List<int>(damagedGroups));
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    char[] firstPossibility = springs.ToCharArray();
                    firstPossibility[0] = '.';

                    char[] secondPossibility = springs.ToCharArray();
                    secondPossibility[0] = '#';
                    List<int> newList = new List<int>(damagedGroups);
                    return GetDamagedGroupArrangementCount(new string(firstPossibility), newList) +
                           GetDamagedGroupArrangementCount(new string(secondPossibility), newList);
                }
            }

            return damagedGroups.Count() > 0 ? 0 : 1;

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