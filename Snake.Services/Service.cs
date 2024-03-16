namespace Snake.Services
{
    using Microsoft.Extensions.DependencyInjection;

    using Snake.Services.Drowers;
    using Snake.Services.Interfaces;

    public class Service : IService
    {
        public IServiceProvider GetServices()
        {
            ServiceCollection services = new ServiceCollection();
            RegisterServices(services);
            return services.BuildServiceProvider();
        }

        private static ServiceCollection RegisterServices(ServiceCollection services)
        {
            services.AddSingleton<IDrower, ConsoleDrower>();
            services.AddSingleton<IFieldService, ConsoleFieldService>();
            services.AddSingleton<ISnakeService, SnakeService>();
            services.AddSingleton<IInputHandlerService, ConsoleInputHandlerService>();
            services.AddSingleton<IDirectionService, DirectionService>();
            services.AddSingleton<IScoreService, ScoreService>();
            services.AddSingleton<IFoodService, FoodService>();
            services.AddSingleton<IObstacleService, ObstacleService>();
            services.AddSingleton<IGameService, GameService>();

            return services;
        }
    }
}
