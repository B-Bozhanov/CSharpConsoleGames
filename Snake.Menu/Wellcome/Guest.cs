namespace Snake.Menu.Wellcome
{
    using Snake.Models.Models.Menues;

    public class Guest : MenuBase
    {
        public Guest(string name) : base(name)
        {
        }

        public override int PriorityNumber { get; protected set; } = 2;

        public override void Execute(Stack<string> namespaces)
        {
        }
    }
}
