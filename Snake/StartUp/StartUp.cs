using Microsoft.Extensions.DependencyInjection;
using GameMenu.Core.Interfaces;
using Snake.Core;
using StartUp;
using UserDatabase.Interfaces;


var serviceProvider = DependencyResolver.GetServiceProvider();

var database = serviceProvider.GetService<IDatabase>();
database!.LoadDatabase();

var engine = serviceProvider.GetService<IMenuEngine>();
IAccount account = engine!.Start();
var field = serviceProvider.GetService<IField>();

var snakeEngine = new SnakeEngine(account, field);
snakeEngine.StartGame();

