namespace Snake.Models.SnakeModels.Models
{
    using System.Collections.Generic;

    using Models.Interfaces;

    using Snake.Common;

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
