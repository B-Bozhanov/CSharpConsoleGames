using Snake.Common;
using Snake.Services.Models.Interfaces;

namespace Snake.Services.Models
{

    public class Food : IFood
    {
        public Coordinates FoodPossition { get; set; }
    }
}
