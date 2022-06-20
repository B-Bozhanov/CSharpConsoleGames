namespace Snake
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var field = new Field(new Coordinates(30, 120));
            var menu = new GameMenu(field.ConsoleRow / 2 -4 , field.ConsoleCol / 2 -3 ); // TODO: something with this!!
            var wellcome = new WellcomeScreen(field.ConsoleRow / 2 - 4, field.ConsoleCol / 2 - 3);
            int snakeLength = menu.GetSnakeLengthByUserOrDefault(); // Default is 6:
            var snake = new Snake(snakeLength);
            var engine = new Engine(field.ConsoleRow, field.ConsoleCol, snake);

            wellcome.Wellcome(true);
            menu.StartMainMenu();
            engine.Start();
        }
    }
}
