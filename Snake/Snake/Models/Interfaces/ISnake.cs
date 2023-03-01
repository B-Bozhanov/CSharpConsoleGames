namespace Snake.Services.Models.Interfaces
{
    using GameMenu.Core.Interfaces;
    using GameMenu.UserInputHandle.Interfaces;

    using global::Snake.Common;

    public interface ISnake
    {
        public Queue<Coordinates> Elements { get; }

        public Coordinates Head { get; }

        public Coordinates Move(IField field, IUserInput userInput, IObstacle obstacle, IFood food);
    }
}
