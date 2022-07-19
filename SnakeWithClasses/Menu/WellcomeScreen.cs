using System;
using System.Diagnostics;

namespace Snake
{
    internal class WellcomeScreen 
    {
        private readonly Coordinates consoleCoords;
        private readonly Random generator;
        private readonly Stopwatch timer;
        private readonly string wellcome;
        private readonly string loading;
        private readonly int loadingTime;

        internal WellcomeScreen()
        {
            this.consoleCoords = new Coordinates(Field.MenuRow, Field.MenuCol);
            this.generator = new Random();
            this.timer = new Stopwatch();
            this.loadingTime = 1;//generator.Next(5, 15);

            this.wellcome = $"Wellcome";
            this.loading = "loading...";

            Wellcome(true); // TODO: Fix boolean;
        }

        internal void Wellcome(bool IsNewGame)
        {
            this.timer.Start();
            while (true)
            {
                TimeSpan seconds = timer.Elapsed;
                if (IsNewGame)
                {
                    Visualizer.WriteOnConsole(this.wellcome, this.consoleCoords.Row, this.consoleCoords.Col, ConsoleColor.Yellow);
                }

                Visualizer.WriteOnConsole(this.loading, this.consoleCoords.Row + 1, this.consoleCoords.Col, ConsoleColor.Yellow);

                if (seconds.Seconds == loadingTime)
                {
                    timer.Reset();
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
