namespace Snake.Drowers
{
    using System.Collections.Generic;

    using static Common.GlobalConstants;

    public class ConsoleDrower : DrowerBase, IDrower
    {
        private readonly Coordinates scorePossition;
        private readonly Coordinates levelPossition;

        public ConsoleDrower()
        {
            this.scorePossition = new Coordinates(Field.InfoWindowData.ScoreRowCoordinate, Field.InfoWindowData.ScoreColumnCoordinate);
            this.levelPossition = new Coordinates(Field.InfoWindowData.LevelRowCoordinate, Field.InfoWindowData.LevelColumnCoordinate);
        }

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
            Drow(string.Format(Field.InfoWindowData.ScoreMessage, score), this.scorePossition, color);
            Drow(string.Format(Field.InfoWindowData.LevelMessage, level), this.levelPossition, color);
        }

        public void DrowGameOver(int score, int level, Color color)
        {
            Drow(string.Format(Field.InfoWindowData.GameOverScoreMessage, Environment.NewLine, score, level), this.scorePossition, color);
        }

        public void Drow(IEnumerable<Coordinates> collection)
        {
            foreach (var item in collection)
            {
                Drow(item.Symbol.ToString()!, new Coordinates(item.Row, item.Column), item.Color);
            }
        }

        public void Drow(Coordinates coordinates, Color color = Color.None)
        {
            Drow(coordinates.Symbol.ToString()!, coordinates, coordinates.Color);
        }
    }
}
