using GameMenu.Menues.Interfaces;
using GameMenu.Repository.Interfaces;
using GameMenu.Utilities;

namespace GameMenu.Menues.UserLoginMenu
{
    internal class ContinueWithoutAccount : Menu
    {
        private const int SequenceNumber = 3;

        public ContinueWithoutAccount(int row, int col, IRepository<string> namespaces) 
            : base(SequenceNumber, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string GetName()
        {
            return "Continue without account";
        }
        public override string Execute(IField field)
        {
            this.namespaces.Add(NameSpacesInfo.MainMenu);
            return this.namespaces.Get();
        }
    }
}
