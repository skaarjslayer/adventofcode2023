using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1.Services
{
    /// <summary>
    /// A service for solving Day 1 puzzles.
    /// </summary>
    public class Day1SolverService : ISolverService
    {
        #region Fields

        private readonly AbstractFactory<string, IEnumerable<string>> _calibrationFactory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// This constructor will be automatically called by the dependency injection framework and provide the requested dependencies.
        /// </summary>
        /// <param name="calibrationFactory">The factory for creating calibrations that will be injected into the constructor.</param>
        public Day1SolverService(AbstractFactory<string, IEnumerable<string>> calibrationFactory)
        {
            _calibrationFactory = calibrationFactory;
        }

        #endregion Constructors

        #region ISolverService Implementation

        /// <inheritdoc/>
        public void Execute()
        {
            ExecuteS1(Resources.Resource.Test);
            ExecuteS1(Resources.Resource.Puzzle);
            ExecuteS2(Resources.Resource.Test2);
            ExecuteS2(Resources.Resource.Puzzle);
        }

        #endregion ISolverService Implementation

        #region Private Methods

        /// <summary>
        /// Executes the solution for Star 1 using the provided input string.
        /// </summary>
        /// <param name="input">The input string for the puzzle.</param>
        private void ExecuteS1(string input)
        {
            /* For each calibration string, we must gather all indices where digits (1, 2, 3, etc.) appear in that string. */
            IEnumerable<string> calibrations = _calibrationFactory.Create(input);
            IEnumerable<IEnumerable<KeyValuePair<int, string>>> indexDigitPairs = calibrations.Select(x => GetIndexDigitPairs(x));

            /* Then, we simply concatenate each of the first and last digits (e.g., 1 and 2 becomes 12).
             * Finally, we convert this value into an integer, and sum all of these values. */
            Console.WriteLine($"The sum of all calibration values is {indexDigitPairs.Sum(x => int.Parse(x.First().Value + x.Last().Value))}.");
        }

        /// <summary>
        /// Executes the solution for Star 2 using the provided input string.
        /// </summary>
        /// <param name="input">The input string for the puzzle.</param>
        private void ExecuteS2(string input)
        {
            // We first create a word map that maps a word number (one) to a digit (1).
            Dictionary<string, string> wordNumberMap = new Dictionary<string, string>
            {
                { "one", "1" },
                { "two", "2" },
                { "three", "3" },
                { "four", "4" },
                { "five", "5" },
                { "six", "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine", "9" },
            };

            /* For each calibration string, we must gather all indices where digits (1, 2, 3, etc.) appear in that string.
             * Then, we must also gather all indices where word numbers (one, two, three, etc.) appear in that string.
             * Because we process digits and word numbers separately, we must re-order the collection by index. */
            IEnumerable<string> calibrations = _calibrationFactory.Create(input);
            IEnumerable<IEnumerable<KeyValuePair<int, string>>> indexDigitPairs = calibrations.Select(x => GetIndexDigitPairs(x).Union(GetIndexWordNumberPairs(x, wordNumberMap)).OrderBy(x => x.Key));

            /* Then, we simply concatenate each of the first and last digits (e.g., 1 and 2 becomes 12).
             * Finally, we convert this value into an integer, and sum all of these values. */
            Console.WriteLine($"The sum of all calibration values is {indexDigitPairs.Sum(x => int.Parse(x.First().Value + x.Last().Value))}.");
        }

        /// <summary>
        /// Gets all instances of digits (1, 2, 3, etc.) within a string and returns a collection of key-value pairs showing which index in the string the digits appear.
        /// </summary>
        /// <param name="input">The string being processed.</param>
        /// <returns>A collection of key-value pairs where the key is the index a digit appears, and the value is the digit itself.</returns>
        private IEnumerable<KeyValuePair<int, string>> GetIndexDigitPairs(string input)
        {
            List<KeyValuePair<int, string>> indexDigitPairs = new List<KeyValuePair<int, string>>();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    indexDigitPairs.Add(new KeyValuePair<int, string>(i, input[i].ToString()));
                }
            }

            return indexDigitPairs;
        }

        /// <summary>
        /// Gets all instances of word numbers (one, two, three, etc.) within a string, converts them to digits, and returns a collection of key-value pairs showing which index in the string the digits appear.
        /// </summary>
        /// <param name="input">The string being processed.</param>
        /// <param name="wordNumberMap">A dictionary that maps word numbers (one) to digits (1).</param>
        /// <returns>A collection of key-value pairs where the key is the index a digit appears, and the value is the digit itself.</returns>
        private IEnumerable<KeyValuePair<int, string>> GetIndexWordNumberPairs(string input, IDictionary<string, string> wordNumberMap)
        {
            List<KeyValuePair<int, string>> indexWordNumberPairs = new List<KeyValuePair<int, string>>();

            foreach (KeyValuePair<string, string> wordNumber in wordNumberMap)
            {
                if (input.Contains(wordNumber.Key))
                {
                    int index = input.IndexOf(wordNumber.Key);

                    while (index != -1)
                    {
                        indexWordNumberPairs.Add(new KeyValuePair<int, string>(index, wordNumber.Value));
                        index = input.IndexOf(wordNumber.Key, index + 1);
                    }
                }
            }

            return indexWordNumberPairs;
        }

        #endregion Private Methods
    }
}