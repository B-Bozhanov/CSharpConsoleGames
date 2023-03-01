namespace Snake.Models.SnakeModels.Models
{
    using Snake.Common;
    using Snake.Models.SnakeModels.Models.Interfaces;

    public class Food : IFood
    {
        public Coordinates FoodPossition { get; set; }
    }
}
