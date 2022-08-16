using System;

namespace Snake
{
    internal class StartUp
    {
        const int fieldRow = 30;
        const int fieldCol = 120;
        const int infoWindow = 2; // Is zero by default! 

        private static void Main()
        {
            Field field = new Field(new Coordinates(fieldRow, fieldCol));
            GameMenu menu = new GameMenu();
            Snake snake = new Snake(6);
            var engine = new Engine(snake);

            engine.Start();

            Main();
        }
    }
}
