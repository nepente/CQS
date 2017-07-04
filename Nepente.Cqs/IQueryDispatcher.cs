namespace Nepente.Cqs
{
    public interface IQueryDispatcher
    {
        TQueryResult Dispatch<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery;
    }
}
