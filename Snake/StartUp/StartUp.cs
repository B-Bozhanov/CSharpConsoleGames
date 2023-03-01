using Microsoft.Extensions.DependencyInjection;

using Snake.Models.Menu.Core.Interfaces;
using Snake.Services.Core.Interfaces;

using StartUp;

using UserDatabase.Interfaces;


var serviceProvider = DependencyResolver.GetServiceProvider();

var database = serviceProvider.GetService<IDatabase>();
database!.LoadDatabase();

var engine = serviceProvider.GetService<IMenuEngine>();
IAccount account = engine!.Start();
var field = serviceProvider.GetService<IField>();

var snakeEngine = serviceProvider.GetService<ISnakeEngine>();
snakeEngine!.StartGame(account);

