using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.UserLoginMenu
{
    internal class Login : Menu
    {
        private const int Number = 1;

        public Login(int row, int col, IRepository<string> namespaces) 
            : base(Number, row, col, namespaces)
        {
        }
    }
}
