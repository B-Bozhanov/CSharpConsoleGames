namespace Snake.Services.Drowers
{
    using System.Collections.Generic;

    using Snake.Models;
    using Snake.Models.Models.Menues;

    using static Common.GlobalConstants;

    public class ConsoleDrowerService : DrowerBase, IDrowerService
    {
        public void DrowInfoWindow(Coordinates startPossition, Color infoWindowColor = Color.DarkGray)
        {
            ConsoleColor color = GetColor(infoWindowColor);
            string infoWindowString = GetInfoWindow();
            Console.ForegroundColor = color;
            Console.SetCursorPosition(startPossition.Column, startPossition.Row);
            Console.Write(infoWindowString.Trim());
            Console.ResetColor();
        }

        public void DrowWalls(Coordinates startPossition, Color wallsColor = Color.DarkGray)
        {
            ConsoleColor color = GetColor(wallsColor);
            Console.SetCursorPosition(startPossition.Column, startPossition.Row);
            string walls = GetWalls();
            Console.ForegroundColor = color;
            Console.Write(walls);
            Console.ResetColor();
        }

        private static ConsoleColor GetColor(Color color)
        {
            var consoleColor = Enum.GetValues<ConsoleColor>().FirstOrDefault(x => x.ToString() == color.ToString());
            return consoleColor;
        }

        private static void Drow(string text, Coordinates coordinatesToDrow, Color color = Color.Black)
        {
            Console.SetCursorPosition(coordinatesToDrow.Column, coordinatesToDrow.Row);
            var consoleColor = GetColor(color);
            Console.ForegroundColor = consoleColor;
            Console.Write(text);
            Console.ResetColor();
        }

        public void DrowEmpty(Coordinates coordinates, Color color = Color.Black)
        {
            Drow(Field.InfoWindow.EmptySymbol.ToString(), coordinates, color);
        }

        public void DrowInfoWindowData(int score, int level, Color color = Color.White)
        {
            Drow(string.Format(Field.InfoWindowData.ScoreMessage, score), this.ScorePossition, color);
            Drow(string.Format(Field.InfoWindowData.LevelMessage, level), this.LevelPossition, color);
        }

        public void DrowGameOver(int score, int level, Color color)
        {
            Drow(string.Format(Field.InfoWindowData.GameOverScoreMessage, Environment.NewLine, score, level), this.ScorePossition, color);
        }

        public void Drow(IEnumerable<Coordinates> collection)
        {
            foreach (var item in collection)
            {
                Drow(item.Symbol.ToString()!, new Coordinates(item.Row, item.Column), item.Color);
            }
        }

        public void Drow(Coordinates coordinates)
        {
            Drow(coordinates.Symbol.ToString()!, coordinates, coordinates.Color);
        }

        public void Drow(IEnumerable<IMenu> menues)
        {
            foreach (var menu in menues)
            {
                this.Drow(menu.Coordinates);
            }
        }
    }
}
