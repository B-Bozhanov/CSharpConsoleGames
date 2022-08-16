namespace GameMenu.Core
{
    using GameMenu.IO;
    using GameMenu.IO.Interfaces;
    using GameMenu.Models;
    using GameMenu.Models.Interfaces;
    using GameMenu.UserInputHandle;
    using GameMenu.UserInputHandle.Interfaces;
    using Interfaces;
    using Snake.Utilities;
    using Snake.Utilities.Interfaces;

    public class Engine : IEngine
    {
        private HashSet<IMenu> menues;
        private readonly IWriter writer;
        private readonly IField field;
        private readonly IInterpretor interpretor;
        private string currentNameSpace;


        private Engine()
        {
            this.menues = new HashSet<IMenu>();
            this.writer = new ConsoleWriter();
            this.field = new ConsoleField();
            this.interpretor = new Interpretor();
            NameSpaces.Push("GameMenu.Models.Menuses.MainMenu");
            this.currentNameSpace = NameSpaces.Peek();
        }
        public Engine(string test)
            : this()
        {
        }

        public void Start()
        {

            this.menues = this.interpretor.GetMenues(currentNameSpace, ConsoleField.MenuRow, ConsoleField.MenuCol);
            this.SelectMenu();

        }

        private void SelectMenu()
        {
            ICoordinates cursor = new Coordinates(ConsoleField.MenuRow, ConsoleField.MenuCol - 2);

            foreach (var menu in menues)
            {
                string message = menu.GetName();
                writer.Write(message, menu.MenuCoordinates.Row, menu.MenuCoordinates.Col);

            }

            while (true)
            {
                IUserInput input = new UserInput();
                var key = input.GetInput();

                int move = 0;
                if (key == KeyPressed.Up) move = -1;
                if (key == KeyPressed.Down) move = 1;
                if (key != KeyPressed.None) writer.Write(" ", cursor.Row, cursor.Col);
                if (key == KeyPressed.Enter) break;

                cursor.Row += move;

                if (cursor.Row < ConsoleField.MenuRow)
                {
                    cursor.Row = menues.Count - 1 + ConsoleField.MenuRow;
                }
                else if (cursor.Row > menues.Count - 1 + ConsoleField.MenuRow)
                {
                    cursor.Row = ConsoleField.MenuRow;
                }
                writer.Write("*", cursor.Row, cursor.Col);
            }

            IMenu currentMenu = this.menues.First(m => m.MenuCoordinates.Row == cursor.Row
                                                  && m.MenuCoordinates.Col == cursor.Col + 2);

            this.currentNameSpace = currentMenu.Execute();
            this.writer.Clear();
            this.Start();
        }
    }
}
