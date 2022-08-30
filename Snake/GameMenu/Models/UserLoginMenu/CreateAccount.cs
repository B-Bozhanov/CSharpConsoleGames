using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.UserLoginMenu
{
    internal class CreateAccount : Menu
    {
        private const int MenuNumber = 2;

        public CreateAccount(int row, int col, IRepository<string> namespaces) 
            : base(MenuNumber, row, col, namespaces)
        {
        }

        public override string GetName()
        {
            return "Create new account";
        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
