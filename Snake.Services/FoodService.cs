namespace Snake.Services
{
    using Common;

    using Snake.Models;
    using Snake.Services.Interfaces;

    public class FoodService : IFoodService
    {
        private readonly Random generator;
        private readonly Coordinates coordinates;
        private readonly Coordinates rowsRange;
        private readonly Coordinates columnsRange;
        private readonly int disapearStartSecconds = 5;
        private readonly int disapearEndSecconds = 20;
        private readonly IFieldService field;

        public FoodService(IFieldService field)
        {
            generator = new Random();
            coordinates = new Coordinates
            {
                Color = Color.Green,
                Symbol = GlobalConstants.Snake.FoodSymbol
            };
            this.field = field;

            rowsRange = new Coordinates(this.field.InfoWindowHeight + 2, this.field.FieldRows);
            columnsRange = new Coordinates(0, this.field.FieldColumns);

        }

        public Coordinates Coordinates => coordinates;

        //TODO: May be in GameManager or ScoreManager:
        public int RandomDisapearSeconds => generator.Next(disapearStartSecconds, disapearEndSecconds);

        public Coordinates Generate(IEnumerable<Coordinates> snakeBody, IEnumerable<Coordinates> obstacles, Coordinates wallsSize)
        {
            rowsRange.Column -= wallsSize.Row;
            columnsRange.Row = wallsSize.Column;
            columnsRange.Column -= wallsSize.Column;

            do
            {
                coordinates.Row = generator.Next(rowsRange.Row, rowsRange.Column);
                coordinates.Column = generator.Next(columnsRange.Row, columnsRange.Column);
            }
            while (snakeBody.Contains(coordinates) || obstacles.Contains(coordinates));

            return Coordinates;
        }
    }
}
