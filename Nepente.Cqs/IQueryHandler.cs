namespace Nepente.Cqs
{
    public interface IQueryHandler<TQuery, TQueryResult>
        where TQuery : IQuery
    {
        TQueryResult Handle(TQuery query);
    }
}
