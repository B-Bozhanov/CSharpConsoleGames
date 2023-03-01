namespace StartUp
{
    using GameMenu.Core;
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Console;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository;
    using GameMenu.Repository.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using UserDatabase;
    using UserDatabase.Interfaces;
    using GameMenu.UserInputHandle.Interfaces;
    using GameMenu.UserInputHandle;
    using Snake.Services.Models;
    using Snake.Services.Core;
    using Snake.Services.Models.Interfaces;
    using Snake.Services.Core.Interfaces;

    public static class DependencyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDatabase, UserDatabase>();
            services.AddSingleton<IField, ConsoleField>();
            services.AddSingleton<ICursor, Cursor>();
            services.AddSingleton<IRepository<string>, NameSpaceRepository>();
            services.AddSingleton<IMenuEngine, MenuEngine>();
            services.AddSingleton<ISnakeEngine, SnakeEngine>();
            services.AddSingleton<ISnake, Snake>();
            services.AddTransient<IRenderer, ConsoleRenderer>();
            services.AddTransient<IMenuCreator, MenuCreator>();
            services.AddTransient<IUserInput, UserInput>();
            services.AddTransient<IAccount, Account>();
            services.AddTransient<IUserInput, UserInput>();
            services.AddTransient<IObstacle, Obstacle>();
            services.AddTransient<IFood, Food>();

            return services.BuildServiceProvider();
        }
    }
}
