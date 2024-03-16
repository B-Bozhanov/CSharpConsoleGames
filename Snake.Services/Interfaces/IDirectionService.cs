namespace Snake.Services.Interfaces
{
    using Snake.Models;

    public interface IDirectionService
    {
        public Coordinates CurrentDirection { get; set; }

        public Coordinates Down { get; }

        public Coordinates Left { get; }

        public Coordinates Right { get; }

        public Coordinates Up { get; }

        public void ChangeCurrentDirection(KeyboardKey currentPressedKey);
    }
}
