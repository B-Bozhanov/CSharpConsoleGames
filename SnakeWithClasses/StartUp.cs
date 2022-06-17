namespace Snake
{
    internal class StartUp
    {
        const fieldRow = 30;
        const fieldCol = 120;
        const infoWindow = 2;

        static void Main(string[] args)
        {
            var field = new Field(new Coordinates(fieldRow, fieldCol));
            var visualizer = new Visualizer();
            var wellcome = new WellcomeScreen(field.ConsoleRow / 2 - 4, field.ConsoleCol / 2 - 3);
            var menu = new GameMenu(field.ConsoleRow / 2 -4 , field.ConsoleCol / 2 -3 ); // TODO: something with this!!
            int snakeLength = menu.GetSnakeLengthByUserOrDefault(); // Default is 6:
            var snake = new Snake(snakeLength);
            var engine = new Engine(field.ConsoleRow, field.ConsoleCol, snake);
            wellcome.Wellcome(true);
            menu.StartMainMenu();


           




            //Test test = new Test();
        }
    }
}
