using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.UserLoginMenu
{
    internal class Login : Menu
    {
        private const int MenuNumber = 1;

        public Login(int row, int col, IRepository<string> namespaces) 
            : base(MenuNumber, row, col, namespaces)
        {
        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
