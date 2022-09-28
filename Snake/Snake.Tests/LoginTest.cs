namespace Snake.Tests
{
    using GameMenu.Menues;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Menues.UserLoginMenu;
    using GameMenu.Repository;
    using GameMenu.Repository.Interfaces;
    using UserDatabase;
    using UserDatabase.Interfaces;


    public class LoginTest
    {
        [Test]
        public void LoginShouldWorkCorrectly()
        {
            IDatabase database = new UserDatabase();
            IAccount account = new Account("Test", "test", 10);
            database.AddAccount(account);

            var result = database.GetAccount("Test");
            Assert.That(result, Is.EqualTo(account));
        }
    }
}
