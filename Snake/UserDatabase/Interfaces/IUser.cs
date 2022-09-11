namespace UserDatabase.Interfaces
{
    public interface IUser
    {
        public string Username { get;}

        public string Password { get;}

        public int Score { get; set; }
    }
}
