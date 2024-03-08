namespace Snake
{
    using System;

    using Common;

    using static Common.GlobalConstants;

    public class Snake
    {
        private readonly Queue<Coordinates> body;
        private Coordinates nextHeadPossition;
        private readonly Color bodyColor;
        private readonly Color nextHeadColor = Color.Red;
        private readonly Color bodyColor1 = Color.DarkYellow;
        private readonly Color bodyColor2 = Color.DarkGreen;
        private readonly char bodySymbol;
        private char nextHeadSymbol;

        public Snake(int snakeStartPossition)
        {
            this.body = new Queue<Coordinates>();
            this.nextHeadPossition = new Coordinates();
            this.bodySymbol = GlobalConstants.Snake.BodySymbol;
            this.nextHeadSymbol = GlobalConstants.Snake.HeadRight;

            for (int i = 1; i <= GlobalConstants.Snake.DefaultLength; i++)
            {
                this.body.Enqueue(new Coordinates(snakeStartPossition, i, this.bodySymbol, this.bodyColor));
            }
        }
        public Queue<Coordinates> Body => this.body;

        public Coordinates CurrentHeadPossition => this.body.Last();

        public Coordinates NextHeadPossition => this.nextHeadPossition;

        public Coordinates? TailPossition { get; private set; }

        public void ChangeNextHeadPossition(Direction direction)
        {
            if (direction.CurrentDirection.Equals(direction.Right)) this.nextHeadSymbol = GlobalConstants.Snake.HeadRight;
            if (direction.CurrentDirection.Equals(direction.Left)) this.nextHeadSymbol = GlobalConstants.Snake.HeadLeft;
            if (direction.CurrentDirection.Equals(direction.Down)) this.nextHeadSymbol = GlobalConstants.Snake.HeadDown;
            if (direction.CurrentDirection.Equals(direction.Up)) this.nextHeadSymbol = GlobalConstants.Snake.HeadUp;

            this.nextHeadPossition = new()
            {
                Color = this.nextHeadColor,
                Symbol = this.nextHeadSymbol,
                Row = this.CurrentHeadPossition.Row + direction.CurrentDirection.Row,
                Column = this.CurrentHeadPossition.Column + direction.CurrentDirection.Column
            };

            this.CurrentHeadPossition.Symbol = this.bodySymbol;
        }

        public bool Eat(Coordinates food)
        {
            if (this.nextHeadPossition.AreEqual(food))
            {
                this.body.Enqueue(this.NextHeadPossition);
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
                => obstacles.Any(o => o.AreEqual(this.nextHeadPossition));

        public bool IsEatMySelf()
                => this.body.Any(x => x.AreEqual(this.nextHeadPossition));

        public bool IsOnField()
                => this.NextHeadPossition.Row >= Field.FieldRows + 1 || this.NextHeadPossition.Row < Field.InfoWindowHeight + 2
                   || this.NextHeadPossition.Column >= Field.FieldColumns - 1 || this.NextHeadPossition.Column < 1;

        public void IncreaseSpeed(int speed)
        {

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
                if (body.Equals(this.NextHeadPossition))
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
