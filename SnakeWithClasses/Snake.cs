using System;
using System.Collections.Generic;
using System.Linq;

namespace TempSnakeWithClasses
{
    internal class Snake
    {
        private Queue<Coordinates> snakeElements;
        private Coordinates[] directions;
        private Coordinates nextHead;
        private int direction = 0;  // Right by default


        public Snake(int snakeLenght = 6)
        {
            this.SnakeLenght = snakeLenght;
            snakeElements = new Queue<Coordinates>();
            this.directions = new Coordinates[]
               {
                new Coordinates(0, 1),  // Right
                new Coordinates(0, -1), // Left
                new Coordinates(1, 0),  // Down
                new Coordinates(-1, 0)  // Up
               };
        }

        public Queue<Coordinates> SnakeElements { get => snakeElements; }
        public Coordinates NextHead
        {
            get => this.nextHead;
            set => this.nextHead = value;
        }
        public int Direction { get => direction; }
        public int SnakeLenght { get; set; }


        public void SnakeCreation(int infoWindow)
        {
            for (int i = 1; i <= this.SnakeLenght; i++)
            {
                this.snakeElements.Enqueue(new Coordinates(infoWindow + 2, i));   // InfoWindow + 2
            }
        }
        public void NextPossition()
        {
            this.direction = GetSnakeDirection(this.direction);
            Coordinates snakeHead = this.snakeElements.Last();
            Coordinates nextDirection = this.directions[this.direction];
            this.nextHead = new Coordinates(snakeHead.Row + nextDirection.Row, snakeHead.Col + nextDirection.Col);
        }
        public void Move()
        {
            this.snakeElements.Enqueue(nextHead);
            this.snakeElements.Dequeue();
        }
        private int GetSnakeDirection(int direction)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (direction == 1)
                    {
                        direction = 1;
                        return direction;
                    }
                    direction = 0;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (direction == 0)
                    {
                        direction = 0;
                        return direction;
                    }
                    direction = 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (direction == 3)
                    {
                        direction = 3;
                        return direction;
                    }
                    direction = 2;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (direction == 2)
                    {
                        direction = 2;
                        return direction;
                    }
                    direction = 3;
                }
            }
            return direction;
        }
        public bool IsDeath(int row, int col, int infoWindow, bool wallsAppear) // TODO Obstacles and Levels
        {
            var isDeath = false;
            if (wallsAppear)
            {
                if (nextHead.Row >= row + 2 || nextHead.Row < infoWindow + 2   // Die
                  || nextHead.Col >= col - 1 || nextHead.Col < 1)
                {
                    isDeath = true;
                }
            }
            else
            {
                if (nextHead.Row >= row + 2) nextHead.Row = infoWindow + 2;    // Goes through the walls
                if (nextHead.Row < infoWindow + 2) nextHead.Row = row + 1;
                if (nextHead.Col >= col - 1) nextHead.Col = 1;
                if (nextHead.Col < 1) nextHead.Col = col - 1;
            }

            foreach (var element in snakeElements)
            {
                if (nextHead.Row == element.Row && nextHead.Col == element.Col)
                {
                    isDeath = true;
                }
            }
            //if (level >= 5)
            //{
            //    foreach (var item in obstacles)
            //    {
            //        if (snakeElements.Contains(item))
            //        {
            //            Field.Write($"Game over!\n Your Score is: {Score}\n", 1, 1, ConsoleColor.DarkRed);
            //            Environment.Exit(0);
            //        }
            //    }
            //}

            return isDeath;
        }
    }
}
