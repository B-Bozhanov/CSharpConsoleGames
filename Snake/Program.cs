using Microsoft.Extensions.DependencyInjection;

using Snake.Data.Data;
using Snake.Services;
using Snake.Services.Interfaces;

string sqlConnectionString = "Server=localhost;Database=SnakeGame;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;Integrated Security=true";
var dbContext = new SnakeDbContext(sqlConnectionString);
await dbContext.Database.EnsureCreatedAsync();

IServiceProvider services = new Service().GetServices();
IGameService gameService = services.GetRequiredService<IGameService>()!;
gameService.Start();
