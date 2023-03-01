namespace Snake.Services.Models.Interfaces
{
    using global::Snake.Common;
    using global::Snake.Models.Menu.Core.Interfaces;
    using global::Snake.Models.Menu.UserInputHandle.Interfaces;

    public interface ISnake
    {
        public Queue<Coordinates> Elements { get; }

        public Coordinates Head { get; }

        public Coordinates Move(IField field, IUserInput userInput, IObstacle obstacle, IFood food);
    }
}
