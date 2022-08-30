﻿using GameMenu.IO;
using GameMenu.IO.Interfaces;
using GameMenu.Repository.Interfaces;
using UserDatabase;
using UserDatabase.Interfaces;

namespace GameMenu.Models.UserLoginMenu
{
    internal class CreateAccount : Menu
    {
        private const int MenuNumber = 2;
        private readonly IUserDatabase users;
        private readonly IWriter writer;
        private readonly IReader reader;

        public CreateAccount(int row, int col, IRepository<string> namespaces, IUserDatabase users)
           : base(MenuNumber, row, col, namespaces)
        {
            this.users = users;
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
        }

        public override string GetName()
        {
            return "Create new account";
        }

        public override string Execute()
        {
            string username = string.Empty;
            string password = string.Empty;

            while (true)
            {
                this.writer.Clear();
                this.writer.Write("Enter username: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                username = this.reader.ReadeLine();

                this.writer.Clear();
                this.writer.Write("Enter password: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                password = this.reader.ReadeLine();

                try
                {
                    IUser user = new User(username, password);
                    this.users.Add(user);
                    break;
                }
                catch (Exception ex)
                {
                    this.writer.Clear();
                    this.writer.Write(ex.Message, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                    Thread.Sleep(2000);
                }
            }
            return username;
        }
    }
}
