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



        public GameMenu(Field field)
        {
            this.mainMenuOptions = new string[]
            {
               "New Game",
               "Dificult",
               "Settings",
               "Exit"
            };
            this.field = field;
        }


        private void MainMenu()
        {
            for (int i = 0; i < mainMenuOptions.Length; i++)
            {
                Visualizer.WriteOnConsole(mainMenuOptions[i], field.ConsoleRow / 2 + i, field.ConsoleCol / 2 - 3, ConsoleColor.Yellow);
            }

            int move = 1;
            int direction = field.ConsoleRow / 2;

            while (true)
            {
                Visualizer.WriteOnConsole("*", direction, field.ConsoleCol / 2 - 5, ConsoleColor.Yellow);
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
                    Visualizer.WriteOnConsole(" ", direction, field.ConsoleCol / 2 - 5);
                    direction += move;
                }

                if (direction < field.ConsoleRow / 2) 
                    direction = field.ConsoleRow / 2;
                if(direction > field.ConsoleRow / 2 + mainMenuOptions.Length -1) 
                    direction = field.ConsoleRow / 2 + mainMenuOptions.Length - 1;
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
