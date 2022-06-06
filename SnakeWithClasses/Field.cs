using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class Field
    {
        private List<Coordinates> obstacles;
        private Coordinates food;
        private readonly int infoWindow;
        private readonly int consoleRow;
        private readonly int consoleCol;
        private int score;
        private int level;

        public Field(Coordinates fieldSize)
        {
            this.FieldSize = fieldSize;
            this.infoWindow = 2;   // Two Rows by default
            this.consoleRow = 1 + this.infoWindow + 1 + this.FieldSize.Row + 1; // One is borders size.
            this.consoleCol = 1 + this.FieldSize.Col + 1;
            score = 0;
            level = 1;

            food = new Coordinates();
            obstacles = new List<Coordinates>()
            {
               new Coordinates(6, 30),    // TODO: Fix coordinates abaut the consoleSize
               new Coordinates(15, 23),
               new Coordinates(25, 100),
               new Coordinates(17, 93),
            };

            SetConsoleSettings();
            foreach (var item in obstacles)
            {
                Visualizer.WriteOnConsole("=", item.Row, item.Col, ConsoleColor.Cyan);
            }
        }

        public Coordinates Food 
        {
            get { return this.food; }
            set { this.food = value; }
        }
        public Coordinates FieldSize { get; set; }
        public int InfoWindow { get { return infoWindow; } }
        public int ConsoleRow { get { return consoleRow; } }
        public int ConsoleCol { get { return consoleCol; } }
        public int Level 
        {
            get => this.level;
            set => this.level = value;
        }
        public int Score 
        {
            get => this.score;
            set => this.score = value;
        }

        private void SetConsoleSettings()
        {
            Console.CursorVisible = false;
            Console.Title = "Snake v1.2";
            Console.WindowHeight = consoleRow;
            Console.WindowWidth = consoleCol;
            Console.BufferHeight = consoleRow;
            Console.BufferWidth = consoleCol;
            Console.OutputEncoding = Encoding.UTF8;
        }
        public Coordinates FoodGenerator(Queue<Coordinates> snakeElements)
        {
            Random generator =  new Random();
            food.Row = generator.Next(infoWindow + 2, consoleRow + 2);
            food.Col = generator.Next(0, consoleCol - 2);

            if (snakeElements.Contains(food))
            {
                FoodGenerator(snakeElements);
            }

            return food;
        }
    }
}
