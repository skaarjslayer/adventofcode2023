using Day2.Model;
using Services;

namespace Day2.Services
{
    public class SubsetFactory : AbstractFactory<string, IEnumerable<CubeSet>>
    {
        public override IEnumerable<CubeSet> Create(string input)
        {
            List<CubeSet> subsets = new List<CubeSet>();

            string[] subsetData = input.Split(';');

            foreach (string subset in subsetData)
            {
                string[] cubeData = subset.Split(',');
                int reds = 0;
                int greens = 0;
                int blues = 0;

                foreach(string data in cubeData)
                {
                    string[] parts = data.Trim().Split(' ');
                    int count = int.Parse(parts.First());

                    switch (parts.Last())
                    {
                        case "red":
                            reds = count;
                            break;
                        case "green":
                            greens = count;
                            break;
                        case "blue":
                            blues = count;
                            break;
                    }
                }

                subsets.Add(new CubeSet(reds, greens, blues));
            }

            return subsets.AsReadOnly();
        }
    }
}