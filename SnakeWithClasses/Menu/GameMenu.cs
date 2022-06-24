using Snake.Menu;
using System;
using System.Threading;

namespace Snake
{
    internal class GameMenu 
    {
        private readonly string[] mainMenu;
        private readonly string[] subDificult;
        private readonly string[] subSettings;
        private readonly int menuRow;
        private readonly int menuCol;
        private int snakeLength;   

        public GameMenu(int menuRow, int menuCol)
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
            this.menuRow = menuRow; 
            this.menuCol = menuCol;
            this.WellcomeScreen = new WellcomeScreen(menuRow, menuCol);
        }

        internal WellcomeScreen WellcomeScreen { get; private set; }

        private void Menu(string[] menu)
        {
            var currentMenu = new MenuPositions(menu, this.menuRow, this.menuCol);
            var cursor = new Cursor(this.menuRow, this.menuCol);

            currentMenu.SetPositions();
            Visualizer.DrowingMenu(menu, this.menuRow, this.menuCol);
            cursor.Move(menu.Length, this.menuRow);  // may be return from While Looop and with escape.....
            Console.Clear();

            int index = currentMenu.GetPositionIndex(cursor.Position);        // Get index of current array
            cursor.Position.Row = this.menuRow;                            // Restore Cursor row position.

            if (menu == mainMenu)
            {
                switch (index)
                {
                    case 0: GetSnakeLengthByUserOrDefault(); break;     // New Game
                    case 1: Menu(this.subDificult); break;              // Dificult
                    case 2: Menu(this.subSettings); break;              // Settings
                    case 3: Environment.Exit(0); break;                 // Exit   -->  TODO: fix this
                }
            }
            else if (menu == this.subDificult)
            {
                switch (index)
                {
                    case 0:; break;                  // Easy
                    case 1:; break;                  // Medium
                    case 2:; break;                  // Hard
                    case 3: Menu(mainMenu); break;   // Back
                }
            }
            else if (menu == this.subSettings)
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
        public void StartMainMenu()
        {
            Menu(this.mainMenu);
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
                Thread.Sleep(2000);
                Console.Clear();
                SetSnakeLength(); // Invoke the method again.
            }
            Console.CursorVisible = false;
            Console.Clear();

            Menu(this.mainMenu); //Go back in the main menu window.
        }
        public int GetSnakeLengthByUserOrDefault()
        {
            return this.snakeLength;
        }
    }
}

