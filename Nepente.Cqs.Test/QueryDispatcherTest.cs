namespace Nepente.Cqs.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SimpleInjector;

    [TestClass]
    public class QueryDispatcherTest
    {
        [TestMethod]
        [ExpectedException(typeof(HandlerNotFoundException))]
        public void HandlerNotFoundExceptionTest()
        {
            var container = new Container();
            var queryDispatcher = new QueryDispatcher(container);
            queryDispatcher.Dispatch<UserQuery, User>(new UserQuery());
        }

        private class User
        {
        }

        private class UserQuery : IQuery
        {
        }
    }
}
