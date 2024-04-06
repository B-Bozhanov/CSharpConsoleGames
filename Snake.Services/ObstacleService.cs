namespace Snake.Services
{
    using Common;

    using Snake.Models;
    using Snake.Services.Interfaces;

    public class ObstacleService : IObstacleService
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

        public ObstacleService()
        {
            this.generator = new Random();
            this.obstacles = [];
            this.color = Color.Cyan;
            this.symbol = GlobalConstants.Snake.ObstacleSymbol;

        }

        public IList<Coordinates> Obstacles => obstacles;

        //TODO: May be in GameManager or ScoreManager:
        public int RandomAppearSecconds => generator.Next(appearStartSecconds, appearEndSecconds);

        //TODO: May be in GameManager or ScoreManager:
        public int RandomDisappearSecconds => generator.Next(disapearStartSecconds, disapearEndSecconds);

        public Coordinates Generate(IFieldService field, IEnumerable<Coordinates> snakeBody, Coordinates foodCoordinates, Coordinates wallsSize)
        {
            var obstacle = new Coordinates(0 , 0, this.symbol, this.color);

            do
            {
                obstacle.Row = generator.Next(field.InfoWindowHeight + 2, field.FieldRows - wallsSize.Row);
                obstacle.Column = generator.Next(wallsSize.Column, field.FieldColumns - wallsSize.Column);
            }
            while (snakeBody.Contains(obstacle)
              || foodCoordinates.Row == obstacle.Row
              || foodCoordinates.Column == obstacle.Column
              || obstacles.Contains(obstacle));

            obstacles.Add(obstacle);

            return obstacle;
        }

        public void GenerateFirstCount(IFieldService field, IEnumerable<Coordinates> snakeBody, Coordinates foodCoordinates, Coordinates wallsSize)
        {
            for (int i = 0; i < GlobalConstants.Snake.FirstObstaclesCount; i++)
            {
                Generate(field, snakeBody, foodCoordinates, wallsSize);
            }
        }

        public void Disappear(int index)
        {
            if (!IsInRange(index))
            {
                throw new IndexOutOfRangeException("The index is out of obstacles range!");
            }

            obstacles.RemoveAt(index);
        }

        public Coordinates RandomDisappear()
        {
            var index = generator.Next(0, Obstacles.Count - 1);
            var obstacle = Obstacles[index];
            obstacles.Remove(obstacle);

            return obstacle;
        }

        private bool IsInRange(int index) => obstacles.Count >= 0 && obstacles.Count < index;
    }
}
