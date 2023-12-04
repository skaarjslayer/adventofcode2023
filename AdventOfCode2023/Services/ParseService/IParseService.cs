namespace Services
{
    public interface IParseService<TInput, TOutput> : IService
    {
        TOutput Parse(TInput input);
    }
}