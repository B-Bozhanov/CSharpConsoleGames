using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Snake
{
    internal class Obstacles : Engine
    {
        private readonly Random random;
        private Stopwatch timer;
        private  int obsCount = 7;
        private readonly int consoleRow;
        private readonly int consoleCol;
        private readonly int infoWindow;
        private Snake snake;
        private Food food;

        public Obstacles(int consoleRow, int consoleCol, int infoWindow, Snake snake) : 
            base(consoleRow, consoleCol, infoWindow, snake)
        {
            this.random = new Random();
            this.ObstaclesList = new List<Coordinates>();
            this.symbol = '=';

            GenerateFirstObs();
            new Thread(Test).Start();
        }

        internal List<Coordinates> ObstaclesList { get; private set; }
        public char Symbol { get => this.symbol; }


        public char Symbol { get; private set; }


        public  int ObsCount { get => obsCount; set => obsCount = value; }


        internal void GenerateFirstObs()
        {
            for (int i = 0; i < this.ObsCount; i++)
            {
                int row = random.Next(infoWindow + 2 + 1, consoleRow - 1);
                int col = random.Next(0, consoleCol - 2);
                ObstaclesList.Add(new Coordinates(row, col));
            }
        }
        internal void GenerateNew()
        {
            int row = random.Next(infoWindow + 2, consoleRow - 1);
            int col = random.Next(0, consoleCol - 2);

            if (snake.SnakeElements.Any(x => x.Row == row && x.Col == col) ||
                food.FoodCords.Row == row && food.FoodCords.Col == col)
            {
                GenerateNew();
            }
            ObstaclesList.Add(new Coordinates(row, col));
        }
        internal Coordinates Disapear()
        {
            int index = random.Next(0, ObstaclesList.Count - 1);

            if (ObstaclesList.Count > 2)
            {
                ObstaclesList.RemoveAt(index);
                return ObstaclesList[index];
            }
            return null;
        }
        private void Test()
        {
            int interval = 7;
            timer.Start();

            while (true)
            {
                TimeSpan secconds = timer.Elapsed;

                if (secconds.Seconds == interval)
                {
                    var removed = Disapear();
                    GenerateNew();
                    interval = random.Next(5, 20);
                    timer.Restart();
                    Visualizer.ObstaclesDrowing(this.ObstaclesList, removed, this.Symbol);
                }
            }
            
        }
    }
}
