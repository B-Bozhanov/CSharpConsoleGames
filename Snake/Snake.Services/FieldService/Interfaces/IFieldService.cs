namespace Snake.Services.FieldService.Interfaces
{
    using Snake.Common;
    using Snake.Models.Menu;

    public interface IFieldService
    {
        public int WindowHeight { get; }

        public int WindowWidth { get; }

        public static Coordinates MenuStartPossition { get; }

        public Coordinates InfoWindow { get; }

        public void WindowResize(int row, int col);

        public void SetBackgroundColor(Color color);

        public void SetTextColor(Color color);

        public void ResetColor();
    }
}
