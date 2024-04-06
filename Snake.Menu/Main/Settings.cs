namespace Snake.Menu.Main
{
    using Snake.Models.Models.Menues;

    public class Settings(string name) : MenuBase(name)
    {
        public override int PriorityNumber { get; protected set; } = 1;

        public override void Execute(Stack<string> namespaces)
        {
            throw new NotImplementedException();
        }
    }
}
