namespace Snake.Models.Interfaces
{
    using GameMenu.Core.Interfaces;
    using GameMenu.UserInputHandle.Interfaces;
    using Utilities;

    public interface ISnake
    {
        public Queue<Coordinates> Elements { get; }

        public Coordinates Head { get; }

        public Coordinates Move(IUserInput input, IField field);

        public void Eat(Coordinates food);
    }
}
