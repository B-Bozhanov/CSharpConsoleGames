namespace Snake.Services.Models.Interfaces
{
    using global::Snake.Common;

    public interface IFood
    {
        public Coordinates FoodPossition { get; set; }
    }
}
