namespace SnakeProject.Models.Field.Interfaces
{
    public interface IField
    {
        public int Row { get; }
        public int Col { get; }
        public int GameInfoWindow { get; }
        public int MenuRow { get; }
        public int MenuCol { get; }
    }
}
