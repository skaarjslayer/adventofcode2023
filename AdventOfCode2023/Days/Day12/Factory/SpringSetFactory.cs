using Day12.Model;
using Services;

namespace Day12.Factory
{
    public class SpringSetCreateArgs
    {
        public string Springs { get; init; }
        public int Copies { get; init; }
    }

    public class SpringSetFactory : AbstractFactory<SpringSetCreateArgs, SpringSet>
    {
        public override SpringSet Create(SpringSetCreateArgs input)
        {
            string[] parts = input.Springs.Split(' ');
            List<int> groupsList = new List<int>();

            string[] groups = parts.Last().Split(',');
            string springs = string.Empty;

            for (int i = 0; i < input.Copies; i++)
            {
                springs += parts.First();

                if (i < input.Copies - 1)
                {
                    springs += '?';
                }

                foreach (string group in groups)
                {
                    groupsList.Add(int.Parse(group));
                }
            }

            return new SpringSet() { Springs = springs, DamagedGroups = groupsList };
        }
    }
}