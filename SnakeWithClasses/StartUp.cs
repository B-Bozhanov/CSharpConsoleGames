namespace Snake
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Field field = new Field(new Coordinates(30, 120));
            GameMenu menu = new GameMenu(field.ConsoleRow / 2 -4 , field.ConsoleCol / 2 -3 ); // TODO: something with this!!
            WellcomeScreen wellcome = new WellcomeScreen(field.ConsoleRow / 2 - 3, field.ConsoleCol / 2 - 4);

            wellcome.Wellcome(true);
            menu.StartMainMenu();
            int snakeLength = menu.GetSnakeLengthByUser(); // Default is 6:

            Engine.Start(field, snakeLength);

            //Test test = new Test();
        }
    }
}
