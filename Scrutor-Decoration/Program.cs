using Microsoft.Extensions.DependencyInjection;
using Scrutor_Decoration;
using Scrutor_Decoration.Decorators;
using Scrutor_Decoration.Execution;
using Scrutor_Decoration.Queries;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.Scan(
            static a => a.FromAssemblyOf<IQueryDispatcher>()
                .AddClasses(static c => c.AssignableTo(typeof(IQueryHandlerAsync<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(static c => c.AssignableTo(typeof(ICommandHandlerAsync<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(static c => c.AssignableTo(typeof(ICommandHandlerAsync<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );

        services.Decorate(typeof(ICommandHandlerAsync<>), typeof(LoggerCommandHandlerDecorator<>));
        services.Decorate(typeof(IQueryHandlerAsync<,>), typeof(LoggerQueryHandlerDecorator<,>));
        services.Decorate(typeof(ICommandHandlerAsync<,>), typeof(LoggerCommandHandlerDecorator<,>));
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddLogging();

        var serviceProvider = services.BuildServiceProvider();
        var dispatcher = serviceProvider.GetRequiredService<IQueryDispatcher>();

        var result = await dispatcher.HandleAsync<HelloQuery, string>(new HelloQuery(new(Guid.NewGuid()), "World"));

        Console.WriteLine(result);
    }
}