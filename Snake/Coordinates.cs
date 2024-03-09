// Primary constructor
namespace Snake
{
    public class Coordinates
    {
        public Coordinates()
        {
        }

        public Coordinates(int row, int column, char? symbol = null, Color color = Color.None)
        {
            this.Row = row;
            this.Column = column;
            this.Symbol = symbol;
            this.Color = color;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public char? Symbol { get; set; }

        public Color Color { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Coordinates other)
            {
                return false;
            }
            if (other.Row == this.Row && other.Column == this.Column)
            {
                return true;
            }

            return false;
        }
    }
}