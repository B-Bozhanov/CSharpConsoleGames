namespace StartUp
{
    using Microsoft.Extensions.DependencyInjection;

    using Snake.Engine.MenuEngine;
    using Snake.Engine.MenuEngine.Interfaces;
    using Snake.Models.Menu;
    using Snake.Models.Menu.Core;
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.IO.Console;
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.Repository;
    using Snake.Models.Menu.Repository.Interfaces;
    using Snake.Models.Menu.UserInputHandle;
    using Snake.Models.Menu.UserInputHandle.Interfaces;
    using Snake.Models.SnakeModels.Core;
    using Snake.Models.SnakeModels.Core.Interfaces;
    using Snake.Models.SnakeModels.Models;
    using Snake.Models.SnakeModels.Models.Interfaces;
    using Snake.Services;

    using UserDatabase;
    using UserDatabase.Interfaces;

    public static class DependencyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDatabase, UserDatabase>();
            services.AddSingleton<IField, ConsoleField>();
            services.AddSingleton<ICursor, Cursor>();
            services.AddSingleton<IRepository<string>, NameSpaceRepository>();
            services.AddSingleton<IMenuEngine, Engine>();
            services.AddSingleton<ISnakeEngine, SnakeEngine>();
            services.AddSingleton<ISnake, SnakeModel>();
            services.AddTransient<IRenderer, ConsoleRenderer>();
            services.AddTransient<IMenuCreator, MenuCreator>();
            services.AddTransient<IUserInput, UserInput>();
            services.AddTransient<IAccount, Account>();
            services.AddTransient<IUserInput, UserInput>();
            services.AddTransient<IObstacle, Obstacle>();
            services.AddTransient<IFood, Food>();
            services.AddTransient<IBorderService, BorderService>();

            return services.BuildServiceProvider();
        }
    }
}
