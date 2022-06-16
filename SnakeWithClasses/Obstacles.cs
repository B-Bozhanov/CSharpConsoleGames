using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Obstacles 
    {
        private readonly List<Coordinates> obstacles;
        private readonly Random random;
        private readonly char symbol;

        public Obstacles()
        {
            this.random = new Random();
            this.obstacles = new List<Coordinates>();
            this.symbol = '=';

           // FirsObstacles();
        }

        internal List<Coordinates> ObstaclesList { get => this.obstacles; }
        public char Symbol { get => this.symbol; }

        //private void FirsObstacles()
        //{
        //    for (int i = 0; i < 7; i++)
        //    {
        //        int row = random.Next(InfoWindow + 2 + 1, ConsoleRow - 1);
        //        int col = random.Next(0, ConsoleCol - 2);
        //        obstacles.Add(new Coordinates(row, col));
        //    }
        //}
        //internal void Generate(Coordinates food)
        //{
        //    int row = random.Next(InfoWindow + 2, ConsoleRow - 1);
        //    int col = random.Next(0, ConsoleCol - 2);

        //    if (SnakeElements.Any(x => x.Row == row && x.Col == col) ||
        //        food.Row == row && food.Col == col)
        //    {
        //        Generate(food);
        //    }
        //    obstacles.Add(new Coordinates(row, col));
        //}
        internal void Disapear()
        {
            int index = random.Next(0, obstacles.Count - 1);
            obstacles.RemoveAt(index);
        }
    }
}
