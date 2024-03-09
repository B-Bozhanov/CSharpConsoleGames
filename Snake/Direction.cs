namespace Snake
{
    public class Direction
    {
        private readonly Coordinates[] directions;

        public Direction()
        {
            this.directions =
            [
                new Coordinates(1, 0),   // Down, 0
                new Coordinates(0, -1),  // Left, 1
                new Coordinates(0, 1),   // Right, 2
                new Coordinates(-1, 0),  // Up, 3
            ];

            this.CurrentDirection = this.Right;   // Right by default
        }

        public Coordinates CurrentDirection { get; set; }

        public Coordinates Down => this.directions[0];

        public Coordinates Left => this.directions[1];

        public Coordinates Right => this.directions[2];

        public Coordinates Up => this.directions[3];

        public void ChangeCurrentDirection(KeyboardKey currentPressedKey)
        {
            switch (currentPressedKey)
            {
                case KeyboardKey.Right:
                    if (!this.CurrentDirection.Equals((object)this.Left))
                    {
                        this.CurrentDirection = this.Right;
                    }
                    break;
                case KeyboardKey.Left:
                    if (!this.CurrentDirection.Equals((object)this.Right))
                    {
                        this.CurrentDirection = this.Left;
                    }
                    break;
                case KeyboardKey.Up:
                    if (!this.CurrentDirection.Equals((object)this.Down))
                    {
                        this.CurrentDirection = this.Up;
                    }
                    break;
                case KeyboardKey.Down:
                    if (!this.CurrentDirection.Equals((object)this.Up))
                    {
                        this.CurrentDirection = this.Down;
                    }
                    break;
            }
        }
    }
}
