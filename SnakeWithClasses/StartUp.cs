namespace Snake
{
    internal class StartUp
    {
        const int fieldRow = 30;
        const int fieldCol = 120;
        const int infoWindow = 2; // Is zero by default! 

        private static void Main()
        {
            var field = new Field(new Coordinates(fieldRow, fieldCol), infoWindow);
            int menuRow = field.ConsoleRow / 2 - 4; //TODO: Get numbers from arrays.Length(from menues)
            int menuCol = field.ConsoleCol / 2 - 3;

            var menu = new GameMenu(menuRow, menuCol); // TODO: something with this!!
            menu.StartMainMenu();

            int snakeLength = menu.GetSnakeLengthByUserOrDefault(); // Default is 6:
            var snake = new Snake(snakeLength, infoWindow);
            var engine = new Engine(field.ConsoleRow, field.ConsoleCol, snake, menu.WellcomeScreen, infoWindow);

            engine.Start();

            Main();
        }
    }
}
