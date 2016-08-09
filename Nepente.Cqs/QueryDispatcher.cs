using System;

namespace Nepente.Cqs
{
    public interface IQueryDispatcher
    {
        TQueryResult Dispatch<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery;
    }

    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");   
            }

            _serviceProvider = serviceProvider;
        }

        public TQueryResult Dispatch<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TQueryResult));

            try
            {
                dynamic handler = _serviceProvider.GetService(handlerType);
                return handler.Handle((dynamic)query);
            }
            catch (Exception ex)
            {
                throw new HandlerNotFoundException(ex);
            }
        }
    }
}

