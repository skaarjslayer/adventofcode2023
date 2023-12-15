using Day2.Model;
using Services;

namespace Day2.Services
{
    /// <summary>
    /// A factory for creating cubes.
    /// </summary>
    public class CubesFactory : AbstractFactory<string, Cubes>
    {
        #region AbstractFactory Implementation

        /// <inheritdoc/>
        public override Cubes Create(string input)
        {
            const string RedName = "red";
            const string GreenName = "green";
            const string BlueName = "blue";
            const char SemiColon = ';';
            const char Comma = ',';
            const char Space = ' ';

            List<Cubes> subsets = new List<Cubes>();

            string[] subsetData = input.Split(SemiColon);

            foreach (string subset in subsetData)
            {
                string[] cubeData = subset.Split(Comma);
                int reds = 0;
                int greens = 0;
                int blues = 0;

                foreach(string data in cubeData)
                {
                    string[] parts = data.Trim().Split(Space);
                    int count = int.Parse(parts.First());

                    switch (parts.Last())
                    {
                        case RedName:
                            reds = count;
                            break;
                        case GreenName:
                            greens = count;
                            break;
                        case BlueName:
                            blues = count;
                            break;
                    }
                }

                subsets.Add(new Cubes(reds, greens, blues));
            }

            return null;
        }

        #endregion AbstractFactory Implementation
    }
}