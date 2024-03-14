namespace Snake
{
    using Common;

    public class Food
    {
        private readonly Random generator;
        private readonly Coordinates coordinates;
        private readonly Coordinates rowsRange;
        private readonly Coordinates columnsRange;
        private readonly int disapearStartSecconds = 5;
        private readonly int disapearEndSecconds = 20;
        private readonly IField field;

        public Food(IField field)
        {
            generator = new Random();
            this.coordinates = new Coordinates
            {
                Color = Color.Green,
                Symbol = GlobalConstants.Snake.FoodSymbol
            };
            this.field = field;

            this.rowsRange = new Coordinates(this.field.InfoWindowHeight + 2, this.field.FieldRows);
            this.columnsRange = new Coordinates(0, this.field.FieldColumns);

        }

        public Coordinates Coordinates => this.coordinates;

        //TODO: May be in GameManager or ScoreManager:
        public int RandomDisapearSeconds => this.generator.Next(this.disapearStartSecconds, this.disapearEndSecconds);

        public Coordinates Generate(IEnumerable<Coordinates> snakeBody, IEnumerable<Coordinates> obstacles, Coordinates wallsSize)
        {
            this.rowsRange.Column -= wallsSize.Row;
            this.columnsRange.Row = wallsSize.Column;
            this.columnsRange.Column -= wallsSize.Column;

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
