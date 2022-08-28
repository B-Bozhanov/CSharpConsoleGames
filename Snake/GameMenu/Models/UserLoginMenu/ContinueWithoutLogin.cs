using GameMenu.Repository.Interfaces;
using GameMenu.Utilities;

namespace GameMenu.Models.UserLoginMenu
{
    internal class ContinueWithoutLogin : Menu
    {
        private const int Number = 3;

        public ContinueWithoutLogin(int row, int col, IRepository<string> namespaces) 
            : base(Number, row, col, namespaces)
        {
        }

        public override string GetName()
        {
            return "Continue without accaunt";
        }

        public override string Execute()
        {
            this.namespaces.Push(NameSpacesInfo.MainMenu);
            return this.namespaces.Peek();
        }
    }
}
