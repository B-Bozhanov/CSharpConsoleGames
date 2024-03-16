using Snake.Models;
using Snake.Services.Interfaces;

namespace Snake.Services
{
    public class DirectionService : IDirectionService
    {
        private readonly Coordinates[] directions;

        public DirectionService()
        {
            directions =
            [
                new Coordinates(1, 0),   // Down, 0
                new Coordinates(0, -1),  // Left, 1
                new Coordinates(0, 1),   // Right, 2
                new Coordinates(-1, 0),  // Up, 3
            ];

            CurrentDirection = Right;   // Right by default
        }

        public Coordinates CurrentDirection { get; set; }

        public Coordinates Down => directions[0];

        public Coordinates Left => directions[1];

        public Coordinates Right => directions[2];

        public Coordinates Up => directions[3];

        public void ChangeCurrentDirection(KeyboardKey currentPressedKey)
        {
            switch (currentPressedKey)
            {
                case KeyboardKey.Right:
                    if (!CurrentDirection.Equals(Left))
                    {
                        CurrentDirection = Right;
                    }
                    break;
                case KeyboardKey.Left:
                    if (!CurrentDirection.Equals(Right))
                    {
                        CurrentDirection = Left;
                    }
                    break;
                case KeyboardKey.Up:
                    if (!CurrentDirection.Equals(Down))
                    {
                        CurrentDirection = Up;
                    }
                    break;
                case KeyboardKey.Down:
                    if (!CurrentDirection.Equals(Up))
                    {
                        CurrentDirection = Down;
                    }
                    break;
            }
        }
    }
}
