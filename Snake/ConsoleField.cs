namespace Snake
{
    using System.Text;

    using Common;

    public class ConsoleField : IField
    {
        public ConsoleField()
        {
            this.GameRows = GlobalConstants.Field.GameRows;
            this.GameColumns = GlobalConstants.Field.GameColumns;
            this.InfoWindowHeight = GlobalConstants.Field.InfoWindowHeight;
            this.FieldRows = GlobalConstants.Field.FieldRows;
            this.FieldColumns = GlobalConstants.Field.FieldColumns;

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
