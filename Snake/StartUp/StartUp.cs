using GameMenu.Core;
using GameMenu.Core.Interfaces;
using Snake.Core;
using Snake.Core.Interfaces;
using UserDatabase;
using UserDatabase.Interfaces;

IUserDatabase users = new UserDatabase.UserDatabase();
IMenuEngine engine = new MenuEngine(users);
IUser user = engine.Start();

ISnakeEngine snake = new SnakeEngine();
snake.StartGame();
