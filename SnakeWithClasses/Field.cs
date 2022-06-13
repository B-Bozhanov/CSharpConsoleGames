using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class Field
    {
        private List<Coordinates> obstacles;
        private Coordinates fieldSize;
        private int score;
        private int level;

        public Field(Coordinates fieldSize)
        {
            this.fieldSize = fieldSize;
            this.InfoWindow = 2;   // Two Rows by default
            this.ConsoleRow = 1 + this.InfoWindow + 1 + this.FieldSize.Row + 1; // One is borders size.
            this.ConsoleCol = 1 + this.FieldSize.Col + 1;
            score = 0; // TODO: Score class or ScoreManager class
            level = 1;

            SetConsoleSettings();
            //foreach (var item in obstacles) // TODO: move this from here.
            //{
            //    Visualizer.WriteOnConsole("=", item.Row, item.Col, ConsoleColor.Cyan);
            //}
        }

        public List<Coordinates> Obstacless
        {
            get => this.obstacles;
            set => this.obstacles = value;
        }
        public Coordinates FieldSize { get => this.fieldSize; }
        public int InfoWindow { get; private set; }
        public int ConsoleRow { get; private set; }
        public int ConsoleCol { get; private set; }
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
            Console.WindowHeight = ConsoleRow;
            Console.WindowWidth = ConsoleCol;
            Console.BufferHeight = ConsoleRow;
            Console.BufferWidth = ConsoleCol;
            Console.OutputEncoding = Encoding.UTF8;
        }
        //public void FoodGenerator(Queue<Coordinates> elements)
        //{
        //    Random generator =  new Random();
        //    food.Row = generator.Next(infoWindow + 2, consoleRow -1);
        //    food.Col = generator.Next(0, consoleCol - 2);

        //    if (elements.Any(e => e.Row == food.Row && e.Col == food.Col))
        //    {
        //        FoodGenerator(elements);
        //    }
        //}
        //public void ObstaclesGen(List<Coordinates> obstacles)
        //{
        //    Random generator = new Random();
        //    food.Row = generator.Next(infoWindow + 2, consoleRow - 1);
        //    food.Col = generator.Next(0, consoleCol - 2);

        //    if (elements.Any(e => e.Row == food.Row && e.Col == food.Col))
        //    {
        //        FoodGenerator(elements);
        //    }
        //}
    }
}
