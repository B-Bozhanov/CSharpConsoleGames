namespace Snake.Drowers
{
    using Common;

    public class ConsoleDrower : DrowerBase, IDrower
    {
        public void DrowInfoWindow(Coordinates startPossition, Color infoWindowColor = Color.DarkGray)
        {
            ConsoleColor color = GetColor(infoWindowColor);
            string infoWindowString = GetInfoWindow();
            Console.ForegroundColor = color;
            Console.SetCursorPosition(startPossition.Column, startPossition.Row);
            Console.Write(infoWindowString.ToString().Trim());
            Console.ResetColor();
        }

        public void DrowWalls(Coordinates startPossition, Color wallsColor = Color.DarkGray)
        {
            ConsoleColor color = GetColor(wallsColor);
            Console.SetCursorPosition(startPossition.Column, startPossition.Row);
            string walls = GetWalls();
            Console.ForegroundColor = color;
            Console.WriteLine(walls);
            Console.ResetColor();
        }

        private static ConsoleColor GetColor(Color color)
        {
            var consoleColor = Enum.GetValues<ConsoleColor>().FirstOrDefault(x => x.ToString() == color.ToString());
            return consoleColor;
        }

        public void Drow(string text, Coordinates coordinatesToDrow, Color color = Color.Black)
        {
            Console.SetCursorPosition(coordinatesToDrow.Column, coordinatesToDrow.Row);
            var consoleColor = GetColor(color);
            Console.ForegroundColor = consoleColor;
            Console.Write(text);
            Console.ResetColor();
        }

        public void Drow(Coordinates coordinates)
        {
            this.Drow(GlobalConstants.Field.InfoWindow.EmptySymbol.ToString(), coordinates, Color.Black);
        }
    }
}
