namespace Snake.Game
{
    using Microsoft.Extensions.DependencyInjection;

    using Drowers;

    public static class RegisterServices
    {
        public static IServiceProvider Register()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IDrower, ConsoleDrower>();
            services.AddScoped<IField, ConsoleField>();
            services.AddScoped<Snake, Snake>();
            services.AddScoped<IInputHandler, ConsoleInputHandler>();
            services.AddScoped<Direction, Direction>();
            services.AddScoped<ScoreManager, ScoreManager>();
            services.AddScoped<Food, Food>();
            services.AddScoped<Obstacle, Obstacle>();
            services.AddScoped<GameManager, GameManager>();

            return services.BuildServiceProvider();
        }
    }
}
