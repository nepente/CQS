namespace Nepente.Cqs.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SimpleInjector;

    [TestClass]
    public class CommandDispatcherTest
    {
        [TestMethod]
        [ExpectedException(typeof(HandlerNotFoundException))]
        public void HandlerNotFoundExceptionTest()
        {
            var container = new Container();
            container.Register<ICommandDispatcher>(() => new CommandDispatcher(container));

            var commandDispatcher = container.GetInstance<ICommandDispatcher>();

            commandDispatcher.Dispatch<UserCommand>(new UserCommand());
        }

        private class UserCommand : ICommand
        {
        }
    }
}
