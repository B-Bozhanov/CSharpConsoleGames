namespace Snake.Utilities
{
    using Interfaces;

    public class Coordinates : ICoordinates
    {
        public Coordinates()
        {
            this.Row = 0;
            this.Col = 0;
        }
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}