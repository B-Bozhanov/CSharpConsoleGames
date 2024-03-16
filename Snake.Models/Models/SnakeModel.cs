namespace Snake.Models.Models
{
    using Snake.Models;

    public class SnakeModel
    {
        public IEnumerable<Coordinates> Body { get; set; } = null!;
    }
}
