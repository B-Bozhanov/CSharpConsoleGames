namespace Snake
{
    using Common;

    public class Snake
    {
        private readonly Queue<Coordinates> body;
        private Coordinates nextHeadPossition;
        private int speed = GlobalConstants.Snake.DefaultSpeed;
        private readonly Color bodyColor;
        private readonly Color nextHeadColor = Color.Red;
        private readonly Color bodyColor1 = Color.DarkYellow;
        private readonly Color bodyColor2 = Color.DarkGreen;
        private readonly char bodySymbol;
        private char nextHeadSymbol;
        private readonly IField field;

        public Snake(IField field, int snakeStartPossition)
        {
            this.body = new Queue<Coordinates>();
            this.nextHeadPossition = new Coordinates();
            this.bodySymbol = GlobalConstants.Snake.BodySymbol;
            this.nextHeadSymbol = GlobalConstants.Snake.HeadRight;
            this.field = field;

            for (int i = 1; i <= GlobalConstants.Snake.DefaultLength; i++)
            {
                this.body.Enqueue(new Coordinates(snakeStartPossition, i, this.bodySymbol, this.bodyColor));
            }
        }
        public Queue<Coordinates> Body => this.body;

        public Coordinates CurrentHeadPossition => this.body.Last();

        public Coordinates NextHeadPossition => this.nextHeadPossition;

        public int Speed => this.speed;

        public Coordinates TailPossition { get; private set; } = null!;

        public void ChangeNextHeadPossition(Direction direction)
        {
            if (direction.CurrentDirection.Equals((object)direction.Right)) this.nextHeadSymbol = GlobalConstants.Snake.HeadRight;
            if (direction.CurrentDirection.Equals((object)direction.Left)) this.nextHeadSymbol = GlobalConstants.Snake.HeadLeft;
            if (direction.CurrentDirection.Equals((object)direction.Down)) this.nextHeadSymbol = GlobalConstants.Snake.HeadDown;
            if (direction.CurrentDirection.Equals((object)direction.Up)) this.nextHeadSymbol = GlobalConstants.Snake.HeadUp;

            this.CurrentHeadPossition.Symbol = this.bodySymbol;
            this.nextHeadPossition = new()
            {
                Color = this.nextHeadColor,
                Symbol = this.nextHeadSymbol,
                Row = this.CurrentHeadPossition.Row + direction.CurrentDirection.Row,
                Column = this.CurrentHeadPossition.Column + direction.CurrentDirection.Column
            };

        }

        public bool Eat(Coordinates food)
        {
            if (this.nextHeadPossition.Equals(food))
            {
                this.body.Enqueue(this.NextHeadPossition);
                return true;
            }

            return false;
        }

        public void GoThroughtWalls(Coordinates wallSize)
        {
            if (this.NextHeadPossition.Column >= this.field.GameColumns - wallSize.Column)
            {
                this.nextHeadPossition.Column = wallSize.Column;
            }
            if (this.NextHeadPossition.Column < wallSize.Column)
            {
                this.nextHeadPossition.Column = this.field.GameColumns - 1 - wallSize.Column;
            }
            if (this.NextHeadPossition.Row >= this.field.FieldRows + 1 - wallSize.Row)
            {
                this.nextHeadPossition.Row = this.field.InfoWindowHeight + 2;
            }
            if (this.NextHeadPossition.Row < this.field.InfoWindowHeight + 2)
            {
                this.nextHeadPossition.Row = this.field.FieldRows - wallSize.Row;
            }
        }

        //TODO: May be in obstacle file.
        public bool IsCrashToObstacle(IEnumerable<Coordinates> obstacles)
                => obstacles.Any(o => o.Equals(this.nextHeadPossition));

        public bool IsEatMySelf()
                => this.body.Any(x => x.Equals(this.nextHeadPossition));

        public bool IsOnField()
                => this.NextHeadPossition.Row >= this.field.FieldRows + 1 || this.NextHeadPossition.Row < this.field.InfoWindowHeight + 2
                   || this.NextHeadPossition.Column >= this.field.FieldColumns - 1 || this.NextHeadPossition.Column < 1;

        public void IncreaseSpeed(int speed)
        {
            this.speed -= speed;
        }

        public void Move()
        {
            this.body.Enqueue(this.NextHeadPossition);
            this.TailPossition = this.body.Dequeue();
            this.SetBodyColors();
        }

        private void SetBodyColors()
        {
            int count = 0;
            foreach (var body in this.body)
            {
                if (body.Equals((object)this.NextHeadPossition))
                {
                    break;
                }

                if (count % 2 == 0)
                {
                    body.Color = this.bodyColor1;
                }
                else
                {
                    body.Color = this.bodyColor2;
                }
                count++;
            }
        }
    }
}
