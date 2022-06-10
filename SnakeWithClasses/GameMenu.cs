using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class GameMenu
    {
        private readonly Field field;
        private readonly string[] mainMenuOptions;
        private Dictionary<Coordinates, List<string>> test;
        private Coordinates[] cursor;



        public GameMenu(Field field)
        {
            this.mainMenuOptions = new string[]
            {
               "New Game",
               "Dificult",
               "Settings",
               "Exit"
            };
            cursor = new Coordinates[]
            {
                new Coordinates(field.ConsoleRow / 2 - 2, field.ConsoleCol / 2 - 5),
                new Coordinates(field.ConsoleRow / 2 - 2 + 1, field.ConsoleCol / 2 - 5),
                new Coordinates(field.ConsoleRow / 2 - 2 + 2, field.ConsoleCol / 2 - 5),
                new Coordinates(field.ConsoleRow / 2 - 2 + 3, field.ConsoleCol / 2 - 5),
            };
            test.Add(cursor, new List<string>() 
            {
               "New Game",
               "Dificult",
               "Settings",
               "Exit"
            });
            test.Add(cursor.Row + 1, cursor.Col, new List<string>()
            {
               "Easy",
               "Medium",
               "Hard",
               "Back"
            });
            test.Add(cursor, new List<string>()
            {
               "Window size",
               "Snake length",
               "Back"
            });
            this.field = field;
        }


        private void MainMenu()
        {
            int move = 1;
            int direction = field.ConsoleRow / 2;
            //Coordinates cursor = new Coordinates(field.ConsoleRow / 2, field.ConsoleCol / 2 - 5);
            while (true)
            {
                var currentCursorPossition = test[cursor];

                foreach (var item in currentCursorPossition)
                {
                    Visualizer.WriteOnConsole(item, cursor.Row + 2, cursor.Col, ConsoleColor.Yellow);
                }
                Visualizer.WriteOnConsole("*", cursor.Row, cursor.Col, ConsoleColor.Yellow);
                // var key = UserKeyInput.KeyPressed();

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        move = -1;
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        move = 1;
                    }
                    if (key.Key == ConsoleKey.Enter) break;
                    Visualizer.WriteOnConsole(" ", cursor.Row, cursor.Col);
                    cursor.Row += move;
                }

                if (cursor.Row < field.ConsoleRow / 2)
                    cursor.Row = field.ConsoleRow / 2;
                if(cursor.Row > field.ConsoleRow / 2 + mainMenuOptions.Length -1)
                    cursor.Row = field.ConsoleRow / 2 + mainMenuOptions.Length - 1;
            }
        }
        public void WellcomeScreen()
        {
            Random generator = new Random();
            int loadingTime = 1;//generator.Next(5, 15);

            string screen = $"Wellcome";
            string loading = "loading...";
            var wellcomeText = new Coordinates(field.ConsoleRow / 2, field.ConsoleCol / 2);

            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (true)
            {
                TimeSpan seconds = timer.Elapsed;
                Visualizer.WriteOnConsole(screen, wellcomeText.Row, wellcomeText.Col, ConsoleColor.Yellow);
                Visualizer.WriteOnConsole(loading, wellcomeText.Row + 1, wellcomeText.Col, ConsoleColor.Yellow);

                if (seconds.Seconds == loadingTime)
                {
                    timer.Reset();
                    Console.Clear();
                    break;
                }
            }

            MainMenu();
        }
    }
}
