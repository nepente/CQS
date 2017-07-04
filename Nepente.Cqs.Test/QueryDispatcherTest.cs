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
            container.Register<IQueryDispatcher>(() => new QueryDispatcher(container));

            var queryDispatcher = container.GetInstance<IQueryDispatcher>();

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
