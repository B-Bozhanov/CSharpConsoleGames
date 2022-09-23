namespace UserDatabase.Interfaces
{
    public interface IAccount
    {
        public string Username { get;}

        public string Password { get;}

        public int Score { get; set; }

        public bool IsBlocked { get; set; }

        public DateTime LastBlockedTime { get; set; }

        public DateTime LastLoggedInTime { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
