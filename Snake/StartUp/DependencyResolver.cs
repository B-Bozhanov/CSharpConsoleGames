namespace StartUp
{
    using GameMenu.Core;
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Console;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository;
    using GameMenu.Repository.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Snake.Core;
    using Snake.Core.Interfaces;
    using Snake.Models.Interfaces;
    using Snake.Models;
    using UserDatabase;
    using UserDatabase.Interfaces;
    using GameMenu.UserInputHandle.Interfaces;
    using GameMenu.UserInputHandle;

    public static class DependencyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDatabase, UserDatabase>();
            services.AddTransient<IRenderer, ConsoleRenderer>();
            services.AddSingleton<IField, ConsoleField>();
            services.AddSingleton<ICursor, Cursor>();
            services.AddSingleton<IRepository<string>, NameSpaceRepository>();
            services.AddTransient<IMenuCreator, MenuCreator>();
            services.AddSingleton<IMenuEngine, MenuEngine>();
            services.AddSingleton<ISnakeEngine, SnakeEngine>();
            services.AddTransient<IAccount, Account>();
            services.AddSingleton<ISnake, Snake>();
            services.AddTransient<IUserInput, UserInput>();
            services.AddTransient<Account>();

            return services.BuildServiceProvider();
        }
    }
}
