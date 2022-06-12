using Snake.Menu;
using Snake.UserInput;
using System;
using System.Diagnostics;
using System.Threading;

namespace Snake
{
    internal class GameMenu
    {
        private readonly string[] mainMenu;
        private readonly string[] subDificult;
        private readonly string[] subSettings;
        private int consoleRow;
        private int consoleCol;
        private int snakeLength = 6;   // By default

        public GameMenu(int consoleRow, int consoleCol)
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
            this.consoleRow = consoleRow / 2 - 3;
            this.consoleCol = consoleCol / 2 - 4;
        }

        public string[] MainMenu { get => this.mainMenu; }

        public void WellcomeScreen()
        {
            var generator = new Random();
            //var screen = $"Wellcome";
            var loading = "loading...";
            var loadingTime = 1;//generator.Next(5, 15);
            var wellcomeText = new Coordinates(this.consoleRow, this.consoleCol); // TODO: something
            var timer = new Stopwatch();

            timer.Start();
            while (true)
            {
                TimeSpan seconds = timer.Elapsed;
                // Visualizer.WriteOnConsole(screen, wellcomeText.Row, wellcomeText.Col, ConsoleColor.Yellow);
                Visualizer.WriteOnConsole(loading, wellcomeText.Row + 1, wellcomeText.Col, ConsoleColor.Yellow);

                if (seconds.Seconds == loadingTime)
                {
                    timer.Reset();
                    Console.Clear();
                    break;
                }
            }

            Menu(this.mainMenu);
        }
        public void Menu(string[] menu)
        {
            MenuPositions currentMenu = new MenuPositions(menu, this.consoleRow, this.consoleCol);
            Cursor cursor = new Cursor(this.consoleRow, this.consoleCol);

            currentMenu.SetPositions();
            Visualizer.DrowingMenu(menu, consoleRow, consoleCol);
            cursor.Move(menu.Length, consoleRow);
            Console.Clear();

            int index = currentMenu.GetPositionIndex(cursor.Position); // Get index of current array
            cursor.Position.Row = consoleRow; // restore Cursor row position.

            if (mainMenu == menu)
            {
                switch (index)
                {
                    case 0: GetSnakeLength(); break;     // New Game
                    case 1: Menu(this.subDificult); break;                 // Dificult
                    case 2: Menu(this.subSettings); break;                 // Settings
                    case 3: Environment.Exit(0); break;                    // Exit   -->  TODO: fix this
                }
            }
            else if (this.subDificult == menu)
            {
                switch (index)
                {
                    case 0:; break;  // Easy
                    case 1:; break; // Medium
                    case 2:; break; // Hard
                    case 3: Menu(mainMenu); break;   // Back
                }
            }
            else if (this.subSettings == menu)
            {
                switch (index)
                {
                    case 0:; break;  // Screen size
                    case 1:; break; // Field Color
                    case 2:; break; // Snake Color
                    case 3: SetSnakeLength(); break;   // Snake Length
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
        public int GetSnakeLength()
        {
            return this.snakeLength;
        }
    }
}

