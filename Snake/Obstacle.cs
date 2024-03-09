namespace Snake
{
    using Common;

    using static Common.GlobalConstants;

    public class Obstacle
    {
        private readonly Random generator;
        private readonly List<Coordinates> obstacles;
        private readonly Color color;
        private readonly char symbol;

        public Obstacle()
        {
            this.generator = new Random();
            this.obstacles = [];
            this.color = Color.Cyan;
            this.symbol = GlobalConstants.Snake.ObstacleSymbol;
        }

        public IEnumerable<Coordinates> Obstacles => this.obstacles;

        public Coordinates Generate(IEnumerable<Coordinates> snakeBody, Coordinates foodCoordinates, Coordinates wallsSize)
        {
            var obstacle = new Coordinates();
            obstacle.Color = this.color;
            obstacle.Symbol = this.symbol;

            do
            {
                obstacle.Row = this.generator.Next(Field.InfoWindowHeight + 2, Field.FieldRows - wallsSize.Row);
                obstacle.Column = this.generator.Next(wallsSize.Column, Field.FieldColumns - wallsSize.Column);
            } 
            while (snakeBody.Contains(obstacle)
              || foodCoordinates.Row == obstacle.Row
              || foodCoordinates.Column == obstacle.Column
              || this.obstacles.Contains(obstacle));

            this.obstacles.Add(obstacle);

            return obstacle;
        }

        public void GenerateFirstCount(IEnumerable<Coordinates> snakeBody, Coordinates foodCoordinates, Coordinates wallsSize)
        {
            for (int i = 0; i < GlobalConstants.Snake.FirstObstaclesCount; i++)
            {
                var obstacle = this.Generate(snakeBody, foodCoordinates, wallsSize);
                this.obstacles.Add(obstacle);
            }
        }
    }
}
