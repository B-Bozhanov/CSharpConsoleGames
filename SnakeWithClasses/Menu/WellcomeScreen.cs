using System;
using System.Diagnostics;

namespace Snake
{
    internal class WellcomeScreen
    {
        private readonly Coordinates text;
        private readonly Random generator;
        private readonly Stopwatch timer;
        private readonly string wellcome;
        private readonly string loading;
        private readonly int loadingTime;

        public WellcomeScreen(int consoleRow, int consoleCol)
        {
            this.generator = new Random();
            this.wellcome = $"Wellcome";
            this.loading = "loading...";
            this.loadingTime = 1;//generator.Next(5, 15);
            this.text = new Coordinates(consoleRow, consoleCol);
            this.timer = new Stopwatch();
        }

        public void Wellcome(bool IsNewGame)
        {
            this.timer.Start();
            while (true)
            {
                TimeSpan seconds = timer.Elapsed;
                if (IsNewGame)
                {
                    Visualizer.WriteOnConsole(this.wellcome, this.text.Row, this.text.Col, ConsoleColor.Yellow);
                }

                Visualizer.WriteOnConsole(this.loading, this.text.Row + 1, this.text.Col, ConsoleColor.Yellow);

                if (seconds.Seconds == loadingTime)
                {
                    timer.Reset();
                    Console.Clear();
                    break;
                }
            }
            this.timer.Stop();
        }
    }
}
