namespace Snake.Services.Interfaces
{
    public interface IFieldService
    {
        public int GameRows { get; }

        public int GameColumns { get; }

        public int InfoWindowHeight { get; }

        public int FieldRows { get; }

        public int FieldColumns { get; }

        public void SetSettings();
    }
}