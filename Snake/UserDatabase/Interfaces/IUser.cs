﻿using System.Diagnostics;

namespace UserDatabase.Interfaces
{
    public interface IUser
    {
        public string Username { get;}

        public string Password { get;}

        public int Score { get; set; }

        public bool IsBlocked { get; set; }

        public int BlockedTimeCount { get; set; }
    }
}