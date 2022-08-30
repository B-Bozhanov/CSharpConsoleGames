using GameMenu.Repository.Interfaces;
using GameMenu.Utilities;

namespace GameMenu.Models.UserLoginMenu
{
    internal class ContinueWithoutAccount : Menu
    {
        private const int MenuNumber = 3;

        public ContinueWithoutAccount(int row, int col, IRepository<string> namespaces) 
            : base(MenuNumber, row, col, namespaces)
        {
        }

        public override string GetName()
        {
            return "Continue without account";
        }
        public override string Execute()
        {
            this.namespaces.Add(NameSpacesInfo.MainMenu);
            return this.namespaces.Get();
        }
    }
}
