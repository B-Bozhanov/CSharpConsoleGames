namespace Snake.Menu.Main
{
    using Snake.Models.Models.Menues;

    public class Exit(string name) : MenuBase(name)
    {
        public override int PriorityNumber { get; protected set; } = 3;

        public override void Execute(Stack<string> namespaces)
        {
            throw new NotImplementedException();
        }
    }
}
