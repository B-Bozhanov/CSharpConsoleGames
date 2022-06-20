﻿using System;
using System.Text;

namespace Snake
{
    internal class Field 
    {
       private readonly  int consoleRow;
       private readonly  int consoleCol;

        public Field(Coordinates fieldSize, int infoWindow)
        {                           
            this.consoleRow = 1 + infoWindow + 1 + fieldSize.Row + 1; // One is borders size.
            this.consoleCol = 1 + fieldSize.Col + 1;

            SetConsoleSettings();
        }
       
        public  int ConsoleRow { get => consoleRow; }
        public  int ConsoleCol { get => consoleCol; }

        private void SetConsoleSettings()
        {
            Console.CursorVisible = false;
            Console.Title = "Snake v1.2";
            Console.WindowHeight = consoleRow;
            Console.WindowWidth = consoleCol;
            Console.BufferHeight = consoleRow;
            Console.BufferWidth = consoleCol;
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}
