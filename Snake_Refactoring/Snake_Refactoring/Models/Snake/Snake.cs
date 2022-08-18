namespace SnakeProject.Models.Snake
{
    using SnakeProject.UserInput;
    using SnakeProject.UserInput.Inerfaces;
    using SnakeProject.Utilites;

    internal class Snake : ISnake
    {
        private readonly Coordinates[] directions;
        private readonly Queue<Coordinates> snakeElements;
        private Coordinates snakeHead;
        private int direction;
        private int snakeLength;


        private Snake()
        {
            snakeElements = new Queue<Coordinates>();
            snakeHead = new Coordinates();
            directions = new Coordinates[]
              {
                new Coordinates(0, 1),  // Right/ index 0
                new Coordinates(0, -1), // Left / index 1
                new Coordinates(1, 0),  // Down / index 2
                new Coordinates(-1, 0)  // Up   / index 3
              };
            direction = 0; // Right by default:
        }
        public Snake(int snakeLength, int gameInfoWindow) : this()
        {
            SnakeLength = snakeLength;
            SnakeCreation(gameInfoWindow);
        }


        public IReadOnlyCollection<Coordinates> SnakeElements
        {
            get => snakeElements;
        }


        public int SnakeLength
        {
            get => snakeLength;
            set
            {
                if (value < 6 || value > 15)
                {
                    throw new ArgumentException("Snake length must be between 6 - 15");
                }
                snakeLength = value;
            }
        }


        public int NextDirection { get => direction; }



        private void SnakeCreation(int gameInfoWindow)
        {
            for (int i = 1; i <= snakeLength; i++)   // create the snake:
            {
                snakeElements.Enqueue(new Coordinates(gameInfoWindow + 2, i));   // TODO: InfoWindow will be always set by develepor.
            }
        }

        private int GetDirection()
        {
            IUserInputHandle input = new UserInputHandle();
            KeyPressed key = input.GetInput();

            switch (key)
            {
                case KeyPressed.Right:
                    if (direction == 1) direction = 1;
                    else direction = 0;
                    break;
                case KeyPressed.Left:
                    if (direction == 0) direction = 0;
                    else direction = 1;
                    break;
                case KeyPressed.Down:
                    if (direction == 3) direction = 3;
                    else direction = 2;
                    break;
                case KeyPressed.Up:
                    if (direction == 2) direction = 2;
                    else direction = 3;
                    break;
                    //case KeyPressed.Exit:TODO: exit from the game

            }
            return direction;
        }

        public void NextPossition()
        {
            direction = GetDirection();
            Coordinates lastHead = snakeElements.Last();
            Coordinates nextHead = directions[direction];
            snakeHead = new Coordinates(lastHead.Row + nextHead.Row, lastHead.Col + nextHead.Col);
        }

        public void Move()
        {
            snakeElements.Enqueue(snakeHead);
            snakeElements.Dequeue();
        }

        public void Eat(Coordinates food)
        {
            if (snakeHead.Row == food.Row && snakeHead.Col == food.Col)
            {
                snakeElements.Enqueue(snakeHead);
            }
        }

        public Coordinates GetSnakeNextHead()
        {
            return snakeHead;
        }

        public Coordinates GetSnakeTail()
        {
            return snakeElements.Peek();
        }
    }
}
