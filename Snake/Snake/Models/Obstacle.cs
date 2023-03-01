namespace Snake.Services.Models
{
    using global::Snake.Common;

    using Models.Interfaces;

    public class Obstacle : IObstacle
    {
        public Obstacle()
        {
            Obstacles = new List<Coordinates>();
        }

        public bool IsWallAppear { get; set; } = false;

        public ICollection<Coordinates> Obstacles { get; set; }
    }
}
