using Day12.Model;
using Services;

namespace Day12.Factory
{
    /// <summary>
    /// A parameter object for passing arguments to a factory for creating spring information objects from text.
    /// </summary>
    public struct TextToSpringInfoCreateArgs
    {
        public string Text { get; init; }
        public uint Copies { get; init; }

        public TextToSpringInfoCreateArgs(string text, uint copies)
        {
            Text = text;
            Copies = copies;
        }
    }

    /// <summary>
    /// A factory for creating spring information objects from text.
    /// </summary>
    public class TextToSpringInfoFactory : AbstractFactory<TextToSpringInfoCreateArgs, IEnumerable<SpringInfo>>
    {
        #region Fields

        private readonly AbstractFactory<SpringInfoCreateArgs, SpringInfo> _springInfoFactory;

        #endregion Fields

        #region Constructors

        public TextToSpringInfoFactory(AbstractFactory<SpringInfoCreateArgs, SpringInfo> springInfoFactory)
        {
            _springInfoFactory = springInfoFactory;
        }

        #endregion Constructors

        #region AbstractFactory Implementation

        /// <inheritdoc/>
        public override IEnumerable<SpringInfo> Create(TextToSpringInfoCreateArgs input)
        {
            const char Space = ' ';
            const char Comma = ',';
            const char DamagedSpring = '?';

            List<SpringInfo> springInfos = new List<SpringInfo>();
            string[] rows = input.Text.Split("\r\n");

            foreach (string row in rows)
            {
                string[] parts = row.Split(Space);
                string[] groupData = parts.Last().Split(Comma);
                List<int> knownDamagedGroups = new List<int>();
                string springs = string.Empty;

                for (int i = 0; i < input.Copies; i++)
                {
                    springs += parts.First();

                    foreach (string group in groupData)
                    {
                        knownDamagedGroups.Add(int.Parse(group));
                    }

                    // If not iterating over the last index, add another damaged spring.
                    if (i < input.Copies - 1)
                    {
                        springs += DamagedSpring;
                    }
                }

                springInfos.Add(_springInfoFactory.Create(new SpringInfoCreateArgs(springs, knownDamagedGroups)));
            }

            return springInfos;
        }

        #endregion AbstractFactory Implementation
    }
}