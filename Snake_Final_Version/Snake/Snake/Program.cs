using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Text;

namespace Snake
{
   
    class Program
    {
        static void Main(string[] args)
        {
            //GameSettings gameSettings = new GameSettings(44, 191, ConsoleColor.White, ConsoleColor.Black, 6);
            GameMenu gameMenu = new GameMenu();
            gameMenu.WellcomeSreen();
        }
    }
}
