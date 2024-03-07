namespace Snake
{
    using Common;

    using static Common.GlobalConstants;

    public class Snake
    {
        private readonly Queue<Coordinates> body;
        private Coordinates nextHeadPossition;

        public Snake(int snakeStartPossition)
        {
            this.body = new Queue<Coordinates>();
            this.nextHeadPossition = new Coordinates();
            for (int i = 1; i <= GlobalConstants.Snake.DefaultLength; i++)
            {
                body.Enqueue(new Coordinates(snakeStartPossition, i));
            }
        }

        public Queue<Coordinates> Body => this.body;

        public Coordinates CurrentHeadPossition => this.body.Last();

        public Coordinates NextHeadPossition => this.nextHeadPossition;

        public void ChangeNextHeadPossition(Coordinates nextHeadPossition)
        {
            this.nextHeadPossition = nextHeadPossition;
        }

        public bool Eat(Coordinates food)
        {
            if (this.NextHeadPossition.Row == food.Row && this.NextHeadPossition.Column == food.Column)
            {
                this.Body.Enqueue(this.NextHeadPossition);
                return true;
            }
            return false;
        }

        public void GoThroughtWalls(Coordinates wallSize)
        {
            if (this.NextHeadPossition.Column >= Field.GameColumns - wallSize.Column)
            {
                this.nextHeadPossition.Column = wallSize.Column;
            }
            if (this.NextHeadPossition.Column < wallSize.Column)
            {
                this.nextHeadPossition.Column = Field.GameColumns - 1 - wallSize.Column;
            }
            if (this.NextHeadPossition.Row >= Field.FieldRows + 1 - wallSize.Row)
            {
                this.nextHeadPossition.Row = Field.InfoWindowHeight + 2;
            }
            if (this.NextHeadPossition.Row < Field.InfoWindowHeight + 2)
            {
                this.nextHeadPossition.Row = Field.FieldRows - wallSize.Row;
            }
        }

        //TODO: May be in obstacle file.
        public bool IsCrashToObstacle(IEnumerable<Coordinates> obstacles)
                => obstacles.Any(o => o.Row == this.nextHeadPossition.Row && o.Column == this.nextHeadPossition.Column);

        public bool IsEatMySelf()
                => this.body.Any(x => x.Row == this.nextHeadPossition.Row && x.Column == this.nextHeadPossition.Column);

        public bool IsOnField()
                => this.nextHeadPossition.Row >= Field.FieldRows + 1 || this.nextHeadPossition.Row < Field.InfoWindowHeight + 2
                   || this.nextHeadPossition.Column >= Field.FieldColumns - 1 || this.nextHeadPossition.Column < 1;

        public void IncreaseSpeed(int speed)
        {

        }

        public void Move(Coordinates currentDirection)
        {
            //this.body.Enqueue(this.nextHeadPossition);
            this.nextHeadPossition.Row = this.CurrentHeadPossition.Row + currentDirection.Row;
            this.nextHeadPossition.Column = this.CurrentHeadPossition.Column + currentDirection.Column;
             //this.body.Dequeue();
        }
    }
}
