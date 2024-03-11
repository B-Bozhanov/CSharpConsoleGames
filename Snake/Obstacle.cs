namespace Snake
{
    using Common;

    using static Common.GlobalConstants;

    public class Obstacle
    {
        // TODO: Think for some better dataStructure;
        private readonly Random generator;
        private readonly List<Coordinates> obstacles;
        private readonly Color color;
        private readonly char symbol;
        private readonly int appearStartSecconds = 10;
        private readonly int appearEndSecconds = 30;
        private readonly int disapearStartSecconds = 20;
        private readonly int disapearEndSecconds = 50;

        public Obstacle()
        {
            this.generator = new Random();
            this.obstacles = [];
            this.color = Color.Cyan;
            this.symbol = GlobalConstants.Snake.ObstacleSymbol;
        }

        public List<Coordinates> Obstacles => this.obstacles;

        //TODO: May be in GameManager or ScoreManager:
        public int RandomAppearSecconds => this.generator.Next(this.appearStartSecconds, this.appearEndSecconds);

        //TODO: May be in GameManager or ScoreManager:
        public int RandomDisappearSecconds => this.generator.Next(this.disapearStartSecconds, this.disapearEndSecconds);

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

        public void Disappear(int index)
        {
            if (!IsInRange(index))
            {
                throw new IndexOutOfRangeException("The index is out of obstacles range!");
            }

            this.obstacles.RemoveAt(index);
        }

        public Coordinates RandomDisappear()
        {
            var index = this.generator.Next(0, this.obstacles.Count -1);
            var obstacle = this.obstacles[index];
            this.obstacles.RemoveAt(index);

            return obstacle;
        }

        private bool IsInRange(int index) => this.obstacles.Count >= 0 && this.obstacles.Count < index;
    }
}
