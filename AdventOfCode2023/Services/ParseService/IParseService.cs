using System.Collections.Generic;

namespace Services
{
    public interface IParseService<T> : IService
    {
        IEnumerable<T> Parse(string input);
    }
}