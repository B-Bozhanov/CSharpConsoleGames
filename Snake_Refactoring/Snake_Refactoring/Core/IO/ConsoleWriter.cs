namespace SnakeProject.Core.IO
{
    using Core.IO.Interfaces;
    using SnakeProject.Models.Field.Interfaces;
    using System.Text;
    using Utilites;

    internal class ConsoleWriter : IWriter
    {
        private readonly int row;
        private readonly int col;
        private readonly int infoWindow;
        public ConsoleWriter(IField field)
        {
            this.row = field.Row;
            this.col = field.Col;
            this.infoWindow = field.GameInfoWindow;
        }


        public void DrowingCursor(char item, Coordinates position)
        {
            throw new NotImplementedException();
        }

        public void DrowingGameInfo(int score, int level)
        {
            throw new NotImplementedException();
        }

        public void DrowingInfoWindow()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            var sb = new StringBuilder();

            sb.Append('╔');
            sb.Append(new string('═', this.col - 2));
            sb.Append('╗');

            Console.Write(sb.ToString().Trim());
            sb.Clear();

            for (int i = 0; i < infoWindow; i++)
            {
                sb.Append('║');
                sb.Append(new string(' ', this.col - 2));
                sb.Append('║');

                Console.Write(sb.ToString().Trim());
                sb.Clear();
            }

            sb.Append('╠');
            sb.Append(new string('═', this.col - 2));
            sb.Append('╣');

            Console.Write(sb.ToString().Trim());
            Console.ResetColor();
        }

        public void DrowingLevelWalls(int row, int infoWindow, int col)
        {
            throw new NotImplementedException();
        }

        public void DrowingMenu(string[] items, int row, int col)
        {
            throw new NotImplementedException();
        }

        public void DrowingSnake(ISnake snake)
        {
            int colorCount = 0;
            foreach (var element in snake.SnakeElements)
            {
                ConsoleColor color;
                if (colorCount % 2 == 0)
                {
                    color = ConsoleColor.DarkYellow;
                }
                else
                {
                    color = ConsoleColor.DarkGreen;
                }
                WriteOnConsole("●", element.Row, element.Col, color);
                colorCount++;
                //"●"
            }
            string direct = string.Empty;          // Snake Head
            if (snake.NextDirection == 0) direct = ">";
            if (snake.NextDirection == 1) direct = "<";
            if (snake.NextDirection == 2) direct = "V";
            if (snake.NextDirection == 3) direct = "^";

            WriteOnConsole(direct, snake.GetSnakeNextHead().Row, snake.GetSnakeNextHead().Col, ConsoleColor.Red);

            Coordinates snakeTail = snake.GetSnakeTail();
            WriteOnConsole(" ", snakeTail.Row, snakeTail.Col);
        }

        public void FoodDrowing(char symbol, Coordinates food)
        {
            throw new NotImplementedException();
        }

        public void GameOver(int score)
        {
            throw new NotImplementedException();
        }
        private void WriteOnConsole(string text, int row, int col, ConsoleColor color = ConsoleColor.Black)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
