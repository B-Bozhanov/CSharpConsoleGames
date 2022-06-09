using System;
using System.Diagnostics;

namespace Snake
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Field field = new Field(new Coordinates(30, 120));

            Random generator = new Random();
            int loadingTime = 5;

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

               // loadingTime = 5;// generator.Next(5, 12);
                if (seconds.Seconds == loadingTime)
                {
                    timer.Reset();
                    Console.Clear();
                    break;
                }
            }
            //GameMenu.MainMenu(field);
            //Engine.Start(field);
        }
    }
}
