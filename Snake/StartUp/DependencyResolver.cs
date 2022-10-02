using GameMenu.Core;
using GameMenu.Core.Interfaces;
using GameMenu.IO.Interfaces;
using GameMenu.Repository;
using GameMenu.Repository.Interfaces;
using IO.Console;
using Microsoft.Extensions.DependencyInjection;
using Snake.Core;
using Snake.Core.Interfaces;
using UserDatabase;
using UserDatabase.Interfaces;

namespace StartUp
{
    public static class DependencyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDatabase, UserDatabase.UserDatabase>();
            services.AddSingleton<IWriter, ConsoleWriter>();
            services.AddSingleton<IReader, ConsoleReader>();
            services.AddSingleton<IField, ConsoleField>();
            services.AddSingleton<ICursor, Cursor>();
            services.AddSingleton<IRepository<string>, NameSpaceRepository>();
            services.AddSingleton<IMenuCreator, MenuCreator>();
            services.AddSingleton<IMenuEngine, MenuEngine>();
            services.AddSingleton<ISnakeEngine, SnakeEngine>();
            services.AddTransient<IAccount, Account>();
            services.AddTransient<Account>();

            return services.BuildServiceProvider();
        }
    }
}
