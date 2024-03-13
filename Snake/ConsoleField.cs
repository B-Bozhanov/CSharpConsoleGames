namespace Snake
{
    using System.Text;

    using Common;

    public class ConsoleField : IField
    {
        public ConsoleField(Coordinates gameCoordinates, int infoWindowHeight, Coordinates fieldCoordinates)
        {
            this.GameRows = gameCoordinates.Row;
            this.GameColumns = gameCoordinates.Column;
            this.InfoWindowHeight = infoWindowHeight;
            this.FieldRows = fieldCoordinates.Row;
            this.FieldColumns = fieldCoordinates.Column;

            this.SetSettings();
        }

        public int GameRows { get; }

        public int GameColumns { get; }

        public int InfoWindowHeight { get; }

        public int FieldRows { get; }

        public int FieldColumns { get; }

        public void SetSettings()
        {
            Console.CursorVisible = false;
            Console.Title = GlobalConstants.Snake.Name;
            Console.SetWindowSize(this.FieldColumns, this.FieldRows + 1);
            Console.SetBufferSize(this.FieldColumns, this.FieldRows + 1);
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}
