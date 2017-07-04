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
            var commandDispatcher = new CommandDispatcher(container);

            commandDispatcher.Dispatch(new UserCommand());
        }

        private class UserCommand : ICommand
        {
        }
    }
}
