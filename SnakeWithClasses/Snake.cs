using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Snake : UserKeyInput
    {
        private Coordinates[] directions; // May be ReadOnly!
        private static Queue<Coordinates> snakeCoords;
        private int snakeDirection = 0;  // Right by default
        private readonly int snakeLength;
        private Coordinates snakeNextHead;

        internal Snake(int snakeLenght)
        {
            this.snakeLength = snakeLenght;
            snakeCoords = new Queue<Coordinates>();

            for (int i = 1; i <= this.snakeLength; i++)   // create the snake:
            {
               // snakeCoords.Enqueue(new Coordinates(InfoWindow + 2, i));   // InfoWindow will be always set by develepor.
            }
            this.snakeNextHead = new Coordinates();
            this.directions = new Coordinates[]
               {
                new Coordinates(0, 1),  // Right/ index 0
                new Coordinates(0, -1), // Left / index 1
                new Coordinates(1, 0),  // Down / index 2
                new Coordinates(-1, 0)  // Up   / index 3
               };
            this.snakeNextHead = new Coordinates();
        }

        protected static Queue<Coordinates> SnakeElements { get => snakeCoords; }
        internal Coordinates NextHead { get => snakeNextHead; }
        internal int Direction { get => snakeDirection; }
        internal int SnakeLenght { get => snakeLength; }


        internal void NextPossition()
        {
            this.snakeDirection = GetDirection(this.snakeDirection);
            Coordinates snakeHead = snakeCoords.Last();
            Coordinates nextHeadDirection = this.directions[this.snakeDirection];
            this.snakeNextHead = new Coordinates(snakeHead.Row + nextHeadDirection.Row, snakeHead.Col + nextHeadDirection.Col);
        }
        private int GetDirection(int direction)
        {
            KeyPressed key = GetInput();
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
        public void Move()   // May be not necessarily:
        {
            snakeCoords.Enqueue(NextHead);
            snakeCoords.Dequeue();
        }
        public bool IsDeath(int row, int col, bool wallsAppear, List<Coordinates> obstacles)  // TODO: Не ми се струва добре.... даже не е!
        {
            //if (wallsAppear)
            //{
            //    if (this.NextHead.Row >= row + 2 || this.NextHead.Row < InfoWindow + 2   // Die
            //      || this.NextHead.Col >= col - 1 || this.NextHead.Col < 1)
            //    {
            //        return true;
            //    }
            //}
            //else
            //{
            //    if (NextHead.Row == row - 1) NextHead.Row = InfoWindow + 2;    // Goes through the walls
            //   // if (NextHead.Row < InfoWindow + 2) NextHead.Row = row - 1;
            //    if (NextHead.Col >= col - 1) NextHead.Col = 1;
            //    if (NextHead.Col < 1) NextHead.Col = col - 1;
            //}

            foreach (var element in SnakeElements)
            {
                if (NextHead.Row == element.Row && NextHead.Col == element.Col)
                {
                    return true;
                }
            }
            foreach (var obstacle in obstacles)
            {
                if (SnakeElements.Any(s => s.Row == obstacle.Row && s.Col == obstacle.Col))
                {
                    return true;
                }
            }
            return false;
        }
        public void Eat(Coordinates food)
        {
            this.snakeNextHead.Row = food.Row;
            this.snakeNextHead.Col = food.Col;
            snakeCoords.Enqueue(this.NextHead);
        }
    }
}
