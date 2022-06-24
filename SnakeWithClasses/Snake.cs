using Snake.Interfaces;
using Snake.UserInput;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Snake 
    {
        private readonly Coordinates[] directions;

        internal Snake(int snakeLenght)
        {
            this.SnakeElements = new Queue<Coordinates>();
            this.directions = new Coordinates[]
               {
                new Coordinates(0, 1),  // Right/ index 0
                new Coordinates(0, -1), // Left / index 1
                new Coordinates(1, 0),  // Down / index 2
                new Coordinates(-1, 0)  // Up   / index 3
               };
            this.NextHead = new Coordinates();
            this.SnakeLenght = snakeLenght;
            this.Direction = 0; // Right by default;

            for (int i = 1; i <= this.SnakeLenght; i++)   // create the snake:
            {
                this.SnakeElements.Enqueue(new Coordinates(Field.InfoWindow + 2, i));   // InfoWindow will be always set by develepor.
            }
        }

        internal Queue<Coordinates> SnakeElements { get; private set; }
        internal Coordinates NextHead { get; private set; }
        internal int Direction { get; private set; }
        internal int SnakeLenght { get; }


        private int GetDirection(int direction)
        {
            IUserInput input = new UserKeyInput();
            var key = input.GetInput();
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
        internal void NextPossition()
        {
            this.Direction = GetDirection(this.Direction);
            Coordinates snakeHead = this.SnakeElements.Last();
            Coordinates nextHeadDirection = this.directions[this.Direction];
            this.NextHead = new Coordinates(snakeHead.Row + nextHeadDirection.Row, snakeHead.Col + nextHeadDirection.Col);
        }
        public void Move()   // May be not necessarily:
        {
            this.SnakeElements.Enqueue(NextHead);
            this.SnakeElements.Dequeue();
        }
        public bool IsDeath(int row, int col, bool wallsAppear, List<Coordinates> obstacles)  // TODO: Не ми се струва добре.... даже не е!
        {
            if (wallsAppear)
            {
                if (this.NextHead.Row >= row + 2 || this.NextHead.Row < Field.InfoWindow + 2   // Die
                  || this.NextHead.Col >= col - 1 || this.NextHead.Col < 1)
                {
                    return true;
                }
            }
            else
            {
                if (NextHead.Row == row - 1) NextHead.Row = Field.InfoWindow + 2;    // Goes through the walls
                if (NextHead.Row < Field.InfoWindow + 2) NextHead.Row = row - 1;
                if (NextHead.Col >= col - 1) NextHead.Col = 1;
                if (NextHead.Col < 1) NextHead.Col = col - 1;
            }

            //foreach (var element in this.SnakeElements)
            //{
            //    if (NextHead.Row == element.Row && NextHead.Col == element.Col)
            //    {
            //        return true;
            //    }
            //}
            foreach (var obstacle in obstacles)
            {
                if (this.SnakeElements.Any(s => s.Row == obstacle.Row && s.Col == obstacle.Col))
                {
                    return true;
                }
            }
            return false;
        }
        public void Eat(Coordinates food)
        {
            this.NextHead.Row = food.Row;
            this.NextHead.Col = food.Col;
            this.SnakeElements.Enqueue(this.NextHead);
        }
    }
}
