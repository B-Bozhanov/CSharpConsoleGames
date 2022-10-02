namespace GameMenu.Menues.MainMenu
{
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;

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
            this.namespaces.Add(NameSpacesInfo.Settings);
            return null; // this.namespaces.Get(); 
        }
    }
}
