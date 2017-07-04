namespace Nepente.Cqs
{
    using System;

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }

            _serviceProvider = serviceProvider;
        }

        public void Dispatch<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handlerType = typeof(ICommandHandler<TCommand>);

            try
            {
                var handler = (ICommandHandler<TCommand>)_serviceProvider.GetService(handlerType);
                handler.Handle(command);
            }
            catch (Exception ex)
            {
                throw new HandlerNotFoundException(ex);
            }
        }
    }
}
