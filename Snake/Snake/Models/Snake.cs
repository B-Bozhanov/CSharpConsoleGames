namespace Snake.Services.Models
{
    using GameMenu.Core.Interfaces;
    using GameMenu.UserInputHandle;
    using GameMenu.UserInputHandle.Interfaces;

    using global::Snake.Common;
    using global::Snake.Common.Exceptions;
    using global::Snake.Services.Models.Interfaces;

    public class Snake : ISnake
    {
        private const char bodyShape = '●';
        private const char headShapeUp = '▲';
        private const char headShapeDown = '▼';
        private const char headShapeLeft = '◄';
        private const char headShapeRight = '►';
        private char currentHeadSymbol = headShapeRight;

        private readonly Coordinates[] directions;
        private int direction = 0;


        public Snake()
        {
            Elements = new Queue<Coordinates>();
            directions = new Coordinates[]
                 {
                     new Coordinates(0, 1),  // right
                     new Coordinates(0, -1), // left
                     new Coordinates(1, 0),  // down
                     new Coordinates(-1, 0)  // up
                 };
            this.Create();
        }


        public Queue<Coordinates> Elements { get; private set; }

        public Coordinates Head => Elements.Last();


        private void Create()
        {
            for (int i = 0; i < 6; i++)
            {
                Elements.Enqueue(new Coordinates(1, i));
            }
        }

        public Coordinates Move(IField field, IUserInput input, IObstacle obstacle, IFood food)
        {

            var userInput = input.GetInput();
            if (userInput == KeyPressed.Right && direction != 1)
            {
                direction = 0;
                currentHeadSymbol = headShapeRight;
            }
            if (userInput == KeyPressed.Left && direction != 0)
            {
                direction = 1;
                currentHeadSymbol = headShapeLeft;
            }
            if (userInput == KeyPressed.Down && direction != 3)
            {
                direction = 2;
                currentHeadSymbol = headShapeDown;
            }
            if (userInput == KeyPressed.Up && direction != 2)
            {
                direction = 3;
                currentHeadSymbol = headShapeUp;
            }

            Coordinates nextDirection = directions[direction];
            Coordinates nextHead = new Coordinates(nextDirection.Row + Head.Row, nextDirection.Col + Head.Col);
            nextHead = HeadValidator(field, nextHead, obstacle);

            Elements.Enqueue(nextHead);
            var tail = Elements.Dequeue();
            Eat(food);

            foreach (var item in Elements)
            {
                item.Symbol = bodyShape;
            }
            Head.Symbol = currentHeadSymbol;


            return tail;
        }

        private void Eat(IFood food)
        {
            if (food.FoodPossition != null)
            {
                if (Head.Row == food.FoodPossition.Row && Head.Col == food.FoodPossition.Col)
                {
                    Elements.Enqueue(food.FoodPossition);
                }
            }
        }

        private Coordinates HeadValidator(IField field, Coordinates head, IObstacle obstacle)
        {
            if (Elements.Contains(head))
            {
                throw new GameOverException("You hit the tail!");
            }
            if (obstacle.Obstacles.Contains(head))
            {
                throw new GameOverException("You hit obstacle!");
            }

            if (obstacle.IsWallAppear && (head.Row >= field.WindowHeight || head.Row < 0
                                     || head.Col >= field.WindowWidth || head.Col < 0))
            {
                throw new GameOverException("You hit the wall!");
            }
            else
            {
                if (head.Row >= field.WindowHeight)
                {
                    head.Row = 0;
                }
                else if (head.Row < 0)
                {
                    head.Row = field.WindowHeight - 1;
                }
                else if (head.Col >= field.WindowWidth)
                {
                    head.Col = 0;
                }
                else if (head.Col < 0)
                {
                    head.Col = field.WindowWidth - 1;
                }
            }

            return head;
        }
    }
}
