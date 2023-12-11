using System.Collections.Generic;

namespace Services
{
    /// <summary>
    /// An abstract base class for all factories. Takes in data from an input type and uses that to produce an output.
    /// </summary>
    /// <typeparam name="TInput">The input type being used for the creation process.</typeparam>
    /// <typeparam name="TOutput">The output type being used for the creation process.</typeparam>
    public abstract class AbstractFactory<TInput, TOutput>
    {
        #region Public Methods

        #region Abstract Methods

        /// <summary>
        /// Creates a single TOutput object from a single TInput object.
        /// </summary>
        /// <param name="input">The input object of type TInput.</param>
        /// <returns>A new instance of TOutput.</returns>
        /// <remarks>Use this method when you want to create a single object.</remarks>
        public abstract TOutput Create(TInput input);

        #endregion Abstract Methods

        /// <summary>
        /// Creates multiple TOutput objects from multiple TInput objects.
        /// </summary>
        /// <param name="inputs">An IEnumerable of TInput objects.</param>
        /// <returns>An IEnumerable of TOutput objects.</returns>
        /// <remarks>Use this method when you want to create multiple objects that are different from one another.</remarks>
        public IEnumerable<TOutput> CreateMany(IEnumerable<TInput> inputs)
        {
            List<TOutput> output = new List<TOutput>();

            foreach (TInput input in inputs)
            {
                output.Add(Create(input));
            }

            return output;
        }

        /// <summary>
        /// Creates multiple TOutput objects from a single TInput object.
        /// </summary>
        /// <param name="input">The input object of type TInput.</param>
        /// <param name="count">The number of times to repeat the creation process.</param>
        /// <returns>An IEnumerable of TOutput objects.</returns>
        /// <remarks>Use this method when you want to create multiple objects that are the same.</remarks>
        public IEnumerable<TOutput> CreateMany(TInput input, int count)
        {
            List<TOutput> output = new List<TOutput>();

            for (int i = 0; i < count; i++)
            {
                output.Add(Create(input));
            }

            return output;
        }

        #endregion Public Methods
    }
}