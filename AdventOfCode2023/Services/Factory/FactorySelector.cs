using System;
using System.Collections.Generic;

namespace Services.Factory
{
    public abstract class FactorySelector<TSelector, TInput, TOutput> : IFactory<TSelector, IFactory<TInput, TOutput>>
    {
        protected readonly Dictionary<TSelector, Func<IFactory<TInput, TOutput>>> _factoryMap;

        public FactorySelector(Dictionary<TSelector, Func<IFactory<TInput, TOutput>>> factoryMap)
        {
            _factoryMap = factoryMap;
        }

        public virtual IFactory<TInput, TOutput> Create(TSelector selector)
        {
            if (_factoryMap.TryGetValue(selector, out Func<IFactory<TInput, TOutput>> factoryMethod))
            {
                return factoryMethod();
            }

            throw new ArgumentException("Invalid key", nameof(selector));
        }
    }
}