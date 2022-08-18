namespace SnakeProject
{
    using SnakeProject.Utilites;

    internal interface ISnake
    {
        public IReadOnlyCollection<Coordinates> SnakeElements { get; }
        public int NextDirection { get; }
        public int SnakeLength { get; }
        public Coordinates GetSnakeNextHead();
        public Coordinates GetSnakeTail();
        public void NextPossition();
        public void Move();
        public void Eat(Coordinates food);
    }
}
