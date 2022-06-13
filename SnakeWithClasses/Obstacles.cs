using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Obstacles
    {
        public readonly int consoleRow;
        private readonly int consoleCol;
        private readonly int infoWindow;
        private readonly char symbol;
        private List<Coordinates> obstacles;
        private Random random;

        public Obstacles()
        {

        }
        internal Obstacles(int consoleRow, int consoleCol, int infoWindow)
        {
            this.infoWindow = infoWindow;
            this.consoleRow = consoleRow;
            this.consoleCol = consoleCol;
            this.random = new Random();
            this.obstacles = new List<Coordinates>();
            this.symbol = '=';

            FirsObstacles();
        }

        internal List<Coordinates> ObstaclesList { get => this.obstacles; }
        public char Symbol { get => this.symbol; }

        private void FirsObstacles()
        {
            for (int i = 0; i < 7; i++)
            {
                int row = random.Next(infoWindow + 2 + 1, consoleRow - 1);
                int col = random.Next(0, consoleCol - 2);
                obstacles.Add(new Coordinates(row, col));
            }
        }
        internal void Generate(Queue<Coordinates> snakeElements, Coordinates food)
        {
            int row = random.Next(infoWindow + 2, consoleRow - 1);
            int col = random.Next(0, consoleCol - 2);

            if (snakeElements.Any(x => x.Row == row && x.Col == col) ||
                food.Row == row && food.Col == col)
            {
                Generate(snakeElements, food);
            }
            obstacles.Add(new Coordinates(row, col));
        }
        internal void Disapear()
        {
            int index = random.Next(0, obstacles.Count - 1);
            obstacles.RemoveAt(index);
        }
    }
}
