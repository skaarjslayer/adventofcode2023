using System.Collections.Generic;

namespace Services
{
    public abstract class AbstractFactory<TInput, TOutput>
    {
        public abstract TOutput Create(TInput input);

        public IEnumerable<TOutput> CreateMany(IEnumerable<TInput> inputs)
        {
            foreach(TInput input in inputs)
            {
                yield return Create(input);
            }
        }

        public IEnumerable<TOutput> CreateMany(TInput input, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return Create(input);
            }
        }
    }
}