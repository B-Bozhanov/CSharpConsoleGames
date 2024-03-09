namespace Snake
{
    using Common;

    using static Common.GlobalConstants;

    public class Food
    {
        private readonly Random generator;
        private readonly Coordinates coordinates;
        private readonly Coordinates rowsRange;
        private readonly Coordinates columnsRange;
        private readonly int disapearStartSecconds = 8;
        private readonly int disapearEndSecconds = 20;

        public Food()
        {
            generator = new Random();
            this.coordinates = new Coordinates
            {
                Color = Color.Green,
                Symbol = GlobalConstants.Snake.FoodSymbol
            };

            this.rowsRange = new Coordinates(Field.InfoWindowHeight + 2, Field.FieldRows);
            this.columnsRange = new Coordinates(0, Field.FieldColumns);
        }

        public Coordinates Coordinates => this.coordinates;

        public int DisapearSeconds => this.generator.Next(this.disapearStartSecconds, disapearEndSecconds);

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
