using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Snake
{
    internal class Items
    {
        private Queue<Coordinates> snakeElements;
        private Coordinates food;
        private Stopwatch timer;
        private Random random;
        private int obsCount = 7;

        public Items(Queue<Coordinates> snakeElements)
        {
            this.ObstaclesList = new List<Coordinates>();
            this.food = new Coordinates();
            this.random = new Random();
            this.snakeElements = snakeElements;
            
            GenerateFirstObs();
           // new Thread(Test).Start(); // test new thread !!!
        }

        internal List<Coordinates> ObstaclesList { get; private set; }
        internal Coordinates Food { get; private set; }
        internal char ObstacleSymbol { get; private set; }
        internal char FoodSymbol { get; private set; }
        internal int ObsCount { get => obsCount; set => obsCount = value; }


        internal void GenerateFirstObs()
        {
            for (int i = 0; i < this.ObsCount; i++)
            {
                int row = random.Next(Field.InfoWindow + 2 + 1, Field.ConsoleRow - 1);
                int col = random.Next(0, Field.ConsoleCol - 2);
                ObstaclesList.Add(new Coordinates(row, col));
            }
        }
        internal void GenerateNew()
        {
            int row = random.Next(Field.InfoWindow + 2, Field.ConsoleRow - 1);
            int col = random.Next(0, Field.ConsoleCol - 2);

            if (this.snakeElements.Any(s => s.Row == row && s.Col == col) ||
                food.Row == row && food.Col == col)
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
        //private void Test()
        //{
        //    int interval = 7;
        //    timer.Start();

        //    while (true)
        //    {
        //        TimeSpan secconds = timer.Elapsed;

        //        if (secconds.Seconds == interval)
        //        {
        //            var removed = Disapear();
        //            GenerateNew();
        //            interval = random.Next(5, 20);
        //            timer.Restart();
        //            Visualizer.ObstaclesDrowing(this.ObstaclesList, removed, this.Symbol);
        //        }
        //    }
        //}
    }
}
