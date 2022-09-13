using GameMenu.Core;
using GameMenu.Core.Interfaces;
using GameMenu.IO.Interfaces;
using GameMenu.Menues;
using GameMenu.Menues.Interfaces;
using IO.Console;
using Snake.Core;
using Snake.Core.Interfaces;
using UserDatabase.Interfaces;

IUserDatabase usersDatabase = new UserDatabase.UserDatabase();
usersDatabase.LoadDatabase();
usersDatabase.AutoRemoveUnusedAccaunds();
usersDatabase.StartAutoSave();

IField field = new ConsoleField();

IWriter writer = new ConsoleWriter();
IReader reader = new ConsoleReader();

IMenuEngine engine = new MenuEngine(usersDatabase, field, writer, reader);
IUser user = engine.Start();

ISnakeEngine snake = new SnakeEngine(user);
snake.StartGame();

usersDatabase.SaveDatabase();
Console.WriteLine();