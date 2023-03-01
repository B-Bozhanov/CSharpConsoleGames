namespace Snake.Models.SnakeModels.Models.Interfaces
{
    using System.Collections.Generic;

    using Snake.Common;

    public interface IObstacle
    {
        public bool IsWallAppear { get; set; }

        public ICollection<Coordinates> Obstacles { get; set; }
    }
}
