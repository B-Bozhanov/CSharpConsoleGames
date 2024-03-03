namespace Snake
{
    public class Snake
    {
        private readonly int snakeDefaultLength = 4;
        private readonly Queue<Coordinates> snakeElements = new();

        public Snake(int snakeStartPossition)
        {
            for (int i = 1; i <= snakeDefaultLength; i++)
            {
                snakeElements.Enqueue(new Coordinates(snakeStartPossition, i));
            }
        }

        public Queue<Coordinates> SnakeElements => this.snakeElements;

        public Coordinates CurrentHeadPossition => this.snakeElements.Last();

        public Coordinates NextHeadPossition { get; set; }

        public void Eat()
        {
            this.snakeElements.Enqueue(this.NextHeadPossition);
        }

        public void SetNextHeadPossition(Coordinates currentDirection)
        {

             this.NextHeadPossition = new Coordinates(this.CurrentHeadPossition.Row + currentDirection.Row, 
                                                      this.CurrentHeadPossition.Column + currentDirection.Column);
        }
    }
}
