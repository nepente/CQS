namespace Nepente.Cqs
{
    using System;

    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException("serviceProvider");
        }

        public TQueryResult Dispatch<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery
        {
            var handlerType = typeof(IQueryHandler<TQuery, TQueryResult>);

            try
            {
                var handler = (IQueryHandler<TQuery, TQueryResult>)_serviceProvider.GetService(handlerType);
                return handler.Handle(query);
            }
            catch (Exception ex)
            {
                throw new HandlerNotFoundException(ex);
            }
        }
    }
}
