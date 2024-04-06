namespace Snake.Models
{
    public class Coordinates
    {
        public Coordinates()
        {
        }

        public Coordinates(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public Coordinates(int row, int column, char? symbol = null, Color color = Color.None) : this(row, column)
        {
            this.Symbol = symbol.ToString();
            this.Color = color;
        }

        public Coordinates(int row, int column, string? symbol = null, Color color = Color.None) : this(row, column)
        {
            this.Symbol = symbol;
            this.Color = color;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public string? Symbol { get; set; }

        public Color Color { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

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