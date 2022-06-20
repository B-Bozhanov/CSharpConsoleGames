using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Food 
    {
        private char symbol;


        public Food()
        {
            this.symbol = '@';
            this.FoodCords = new Coordinates();
        }
        public Coordinates FoodCords { get; private set; }

        public char Symbol { get => this.symbol; }

        public void FoodGenerator(Queue<Coordinates> snakeElements)
        {
            //Random generator = new Random();
            //foodCords.Row = generator.Next(this.infoWindow + 2, this.ConsoleRow - 1);
            //foodCords.Col = generator.Next(0, this.ConsoleCol - 2);

            //if (snakeElements.Any(s => s.Row == this.foodCords.Row && s.Col == this.foodCords.Col))
            //{
            //    FoodGenerator(snakeElements);
            //}
        }
    }
}
