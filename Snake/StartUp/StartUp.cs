using GameMenu.Core;
using GameMenu.Core.Interfaces;
using GameMenu.IO.Interfaces;
using GameMenu.Menues;
using GameMenu.Repository;
using GameMenu.Repository.Interfaces;
using IO.Console;
using Snake.Core;
using Snake.Core.Interfaces;
using UserDatabase.Interfaces;

IDatabase usersDatabase = new UserDatabase.UserDatabase();
usersDatabase.LoadDatabase();

IWriter writer = new ConsoleWriter();
IReader reader = new ConsoleReader();
IField field = new ConsoleField();
ICursor cursor = new Cursor(writer, field);
IRepository<string> namespaces = new NameSpaceRepository();
IMenuCreator menuCreator = new MenuCreator(namespaces, usersDatabase);

IMenuEngine engine = new MenuEngine(usersDatabase, field, writer, reader,menuCreator, cursor, namespaces);
IAccount user = engine.Start();

ISnakeEngine snake = new SnakeEngine(user, field);
snake.StartGame();