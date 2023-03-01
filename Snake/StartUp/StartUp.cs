using Microsoft.Extensions.DependencyInjection;

using StartUp;
using GameMenu.Core.Interfaces;
using UserDatabase.Interfaces;
using Snake.Services.Core.Interfaces;

var serviceProvider = DependencyResolver.GetServiceProvider();

var database = serviceProvider.GetService<IDatabase>();
database!.LoadDatabase();

var engine = serviceProvider.GetService<IMenuEngine>();
IAccount account = engine!.Start();
var field = serviceProvider.GetService<IField>();

var snakeEngine = serviceProvider.GetService<ISnakeEngine>();
snakeEngine!.StartGame(account);

