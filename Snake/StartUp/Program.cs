using GameMenu.Core;
using GameMenu.Core.Interfaces;
using Snake.Core;
using Snake.Core.Interfaces;
using UsersDatabse;
using UsersDatabse.Interfaces;

IUserDatabase database = new UserDatabase();
IMenuEngine engine = new MenuEngine(database);
engine.Start();

ISnakeEngine snake = new SnakeEngine();
snake.StartGame();
