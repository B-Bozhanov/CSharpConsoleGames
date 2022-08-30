namespace UserDatabase
{
    using global::UserDatabase.Interfaces;

    public class User : IUser
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }


        public string Username
        {
            get => this.username;
            private set => this.username = value;
        }

        public string Password
        {
            get => this.password;
            private set => this.password = value;
        }
    }
}
