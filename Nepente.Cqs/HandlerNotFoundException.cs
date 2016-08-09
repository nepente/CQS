using System;

namespace Nepente.Cqs
{
    public class HandlerNotFoundException : Exception
    {
        private const string message = "There is no handler for the query. Perhaps you didn't register the Query/QueryResult pair or the configuration was invalid.";

        public HandlerNotFoundException() : base(message)
        {}

        public HandlerNotFoundException(Exception innerException) : base(message, innerException)
        {}
    }
}
