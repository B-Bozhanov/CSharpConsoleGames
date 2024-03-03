namespace Snake
{
    using Common;

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

        public void Eat()
        {
            this.body.Enqueue(this.nextHeadPossition);
        }

        public bool IsDead() => this.body.Any(x => x.Row == this.nextHeadPossition.Row && x.Column == this.nextHeadPossition.Column);
        
        public void SetNextHeadPossition(Coordinates currentDirection)
        {
            this.nextHeadPossition.Row = this.CurrentHeadPossition.Row + currentDirection.Row;
            this.nextHeadPossition.Column = this.CurrentHeadPossition.Column + currentDirection.Column;
        }
    }
}
