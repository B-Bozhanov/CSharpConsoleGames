namespace Snake.Models
{
    using GameMenu.UserInputHandle;
    using GameMenu.UserInputHandle.Interfaces;
    using Utilities;


    internal class Snake
    {
        private IUserInput input;
        private readonly Coordinates[] directions = new Coordinates[]
                 {
                     new Coordinates(0, 1),  // right
                     new Coordinates(0, -1), // left
                     new Coordinates(1, 0),  // down
                     new Coordinates(-1, 0)  // up
                 };
        private int direction = 0;


        public Snake()
        {
            this.Elements = new Queue<Coordinates>();
            this.input = new UserInput();
            this.Create();
        }


        public Queue<Coordinates> Elements { get; private set; }
        public Coordinates Head { get; private set; }

        private void Create()
        {
            for (int i = 0; i < 6; i++)
            {
                this.Elements.Enqueue(new Coordinates(0, i));
            }
        }

        public void Move()
        {
            var userInput = this.input.GetInput();
            if (userInput == KeyPressed.Right && this.direction != 1)  this.direction = 0;
            if (userInput == KeyPressed.Left && this.direction != 0)   this.direction = 1;
            if (userInput == KeyPressed.Down && this.direction != 3)   this.direction = 2;
            if (userInput == KeyPressed.Up && this.direction != 2)     this.direction = 3;


            Coordinates snakeHead = this.Elements.Last();
            Coordinates nextDirection = this.directions[direction];
            this.Head = new Coordinates(nextDirection.Row + snakeHead.Row, nextDirection.Col + snakeHead.Col);

            this.Elements.Enqueue(this.Head);
            var queueElement = this.Elements.Dequeue();
            Console.SetCursorPosition(queueElement.Col, queueElement.Row);
            Console.Write(" ");
        }
    }
}
