using System;
using System.Diagnostics;

namespace Snake
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Field field = new Field(new Coordinates(30, 120));
            GameMenu menu = new GameMenu(field);
            menu.WellcomeScreen();
        }
    }
}
