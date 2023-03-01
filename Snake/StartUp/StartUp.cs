using Microsoft.Extensions.DependencyInjection;

using Snake.Engine.MenuEngine.Interfaces;
using Snake.Models.Menu.Core.Interfaces;
using Snake.Models.SnakeModels.Core.Interfaces;
using Snake.Services;

using StartUp;

using UserDatabase.Interfaces;


var serviceProvider = DependencyResolver.GetServiceProvider();

var database = serviceProvider.GetService<IDatabase>();
database!.LoadDatabase();

var engine = serviceProvider.GetService<IMenuEngine>();
IAccount account = engine!.Start();

var snakeEngine = serviceProvider.GetService<ISnakeEngine>();
snakeEngine!.StartGame(account);

