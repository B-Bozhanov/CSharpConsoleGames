namespace Snake.Menu.Wellcome
{
    using Snake.Models.Models.Menues;

    public class About(string name) : MenuBase(name)
    {
        public override int PriorityNumber { get; protected set; } = 3;

        public override void Execute(Stack<string> namespaces)
        {
            throw new NotImplementedException();
        }
    }
}
