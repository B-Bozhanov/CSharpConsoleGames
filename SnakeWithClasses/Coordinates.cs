
namespace Snake
{
    internal class Coordinates
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public Coordinates()
        {
            this.Row = 0;  // Default Value
            this.Col = 0;  // Default Value
        }
    }
}
