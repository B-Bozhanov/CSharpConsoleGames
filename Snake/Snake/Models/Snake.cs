namespace Snake.Models
{
    using GameMenu.Core.Interfaces;
    using GameMenu.UserInputHandle;
    using GameMenu.UserInputHandle.Interfaces;
    using Interfaces;
    using Utilities;


    public class Snake : ISnake
    {
        private readonly Coordinates[] directions;
        private int direction = 0;


        public Snake()
        {
            this.Elements = new Queue<Coordinates>();
            this.directions = new Coordinates[]
                 {
                     new Coordinates(0, 1),  // right
                     new Coordinates(0, -1), // left
                     new Coordinates(1, 0),  // down
                     new Coordinates(-1, 0)  // up
                 };
            this.Create();
        }


        public Queue<Coordinates> Elements { get; private set; }

        public Coordinates Head => this.Elements.Last(); 

        private void Create()
        {
            for (int i = 0; i < 6; i++)
            {
                this.Elements.Enqueue(new Coordinates(0, i));
            }
        }

        public Coordinates Move(IUserInput input, IField field)
        {
            var userInput = input.GetInput();
            if (userInput == KeyPressed.Right && this.direction != 1) this.direction = 0;
            if (userInput == KeyPressed.Left && this.direction != 0) this.direction = 1;
            if (userInput == KeyPressed.Down && this.direction != 3) this.direction = 2;
            if (userInput == KeyPressed.Up && this.direction != 2) this.direction = 3;


            Coordinates snakeHead = this.Elements.Last();
            Coordinates nextDirection = this.directions[direction];
            Coordinates head = new Coordinates(nextDirection.Row + snakeHead.Row, nextDirection.Col + snakeHead.Col);

            head = HeadValidator(field, head);

            this.Elements.Enqueue(head);
            var tail = this.Elements.Dequeue();
            return tail;
        }

        public void Eat(Coordinates food)
        {
            this.Elements.Enqueue(food);
        }

        private Coordinates HeadValidator(IField field, Coordinates head)
        {
            if (head.Row >= field.WindowHeight)
            {
                head.Row = 0;
            }
            if (head.Row < 0)
            {
                head.Row = field.WindowHeight - 1;
            }
            if (head.Col >= field.WindowWidth)
            {
                head.Col = 0;
            }
            if (head.Col < 0)
            {
                head.Col = field.WindowWidth - 1;
            }

            return head;
        }
    }
}
