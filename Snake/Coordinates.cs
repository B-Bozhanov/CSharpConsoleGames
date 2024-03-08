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

        public bool AreEqual(Coordinates other)
        {
            if (other.Row == this.Row && other.Column == this.Column)
            {
                return true;
            }

            return false;
        }

        public bool AreAllEquals(Coordinates other)
        {
            if (other.Equals(this))
            {
                return true;
            }

            return false;
        }
    }
}