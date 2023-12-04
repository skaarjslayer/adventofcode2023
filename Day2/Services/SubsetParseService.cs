using Day2.Model;
using Services;

namespace Day2.Services
{
    public class SubsetParseService : IParseService<string, IEnumerable<Subset>>
    {
        public IEnumerable<Subset> Parse(string input)
        {
            List<Subset> subsets = new List<Subset>();

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

                subsets.Add(new Subset(reds, greens, blues));
            }

            return subsets.AsReadOnly();
        }
    }
}