using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace Nepente.Cqs.Test
{
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


        class User { }
        class UserQuery : IQuery { }
    }
}
