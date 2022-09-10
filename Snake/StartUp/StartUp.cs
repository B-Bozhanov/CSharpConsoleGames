using GameMenu.Core;
using GameMenu.Core.Interfaces;
using GameMenu.Menues;
using GameMenu.Menues.Interfaces;
using Snake.Core;
using Snake.Core.Interfaces;
using UserDatabase.Interfaces;


IField field = new ConsoleField();
IUserDatabase usersDatabase = new UserDatabase.UserDatabase();
IMenuEngine engine = new MenuEngine(usersDatabase, field);
IUser user = engine.Start();

ISnakeEngine snake = new SnakeEngine();
snake.StartGame();
