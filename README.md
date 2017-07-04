# Cqs

Just a naive implementation of [CQS](http://martinfowler.com/bliki/CommandQuerySeparation.html) pattern.

## Installation

Install the package via NuGet:

```
$ Install-Package Nepente.Cqs
```

OR

```
$ dotnet add package Nepente.Cqs
```

## Configure DI

To dispatch your queries/commands you need respectively an IQueryDispatcher and ICommandDispatcher.
You can implement these yourself or use a generic implementation provided by the library.

QueryDispatcher and CommandDispatcher just implement the least necessary to use [Nepente.Cqs](https://github.com/nepente/cqs).
You just have to instantiate them with an IServiceProvider. Since most of DI Containers implements IServiceProvider it's as easy as follow:

``` csharp
var container = new Container(); // Any DI Container that implements IServiceProvider. e.g.: SimpleInjector
var queryDispatcher = new QueryDispatcher(container);
var commandDispatcher = new CommandDispatcher(container);
```

A more real world example where IQueryHandler and ICommandHandlers are dynamically registered with [SimpleInjector](https://simpleinjector.org).

``` csharp
var queryAndCommandsAssemblies = new[] { typeof(Startup).Assembly }; // Add here any assembly that contains queries or commands
var container = new Container();
container.Register<ICommandDispatcher>(() => new CommandDispatcher(this), Lifestyle.Singleton);
container.Register<IQueryDispatcher>(() => new QueryDispatcher(this), Lifestyle.Singleton);
container.Register(typeof(ICommandHandler<>), queryAndCommandsAssemblies);
container.Register(typeof(IQueryHandler<,>), queryAndCommandsAssemblies);
// Rest of your container configuration
```

## How to dispatch queries/commands

Ok, we have our dispatchers configured. Now let's create a sample query and command.

``` csharp
class HelloWorldQuery : IQuery
{
    public string Name { get; private set; }

    public HelloWorldQuery(string name)
    {
        Name = name;
    }
}

class HelloWorldQueryHandler : IQueryHandler<HelloWorldQuery, string>
{
    public string Handle(HelloWorldQuery query)
    {
        return $"Hello {query.Name}";
    }
}

class HellowWorldApp
{
    private readonly IQueryDispatcher _queryDispatcher;

    public HelloWorldApp(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    public SayHelloTo(string name)
    {
        Console.WriteLine(_queryDispatcher.Dispatch(new HelloWorldQuery(name)));
    }
}
```
