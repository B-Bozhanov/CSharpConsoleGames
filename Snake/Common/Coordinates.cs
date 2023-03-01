namespace Snake.Common
{
    public class Coordinates
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

        public char Symbol { get; set; } = ' ';
    }
}