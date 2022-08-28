namespace GameMenu.Models.UserLoginMenu
{
    using GameMenu.Models.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UsersDatabse.Interfaces;

    internal class CreateNewProfile : Menu, ICreateProfile<IUser>
    {
        private const int Number = 2;
        public CreateNewProfile(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override string GetName()
        {
            return "Create new profile";
        }

        public override string Execute()
        {
            return null;
        }

        public IUser Value()
        {
            throw new NotImplementedException();
        }
    }
}
