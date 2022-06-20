using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal static class Visualizer
    {
        public static void DrowingInfoWindow(int col, int infoWindow)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            var sb = new StringBuilder();

            sb.Append('╔');
            sb.Append(new string('═', col - 2));
            sb.Append('╗');
            Console.Write(sb.ToString().Trim());
            sb.Clear();

            for (int i = 0; i < infoWindow; i++)
            {
                sb.Append('║');
                sb.Append(new string(' ', col - 2));
                sb.Append('║');
                Console.Write(sb.ToString().Trim());
                sb.Clear();
            }

            sb.Append('╠');
            sb.Append(new string('═', col - 2));
            sb.Append('╣');
            Console.Write(sb.ToString().Trim());
            Console.ResetColor();
        }
        public static void DrowingLevelWalls(int row, int infoWindow, int col)
        {
            Console.SetCursorPosition(0, infoWindow + 2);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            var sb = new StringBuilder();

            for (int i = 0; i <= row - infoWindow - 3; i++)
            {
                sb.Append('║');
                sb.Append(new string(' ', col - 2));
                sb.Append('║');
                Console.Write(sb.ToString().Trim());
                sb.Clear();
            }
            sb.Append('╚');
            sb.Append(new string('═', col - 2));
            sb.Append('╝');
            Console.Write(sb.ToString().Trim());
            Console.ResetColor();
        }
        public static void GameOver(int score)
        {
            WriteOnConsole($"Game over!\n Your Score is: {score}\n", 1, 1, ConsoleColor.DarkRed);
        }
        public static void WriteOnConsole(string text, int row, int col, ConsoleColor color = ConsoleColor.Black)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void DrowingSnake(Queue<Coordinates> elements, int direction, Coordinates nextElementPossition)
        {
            int colorCount = 0;
            foreach (var element in elements)
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
            }
            string direct = string.Empty;          // Snake Head
            if (direction == 0) direct = ">";
            if (direction == 1) direct = "<";
            if (direction == 2) direct = "V";
            if (direction == 3) direct = "^";

            WriteOnConsole(direct, nextElementPossition.Row, nextElementPossition.Col, ConsoleColor.Red);

            Coordinates possitionToDelete = elements.Peek();
            WriteOnConsole(" ", possitionToDelete.Row, possitionToDelete.Col);
        }
        public static void DrowingGameInfo(int score, int level)
        {
            WriteOnConsole($"Score: {score}", 1, 1, ConsoleColor.Yellow);
            WriteOnConsole($"Level: {level}", 2, 1, ConsoleColor.Yellow);
        }
        public static void FoodDrowing(char symbol, Coordinates food)
        {
            WriteOnConsole(symbol.ToString(), food.Row, food.Col, ConsoleColor.Green);
        }
        public static void ObstaclesDrowing(Obstacles obstacles)
        {
            foreach (var o in obstacles.ObstaclesList)
            {
                WriteOnConsole(obstacles.Symbol.ToString(), o.Row, o.Col, ConsoleColor.Cyan);
            }
        }
        public static void DrowingMenu(string[] items, int row, int col)
        {
            for (int i = 0; i < items.Length; i++)
            {
                WriteOnConsole(items[i], row + i, col, ConsoleColor.Yellow);
            }
        }
        public static void DrowingCursor(char item, Coordinates position)
        {
            WriteOnConsole(item.ToString(), position.Row, position.Col, ConsoleColor.Yellow);
        }
        public static void Exit()
        {
            Environment.Exit(0); // TODO: Fix this
        }
    }
}
