using Snake.Menu;
using System;
using System.Threading;
namespace Snake
{
    internal class GameMenu : Field
    {
        private readonly string[] mainMenu;
        private readonly string[] subDificult;
        private readonly string[] subSettings;
        private int snakeLength;   

        public GameMenu(int row, int col) : base(row, col)
        {
            this.mainMenu = new string[]
            {
               "New Game",
               "Dificult",
               "Settings",
               "Exit"
            };
            this.subDificult = new string[]
            {
               "Easy",
               "Medium",
               "Hard",
               "Back"
            };
            this.subSettings = new string[]
            {
               "Screen size",
               "Field Color",
               "Snake Color",
               "Snake Length",
               "Back"
            };
            this.snakeLength = 6;               // By default
        }
        public GameMenu() 
        {
        }

        private void Menu(string[] menu)
        {
            var currentMenu = new MenuPositions(menu, base.Row, base.Col);
            var cursor = new  Cursor(this.Row, this.Col);

            currentMenu.SetPositions();
            Visualizer.DrowingMenu(menu, base.Row, base.Col);
            cursor.Move(menu.Length, base.Row);
            Console.Clear();

            int index = currentMenu.GetPositionIndex(cursor); // Get index of current array
            cursor.Position.Row = base.ConsoleCords.Row; // restore Cursor row position.

            if (mainMenu == menu)
            {
                switch (index)
                {
                    case 0: GetSnakeLengthByUser(); break;     // New Game
                    case 1: Menu(this.subDificult); break;     // Dificult
                    case 2: Menu(this.subSettings); break;     // Settings
                    case 3: Environment.Exit(0); break;        // Exit   -->  TODO: fix this
                }
            }
            else if (this.subDificult == menu)
            {
                switch (index)
                {
                    case 0:; break;                  // Easy
                    case 1:; break;                  // Medium
                    case 2:; break;                  // Hard
                    case 3: Menu(mainMenu); break;   // Back
                }
            }
            else if (this.subSettings == menu)
            {
                switch (index)
                {
                    case 0:; break;                       // Screen size
                    case 1:; break;                       // Field Color
                    case 2:; break;                       // Snake Colors
                    case 3: SetSnakeLength(); break;      // Snake Length
                    case 4: Menu(this.mainMenu); break;   // Back
                }
            }
        }
        private void SetSnakeLength()
        {
            Visualizer.WriteOnConsole($"Enter length -> min 3 - max 20 -> ", 14, 40, ConsoleColor.Yellow); //TODO: fix coordinates.
            Console.CursorVisible = true;
            int length = int.Parse(Console.ReadLine());
            if (length >= 3 && length <= 20)
            {
                this.snakeLength = length;
            }
            else
            {
                Console.Clear();
                Visualizer.WriteOnConsole($"Incorect Length! Try again!", 14, 50, ConsoleColor.Red); //TODO: fix coordinates.
                Thread.Sleep(1500);
                Console.Clear();
                SetSnakeLength(); // Invoke the method again.
            }
            Console.CursorVisible = false;
            Console.Clear();

            Menu(this.mainMenu); //Go back in the main menu window.
        }
        public int GetSnakeLengthByUser()
        {
            return this.snakeLength;
        }
        public void StartMainMenu()
        {
            Menu(this.mainMenu);
        }
    }
}

