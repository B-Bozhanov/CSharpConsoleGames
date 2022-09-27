using GameMenu.Core;
using GameMenu.Core.Interfaces;
using GameMenu.IO.Interfaces;
using GameMenu.Menues;
using GameMenu.Menues.Interfaces;
using IO.Console;
using Snake.Core;
using Snake.Core.Interfaces;
using UserDatabase.Interfaces;

IDatabase usersDatabase = new UserDatabase.UserDatabase();
usersDatabase.LoadDatabase();
IWriter writer = new ConsoleWriter();
IReader reader = new ConsoleReader();

IField field = new ConsoleField();
IMenuEngine engine = new MenuEngine(usersDatabase, field, writer, reader);
IAccount user = engine.Start();

ISnakeEngine snake = new SnakeEngine(user);
snake.StartGame();