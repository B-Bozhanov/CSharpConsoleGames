namespace Snake.Models.Menu.MainMenu
{
    using Snake.Common;
    using Snake.Models.Menu.Repository.Interfaces;

    internal class Settings : Menu
    {
        private const int SequenceNumber = 2;

        public Settings(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override int ID { get; protected set; }

        public override string Execute()
        {
            namespaces.Add(NameSpacesInfo.Settings);
            return null; // this.namespaces.Get(); 
        }
    }
}
