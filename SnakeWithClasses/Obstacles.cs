using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Snake
{
    internal class Obstacles
    {
        private readonly Random random;
        private Stopwatch timer;
        private  int obsCount = 7;
        private readonly int consoleRow;
        private readonly int consoleCol;
        private readonly int infoWindow;
        private Snake snake;
        private Food food;

        public Obstacles(int consoleRow, int consoleCol, int infoWindow, Snake snake)
        {
            this.random = new Random();
            this.ObstaclesList = new List<Coordinates>();
            this.Symbol = '=';
            this.timer = new Stopwatch();
            this.snake = snake;
            this.consoleRow = consoleRow;
            this.consoleCol = consoleCol;
            this.infoWindow = infoWindow;
            this.food = new Food();
            GenerateFirstObs();
            new Thread(Test).Start();
        }

        internal List<Coordinates> ObstaclesList { get; private set; }


        public char Symbol { get; private set; }


        public  int ObsCount { get => obsCount; set => obsCount = value; }


        internal void GenerateFirstObs()
        {
            for (int i = 0; i < this.ObsCount; i++)
            {
                int row = random.Next(infoWindow + 2 + 1, consoleRow - 1);
                int col = random.Next(0, consoleCol - 2);
                this.ObstaclesList.Add(new Coordinates(row, col));
            }
        }
        internal void GenerateNew(int consoleCol, int consoleRow, int infoWindol, Snake snake, Food food)
        {
            int row = random.Next(infoWindol + 2, consoleRow - 1);
            int col = random.Next(0, consoleCol - 2);

            if (snake.SnakeElements.Any(x => x.Row == row && x.Col == col) ||
                food.FoodCords.Row == row && food.FoodCords.Col == col)
            {
                GenerateNew(consoleCol, consoleRow, infoWindol, snake, food);
            }
            ObstaclesList.Add(new Coordinates(row, col));
        }
        internal Coordinates Disapear()
        {
            int index = random.Next(0, ObstaclesList.Count - 1);
            var obsForRemove = ObstaclesList[index];
            ObstaclesList.RemoveAt(index);
            return obsForRemove;
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
                    GenerateNew(consoleCol, consoleRow, infoWindow, snake, food);
                    interval = random.Next(5, 20);
                    timer.Restart();
                    Visualizer.ObstaclesDrowing(this.ObstaclesList, removed, this.Symbol);
                }
            }
            
        }
    }
}
