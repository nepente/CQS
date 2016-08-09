using System;

namespace Nepente.Cqs
{
    public class HandlerNotFoundException : Exception
    {
        private const string message = "Erro ao encontrar um handler para a query solicitada. Associação entre Query e QueryResult inválida ou não registrada.";

        public HandlerNotFoundException() : base(message)
        {}

        public HandlerNotFoundException(Exception innerException) : base(message, innerException)
        {}
    }
}
