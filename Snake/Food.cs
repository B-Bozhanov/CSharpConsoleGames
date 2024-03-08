namespace Snake
{
    using Common;

    public class Food
    {
        private readonly Random generator;
        private Coordinates coordinates;
        private readonly int disapearStartSecconds = 8;
        private readonly int disapearEndSecconds = 20;
        private readonly char symbol;

        public Food()
        {
            generator = new Random();
            this.coordinates = new Coordinates();
            this.symbol = GlobalConstants.Snake.FoodSymbol;
        }

        public Coordinates Coordinates => this.coordinates;

        public int DisapearSeconds => this.generator.Next(this.disapearStartSecconds, disapearEndSecconds);

        public string Symbol => this.symbol.ToString();

        public Coordinates Generate(IEnumerable<Coordinates> snakeBody, IEnumerable<Coordinates> obstacles, Coordinates rowsRange, Coordinates columnsRange)
        {
            do
            {
                this.coordinates.Row = this.generator.Next(rowsRange.Row, rowsRange.Column);
                this.coordinates.Column = this.generator.Next(columnsRange.Row, columnsRange.Column);
            }
            while (snakeBody.Contains(this.coordinates) || obstacles.Contains(this.coordinates));
            
            return this.Coordinates;
        }
    }
}
