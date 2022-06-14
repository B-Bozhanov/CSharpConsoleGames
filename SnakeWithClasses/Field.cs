using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class Field : UserKeyInput
    {
        protected readonly int consoleRow;
        protected readonly int consoleCol;
        protected readonly int infoWindow;

        private List<Coordinates> obstacles;
        private Coordinates fieldSize;
        private int score;
        private int level;

        public Field(Coordinates fieldSize)
        {
            this.fieldSize = fieldSize;

            this.infoWindow = 2;   // Two Rows by default
            this.consoleRow = 1 + this.infoWindow + 1 + this.fieldSize.Row + 1; // One is borders size.
            this.consoleCol = 1 + this.FieldSize.Col + 1;

            score = 0; // TODO: Score class or ScoreManager class
            level = 1;

            SetConsoleSettings();
            //foreach (var item in obstacles) // TODO: move this from here.
            //{
            //    Visualizer.WriteOnConsole("=", item.Row, item.Col, ConsoleColor.Cyan);
            //}
        }
        protected Field()
        {

        }

        public List<Coordinates> Obstacless
        {
            get => this.obstacles;
            set => this.obstacles = value;
        }
        public Coordinates FieldSize { get => this.fieldSize; }
        public int MyProperty { get; set; }
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
