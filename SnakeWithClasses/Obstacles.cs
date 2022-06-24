using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Obstacles 
    {
        private readonly Random random;
        private readonly char symbol;

        public Obstacles()
        {
            this.random = new Random();
            this.ObstaclesList = new List<Coordinates>();
            this.symbol = '=';

           // FirsObstacles();
        }

        internal List<Coordinates> ObstaclesList { get; private set; }
        public char Symbol { get => this.symbol; }

        internal void FirsObstacles(int consoleRow , int consoleCol, int infoWindol)
        {
            for (int i = 0; i < 7; i++)
            {
                int row = random.Next(infoWindol + 2 + 1, consoleRow - 1);
                int col = random.Next(0, consoleCol - 2);
                ObstaclesList.Add(new Coordinates(row, col));
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

            if (ObstaclesList.Count > 2)
            {
                ObstaclesList.RemoveAt(index);
                return ObstaclesList[index];
            }
            return null;
        }
    }
}
