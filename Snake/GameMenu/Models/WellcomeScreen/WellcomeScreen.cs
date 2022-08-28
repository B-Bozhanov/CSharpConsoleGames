namespace GameMenu.Models.WellcomeScreen
{
    using System.Diagnostics;
    using GameMenu.IO.Interfaces;

    internal class WellcomeScreen
    {
        private const string WellcomeMessage = "Wellcome";
        private const string LoadingMessage = "loading...";
        private const int NextRow = 1;

        private readonly Stopwatch timer;
        private readonly IWriter writer;
        private readonly int loadingTime;

        public WellcomeScreen(int row, int col, IWriter writer)
        {
            var generator = new Random();
            this.timer = new Stopwatch();
            this.loadingTime = 2;// generator.Next(5, 15);
            this.writer = writer;

            writer.Write(WellcomeMessage, row, col);
            writer.Write(LoadingMessage, row + NextRow, col);
            Wellcome();
        }

        private void Wellcome()
        {
            this.timer.Start();
            while (true)
            {
                TimeSpan seconds = timer.Elapsed;

                if (seconds.Seconds == loadingTime)
                {
                    timer.Reset();
                    this.writer.Clear();
                    break;
                }
            }
        }
    }
}
