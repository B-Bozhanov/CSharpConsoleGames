namespace Snake.Services.Interfaces
{
    using Snake.Models;

    public interface IObstacleService
    {
        public IList<Coordinates> Obstacles { get; }

        //TODO: May be in GameManager or ScoreManager:
        public int RandomAppearSecconds { get; }

        //TODO: May be in GameManager or ScoreManager:
        public int RandomDisappearSecconds { get; }

        public Coordinates Generate(IFieldService field, IEnumerable<Coordinates> snakeBody, Coordinates foodCoordinates, Coordinates wallsSize);

        public void GenerateFirstCount(IFieldService field, IEnumerable<Coordinates> snakeBody, Coordinates foodCoordinates, Coordinates wallsSize);

        public void Disappear(int index);

        public Coordinates RandomDisappear();
    }
}