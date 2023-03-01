namespace Snake.Models.SnakeModels.Models.Interfaces
{
    using System.Collections.Generic;

    using Snake.Common;
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.UserInputHandle.Interfaces;

    public interface ISnake
    {
        public Queue<Coordinates> Elements { get; }

        public Coordinates Head { get; }

        public Coordinates Move(IField field, IUserInput userInput, IObstacle obstacle, IFood food);
    }
}
