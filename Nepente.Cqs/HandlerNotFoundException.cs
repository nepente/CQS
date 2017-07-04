namespace Nepente.Cqs
{
    using System;

    public class HandlerNotFoundException : Exception
    {
        private const string HandlerNotFoundMessage = "There is no handler for the query. Perhaps you didn't register the Query/QueryResult pair or the configuration was invalid.";

        public HandlerNotFoundException()
            : base(HandlerNotFoundMessage)
        {
        }

        public HandlerNotFoundException(Exception innerException)
            : base(HandlerNotFoundMessage, innerException)
        {
        }
    }
}
