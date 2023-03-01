﻿namespace Snake.Models.Menu.Core
{
    using System;
    using System.Text;

    using Interfaces;

    using Snake.Common;

    public class ConsoleField : IField
    {
        private const int DefaultInfoWindowHeight = 2;

        public ConsoleField()
        {
            WindowResizer(WindowHeight, WindowWidth);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }


        public Coordinates InfoWindow { get; private set; }

        public int WindowHeight { get; private set; } = 30;//Console.LargestWindowHeight / 3;

        public int WindowWidth { get; private set; } = 120;//Console.LargestWindowWidth / 16;

        public static Coordinates MenuStartPossition { get; private set; } // TODO: Think something to remove static!

        public void WindowResizer(int row, int col)
        {
            WindowHeight = row;
            WindowWidth = col;
            InfoWindow = new Coordinates(DefaultInfoWindowHeight, WindowWidth);
            MenuStartPossition = new Coordinates(WindowHeight / 2 - 4, WindowWidth / 2 - 6); // TODO: Save magig numbers in const.
            SetSettings();
        }

        public void SetBackgroundColor(Color color)
        {
            var backGroundColor = GetColor(color);
            Console.BackgroundColor = backGroundColor;
        }

        public void SetTextColor(Color color)
        {
            var textColor = GetColor(color);
            Console.ForegroundColor = textColor;
        }
        public void ResetColor()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private ConsoleColor GetColor(Color color)
        {
            switch (color)
            {
                case Color.White:
                    return ConsoleColor.White;
                case Color.Black:
                    return ConsoleColor.Black;
                case Color.Red:
                    return ConsoleColor.Red;
                case Color.Green:
                    return ConsoleColor.Green;
                case Color.Blue:
                    return ConsoleColor.Blue;
                case Color.Yellow:
                    return ConsoleColor.Yellow;
                default:
                    break;
            }
            return default;
        }
        private void SetSettings()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.Title = "Snake v2.0";
                Console.CursorVisible = false;
                Console.WindowHeight = WindowHeight!;
                Console.WindowWidth = WindowWidth;
                Console.BufferHeight = WindowHeight;
                Console.BufferWidth = WindowWidth;
                Console.OutputEncoding = Encoding.UTF8;
                Console.SetWindowPosition(0, 0);
            }
        }
    }
}