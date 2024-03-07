namespace Snake
{
    public class Food
    {
        private readonly Random foodGenerator;
        private Coordinates coordinates;
        private readonly char symbol;

        public Food()
        {
            foodGenerator = new Random();
            this.coordinates = new Coordinates();
            this.symbol = '@';
        }

        public Coordinates Coordinates => this.coordinates;

        public string Symbol => this.symbol.ToString();

        public Coordinates Generate(IEnumerable<Coordinates> snakeBody, IEnumerable<Coordinates> obstacles, Coordinates rowsRange, Coordinates columnsRange)
        {
            do
            {
                this.coordinates.Row = this.foodGenerator.Next(rowsRange.Row, rowsRange.Column);
                this.coordinates.Column = this.foodGenerator.Next(columnsRange.Row, columnsRange.Column);
            }
            while (snakeBody.Contains(this.coordinates) || obstacles.Contains(this.coordinates));
            
            return this.Coordinates;
        }
    }
}
