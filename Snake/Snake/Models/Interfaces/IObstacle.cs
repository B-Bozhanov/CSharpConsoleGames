using Snake.Common;

namespace Snake.Services.Models.Interfaces
{

    public interface IObstacle
    {
        public bool IsWallAppear { get; set; }

        public ICollection<Coordinates> Obstacles { get; set; }
    }
}
