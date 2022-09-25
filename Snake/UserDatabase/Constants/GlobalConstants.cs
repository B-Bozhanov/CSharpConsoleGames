namespace UserDatabase.Constants
{
    internal static class GlobalConstants
    {
       internal const int BlockTimeInMinutes = 15;
       internal const int RemoveUnUsedAccaundInDays = 30;
       internal const int AutoSaveCurrentAccountIntervalInSecconds = 1;
       internal const int AutoSaveDatabseIntervalInMinutes = 5;
       internal const int WrongPassAttemps = 2;
       internal const string Guest = "Guest";
       internal const string DefaultFilePath = "../../../../UserDatabase/UsersData/UserDatabse.json";
       internal const string DefaultTempFilePath = "../../../../UserDatabase/UsersData/CurrentUserData.json";
    }
}
