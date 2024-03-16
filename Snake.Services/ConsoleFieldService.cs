namespace Snake.Services
{
    using System.Text;

    using Common;

    using Snake.Services.Interfaces;

    public class ConsoleFieldService : IFieldService
    {
        public ConsoleFieldService()
        {
            GameRows = GlobalConstants.Field.GameRows;
            GameColumns = GlobalConstants.Field.GameColumns;
            InfoWindowHeight = GlobalConstants.Field.InfoWindowHeight;
            FieldRows = GlobalConstants.Field.FieldRows;
            FieldColumns = GlobalConstants.Field.FieldColumns;

            SetSettings();
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
            Console.SetWindowSize(FieldColumns, FieldRows + 1);

            if (OperatingSystem.IsWindows())
            {
                Console.SetBufferSize(FieldColumns, FieldRows + 1);
            }

            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}
