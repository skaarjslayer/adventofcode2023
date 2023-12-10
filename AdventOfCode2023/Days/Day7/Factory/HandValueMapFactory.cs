using Services;

namespace Day7.Factory
{
    public class HandValueMapFactory : AbstractFactory<string, IDictionary<string, int>>
    {
        public override IDictionary<string, int> Create(string text)
        {
            Dictionary<string, int> handTypes = new Dictionary<string, int>();

            string[] parts = text.Split("\r\n");

            foreach (string part in parts)
            {
                string[] handTypeData = part.Split(' ');

                handTypes.Add(handTypeData.First(), int.Parse(handTypeData.Last()));
            }

            return handTypes;
        }
    }
}