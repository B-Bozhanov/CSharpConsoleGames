namespace Snake.Models.Interfaces
{
    using GameMenu.Core.Interfaces;
    using GameMenu.UserInputHandle.Interfaces;
    using Utilities;

    public interface ISnake
    {
        public Queue<Coordinates> Elements { get; }
        public Coordinates head { get; set; }

        public Coordinates Move(IField field, IUserInput userInput);

        public void Eat(Coordinates food);
    }
}
